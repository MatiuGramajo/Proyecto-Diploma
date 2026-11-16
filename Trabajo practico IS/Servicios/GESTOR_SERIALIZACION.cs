using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Servicios
{
    public class GESTOR_SERIALIZACION
    {
        public void SerializarXML<T>(T objeto, string rutaArchivo)
        {
            try
            {
                string directorio = Path.GetDirectoryName(rutaArchivo);
                if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
                {
                    serializer.Serialize(writer, objeto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al serializar el archivo XML: " + ex.Message);
            }
        }

        public T DeserializarXML<T>(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    throw new FileNotFoundException("No se encontró el archivo XML especificado.");
                }

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamReader reader = new StreamReader(rutaArchivo, Encoding.UTF8))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al deserializar el archivo XML: " + ex.Message);
            }
        }
    }

}

