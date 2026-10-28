using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PRESTADOR_SERVICIO
    {
       
        
            private DAL.MP_PRESTADOR_SERVICIO mpPrestador = new DAL.MP_PRESTADOR_SERVICIO();

            public List<BE.PRESTADOR_SERVICIO> Listar()
            {
                return mpPrestador.Listar();
           }
        
    }
}
