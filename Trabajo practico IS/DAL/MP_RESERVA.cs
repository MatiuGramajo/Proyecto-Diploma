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
        public List<DateTime> ObtenerFechasOcupadas()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("OBTENER_FECHAS_OCUPADAS");
            acceso.Cerrar();

            List<DateTime> fechas = new List<DateTime>();
            foreach (DataRow row in dt.Rows)
            {
                fechas.Add(Convert.ToDateTime(row["Fecha_Evento"]));
            }
            return fechas;
        }
        public List<BE.RESERVA> ListarConfirmadas()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_RESERVAS_CONFIRMADAS");
            acceso.Cerrar();

            List<BE.RESERVA> lista = new List<BE.RESERVA>();
            foreach (DataRow row in dt.Rows)
            {
                BE.RESERVA res = new BE.RESERVA();
                res.Id_Reserva = Convert.ToInt32(row["Id_Reserva"]);
                res.Id_Cliente = Convert.ToInt32(row["Id_Cliente"]);
                res.Id_Usuario = Convert.ToInt32(row["Id_Usuario"]);
                res.Id_Presupuesto = Convert.ToInt32(row["Id_Presupuesto"]);
                res.Fecha_Evento = Convert.ToDateTime(row["Fecha_Evento"]);
                res.Monto_Senia = Convert.ToDecimal(row["Monto_Senia"]);
                res.Estado = row["Estado"].ToString();

                // Mapeamos los objetos asociados para mostrarlos en la grilla
                res.ClienteAsociado = new BE.CLIENTE
                {
                    Id_Cliente = res.Id_Cliente,
                    Nombre_Completo = row["ClienteNombre"].ToString()
                };

                res.PresupuestoAsociado = new BE.PRESUPUESTO
                {
                    Id_Presupuesto = res.Id_Presupuesto,
                    Tipo_Evento = row["Tipo_Evento"].ToString()
                };

                lista.Add(res);
            }
            return lista;
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

        public void ActualizarCostosyEstado(int idReserva, decimal costoTotal, decimal saldoPendiente, string estado)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Reserva", idReserva));
            parametros.Add(acceso.CrearParametro("@Costo_Total_Real", costoTotal));
            parametros.Add(acceso.CrearParametro("@Saldo_Pendiente", saldoPendiente));
            parametros.Add(acceso.CrearParametro("@Estado", estado));

            acceso.Escribir("ACTUALIZAR_SALDOS_ESTADO_RESERVA", parametros);
            acceso.Cerrar();
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
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Cliente", obj.Id_Cliente));
            parametros.Add(acceso.CrearParametro("@Id_Presupuesto", obj.Id_Presupuesto));
            parametros.Add(acceso.CrearParametro("@Id_Usuario", obj.Id_Usuario));
            parametros.Add(acceso.CrearParametro("@Fecha_Evento", obj.Fecha_Evento));
            parametros.Add(acceso.CrearParametro("@Monto_Senia", obj.Monto_Senia));
            parametros.Add(acceso.CrearParametro("@Estado", obj.Estado));
            acceso.Escribir("INSERTAR_RESERVA", parametros);
            acceso.Cerrar();
        }
    }
}
