using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class SESION
    {
        private static SESION _instancia;
        public USUARIO usuactual { get; set; }
        private static object _lock = new object();
        private SESION() { }

        public static SESION GetInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    _instancia = new SESION();
                }
            }
            return _instancia;
        }

        public void AsignarUsuario(USUARIO usuario)
        {
            usuactual = usuario;
        }
        public void Desasignar()
        {
            _instancia = null;
        }
        
    }
}
