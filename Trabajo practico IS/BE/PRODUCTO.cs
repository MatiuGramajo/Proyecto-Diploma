using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PRODUCTO
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

		private decimal precio;

		public decimal Precio
		{
			get { return precio; }
			set { precio = value; }
		}

		private int stock;

		public int Stock
		{
			get { return stock; }
			set { stock = value; }
		}

		private bool activo;

		public bool Activo
		{
			get { return activo; }
			set { activo = value; }
		}

        public PRODUCTO()
        {
            this.Activo = true;
        }
    }
}
