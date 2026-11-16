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
    public partial class FrmRegistrarEvaluacion : Form, BE.IObserver
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BE.RESERVA reservaSeleccionada;
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmRegistrarEvaluacion()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
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
            InicializarIdioma();
        }

        private void LimpiarYDeshabilitarCampos()
        {
            reservaSeleccionada = null;

            lblClienteInfo.Text = "Nombre: -";
            lblFechaInfo.Text = "Fecha: -";
            lblTipoEventoInfo.Text = "Tipo de Evento: -";
            lblInvitadosInfo.Text = "Invitados: -";

            cmbResultado.SelectedIndex = -1;
            cmbResultado.Enabled = false;

            txtObservaciones.Clear();
            txtObservaciones.Enabled = false;

            btnGuardarEvaluacion.Enabled = false;

            dgvPersonal.DataSource = null;
            dgvPersonal.Columns.Clear();

            if (dgvEventos.Rows.Count > 0)
            {
                dgvEventos.ClearSelection();
            }
        }

        private void CargarEventosPendientes()
        {
            try
            {
                List<BE.RESERVA> listaPendientes = gestorReserva.ListarReservasPendientesEvaluacion();

                dgvEventos.DataSource = null;
                dgvEventos.Columns.Clear();
                dgvEventos.DataSource = new BindingSource { DataSource = listaPendientes };

                if (dgvEventos.Columns.Count > 0)
                {
                    dgvEventos.ReadOnly = true;
                    dgvEventos.AllowUserToAddRows = false;
                    dgvEventos.AllowUserToDeleteRows = false;
                    dgvEventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEventos.MultiSelect = false;
                    dgvEventos.RowHeadersVisible = false;
                    dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    foreach (DataGridViewColumn col in dgvEventos.Columns)
                        col.Visible = false;

                    dgvEventos.Columns.Add("ColCliente", "Cliente");
                    dgvEventos.Columns.Add("ColEvento", "Tipo de Evento");

                    if (dgvEventos.Columns.Contains("Id_Reserva"))
                    {
                        var col = dgvEventos.Columns["Id_Reserva"];
                        col.Visible = true;
                        col.HeaderText = "Nro.";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 45;
                        col.DisplayIndex = 0;
                    }

                    var colCliente = dgvEventos.Columns["ColCliente"];
                    colCliente.Visible = true;
                    colCliente.DisplayIndex = 1; 

                    var colEvento = dgvEventos.Columns["ColEvento"];
                    colEvento.Visible = true;
                    colEvento.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    colEvento.Width = 105;
                    colEvento.DisplayIndex = 2;

                    if (dgvEventos.Columns.Contains("Fecha_Evento"))
                    {
                        var col = dgvEventos.Columns["Fecha_Evento"];
                        col.Visible = true;
                        col.HeaderText = "Fecha";
                        col.DefaultCellStyle.Format = "dd/MM/yyyy";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 80;
                        col.DisplayIndex = 3;
                    }

                    foreach (DataGridViewRow row in dgvEventos.Rows)
                    {
                        if (row.DataBoundItem is BE.RESERVA res)
                        {
                            row.Cells["ColCliente"].Value = res.ClienteAsociado != null
                                ? res.ClienteAsociado.Nombre_Completo
                                : $"Cliente #{res.Id_Cliente}";

                            row.Cells["ColEvento"].Value = res.PresupuestoAsociado != null
                                ? res.PresupuestoAsociado.Tipo_Evento
                                : "Evento";
                        }
                    }
                }
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

            lblClienteInfo.Text = $"Nombre: {reservaSeleccionada.ClienteAsociado?.Nombre_Completo ?? "N/A"}";
            lblFechaInfo.Text = $"Fecha: {reservaSeleccionada.Fecha_Evento:dd/MM/yyyy}";
            lblTipoEventoInfo.Text = $"Tipo de Evento: {reservaSeleccionada.PresupuestoAsociado?.Tipo_Evento ?? "N/A"}";
            lblInvitadosInfo.Text = $"Invitados: {reservaSeleccionada.PresupuestoAsociado?.Cantidad_Invitados_Estimada ?? 0}";

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
                dgvPersonal.Columns.Clear();
                dgvPersonal.DataSource = new BindingSource { DataSource = personalAsignado };

                if (dgvPersonal.Columns.Count > 0)
                {
                    dgvPersonal.ReadOnly = true;
                    dgvPersonal.AllowUserToAddRows = false;
                    dgvPersonal.AllowUserToDeleteRows = false;
                    dgvPersonal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPersonal.MultiSelect = false;
                    dgvPersonal.RowHeadersVisible = false;
                    dgvPersonal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    foreach (DataGridViewColumn col in dgvPersonal.Columns)
                        col.Visible = false;

                    if (dgvPersonal.Columns.Contains("Nombre"))
                    {
                        var col = dgvPersonal.Columns["Nombre"];
                        col.Visible = true;
                        col.HeaderText = "Nombre";
                        col.DisplayIndex = 0;
                    }

                    if (dgvPersonal.Columns.Contains("Apellido"))
                    {
                        var col = dgvPersonal.Columns["Apellido"];
                        col.Visible = true;
                        col.HeaderText = "Apellido";
                        col.DisplayIndex = 1;
                    }

                    if (dgvPersonal.Columns.Contains("Dni"))
                    {
                        var col = dgvPersonal.Columns["Dni"];
                        col.Visible = true;
                        col.HeaderText = "DNI";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 75;
                        col.DisplayIndex = 2;
                    }

                    if (dgvPersonal.Columns.Contains("Categoria"))
                    {
                        var col = dgvPersonal.Columns["Categoria"];
                        col.Visible = true;
                        col.HeaderText = "Categoría";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 95;
                        col.DisplayIndex = 3;
                    }
                }
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

                gestorReserva.GuardarReservaEvaluacion(reservaSeleccionada);

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

        private void FrmRegistrarEvaluacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
    
}
