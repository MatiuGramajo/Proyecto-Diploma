using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DEMANDA_TIPO_EVENTO_DTO
    {
		private string tipo_Evento;

		public string Tipo_Evento
		{
			get { return tipo_Evento; }
			set { tipo_Evento = value; }
		}
		private int cantidad_Eventos;

		public int Cantidad_Eventos
		{
			get { return cantidad_Eventos; }
			set { cantidad_Eventos = value; }
		}

	}
}
