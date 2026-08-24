using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class USUARIO
    {
		private int id;

		public int Id 
		{
			get { return id; }
			set { id = value; }
		}
		private string usuario;

		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		private string contraseña;

		public string Contraseña
		{
			get { return contraseña; }
			set { contraseña = value; }
		}

		private bool estadoBloqueado;

		public bool EstadoBloqueado
		{
			get { return estadoBloqueado; }
			set { estadoBloqueado = value; }
		}
		private int intentosFallidos;

		public int IntentosFallidos
		{
			get { return intentosFallidos; }
			set { intentosFallidos = value; }
		}

		private int dni;

		public int Dni
		{
			get { return dni; }
			set { dni = value; }
		}
		private string email;

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

        private List<COMPONENTE> permisos = new List<COMPONENTE>();
        public List<COMPONENTE> Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }

        private int idIdioma;

        public int IdIdioma
        {
            get { return idIdioma; }
            set { idIdioma = value; }
        }

		private string dvh;

		public string DVH
		{
			get { return dvh; }
			set { dvh = value; }
		}


		private bool activo;

		public bool Activo
		{
			get { return activo; }
			set { activo = value; }
		}

		public bool TienePermiso(string nombrePermiso)
        {
            foreach (var comp in permisos)
            {
                if (comp.TienePermiso(nombrePermiso))
                {
                    return true;
                }
            }
            return false;
        }

        public USUARIO()
        {
            this.Activo = true;
        }


    }

}
