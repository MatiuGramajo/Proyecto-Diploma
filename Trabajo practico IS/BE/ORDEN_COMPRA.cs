using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ORDEN_COMPRA
    {
		private int id_OrdenCompra;

		public int Id_OrdenCompra
		{
			get { return id_OrdenCompra; }
			set { id_OrdenCompra = value; }
		}

		private int id_Proveedor;

		public int Id_Proveedor
		{
			get { return id_Proveedor; }
			set { id_Proveedor = value; }
		}
		private List<DETALLE_ORDEN_COMPRA> detalles= new List<DETALLE_ORDEN_COMPRA>() ;

		public List<DETALLE_ORDEN_COMPRA> Detalles
		{
			get { return detalles; }
			set { detalles  = value; }
		}
		private DateTime fecha_Emision;

		public DateTime Fecha_Emision
		{
			get { return fecha_Emision; }
			set { fecha_Emision = value; }
		}
		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}



	}
}
