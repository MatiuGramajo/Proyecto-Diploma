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
    public class MP_PRESTADOR_SERVICIO : MAPPER<BE.PRESTADOR_SERVICIO>
    {
        public bool VerificarEstado(int idPrestador)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Proveedor", idPrestador));

            DataTable dt = acceso.Leer("VERIFICAR_ESTADO_PRESTADOR", parametros);
            acceso.Cerrar();

            if (dt.Rows.Count > 0)
            {
                // Si el estado es 1 o 'Activo', retorna true.
                return dt.Rows[0]["Estado"].ToString().Equals("Activo", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
        public override void Alta(PRESTADOR_SERVICIO obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(PRESTADOR_SERVICIO obj)
        {
            throw new NotImplementedException();
        }

        public override List<PRESTADOR_SERVICIO> Listar()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_PRESTADORES_SERVICIOS");
            acceso.Cerrar();

            List<BE.PRESTADOR_SERVICIO> lista = new List<BE.PRESTADOR_SERVICIO>();
            foreach (DataRow row in dt.Rows)
            {
                BE.PRESTADOR_SERVICIO prov = new BE.PRESTADOR_SERVICIO();
                prov.Id_Prestador = Convert.ToInt32(row["Id_Prestador"]);
                prov.Nombre_Fantasia = row["Nombre_Fantasia"].ToString();
                prov.Rubro = row["Rubro"].ToString();
                prov.Estado = row["Estado"].ToString();
                prov.Precio_Servicio = Convert.ToInt32(row["Precio_Servicio"]);
                // Asumimos que tienes "Estado" en tu BD para los proveedores
                lista.Add(prov);
            }
            return lista;
        }

        public override void Modificar(PRESTADOR_SERVICIO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(PRESTADOR_SERVICIO obj)
        {
            throw new NotImplementedException();
        }
    }
}
