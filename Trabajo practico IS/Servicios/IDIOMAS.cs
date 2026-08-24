using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public  class IDIOMAS: BE.IObservable
    {

        private static IDIOMAS _instancia;
        private static object _lock = new object();
        private List<BE.IObserver> _observadores = new List<BE.IObserver>();
        public Dictionary<string, string> Traducciones { get; private set; } = new Dictionary<string, string>();
        public int IdIdiomaActual { get; private set; } = 1;
        private IDIOMAS() { }

        public static IDIOMAS GetInstancia()
        {
            if(_instancia == null)
            {
                lock(_lock)
                {
                    if (_instancia == null) _instancia = new IDIOMAS();

                }
            }
            return _instancia;
        }
        
        public void Suscribir(IObserver observer)
        {
            if (!_observadores.Contains(observer))
                _observadores.Add(observer);
        }

        public void Desuscribir(IObserver observer)
        {

            if (_observadores.Contains(observer))
                _observadores.Remove(observer);
        }

        public void Notificar(string mensaje="")
        {
            foreach (var observer in _observadores)
            {
                observer.ActualizarIdioma();
            }
        }
        public void CambiarIdioma(int idIdioma, Dictionary<string, string> nuevasTraducciones)
        {
            IdIdiomaActual = idIdioma;
            Traducciones = nuevasTraducciones;
            Notificar();
        }
    }
}
