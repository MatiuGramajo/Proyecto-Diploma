using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CLIENTE

    {
		private int id_Cliente;

		public int Id_Cliente
		{
			get { return id_Cliente; }
			set { id_Cliente = value; }
		}
		private string nombre_Completo;

		public string Nombre_Completo
		{
			get { return nombre_Completo; }
			set { nombre_Completo = value; }
		}
		private int telefono;

		public int Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}
		private string email;

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

	}
}
