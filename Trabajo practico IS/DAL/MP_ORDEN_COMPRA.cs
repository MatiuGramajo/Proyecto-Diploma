using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_ORDEN_COMPRA : MAPPER<BE.ORDEN_COMPRA>
    {
        public override void Alta(ORDEN_COMPRA obj)
        {
            acceso.Abrir();

            // 1. Guardar Cabecera de la Orden de Compra
            List<SqlParameter> paramCabecera = new List<SqlParameter>();
            paramCabecera.Add(acceso.CrearParametro("@Id_Proveedor", obj.Id_Proveedor));
            paramCabecera.Add(acceso.CrearParametro("@Fecha_Emision", obj.Fecha_Emision));
            paramCabecera.Add(acceso.CrearParametro("@Estado", obj.Estado));

            int idOrdenGenerado = acceso.LeerEscalar("INSERTAR_ORDEN_COMPRA", paramCabecera);
            obj.Id_OrdenCompra = idOrdenGenerado;

            // 2. Loop: Guardar cada detalle en la tabla DETALLE_OC
            foreach (BE.DETALLE_ORDEN_COMPRA detalle in obj.Detalles)
            {
                List<SqlParameter> paramDetalle = new List<SqlParameter>();
                paramDetalle.Add(acceso.CrearParametro("@Id_OrdenCompra", idOrdenGenerado));
                paramDetalle.Add(acceso.CrearParametro("@Nombre_Insumo", detalle.Nombre_Insumo));
                paramDetalle.Add(acceso.CrearParametro("@Cantidad_Solicitada", detalle.Cantidad_Solicitada));

                acceso.Escribir("INSERTAR_DETALLE_ORDEN_COMPRA", paramDetalle);
            }

            acceso.Cerrar();
     
        }
        public void RegistrarRecepcion(BE.ORDEN_COMPRA ordenSeleccionada)
        {
            acceso.Abrir();

            // 1. Actualizar el estado de la Orden de Compra a 'Recibida'
            List<SqlParameter> paramCabecera = new List<SqlParameter>();
            paramCabecera.Add(acceso.CrearParametro("@Id_OrdenCompra", ordenSeleccionada.Id_OrdenCompra));

            acceso.Escribir("REGISTRAR_RECEPCION_ORDEN_COMPRA", paramCabecera);

            // 2. Loop Por cada detalle de la orden de compra para guardar la Cantidad_Recibida
            foreach (BE.DETALLE_ORDEN_COMPRA detalle in ordenSeleccionada.Detalles)
            {
                List<SqlParameter> paramDetalle = new List<SqlParameter>();
                paramDetalle.Add(acceso.CrearParametro("@Id_Detalle", detalle.Id_Detalle));
                paramDetalle.Add(acceso.CrearParametro("@Cantidad_Recibida", detalle.Cantidad_Recibida));

                acceso.Escribir("ACTUALIZAR_CANTIDAD_RECIBIDA_DETALLE", paramDetalle);
            }

            acceso.Cerrar();
        }
    

        public List<BE.ORDEN_COMPRA> ListarEmitidas()
        {
            acceso.Abrir();
            DataTable dt = acceso.Leer("LISTAR_ORDENES_COMPRA_EMITIDAS");
            acceso.Cerrar();

            List<BE.ORDEN_COMPRA> lista = new List<BE.ORDEN_COMPRA>();
            foreach (DataRow row in dt.Rows)
            {
                BE.ORDEN_COMPRA orden = new BE.ORDEN_COMPRA
                {
                    Id_OrdenCompra = Convert.ToInt32(row["Id_OrdenCompra"]),
                    Id_Proveedor = Convert.ToInt32(row["Id_Proveedor"]),
                    Fecha_Emision = Convert.ToDateTime(row["Fecha_Emision"]),
                    Estado = row["Estado"].ToString()
                };

                // Carga del detalle asociado para cada orden
                orden.Detalles = CargarDetallesPorOrden(orden.Id_OrdenCompra);
                lista.Add(orden);
            }
            return lista;
        }
        private List<BE.DETALLE_ORDEN_COMPRA> CargarDetallesPorOrden(int idOrdenCompra)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_OrdenCompra", idOrdenCompra));

            DataTable dt = acceso.Leer("LISTAR_DETALLES_POR_ORDEN", parametros);
            acceso.Cerrar();

            List<BE.DETALLE_ORDEN_COMPRA> detalles = new List<BE.DETALLE_ORDEN_COMPRA>();
            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(new BE.DETALLE_ORDEN_COMPRA
                {
                    Id_Detalle = Convert.ToInt32(row["Id_Detalle"]),
                    Id_OrdenCompra = Convert.ToInt32(row["Id_OrdenCompra"]),
                    Nombre_Insumo = row["Nombre_Insumo"].ToString(),
                    Cantidad_Solicitada = Convert.ToInt32(row["Cantidad_Solicitada"]),
                    Cantidad_Recibida = row["Cantidad_Recibida"] != DBNull.Value ? Convert.ToInt32(row["Cantidad_Recibida"]) : 0
                });
            }
            return detalles;
        }
        public void Anular(int idOrdenCompra, string motivo)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_OrdenCompra", idOrdenCompra));
            parametros.Add(acceso.CrearParametro("@Motivo_Anulacion", motivo));

            acceso.Escribir("ANULAR_ORDEN_COMPRA", parametros);
            acceso.Cerrar();
        }
        public override void Baja(ORDEN_COMPRA obj)
        {
            throw new NotImplementedException();
        }

        public override List<ORDEN_COMPRA> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(ORDEN_COMPRA obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(ORDEN_COMPRA obj)
        {
            throw new NotImplementedException();
        }
    }
}
