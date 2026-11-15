using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PERSONAL_ASISTENCIA_DTO
    {
		private string nombre_Completo;

		public string Nombre_Completo
		{
			get { return nombre_Completo; }
			set { nombre_Completo = value; }
		}
		private string categoria;

		public string Categoria
		{
			get { return categoria; }
			set { categoria = value; }
		}
		private int cantidad_Eventos;

		public int Cantidad_Eventos
		{
			get { return cantidad_Eventos; }
			set { cantidad_Eventos = value; }
		}
	
	}
}
