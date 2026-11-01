using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class REQUERIMIENTO_INSUMO
    {
		private int id_Insumo;

		public int Id_Insumo
		{
			get { return id_Insumo; }
			set { id_Insumo = value; }
		}
		private string nombre_Insumo;

		public string Nombre_Insumo
		{
			get { return nombre_Insumo; }
			set { nombre_Insumo = value; }
		}
		private string rubro;

		public string Rubro
		{
			get { return rubro; }
			set { rubro = value; }
		}
		private string unidad_Medida;

		public string Unidad_Medida
		{
			get { return unidad_Medida; }
			set { unidad_Medida = value; }
		}
		private decimal cantidad_Requerida;

		public decimal Cantidad_Requerida
		{
			get { return cantidad_Requerida; }
			set { cantidad_Requerida = value; }
		}
		private decimal stock_Actual;

		public decimal Stock_Actual
		{
			get { return stock_Actual; }
			set { stock_Actual = value; }
		}
		private decimal cantidad_Faltante;

		public decimal Cantidad_Faltante
		{
			get { return cantidad_Faltante; }
			set { cantidad_Faltante = value; }
		}
		private string estado_Stock;

		public string Estado_Stock
		{
			get { return estado_Stock; }
			set { estado_Stock = value; }
		}

	}
}
