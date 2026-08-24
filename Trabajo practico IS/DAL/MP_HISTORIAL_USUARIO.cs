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
    public class MP_HISTORIAL_USUARIO
    {
        ACCESO acceso = new ACCESO();
        public void RegistrarEnHistorial(int idUsuario, string usuarioResponsable, string tipoAccion)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_usuario", idUsuario));
            parametros.Add(acceso.CrearParametro("@usuario_responsable", usuarioResponsable));
            parametros.Add(acceso.CrearParametro("@tipo_accion", tipoAccion));
            acceso.Escribir("INSERTAR_HISTORIAL_USUARIO", parametros);
            acceso.Cerrar();
        }
        public void RestaurarVersion(int idHistorial, string usuarioResponsable)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_historial", idHistorial));
            parametros.Add(acceso.CrearParametro("@usuario_responsable", usuarioResponsable));
            acceso.Escribir("RESTAURAR_USUARIO_DESDE_HISTORIAL", parametros);
            acceso.Cerrar();
        }

        public List<HISTORIAL_USUARIO> Listar()
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataTable tabla = acceso.Leer("LISTAR_HISTORIAL_USUARIO", parametros);
            acceso.Cerrar();

            List<BE.HISTORIAL_USUARIO> lista = new List<BE.HISTORIAL_USUARIO>();
            foreach (DataRow row in tabla.Rows)
            {
                BE.HISTORIAL_USUARIO hist = new BE.HISTORIAL_USUARIO();
                hist.IdHistorial = Convert.ToInt32(row["id_historial"]);
                hist.Id = Convert.ToInt32(row["id_usuario"]);
                hist.Usuario = row["usuario"].ToString();
                hist.Email = row["email"].ToString();
                hist.Dni = Convert.ToInt32(row["dni"]);
                hist.FechaCambio = Convert.ToDateTime(row["fecha_cambio"]);
                hist.UsuarioAccion = row["usuario_accion"].ToString();
                hist.TipoAccion = row["tipo_accion"].ToString();
                hist.IdIdioma = Convert.ToInt32(row["id_idioma"]);
                hist.IntentosFallidos = Convert.ToInt32(row["intentosfallidos"]);
                hist.EstadoBloqueado = Convert.ToBoolean(row["estadobloqueado"]);
                hist.Contraseña = row["contraseña"].ToString();
                hist.DVH = row["dvh"].ToString();
                lista.Add(hist);
            }
            return lista;
        }
        
    }
}
