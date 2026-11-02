using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PERSONAL
    {
        private DAL.MP_PERSONAL mpPersonal = new DAL.MP_PERSONAL();

        public List<BE.PERSONAL> ListarPersonalActivo()
        {
            return mpPersonal.ListarActivos();
        }
        public List<BE.PERSONAL> ListarPersonal()
        {
            return mpPersonal.Listar();
        }

        public void Guardar(BE.PERSONAL personal)
        {
            if (mpPersonal.ExisteDNI(personal.Dni, personal.Id_Personal))
            {
                throw new Exception("El DNI ingresado ya se encuentra registrado en el sistema.");
            }

            if (personal.Id_Personal == 0)
            {
                mpPersonal.Alta(personal);
            }
            else
            {
                mpPersonal.Modificar(personal);
            }
        }

        public void CambiarEstado(BE.PERSONAL personal)
        {
            personal.Estado = (personal.Estado == "Activo") ? "Inactivo" : "Activo";
            mpPersonal.Baja(personal);
        }
    }

}
