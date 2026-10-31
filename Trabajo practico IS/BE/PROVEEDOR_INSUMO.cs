using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PROVEEDOR_INSUMO
    {
		private int id_Proveedor;

		public int Id_Proveedor
		{
			get { return id_Proveedor; }
			set { id_Proveedor = value; }
		}
		private string razon_Social;

		public string Razon_Social
		{
			get { return razon_Social; }
			set { razon_Social = value; }
		}
		private string cuit;

		public string Cuit
		{
			get { return cuit; }
			set { cuit = value; }
		}
		private string rubro;

		public string Rubro
		{
			get { return rubro; }
			set { rubro = value; }
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
            return $"{Razon_Social} ({Rubro}) - CUIT: {Cuit}";
        }
    }
}
