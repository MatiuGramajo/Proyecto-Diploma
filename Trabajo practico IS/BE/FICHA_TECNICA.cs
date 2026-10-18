using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class FICHA_TECNICA
    {
		private int id_Ficha;

		public int Id_Ficha
		{
			get { return id_Ficha; }
			set { id_Ficha = value; }
		}
		private int id_Servicio;

		public int Id_Servicio
		{
			get { return id_Servicio; }
			set { id_Servicio = value; }
		}
		private int id_Usuario;

		public int Id_Usuario
		{
			get { return id_Usuario; }
			set { id_Usuario = value; }
		}
		private int id_Reserva;

		public int Id_Reserva
		{
			get { return id_Reserva; }
			set { id_Reserva = value; }
		}
		private RESERVA reservaAsociada;

		public RESERVA ReservaAsociada
		{
			get { return reservaAsociada; }
			set { reservaAsociada = value; }
		}
		private SERVICIO_CATERING cateringAsociado;

		public SERVICIO_CATERING CateringAsociado
		{
			get { return cateringAsociado; }
			set { cateringAsociado = value; }
		}
		private List<PROVEEDOR_EXTERNO> proveedoresAsignados = new List<PROVEEDOR_EXTERNO>();	

		public List<PROVEEDOR_EXTERNO> ProveedoresAsignados 
		{
			get { return proveedoresAsignados; }
			set { proveedoresAsignados = value; }
		}
		private int cantidad_Invitados_Final;

		public int Cantidad_Invitados_Final
		{
			get { return cantidad_Invitados_Final; }
			set { cantidad_Invitados_Final = value; }
		}
		private string tipo_Evento;

		public string Tipo_Evento
		{
			get { return tipo_Evento; }
			set { tipo_Evento = value; }
		}
		private string observaciones;

		public string Observaciones
		{
			get { return observaciones; }
			set { observaciones = value; }
		}



	}
}
