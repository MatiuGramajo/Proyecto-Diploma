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
    public partial class FrmFichaTecnica : Form, BE.IObserver
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BLL.SERVICIO_CATERING gestorCatering = new BLL.SERVICIO_CATERING();
        private BLL.PRESTADOR_SERVICIO gestorProveedor = new BLL.PRESTADOR_SERVICIO();
        private BLL.FICHA_TECNICA gestorFicha = new BLL.FICHA_TECNICA();
        private BE.RESERVA reservaSeleccionada;
        private bool cambiandoSeleccionInterna = false;
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmFichaTecnica()
        {
            InitializeComponent();
        }

        private void FrmFichaTecnica_Load(object sender, EventArgs e)
        {
            CargarEventosReservados();
            DeshabilitarSeccionPlanificacion();
            InicializarIdioma();
        }

        private void CargarPrestadores()
        {
            try
            {
                CLBprestadores.Items.Clear();
                List<BE.PRESTADOR_SERVICIO> listaProv = gestorProveedor.Listar();
                foreach (var prov in listaProv)
                {
                    if (prov.Estado != null && prov.Estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                    {
                       CLBprestadores.Items.Add(prov);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
        }

        private void CargarCatering()
        {
            try
            {
                List<BE.SERVICIO_CATERING> listaCatering = gestorCatering.Listar();
                CBXcatering.DataSource = listaCatering;
                CBXcatering.DisplayMember = "Tipo_Menu";
                CBXcatering.ValueMember = "Id_Servicio";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las opciones de catering: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarEventosReservados()
        {
            try
            {
                List<BE.RESERVA> Lista = gestorReserva.ListarReservasConfirmadas();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Lista;

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

                    if (!dataGridView1.Columns.Contains("ColCliente"))
                        dataGridView1.Columns.Add("ColCliente", "Cliente");

                    if (!dataGridView1.Columns.Contains("ColEvento"))
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
                        col.Width = 85;
                        col.DisplayIndex = 3;
                    }

                    if (dataGridView1.Columns.Contains("Estado"))
                    {
                        var col = dataGridView1.Columns["Estado"];
                        col.Visible = true;
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 85;
                        col.DisplayIndex = 4;
                    }

                    if (dataGridView1.Columns.Contains("Monto_Senia"))
                    {
                        var col = dataGridView1.Columns["Monto_Senia"];
                        col.Visible = true;
                        col.HeaderText = "Seña Abonada";
                        col.DefaultCellStyle.Format = "C2";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 105;
                        col.DisplayIndex = 5;
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.DataBoundItem is BE.RESERVA res)
                        {
                            row.Cells["ColCliente"].Value = res.ClienteAsociado != null ? res.ClienteAsociado.Nombre_Completo : "Sin Asignar";
                            row.Cells["ColEvento"].Value = res.PresupuestoAsociado != null ? res.PresupuestoAsociado.Tipo_Evento : "Evento";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los eventos confirmados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeshabilitarSeccionPlanificacion()
        {
            reservaSeleccionada = null;
            GBplanificarevento.Enabled = false;
            BTNarrmarfichatecnica.Enabled = false;
            textBox1.Clear();
            CBXcatering.DataSource = null;
            CLBprestadores.Items.Clear();
            LBLnombre.Text = "-";
            LBLtipoevento.Text = "-";
            LBLseñapagada2.Text = "$ 0,00";
            LBLseñapagada.Text = "$ 0,00";
            ReseteosTotales();
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
            }
        }
        private void HabilitarSeccionPlanificacion()
        {
            GBplanificarevento.Enabled = true;
            textBox1.Focus();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null || cambiandoSeleccionInterna)
                return;

            BE.RESERVA nuevaSeleccion = (BE.RESERVA)dataGridView1.CurrentRow.DataBoundItem;

            if (GBplanificarevento.Enabled && reservaSeleccionada != null && nuevaSeleccion.Id_Reserva != reservaSeleccionada.Id_Reserva)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Actualmente se está armando la Ficha Técnica de otro evento.\n\n¿Desea descartar los datos cargados y seleccionar este nuevo evento?",
                    "Atención: Evento en proceso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    ReseleccionarFilaEnGrilla(reservaSeleccionada.Id_Reserva);
                    return;
                }
                else
                {
                    DeshabilitarSeccionPlanificacion();
                }
            }

            reservaSeleccionada = nuevaSeleccion;
            LBLseñapagada.Text = $"Seña Pagada: {reservaSeleccionada.Monto_Senia:C}";
            BTNarrmarfichatecnica.Enabled = true;
        }
        

        private void ReseleccionarFilaEnGrilla(int id_Reserva)
        {
            cambiandoSeleccionInterna = true;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.DataBoundItem is BE.RESERVA res && res.Id_Reserva==id_Reserva)
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[0];
                    break;
                }
            }
            cambiandoSeleccionInterna = false;
        }

        private void RecalcularTotales()
        {
            if(reservaSeleccionada==null || CBXcatering.SelectedItem==null)
            {
                ReseteosTotales();
                return;
            }
            if(!int.TryParse(textBox1.Text, out int invitados) || invitados <=0)
            {
                ReseteosTotales();
                return;
            }
            BE.SERVICIO_CATERING catering = (BE.SERVICIO_CATERING)CBXcatering.SelectedItem;
            decimal costoCatering = invitados * catering.Precio_Por_Persona;
            decimal costoPrestadores = 0;
            foreach(BE.PRESTADOR_SERVICIO prov in CLBprestadores.CheckedItems)
            {
                costoPrestadores += prov.Precio_Servicio;
            }
            decimal costoTotal = costoCatering + costoPrestadores;
            decimal saldo = costoTotal - reservaSeleccionada.Monto_Senia;
            LBLcostocaterring.Text = $"Costo Catering: {costoCatering:C}";
            LBLcostoprestadores.Text = $"Costo Prestadores: {costoPrestadores:C}";
            LBLcostototal.Text = $"Costo Total Real: {costoTotal:C}";
            LBLsaldopendiente.Text = $"Saldo Pendiente: {saldo:C}";
        }

        private void ReseteosTotales()
        {
            LBLcostocaterring.Text = "Costo Catering: $ 0,00";
            LBLcostoprestadores.Text = "Costo Prestadores: $ 0,00";
            LBLcostototal.Text = "Costo Total Real: $ 0,00";
            LBLsaldopendiente.Text = "Saldo Pendiente: $ 0,00";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotales();
        }

        private void CBXcatering_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularTotales();
        }

        private void CLBprestadores_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { RecalcularTotales(); });
        }

        private void BTNguardarficha_Click(object sender, EventArgs e)
        {
            try
            {
                if(reservaSeleccionada==null)
                {
                    MessageBox.Show("Por favor, seleccione un evento de la lista de reservas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if(string.IsNullOrEmpty(textBox1.Text) || !int.TryParse(textBox1.Text, out int cantidadInvitados) || cantidadInvitados <=0 || CBXcatering.SelectedItem==null)
                {
                    MessageBox.Show("Faltan campos por completar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                BE.FICHA_TECNICA nuevaFicha = new BE.FICHA_TECNICA();
                nuevaFicha.Id_Reserva = reservaSeleccionada.Id_Reserva;
                nuevaFicha.Id_Usuario = 1;
                nuevaFicha.Id_Servicio = ((BE.SERVICIO_CATERING)CBXcatering.SelectedItem).Id_Servicio;
                nuevaFicha.CateringAsociado = (BE.SERVICIO_CATERING)CBXcatering.SelectedItem;
                nuevaFicha.Cantidad_Invitados_Final = cantidadInvitados;
                nuevaFicha.Tipo_Evento = reservaSeleccionada.PresupuestoAsociado != null ? reservaSeleccionada.PresupuestoAsociado.Tipo_Evento : "Evento";
                nuevaFicha.ReservaAsociada = reservaSeleccionada;
                foreach(BE.PRESTADOR_SERVICIO prest in CLBprestadores.CheckedItems)
                {
                    nuevaFicha.PrestadoresAsignados.Add(prest);
                }
                gestorFicha.ConsolidarFicha(nuevaFicha);
                MessageBox.Show("Ficha guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarEventosReservados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la Ficha Técnica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            reservaSeleccionada = null;
            textBox1.Clear();
            CBXcatering.SelectedIndex = -1;
            LBLseñapagada.Text = "$ 0,00";
            ReseteosTotales();
            for (int i = 0; i < CLBprestadores.Items.Count; i++) 
            {
                CLBprestadores.SetItemChecked(i, false);
            }
        }

        private void BTNarrmarfichatecnica_Click(object sender, EventArgs e)
        {
            if(reservaSeleccionada==null)
            {
                MessageBox.Show("Por favor, selecciona un evento reservado de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cliente = reservaSeleccionada.ClienteAsociado != null ? reservaSeleccionada.ClienteAsociado.Nombre_Completo : "Cliente";
            string evento = reservaSeleccionada.PresupuestoAsociado != null ? reservaSeleccionada.PresupuestoAsociado.Tipo_Evento : "Evento";

            LBLnombre.Text = $"Cliente: {cliente}";
            LBLtipoevento.Text = $"Tipo Evento: {evento}";
            LBLseñapagada2.Text = $"Seña Pagada: {reservaSeleccionada.Monto_Senia:C}";
            CargarCatering();
            CargarPrestadores();
            HabilitarSeccionPlanificacion();
        }

        private void BTNvolverAlMenuPrincipal_Click(object sender, EventArgs e)
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
        private void FrmFichaTecnica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
