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
    public partial class FrmCalendario : Form
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        public FrmCalendario()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fechaSolicitada = monthCalendar1.SelectionStart.Date;

                if(fechaSolicitada< DateTime.Now.Date)
                {
                    MessageBox.Show("Por favor, seleccione una fecha futura para la reserva.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                bool estaDisponible = gestorReserva.ConsultarDisponibilidad(fechaSolicitada);
                if (!estaDisponible)
                {
                    List<DateTime> alternativas = gestorReserva.ConsultarFechasCercanas(fechaSolicitada);
                    ResaltarFecha(fechaSolicitada, false);
                    CargarFechas(alternativas);
                    BtnIniciarPresupuesto.Enabled = false;
                    MessageBox.Show("La fecha solicitada se encuentra ocupada. Hemos cargado fechas alternativas en la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ResaltarFecha(fechaSolicitada, true);
                    HabilitarBotonPresupuesto();
                    listBox1.DataSource = null;
                    MessageBox.Show("¡La fecha está libre! Ya puede iniciar el presupuesto.", "Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la consulta: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);   }


        }

        private void ResaltarFecha(DateTime fechaSolicitada, bool libre)
        {
            try
            {
                monthCalendar1.RemoveAllBoldedDates();
                monthCalendar1.AddBoldedDate(fechaSolicitada);
                monthCalendar1.UpdateBoldedDates();
                if (libre)
                {
                    monthCalendar1.TitleBackColor = Color.Green;

                }
                else
                {
                    monthCalendar1.TitleBackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error visual al resaltar el calendario: " + ex.Message, "Error Menor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void CargarFechas(List<DateTime> fechasAlternativas)
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DataSource = fechasAlternativas;
                listBox1.FormatString = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de alternativas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HabilitarBotonPresupuesto()
        {
            BtnIniciarPresupuesto.Enabled = true;
        }

        private void BtnIniciarPresupuesto_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaValidada = monthCalendar1.SelectionStart.Date;
                FrmPresupuesto frmpresupuesto = new FrmPresupuesto(fechaValidada);
                frmpresupuesto.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo iniciar el presupuesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
