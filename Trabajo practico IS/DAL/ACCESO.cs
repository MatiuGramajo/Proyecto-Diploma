using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ACCESO
    {
        SqlConnection conexion;

        public void Abrir()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Initial Catalog=BASE;Data Source=.;Integrated Security=SSPI";
            conexion.Open();
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

        public int Escribir(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = CrearComando(query, parametros);
            int filas = 0;

            try
            {
                cmd.ExecuteNonQuery();
            }
                catch (Exception ex)
            {
                filas = -1;
            }

            cmd.Parameters.Clear();
            cmd = null;
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
