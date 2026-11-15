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
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmRegistrarCliente()
        {
            InitializeComponent();
        }

        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {
            InicializarIdioma();
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

                string dniLimpio = txtdni.Text.Replace(".", "").Replace(" ", "");
                string telLimpio = txttelefono.Text.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "");

                if (!int.TryParse(dniLimpio, out int dni) || !long.TryParse(telLimpio, out long telefonoLargo))
                {
                    MessageBox.Show("El DNI o el Telefono contienen caracteres invalidos o el número es demasiado grande.", "Validación de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BE.CLIENTE nuevoCliente = new BE.CLIENTE();
                nuevoCliente.Nombre_Completo = txtnombre.Text;
                nuevoCliente.Dni = dni;

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
        private void FrmRegistrarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
