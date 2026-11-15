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
    public partial class FrmLiquidacionFinal : Form,BE.IObserver
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BE.RESERVA reservaSeleccionada;
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmLiquidacionFinal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
                return;

            reservaSeleccionada = (BE.RESERVA)dataGridView1.CurrentRow.DataBoundItem;

            LBLcostototal.Text = $"Costo Total Real: {reservaSeleccionada.Costo_Total_Real:C}";
            LBLsenia.Text = $"Seña Pagada: {reservaSeleccionada.Monto_Senia:C}";
            LBLsaldopendiente.Text = $"Saldo Pendiente: {reservaSeleccionada.Saldo_Pendiente:C}";

            HabilitarCampos();
        }

        private void FrmLiquidacionFinal_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
            InicializarIdioma();

        }

        private void BTNconfirmarliquidacion_Click(object sender, EventArgs e)
        {
            if (reservaSeleccionada == null)
            {
                MessageBox.Show("Por favor, seleccione un evento de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                List<BE.RESERVA> lista = gestorReserva.ListarReservasPlanificadas();

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = lista;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.Visible = false;
                    }

                    dataGridView1.Columns.Add("ColCliente", "Cliente");
                    dataGridView1.Columns.Add("ColEvento", "Tipo de Evento");

                    if (dataGridView1.Columns.Contains("Id_Reserva"))
                    {
                        var col = dataGridView1.Columns["Id_Reserva"];
                        col.Visible = true;
                        col.HeaderText = "Nro.";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 50;
                        col.DisplayIndex = 0;
                    }

                    var colCliente = dataGridView1.Columns["ColCliente"];
                    colCliente.Visible = true;
                    colCliente.DisplayIndex = 1;

                    var colEvento = dataGridView1.Columns["ColEvento"];
                    colEvento.Visible = true;
                    colEvento.DisplayIndex = 2;

                    if (dataGridView1.Columns.Contains("Fecha_Evento"))
                    {
                        var col = dataGridView1.Columns["Fecha_Evento"];
                        col.Visible = true;
                        col.HeaderText = "Fecha";
                        col.DefaultCellStyle.Format = "dd/MM/yyyy";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 90;
                        col.DisplayIndex = 3;
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
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
                MessageBox.Show("Error al cargar los eventos planificados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNvolveralmenuprincipal_Click(object sender, EventArgs e)
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

        private void FrmLiquidacionFinal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
