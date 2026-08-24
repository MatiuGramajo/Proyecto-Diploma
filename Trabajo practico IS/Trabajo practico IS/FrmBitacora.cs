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
    public partial class FrmBitacora : Form, BE.IObserver
    {
        BLL.BITACORA GestorBitacora= new BLL.BITACORA();
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmBitacora()
        {
            InitializeComponent();
        }
        public void EnlazarUsuarios()
        {
            CBXBitacoraUsuario.DataSource = null;
            CBXBitacoraUsuario.DataSource = GestorBitacora.ObtenerUsuarios();
            CBXBitacoraUsuario.DisplayMember = "Usuario";
            CBXBitacoraUsuario.SelectedIndex = -1;
        }
        public void EnlazarModulo()
        {
            CBXBitacoraModulo.DataSource = null;
            CBXBitacoraModulo.DataSource = GestorBitacora.ObtenerModulo();
            CBXBitacoraModulo.DisplayMember = "Modulo";
            CBXBitacoraModulo.SelectedIndex = -1;


        }
        public void EnlazarCriticidad()
        {
            CBXBitacoraCriticidad.DataSource = null;
            CBXBitacoraCriticidad.DataSource = GestorBitacora.ObtenerCriticidad();
            CBXBitacoraCriticidad.DisplayMember = "Criticidad";
            CBXBitacoraCriticidad.SelectedIndex = -1;

        }
        public void EnlazarBitacora()
        {
            DateTime desde = DTPBitacoraDesde.Value.Date;
            DateTime hasta = DTPBitacoraHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            List<BE.BITACORA> ListaFiltrada = GestorBitacora.ObtenerHistorial(desde, hasta);
            if(CBXBitacoraUsuario.SelectedIndex !=-1)
            {
                string usuarioSeleccionado = CBXBitacoraUsuario.Text;
                List<BE.BITACORA> FiltrarUsuarios = (from l in ListaFiltrada
                                                     where l.Usuario == usuarioSeleccionado
                                                     select l).ToList();
                ListaFiltrada = FiltrarUsuarios;
            }
            if (CBXBitacoraModulo.SelectedIndex != -1)
            {
                string moduloSeleccionado = CBXBitacoraModulo.Text;
                List<BE.BITACORA> FiltrarModulo = (from m in ListaFiltrada
                                                     where m.Modulo == moduloSeleccionado
                                                     select m).ToList();
                ListaFiltrada = FiltrarModulo;
            }
            if (CBXBitacoraCriticidad.SelectedIndex != -1)
            {
                string criticidadSeleccionada = CBXBitacoraCriticidad.Text;
                List<BE.BITACORA> FiltrarCriticidad = (from c in ListaFiltrada
                                                     where c.Criticidad == int.Parse(criticidadSeleccionada)
                                                     select c).ToList();
                ListaFiltrada = FiltrarCriticidad;
            }
            DGV_BITACORA.DataSource = null;
            DGV_BITACORA.DataSource = ListaFiltrada;
            DGV_BITACORA.Columns["Id"].Visible = false;
        }
        public void EnlazarBitacoraTotal()
        {
            List<BE.BITACORA> ListaTotalFiltrada = GestorBitacora.ObtenerHistorialCompleto();
            if (CBXBitacoraUsuario.SelectedIndex != -1)
            {
                string usuarioSeleccionado = CBXBitacoraUsuario.Text;
                List<BE.BITACORA> FiltrarUsuarios = (from l in ListaTotalFiltrada
                                                     where l.Usuario == usuarioSeleccionado
                                                     select l).ToList();
                ListaTotalFiltrada = FiltrarUsuarios;
            }
            if (CBXBitacoraModulo.SelectedIndex != -1)
            {
                string moduloSeleccionado = CBXBitacoraModulo.Text;
                List<BE.BITACORA> FiltrarModulo = (from m in ListaTotalFiltrada
                                                   where m.Modulo == moduloSeleccionado
                                                   select m).ToList();
                ListaTotalFiltrada = FiltrarModulo;
            }
            if (CBXBitacoraCriticidad.SelectedIndex != -1)
            {
                string criticidadSeleccionada = CBXBitacoraCriticidad.Text;
                List<BE.BITACORA> FiltrarCriticidad = (from c in ListaTotalFiltrada
                                                       where c.Criticidad == int.Parse(criticidadSeleccionada)
                                                       select c).ToList();
                ListaTotalFiltrada = FiltrarCriticidad;
            }
            DGV_BITACORA.DataSource = null;
            DGV_BITACORA.DataSource = ListaTotalFiltrada;
            DGV_BITACORA.Columns["Id"].Visible = false;

        }
       
        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXidiomas.SelectedIndexChanged-= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            CBXidiomas.SelectedIndex = -1;
            ActualizarIdioma();
            DTPBitacoraDesde.Value = DateTime.Now.AddDays(-2);
            DTPBitacoraHasta.Value = DateTime.Now;
            EnlazarCriticidad();
            EnlazarModulo();
            EnlazarUsuarios();
            EnlazarBitacora();
            CKXincluirfechas.Checked = false;
            DTPBitacoraDesde.Enabled = false;
            DTPBitacoraHasta.Enabled = false;  
            

        }

        private void CBXidiomas_SelectedIndexChanged1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BTN_CargarBitacora_Click(object sender, EventArgs e)
        {
            if(CKXincluirfechas.Checked)
            { 
                if (DTPBitacoraHasta.Value < DTPBitacoraDesde.Value)
                {
                MessageBox.Show("La fecha final debe ser menor que la inicial.");
                return;
                }
              EnlazarBitacora();
            }
           else
            {
                EnlazarBitacoraTotal();
            }
            CBXBitacoraUsuario.SelectedIndex = -1;
            CBXBitacoraModulo.SelectedIndex = -1;
            CBXBitacoraCriticidad.SelectedIndex = -1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DTPBitacoraDesde.Enabled = CKXincluirfechas.Checked;
            DTPBitacoraHasta.Enabled = CKXincluirfechas.Checked;
        }

        private void BTN_BitacoraVolverAlMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
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
                if (traducciones.TryGetValue(clave, out string textoTraducido)) control.Text = textoTraducido;
                if (control.HasChildren) TraducirControles(control.Controls, traducciones);
            }
        }

        private void FrmBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        private void CBXidiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBXidiomas.SelectedValue != null && int.TryParse(CBXidiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
                    var traducciones = gestorIdioma.ObtenerTraducciones(idIdioma);
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

            }
        }
    }
}
