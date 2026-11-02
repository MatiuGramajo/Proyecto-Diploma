using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PERSONAL
    {
        private int id_Personal;
        public int Id_Personal
        {
            get { return id_Personal; }
            set { id_Personal = value; }
        }

        private string dni;
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string categoria;
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre} ({Categoria}) - DNI: {Dni}";
        }
    }
}
