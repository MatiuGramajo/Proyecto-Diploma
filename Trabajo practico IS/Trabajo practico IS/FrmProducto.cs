using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    public partial class FrmProducto : Form, BE.IObserver
    {
        BLL.PRODUCTO GestorProductos = new BLL.PRODUCTO();
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        BE.PRODUCTO productoSeleccionado = null;
        BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
        public FrmProducto()
        {
            InitializeComponent();
        }
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = gestorIdioma.Listar();
            CBXIdiomas.DisplayMember = "Nombre";
            CBXIdiomas.ValueMember = "Id";
            CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            ActualizarIdioma();
            EnlazarProductos();
            ActualizarEstadoBotones();
        }

        public void EnlazarProductos()
        {
            var productos = GestorProductos.Listar().AsEnumerable();

            if (CKXmostrarInactivos.Checked == false)
            {
                productos = productos.Where(p => p.Activo == true);
            }

            DGV_Productos.DataSource = null;
            DGV_Productos.DataSource = productos.ToList();
            DGV_Productos.ReadOnly = true;

            if (DGV_Productos.Columns["Id"] != null) DGV_Productos.Columns["Id"].Visible = false;
            if (DGV_Productos.Columns["Activo"] != null) DGV_Productos.Columns["Activo"].Visible = false;

        }
        public void LimpiarControles()
        {
            TXT_ProductoNombre.Text = "";
            NUD_PrecioProd.Value = 0;
            NUD_StockProd.Value = 0;
            productoSeleccionado = null;

            ActualizarEstadoBotones();
        }
        private void BTN_ProductoAlta_Click(object sender, EventArgs e)
        {
            try
            {
                BE.PRODUCTO nuevoProducto = new BE.PRODUCTO();
                nuevoProducto.Nombre = TXT_ProductoNombre.Text;
                nuevoProducto.Precio = NUD_PrecioProd.Value;
                nuevoProducto.Stock = (int)NUD_StockProd.Value;

                BE.PRODUCTO inactivoDuplicado = GestorProductos.ObtenerInactivoDuplicado(nuevoProducto);

                if (inactivoDuplicado != null)
                {
                    var result = MessageBox.Show("El nombre ingresado pertenece a un producto que fue dado de baja.\n\n¿Desea reactivarlo para conservar su historial en el sistema en lugar de crear uno nuevo?",
                                                 "Producto Inactivo Detectado",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        GestorProductos.Reactivar(inactivoDuplicado);
                        MessageBox.Show("El producto ha sido reactivado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnlazarProductos();
                        LimpiarControles();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                GestorProductos.Insertar(nuevoProducto);

                EnlazarProductos();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTN_ProductoBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado != null)
                {
                    var result = MessageBox.Show($"Esta seguro que desea borrar: {productoSeleccionado.Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        GestorProductos.Borrar(productoSeleccionado);
                        EnlazarProductos();
                        LimpiarControles();
                        productoSeleccionado = null;
                        ActualizarEstadoBotones();
                    }
                }
                else
                {
                    throw new Exception("Seleccione un producto para borrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTN_ProductoModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado != null)
                {
                    productoSeleccionado.Nombre = TXT_ProductoNombre.Text;
                    productoSeleccionado.Precio = NUD_PrecioProd.Value;
                    productoSeleccionado.Stock = (int)NUD_StockProd.Value;

                    GestorProductos.Modificar(productoSeleccionado);
                    GestorBitacora.RegistrarEvento("Inventario", $"Se modificó el producto: {productoSeleccionado.Nombre}", 3);

                    EnlazarProductos();
                    LimpiarControles();
                    productoSeleccionado = null;
                }
                else
                {
                    MessageBox.Show("Seleccione un producto para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                EnlazarProductos();
            }
        }

        private void BTN_ProductoReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado != null && productoSeleccionado.Activo == false)
                {
                    var result = MessageBox.Show($"¿Desea reactivar el producto: {productoSeleccionado.Nombre}?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        GestorProductos.Reactivar(productoSeleccionado);
                        EnlazarProductos();
                        LimpiarControles();
                        productoSeleccionado = null;
                        ActualizarEstadoBotones();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error al Reactivar", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void DGV_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                productoSeleccionado = DGV_Productos.Rows[e.RowIndex].DataBoundItem as BE.PRODUCTO;
                if (productoSeleccionado != null)
                {
                    TXT_ProductoNombre.Text = productoSeleccionado.Nombre;
                    NUD_PrecioProd.Value = productoSeleccionado.Precio;
                    NUD_StockProd.Value = productoSeleccionado.Stock;

                    ActualizarEstadoBotones();
                }

            }
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
            if (CBXIdiomas.Items.Count > 0)
            {
                CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
                CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            }
        }

        public void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido)) control.Text = textoTraducido;
                if (control.HasChildren) TraducirControles(control.Controls, traducciones);
            }
        }

        private void CBXIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBXIdiomas.SelectedValue != null && int.TryParse(CBXIdiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
                    var traducciones = gestorIdioma.ObtenerTraducciones(idIdioma);
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdioma, traducciones);

                    if (Servicios.SESION.GetInstancia().usuactual != null)
                    {
                        BLL.USUARIO gestorUsu = new BLL.USUARIO();
                        gestorUsu.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdioma);
                        Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdioma;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BTNvolveralmenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void FrmProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        private void CKXmostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            EnlazarProductos();
            LimpiarControles();
            productoSeleccionado = null;
        }

        private void ActualizarEstadoBotones()
        {
            if (productoSeleccionado == null)
            {
                BTN_ProductoModificar.Enabled = false;
                BTN_ProductoBaja.Enabled = false;
                BTN_ProductoReactivar.Enabled = false;
                return;
            }

            if (productoSeleccionado.Activo == false)
            {
                BTN_ProductoReactivar.Enabled = true;
                BTN_ProductoBaja.Enabled = false;
                BTN_ProductoModificar.Enabled = false;
            }

            else
            {
                BTN_ProductoReactivar.Enabled = false;
                BTN_ProductoBaja.Enabled = true;
                BTN_ProductoModificar.Enabled = true;
            }
        }

        private void DGV_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
