using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface IObservable
    {
        void Suscribir(IObserver observer);
        void Desuscribir(IObserver observer);
        void Notificar(string mensaje);
    }
}
