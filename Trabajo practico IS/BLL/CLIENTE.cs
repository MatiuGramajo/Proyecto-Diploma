using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CLIENTE
    {
        private DAL.MP_CLIENTE mapper = new DAL.MP_CLIENTE();

        public void Insertar(BE.CLIENTE clienteNuevo)
        {
            bool existeDNI = mapper.ValidarDNI(clienteNuevo.Dni);

            if (existeDNI)
            {
                throw new Exception("El DNI ingresado ya se encuentra registrado.");
            }

            mapper.Alta(clienteNuevo);
        }

        public List<BE.CLIENTE> Listar()
        {
            return mapper.Listar();
        }
    }
}

