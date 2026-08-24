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
    public class MP_HISTORIAL_PRODUCTO
    {
        DAL.ACCESO acceso = new DAL.ACCESO();

        public void RegistrarEnHistorial(int idProducto, string responsable, string tipoAccion)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id_producto", idProducto));
            parametros.Add(acceso.CrearParametro("@usuario_accion", responsable));
            parametros.Add(acceso.CrearParametro("@tipo_accion", tipoAccion));

            acceso.Escribir("INSERTAR_HISTORIAL_PRODUCTO", parametros);
            acceso.Cerrar();
        }

        public List<BE.HISTORIAL_PRODUCTO> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_HISTORIAL_PRODUCTOS");
            acceso.Cerrar();

            List<BE.HISTORIAL_PRODUCTO> listaHistorial = new List<BE.HISTORIAL_PRODUCTO>();

            foreach (DataRow fila in tabla.Rows)
            {
                BE.HISTORIAL_PRODUCTO historial = new BE.HISTORIAL_PRODUCTO();

                historial.IdHistorial = int.Parse(fila["Id_Historial"].ToString());
                historial.UsuarioAccion = fila["Usuario_Accion"].ToString();
                historial.FechaCambio = DateTime.Parse(fila["Fecha_Cambio"].ToString());
                historial.TipoAccion = fila["Tipo_Accion"].ToString();
                historial.IdProducto = int.Parse(fila["Id_Producto"].ToString());
                historial.Nombre = fila["Nombre"].ToString();
                historial.Precio = decimal.Parse(fila["Precio"].ToString());
                historial.Stock = int.Parse(fila["Stock"].ToString());

                listaHistorial.Add(historial);
            }

            return listaHistorial;
        }

        public void RestaurarVersion(int idHistorial, string usuarioResponsable)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_historial", idHistorial));
            parametros.Add(acceso.CrearParametro("@usuario_accion", usuarioResponsable));
            acceso.Escribir("RESTAURAR_PRODUCTO_DESDE_HISTORIAL", parametros);
            acceso.Cerrar();
        }
    }
}
