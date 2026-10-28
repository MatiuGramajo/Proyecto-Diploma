using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SERVICIO_CATERING
    {
       
            private DAL.MP_SERVICIO_CATERING mpCatering = new DAL.MP_SERVICIO_CATERING();

            public List<BE.SERVICIO_CATERING> Listar()
            {
                return mpCatering.Listar();
            }
        
    }
}
