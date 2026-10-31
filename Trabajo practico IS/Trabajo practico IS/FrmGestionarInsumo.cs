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
    public partial class FrmGestionarInsumo : Form
    {
        private BLL.INSUMO gestorInsumo = new BLL.INSUMO();
        private BE.INSUMO insumoSeleccionado = null;
        public FrmGestionarInsumo()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
                return;

            insumoSeleccionado = (BE.INSUMO)dataGridView1.CurrentRow.DataBoundItem;

            txtNombre.Text = insumoSeleccionado.Nombre;
            txtRubro.Text = insumoSeleccionado.Rubro;
            txtUnidadMedida.Text = insumoSeleccionado.Unidad_Medida;

            // Formato de texto para los TextBox de stock
            txtStockActual.Text = insumoSeleccionado.Stock_Actual.ToString("0.00");
            txtStockMinimo.Text = insumoSeleccionado.Stock_Minimo.ToString("0.00");

            cbxEstado.SelectedItem = insumoSeleccionado.Estado;

            btnGuardar.Enabled = false;
            btnModificar.Enabled = true;
            btnBaja.Enabled = true;
        }

        private void FrmGestionarInsumo_Load(object sender, EventArgs e)
        {
            cbxEstado.Items.Clear();
            cbxEstado.Items.Add("Activo");
            cbxEstado.Items.Add("Inactivo");
            cbxEstado.SelectedIndex = 0;

            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            CargarInsumos();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            insumoSeleccionado = null;

            txtNombre.Clear();
            txtRubro.Clear();
            txtUnidadMedida.Clear();
            cbxEstado.SelectedIndex = 0;
            txtStockActual.Clear();
            txtStockMinimo.Clear();
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnBaja.Enabled = false;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
            }
        }

        private void CargarInsumos()
        {
            try
            {
                List<BE.INSUMO> lista = gestorInsumo.ListarInsumos();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesarGuardado(esNuevo: true);
        }

        private void ProcesarGuardado(bool esNuevo)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUnidadMedida.Text))
            {
                MessageBox.Show("Faltan campos por completar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtStockActual.Text.Trim(), out decimal stockActual))
            {
                MessageBox.Show("El Stock Actual debe ser un número válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtStockMinimo.Text.Trim(), out decimal stockMinimo))
            {
                MessageBox.Show("El Stock Mínimo debe ser un número válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                BE.INSUMO insumo = esNuevo ? new BE.INSUMO() : insumoSeleccionado;

                insumo.Nombre = txtNombre.Text.Trim();
                insumo.Rubro = txtRubro.Text.Trim();
                insumo.Unidad_Medida = txtUnidadMedida.Text.Trim();
                insumo.Stock_Actual = stockActual;
                insumo.Stock_Minimo = stockMinimo;
                insumo.Estado = cbxEstado.SelectedItem.ToString();

                gestorInsumo.Guardar(insumo);

                MessageBox.Show("Insumo registrado con exito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Nombre Duplicado"))
                {
                    MessageBox.Show("Ya existe un insumo registrado con el nombre ingresado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al guardar el insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (insumoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un insumo de la grilla para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcesarGuardado(esNuevo: false);
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (insumoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un insumo de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string accion = insumoSeleccionado.Estado == "Activo" ? "desactivar" : "activar";
                DialogResult dr = MessageBox.Show($"¿Está seguro de que desea {accion} el insumo '{insumoSeleccionado.Nombre}'?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    gestorInsumo.CambiarEstado(insumoSeleccionado);
                    MessageBox.Show("Estado del insumo actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado del insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
