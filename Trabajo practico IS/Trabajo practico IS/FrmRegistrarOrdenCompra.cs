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
    public partial class FrmRegistrarOrdenCompra : Form
    {
        private BLL.PROVEEDOR_INSUMO bllProveedorInsumo = new BLL.PROVEEDOR_INSUMO();
        private BLL.INSUMO bllInsumo = new BLL.INSUMO();
        private BLL.ORDEN_COMPRA bllOrdenCompra = new BLL.ORDEN_COMPRA();

        private List<BE.DETALLE_ORDEN_COMPRA> listaDetalles = new List<BE.DETALLE_ORDEN_COMPRA>();
        public FrmRegistrarOrdenCompra()
        {
            InitializeComponent();
        }

        private void FrmRegistrarOrdenCompra_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            try
            {
                cmbProveedores.DataSource = null;
                cmbProveedores.DataSource = bllProveedorInsumo.ListarProveedores();
                cmbProveedores.DisplayMember = "Razon_Social";
                cmbProveedores.ValueMember = "Id_Proveedor";
                cmbProveedores.SelectedIndex = -1;

                cmbInsumos.DataSource = null;
                cmbInsumos.DataSource = bllInsumo.ListarInsumos();
                cmbInsumos.DisplayMember = "Nombre";
                cmbInsumos.ValueMember = "Id_Insumo";
                cmbInsumos.SelectedIndex = -1;

                listaDetalles.Clear();
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la pantalla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrilla()
        {
            if (dgvDetalle.Columns.Count == 0) return;

            if (dgvDetalle.Columns["Id_Detalle"] != null) dgvDetalle.Columns["Id_Detalle"].Visible = false;
            if (dgvDetalle.Columns["Id_Orden"] != null) dgvDetalle.Columns["Id_Orden"].Visible = false;
            if (dgvDetalle.Columns["Id_OrdenCompra"] != null) dgvDetalle.Columns["Id_OrdenCompra"].Visible = false;
            if (dgvDetalle.Columns["Cantidad_Recibida"] != null) dgvDetalle.Columns["Cantidad_Recibida"].Visible = false;

            if (dgvDetalle.Columns["Id_Insumo"] != null) dgvDetalle.Columns["Id_Insumo"].HeaderText = "Cód. Insumo";
            if (dgvDetalle.Columns["Nombre_Insumo"] != null) dgvDetalle.Columns["Nombre_Insumo"].HeaderText = "Insumo";
            if (dgvDetalle.Columns["Cantidad_Solicitada"] != null) dgvDetalle.Columns["Cantidad_Solicitada"].HeaderText = "Cant. Solicitada";
        }
        private void ActualizarGrilla()
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = listaDetalles;
            FormatearGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbInsumos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un insumo del catálogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad numérica válida mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BE.INSUMO insumoSeleccionado = (BE.INSUMO)cmbInsumos.SelectedItem;

            BE.DETALLE_ORDEN_COMPRA existente = listaDetalles.FirstOrDefault(d => d.Id_Insumo == insumoSeleccionado.Id_Insumo);
            if (existente != null)
            {
                existente.Cantidad_Solicitada += cantidad;
            }
            else
            {
                listaDetalles.Add(new BE.DETALLE_ORDEN_COMPRA
                {
                    Id_Insumo = insumoSeleccionado.Id_Insumo,
                    Nombre_Insumo = insumoSeleccionado.Nombre,
                    Cantidad_Solicitada = cantidad,
                    Cantidad_Recibida = 0 
                });
            }

            txtCantidad.Text = ""; 
            cmbInsumos.SelectedIndex = -1; 
            ActualizarGrilla();
        }

        private void btnEmitirOrden_Click(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor para emitir la Orden de Compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listaDetalles == null || listaDetalles.Count == 0 || listaDetalles.Any(d => d.Cantidad_Solicitada <= 0))
            {
                MessageBox.Show("Ingrese al menos un insumo con cantidad valida mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BE.PROVEEDOR_INSUMO prov = (BE.PROVEEDOR_INSUMO)cmbProveedores.SelectedItem;

                BE.ORDEN_COMPRA nuevaOrden = new BE.ORDEN_COMPRA
                {
                    Id_Proveedor = prov.Id_Proveedor,
                    Detalles = listaDetalles
                };

                bllOrdenCompra.RegistrarOrdenCompra(nuevaOrden);

                MessageBox.Show("Orden de Compra emitida con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al emitir la Orden de Compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolverAlMenuPrincipal_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}
