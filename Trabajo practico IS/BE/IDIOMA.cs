using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class IDIOMA
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private bool estaDisponible;

		public bool EstaDisponible
		{
			get { return estaDisponible; }
			set { estaDisponible = value; }
		}

	}
}
