using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_SERVICIO_CATERING : MAPPER<BE.SERVICIO_CATERING>
    {
        public override void Alta(SERVICIO_CATERING obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(SERVICIO_CATERING obj)
        {
            throw new NotImplementedException();
        }

        public override List<SERVICIO_CATERING> Listar()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_CATERING");
            acceso.Cerrar();

            List<BE.SERVICIO_CATERING> lista = new List<BE.SERVICIO_CATERING>();
            foreach (DataRow row in dt.Rows)
            {
                BE.SERVICIO_CATERING cat = new BE.SERVICIO_CATERING();
                cat.Id_Servicio = Convert.ToInt32(row["Id_Servicio"]);
                cat.Tipo_Menu = row["Tipo_Menu"].ToString();
                cat.Precio_Por_Persona = Convert.ToDecimal(row["Precio_Por_Persona"]);
                lista.Add(cat);
            }
            return lista;
        }

        public override void Modificar(SERVICIO_CATERING obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(SERVICIO_CATERING obj)
        {
            throw new NotImplementedException();
        }
    }
}
