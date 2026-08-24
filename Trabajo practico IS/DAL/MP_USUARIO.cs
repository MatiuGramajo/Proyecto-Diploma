using BE;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_USUARIO : MAPPER<BE.USUARIO>
    {

        public override void Alta(USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@contra", usuario.Contraseña));
            parametros.Add(acceso.CrearParametro("@dni", usuario.Dni));
            parametros.Add(acceso.CrearParametro("@email", usuario.Email));

            parametros.Add(acceso.CrearParametro("@dvh", usuario.DVH));

            object resultado = acceso.LeerEscalar("INSERTAR_USUARIO", parametros);

            if (resultado != null)
            {
                usuario.Id = Convert.ToInt32(resultado);
            }

            if (usuario.Permisos != null && usuario.Permisos.Count > 0)
            {
                foreach (var permiso in usuario.Permisos)
                {
                    List<SqlParameter> paramPermiso = new List<SqlParameter>();
                    paramPermiso.Add(acceso.CrearParametro("@idUsuario", usuario.Id));
                    paramPermiso.Add(acceso.CrearParametro("@idPermiso", permiso.Id));

                    acceso.Escribir("INSERTAR_USUARIO_PERMISO", paramPermiso);
                }
            }
            acceso.Cerrar();
            
        }
        

        public override bool Verificar(USUARIO usuario)
        {
            acceso.Abrir();
            bool ok = false;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@contra", usuario.Contraseña));
            SqlDataReader reader = acceso.Read("VERIFICAR_USUARIO", parametros);
            ok = reader.HasRows;
            reader.Close();
            acceso.Cerrar();
            return ok;
        }
        public BE.USUARIO ObtenerUsuario(string username)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@usu", username));
            DataTable dt = acceso.Leer("OBTENER_USUARIO_POR_NOMBRE", parametros);
            acceso.Cerrar();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                BE.USUARIO usuarioEncontrado = new BE.USUARIO();
                usuarioEncontrado.Id = Convert.ToInt32(row["Id"]);
                usuarioEncontrado.Usuario = row["Usuario"].ToString();
                usuarioEncontrado.Contraseña = row["Contraseña"].ToString();
                usuarioEncontrado.IntentosFallidos = Convert.ToInt32(row["IntentosFallidos"]);
                usuarioEncontrado.EstadoBloqueado = Convert.ToBoolean(row["EstadoBloqueado"]);
                usuarioEncontrado.Dni = int.Parse(row["DNI"].ToString());
                usuarioEncontrado.Email = row["EMAIL"].ToString();
                usuarioEncontrado.IdIdioma = row["id_idioma"] != DBNull.Value ? Convert.ToInt32(row["id_idioma"]) : 1;
                usuarioEncontrado.Activo = Convert.ToBoolean(row["ACTIVO"]);

                return usuarioEncontrado;
            }

            return null; 
        }
        public void ActualizarIntentosFallidos(BE.USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", usuario.Id));
            parametros.Add(acceso.CrearParametro("@intentos",usuario.IntentosFallidos));
            parametros.Add(acceso.CrearParametro("@dvh", usuario.DVH));
            acceso.Escribir("ACTUALIZAR_INTENTOS_FALLIDOS", parametros);
            acceso.Cerrar();
        }
        public void ActualizarEstadoBloqueado(BE.USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", usuario.Id));
            parametros.Add(acceso.CrearParametro("@estadobloqueado", usuario.EstadoBloqueado));
            parametros.Add(acceso.CrearParametro("@intentos", usuario.IntentosFallidos));
            parametros.Add(acceso.CrearParametro("@dvh", usuario.DVH));
            acceso.Escribir("ACTUALIZAR_ESTADOBLOQUEADO", parametros);
            acceso.Cerrar();

        }

        public override void Baja(USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter>parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", usuario.Id));
            acceso.Escribir("BORRAR_USUARIO", parametros);
            acceso.Cerrar();

        }

        public override void Modificar(USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter>parametros= new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id",usuario.Id));
            parametros.Add(acceso.CrearParametro("@usu", usuario.Usuario));
            parametros.Add(acceso.CrearParametro("@contra", usuario.Contraseña));
            parametros.Add(acceso.CrearParametro("@dni", usuario.Dni));
            parametros.Add(acceso.CrearParametro("@email", usuario.Email));
            parametros.Add(acceso.CrearParametro("DVH", usuario.DVH));
            int res = acceso.Escribir("MODIFICAR_USUARIO", parametros);

            List<SqlParameter> paramBorrar = new List<SqlParameter>();
            paramBorrar.Add(acceso.CrearParametro("@idUsuario", usuario.Id));
            acceso.Escribir("BORRAR_PERMISOS_USUARIO", paramBorrar);

            foreach (var permiso in usuario.Permisos)
            {
                List<SqlParameter> paramInsert = new List<SqlParameter>();
                paramInsert.Add(acceso.CrearParametro("@idUsuario", usuario.Id));
                paramInsert.Add(acceso.CrearParametro("@idPermiso", permiso.Id));
                acceso.Escribir("INSERTAR_USUARIO_PERMISO", paramInsert);
            }
            acceso.Cerrar();
        }
        public override List<USUARIO> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_USUARIOS");
            acceso.Cerrar();
            List<BE.USUARIO> usuarios = new List<USUARIO>();
            foreach(DataRow registro in tabla.Rows)
            {
                BE.USUARIO usu= new BE.USUARIO();
                usu.Id = int.Parse(registro["ID"].ToString());
                usu.Usuario = registro["USUARIO"].ToString();
                usu.Contraseña = registro["CONTRASEÑA"].ToString();
                usu.EstadoBloqueado = bool.Parse(registro["ESTADOBLOQUEADO"].ToString());
                usu.IntentosFallidos = int.Parse(registro["INTENTOSFALLIDOS"].ToString());
                usu.Dni = int.Parse(registro["DNI"].ToString());
                usu.Email= registro["EMAIL"].ToString();
                usu.IdIdioma = int.Parse(registro["ID_IDIOMA"].ToString());
                usu.DVH = registro["DVH"].ToString();
                usu.Activo = Convert.ToBoolean(registro["ACTIVO"]);
                usuarios.Add(usu);
            }
            return usuarios;
        }

        public void Reactivar(BE.USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", usuario.Id));
            acceso.Escribir("REACTIVAR_USUARIO", parametros);
            acceso.Cerrar();
        }

        public void ActualizarIdiomaUsuario(BE.USUARIO usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id_usuario", usuario.Id));
            parametros.Add(acceso.CrearParametro("@id_idioma", usuario.IdIdioma));
            parametros.Add(acceso.CrearParametro("@dvh", usuario.DVH));

            acceso.Escribir("ACTUALIZAR_IDIOMA_USUARIO", parametros);
            acceso.Cerrar();
        }

        public List<string> ObtenerTodosLosDVH()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("OBTENER_TODOS_DVH_USUARIO");
            acceso.Cerrar();

            List<string> listaDvh = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (row["DVH"] != DBNull.Value)
                {
                    listaDvh.Add(row["DVH"].ToString());
                }
            }
            return listaDvh;
        }

        public void ActualizarSoloDVH(int idUsuario, string nuevoDvh)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", idUsuario));
            parametros.Add(acceso.CrearParametro("@dvh", nuevoDvh));

            acceso.Escribir("ACTUALIZAR_DVH_USUARIO", parametros);
            acceso.Cerrar();
        }

        public void MigrarUsuariosDeIdioma(int idIdiomaViejo, int idIdiomaNuevo)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@viejo", idIdiomaViejo));
            parametros.Add(acceso.CrearParametro("@nuevo", idIdiomaNuevo));
            acceso.Escribir("MIGRAR_USUARIOS_IDIOMA", parametros);

            acceso.Cerrar();
        }
    }
}
