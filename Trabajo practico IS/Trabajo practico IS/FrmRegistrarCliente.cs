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
    public partial class FrmRegistrarCliente : Form, BE.IObserver
    {
        private BLL.CLIENTE gestorCliente = new BLL.CLIENTE();
        public BE.CLIENTE ClienteGenerado {  get; private set; }
        public FrmRegistrarCliente()
        {
            InitializeComponent();
        }

        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            ActualizarIdioma();
        }
        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
        }

        private void BtnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtdni.Text) ||
                    string.IsNullOrWhiteSpace(txttelefono.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
                {
                    MessageBox.Show("Faltan campos por completar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Limpiamos cualquier símbolo extra (incluso paréntesis y signos más)
                string dniLimpio = txtdni.Text.Replace(".", "").Replace(" ", "");
                string telLimpio = txttelefono.Text.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "");

                // 2. Evaluamos
                if (!int.TryParse(dniLimpio, out int dni) || !long.TryParse(telLimpio, out long telefonoLargo))
                {
                    MessageBox.Show("El DNI o el Telefono contienen caracteres invalidos o el número es demasiado grande.", "Validación de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BE.CLIENTE nuevoCliente = new BE.CLIENTE();
                nuevoCliente.Nombre_Completo = txtnombre.Text;
                nuevoCliente.Dni = dni;

                // 3. ASIGNAMOS DIRECTAMENTE EL LONG (Sin el (int) adelante)
                nuevoCliente.Telefono = telefonoLargo;

                nuevoCliente.Email = txtemail.Text;

                gestorCliente.Insertar(nuevoCliente);
                this.ClienteGenerado = nuevoCliente;

                MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmRegistrarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
