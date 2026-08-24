using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_BACKUP
    {
        public void RestaurarBaseDeDatos(string rutaBackup)
        {
            string connectionStringMaster = "Initial Catalog=master;Data Source=.;Integrated Security=SSPI";

            using (SqlConnection conexionMaster = new SqlConnection(connectionStringMaster))
            {
                conexionMaster.Open();
                string queryRestore = @"
                    ALTER DATABASE [BASE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [BASE] FROM DISK = @ruta WITH REPLACE;
                    ALTER DATABASE [BASE] SET MULTI_USER;";

                using (SqlCommand cmd = new SqlCommand(queryRestore, conexionMaster))
                {
                    cmd.Parameters.AddWithValue("@ruta", rutaBackup);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CrearBackup(string rutaDestino)
        {
            string connectionStringMaster = "Initial Catalog=master;Data Source=.;Integrated Security=SSPI";

            using (SqlConnection conexionMaster = new SqlConnection(connectionStringMaster))
            {
                conexionMaster.Open();
                string queryBackup = @"BACKUP DATABASE [BASE] TO DISK = @ruta WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Copia de seguridad completa de BASE';";

                using (SqlCommand cmd = new SqlCommand(queryBackup, conexionMaster))
                {
                    cmd.Parameters.AddWithValue("@ruta", rutaDestino);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
