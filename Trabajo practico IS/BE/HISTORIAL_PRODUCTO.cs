using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HISTORIAL_PRODUCTO
    {
        private int idHistorial;

        public int IdHistorial
        {
            get { return idHistorial; }
            set { idHistorial = value; }
        }
        
        private int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private DateTime fechaCambio;

        public DateTime FechaCambio
        {
            get { return fechaCambio; }
            set { fechaCambio = value; }
        }
        private string usuarioAccion;

        public string UsuarioAccion
        {
            get { return usuarioAccion; }
            set { usuarioAccion = value; }
        }
        private string tipoAccion;

        public string TipoAccion
        {
            get { return tipoAccion; }
            set { tipoAccion = value; }
        }
        
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private decimal precio;

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private bool activo;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }
}
