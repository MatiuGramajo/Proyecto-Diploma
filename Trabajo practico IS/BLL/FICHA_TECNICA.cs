using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FICHA_TECNICA
    {
        private DAL.MP_FICHA_TECNICA mpFicha = new DAL.MP_FICHA_TECNICA();

        // Diagrama CU-04: ValidarDatos(invitados, catering)
        public void ValidarDatos(int invitados, int idCatering)
        {
            // Flujo Alternativo: No completa campos
            if (invitados <= 0 || idCatering <= 0)
            {
                throw new Exception("Faltan campos por completar.");
            }
        }

        // Diagrama CU-04: ConsolidarFicha(datosFicha)
        public void ConsolidarFicha(BE.FICHA_TECNICA datosFicha)
        {
            mpFicha.RegistrarDetallesyActualizarEstado(datosFicha);
        }
    }
}

