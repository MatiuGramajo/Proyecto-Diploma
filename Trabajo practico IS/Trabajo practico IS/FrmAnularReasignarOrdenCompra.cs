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
    public partial class FrmAnularReasignarOrdenCompra : Form, BE.IObserver
    {
        private BLL.ORDEN_COMPRA bllOrdenCompra = new BLL.ORDEN_COMPRA();
        private BLL.PROVEEDOR_INSUMO bllProveedorInsumo = new BLL.PROVEEDOR_INSUMO();
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        private List<BE.ORDEN_COMPRA> listaOrdenesEmitidas = new List<BE.ORDEN_COMPRA>();
        private BE.ORDEN_COMPRA ordenSeleccionada = null;
        public FrmAnularReasignarOrdenCompra()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmAnularReasignarOrdenCompra_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
            InicializarIdioma();
        }

        private void MostrarFormulario()
        {
            try
            {
                rbAnular.Checked = true;
                txtMotivo.Text = string.Empty;
                ordenSeleccionada = null;

                cmbProveedores.DataSource = null;
                cmbProveedores.DataSource = bllProveedorInsumo.ListarProveedores();
                cmbProveedores.DisplayMember = "Razon_Social";
                cmbProveedores.ValueMember = "Id_Proveedor";
                cmbProveedores.SelectedIndex = -1;

                ActualizarEstadoControles();

                CargarOrdenesEmitidas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la pantalla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOrdenesEmitidas()
        {
            listaOrdenesEmitidas = bllOrdenCompra.ListarOrdenesEmitidas();

            dgvOrdenesEmitidas.DataSource = null;
            dgvOrdenesEmitidas.Columns.Clear();
            dgvOrdenesEmitidas.DataSource = new BindingSource { DataSource = listaOrdenesEmitidas };

            FormatearGrillaOrdenes();

            dgvDetalleOrden.DataSource = null;
            dgvDetalleOrden.Columns.Clear();
            ordenSeleccionada = null;
        }

        private void FormatearGrillaOrdenes()
        {
            if (dgvOrdenesEmitidas.Columns.Count == 0) return;

            // 1. Configuración de solo lectura y selección completa
            dgvOrdenesEmitidas.ReadOnly = true;
            dgvOrdenesEmitidas.AllowUserToAddRows = false;
            dgvOrdenesEmitidas.AllowUserToDeleteRows = false;
            dgvOrdenesEmitidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenesEmitidas.MultiSelect = false;
            dgvOrdenesEmitidas.RowHeadersVisible = false;
            dgvOrdenesEmitidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 2. Ocultar todas las columnas por defecto
            foreach (DataGridViewColumn col in dgvOrdenesEmitidas.Columns)
            {
                col.Visible = false;
            }

            // 3. Agregar columna manual para el nombre del proveedor
            dgvOrdenesEmitidas.Columns.Add("ColProveedor", "Proveedor");

            // 4. Habilitar, ordenar y formatear solo lo necesario
            if (dgvOrdenesEmitidas.Columns.Contains("Id_OrdenCompra"))
            {
                var col = dgvOrdenesEmitidas.Columns["Id_OrdenCompra"];
                col.Visible = true;
                col.HeaderText = "N° Orden";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 65;
                col.DisplayIndex = 0;
            }

            var colProv = dgvOrdenesEmitidas.Columns["ColProveedor"];
            colProv.Visible = true;
            colProv.DisplayIndex = 1; // Ocupa el espacio restante automáticamente

            if (dgvOrdenesEmitidas.Columns.Contains("Fecha_Emision"))
            {
                var col = dgvOrdenesEmitidas.Columns["Fecha_Emision"];
                col.Visible = true;
                col.HeaderText = "Fecha Emisión";
                col.DefaultCellStyle.Format = "dd/MM/yyyy";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 90;
                col.DisplayIndex = 2;
            }

            // 5. Completar la Razón Social usando la lista ya cargada en cmbProveedores
            var proveedores = cmbProveedores.DataSource as List<BE.PROVEEDOR_INSUMO>;
            foreach (DataGridViewRow row in dgvOrdenesEmitidas.Rows)
            {
                if (row.DataBoundItem is BE.ORDEN_COMPRA ord)
                {
                    var prov = proveedores?.FirstOrDefault(p => p.Id_Proveedor == ord.Id_Proveedor);
                    row.Cells["ColProveedor"].Value = prov != null ? prov.Razon_Social : $"Proveedor #{ord.Id_Proveedor}";
                }
            }
        }

        private void ActualizarEstadoControles()
        {
            cmbProveedores.Enabled = rbReasignar.Checked;
            if (rbAnular.Checked)
            {
                cmbProveedores.SelectedIndex = -1;
            }
        }

        private void dgvOrdenesEmitidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrdenesEmitidas.CurrentRow != null)
            {
                ordenSeleccionada = (BE.ORDEN_COMPRA)dgvOrdenesEmitidas.CurrentRow.DataBoundItem;

                if (ordenSeleccionada != null)
                {
                    dgvDetalleOrden.DataSource = null;
                    dgvDetalleOrden.Columns.Clear();
                    dgvDetalleOrden.DataSource = new BindingSource { DataSource = ordenSeleccionada.Detalles };
                    FormatearGrillaDetalle();
                }
            }
        }

        private void FormatearGrillaDetalle()
        {
            if (dgvDetalleOrden.Columns.Count == 0) return;

            // 1. Configuración de solo lectura y ajuste visual
            dgvDetalleOrden.ReadOnly = true;
            dgvDetalleOrden.AllowUserToAddRows = false;
            dgvDetalleOrden.AllowUserToDeleteRows = false;
            dgvDetalleOrden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleOrden.MultiSelect = false;
            dgvDetalleOrden.RowHeadersVisible = false;
            dgvDetalleOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 2. Ocultar todas las columnas por defecto (incluye Id_Insumo, Id_Detalle, etc.)
            foreach (DataGridViewColumn col in dgvDetalleOrden.Columns)
            {
                col.Visible = false;
            }

            // 3. Mostrar y ordenar solo Insumo y Cantidad Solicitada
            if (dgvDetalleOrden.Columns.Contains("Nombre_Insumo"))
            {
                var col = dgvDetalleOrden.Columns["Nombre_Insumo"];
                col.Visible = true;
                col.HeaderText = "Insumo";
                col.DisplayIndex = 0; // Ocupa el ancho restante para que no se corte el texto
            }

            if (dgvDetalleOrden.Columns.Contains("Cantidad_Solicitada"))
            {
                var col = dgvDetalleOrden.Columns["Cantidad_Solicitada"];
                col.Visible = true;
                col.HeaderText = "Cant. Solicitada";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 105;
                col.DisplayIndex = 1;
            }
        }

        private void rbAnular_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoControles();
        }

        private void rbReasignar_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoControles();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
   
            if (ordenSeleccionada == null)
            {
                MessageBox.Show("Seleccione una Orden de Compra de la grilla superior.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Debe ingresar el motivo de la anulación/reasignación para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string motivo = txtMotivo.Text.Trim();

            try
            {
                if (rbAnular.Checked)
                {

                    bllOrdenCompra.AnularOrdenCompra(ordenSeleccionada.Id_OrdenCompra, motivo);

                    MessageBox.Show("Orden de Compra anulada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbReasignar.Checked)
                {

                    if (cmbProveedores.SelectedItem == null)
                    {
                        MessageBox.Show("Debe seleccionar un proveedor distinto al original para reasignar orden de compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    BE.PROVEEDOR_INSUMO nuevoProveedor = (BE.PROVEEDOR_INSUMO)cmbProveedores.SelectedItem;

                    if (nuevoProveedor.Id_Proveedor == ordenSeleccionada.Id_Proveedor)
                    {
                        MessageBox.Show("Debe seleccionar un proveedor distinto al original para reasignar orden de compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    bllOrdenCompra.ReasignarOrdenCompra(ordenSeleccionada, nuevoProveedor.Id_Proveedor, motivo);

                    MessageBox.Show("Orden de Compra reasignada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la operación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void btnVolverAlMenu_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }

        }

        private void InicializarIdioma()
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);

            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;

            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);

            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo))
                this.Text = textoTitulo;

            if (CBXidiomas.Items.Count > 0)
            {
                CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            }
        }
        private void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido))
                    control.Text = textoTraducido;

                if (control.HasChildren)
                    TraducirControles(control.Controls, traducciones);
            }
        }
        private void CBXidiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBXidiomas.SelectedValue != null && int.TryParse(CBXidiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    var traducciones = GestorIdioma.ObtenerTraducciones(idIdioma);
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
                MessageBox.Show("Error al cambiar el idioma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAnularReasignarOrdenCompra_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
