using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_PAGO_SEÑA : MAPPER<BE.RESERVA>
    {
        public void RegistrarCobro(BE.RESERVA datosPago)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Reserva", datosPago.Id_Reserva));
            parametros.Add(acceso.CrearParametro("@Monto", datosPago.Monto_Senia));

            // Retorna void() según el diagrama[cite: 8]
            acceso.Escribir("REGISTRAR_COBRO", parametros);
            acceso.Cerrar();
        }
        public void ActualizarEstadoPresupuesto(BE.PRESUPUESTO presupuesto)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Presupuesto", presupuesto.Id_Presupuesto));
            parametros.Add(acceso.CrearParametro("@Estado", "Aprobado"));

            acceso.Escribir("ACTUALIZAR_ESTADO_PRESUPUESTO", parametros);
            acceso.Cerrar();

        }
        public void ActualizarEstadoFecha(BE.RESERVA datosPago)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Fecha_Evento", datosPago.Fecha_Evento));
            parametros.Add(acceso.CrearParametro("@Estado", "Bloqueada"));

            acceso.Escribir("ACTUALIZAR_ESTADO_FECHA", parametros);
            acceso.Cerrar();

        }
        public override void Alta(RESERVA obj)
        {
            throw new NotImplementedException();
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
    }
}
