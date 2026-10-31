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
    public partial class FrmGestionProveedorInsumo : Form
    {
        private BLL.PROVEEDOR_INSUMO gestorProveedor = new BLL.PROVEEDOR_INSUMO();
        private BE.PROVEEDOR_INSUMO proveedorSeleccionado = null;
        public FrmGestionProveedorInsumo()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
                return;

            proveedorSeleccionado = (BE.PROVEEDOR_INSUMO)dataGridView1.CurrentRow.DataBoundItem;

            txtRazonSocial.Text = proveedorSeleccionado.Razon_Social;
            txtCUIT.Text = proveedorSeleccionado.Cuit;
            txtRubro.Text = proveedorSeleccionado.Rubro;
            txtTelefono.Text = proveedorSeleccionado.Telefono;
            txtDireccion.Text = proveedorSeleccionado.Direccion;
            txtEmail.Text = proveedorSeleccionado.Email;
            cbxEstado.SelectedItem = proveedorSeleccionado.Estado;

            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnBaja.Enabled = true;

        }

        private void FrmGestionProveedorInsumo_Load(object sender, EventArgs e)
        {
            cbxEstado.Items.Clear();
            cbxEstado.Items.Add("Activo");
            cbxEstado.Items.Add("Inactivo");
            cbxEstado.SelectedIndex = 0;
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            CargarProveedores();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            proveedorSeleccionado = null;

            txtRazonSocial.Clear();
            txtCUIT.Clear();
            txtRubro.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            cbxEstado.SelectedIndex = 0;

            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnBaja.Enabled = false;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
            }
        }

        private void CargarProveedores()
        {
            try
            {
                List<BE.PROVEEDOR_INSUMO> lista = gestorProveedor.ListarProveedores();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesarGuardado(esNuevo: true);
        }

        private void ProcesarGuardado(bool esNuevo)
        {
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text) || string.IsNullOrWhiteSpace(txtCUIT.Text))
            {
                MessageBox.Show("Faltan campos obligatorios por completar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BE.PROVEEDOR_INSUMO prov = esNuevo ? new BE.PROVEEDOR_INSUMO() : proveedorSeleccionado;

                prov.Razon_Social = txtRazonSocial.Text.Trim();
                prov.Cuit = txtCUIT.Text.Trim();
                prov.Rubro = txtRubro.Text.Trim();
                prov.Telefono = txtTelefono.Text.Trim();
                prov.Direccion = txtDireccion.Text.Trim();
                prov.Email = txtEmail.Text.Trim();
                prov.Estado = cbxEstado.SelectedItem.ToString();

                gestorProveedor.Guardar(prov);

                string mensaje = esNuevo ? "Proveedor registrado con éxito." : "Datos del proveedor actualizados con éxito.";
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("CUIT DUPLICADO"))
                {
                    MessageBox.Show("Ya existe un proveedor registrado con el CUIT ingresado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al guardar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un proveedor de la grilla para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcesarGuardado(esNuevo: false);
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un proveedor de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string accion = proveedorSeleccionado.Estado == "Activo" ? "desactivar" : "activar";
                DialogResult dr = MessageBox.Show($"¿Está seguro de que desea {accion} al proveedor '{proveedorSeleccionado.Razon_Social}'?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    gestorProveedor.CambiarEstado(proveedorSeleccionado);
                    MessageBox.Show("Estado del proveedor actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado del proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
