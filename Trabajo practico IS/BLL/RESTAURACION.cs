using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RESTAURACION
    {
        MP_BACKUP MapperBackUp = new MP_BACKUP();
        BLL.USUARIO GestorUsuarios = new BLL.USUARIO();
        BLL.DIGITO_VERIFICADOR GestorDv = new BLL.DIGITO_VERIFICADOR();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();

        public void RestaurarBackup(string rutaArchivo)
        {
            MapperBackUp.RestaurarBaseDeDatos(rutaArchivo);
            GestorBitacora.RegistrarEvento("Administracion", "Restauración de base de datos desde archivo .bak", 1);
        }

        public void CrearBackup(string rutaDestino)
        {
            MapperBackUp.CrearBackup(rutaDestino);
            GestorBitacora.RegistrarEvento("Administracion", "Generación de Backup manual de la base de datos", 2);
        }

        public void RecalcularTodosLosDigitos()
        {
            List<BE.USUARIO> usuarios = GestorUsuarios.Listar();
            List<string> nuevosDvhs = new List<string>();

            foreach (var usu in usuarios)
            {
                string nuevoDvh = GestorDv.CalcularDVH(usu);
                GestorUsuarios.ActualizarSoloDVH(usu.Id, nuevoDvh);
                nuevosDvhs.Add(nuevoDvh);
            }

            GestorDv.RecalcularYGuardarDVV("USUARIO", nuevosDvhs);

            GestorBitacora.RegistrarEvento("Seguridad", "Se recalcularon las firmas DVH y DVV de la tabla USUARIO (Operación de Emergencia)", 1);
        }
    }
}
