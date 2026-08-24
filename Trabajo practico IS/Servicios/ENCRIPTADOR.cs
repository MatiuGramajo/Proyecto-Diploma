using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Servicios
{
    public static class ENCRIPTADOR
    {
        public static string Hashear(string textoPlano)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoPlano);
                byte[] hashbytes = sha256.ComputeHash(bytes);
                StringBuilder constructorString = new StringBuilder();
                for (int i = 0; i < hashbytes.Length;i++)
                {
                    constructorString.Append(hashbytes[i].ToString("x2"));
                }
                return constructorString.ToString();

            }
        }
    }
}
