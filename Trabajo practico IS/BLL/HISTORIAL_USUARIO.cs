using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HISTORIAL_USUARIO
    {
        private DAL.MP_HISTORIAL_USUARIO mapperHistorial = new DAL.MP_HISTORIAL_USUARIO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();

        public void RegistrarCambio(int idUsuario, string usuarioResponsable, string tipoAccion)
        {
            mapperHistorial.RegistrarEnHistorial(idUsuario, usuarioResponsable, tipoAccion);
        }

        public List<BE.HISTORIAL_USUARIO> Listar()
        {
            return mapperHistorial.Listar();
        }

        public void RestaurarUsuario(int idHistorial)
        {
            string responsable = Servicios.SESION.GetInstancia().usuactual.Usuario;
            mapperHistorial.RestaurarVersion(idHistorial, responsable);
            BLL.USUARIO gestorUsuarioLocal = new BLL.USUARIO();
            gestorUsuarioLocal.ActualizarDvvUsuarios();

            GestorBitacora.RegistrarEvento("Administracion", $"Se restauró un perfil de usuario desde el registro histórico ID: {idHistorial}", 2);
        }
    }
}
