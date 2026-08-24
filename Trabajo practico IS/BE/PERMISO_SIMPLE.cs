using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PERMISO_SIMPLE : COMPONENTE
    {
        public override bool EsCompuesto
        {
            get { return false; }
        }
        public override void AgregarHijo(COMPONENTE c)
        {
            throw new NotImplementedException("Los permisos simples no tienen hijos.");
        }

        public override void BorrarHijo(COMPONENTE c)
        {
            throw new NotImplementedException();
        }

        public override COMPONENTE GetHijo(int index)
        {
            throw new NotImplementedException("Los permisos simples no tienen hijos.");
        }

        public override int GetCantidadHijos()
        {
            return 0;
        }

        public override bool TienePermiso(string nombrePermiso)
        {
            return this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase);
        }

        public override void VaciarHijos()
        {
            
        }
    }
}
