using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PRESUPUESTO
    {
		private int id_Presupuesto;

		public int Id_Presupuesto
		{
			get { return id_Presupuesto; }
			set { id_Presupuesto = value; }
		}
		private int id_Cliente;

		public int Id_Cliente
		{
			get { return id_Cliente; }
			set { id_Cliente = value; }
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
		private int cantidad_Invitados_Estimada;

		public int Cantidad_Invitados_Estimada
		{
			get { return cantidad_Invitados_Estimada; }
			set { cantidad_Invitados_Estimada = value; }
		}
		private string tipo_Evento;

		public string Tipo_Evento
		{
			get { return tipo_Evento; }
			set { tipo_Evento = value; }
		}
		private decimal subtotal;

		public decimal Subtotal
		{
			get { return subtotal; }
			set { subtotal = value; }
		}
		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}

	}
}
