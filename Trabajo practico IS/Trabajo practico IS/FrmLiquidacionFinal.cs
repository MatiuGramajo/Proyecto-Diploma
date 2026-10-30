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
    public partial class FrmLiquidacionFinal : Form
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BE.RESERVA reservaSeleccionada;
        public FrmLiquidacionFinal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
                return;

            reservaSeleccionada = (BE.RESERVA)dataGridView1.CurrentRow.DataBoundItem;

            // Muestra los valores financieros formateados
            LBLcostototal.Text = $"Costo Total Real: {reservaSeleccionada.Costo_Total_Real:C}";
            LBLsenia.Text = $"Seña Pagada: {reservaSeleccionada.Monto_Senia:C}";
            LBLsaldopendiente.Text = $"Saldo Pendiente: {reservaSeleccionada.Saldo_Pendiente:C}";

            HabilitarCampos();
        }

        private void FrmLiquidacionFinal_Load(object sender, EventArgs e)
        {
            MostrarFormulario();

        }

        private void BTNconfirmarliquidacion_Click(object sender, EventArgs e)
        {
            if (reservaSeleccionada == null)
            {
                MessageBox.Show("Por favor, seleccione un evento de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- FLUJO ALTERNATIVO 5.1 DEL DIAGRAMA DE SECUENCIA ---
            if (CBXmetododepago.SelectedIndex == -1 || string.IsNullOrWhiteSpace(CBXmetododepago.Text))
            {
                MessageBox.Show("Primero seleccione un metodo de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string metodoPago = CBXmetododepago.Text;

                gestorReserva.RegistrarLiquidacion(reservaSeleccionada, metodoPago);

                MessageBox.Show("Evento saldado con exito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la liquidación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarFormulario()
        {
            CargarEventosPlanificados();
            DeshabilitarCampos();
        }

        private void DeshabilitarCampos()
        {
            reservaSeleccionada = null;

            CBXmetododepago.SelectedIndex = -1;
            CBXmetododepago.Enabled = false;
            BTNconfirmarliquidacion.Enabled = false;

            LBLcostototal.Text = "Costo Total Real: $ 0,00";
            LBLsenia.Text = "Seña Pagada: $ 0,00";
            LBLsaldopendiente.Text = "Saldo Pendiente: $ 0,00";

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
            }
        }

        private void HabilitarCampos()
        {
            CBXmetododepago.Enabled = true;
            BTNconfirmarliquidacion.Enabled = true;
        }
        private void CargarEventosPlanificados()
        {
            try
            {
                List<BE.RESERVA> lista = gestorReserva.ObtenerEventosPlanificados();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;

                // Ocultar objetos complejos en la grilla si no es necesario verlos
                if (dataGridView1.Columns["ClienteAsociado"] != null)
                    dataGridView1.Columns["ClienteAsociado"].Visible = false;
                if (dataGridView1.Columns["PresupuestoAsociado"] != null)
                    dataGridView1.Columns["PresupuestoAsociado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los eventos planificados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
