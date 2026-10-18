using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RECEPCION
    {
        private DAL.MP_ORDEN_COMPRA mpOrdenCompra = new DAL.MP_ORDEN_COMPRA();
        private DAL.MP_INVENTARIO mpInventario = new DAL.MP_INVENTARIO();

        // Diagrama CU-06: ObtenerDetalles(idOC)[cite: 13]
        public List<BE.DETALLE_OC> ObtenerDetalles(int idOC)
        {
            // Retorna List<DetallesOC>() para llenar la grilla del formulario[cite: 13]
            return mpOrdenCompra.LeerDetalles(idOC);
        }

        // Diagrama CU-06: ProcesarIngreso(idOC, listaDetallesRecibidos)[cite: 13]
        public void ProcesarIngreso(int idOC, List<BE.DETALLE_OC> listaDetallesRecibidos)
        {
            // 1. Primero actualizamos el stock físico en la base de datos[cite: 13]
            mpInventario.ActualizarStock(listaDetallesRecibidos);

            // 2. Regla de negocio para determinar el estado final
            bool hayFaltantes = false;
            foreach (var detalle in listaDetallesRecibidos)
            {
                if (detalle.Cantidad_Recibida < detalle.Cantidad_Solicitada)
                {
                    hayFaltantes = true;
                    break;
                }
            }

            // 3. Flujos de estado según el diagrama CU-06[cite: 13]
            if (hayFaltantes)
            {
                mpOrdenCompra.ActualizarEstado(idOC, "Recibida con Faltantes"); 
            }
            else
            {
                mpOrdenCompra.ActualizarEstado(idOC, "Recibida"); 
            }
        }
    }
}
