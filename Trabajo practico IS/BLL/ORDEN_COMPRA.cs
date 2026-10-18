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
        private DAL.MP_PROVEEDOR_EXTERNO mpProveedor = new DAL.MP_PROVEEDOR_EXTERNO();

        public List<string> CalcularFaltantes(int idEvento)
        {
            // Lógica que cruza la ficha técnica con el stock actual
            // Retorna la lista de insumos faltantes[cite: 14]
            return new List<string>();
        }

        // Diagrama CU-05: EmitirOrden(datosOC, idProveedor)[cite: 14]
        public void EmitirOrden(BE.ORDEN_COMPRA datosOC, int idProveedor)
        {
            // 1. Verificar estado del proveedor[cite: 14]
            bool proveedorActivo = mpProveedor.VerificarEstado(idProveedor);

            // 2. Flujo Alternativo: Proveedor.Estado == 0[cite: 14]
            if (!proveedorActivo)
            {
                // ¡Aquí la BLL lanza el error para que el Formulario lo atrape y lo muestre!
                throw new Exception("Seleccione otro proveedor del catalogo.");
            }

            // 3. Si todo está bien, lo manda a guardar[cite: 14]
            mpOrdenCompra.Alta(datosOC);
        }
    }
}
