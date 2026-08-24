using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PERMISO_COMPUESTO : COMPONENTE
    {
        private List<COMPONENTE> _hijos;

        public override bool EsCompuesto
        {
            get { return true; }
        }

        public PERMISO_COMPUESTO()
        {
            _hijos = new List<COMPONENTE>();
        }

        public override void VaciarHijos()
        {
            _hijos = new List<COMPONENTE>();
        }
        public override void AgregarHijo(COMPONENTE c)
        {
            _hijos.Add(c);
        }

        public override void BorrarHijo(COMPONENTE c)
        {
            _hijos.Remove(c);
        
        }
        public override COMPONENTE GetHijo(int index)
        {
            if (index < 0 || index >= _hijos.Count)
                return null;

            return _hijos[index];
        }

        public override int GetCantidadHijos()
        {
            return _hijos.Count;
        }

        public override bool TienePermiso(string nombrePermiso)
        {
            if (this.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            foreach (var hijo in _hijos)
            {
                if (hijo.TienePermiso(nombrePermiso))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
