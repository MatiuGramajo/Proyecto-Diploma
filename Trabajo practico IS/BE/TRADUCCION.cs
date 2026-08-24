using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TRADUCCION
    {
		private int idTraduccion;

		public int IdTraduccion
		{
			get { return idTraduccion; }
			set { idTraduccion = value; }
		}
		private string nombreFormulario;

		public string NombreFormulario
		{
			get { return nombreFormulario; }
			set { nombreFormulario = value; }
		}
		private string textoTraducido;

		public string TextoTraducido
		{
			get { return textoTraducido; }
			set { textoTraducido = value; }
		}
		private string nombreControl;

		public string NombreControl
		{
			get { return nombreControl; }
			set { nombreControl = value; }
		}



	}
}
