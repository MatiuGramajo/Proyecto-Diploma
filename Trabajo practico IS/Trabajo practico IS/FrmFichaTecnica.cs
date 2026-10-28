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
    public partial class FrmFichaTecnica : Form
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BLL.SERVICIO_CATERING gestorCatering = new BLL.SERVICIO_CATERING();
        private BLL.PRESTADOR_SERVICIO gestorProveedor = new BLL.PRESTADOR_SERVICIO();
        private BLL.FICHA_TECNICA gestorFicha = new BLL.FICHA_TECNICA();
        private BE.RESERVA reservaSeleccionada;
        private bool cambiandoSeleccionInterna = false;
        public FrmFichaTecnica()
        {
            InitializeComponent();
        }

        private void FrmFichaTecnica_Load(object sender, EventArgs e)
        {
            CargarEventosReservados();
            DeshabilitarSeccionPlanificacion();
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
                if (dataGridView1.Columns["ClienteAsociado"] != null)
                    dataGridView1.Columns["ClienteAsociado"].Visible = false;
                if (dataGridView1.Columns["PresupuestoAsociado"] != null)
                    dataGridView1.Columns["PresupuestoAsociado"].Visible = false;
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

            // Si la sección ya estaba activa y elegimos un evento DISTINTO
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

            // Asignación de la reserva y habilitación del botón
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
    }
}
