using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class VOLUMEN_EVENTOS_DTO
    {
		private string mes_Año;

		public string Mes_Año
		{
			get { return mes_Año; }
			set { mes_Año = value; }
		}
		private int cantidad_Eventos;

		public int Cantidad_Eventos
		{
			get { return cantidad_Eventos; }
			set { cantidad_Eventos = value; }
		}
		
	}
}
