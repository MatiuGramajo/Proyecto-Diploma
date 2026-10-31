using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DETALLE_RECETARIO
    {
		private int id_Detalle_Recetario;

		public int Id_Detalle_Recetario
		{
			get { return id_Detalle_Recetario; }
			set { id_Detalle_Recetario = value; }
		}
		private int id_Servicio;

		public int Id_Servicio
		{
			get { return id_Servicio; }
			set { id_Servicio = value; }
		}
		private int id_Insumo;

		public int Id_Insumo
		{
			get { return id_Insumo; }
			set { id_Insumo = value; }
		}
		private decimal cantidad_Por_Persona;

		public decimal Cantidad_Por_Persona
		{
			get { return cantidad_Por_Persona; }
			set { cantidad_Por_Persona = value; }
		}
		private BE.INSUMO insumoAsociado;

		public BE.INSUMO InsumoAsociado
		{
			get { return insumoAsociado; }
			set { insumoAsociado = value; }
		}
		public DETALLE_RECETARIO()
		{
			insumoAsociado= new BE.INSUMO();
		}
	}
}
