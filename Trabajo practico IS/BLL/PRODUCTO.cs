using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PRODUCTO
    {
        MP_PRODUCTO mapper = new MP_PRODUCTO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        BLL.HISTORIAL_PRODUCTO GestorHistorial = new BLL.HISTORIAL_PRODUCTO();

        public void Insertar(BE.PRODUCTO producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre del producto no puede estar vacío.");

            if (producto.Precio <= 0)
                throw new Exception("El precio debe ser mayor a cero.");

            if (producto.Stock < 0)
                throw new Exception("El stock no puede ser negativo.");

            var todos = mapper.Listar();
            if (todos.Any(p => p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase) && p.Activo == true ))
                throw new Exception("Ya existe un producto con ese nombre.");

            mapper.Alta(producto);
            GestorHistorial.RegistrarCambio(producto.Id, ObtenerResponsable(), "ALTA");
            GestorBitacora.RegistrarEvento("Inventario", $"Se dio de alta el producto {producto.Nombre}", 2);
        }

        public void Borrar(BE.PRODUCTO producto)
        {
            GestorHistorial.RegistrarCambio(producto.Id, ObtenerResponsable(), "BAJA");
            producto.Activo = false;
            mapper.Baja(producto);
            GestorBitacora.RegistrarEvento("Inventario", $"Se dio de baja el producto {producto.Nombre}", 2);
        }

        public void Modificar(BE.PRODUCTO producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new Exception("El nombre del producto no puede estar vacío.");
            }

            if (producto.Precio <= 0)
            {
                throw new Exception("El precio del producto debe ser mayor a cero.");
            }

            if (producto.Stock < 0)
            {
                throw new Exception("El stock no puede ser un número negativo.");
            }

            List<BE.PRODUCTO> todosLosProductos = mapper.Listar();

            bool nombreRepetido = todosLosProductos.Any(p => p.Id != producto.Id && p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase) && p.Activo == true);

            if (nombreRepetido)
            {
                throw new Exception("Ya existe otro producto registrado con ese mismo nombre.");
            }

            mapper.Modificar(producto);
            GestorHistorial.RegistrarCambio(producto.Id, ObtenerResponsable(), "MODIFICACION");
            GestorBitacora.RegistrarEvento("Inventario", $"Se modificó el producto {producto.Nombre}", 2);
        }

        public List<BE.PRODUCTO> Listar()
        {
            return mapper.Listar();
        }

        public void Reactivar(BE.PRODUCTO producto)
        {
            List<BE.PRODUCTO> todosLosProductos = mapper.Listar();

            bool productoExistente = todosLosProductos.Any(p =>
                p.Id != producto.Id &&
                p.Activo == true &&
                p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase)
            );

            if (productoExistente)
            {
                throw new Exception("Operación Denegada: Ya existe un producto activo en el catálogo con este mismo nombre.");
            }

            producto.Activo = true;
            mapper.Reactivar(producto);

            GestorHistorial.RegistrarCambio(producto.Id, ObtenerResponsable(), "REACTIVACION");
            GestorBitacora.RegistrarEvento("Inventario", $"Se reactivó el producto: {producto.Nombre}", 3);
        }

        public BE.PRODUCTO ObtenerInactivoDuplicado(BE.PRODUCTO producto)
        {
            List<BE.PRODUCTO> todosLosProductos = mapper.Listar();

            return todosLosProductos.FirstOrDefault(p =>
                p.Activo == false &&
                p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase)
            );
        }

        private string ObtenerResponsable()
        {
            return Servicios.SESION.GetInstancia().usuactual != null
                ? Servicios.SESION.GetInstancia().usuactual.Usuario
                : "SISTEMA";
        }
    }
}
