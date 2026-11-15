using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DISTRIBUCION_CATEGORIA_DTO
    {
		private string categoria;

		public string Categoria
		{
			get { return categoria; }
			set { categoria = value; }
		}
		private int cantidad_Asignaciones;

		public int Cantidad_Asignaciones
		{
			get { return cantidad_Asignaciones; }
			set { cantidad_Asignaciones = value; }
		}

	}
}
