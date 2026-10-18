using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PROVEEDOR_EXTERNO
    {
		private int id_Proveedor;

		public int Id_Proveedor
		{
			get { return id_Proveedor; }
			set { id_Proveedor = value; }
		}
		private string rubro;

		public string Rubro
		{
			get { return rubro; }
			set { rubro = value; }
		}
		private string nombre_Fantasia;

		public string Nombre_Fantasia
		{
			get { return nombre_Fantasia; }
			set { nombre_Fantasia = value; }
		}
		private int telefono_Contacto;

		public int Telefono_Contacto
		{
			get { return telefono_Contacto; }
			set { telefono_Contacto = value; }
		}

	}
}
