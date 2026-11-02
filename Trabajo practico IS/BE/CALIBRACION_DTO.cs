using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CALIBRACION_DTO
    {
		private int totalEventosEvaluados;

		public int TotalEventosEvaluados
		{
			get { return totalEventosEvaluados; }
			set { totalEventosEvaluados = value; }
		}
		private int cantidadAprobados;

		public int CantidadAprobados
		{
			get { return cantidadAprobados; }
			set { cantidadAprobados = value; }
		}
		private int cantidadDesaprobados;

		public int CantidadDesaprobados
		{
			get { return cantidadDesaprobados; }
			set { cantidadDesaprobados = value; }
		}
		private decimal porcentajeAprobacion;

		public decimal PorcentajeAprobacion
		{
			get { return porcentajeAprobacion; }
			set { porcentajeAprobacion = value; }
		}
		private decimal porcentajeDesaprobacion;

		public decimal PorcentajeDesaprobacion
		{
			get { return porcentajeDesaprobacion; }
			set { porcentajeDesaprobacion = value; }
		}
		private string recomendacionAjuste;

		public string RecomendacionAjuste
		{
			get { return recomendacionAjuste; }
			set { recomendacionAjuste = value; }
		}
		private List<PARAMETRO_RATIO> ratiosActuales = new List<PARAMETRO_RATIO>();

		public List<PARAMETRO_RATIO> RatiosActuales
		{
			get { return ratiosActuales ; }
			set { ratiosActuales  = value; }
		}
		private List<PARAMETRO_RATIO> ratiosSugeridos = new List<PARAMETRO_RATIO>();

		public List<PARAMETRO_RATIO> RatiosSugeridos
		{
			get { return ratiosSugeridos; }
			set { ratiosSugeridos = value; }
		}


	}
}
