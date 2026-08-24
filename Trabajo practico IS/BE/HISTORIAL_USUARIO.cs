using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HISTORIAL_USUARIO:USUARIO
    {
        private int idHistorial;

        public int IdHistorial
        {
            get { return idHistorial; }
            set { idHistorial = value; }
        }
        private DateTime fechaCambio;

        public DateTime FechaCambio
        {
            get { return fechaCambio; }
            set { fechaCambio = value; }
        }
        private string usuarioAccion;

        public string UsuarioAccion
        {
            get { return usuarioAccion; }
            set { usuarioAccion = value; }
        }
        private string tipoAccion;

        public string TipoAccion
        {
            get { return tipoAccion; }
            set { tipoAccion = value; }
        }


    }
}
