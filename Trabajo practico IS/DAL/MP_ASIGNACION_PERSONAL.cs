using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_ASIGNACION_PERSONAL : MAPPER<BE.ASIGNACION_PERSONAL>
    {
        public void GuardarAsignacion(int idReserva, List<BE.PERSONAL> listaPersonalAsignado)
        {
            acceso.Abrir();

            List<SqlParameter> paramLimpieza = new List<SqlParameter>();
            paramLimpieza.Add(acceso.CrearParametro("@Id_Reserva", idReserva));
            acceso.Escribir("ELIMINAR_ASIGNACION_RESERVA", paramLimpieza);

            foreach (BE.PERSONAL p in listaPersonalAsignado)
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.CrearParametro("@Id_Reserva", idReserva));
                parametros.Add(acceso.CrearParametro("@Id_Personal", p.Id_Personal));

                acceso.Escribir("GUARDAR_ASIGNACION_PERSONAL", parametros);
            }

            acceso.Cerrar();
        }
        public override void Alta(ASIGNACION_PERSONAL obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(ASIGNACION_PERSONAL obj)
        {
            throw new NotImplementedException();
        }

        public override List<ASIGNACION_PERSONAL> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(ASIGNACION_PERSONAL obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(ASIGNACION_PERSONAL obj)
        {
            throw new NotImplementedException();
        }
    }
}
