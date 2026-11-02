using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ASIGNACION_PERSONAL
    {
		private int id_Asignacion;

		public int Id_Asignacion
		{
			get { return id_Asignacion; }
			set { id_Asignacion = value; }
		}
		private int id_Reserva;

		public int Id_Reserva
		{
			get { return id_Reserva; }
			set { id_Reserva = value; }
		}
		private int id_Personal;

		public int Id_Personal
		{
			get { return id_Personal; }
			set { id_Personal = value; }
		}

	}
}
