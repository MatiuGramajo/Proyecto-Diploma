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
    public class MP_CLIENTE : MAPPER<BE.CLIENTE>
    {
        public bool ValidarDNI(int dni)
        {
            acceso.Abrir();
            List<SqlParameter>parametros= new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@dni",dni));
            DataTable dt = acceso.Leer("VALIDAR_DNI_CLIENTE", parametros);
            acceso.Cerrar();
            return dt.Rows.Count > 0;
        }
        public override void Alta(CLIENTE obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nombre_completo", obj.Nombre_Completo));
            parametros.Add(acceso.CrearParametro("@dni", obj.Dni));
            parametros.Add(acceso.CrearParametro("@telefono", obj.Telefono));
            parametros.Add(acceso.CrearParametro("@email", obj.Email));
            acceso.Escribir("INSERTAR_CLIENTE", parametros);
            acceso.Cerrar();
        }

        public override void Baja(CLIENTE obj)
        {
            throw new NotImplementedException();
        }

        public override List<CLIENTE> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(CLIENTE obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(CLIENTE obj)
        {
            throw new NotImplementedException();
        }
    }
}
