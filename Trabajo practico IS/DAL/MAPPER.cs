using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class MAPPER<T>
    {
        public ACCESO acceso = new ACCESO();

        public abstract void Alta(T obj);
        public abstract void Baja(T obj);
        public abstract void Modificar(T obj);
        public abstract List<T> Listar();
        public abstract bool Verificar (T obj);
        

    }
}
