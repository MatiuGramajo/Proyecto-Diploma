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
    public class MP_PROVEEDOR_EXTERNO : MAPPER<BE.PROVEEDOR_EXTERNO>
    {
        public bool VerificarEstado(int idProveedor)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Proveedor", idProveedor));

            DataTable dt = acceso.Leer("VERIFICAR_ESTADO_PROVEEDOR", parametros);
            acceso.Cerrar();

            if (dt.Rows.Count > 0)
            {
                // Si el estado es 1 o 'Activo', retorna true.
                return dt.Rows[0]["Estado"].ToString().Equals("Activo", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
        public override void Alta(PROVEEDOR_EXTERNO obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(PROVEEDOR_EXTERNO obj)
        {
            throw new NotImplementedException();
        }

        public override List<PROVEEDOR_EXTERNO> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(PROVEEDOR_EXTERNO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(PROVEEDOR_EXTERNO obj)
        {
            throw new NotImplementedException();
        }
    }
}
