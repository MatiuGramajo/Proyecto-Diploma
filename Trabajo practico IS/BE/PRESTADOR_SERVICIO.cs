using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PRESTADOR_SERVICIO
    {
		private int id_Prestador;

		public int Id_Prestador
		{
			get { return id_Prestador; }
			set { id_Prestador = value; }
		}
		private string rubro;

		public string Rubro
		{
			get { return rubro; }
			set { rubro = value; }
		}
		private string nombre_Fantasia;

		public string Nombre_Fantasia
		{
			get { return nombre_Fantasia; }
			set { nombre_Fantasia = value; }
		}
		private int telefono_Contacto;

		public int Telefono_Contacto
		{
			get { return telefono_Contacto; }
			set { telefono_Contacto = value; }
		}

        private decimal precio_Servicio;
        public decimal Precio_Servicio
        {
            get { return precio_Servicio; }
            set { precio_Servicio = value; }
        }
		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}
        public override string ToString()
        {
			return $"{Nombre_Fantasia} ({Rubro}) - {Precio_Servicio:C}";
        }
    }
}
