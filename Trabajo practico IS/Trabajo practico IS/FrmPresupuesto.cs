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
        private BLL.CLIENTE gestorCliente = new BLL.CLIENTE();
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

        private void BtnGeneralCotizacionFormal_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxclientes.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un cliente antes de generar el presupuesto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BE.PRESUPUESTO nuevoPresupuesto = new BE.PRESUPUESTO();
                nuevoPresupuesto.Cantidad_Invitados_Estimada = int.Parse(textBox1.Text);
                nuevoPresupuesto.Tipo_Evento = comboBox1.SelectedItem.ToString();
                nuevoPresupuesto.Subtotal = subtotalCalculado;
                nuevoPresupuesto.Estado = "Pendiente";
                nuevoPresupuesto.Id_Cliente = Convert.ToInt32(cbxclientes.SelectedValue); 
                nuevoPresupuesto.Id_Usuario = 1;
                gestorPresupuesto.GuardarPresupuesto(nuevoPresupuesto);
                MessageBox.Show("Presupuesto realizado con éxito.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el presupuesto en el sistema: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNnuevoCliente_Click(object sender, EventArgs e)
        {
            using (FrmRegistrarCliente frmAlta = new FrmRegistrarCliente())
            {
                if (frmAlta.ShowDialog() == DialogResult.OK)
                {
                    CargarClientesEnCombo();
                    BE.CLIENTE clienteNuevo = frmAlta.ClienteGenerado;
                    if(clienteNuevo !=null)
                    {
                        cbxclientes.SelectedIndex = cbxclientes.FindStringExact(clienteNuevo.Nombre_Completo);
                    }
                    
                }
            }
        }

        private void FrmPresupuesto_Load(object sender, EventArgs e)
        {
            CargarTiposDeEvento();
            CargarClientesEnCombo();
        }

        private void CargarClientesEnCombo()
        {
            try
            {
                cbxclientes.DataSource = null;
                cbxclientes.DataSource = gestorCliente.Listar();
                cbxclientes.DisplayMember = "Nombre_Completo";
                cbxclientes.ValueMember = "Id_Cliente";
                cbxclientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
