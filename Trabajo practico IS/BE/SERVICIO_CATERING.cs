using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SERVICIO_CATERING
    {
		private int id_Servicio;

		public int Id_Servicio
		{
			get { return id_Servicio; }
			set { id_Servicio = value; }
		}
		private string tipo_Menu;

		public string Tipo_Menu
		{
			get { return tipo_Menu; }
			set { tipo_Menu = value; }
		}
		private decimal precio_Por_Persona;

		public decimal Precio_Por_Persona
		{
			get { return precio_Por_Persona; }
			set { precio_Por_Persona = value; }
		}
		private string nombre_Servicio;

		public string Nombre_Servicio
		{
			get { return nombre_Servicio; }
			set { nombre_Servicio = value; }
		}
		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}


	}
}
