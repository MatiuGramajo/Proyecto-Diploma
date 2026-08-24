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
    public class MP_PRODUCTO : MAPPER<BE.PRODUCTO>
    {
        public override void Alta(BE.PRODUCTO producto)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nombre", producto.Nombre));
            parametros.Add(acceso.CrearParametro("@precio", producto.Precio));
            parametros.Add(acceso.CrearParametro("@stock", producto.Stock));
            producto.Id = acceso.LeerEscalar("INSERTAR_PRODUCTO", parametros);
            acceso.Cerrar();

        }

        public override void Baja(BE.PRODUCTO producto)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", producto.Id));
            acceso.Escribir("BORRAR_PRODUCTO", parametros);
            acceso.Cerrar();
        }

        public override List<BE.PRODUCTO> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_PRODUCTOS");
            acceso.Cerrar();

            List<BE.PRODUCTO> productos = new List<BE.PRODUCTO>();
            foreach (DataRow registro in tabla.Rows)
            {
                BE.PRODUCTO prod = new BE.PRODUCTO();
                prod.Id = int.Parse(registro["ID_PRODUCTO"].ToString());
                prod.Nombre = registro["NOMBRE"].ToString();
                prod.Precio = decimal.Parse(registro["PRECIO"].ToString());
                prod.Stock = int.Parse(registro["STOCK"].ToString());
                prod.Activo = Convert.ToBoolean(registro["ACTIVO"]);

                productos.Add(prod);
            }
            return productos;
        }

        public override void Modificar(BE.PRODUCTO producto)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", producto.Id));
            parametros.Add(acceso.CrearParametro("@nombre", producto.Nombre));
            parametros.Add(acceso.CrearParametro("@precio", producto.Precio));
            parametros.Add(acceso.CrearParametro("@stock", producto.Stock));
            int res = acceso.Escribir("MODIFICAR_PRODUCTO", parametros);
        }

        public void Reactivar(BE.PRODUCTO producto)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", producto.Id));
            acceso.Escribir("REACTIVAR_PRODUCTO", parametros);
            acceso.Cerrar();
        }

        public override bool Verificar(BE.PRODUCTO producto)
        {
            throw new NotImplementedException();
        }


    }
}
