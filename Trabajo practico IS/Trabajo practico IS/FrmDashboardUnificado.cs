using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trabajo_practico_IS
{
    public partial class FrmDashboardUnificado : Form,BE.IObserver
    {
        private BLL.DASHBOARD_FINANCIERO bllFinanciero = new BLL.DASHBOARD_FINANCIERO();
        private BLL.DASHBOARD_PERSONAL bllPersonal = new BLL.DASHBOARD_PERSONAL();
        private BLL.DASHBOARD_DEMANDA bllDemanda = new BLL.DASHBOARD_DEMANDA();
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        private Servicios.GESTOR_PDF gestorPdf = new Servicios.GESTOR_PDF();


        public FrmDashboardUnificado()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmDashboardUnificado_Load(object sender, EventArgs e)
        {
            InicializarFiltros();
            InicializarIdioma();
        }

        private void InicializarFiltros()
        {
            dtpFechaDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpFechaHasta.Value = DateTime.Now;

            cmbArea.Items.Clear();
            cmbArea.Items.Add("Financiero");
            cmbArea.Items.Add("Personal");
            cmbArea.Items.Add("Ocupación y Demanda");
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedItem == null) return;

            cmbMetrica.Items.Clear();
            string area = cmbArea.SelectedItem.ToString();

            switch (area)
            {
                case "Financiero":
                    cmbMetrica.Items.Add("Saldos Pendientes por Cliente");
                    cmbMetrica.Items.Add("Ingresos Proyectados vs. Cobrados");
                    cmbMetrica.Items.Add("Tasa de Conversión de Presupuestos");
                    break;

                case "Personal":
                    cmbMetrica.Items.Add("Top Personal por Asistencia");
                    cmbMetrica.Items.Add("Distribución por Categoría Laboral");
                    break;

                case "Ocupación y Demanda":
                    cmbMetrica.Items.Add("Volumen de Eventos por Mes");
                    cmbMetrica.Items.Add("Demanda por Tipo de Evento");
                    break;
            }

            if (cmbMetrica.Items.Count > 0)
                cmbMetrica.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            RenderizarDashBoard();
        }

        private void RenderizarDashBoard()
        {
            if (cmbMetrica.SelectedItem == null) return;

            try
            {
                DateTime desde = dtpFechaDesde.Value.Date;
                DateTime hasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1); 

                string metricaSeleccionada = cmbMetrica.SelectedItem.ToString();

                switch (metricaSeleccionada)
                {
                    case "Saldos Pendientes por Cliente":
                        RenderizarSaldosPendientesGrid(desde, hasta);
                        break;
                    case "Ingresos Proyectados vs. Cobrados":
                        RenderizarIngresosProyectados(desde, hasta);
                        break;
                    case "Tasa de Conversión de Presupuestos":
                        RenderizarConversionPresupuestos(desde, hasta);
                        break;

                    case "Top Personal por Asistencia":
                        RenderizarTopPersonalAsistencia(desde, hasta);
                        break;
                    case "Distribución por Categoría Laboral":
                        RenderizarDistribucionCategoriaPersonal(desde, hasta);
                        break;

                    case "Volumen de Eventos por Mes":
                        RenderizarVolumenEventosMes(desde, hasta);
                        break;
                    case "Demanda por Tipo de Evento":
                        RenderizarDemandaTiposEvento(desde, hasta);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderizarDemandaTiposEvento(DateTime desde, DateTime hasta)
        {
            PrepararChart("Demanda por Tipo de Evento", "Tipo de Evento", "Cantidad Contratada");

            List<BE.DEMANDA_TIPO_EVENTO_DTO> lista = bllDemanda.ObtenerDemandaTiposEvento(desde, hasta);

            Series serie = new Series("TiposEvento")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.DarkSlateBlue,
                CustomProperties = "PointWidth=0.5"
            };

            foreach (var item in lista)
            {
                serie.Points.AddXY(item.Tipo_Evento, item.Cantidad_Eventos);
            }

            chartPrincipal.Series.Add(serie);
        }

        private void RenderizarVolumenEventosMes(DateTime desde, DateTime hasta)
        {
            PrepararChart("Evolución del Volumen de Eventos", "Mes / Año", "Cantidad de Eventos");

            List<BE.VOLUMEN_EVENTOS_DTO> lista = bllDemanda.ObtenerVolumenEventosPorMes(desde, hasta);

            Series serie = new Series("Volumen")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.DarkBlue,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                IsValueShownAsLabel = true
            };

            foreach (var item in lista)
            {
                serie.Points.AddXY(item.Mes_Año, item.Cantidad_Eventos);
            }

            chartPrincipal.Series.Add(serie);
        }

        private void RenderizarDistribucionCategoriaPersonal(DateTime desde, DateTime hasta)
        {
            PrepararChart("Distribución de Asignaciones por Categoría", "", "");

            List<BE.DISTRIBUCION_CATEGORIA_DTO> lista = bllPersonal.ObtenerDistribucionCategoria(desde, hasta);

            Series serie = new Series("Categorias")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            foreach (var item in lista)
            {
                int idx = serie.Points.AddXY(item.Categoria, item.Cantidad_Asignaciones);
                serie.Points[idx].LegendText = $"{item.Categoria} ({item.Cantidad_Asignaciones})";
            }

            chartPrincipal.Series.Add(serie);
        }

        private void RenderizarTopPersonalAsistencia(DateTime desde, DateTime hasta)
        {
            PrepararChart("Top Personal por Asistencia a Eventos", "Cantidad de Eventos", "Empleado");

            List<BE.PERSONAL_ASISTENCIA_DTO> lista = bllPersonal.ObtenerTopPersonalAsistencia(desde, hasta);

            Series serie = new Series("Asistencias")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Color = Color.Teal
            };

            foreach (var item in lista)
            {
                serie.Points.AddXY(item.Nombre_Completo, item.Cantidad_Eventos);
            }

            chartPrincipal.Series.Add(serie);
        }

        private void RenderizarConversionPresupuestos(DateTime desde, DateTime hasta)
        {
            PrepararChart("Estado y Conversión de Presupuestos", "", "");

            BE.CONVERSION_PRESUPUESTO_DTO datos = bllFinanciero.ObtenerConversionPresupuestos(desde, hasta);

            Series serie = new Series("Presupuestos")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true
            };

            if (datos.Total_Presupuestos > 0)
            {
                int p1 = serie.Points.AddXY("Aprobados", datos.Cantidad_Aprobados);
                serie.Points[p1].Color = Color.ForestGreen;
                serie.Points[p1].LegendText = $"Aprobados ({datos.Cantidad_Aprobados})";

                int p2 = serie.Points.AddXY("Pendientes", datos.Cantidad_Pendientes);
                serie.Points[p2].Color = Color.Orange;
                serie.Points[p2].LegendText = $"Pendientes ({datos.Cantidad_Pendientes})";

                int p3 = serie.Points.AddXY("Rechazados", datos.Cantidad_Rechazados);
                serie.Points[p3].Color = Color.Firebrick;
                serie.Points[p3].LegendText = $"Rechazados ({datos.Cantidad_Rechazados})";
            }

            chartPrincipal.Series.Add(serie);
        }

        private void RenderizarIngresosProyectados(DateTime desde, DateTime hasta)
        {
            PrepararChart("Comparativa de Ingresos Financieros", "Concepto", "Monto ($)");

            BE.INGRESOS_PROYECTADOS_DTO datos = bllFinanciero.ObtenerIngresosProyectados(desde, hasta);

            Series serie = new Series("Ingresos")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                CustomProperties = "PointWidth=0.4"
            };

            int p1 = serie.Points.AddXY("Cobrado (Señas)", datos.Total_Cobrado);
            serie.Points[p1].Color = Color.MediumSeaGreen;
            serie.Points[p1].Label = $"${datos.Total_Cobrado:N2}";

            int p2 = serie.Points.AddXY("Saldo Pendiente", datos.Total_Pendiente);
            serie.Points[p2].Color = Color.IndianRed;
            serie.Points[p2].Label = $"${datos.Total_Pendiente:N2}";

            int p3 = serie.Points.AddXY("Total Proyectado", datos.Total_Proyectado);
            serie.Points[p3].Color = Color.SteelBlue;
            serie.Points[p3].Label = $"${datos.Total_Proyectado:N2}";

            chartPrincipal.Series.Add(serie);
        }

        private void RenderizarSaldosPendientesGrid(DateTime desde, DateTime hasta)
        {
            chartPrincipal.Visible = false;
            dgvDetalle.Visible = true;

            List<BE.SALDO_CLIENTE_DTO> lista = bllFinanciero.ListarSaldosPendientes(desde, hasta);

            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = lista;

            if (dgvDetalle.Columns.Count > 0)
            {
                dgvDetalle.Columns["Id_Reserva"].HeaderText = "N° Reserva";
                dgvDetalle.Columns["Cliente"].HeaderText = "Cliente";
                dgvDetalle.Columns["Fecha_Evento"].HeaderText = "Fecha Evento";
                dgvDetalle.Columns["Costo_Total"].HeaderText = "Costo Total";
                dgvDetalle.Columns["Monto_Senia"].HeaderText = "Seña Pagada";
                dgvDetalle.Columns["Saldo_Pendiente"].HeaderText = "Saldo Pendiente";

                dgvDetalle.Columns["Costo_Total"].DefaultCellStyle.Format = "C2";
                dgvDetalle.Columns["Monto_Senia"].DefaultCellStyle.Format = "C2";
                dgvDetalle.Columns["Saldo_Pendiente"].DefaultCellStyle.Format = "C2";

                dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void PrepararChart(string titulo, string tituloEjeX, string tituloEjeY)
        {
            dgvDetalle.Visible = false;
            chartPrincipal.Visible = true;

            chartPrincipal.Series.Clear();
            chartPrincipal.ChartAreas.Clear();
            chartPrincipal.Titles.Clear();

            ChartArea area = new ChartArea("AreaGeneral");
            area.AxisX.Title = tituloEjeX;
            area.AxisY.Title = tituloEjeY;
            area.AxisX.Interval = 1;
            chartPrincipal.ChartAreas.Add(area);

            chartPrincipal.Titles.Add(titulo);
        }
        private void cmbMetrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderizarDashBoard();
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

        private void FrmDashboardUnificado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedItem == null || cmbMetrica.SelectedItem == null)
            {
                MessageBox.Show("Primero seleccione un área y una métrica para consultar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string area = cmbArea.SelectedItem.ToString();
            string metrica = cmbMetrica.SelectedItem.ToString();
            DateTime desde = dtpFechaDesde.Value.Date;
            DateTime hasta = dtpFechaHasta.Value.Date;

            try
            {
                if (chartPrincipal.Visible && chartPrincipal.Series.Count > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        chartPrincipal.SaveImage(ms, ChartImageFormat.Png);
                        gestorPdf.GenerarReporteDashboardGrafico(area, metrica, desde, hasta, ms.ToArray());
                    }
                }
                else if (dgvDetalle.Visible && dgvDetalle.Rows.Count > 0)
                {
                    var columnasVisibles = dgvDetalle.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .OrderBy(c => c.DisplayIndex)
                        .ToList();

                    List<string> encabezados = columnasVisibles.Select(c => c.HeaderText).ToList();
                    List<List<string>> filas = new List<List<string>>();

                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        if (row.IsNewRow) continue;

                        List<string> celdas = columnasVisibles
                            .Select(c => row.Cells[c.Index].FormattedValue?.ToString() ?? "")
                            .ToList();

                        filas.Add(celdas);
                    }

                    gestorPdf.GenerarReporteDashboardTabla(area, metrica, desde, hasta, encabezados, filas);
                }
                else
                {
                    MessageBox.Show("No hay datos visualizados en el dashboard para imprimir.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir el dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNvolveralmenuprincipal_Click(object sender, EventArgs e)
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
