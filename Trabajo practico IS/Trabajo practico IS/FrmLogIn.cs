using BLL;
using Servicios;
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
    public partial class FrmLogIn : Form, BE.IObserver
    {

        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        private bool idiomaCambiadoManualmente = false;
        public FrmLogIn()
        {
            InitializeComponent();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (CBXIdiomas.Items.Count > 0)
            {
                CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
                CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            }

        }

        private void BTN_IniciarSesion_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtBoxUsuario.Text) || string.IsNullOrWhiteSpace(TxtBoxPassword.Text))
                    throw new Exception("Debe completar todos los campos");

                GestorUsuario.LogIn(TxtBoxUsuario.Text, TxtBoxPassword.Text);
                int idIdiomaFinalAAplicar = idiomaCambiadoManualmente ? Convert.ToInt32(CBXIdiomas.SelectedValue) : Servicios.SESION.GetInstancia().usuactual.IdIdioma;

                if (idiomaCambiadoManualmente)
                {
                    GestorUsuario.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdiomaFinalAAplicar);
                    Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdiomaFinalAAplicar;
                }
                var traduccionesUsuario = GestorIdioma.ObtenerTraducciones(idIdiomaFinalAAplicar);
                Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaFinalAAplicar, traduccionesUsuario);

                this.DialogResult = DialogResult.OK;
                this.Hide();

                FrmMenuPrincipal frmMenu = new FrmMenuPrincipal();
                frmMenu.ShowDialog();

                ProcesarPostLogout();
            }
            catch (Servicios.Excepciones.IntegridadDatosException ex)
            {
                ManejarFallaIntegridad(ex);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TxtBoxUsuario.Text = "";
                TxtBoxPassword.Text = "";
            }
        }

        private void ManejarFallaIntegridad(Servicios.Excepciones.IntegridadDatosException ex)
        {
            var usuActual = Servicios.SESION.GetInstancia().usuactual;
            bool puedeRestaurarBD = false;

            if (usuActual != null && usuActual.Permisos != null)
            {
                foreach (var permiso in usuActual.Permisos)
                {
                    if (permiso.TienePermiso("RESTAURACION_BASE"))
                    {
                        puedeRestaurarBD = true;
                        break;
                    }
                }
            }

            string msjError = $"¡ALERTA CRÍTICA DE SEGURIDAD!\n\n" +
                      $"Tabla Corrupta: {ex.TablaCorrupta}\n" +
                      $"Registro Afectado: {ex.RegistroAfectado}\n" +
                      $"Detalle Técnico: {ex.DetalleTecnico}";

            if (puedeRestaurarBD)
            {
                MessageBox.Show(msjError, "Consola de Emergencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Hide();

                FrmRestauracionBase frmEmergencia = new FrmRestauracionBase(msjError);
                frmEmergencia.ShowDialog();
            }
            else
            {
                MessageBox.Show("El sistema se encuentra inhabilitado temporalmente debido a fallas técnicas graves de consistencia.\n\n" +
                        "Por favor, comuníquese con el administrador de seguridad para restablecer el servicio.",
                        "Error Fatal de Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        private void ProcesarPostLogout()
        {
            try
            {
                idiomaCambiadoManualmente = false;
                int idEspañol = 1;
                var traduccionesEspañol = GestorIdioma.ObtenerTraducciones(idEspañol);
                Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idEspañol, traduccionesEspañol);
            }
            catch (Exception)
            {

            }
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = GestorIdioma.Listar();
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;

            this.Show();
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = GestorIdioma.Listar();
            CBXIdiomas.DisplayMember = "Nombre";
            CBXIdiomas.ValueMember= "Id";
            CBXIdiomas.SelectedIndex = -1;
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;

        }

        private void FrmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
            
        }

        private void CBXIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idiomaCambiadoManualmente = true;
                if (CBXIdiomas.SelectedValue != null && int.TryParse(CBXIdiomas.SelectedValue.ToString(), out int idIdiomaSeleccionado))
                {
                    var traducciones = GestorIdioma.ObtenerTraducciones(idIdiomaSeleccionado);
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaSeleccionado, traducciones);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la Base de Datos: " + ex.Message);
            }
        }
        

        public void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido))
                {
                    control.Text = textoTraducido;
                }
                if (control.HasChildren)
                {
                    TraducirControles(control.Controls, traducciones);
                }
            }
        }

        private void LBLidiomas_Click(object sender, EventArgs e)
        {

        }
    }
}
