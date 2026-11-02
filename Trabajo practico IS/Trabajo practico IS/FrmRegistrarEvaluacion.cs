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
    public partial class FrmRegistrarEvaluacion : Form
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BE.RESERVA reservaSeleccionada;
        public FrmRegistrarEvaluacion()
        {
            InitializeComponent();
        }

        private void FrmRegistrarEvaluacion_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            CargarComboResultado();
            CargarEventosPendientes();
            LimpiarYDeshabilitarCampos();
        }

        private void LimpiarYDeshabilitarCampos()
        {
            reservaSeleccionada = null;

            lblClienteInfo.Text = "-";
            lblFechaInfo.Text = "-";
            lblTipoEventoInfo.Text = "-";
            lblInvitadosInfo.Text = "-";

            cmbResultado.SelectedIndex = -1;
            cmbResultado.Enabled = false;

            txtObservaciones.Clear();
            txtObservaciones.Enabled = false;

            btnGuardarEvaluacion.Enabled = false;

            dgvPersonal.DataSource = null;

            if (dgvEventos.Rows.Count > 0)
            {
                dgvEventos.ClearSelection();
            }
        }

        private void CargarEventosPendientes()
        {
            try
            {
                List<BE.RESERVA> listaPendientes = gestorReserva.ListarPendientesEvaluacion();

                dgvEventos.DataSource = null;
                dgvEventos.DataSource = listaPendientes;

                if (dgvEventos.Columns["ClienteAsociado"] != null)
                    dgvEventos.Columns["ClienteAsociado"].Visible = false;
                if (dgvEventos.Columns["PresupuestoAsociado"] != null)
                    dgvEventos.Columns["PresupuestoAsociado"].Visible = false;
                if (dgvEventos.Columns["Evaluacion_Personal"] != null)
                    dgvEventos.Columns["Evaluacion_Personal"].Visible = false;
                if (dgvEventos.Columns["Observaciones_Personal"] != null)
                    dgvEventos.Columns["Observaciones_Personal"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los eventos pendientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HabilitarCampos()
        {
            cmbResultado.Enabled = true;
            txtObservaciones.Enabled = true;
            btnGuardarEvaluacion.Enabled = true;
        }

        private void dgvEventos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvEventos.CurrentRow == null)
                return;

            reservaSeleccionada = (BE.RESERVA)dgvEventos.CurrentRow.DataBoundItem;

            lblClienteInfo.Text = reservaSeleccionada.ClienteAsociado?.Nombre_Completo ?? "N/A";
            lblFechaInfo.Text = reservaSeleccionada.Fecha_Evento.ToShortDateString();
            lblTipoEventoInfo.Text = reservaSeleccionada.PresupuestoAsociado?.Tipo_Evento ?? "N/A";
            lblInvitadosInfo.Text = reservaSeleccionada.PresupuestoAsociado?.Cantidad_Invitados_Estimada.ToString() ?? "0";

            CargarPersonalAsignado(reservaSeleccionada.Id_Reserva);

            HabilitarCampos();
        }
        private void CargarComboResultado()
        {
            cmbResultado.Items.Clear();
            cmbResultado.Items.Add("Aprobado");
            cmbResultado.Items.Add("No Aprobado");
        }
        private void CargarPersonalAsignado(int id_Reserva)
        {
            try
            {
                List<BE.PERSONAL> personalAsignado = gestorReserva.ObtenerPersonalAsignado(id_Reserva);
                dgvPersonal.DataSource = null;
                dgvPersonal.DataSource = personalAsignado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la nómina de personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarEvaluacion_Click(object sender, EventArgs e)
        {
            if (reservaSeleccionada == null)
            {
                MessageBox.Show("Por favor, seleccione una reserva de la grilla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbResultado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbResultado.Text))
            {
                MessageBox.Show("Debe seleccionar un resultado de evaluación antes de guardarlo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                reservaSeleccionada.Evaluacion_Personal = cmbResultado.Text.Equals("Aprobado", StringComparison.OrdinalIgnoreCase) ? 1 : 0;
                reservaSeleccionada.Observaciones_Personal = txtObservaciones.Text.Trim();

                gestorReserva.GuardarEvaluacion(reservaSeleccionada);

                MessageBox.Show("Evaluación registrada y evento finalizado con exito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la evaluación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
