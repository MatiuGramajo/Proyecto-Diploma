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
    public partial class FrmPresupuesto : Form
    {
        private BLL.PRESUPUESTO gestorPresupuesto;
        private DateTime fechaSeleccionada;
        private decimal subtotalCalculado = 0;
        public FrmPresupuesto(DateTime fechaDelEvento)
        {
            InitializeComponent();
            this.fechaSeleccionada = fechaDelEvento;
            try
            {
                gestorPresupuesto = new BLL.PRESUPUESTO();
                CargarTiposDeEvento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al inicializar Presupuestos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiposDeEvento()
        {
            comboBox1.Items.Add("Casamiento");
            comboBox1.Items.Add("Cumpleaños de 15");
            comboBox1.Items.Add("Evento Corporativo");
            comboBox1.SelectedIndex = 0;
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox1.Text, out int cantidadInvitados))
                {
                    MessageBox.Show("Por favor, ingrese un número válido de invitados.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string tipoEvento = comboBox1.SelectedItem.ToString();
                subtotalCalculado = gestorPresupuesto.CalcularCotizacion(cantidadInvitados,tipoEvento);
                lblSubottal.Text = "$ " + subtotalCalculado.ToString("0.00");
                BtnGeneralCotizacionFormal.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BtnGeneralCotizacionFormal.Enabled = false;
                lblSubottal.Text = "$ 0.00";
            }
        }
    }
}
