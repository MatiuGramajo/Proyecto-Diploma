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
    public partial class FrmAsignarPersonal : Form, BE.IObserver
    {
        private BLL.RESERVA bllReserva = new BLL.RESERVA();
        private BLL.ASIGNACION_PERSONAL bllAsignacion = new BLL.ASIGNACION_PERSONAL();
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        private BE.RESERVA reservaSeleccionada = null;
        private BE.DOTACION_DTO dtoDotacion = null;
        private List<BE.PERSONAL> listaPersonalDisponible = new List<BE.PERSONAL>();
        public FrmAsignarPersonal()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmAsignarPersonal_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
            InicializarIdioma();
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

			dgvPersonalDisponible.ReadOnly = false;
			dgvPersonalDisponible.EditMode = DataGridViewEditMode.EditOnEnter;

			DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn
			{
				Name = "Seleccionado",
				HeaderText = "Asignar",
				Width = 60,
				ReadOnly = false
			};
			dgvPersonalDisponible.Columns.Add(colCheck);

			dgvPersonalDisponible.DataSource = listaPersonalDisponible;

			foreach (DataGridViewColumn col in dgvPersonalDisponible.Columns)
			{
				col.ReadOnly = (col.Name != "Seleccionado");
			}

			foreach (DataGridViewRow row in dgvPersonalDisponible.Rows)
			{
				row.Cells["Seleccionado"].Value = false;
			}

			dgvPersonalDisponible.CurrentCellDirtyStateChanged -= dgvPersonalDisponible_CurrentCellDirtyStateChanged;
			dgvPersonalDisponible.CurrentCellDirtyStateChanged += dgvPersonalDisponible_CurrentCellDirtyStateChanged;

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

        private void FrmAsignarPersonal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        private void dgvPersonalDisponible_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
			if (dgvPersonalDisponible.IsCurrentCellDirty)
			{
				dgvPersonalDisponible.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
    }
}
