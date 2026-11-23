using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Servicios.GESTOR_SERIALIZACION gestorXML = new Servicios.GESTOR_SERIALIZACION();

        public void RegistrarOrdenCompra(BE.ORDEN_COMPRA nuevaOrden)
        {
            nuevaOrden.Estado = "Emitida";
            nuevaOrden.Fecha_Emision = DateTime.Now;

            mpOrdenCompra.Alta(nuevaOrden);

            var bllProveedor = new BLL.PROVEEDOR_INSUMO();
            var proveedor = bllProveedor.ListarProveedores()
                .Find(p => p.Id_Proveedor == nuevaOrden.Id_Proveedor);

            gestorPDF.GenerarComprobantePDF(nuevaOrden, proveedor);

            string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OrdenesDeCompra");
            string rutaXml = Path.Combine(carpeta, $"OrdenCompra_{nuevaOrden.Id_OrdenCompra}_{DateTime.Now:yyyyMMdd_HHmmss}.xml");
            gestorXML.SerializarXML(nuevaOrden, rutaXml);
        }
        public void ExportarOrdenXML(BE.ORDEN_COMPRA orden, string rutaArchivo)
        {
            if (orden == null)
                throw new Exception("Debe seleccionar una Orden de Compra válida para exportar.");

            gestorXML.SerializarXML(orden, rutaArchivo);
        }

        public BE.ORDEN_COMPRA ImportarOrdenXML(string rutaArchivo)
        {
            return gestorXML.DeserializarXML<BE.ORDEN_COMPRA>(rutaArchivo);
        }
        public void RegistrarRecepcionInsumo(BE.ORDEN_COMPRA ordenSeleccionada)
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
