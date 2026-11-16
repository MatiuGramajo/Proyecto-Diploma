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
    public partial class FrmCalibrarRatios : Form,BE.IObserver
    {
        private BLL.PARAMETRO_RATIO bllRatio = new BLL.PARAMETRO_RATIO();
        private BE.CALIBRACION_DTO dtoCalibracion = null;
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmCalibrarRatios()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmCalibrarRatios_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
            InicializarIdioma();
        }

        private void MostrarFormulario()
        {
            try
            {
                LimpiarControles();
                CargarDatosCalibracion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la calibración de ratios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosCalibracion()
        {
            dtoCalibracion = bllRatio.ObtenerCalibracionRatios();

            if (dtoCalibracion.TotalEventosEvaluados < 10)
            {
                lblTotalEventosInfo.Text = $"Total evaluados: {dtoCalibracion.TotalEventosEvaluados}";
                MessageBox.Show(
                    "Se requieren al menos 10 eventos evaluados para ejecutar la calibración de ratios.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                return;
            }

            lblTotalEventosInfo.Text = $"Total eventos evaluados: {dtoCalibracion.TotalEventosEvaluados}";
            lblAprobadosInfo.Text = $"Aprobación favorable: {dtoCalibracion.CantidadAprobados} ({dtoCalibracion.PorcentajeAprobacion}%)";
            lblDesaprobadosInfo.Text = $"Evaluaciones negativas: {dtoCalibracion.CantidadDesaprobados} ({dtoCalibracion.PorcentajeDesaprobacion}%)";
            lblRecomendacionInfo.Text = $"Recomendación: {dtoCalibracion.RecomendacionAjuste}";

            var listaComparativa = from actual in dtoCalibracion.RatiosActuales
                                   join sugerido in dtoCalibracion.RatiosSugeridos
                                   on actual.Categoria equals sugerido.Categoria
                                   select new
                                   {
                                       Categoria = actual.Categoria,
                                       RatioActual = $"1 personal / {actual.Cantidad_Invitados_Por_Personal} invitados",
                                       RatioSugerido = $"1 personal / {sugerido.Cantidad_Invitados_Por_Personal} invitados"
                                   };

            dgvRatios.DataSource = null;
            dgvRatios.DataSource = listaComparativa.ToList();

            FormatearGrillaRatios();
            btnAplicarRatios.Enabled = true;
        }
        

        private void FormatearGrillaRatios()
        {
            if (dgvRatios.Columns.Count == 0) return;

            dgvRatios.Columns["Categoria"].HeaderText = "Categoría Laboral";
            dgvRatios.Columns["RatioActual"].HeaderText = "Cobertura Actual";
            dgvRatios.Columns["RatioSugerido"].HeaderText = "Cobertura Sugerida";

            dgvRatios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarControles()
        {
            dtoCalibracion = null;

            lblTotalEventosInfo.Text = "-";
            lblAprobadosInfo.Text = "-";
            lblDesaprobadosInfo.Text = "-";
            lblRecomendacionInfo.Text = "Sin analizar";

            dgvRatios.DataSource = null;
            btnAplicarRatios.Enabled = false;
        }

        private void btnAplicarRatios_Click(object sender, EventArgs e)
        {
            if (dtoCalibracion == null || dtoCalibracion.RatiosSugeridos.Count == 0)
            {
                MessageBox.Show("No existen parámetros calculados para aplicar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bllRatio.GuardarNuevosRatios(dtoCalibracion);

                MessageBox.Show("Ratios operativos calibrados y actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los nuevos ratios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolverAlMenu_Click(object sender, EventArgs e)
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

        private void FrmCalibrarRatios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
