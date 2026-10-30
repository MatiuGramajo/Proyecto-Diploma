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
		private List<PRESTADOR_SERVICIO> prestadoresAsignados = new List<PRESTADOR_SERVICIO>();	

		public List<PRESTADOR_SERVICIO> PrestadoresAsignados 
		{
			get { return prestadoresAsignados; }
			set { prestadoresAsignados = value; }
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

        private decimal costo_Total_Real;
        public decimal Costo_Total_Real
        {
            get { return costo_Total_Real; }
            set { costo_Total_Real = value; }
        }

        private decimal saldo_Pendiente;
        public decimal Saldo_Pendiente
        {
            get { return saldo_Pendiente; }
            set { saldo_Pendiente = value; }
        }

    }
}
