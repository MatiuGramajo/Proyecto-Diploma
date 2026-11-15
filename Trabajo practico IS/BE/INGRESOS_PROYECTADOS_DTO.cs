using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class INGRESOS_PROYECTADOS_DTO
    {
		private decimal total_Cobrado;

		public decimal Total_Cobrado
		{
			get { return total_Cobrado; }
			set { total_Cobrado = value; }
		}
		private decimal total_Pendiente;

		public decimal Total_Pendiente
		{
			get { return total_Pendiente; }
			set { total_Pendiente = value; }
		}
		private decimal total_Proyectado;

		public decimal Total_Proyectado
		{
			get { return total_Proyectado; }
			set { total_Proyectado = value; }
		}

	}
}
