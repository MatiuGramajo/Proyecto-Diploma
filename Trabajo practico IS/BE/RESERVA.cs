using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RESERVA
    {
		private int id_Reserva;

		public int Id_Reserva
		{
			get { return id_Reserva; }
			set { id_Reserva = value; }
		}
		private int id_Cliente;

		public int Id_Cliente
		{
			get { return id_Cliente; }
			set { id_Cliente = value; }
		}
		private int id_Presupuesto;

		public int Id_Presupuesto
		{
			get { return id_Presupuesto; }
			set { id_Presupuesto = value; }
		}
		private int id_Usuario;

		public int Id_Usuario
		{
			get { return id_Usuario; }
			set { id_Usuario = value; }
		}
		private CLIENTE clienteAsociado;

		public CLIENTE ClienteAsociado
		{
			get { return clienteAsociado; }
			set { clienteAsociado = value; }
		}
		private PRESUPUESTO presupuestoAsociado;

		public PRESUPUESTO PresupuestoAsociado
		{
			get { return presupuestoAsociado; }
			set { presupuestoAsociado = value; }
		}
		private DateTime fecha_Evento;

		public DateTime Fecha_Evento
		{
			get { return fecha_Evento; }
			set { fecha_Evento = value; }
		}
		private decimal monto_Senia;

		public decimal Monto_Senia
		{
			get { return monto_Senia; }
			set { monto_Senia = value; }
		}
		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}

	}
}
