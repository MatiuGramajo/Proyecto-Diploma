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
    public class MP_PARAMETRO_RATIO : MAPPER<BE.PARAMETRO_RATIO>
    {
        public override void Alta(PARAMETRO_RATIO obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(PARAMETRO_RATIO obj)
        {
            throw new NotImplementedException();
        }

        public override List<PARAMETRO_RATIO> Listar()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_RATIOS_PARAMETROS");
            acceso.Cerrar();

            List<BE.PARAMETRO_RATIO> lista = new List<BE.PARAMETRO_RATIO>();
            foreach (DataRow row in dt.Rows)
            {
                BE.PARAMETRO_RATIO ratio = new BE.PARAMETRO_RATIO
                {
                    Id_Ratio = Convert.ToInt32(row["Id_Ratio"]),
                    Categoria = row["Categoria"].ToString(),
                    Cantidad_Invitados_Por_Personal = Convert.ToInt32(row["Cantidad_Invitados_Por_Personal"]),
                    Estado = row["Estado"].ToString()
                };
                lista.Add(ratio);
            }
            return lista;
        }
        public void GuardarCalibracion(BE.CALIBRACION_DTO objCalibracion)
        {
            foreach (var ratio in objCalibracion.RatiosSugeridos)
            {
                Modificar(ratio);
            }
        }
        public override void Modificar(PARAMETRO_RATIO obj)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Categoria", obj.Categoria),
                new SqlParameter("@Cantidad_Invitados_Por_Personal", obj.Cantidad_Invitados_Por_Personal)
            };
            acceso.Escribir("GUARDAR_PARAMETRO_RATIO", parametros);
            acceso.Cerrar();
        }

        public override bool Verificar(PARAMETRO_RATIO obj)
        {
            throw new NotImplementedException();
        }
    }
}
