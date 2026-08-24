using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DIGITO_VERIFICADOR
    {
        MP_DIGITO_VERIFICADOR MapperDV = new MP_DIGITO_VERIFICADOR();
        public string CalcularDVH(BE.USUARIO usuario)
        {
            string cadenaAHashear = $"{usuario.Id}" +
                                    $"{usuario.Usuario}" +
                                    $"{usuario.Contraseña}" +
                                    $"{usuario.EstadoBloqueado}" +
                                    $"{usuario.IntentosFallidos}" +
                                    $"{usuario.Dni}" +
                                    $"{usuario.Email}" +
                                    $"{usuario.IdIdioma}" +
                                    $"{usuario.Activo}";

            return ENCRIPTADOR.Hashear(cadenaAHashear);
        }

        public string ObtenerDVV(string nombreTabla)
        {
            return MapperDV.ObtenerDVV(nombreTabla);
        }
        public string CalcularDVV(List<string> todosLosDvh)
        {
            if (todosLosDvh == null || todosLosDvh.Count == 0)
            {
                return ENCRIPTADOR.Hashear("");
            }

            StringBuilder cadenaGlobal = new StringBuilder();

            foreach (string dvh in todosLosDvh)
            {
                cadenaGlobal.Append(dvh);
            }

            return ENCRIPTADOR.Hashear(cadenaGlobal.ToString());
        }

        public void RecalcularYGuardarDVV(string nombreTabla, List<string> todosLosDvh)
        {
            string nuevoDvv = CalcularDVV(todosLosDvh);
            MapperDV.ActualizarDVV(nombreTabla, nuevoDvv);
        }
    }
}
