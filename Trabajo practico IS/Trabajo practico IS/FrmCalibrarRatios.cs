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
    public partial class FrmCalibrarRatios : Form
    {
        private BLL.PARAMETRO_RATIO bllRatio = new BLL.PARAMETRO_RATIO();
        private BE.CALIBRACION_DTO dtoCalibracion = null;
        public FrmCalibrarRatios()
        {
            InitializeComponent();
        }

        private void FrmCalibrarRatios_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
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
    }
}
