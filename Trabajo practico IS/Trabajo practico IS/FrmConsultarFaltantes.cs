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
    public partial class FrmConsultarFaltantes : Form,BE.IObserver
    {
        private BLL.REQUERIMIENTO bllRequerimiento = new BLL.REQUERIMIENTO();
        private BLL.RESERVA bllReserva = new BLL.RESERVA();
        private List<BE.REQUERIMIENTO_INSUMO> listaConsolidada = new List<BE.REQUERIMIENTO_INSUMO>();
        private List<BE.RESERVA> listaEventosPlanificados = new List<BE.RESERVA>();
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();

        public FrmConsultarFaltantes()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmConsultarFaltantes_Load(object sender, EventArgs e)
        {

            MostrarFormulario();
            InicializarIdioma();
        }

        private void MostrarFormulario()
        {
            rbFechas.Checked = true;

            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today.AddDays(60);

            ActualizarEstadoFiltros();

            dgvRequerimientos.DataSource = null;
            listaConsolidada.Clear();

            CargarGrillaEventosPlanificados();
        }

        private void CargarGrillaEventosPlanificados()
        {
            try
            {
                DateTime? fechaDesde = null;
                DateTime? fechaHasta = null;

                if (rbFechas.Checked)
                {
                    if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
                    {
                        MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    fechaDesde = dtpFechaDesde.Value.Date;
                    fechaHasta = dtpFechaHasta.Value.Date;
                }

                listaEventosPlanificados = bllReserva.ListarReservasPlanificadas(fechaDesde, fechaHasta);

                dgvEventosPlanificados.DataSource = null;
                dgvEventosPlanificados.Columns.Clear(); 
                dgvEventosPlanificados.DataSource = listaEventosPlanificados;

                FormatearGrillaEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar eventos planificados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrillaEventos()
        {
            if (dgvEventosPlanificados.Columns.Count == 0) return;

            dgvEventosPlanificados.ReadOnly = true;
            dgvEventosPlanificados.AllowUserToAddRows = false;
            dgvEventosPlanificados.AllowUserToDeleteRows = false;
            dgvEventosPlanificados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEventosPlanificados.MultiSelect = false;
            dgvEventosPlanificados.RowHeadersVisible = false;
            dgvEventosPlanificados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in dgvEventosPlanificados.Columns)
            {
                col.Visible = false;
            }

            dgvEventosPlanificados.Columns.Add("ColCliente", "Cliente");
            dgvEventosPlanificados.Columns.Add("ColEvento", "Tipo de Evento");

            if (dgvEventosPlanificados.Columns.Contains("Id_Reserva"))
            {
                var col = dgvEventosPlanificados.Columns["Id_Reserva"];
                col.Visible = true;
                col.HeaderText = "Nro.";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 45;
                col.DisplayIndex = 0;
            }

            var colCliente = dgvEventosPlanificados.Columns["ColCliente"];
            colCliente.Visible = true;
            colCliente.DisplayIndex = 1; 

            var colEvento = dgvEventosPlanificados.Columns["ColEvento"];
            colEvento.Visible = true;
            colEvento.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colEvento.Width = 115;
            colEvento.DisplayIndex = 2;

            if (dgvEventosPlanificados.Columns.Contains("Fecha_Evento"))
            {
                var col = dgvEventosPlanificados.Columns["Fecha_Evento"];
                col.Visible = true;
                col.HeaderText = "Fecha";
                col.DefaultCellStyle.Format = "dd/MM/yyyy";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 80;
                col.DisplayIndex = 3;
            }

            foreach (DataGridViewRow row in dgvEventosPlanificados.Rows)
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

        private void ActualizarEstadoFiltros()
        {
            dtpFechaDesde.Enabled = rbFechas.Checked;
            dtpFechaHasta.Enabled = rbFechas.Checked;

            dgvEventosPlanificados.Enabled = true;

            if (rbFechas.Checked)
            {
                dgvEventosPlanificados.ClearSelection();
            }
        }

        private void rbFechas_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoFiltros();
        }

        private void rbEvento_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoFiltros();
        }

        private void dgvEventosPlanificados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rbEvento.Checked = true;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarGrillaEventosPlanificados();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            int idReserva = 0;

            if (rbFechas.Checked)
            {
                if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fechaDesde = dtpFechaDesde.Value.Date;
                fechaHasta = dtpFechaHasta.Value.Date;
            }
            else if (rbEvento.Checked)
            {
                if (dgvEventosPlanificados.CurrentRow == null || dgvEventosPlanificados.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Seleccione un evento planificado de la grilla superior.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BE.RESERVA reservaSeleccionada = (BE.RESERVA)dgvEventosPlanificados.CurrentRow.DataBoundItem;
                idReserva = reservaSeleccionada.Id_Reserva;
            }

            try
            {
                listaConsolidada = bllRequerimiento.CalcularRequerimientos(fechaDesde, fechaHasta, idReserva);
                MostrarListaConsolidada();
            }
            catch (Exception ex)
            {
                dgvRequerimientos.DataSource = null;
                listaConsolidada.Clear();

                if (ex.Message.Contains("Sin eventos planificados"))
                {
                    MessageBox.Show("No se encontraron eventos planificados en el período seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ex.Message.Contains("Menu sin Recetario"))
                {
                    MessageBox.Show("Uno de los eventos seleccionados no tiene su recetario/menú asignado. Configure la composición del menú antes de calcular.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error inesperado al calcular los requerimientos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarListaConsolidada()
        {
            if (listaConsolidada == null || listaConsolidada.Count == 0)
            {
                dgvRequerimientos.DataSource = null;
                return;
            }

            var listaAmostrar = chkSoloFaltantes.Checked
                ? listaConsolidada.Where(i => i.Cantidad_Faltante > 0).ToList()
                : listaConsolidada;

            dgvRequerimientos.DataSource = null;
            dgvRequerimientos.DataSource = listaAmostrar;

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            if (dgvRequerimientos.Columns.Count == 0) return;

            dgvRequerimientos.ReadOnly = true;
            dgvRequerimientos.AllowUserToAddRows = false;
            dgvRequerimientos.AllowUserToDeleteRows = false;
            dgvRequerimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequerimientos.RowHeadersVisible = false;
            dgvRequerimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvRequerimientos.Columns.Contains("Id_Insumo"))
                dgvRequerimientos.Columns["Id_Insumo"].Visible = false;

            dgvRequerimientos.Columns["Nombre_Insumo"].HeaderText = "Insumo"; 

            dgvRequerimientos.Columns["Rubro"].HeaderText = "Rubro";
            dgvRequerimientos.Columns["Rubro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRequerimientos.Columns["Rubro"].Width = 75;

            dgvRequerimientos.Columns["Unidad_Medida"].HeaderText = "U. Med.";
            dgvRequerimientos.Columns["Unidad_Medida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRequerimientos.Columns["Unidad_Medida"].Width = 55;

            dgvRequerimientos.Columns["Cantidad_Requerida"].HeaderText = "Requerido";
            dgvRequerimientos.Columns["Cantidad_Requerida"].DefaultCellStyle.Format = "N2";
            dgvRequerimientos.Columns["Cantidad_Requerida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRequerimientos.Columns["Cantidad_Requerida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRequerimientos.Columns["Cantidad_Requerida"].Width = 70;

            dgvRequerimientos.Columns["Stock_Actual"].HeaderText = "Stock";
            dgvRequerimientos.Columns["Stock_Actual"].DefaultCellStyle.Format = "N2";
            dgvRequerimientos.Columns["Stock_Actual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRequerimientos.Columns["Stock_Actual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRequerimientos.Columns["Stock_Actual"].Width = 65;

            dgvRequerimientos.Columns["Cantidad_Faltante"].HeaderText = "Faltante";
            dgvRequerimientos.Columns["Cantidad_Faltante"].DefaultCellStyle.Format = "N2";
            dgvRequerimientos.Columns["Cantidad_Faltante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRequerimientos.Columns["Cantidad_Faltante"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRequerimientos.Columns["Cantidad_Faltante"].Width = 65;

            dgvRequerimientos.Columns["Estado_Stock"].HeaderText = "Estado";
            dgvRequerimientos.Columns["Estado_Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRequerimientos.Columns["Estado_Stock"].Width = 75;

            foreach (DataGridViewRow row in dgvRequerimientos.Rows)
            {
                if (row.DataBoundItem is BE.REQUERIMIENTO_INSUMO item)
                {
                    if (item.Cantidad_Faltante > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }

            dgvRequerimientos.ClearSelection();
        }

        private void chkSoloFaltantes_CheckedChanged(object sender, EventArgs e)
        {
            MostrarListaConsolidada();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MostrarFormulario();
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

        private void FrmConsultarFaltantes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
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
    }

}
