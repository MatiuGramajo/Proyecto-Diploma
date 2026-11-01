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
    public partial class FrmAnularReasignarOrdenCompra : Form
    {
        private BLL.ORDEN_COMPRA bllOrdenCompra = new BLL.ORDEN_COMPRA();
        private BLL.PROVEEDOR_INSUMO bllProveedorInsumo = new BLL.PROVEEDOR_INSUMO();

        private List<BE.ORDEN_COMPRA> listaOrdenesEmitidas = new List<BE.ORDEN_COMPRA>();
        private BE.ORDEN_COMPRA ordenSeleccionada = null;
        public FrmAnularReasignarOrdenCompra()
        {
            InitializeComponent();
        }

        private void FrmAnularReasignarOrdenCompra_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            try
            {
                // Reset de controles
                rbAnular.Checked = true;
                txtMotivo.Text = string.Empty;
                ordenSeleccionada = null;

                // Carga de Proveedores para la reasignación
                cmbProveedores.DataSource = null;
                cmbProveedores.DataSource = bllProveedorInsumo.ListarProveedores();
                cmbProveedores.DisplayMember = "Razon_Social";
                cmbProveedores.ValueMember = "Id_Proveedor";
                cmbProveedores.SelectedIndex = -1;

                ActualizarEstadoControles();

                // Carga de Órdenes de Compra Emitidas
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
            dgvOrdenesEmitidas.DataSource = listaOrdenesEmitidas;

            FormatearGrillaOrdenes();

            dgvDetalleOrden.DataSource = null;
            ordenSeleccionada = null;
        }

        private void FormatearGrillaOrdenes()
        {
            if (dgvOrdenesEmitidas.Columns.Count == 0) return;

            if (dgvOrdenesEmitidas.Columns["Id_OrdenCompra"] != null) dgvOrdenesEmitidas.Columns["Id_OrdenCompra"].HeaderText = "N° Orden";
            if (dgvOrdenesEmitidas.Columns["Id_Proveedor"] != null) dgvOrdenesEmitidas.Columns["Id_Proveedor"].HeaderText = "Cód. Proveedor";
            if (dgvOrdenesEmitidas.Columns["Fecha_Emision"] != null) dgvOrdenesEmitidas.Columns["Fecha_Emision"].HeaderText = "Fecha Emisión";
            if (dgvOrdenesEmitidas.Columns["Estado"] != null) dgvOrdenesEmitidas.Columns["Estado"].HeaderText = "Estado";
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
                    dgvDetalleOrden.DataSource = ordenSeleccionada.Detalles;
                    FormatearGrillaDetalle();
                }
            }
        }

        private void FormatearGrillaDetalle()
        {
            if (dgvDetalleOrden.Columns.Count == 0) return;

            if (dgvDetalleOrden.Columns["Id_Detalle"] != null) dgvDetalleOrden.Columns["Id_Detalle"].Visible = false;
            if (dgvDetalleOrden.Columns["Id_OrdenCompra"] != null) dgvDetalleOrden.Columns["Id_OrdenCompra"].Visible = false;
            if (dgvDetalleOrden.Columns["Cantidad_Recibida"] != null) dgvDetalleOrden.Columns["Cantidad_Recibida"].Visible = false;

            if (dgvDetalleOrden.Columns["Nombre_Insumo"] != null) dgvDetalleOrden.Columns["Nombre_Insumo"].HeaderText = "Insumo";
            if (dgvDetalleOrden.Columns["Cantidad_Solicitada"] != null) dgvDetalleOrden.Columns["Cantidad_Solicitada"].HeaderText = "Cant. Solicitada";
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
            // Validar que se haya seleccionado una orden de la grilla
            if (ordenSeleccionada == null)
            {
                MessageBox.Show("Seleccione una Orden de Compra de la grilla superior.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar Flujo Alternativo 4.1: Motivo sin ingresar
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
                    // Invocación a BLL según Diagrama de Secuencia (Acción: Anular)
                    bllOrdenCompra.AnularOrdenCompra(ordenSeleccionada.Id_OrdenCompra, motivo);

                    MessageBox.Show("Orden de Compra anulada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbReasignar.Checked)
                {
                    // Validar Flujo Alternativo 4.1.1: Proveedor no seleccionado o igual al original
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

                    // Invocación a BLL según Diagrama de Secuencia (Acción: Reasignar)
                    bllOrdenCompra.ReasignarOrdenCompra(ordenSeleccionada, nuevoProveedor.Id_Proveedor, motivo);

                    MessageBox.Show("Orden de Compra reasignada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Refrescar pantalla tras procesar la orden
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
    }
}
