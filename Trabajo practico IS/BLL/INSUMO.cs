using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INSUMO
    {
        private DAL.MP_INSUMO mpInsumo = new DAL.MP_INSUMO();

        
        public List<BE.INSUMO> ListarInsumos()
        {
            return mpInsumo.Listar();
        }

        
        public void Guardar(BE.INSUMO insumo)
        {
            if (mpInsumo.ExisteNombre(insumo.Nombre, insumo.Id_Insumo))
            {
                
                throw new Exception("Nombre Duplicado");
            }

            if (insumo.Id_Insumo == 0)
            {
                mpInsumo.Alta(insumo);
            }
            else
            {
                mpInsumo.Modificar(insumo);
            }
        }

        public void CambiarEstado(BE.INSUMO insumo)
        {
            insumo.Estado = (insumo.Estado == "Activo") ? "Inactivo" : "Activo";
            mpInsumo.Baja(insumo);
        }
    }
}

