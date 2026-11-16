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
    public partial class FrmGestionarPersonal : Form, BE.IObserver
    {
        private BLL.PERSONAL bllPersonal = new BLL.PERSONAL();
        private List<BE.PERSONAL> listaPersonal = new List<BE.PERSONAL>();
        private BE.PERSONAL personalSeleccionado = null;
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmGestionarPersonal()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmGestionarPersonal_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            MostrarFormulario();
            InicializarIdioma();
        }

        private void MostrarFormulario()
        {
            try
            {
                LimpiarCampos();
                CargarGrillaPersonal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la pantalla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaPersonal()
        {
            listaPersonal = bllPersonal.ListarPersonal();
            dgvPersonal.DataSource = null;
            dgvPersonal.DataSource = listaPersonal;

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            if (dgvPersonal.Columns.Count == 0) return;

            if (dgvPersonal.Columns["Id_Personal"] != null) dgvPersonal.Columns["Id_Personal"].Visible = false;
            if (dgvPersonal.Columns["Direccion"] != null) dgvPersonal.Columns["Direccion"].Visible = false;
            if (dgvPersonal.Columns["Email"] != null) dgvPersonal.Columns["Email"].Visible = false;

            if (dgvPersonal.Columns["Dni"] != null) dgvPersonal.Columns["Dni"].HeaderText = "DNI";
            if (dgvPersonal.Columns["Apellido"] != null) dgvPersonal.Columns["Apellido"].HeaderText = "Apellido";
            if (dgvPersonal.Columns["Nombre"] != null) dgvPersonal.Columns["Nombre"].HeaderText = "Nombre";
            if (dgvPersonal.Columns["Categoria"] != null) dgvPersonal.Columns["Categoria"].HeaderText = "Categoría";
            if (dgvPersonal.Columns["Telefono"] != null) dgvPersonal.Columns["Telefono"].HeaderText = "Teléfono";
            if (dgvPersonal.Columns["Estado"] != null) dgvPersonal.Columns["Estado"].HeaderText = "Estado";
        }

        private void LimpiarCampos()
        {
            personalSeleccionado = null;
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            cmbCategoria.SelectedIndex = -1;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dgvPersonal.ClearSelection();
        }

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Mozo");
            cmbCategoria.Items.Add("Cocinero");
            cmbCategoria.Items.Add("Seguridad");
            cmbCategoria.Items.Add("Maitre");
            cmbCategoria.SelectedIndex = -1;
        }

        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPersonal.CurrentRow != null)
            {
                personalSeleccionado = (BE.PERSONAL)dgvPersonal.CurrentRow.DataBoundItem;

                if (personalSeleccionado != null)
                {
                    txtDni.Text = personalSeleccionado.Dni;
                    txtNombre.Text = personalSeleccionado.Nombre;
                    txtApellido.Text = personalSeleccionado.Apellido;
                    cmbCategoria.SelectedItem = personalSeleccionado.Categoria;
                    txtTelefono.Text = personalSeleccionado.Telefono;
                    txtDireccion.Text = personalSeleccionado.Direccion;
                    txtEmail.Text = personalSeleccionado.Email;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Debe ingresar datos válidos en todos los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BE.PERSONAL objPersonal = personalSeleccionado ?? new BE.PERSONAL();

                objPersonal.Dni = txtDni.Text.Trim();
                objPersonal.Nombre = txtNombre.Text.Trim();
                objPersonal.Apellido = txtApellido.Text.Trim();
                objPersonal.Categoria = cmbCategoria.SelectedItem.ToString();
                objPersonal.Telefono = txtTelefono.Text.Trim();
                objPersonal.Direccion = txtDireccion.Text.Trim();
                objPersonal.Email = txtEmail.Text.Trim();

                if (objPersonal.Id_Personal == 0)
                {
                    objPersonal.Estado = "Activo";
                }

                bllPersonal.Guardar(objPersonal);

                string mensajeExito = (personalSeleccionado == null) ? "Personal guardado con éxito." : "Personal actualizado con éxito.";
                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (personalSeleccionado == null)
            {
                MessageBox.Show("Seleccione un empleado de la grilla para cambiar su estado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bllPersonal.CambiarEstado(personalSeleccionado);

                MessageBox.Show("Estado del personal actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
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

        private void FrmGestionarPersonal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
