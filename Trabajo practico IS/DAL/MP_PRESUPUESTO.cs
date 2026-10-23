using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_PRESUPUESTO : MAPPER<BE.PRESUPUESTO>
    {
        public decimal ObtenerTarifa(string tipoEvento)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Tipo_Evento", tipoEvento));

            // El diagrama exige acceso.Leer() retornando DataTable
            DataTable dt = acceso.Leer("OBTENER_TARIFA_EVENTO", parametros);
            acceso.Cerrar();

            if (dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0]["TarifaBase"]);

            return 0m;
        }
        public override void Alta(BE.PRESUPUESTO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Cliente", obj.Id_Cliente));
            parametros.Add(acceso.CrearParametro("@Cantidad_Invitados_Estimada", obj.Cantidad_Invitados_Estimada));
            parametros.Add(acceso.CrearParametro("@Tipo_Evento", obj.Tipo_Evento));
            parametros.Add(acceso.CrearParametro("@Subtotal", obj.Subtotal));
            parametros.Add(acceso.CrearParametro("@Id_Usuario", obj.Id_Usuario));
            parametros.Add(acceso.CrearParametro("@Estado", obj.Estado));
 

            // El diagrama exige acceso.Escribir() retornando void
            acceso.Escribir("INSERTAR_PRESUPUESTO", parametros);
            acceso.Cerrar();
        }

        public override void Baja(PRESUPUESTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<PRESUPUESTO> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(PRESUPUESTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(PRESUPUESTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
