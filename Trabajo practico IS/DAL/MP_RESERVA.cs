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

            DataTable dt = acceso.Leer("VERIFICAR_DISPONIBILIDAD_FECHA", parametros);
            acceso.Cerrar();

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
        public List<BE.RESERVA> ListarEventosPlanificados(DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@FechaDesde", (object)fechaDesde ?? DBNull.Value));
            parametros.Add(new SqlParameter("@FechaHasta", (object)fechaHasta ?? DBNull.Value));

            DataTable dt = acceso.Leer("LISTAR_EVENTOS_PLANIFICADOS", parametros);
            acceso.Cerrar();

            List<BE.RESERVA> lista = new List<BE.RESERVA>();
            foreach (DataRow row in dt.Rows)
            {
                BE.RESERVA res = new BE.RESERVA();
                res.Id_Reserva = Convert.ToInt32(row["Id_Reserva"]);
                res.Id_Cliente = Convert.ToInt32(row["Id_Cliente"]);
                res.Id_Presupuesto = Convert.ToInt32(row["Id_Presupuesto"]);
                res.Id_Usuario = Convert.ToInt32(row["Id_Usuario"]);
                res.Fecha_Evento = Convert.ToDateTime(row["Fecha_Evento"]);
                res.Monto_Senia = Convert.ToDecimal(row["Monto_Senia"]);

                res.Costo_Total_Real = row["Costo_Total_Real"] != DBNull.Value ? Convert.ToDecimal(row["Costo_Total_Real"]) : 0;
                res.Saldo_Pendiente = row["Saldo_Pendiente"] != DBNull.Value ? Convert.ToDecimal(row["Saldo_Pendiente"]) : 0;
                res.Estado = row["Estado"].ToString();

                if (dt.Columns.Contains("ClienteNombre") && row["ClienteNombre"] != DBNull.Value)
                {
                    res.ClienteAsociado = new BE.CLIENTE
                    {
                        Id_Cliente = res.Id_Cliente,
                        Nombre_Completo = row["ClienteNombre"].ToString()
                    };
                }

                int invitados = 0;
                if (dt.Columns.Contains("Cantidad_Invitados") && row["Cantidad_Invitados"] != DBNull.Value)
                {
                    invitados = Convert.ToInt32(row["Cantidad_Invitados"]);
                }
                else if (dt.Columns.Contains("Cantidad_Invitados_Estimada") && row["Cantidad_Invitados_Estimada"] != DBNull.Value)
                {
                    invitados = Convert.ToInt32(row["Cantidad_Invitados_Estimada"]);
                }

                res.PresupuestoAsociado = new BE.PRESUPUESTO
                {
                    Id_Presupuesto = res.Id_Presupuesto,
                    Cantidad_Invitados_Estimada = invitados,
                    Tipo_Evento = dt.Columns.Contains("Tipo_Evento") ? row["Tipo_Evento"].ToString() : ""
                };

                lista.Add(res);
             }
            return lista;
            }

        public List<BE.RESERVA> ListarPendientesEvaluacion()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_PENDIENTES_EVALUACION");
            acceso.Cerrar();

            List<BE.RESERVA> lista = new List<BE.RESERVA>();
            foreach (DataRow row in dt.Rows)
            {
                BE.RESERVA res = new BE.RESERVA();
                res.Id_Reserva = Convert.ToInt32(row["Id_Reserva"]);
                res.Id_Cliente = Convert.ToInt32(row["Id_Cliente"]);
                res.Id_Presupuesto = Convert.ToInt32(row["Id_Presupuesto"]);
                res.Id_Usuario = Convert.ToInt32(row["Id_Usuario"]);
                res.Fecha_Evento = Convert.ToDateTime(row["Fecha_Evento"]);
                res.Monto_Senia = Convert.ToDecimal(row["Monto_Senia"]);
                res.Costo_Total_Real = row["Costo_Total_Real"] != DBNull.Value ? Convert.ToDecimal(row["Costo_Total_Real"]) : 0;
                res.Saldo_Pendiente = row["Saldo_Pendiente"] != DBNull.Value ? Convert.ToDecimal(row["Saldo_Pendiente"]) : 0;
                res.Estado = row["Estado"].ToString();

                res.ClienteAsociado = new BE.CLIENTE
                {
                    Id_Cliente = res.Id_Cliente,
                    Nombre_Completo = row["ClienteNombre"].ToString()
                };

                int invitados = dt.Columns.Contains("Cantidad_Invitados") && row["Cantidad_Invitados"] != DBNull.Value
                    ? Convert.ToInt32(row["Cantidad_Invitados"]) : 0;

                res.PresupuestoAsociado = new BE.PRESUPUESTO
                {
                    Id_Presupuesto = res.Id_Presupuesto,
                    Cantidad_Invitados_Estimada = invitados,
                    Tipo_Evento = row["Tipo_Evento"].ToString()
                };

                lista.Add(res);
            }
            return lista;
        }
        public List<BE.RESERVA> ListarEvaluados()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_EVALUADOS");
            acceso.Cerrar();

            List<BE.RESERVA> lista = new List<BE.RESERVA>();
            foreach (DataRow row in dt.Rows)
            {
                BE.RESERVA res = new BE.RESERVA
                {
                    Id_Reserva = Convert.ToInt32(row["Id_Reserva"]),
                    Fecha_Evento = Convert.ToDateTime(row["Fecha_Evento"]),
                    Estado = row["Estado"].ToString(),
                    Evaluacion_Personal = Convert.ToInt32(row["Evaluacion_Personal"]),
                    Observaciones_Personal = row["Observaciones_Personal"] != DBNull.Value ? row["Observaciones_Personal"].ToString() : ""
                };
                lista.Add(res);
            }
            return lista;
        }
        public List<BE.PERSONAL> ObtenerPersonalAsignado(int idReserva)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id_Reserva", idReserva)
            };

            DataTable dt = acceso.Leer("OBTENER_PERSONAL_ASIGNADO", parametros);
            acceso.Cerrar();

            List<BE.PERSONAL> lista = new List<BE.PERSONAL>();
            foreach (DataRow row in dt.Rows)
            {
                BE.PERSONAL p = new BE.PERSONAL
                {
                    Id_Personal = Convert.ToInt32(row["Id_Personal"]),
                    Dni = row["DNI"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Categoria = row["Categoria"].ToString()
                };
                lista.Add(p);
            }
            return lista;
        }
        public void GuardarEvaluacion(BE.RESERVA objReserva)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id_Reserva", objReserva.Id_Reserva),
                new SqlParameter("@Resultado", objReserva.Evaluacion_Personal.Value),
                new SqlParameter("@Observaciones", (object)objReserva.Observaciones_Personal ?? DBNull.Value)
            };

            acceso.Escribir("REGISTRAR_EVALUACION_Y_FINALIZAR", parametros);
            acceso.Cerrar();
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
        public void SaldarReserva(int idReserva)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Reserva", idReserva));
            acceso.Escribir("SALDAR_RESERVA", parametros);
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
