using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class COMPONENTE
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public abstract void AgregarHijo(COMPONENTE c);
        public abstract void VaciarHijos();
        public abstract void BorrarHijo(COMPONENTE c);
        public abstract COMPONENTE GetHijo(int index);
        public abstract int GetCantidadHijos();
        public abstract bool TienePermiso(string nombrePermiso);
        public abstract bool EsCompuesto { get; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
