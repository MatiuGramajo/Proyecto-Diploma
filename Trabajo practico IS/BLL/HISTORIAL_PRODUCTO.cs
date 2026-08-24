using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HISTORIAL_PRODUCTO
    {
        MP_HISTORIAL_PRODUCTO mapper = new MP_HISTORIAL_PRODUCTO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();

        public void RegistrarCambio(int idProducto, string responsable, string tipoMovimiento)
        {
            mapper.RegistrarEnHistorial(idProducto, responsable, tipoMovimiento);
        }

        public List<BE.HISTORIAL_PRODUCTO> Listar()
        {
            return mapper.Listar();
        }
        public void RestaurarProducto(int idHistorial)
        {
            string responsable = Servicios.SESION.GetInstancia().usuactual != null
                                 ? Servicios.SESION.GetInstancia().usuactual.Usuario
                                 : "SISTEMA";

            mapper.RestaurarVersion(idHistorial, responsable);
            GestorBitacora.RegistrarEvento("Inventario", $"Se restauró un producto desde el registro histórico ID: {idHistorial}", 2);
        }
    }
}
