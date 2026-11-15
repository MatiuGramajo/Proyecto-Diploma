using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CONVERSION_PRESUPUESTO_DTO
    {
		private int cantidad_Aprobados;

		public int Cantidad_Aprobados
		{
			get { return cantidad_Aprobados; }
			set { cantidad_Aprobados = value; }
		}
		private int cantidad_Pendientes;

		public int Cantidad_Pendientes
		{
			get { return cantidad_Pendientes; }
			set { cantidad_Pendientes = value; }
		}
		private int cantidad_Rechazados;

		public int Cantidad_Rechazados
		{
			get { return cantidad_Rechazados; }
			set { cantidad_Rechazados = value; }
		}
		private int total_Presupuesto;

		public int Total_Presupuestos
		{
			get { return total_Presupuesto; }
			set { total_Presupuesto = value; }
		}
		private decimal porcentaje_Aprobacion;

		public decimal Porcentaje_Aprobacion
		{
			get { return porcentaje_Aprobacion; }
			set { porcentaje_Aprobacion = value; }
		}

	}
}
