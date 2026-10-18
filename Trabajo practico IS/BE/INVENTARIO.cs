using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class INVENTARIO
    {
		private int id_Insumo;

		public int Id_Insumo
		{
			get { return id_Insumo; }
			set { id_Insumo = value; }
		}
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private int stock_Actual;

		public int Stock_Actual
		{
			get { return stock_Actual; }
			set { stock_Actual = value; }
		}

	}
}
