using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class INSUMO
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
		private decimal stock_Actual;

		public decimal Stock_Actual
		{
			get { return stock_Actual; }
			set { stock_Actual = value; }
		}
		private decimal stock_Minimo;

		public decimal Stock_Minimo
		{
			get { return stock_Minimo; }
			set { stock_Minimo = value; }
		}
		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}
        public override string ToString()
        {
            return $"{Nombre} ({Rubro}) - Stock: {Stock_Actual} {Unidad_Medida}";
        }

    }
}
