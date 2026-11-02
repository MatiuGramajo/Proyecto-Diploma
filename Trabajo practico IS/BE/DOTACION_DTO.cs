using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DOTACION_DTO
    {
        public Dictionary<string, int> DotacionesRequeridas { get; set; } = new Dictionary<string, int>();

        public List<BE.PERSONAL> ListaPersonalDisponible { get; set; } = new List<BE.PERSONAL>();
    }
}
