using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_RESERVA : MAPPER<BE.RESERVA>
    {

        public bool VerificarEstado(DateTime fecha)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Fecha_Evento", fecha));

            // El diagrama exige acceso.Leer() que retorna DataTable
            DataTable dt = acceso.Leer("VERIFICAR_DISPONIBILIDAD_FECHA", parametros);
            acceso.Cerrar();

            // Si la tabla vuelve vacía, la fecha está libre
            return dt.Rows.Count == 0;
        }

        public List<DateTime> ObtenerFechasAlternativas(DateTime fecha)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Fecha_Evento", fecha));

            DataTable dt = acceso.Leer("OBTENER_FECHAS_ALTERNATIVAS", parametros);
            acceso.Cerrar();

            List<DateTime> alternativas = new List<DateTime>();
            foreach (DataRow row in dt.Rows)
            {
                alternativas.Add(Convert.ToDateTime(row["FechaDisponible"]));
            }
            return alternativas;
        }
        public override void Baja(RESERVA obj)
        {
            throw new NotImplementedException();
        }

        public override List<RESERVA> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(RESERVA obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(RESERVA obj)
        {
            throw new NotImplementedException();
        }

        public override void Alta(RESERVA obj)
        {
            throw new NotImplementedException();
        }
    }
}
