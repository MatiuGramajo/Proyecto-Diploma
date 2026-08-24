using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BITACORA
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}
		private string usuario;

		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		private string modulo;

		public string Modulo
		{
			get { return modulo; }
			set { modulo = value; }
		}
		private string operacion;

		public string Operacion
		{
			get { return operacion; }
			set { operacion = value; }
		}
		private int criticidad;

		public int Criticidad
		{
			get { return criticidad; }
			set { criticidad = value; }
		}

	}
}
