using DAL;
using Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AUDITORIA
    {
        MP_USUARIO MapperUsuarios = new MP_USUARIO();
        MP_DIGITO_VERIFICADOR MapperDV = new MP_DIGITO_VERIFICADOR();
        BLL.DIGITO_VERIFICADOR GestorDV = new BLL.DIGITO_VERIFICADOR();

        public void AuditarSistema()
        {
            List<BE.USUARIO> todosLosUsuarios = MapperUsuarios.Listar();
            List<string> dvhsCalculados = new List<string>();

            foreach (var usuario in todosLosUsuarios)
            {
                string dvhCalculado = GestorDV.CalcularDVH(usuario);

                if (dvhCalculado != usuario.DVH)
                {
                    throw new IntegridadDatosException(
                        tabla: "USUARIO",
                        registro: $"ID: {usuario.Id} - Usuario: {usuario.Usuario}",
                        detalle: "Falla en DVH: Un campo de este registro fue modificado por fuera del sistema."
                    );
                }
                dvhsCalculados.Add(dvhCalculado);
            }
            string dvvCalculado = GestorDV.CalcularDVV(dvhsCalculados);
            string dvvBaseDatos = MapperDV.ObtenerDVV("USUARIO");

            if (dvvCalculado != dvvBaseDatos)
            {
                throw new IntegridadDatosException(
                    tabla: "USUARIO",
                    registro: "Múltiples / Tabla Completa",
                    detalle: "Falla en DVV: Se detectó la inserción o eliminación de registros directamente en SQL Server."
                );
            }
        }
    }
}
