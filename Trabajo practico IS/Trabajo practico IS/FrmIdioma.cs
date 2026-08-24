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
    public partial class FrmIdioma : Form, BE.IObserver
    {
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();

        public FrmIdioma()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = TXTnombre.Text;
                string sufijo = TXTsufijo.Text;

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(sufijo))
                    throw new Exception("Debe completar el nombre y el sufijo.");

                if (!sufijo.StartsWith("_"))
                {
                    sufijo = "_" + sufijo;
                }
                BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();

                gestorIdioma.CrearIdioma(nombre, sufijo);

                MessageBox.Show("¡Idioma creado y autotraducido con éxito!");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = GestorIdioma.ObtenerIdioma();

                CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                CBXidiomas.DataSource = GestorIdioma.Listar();
                CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
                TXTnombre.Text = "";
                TXTsufijo.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error Detallado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNvolveralmenu_Click(object sender, EventArgs e)
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


        private void FrmIdioma_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            ActualizarIdioma();
            dataGridView1.DataSource = GestorIdioma.ObtenerIdioma();
            int idIdiomaActual = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            if (DGVtraducciones != null)
            {
                DGVtraducciones.DataSource = null;

                DGVtraducciones.DataSource = GestorIdioma.ObtenerDetalleTraducciones(idIdiomaActual);
                if (DGVtraducciones.Columns.Count > 0)
                {
                    DGVtraducciones.Columns["IdTraduccion"].HeaderText = "ID";
                    DGVtraducciones.Columns["IdTraduccion"].Width = 50;
                    DGVtraducciones.Columns["NombreFormulario"].HeaderText = "Formulario";
                    DGVtraducciones.Columns["NombreControl"].HeaderText = "Control";
                    DGVtraducciones.Columns["TextoTraducido"].HeaderText = "Traducción";
                    DGVtraducciones.Columns["TextoTraducido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
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
                   
                    if (DGVtraducciones != null)
                    {
                        DGVtraducciones.DataSource = null;
                        DGVtraducciones.DataSource = gestorIdioma.ObtenerDetalleTraducciones(idIdioma);

                        if (DGVtraducciones.Columns.Count > 0)
                        {
                            DGVtraducciones.Columns["IdTraduccion"].HeaderText = "ID";
                            DGVtraducciones.Columns["IdTraduccion"].Width = 50; 
                            DGVtraducciones.Columns["NombreFormulario"].HeaderText = "Formulario";
                            DGVtraducciones.Columns["NombreControl"].HeaderText = "Control";
                            DGVtraducciones.Columns["TextoTraducido"].HeaderText = "Traducción";
                            DGVtraducciones.Columns["TextoTraducido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el idioma o sus traducciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmIdioma_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);

        }

        private void BTNhabilitar_Click(object sender, EventArgs e)
        {
            try
            { 
                if (dataGridView1.CurrentRow == null)
                    throw new Exception("Debe seleccionar un idioma de la lista para habilitar.");

                BE.IDIOMA idiomaSeleccionado = (BE.IDIOMA)dataGridView1.CurrentRow.DataBoundItem;
                if (idiomaSeleccionado.EstaDisponible)
                {
                    MessageBox.Show("El idioma seleccionado ya se encuentra habilitado y disponible en el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                GestorIdioma.HabilitarIdioma(idiomaSeleccionado.Id);
                MessageBox.Show($"El idioma '{idiomaSeleccionado.Nombre}' ha sido habilitado con éxito y ya se encuentra disponible para su selección.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = GestorIdioma.ObtenerIdioma();

                CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                CBXidiomas.DataSource = GestorIdioma.Listar();
                CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar habilitar el idioma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNdeshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    throw new Exception("Debe seleccionar un idioma de la lista para deshabilitar.");
                }
                BE.IDIOMA idiomaSeleccionado = (BE.IDIOMA)dataGridView1.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show($"¿Está seguro que desea deshabilitar el idioma '{idiomaSeleccionado.Nombre}'?\nLos usuarios que lo utilicen serán migrados automáticamente al idioma por defecto.", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes)
                {
                    GestorIdioma.DeshabilitarIdioma(idiomaSeleccionado.Id);
                    MessageBox.Show("Idioma deshabilitado y usuarios migrados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = GestorIdioma.ObtenerIdioma();
                    CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                    CBXidiomas.DataSource = GestorIdioma.Listar();
                    CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                    CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
                }
                if (Servicios.IDIOMAS.GetInstancia().IdIdiomaActual == idiomaSeleccionado.Id)
                {
                    var traduccionesEspañol = GestorIdioma.ObtenerTraducciones(1);
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(1, traduccionesEspañol);
                    if (Servicios.SESION.GetInstancia().usuactual != null)
                    {
                        Servicios.SESION.GetInstancia().usuactual.IdIdioma = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricción del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

