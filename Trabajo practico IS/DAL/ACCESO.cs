using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class ACCESO
    {
        SqlConnection conexion;
        private static string cadenaValida = "";
        private static string servidorDetectado = "";
        private static readonly object _lockConexion = new object();

        public static string ObtenerCadenaMaster()
        {
            if (string.IsNullOrEmpty(servidorDetectado))
                new ACCESO().Abrir();

            return $@"Data Source={servidorDetectado};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";
        }

        public void Abrir()
        {
            conexion = new SqlConnection();

            if (!string.IsNullOrEmpty(cadenaValida))
            {
                conexion.ConnectionString = cadenaValida;
                conexion.Open();
                return;
            }

            lock (_lockConexion)
            {
                if (!string.IsNullOrEmpty(cadenaValida))
                {
                    conexion.ConnectionString = cadenaValida;
                    conexion.Open();
                    return;
                }

                List<string> instancias = ObtenerInstanciasCandidatas();
                Exception errorConexion = null;
                Exception errorScript = null;

                foreach (string instancia in instancias)
                {
                    string connMasterStr = $@"Data Source={instancia};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;Connection Timeout=2;";

                    try
                    {
                        using (SqlConnection connMaster = new SqlConnection(connMasterStr))
                        {
                            connMaster.Open();

                            try
                            {
                                if (!BaseDatosLista(connMaster))
                                {
                                    CrearBaseDesdeScript(connMaster);
                                }

                                servidorDetectado = instancia;
                                cadenaValida = $@"Data Source={instancia};Initial Catalog=BASE;Integrated Security=True;TrustServerCertificate=True;";
                                break;
                            }
                            catch (Exception exScript)
                            {
                                errorScript = exScript;
                            }
                        }
                    }
                    catch (Exception exConn)
                    {
                        errorConexion = exConn;
                    }
                }

                if (string.IsNullOrEmpty(cadenaValida))
                {
                    if (errorScript != null)
                        throw new Exception("Se conectó a SQL Server, pero falló la creación de la base de datos BASE: " + errorScript.Message, errorScript);

                    throw new Exception("No se pudo conectar a ninguna instancia local de SQL Server.", errorConexion);
                }
            }

            conexion.ConnectionString = cadenaValida;
            conexion.Open();
        }

        private static List<string> ObtenerInstanciasCandidatas()
        {
            var lista = new List<string>();
            AgregarInstanciasDesdeRegistro(lista, RegistryView.Registry64);
            AgregarInstanciasDesdeRegistro(lista, RegistryView.Registry32);

            string[] porDefecto = { @".\SQLEXPRESS", ".", @".\SQLEXPRESS01", @"(localdb)\MSSQLLocalDB" };
            foreach (string inst in porDefecto)
            {
                if (!lista.Contains(inst))
                    lista.Add(inst);
            }

            return lista;
        }

        private static void AgregarInstanciasDesdeRegistro(List<string> lista, RegistryView vista)
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, vista))
                using (RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
                {
                    if (key == null) return;

                    foreach (string nombreInstancia in key.GetValueNames())
                    {
                        string dataSource = nombreInstancia.Equals("MSSQLSERVER", StringComparison.OrdinalIgnoreCase)
                            ? "."
                            : @".\" + nombreInstancia;

                        if (!lista.Contains(dataSource))
                            lista.Add(dataSource);
                    }
                }
            }
            catch { }
        }

        private static bool BaseDatosLista(SqlConnection connMaster)
        {
            string sqlCheck = @"
                SELECT CASE 
                    WHEN DB_ID(N'BASE') IS NOT NULL 
                     AND COL_LENGTH(N'BASE.dbo.USUARIO', N'CONTRASEÑA') IS NOT NULL 
                    THEN 1 ELSE 0 
                END";

            using (SqlCommand cmd = new SqlCommand(sqlCheck, connMaster))
            {
                return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
        }
        private static void CrearBaseDesdeScript(SqlConnection connMaster)
        {
            string rutaScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InstalacionDB.sql");

            if (!File.Exists(rutaScript))
                throw new FileNotFoundException("No se encontró el archivo InstalacionDB.sql junto al ejecutable.", rutaScript);

            string sqlCrearBase = @"
                IF DB_ID(N'BASE') IS NOT NULL
                BEGIN
                    ALTER DATABASE [BASE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    DROP DATABASE [BASE];
                END
                CREATE DATABASE [BASE];";

            using (SqlCommand cmdCrear = new SqlCommand(sqlCrearBase, connMaster))
            {
                cmdCrear.ExecuteNonQuery();
            }

            connMaster.ChangeDatabase("BASE");

            string script = LeerScriptConEncodingSeguro(rutaScript);
            string[] lineas = script.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            StringBuilder bloque = new StringBuilder();

            foreach (string linea in lineas)
            {
                string lineaLimpia = linea.Trim();
                if (lineaLimpia.Equals("GO", StringComparison.OrdinalIgnoreCase) ||
                    lineaLimpia.StartsWith("GO ", StringComparison.OrdinalIgnoreCase) ||
                    lineaLimpia.StartsWith("GO\t", StringComparison.OrdinalIgnoreCase))
                {
                    string sql = bloque.ToString().Trim();
                    if (!string.IsNullOrEmpty(sql))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, connMaster))
                        {
                            cmd.CommandTimeout = 180;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    bloque.Clear();
                }
                else
                {
                    bloque.AppendLine(linea);
                }
            }

            string ultimoBloque = bloque.ToString().Trim();
            if (!string.IsNullOrEmpty(ultimoBloque))
            {
                using (SqlCommand cmd = new SqlCommand(ultimoBloque, connMaster))
                {
                    cmd.CommandTimeout = 180;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private static string LeerScriptConEncodingSeguro(string ruta)
        {
            byte[] bytes = File.ReadAllBytes(ruta);

            if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
                return Encoding.Unicode.GetString(bytes, 2, bytes.Length - 2);

            if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
                return Encoding.BigEndianUnicode.GetString(bytes, 2, bytes.Length - 2);

            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                return Encoding.UTF8.GetString(bytes, 3, bytes.Length - 3);

            try
            {
                return new UTF8Encoding(false, true).GetString(bytes);
            }
            catch (DecoderFallbackException)
            {
                return Encoding.GetEncoding(1252).GetString(bytes);
            }
        }
        public void Cerrar()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }

        public SqlCommand CrearComando(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Connection = conexion;

            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }

            return cmd;
        }

        public SqlParameter CrearParametro(string nombre,string valor)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = System.Data.DbType.String;
            param.Value = valor;
            param.ParameterName = nombre;

            return param;

        }
        public SqlParameter CrearParametro(string nombre, DateTime valor)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = System.Data.DbType.DateTime;
            param.Value = valor;
            param.ParameterName = nombre;

            return param;

        }
        public SqlParameter CrearParametro(string nombre, bool valor)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = System.Data.DbType.Boolean;
            param.Value = valor;
            param.ParameterName = nombre;

            return param;

        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = System.Data.DbType.Int32;
            param.Value = valor;
            param.ParameterName = nombre;

            return param;
        }

        public SqlParameter CrearParametro(string nombre, decimal valor)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = System.Data.DbType.Decimal;
            param.Value = valor;
            param.ParameterName = nombre;

            return param;
        }
        public SqlParameter CrearParametro(string nombre, long valor)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = System.Data.DbType.Int64; 
            param.Value = valor;
            param.ParameterName = nombre;
            return param;
        }
        public int Escribir(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = CrearComando(query, parametros);
            int filas = 0;

            try
            {
               filas= cmd.ExecuteNonQuery();
            }
                catch (Exception ex)
            {
                throw new Exception("Error en la base de datos : " + ex.Message);
            }
            finally
            {

                cmd.Parameters.Clear();
                cmd = null;
            }

            return filas;
        }

        public DataTable Leer(string query, List<SqlParameter> parametros = null)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = CrearComando(query,parametros);
            adapter.Fill(tabla);
            return tabla;
        }

        public int LeerEscalar(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = CrearComando(query, parametros);
            int res = 0;
            res = int.Parse(cmd.ExecuteScalar().ToString());
            return res;
        }

        public SqlDataReader Read(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = CrearComando(query, parametros);
            SqlDataReader reader = comando.ExecuteReader();
            return reader;
        }


    }
}
