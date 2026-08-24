using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_DIGITO_VERIFICADOR
    {
        private ACCESO acceso = new ACCESO();

        public void ActualizarDVV(string tabla, string dvv)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@tabla", tabla));
            parametros.Add(acceso.CrearParametro("@dvv", dvv));

            acceso.Escribir("ACTUALIZAR_DVV", parametros);
            acceso.Cerrar();
        }

        public string ObtenerDVV(string tabla)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@tabla", tabla));

            DataTable dt = acceso.Leer("OBTENER_DVV", parametros);
            acceso.Cerrar();

            if (dt.Rows.Count > 0 && dt.Rows[0]["DVV"] != DBNull.Value)
            {
                return dt.Rows[0]["DVV"].ToString();
            }

            return string.Empty;
        }
    }
}
