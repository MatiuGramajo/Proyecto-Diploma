using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_IDIOMA : MAPPER<BE.IDIOMA>
    {
        public override void Alta(IDIOMA obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(IDIOMA obj)
        {
            throw new NotImplementedException();
        }

        public List<BE.TRADUCCION>ListarTraduccionesDetalle(int idIdioma)
        {
            //log.Usuario = registro["USUARIO"].ToString();
            acceso.Abrir();
            List<SqlParameter>parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_idioma", idIdioma));
            DataTable tabla = acceso.Leer("OBTENER_TRADUCCIONES", parametros);
            acceso.Cerrar();
            List<BE.TRADUCCION> lista = new List<BE.TRADUCCION>();
            foreach(DataRow registro in tabla.Rows)
            {
                BE.TRADUCCION trad= new BE.TRADUCCION();
                trad.IdTraduccion = int.Parse(registro["ID_TRADUCCION"].ToString());
                trad.NombreFormulario = registro["NOMBRE_FORMULARIO"].ToString();
                trad.NombreControl = registro["NOMBRE_CONTROL"].ToString();
                trad.TextoTraducido = registro["TEXTO_TRADUCIDO"].ToString();
                lista.Add(trad);
            }
            return lista;
        }
        public List<BE.IDIOMA>ObtenerIdiomas()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("OBTENER_IDIOMA");
            acceso.Cerrar();
            List<BE.IDIOMA> listaidioma = new List<BE.IDIOMA>();
            foreach(DataRow registro in tabla.Rows)
            {
                BE.IDIOMA idioma= new BE.IDIOMA();
                idioma.Nombre = registro["NOMBRE"].ToString();
                idioma.Id = int.Parse(registro["ID_IDIOMA"].ToString());
                idioma.EstaDisponible = bool.Parse(registro["ESTADISPONIBLE"].ToString());
                listaidioma.Add(idioma);
            }
            return listaidioma;

        }
        public void AltaIdioma(string nombreIdioma, string sufijo)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nombre", nombreIdioma));
            parametros.Add(acceso.CrearParametro("@sufijo", sufijo));
            acceso.Escribir("ALTA_IDIOMA_CON_SUFIJO", parametros);
            acceso.Cerrar();
        }
        public override List<BE.IDIOMA> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_IDIOMAS");
            acceso.Cerrar();
            List<BE.IDIOMA> idiomas=new List<BE.IDIOMA>();
            foreach(DataRow registro in tabla.Rows)
            {
                BE.IDIOMA idio=new BE.IDIOMA();
                idio.Id = int.Parse(registro["id_idioma"].ToString());
                idio.Nombre = registro["nombre"].ToString();
                idio.EstaDisponible = bool.Parse(registro["estadisponible"].ToString());
                idiomas.Add(idio);
            }
            return idiomas;
        }

        public Dictionary<string, string> ObtenerTraducciones(int idIdioma)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_idioma", idIdioma));
            DataTable tabla = acceso.Leer("OBTENER_TRADUCCIONES", parametros);
            acceso.Cerrar();
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            foreach (DataRow fila in tabla.Rows)
            {
                string form = fila["nombre_formulario"].ToString();
                string control = fila["nombre_control"].ToString();
                string texto = fila["texto_traducido"].ToString();

                string clave = $"{form}_{control}";

                if (!diccionario.ContainsKey(clave))
                {
                    diccionario.Add(clave, texto);
                }
            }
            return diccionario;
        }
        public void HabilitarIdioma(IDIOMA obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_idioma", obj.Id));
            acceso.Escribir("HABILITAR_IDIOMA", parametros);
            acceso.Cerrar();

        }

        public void BajaLogica(IDIOMA obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_idioma", obj.Id));
            acceso.Escribir("BAJA_LOGICA_IDIOMA", parametros);
            acceso.Cerrar();
        }

        public override void Modificar(IDIOMA obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(IDIOMA obj)
        {
            throw new NotImplementedException();
        }
    }
}
