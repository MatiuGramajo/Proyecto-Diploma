using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_INVENTARIO : MAPPER<BE.INVENTARIO>
    {
        public void ActualizarStock(List<BE.DETALLE_OC> listaDetallesRecibidos)
        {
            acceso.Abrir();
            foreach (var detalle in listaDetallesRecibidos)
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.CrearParametro("@Id_Insumo", detalle.Id_Insumo));
                parametros.Add(acceso.CrearParametro("@Cantidad_Sumar", detalle.Cantidad_Recibida));

                acceso.Escribir("ACTUALIZAR_STOCK_INSUMO", parametros);
            }
            acceso.Cerrar();
        }

        public override void Alta(INVENTARIO obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(INVENTARIO obj)
        {
            throw new NotImplementedException();
        }

        public override List<INVENTARIO> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(INVENTARIO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(INVENTARIO obj)
        {
            throw new NotImplementedException();
        }
    }
}
