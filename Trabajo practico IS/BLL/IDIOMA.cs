using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IDIOMA
    {

        private DAL.MP_IDIOMA mapper = new DAL.MP_IDIOMA();

        public List<BE.IDIOMA> Listar()
        {
            List<BE.IDIOMA> IdiomasTotales = mapper.Listar();
            List<BE.IDIOMA> idiomasDisponibles = (from i in IdiomasTotales
                                                  where i.EstaDisponible == true
                                                  select i).ToList();

            return idiomasDisponibles;
        }
        public List<BE.TRADUCCION> ObtenerDetalleTraducciones(int idIdioma)
        {
            return mapper.ListarTraduccionesDetalle(idIdioma);
        }
        public Dictionary<string, string> ObtenerTraducciones(int idIdioma)
        {
            return mapper.ObtenerTraducciones(idIdioma);
        }
        public List<BE.IDIOMA>ObtenerIdioma()
        {
            return mapper.ObtenerIdiomas();
        }
        public void CrearIdioma(string nombreIdioma, string sufijo)
        {
            mapper.AltaIdioma(nombreIdioma, sufijo);
        }
        public void HabilitarIdioma(int idIdiomaHabilitar)
        {
            BE.IDIOMA idiomaParaAlta = new BE.IDIOMA();
            idiomaParaAlta.Id = idIdiomaHabilitar;
            mapper.HabilitarIdioma(idiomaParaAlta);
        }

        public void DeshabilitarIdioma(int idIdiomaADeshabilitar)
        {

            List<BE.IDIOMA> listaCompleta = mapper.Listar();
            int cantidadActivos = (from i in listaCompleta
                                   where i.EstaDisponible == true
                                   select i).Count();

            bool esElIdiomaSeleccionadoActivo = (from i in listaCompleta
                                                 where i.Id == idIdiomaADeshabilitar && i.EstaDisponible == true
                                                 select i).Any();
            if (cantidadActivos <= 1 && esElIdiomaSeleccionadoActivo)
            {
                throw new Exception("Operación inválida: No se puede deshabilitar este idioma. El sistema requiere que permanezca al menos un (1) idioma activo para garantizar el funcionamiento de la interfaz.");
            }
            BE.IDIOMA idiomaParaBaja = new BE.IDIOMA();
            idiomaParaBaja.Id = idIdiomaADeshabilitar;

            mapper.BajaLogica(idiomaParaBaja);
            int idIdiomaAlternativo = 1;
            if (idIdiomaADeshabilitar == 1)
            {

                idIdiomaAlternativo = (from i in listaCompleta
                                       where i.Id != 1 && i.EstaDisponible == true
                                       select i).First().Id;
            }
            DAL.MP_USUARIO mapperUsuario = new DAL.MP_USUARIO();
            mapperUsuario.MigrarUsuariosDeIdioma(idIdiomaADeshabilitar, idIdiomaAlternativo);

            List<BE.USUARIO> todosLosUsuarios = mapperUsuario.Listar();
            BLL.DIGITO_VERIFICADOR gestorDV = new BLL.DIGITO_VERIFICADOR();
            List<string> listaNuevosDVH = new List<string>();

            foreach (var usu in todosLosUsuarios)
            {
                string dvhCalculado = gestorDV.CalcularDVH(usu);

                if (dvhCalculado != usu.DVH)
                {
                    mapperUsuario.ActualizarSoloDVH(usu.Id, dvhCalculado);
                    usu.DVH = dvhCalculado;
                }

                listaNuevosDVH.Add(usu.DVH);
            }
            gestorDV.RecalcularYGuardarDVV("USUARIO", listaNuevosDVH);
        }
    }
}
