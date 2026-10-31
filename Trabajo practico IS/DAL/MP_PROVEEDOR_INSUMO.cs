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
    public class MP_PROVEEDOR_INSUMO : MAPPER<BE.PROVEEDOR_INSUMO>
    {
        public override void Alta(PROVEEDOR_INSUMO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Razon_Social", obj.Razon_Social));
            parametros.Add(acceso.CrearParametro("@CUIT", obj.Cuit));
            parametros.Add(acceso.CrearParametro("@Rubro", obj.Rubro));
            parametros.Add(acceso.CrearParametro("@Telefono",   obj.Telefono));
            parametros.Add(acceso.CrearParametro("@Direccion", obj.Direccion));
            parametros.Add(acceso.CrearParametro("@Email", obj.Email));
            parametros.Add(acceso.CrearParametro("@Estado", string.IsNullOrEmpty(obj.Estado) ? "Activo" : obj.Estado));

            acceso.Escribir("INSERTAR_PROVEEDOR_INSUMO", parametros);
            acceso.Cerrar();
        }

        public override void Baja(PROVEEDOR_INSUMO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Proveedor", obj.Id_Proveedor));
            parametros.Add(acceso.CrearParametro("@Estado", obj.Estado));

            acceso.Escribir("CAMBIAR_ESTADO_PROVEEDOR_INSUMO", parametros);
            acceso.Cerrar();
        }
        

        public override List<PROVEEDOR_INSUMO> Listar()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_PROVEEDORES_INSUMOS");
            acceso.Cerrar();

            List<BE.PROVEEDOR_INSUMO> lista = new List<BE.PROVEEDOR_INSUMO>();
            foreach (DataRow row in dt.Rows)
            {
                BE.PROVEEDOR_INSUMO prov = new BE.PROVEEDOR_INSUMO
                {
                    Id_Proveedor = Convert.ToInt32(row["Id_Proveedor"]),
                    Razon_Social = row["Razon_Social"].ToString(),
                    Cuit = row["CUIT"].ToString(),
                    Rubro = row["Rubro"] != DBNull.Value ? row["Rubro"].ToString() : "",
                    Telefono = row["Telefono"] != DBNull.Value ? row["Telefono"].ToString() : "",
                    Direccion = row["Direccion"] != DBNull.Value ? row["Direccion"].ToString() : "",
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    Estado = row["Estado"] != DBNull.Value ? row["Estado"].ToString() : "Activo"
                };
                lista.Add(prov);
            }
            return lista;
        }

        public bool ExisteCUIT(string cuit, int id)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@CUIT", cuit));
            parametros.Add(acceso.CrearParametro("@Id_Proveedor", id));

            DataTable dt = acceso.Leer("VERIFICAR_CUIT_PROVEEDOR", parametros);
            acceso.Cerrar();

            return dt.Rows.Count > 0;
        }
        public override void Modificar(PROVEEDOR_INSUMO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Proveedor", obj.Id_Proveedor));
            parametros.Add(acceso.CrearParametro("@Razon_Social", obj.Razon_Social));
            parametros.Add(acceso.CrearParametro("@CUIT", obj.Cuit));
            parametros.Add(acceso.CrearParametro("@Rubro", obj.Rubro));
            parametros.Add(acceso.CrearParametro("@Telefono", obj.Telefono));
            parametros.Add(acceso.CrearParametro("@Direccion", obj.Direccion));
            parametros.Add(acceso.CrearParametro("@Email", obj.Email));
            parametros.Add(acceso.CrearParametro("@Estado", string.IsNullOrEmpty(obj.Estado) ? "Activo" : obj.Estado));

            acceso.Escribir("ACTUALIZAR_PROVEEDOR_INSUMO", parametros);
            acceso.Cerrar();
        }

        public override bool Verificar(PROVEEDOR_INSUMO obj)
        {
            throw new NotImplementedException();
        }
    }
}
