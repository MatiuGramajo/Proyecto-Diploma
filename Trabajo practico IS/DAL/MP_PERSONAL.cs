using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_PERSONAL : MAPPER<BE.PERSONAL>
    {
        public override void Alta(PERSONAL obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@DNI", obj.Dni));
            parametros.Add(acceso.CrearParametro("@Nombre", obj.Nombre));
            parametros.Add(acceso.CrearParametro("@Apellido", obj.Apellido));
            parametros.Add(acceso.CrearParametro("@Categoria", obj.Categoria));
            parametros.Add(acceso.CrearParametro("@Telefono", obj.Telefono));
            parametros.Add(acceso.CrearParametro("@Direccion", obj.Direccion));
            parametros.Add(acceso.CrearParametro("@Email", obj.Email));
            parametros.Add(acceso.CrearParametro("@Estado", string.IsNullOrEmpty(obj.Estado) ? "Activo" : obj.Estado));

            acceso.Escribir("INSERTAR_PERSONAL", parametros);
            acceso.Cerrar();
        }
        public List<BE.PERSONAL> ListarActivos()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_PERSONAL_ACTIVO");
            acceso.Cerrar();

            List<BE.PERSONAL> lista = new List<BE.PERSONAL>();
            foreach (DataRow row in dt.Rows)
            {
                BE.PERSONAL p = new BE.PERSONAL
                {
                    Id_Personal = Convert.ToInt32(row["Id_Personal"]),
                    Dni = row["DNI"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Categoria = row["Categoria"].ToString(),
                    Telefono = row["Telefono"] != DBNull.Value ? row["Telefono"].ToString() : "",
                    Direccion = row["Direccion"] != DBNull.Value ? row["Direccion"].ToString() : "",
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    Estado = row["Estado"].ToString().Trim()
                };
                lista.Add(p);
            }
            return lista;
        }

        public override void Baja(PERSONAL obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Personal", obj.Id_Personal));
            parametros.Add(acceso.CrearParametro("@Estado", obj.Estado));

            acceso.Escribir("CAMBIAR_ESTADO_PERSONAL", parametros);
            acceso.Cerrar();
        }

        public bool ExisteDNI(string dni, int id)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@DNI", dni));
            parametros.Add(acceso.CrearParametro("@Id_Personal", id));

            DataTable dt = acceso.Leer("VERIFICAR_DNI_PERSONAL", parametros);
            acceso.Cerrar();

            return dt.Rows.Count > 0;
        }

        public override List<PERSONAL> Listar()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_PERSONAL");
            acceso.Cerrar();

            List<BE.PERSONAL> lista = new List<BE.PERSONAL>();
            foreach (DataRow row in dt.Rows)
            {
                BE.PERSONAL p = new BE.PERSONAL
                {
                    Id_Personal = Convert.ToInt32(row["Id_Personal"]),
                    Dni = row["DNI"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Categoria = row["Categoria"].ToString(),
                    Telefono = row["Telefono"] != DBNull.Value ? row["Telefono"].ToString() : "",
                    Direccion = row["Direccion"] != DBNull.Value ? row["Direccion"].ToString() : "",
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    Estado = row["Estado"] != DBNull.Value ? row["Estado"].ToString().Trim() : "Activo"
                };
                lista.Add(p);
            }
            return lista;
        }

        public override void Modificar(PERSONAL obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Personal", obj.Id_Personal));
            parametros.Add(acceso.CrearParametro("@DNI", obj.Dni));
            parametros.Add(acceso.CrearParametro("@Nombre", obj.Nombre));
            parametros.Add(acceso.CrearParametro("@Apellido", obj.Apellido));
            parametros.Add(acceso.CrearParametro("@Categoria", obj.Categoria));
            parametros.Add(acceso.CrearParametro("@Telefono", obj.Telefono));
            parametros.Add(acceso.CrearParametro("@Direccion", obj.Direccion));
            parametros.Add(acceso.CrearParametro("@Email", obj.Email));
            parametros.Add(acceso.CrearParametro("@Estado", string.IsNullOrEmpty(obj.Estado) ? "Activo" : obj.Estado));

            acceso.Escribir("ACTUALIZAR_PERSONAL", parametros);
            acceso.Cerrar();
        }

        public override bool Verificar(PERSONAL obj)
        {
            throw new NotImplementedException();
        }
    }
}
