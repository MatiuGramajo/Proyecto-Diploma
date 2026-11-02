using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PARAMETRO_RATIO
    {
		private int id_Ratio;

		public int Id_Ratio
		{
			get { return id_Ratio; }
			set { id_Ratio = value; }
		}
		private string categoria;

		public string Categoria
		{
			get { return categoria; }
			set { categoria = value; }
		}
		private int cantidad_Invitados_Por_Personal;

		public int Cantidad_Invitados_Por_Personal
		{
			get { return cantidad_Invitados_Por_Personal; }
			set { cantidad_Invitados_Por_Personal = value; }
		}
		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}

	}
}
