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
    public partial class FrmAsignarPersonal : Form
    {
        private BLL.RESERVA bllReserva = new BLL.RESERVA();
        private BLL.ASIGNACION_PERSONAL bllAsignacion = new BLL.ASIGNACION_PERSONAL();

        private BE.RESERVA reservaSeleccionada = null;
        private BE.DOTACION_DTO dtoDotacion = null;
        private List<BE.PERSONAL> listaPersonalDisponible = new List<BE.PERSONAL>();
        public FrmAsignarPersonal()
        {
            InitializeComponent();
        }

        private void FrmAsignarPersonal_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            try
            {
                LimpiarPantalla();
                CargarGrillaReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los eventos planificados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaReservas()
        {
            List<BE.RESERVA> listaReservas = bllReserva.ListarReservasPlanificadas()
                                                    .Where(r => r.Fecha_Evento.Date >= DateTime.Today)
                                                    .ToList();

            dgvReservas.DataSource = null;
            dgvReservas.DataSource = listaReservas;

            FormatearGrillaReservas();
        }

        private void FormatearGrillaReservas()
        {
            if (dgvReservas.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgvReservas.Columns)
            {
                col.Visible = false;
            }

            if (dgvReservas.Columns["Id_Reserva"] != null) dgvReservas.Columns["Id_Reserva"].Visible = true;
            if (dgvReservas.Columns["Fecha_Evento"] != null) dgvReservas.Columns["Fecha_Evento"].Visible = true;
            if (dgvReservas.Columns["Estado"] != null) dgvReservas.Columns["Estado"].Visible = true;

            dgvReservas.Columns["Id_Reserva"].HeaderText = "N° Reserva";
            dgvReservas.Columns["Fecha_Evento"].HeaderText = "Fecha Evento";
            dgvReservas.Columns["Estado"].HeaderText = "Estado";
        }

        private void LimpiarPantalla()
        {
            reservaSeleccionada = null;
            dtoDotacion = null;
            lblInvitadosInfo.Text = "Seleccione una reserva planificada...";
            lblRequerimientos.Text = "Dotación mínima requerida: -";
            dgvPersonalDisponible.DataSource = null;
            dgvPersonalDisponible.Columns.Clear();
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReservas.CurrentRow != null)
            {
                reservaSeleccionada = (BE.RESERVA)dgvReservas.CurrentRow.DataBoundItem;

                if (reservaSeleccionada != null)
                {
                    CargarDotacionYPersonal();
                }
            }
        }

        private void CargarDotacionYPersonal()
        {
            try
            {
                dtoDotacion = bllAsignacion.ObtenerDotacionYPersonalDisponible(reservaSeleccionada);
                listaPersonalDisponible = dtoDotacion.ListaPersonalDisponible;

                int invitados = reservaSeleccionada.PresupuestoAsociado != null ? reservaSeleccionada.PresupuestoAsociado.Cantidad_Invitados_Estimada : 0;
                string cliente = reservaSeleccionada.ClienteAsociado != null ? reservaSeleccionada.ClienteAsociado.Nombre_Completo : "Sin especificar";

                lblInvitadosInfo.Text = $"Evento N° {reservaSeleccionada.Id_Reserva} - Cliente: {cliente} | Fecha: {reservaSeleccionada.Fecha_Evento:dd/MM/yyyy} | Invitados: {invitados}";

                string resumenRequeridos = "Dotación mínima requerida: ";
                foreach (var req in dtoDotacion.DotacionesRequeridas)
                {
                    resumenRequeridos += $"[{req.Key}: {req.Value}]  ";
                }
                lblRequerimientos.Text = resumenRequeridos;

                CargarGrillaPersonal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la dotación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaPersonal()
        {
            dgvPersonalDisponible.DataSource = null;
            dgvPersonalDisponible.Columns.Clear();

            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn
            {
                Name = "Seleccionado",
                HeaderText = "Asignar",
                Width = 60
            };
            dgvPersonalDisponible.Columns.Add(colCheck);

            dgvPersonalDisponible.DataSource = listaPersonalDisponible;

            if (dgvPersonalDisponible.Columns["Id_Personal"] != null) dgvPersonalDisponible.Columns["Id_Personal"].Visible = false;
            if (dgvPersonalDisponible.Columns["Direccion"] != null) dgvPersonalDisponible.Columns["Direccion"].Visible = false;
            if (dgvPersonalDisponible.Columns["Email"] != null) dgvPersonalDisponible.Columns["Email"].Visible = false;
            if (dgvPersonalDisponible.Columns["Estado"] != null) dgvPersonalDisponible.Columns["Estado"].Visible = false;

            if (dgvPersonalDisponible.Columns["Dni"] != null) dgvPersonalDisponible.Columns["Dni"].HeaderText = "DNI";
            if (dgvPersonalDisponible.Columns["Apellido"] != null) dgvPersonalDisponible.Columns["Apellido"].HeaderText = "Apellido";
            if (dgvPersonalDisponible.Columns["Nombre"] != null) dgvPersonalDisponible.Columns["Nombre"].HeaderText = "Nombre";
            if (dgvPersonalDisponible.Columns["Categoria"] != null) dgvPersonalDisponible.Columns["Categoria"].HeaderText = "Categoría";
            if (dgvPersonalDisponible.Columns["Telefono"] != null) dgvPersonalDisponible.Columns["Telefono"].HeaderText = "Teléfono";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (reservaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una reserva planificada de la grilla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<BE.PERSONAL> personalSeleccionado = new List<BE.PERSONAL>();

            foreach (DataGridViewRow row in dgvPersonalDisponible.Rows)
            {
                bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionado"].Value);
                if (seleccionado)
                {
                    BE.PERSONAL p = (BE.PERSONAL)row.DataBoundItem;
                    personalSeleccionado.Add(p);
                }
            }

            try
            {
                bllAsignacion.GuardarAsignacion(
                    reservaSeleccionada.Id_Reserva,
                    personalSeleccionado,
                    dtoDotacion.DotacionesRequeridas
                );

                MessageBox.Show("Asignación de personal registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
