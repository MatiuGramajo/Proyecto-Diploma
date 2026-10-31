using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PROVEEDOR_INSUMO
    {
        private DAL.MP_PROVEEDOR_INSUMO mpProveedor = new DAL.MP_PROVEEDOR_INSUMO();

        public List<BE.PROVEEDOR_INSUMO> ListarProveedores()
        {
            return mpProveedor.Listar();
        }

        public void Guardar(BE.PROVEEDOR_INSUMO proveedor)
        {
            if (mpProveedor.ExisteCUIT(proveedor.Cuit, proveedor.Id_Proveedor))
            {
                throw new Exception("CUIT DUPLICADO");
            }

            if (proveedor.Id_Proveedor == 0)
            {
                mpProveedor.Alta(proveedor);
            }
            else
            {
                mpProveedor.Modificar(proveedor);
            }
        }
        public void CambiarEstado(BE.PROVEEDOR_INSUMO proveedor)
        {
            proveedor.Estado = (proveedor.Estado == "Activo") ? "Inactivo" : "Activo";
            mpProveedor.Baja(proveedor);
        }
    }
}
