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
    public class MP_ORDEN_COMPRA : MAPPER<BE.ORDEN_COMPRA>
    {
        public override void Alta(ORDEN_COMPRA obj)
        {
            acceso.Abrir();

            // 1. Insertar Cabecera
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Ficha", obj.Id_Ficha));
            parametros.Add(acceso.CrearParametro("@Id_Proveedor", obj.Id_Proveedor));
            parametros.Add(acceso.CrearParametro("@Estado", obj.Estado));

            // Usamos LeerEscalar para capturar el ID autogenerado
            obj.Id_OrdenCompra = acceso.LeerEscalar("INSERTAR_ORDEN_COMPRA", parametros);

            // 2. Insertar Detalles asociados
            foreach (var detalle in obj.Detalles)
            {
                List<SqlParameter> paramDetalle = new List<SqlParameter>();
                paramDetalle.Add(acceso.CrearParametro("@Id_OrdenCompra", obj.Id_OrdenCompra));
                paramDetalle.Add(acceso.CrearParametro("@Id_Insumo", detalle.Id_Insumo));
                paramDetalle.Add(acceso.CrearParametro("@Cantidad_Solicitada", detalle.Cantidad_Solicitada));

                acceso.Escribir("INSERTAR_DETALLE_OC", paramDetalle);
            }
            acceso.Cerrar();

        }

        public List<BE.DETALLE_OC> LeerDetalles(int idOC)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_OrdenCompra", idOC));

            DataTable dt = acceso.Leer("LEER_DETALLES_OC", parametros);
            acceso.Cerrar();

            List<BE.DETALLE_OC> detalles = new List<BE.DETALLE_OC>();
            foreach (DataRow row in dt.Rows)
            {
                BE.DETALLE_OC det = new BE.DETALLE_OC();
                det.Id_Detalle = Convert.ToInt32(row["Id_Detalle"]);
                det.Id_OrdenCompra = Convert.ToInt32(row["Id_OrdenCompra"]);
                det.Id_Insumo = Convert.ToInt32(row["Id_Insumo"]);
                det.Cantidad_Solicitada = Convert.ToInt32(row["Cantidad_Solicitada"]);
                det.Cantidad_Recibida = Convert.ToInt32(row["Cantidad_Recibida"]);
                detalles.Add(det);
            }
            return detalles;
        }

        // Refleja ActualizarEstado(idOC, estado) que retorna void[cite: 11]
        public void ActualizarEstado(int idOC, string estado)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_OrdenCompra", idOC));
            parametros.Add(acceso.CrearParametro("@Estado", estado));

            acceso.Escribir("ACTUALIZAR_ESTADO_OC", parametros);
            acceso.Cerrar();
        }

        public override void Baja(ORDEN_COMPRA obj)
        {
            throw new NotImplementedException();
        }

        public override List<ORDEN_COMPRA> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(ORDEN_COMPRA obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(ORDEN_COMPRA obj)
        {
            throw new NotImplementedException();
        }
    }
}
