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
		private int id_Ficha;

		public int Id_Ficha
		{
			get { return id_Ficha; }
			set { id_Ficha = value; }
		}
		private int id_Proveedor;

		public int Id_Proveedor
		{
			get { return id_Proveedor; }
			set { id_Proveedor = value; }
		}
		private PROVEEDOR_EXTERNO proveedorAsociado;

		public PROVEEDOR_EXTERNO ProveedorAsociado
		{
			get { return proveedorAsociado; }
			set { proveedorAsociado = value; }

		}
		private List<DETALLE_OC> detalles= new List<DETALLE_OC>() ;

		public List<DETALLE_OC> Detalles
		{
			get { return detalles; }
			set { detalles  = value; }
		}
		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}
		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}
		

	}
}
