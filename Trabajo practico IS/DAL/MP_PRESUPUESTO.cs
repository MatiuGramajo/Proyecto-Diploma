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
            parametros.Add(acceso.CrearParametro("@Fecha_Evento", obj.Fecha_Evento));
            int idGenerado = acceso.LeerEscalar("INSERTAR_PRESUPUESTO", parametros);
            obj.Id_Presupuesto = idGenerado;
            //// El diagrama exige acceso.Escribir() retornando void
            //acceso.Escribir("INSERTAR_PRESUPUESTO", parametros);
            acceso.Cerrar();
        }

        public override void Baja(PRESUPUESTO obj)
        {
            throw new NotImplementedException();
        }

        public List<BE.PRESUPUESTO> ListarPresupuestosPendientes()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_PRESUPUESTOS_PENDIENTES");
            acceso.Cerrar();

            List<BE.PRESUPUESTO> lista = new List<BE.PRESUPUESTO>();
            foreach (DataRow row in dt.Rows)
            {
                BE.PRESUPUESTO presu = new BE.PRESUPUESTO();
                presu.Id_Presupuesto = Convert.ToInt32(row["Id_Presupuesto"]);
                presu.Id_Cliente = Convert.ToInt32(row["Id_Cliente"]);
                presu.Cantidad_Invitados_Estimada = Convert.ToInt32(row["Cantidad_Invitados_Estimada"]);
                presu.Tipo_Evento = row["Tipo_Evento"].ToString();
                presu.Subtotal = Convert.ToDecimal(row["Subtotal"]);
                presu.Estado = row["Estado"].ToString();
                presu.Fecha_Evento = Convert.ToDateTime(row["Fecha_Evento"]);

                lista.Add(presu);
            }
            return lista;
        }
        public override List<BE.PRESUPUESTO> Listar()
        {
            throw new NotImplementedException();

        }

        public void ModificarEstado(int idPresupuesto, string nuevoEstado)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Presupuesto", idPresupuesto));
            parametros.Add(acceso.CrearParametro("@Estado", nuevoEstado));

            acceso.Escribir("ACTUALIZAR_ESTADO_PRESUPUESTO", parametros);
            acceso.Cerrar();
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
