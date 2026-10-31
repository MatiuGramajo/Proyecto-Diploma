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
    public class MP_INSUMO : MAPPER<BE.INSUMO>
    {
        public override void Alta(INSUMO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Nombre", obj.Nombre));
            parametros.Add(acceso.CrearParametro("@Rubro", obj.Rubro));
            parametros.Add(acceso.CrearParametro("@Unidad_Medida", obj.Unidad_Medida));
            parametros.Add(acceso.CrearParametro("@Stock_Actual", obj.Stock_Actual));
            parametros.Add(acceso.CrearParametro("@Stock_Minimo", obj.Stock_Minimo));
            parametros.Add(acceso.CrearParametro("@Estado", string.IsNullOrEmpty(obj.Estado) ? "Activo" : obj.Estado));

            acceso.Escribir("INSERTAR_INSUMO", parametros);
            acceso.Cerrar();
        }

        public override void Baja(INSUMO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Insumo", obj.Id_Insumo));
            parametros.Add(acceso.CrearParametro("@Estado", obj.Estado));

            acceso.Escribir("CAMBIAR_ESTADO_INSUMO", parametros);
            acceso.Cerrar();
        }

        public override List<INSUMO> Listar()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_INSUMOS");
            acceso.Cerrar();

            List<BE.INSUMO> lista = new List<BE.INSUMO>();
            foreach (DataRow row in dt.Rows)
            {
                BE.INSUMO ins = new BE.INSUMO
                {
                    Id_Insumo = Convert.ToInt32(row["Id_Insumo"]),
                    Nombre = row["Nombre"].ToString(),
                    Rubro = row["Rubro"] != DBNull.Value ? row["Rubro"].ToString() : "",
                    Unidad_Medida = row["Unidad_Medida"].ToString(),
                    Stock_Actual = Convert.ToDecimal(row["Stock_Actual"]),
                    Stock_Minimo = Convert.ToDecimal(row["Stock_Minimo"]),
                    Estado = row["Estado"] != DBNull.Value ? row["Estado"].ToString().Trim() : "Activo"
                };
                lista.Add(ins);
            }
            return lista;
        }

        public bool ExisteNombre(string nombre, int id)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Nombre", nombre));
            parametros.Add(acceso.CrearParametro("@Id_Insumo", id));

            DataTable dt = acceso.Leer("VERIFICAR_NOMBRE_INSUMO", parametros);
            acceso.Cerrar();

            return dt.Rows.Count > 0;
        }
        public override void Modificar(INSUMO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Insumo", obj.Id_Insumo));
            parametros.Add(acceso.CrearParametro("@Nombre", obj.Nombre));
            parametros.Add(acceso.CrearParametro("@Rubro", obj.Rubro));
            parametros.Add(acceso.CrearParametro("@Unidad_Medida", obj.Unidad_Medida));
            parametros.Add(acceso.CrearParametro("@Stock_Actual", obj.Stock_Actual));
            parametros.Add(acceso.CrearParametro("@Stock_Minimo", obj.Stock_Minimo));
            parametros.Add(acceso.CrearParametro("@Estado", string.IsNullOrEmpty(obj.Estado) ? "Activo" : obj.Estado));

            acceso.Escribir("ACTUALIZAR_INSUMO", parametros);
            acceso.Cerrar();
        }

        public override bool Verificar(INSUMO obj)
        {
            throw new NotImplementedException();
        }
    }
}
