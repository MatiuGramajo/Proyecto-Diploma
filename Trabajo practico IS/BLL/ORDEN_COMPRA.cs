using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ORDEN_COMPRA
    {
        private DAL.MP_ORDEN_COMPRA mpOrdenCompra = new DAL.MP_ORDEN_COMPRA();
        private Servicios.GESTOR_PDF gestorPDF = new Servicios.GESTOR_PDF();
        private BLL.INSUMO bllInsumo = new BLL.INSUMO();
        public void RegistrarOrdenCompra(BE.ORDEN_COMPRA nuevaOrden)
        {
            nuevaOrden.Estado = "Emitida";
            nuevaOrden.Fecha_Emision = DateTime.Now;

            mpOrdenCompra.Alta(nuevaOrden);

            gestorPDF.GenerarComprobantePDF(nuevaOrden);
        }
        public void RegistrarRecepcion(BE.ORDEN_COMPRA ordenSeleccionada)
        {
            mpOrdenCompra.RegistrarRecepcion(ordenSeleccionada);

            foreach (BE.DETALLE_ORDEN_COMPRA detalle in ordenSeleccionada.Detalles)
            {
                if (detalle.Cantidad_Recibida > 0)
                {
                    bllInsumo.ActualizarStock(detalle.Nombre_Insumo, detalle.Cantidad_Recibida);
                }
            }
        }
        public List<BE.ORDEN_COMPRA> ListarOrdenesEmitidas()
        {
            return mpOrdenCompra.ListarEmitidas();
        }

        public void AnularOrdenCompra(int idOrden_Compra, string motivo)
        {
            mpOrdenCompra.Anular(idOrden_Compra, motivo);
        }

        public void ReasignarOrdenCompra(BE.ORDEN_COMPRA ordenOriginal, int idNuevoProveedor, string motivo)
        {
            mpOrdenCompra.Anular(ordenOriginal.Id_OrdenCompra, motivo);

            List<BE.DETALLE_ORDEN_COMPRA> nuevosDetalles = new List<BE.DETALLE_ORDEN_COMPRA>();
            foreach (var det in ordenOriginal.Detalles)
            {
                nuevosDetalles.Add(new BE.DETALLE_ORDEN_COMPRA
                {
                    Nombre_Insumo = det.Nombre_Insumo,
                    Cantidad_Solicitada = det.Cantidad_Solicitada,
                    Cantidad_Recibida = 0
                });
            }

            BE.ORDEN_COMPRA nuevaOrden = new BE.ORDEN_COMPRA
            {
                Id_Proveedor = idNuevoProveedor,
                Fecha_Emision = DateTime.Now,
                Estado = "Emitida",
                Detalles = nuevosDetalles
            };

            mpOrdenCompra.Alta(nuevaOrden);
        }
    }
}
