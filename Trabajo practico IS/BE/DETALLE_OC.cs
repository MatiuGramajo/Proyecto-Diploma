using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DETALLE_OC
    {
		private int id_Detalle;

		public int Id_Detalle
		{
			get { return id_Detalle; }
			set { id_Detalle = value; }
		}
		private int id_OrdenCompra;

		public int Id_OrdenCompra
		{
			get { return id_OrdenCompra; }
			set { id_OrdenCompra = value; }
		}
		private int id_Insumo;

		public int Id_Insumo
		{
			get { return id_Insumo; }
			set { id_Insumo = value; }
		}

		private int cantidad_Solicitada;

		public int Cantidad_Solicitada
		{
			get { return cantidad_Solicitada; }
			set { cantidad_Solicitada = value; }
		}
		private int cantidad_Recibida;

		public int Cantidad_Recibida
		{
			get { return cantidad_Recibida; }
			set { cantidad_Recibida = value; }
		}

	}
}
