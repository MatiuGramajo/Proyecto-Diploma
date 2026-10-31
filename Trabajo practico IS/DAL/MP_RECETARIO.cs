using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_RECETARIO : MAPPER<BE.DETALLE_RECETARIO>
    {
        public List<BE.DETALLE_RECETARIO> LeerRecetarioPorServicio(int idServicio)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Servicio", idServicio));

            DataTable dt = acceso.Leer("OBTENER_RECETARIO_SERVICIO", parametros);
            acceso.Cerrar();

            List<BE.DETALLE_RECETARIO> lista = new List<BE.DETALLE_RECETARIO>();
            foreach (DataRow row in dt.Rows)
            {
                BE.DETALLE_RECETARIO detalle = new BE.DETALLE_RECETARIO
                {
                    Id_Detalle_Recetario = Convert.ToInt32(row["Id_Detalle_Recetario"]),
                    Id_Servicio = Convert.ToInt32(row["Id_Servicio"]),
                    Id_Insumo = Convert.ToInt32(row["Id_Insumo"]),
                    Cantidad_Por_Persona = Convert.ToDecimal(row["Cantidad_Por_Persona"]),
                    InsumoAsociado = new BE.INSUMO
                    {
                        Id_Insumo = Convert.ToInt32(row["Id_Insumo"]),
                        Nombre = row["Nombre_Insumo"].ToString(),
                        Rubro = row["Rubro_Insumo"] != DBNull.Value ? row["Rubro_Insumo"].ToString() : "",
                        Unidad_Medida = row["Unidad_Medida_Insumo"].ToString()
                    }
                };
                lista.Add(detalle);
            }
            return lista;
        }
        public void EliminarPorServicio(int idServicio)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Servicio", idServicio));
            acceso.Escribir("ELIMINAR_RECETARIO_SERVICIO", parametros);
            acceso.Cerrar();
        }
        public override void Alta(DETALLE_RECETARIO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Servicio", obj.Id_Servicio));
            parametros.Add(acceso.CrearParametro("@Id_Insumo", obj.Id_Insumo));
            parametros.Add(acceso.CrearParametro("@Cantidad_Por_Persona", obj.Cantidad_Por_Persona));

            acceso.Escribir("INSERTAR_DETALLE_RECETARIO", parametros);
            acceso.Cerrar();
        }

        public override void Baja(DETALLE_RECETARIO obj)
        {
            throw new NotImplementedException();
        }

        public override List<DETALLE_RECETARIO> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(DETALLE_RECETARIO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(DETALLE_RECETARIO obj)
        {
            throw new NotImplementedException();
        }
    }
}
