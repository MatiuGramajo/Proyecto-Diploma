using BE;
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
    public partial class FrmMenuPrincipal : Form, BE.IObserver
    {

        BE.USUARIO UsuarioActual = SESION.GetInstancia().usuactual;
        BLL.USUARIO GestorUsuario = new BLL.USUARIO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        BLL.IDIOMA GestorIdioma=new BLL.IDIOMA();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            ActualizarIdioma();
            Utilidades.GES_PERMISOS_GUI.AplicarPermisos(this);
        }
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Atención",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión manual", 1);

                SESION.GetInstancia().Desasignar();

                UsuarioActual = null;
                this.Close();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
            if (UsuarioActual != null)
            {
                GestorBitacora.RegistrarEvento("Seguridad", "Cierre de sesión automatico", 1);
                SESION.GetInstancia().Desasignar();
            }

        }

        private void BitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmBitacora FrmBitacora = new FrmBitacora();
            FrmBitacora.ShowDialog();

            this.Show();
        }

        private void controlDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmCTRLUsuario FrmAdminCtrlUsuario = new FrmCTRLUsuario();
            FrmAdminCtrlUsuario.ShowDialog();

            this.Show();
        }

        private void controlDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmCTRLPermiso FrmAdminCtrPermiso = new FrmCTRLPermiso();
            FrmAdminCtrPermiso.ShowDialog();

            this.Show();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_LBLbienvenida", out string textoBienvenida))
            {
                LBLbienvenida.Text = string.Format(textoBienvenida, UsuarioActual.Usuario);
            }
            else
            {
                LBLbienvenida.Text = $"Bienvenido: {UsuarioActual.Usuario}";
            }
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo))
            {
                this.Text = textoTitulo;
            }
            if (CBXidiomas.Items.Count > 0)
            {
                CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
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
                if (control is MenuStrip menuStrip)
                {
                    foreach (ToolStripItem item in menuStrip.Items)
                    {
                        TraducirItemMenu(item, traducciones);
                    }
                }
                if (control.HasChildren)
                {
                    TraducirControles(control.Controls, traducciones);
                }
            }
        }
        private void TraducirItemMenu(ToolStripItem item, Dictionary<string, string> traducciones)
        {
            string clave = $"{this.Name}_{item.Name}";
            if (traducciones.TryGetValue(clave, out string textoTraducido))
            {
                item.Text = textoTraducido;
            }


            if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    TraducirItemMenu(subItem, traducciones);
                }
            }
        }

        private void CBXidiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBXidiomas.SelectedValue != null && int.TryParse(CBXidiomas.SelectedValue.ToString(), out int idIdiomaSeleccionado))
                {
                   
                    BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
                    var traducciones = gestorIdioma.ObtenerTraducciones(idIdiomaSeleccionado);

                   
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdiomaSeleccionado, traducciones);

                    GestorUsuario.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdiomaSeleccionado);

                    Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdiomaSeleccionado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la preferencia de idioma: " + ex.Message);    
            }
        }

        private void controlDeIdiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmIdioma frmIdioma= new FrmIdioma();
            frmIdioma.ShowDialog();
            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
            CBXidiomas.DataSource = gestorIdioma.Listar();
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            this.Show();

        }

        private void restauracionDeBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRestauracionBase frmRestauracion = new FrmRestauracionBase();
            frmRestauracion.ShowDialog();
            this.Show();
        }

        private void historialDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHistorial frmhistorial= new FrmHistorial();
            frmhistorial.ShowDialog();
            this.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.ShowDialog();
            this.Show();
        }

        private void FrmMenuPrincipal_Activated(object sender, EventArgs e)
        {
            ActualizarIdioma();
        }
    }
}

