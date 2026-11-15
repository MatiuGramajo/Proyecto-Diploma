using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SALDO_CLIENTE_DTO
    {
		private int id_Reserva;

		public int Id_Reserva
		{
			get { return id_Reserva; }
			set { id_Reserva = value; }
		}
		private string cliente;

		public string Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}
		private DateTime fecha_Evento;

		public DateTime Fecha_Evento
		{
			get { return fecha_Evento; }
			set { fecha_Evento = value; }
		}
		private decimal costo_Toal;

		public decimal Costo_Total
		{
			get { return costo_Toal; }
			set { costo_Toal = value; }
		}
		private decimal monto_Senia;

		public decimal Monto_Senia
		{
			get { return monto_Senia; }
			set { monto_Senia = value; }
		}
		private decimal saldo_Pendiente;

		public decimal Saldo_Pendiente
		{
			get { return saldo_Pendiente; }
			set { saldo_Pendiente = value; }
		}
			
	}
}
