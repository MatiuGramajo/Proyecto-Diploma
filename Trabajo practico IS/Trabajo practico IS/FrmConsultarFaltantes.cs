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
    public partial class FrmConsultarFaltantes : Form
    {
        private BLL.REQUERIMIENTO bllRequerimiento = new BLL.REQUERIMIENTO();
        private BLL.RESERVA bllReserva = new BLL.RESERVA();
        private List<BE.REQUERIMIENTO_INSUMO> listaConsolidada = new List<BE.REQUERIMIENTO_INSUMO>();
        private List<BE.RESERVA> listaEventosPlanificados = new List<BE.RESERVA>();

        public FrmConsultarFaltantes()
        {
            InitializeComponent();
        }

        private void FrmConsultarFaltantes_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            rbFechas.Checked = true;

            // Rango por defecto (-30 días a +60 días)
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today.AddDays(60);

            ActualizarEstadoFiltros();

            dgvRequerimientos.DataSource = null;
            listaConsolidada.Clear();

            CargarGrillaEventosPlanificados();
        }

        private void CargarGrillaEventosPlanificados()
        {
            try
            {
                DateTime? fechaDesde = null;
                DateTime? fechaHasta = null;

                // Si el filtro de fechas está activo, enviamos el rango seleccionado
                if (rbFechas.Checked)
                {
                    if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
                    {
                        MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    fechaDesde = dtpFechaDesde.Value.Date;
                    fechaHasta = dtpFechaHasta.Value.Date;
                }

                // Carga la lista de eventos planificados
                listaEventosPlanificados = bllReserva.ObtenerEventosPlanificados(fechaDesde, fechaHasta);

                dgvEventosPlanificados.DataSource = null;
                dgvEventosPlanificados.DataSource = listaEventosPlanificados;

                FormatearGrillaEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar eventos planificados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrillaEventos()
        {
            if (dgvEventosPlanificados.Columns.Count == 0) return;

            if (dgvEventosPlanificados.Columns["ClienteAsociado"] != null) dgvEventosPlanificados.Columns["ClienteAsociado"].Visible = false;
            if (dgvEventosPlanificados.Columns["PresupuestoAsociado"] != null) dgvEventosPlanificados.Columns["PresupuestoAsociado"].Visible = false;
            if (dgvEventosPlanificados.Columns["Id_Cliente"] != null) dgvEventosPlanificados.Columns["Id_Cliente"].Visible = false;
            if (dgvEventosPlanificados.Columns["Id_Presupuesto"] != null) dgvEventosPlanificados.Columns["Id_Presupuesto"].Visible = false;
            if (dgvEventosPlanificados.Columns["Id_Usuario"] != null) dgvEventosPlanificados.Columns["Id_Usuario"].Visible = false;

            dgvEventosPlanificados.Columns["Id_Reserva"].HeaderText = "N° Reserva";
            dgvEventosPlanificados.Columns["Fecha_Evento"].HeaderText = "Fecha Evento";
            dgvEventosPlanificados.Columns["Monto_Senia"].HeaderText = "Seña Abonada";
            dgvEventosPlanificados.Columns["Estado"].HeaderText = "Estado";
            dgvEventosPlanificados.Columns["Costo_Total_Real"].HeaderText = "Costo Total";
            dgvEventosPlanificados.Columns["Saldo_Pendiente"].HeaderText = "Saldo Pendiente";
        }

        private void ActualizarEstadoFiltros()
        {
            // Habilita o deshabilita los DateTimePicker según la opción elegida
            dtpFechaDesde.Enabled = rbFechas.Checked;
            dtpFechaHasta.Enabled = rbFechas.Checked;

            // La grilla SIEMPRE permanece habilitada para permitir seleccionar celdas y hacer scroll
            dgvEventosPlanificados.Enabled = true;

            if (rbFechas.Checked)
            {
                dgvEventosPlanificados.ClearSelection();
            }
        }

        private void rbFechas_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoFiltros();
        }

        private void rbEvento_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoFiltros();
        }

        // Evento que permite cambiar automáticamente la selección a "Por Evento" cuando el usuario hace clic en una fila de la grilla
        private void dgvEventosPlanificados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rbEvento.Checked = true;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarGrillaEventosPlanificados();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            int idReserva = 0;

            if (rbFechas.Checked)
            {
                if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fechaDesde = dtpFechaDesde.Value.Date;
                fechaHasta = dtpFechaHasta.Value.Date;
            }
            else if (rbEvento.Checked)
            {
                if (dgvEventosPlanificados.CurrentRow == null || dgvEventosPlanificados.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Seleccione un evento planificado de la grilla superior.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BE.RESERVA reservaSeleccionada = (BE.RESERVA)dgvEventosPlanificados.CurrentRow.DataBoundItem;
                idReserva = reservaSeleccionada.Id_Reserva;
            }

            try
            {
                listaConsolidada = bllRequerimiento.CalcularRequerimientos(fechaDesde, fechaHasta, idReserva);
                MostrarListaConsolidada();
            }
            catch (Exception ex)
            {
                dgvRequerimientos.DataSource = null;
                listaConsolidada.Clear();

                if (ex.Message.Contains("Sin eventos planificados"))
                {
                    MessageBox.Show("No se encontraron eventos planificados en el período seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ex.Message.Contains("Menu sin Recetario"))
                {
                    MessageBox.Show("Uno de los eventos seleccionados no tiene su recetario/menú asignado. Configure la composición del menú antes de calcular.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error inesperado al calcular los requerimientos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarListaConsolidada()
        {
            if (listaConsolidada == null || listaConsolidada.Count == 0)
            {
                dgvRequerimientos.DataSource = null;
                return;
            }

            var listaAmostrar = chkSoloFaltantes.Checked
                ? listaConsolidada.Where(i => i.Cantidad_Faltante > 0).ToList()
                : listaConsolidada;

            dgvRequerimientos.DataSource = null;
            dgvRequerimientos.DataSource = listaAmostrar;

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            if (dgvRequerimientos.Columns.Count == 0) return;

            dgvRequerimientos.Columns["Id_Insumo"].HeaderText = "Código Insumo";
            dgvRequerimientos.Columns["Nombre_Insumo"].HeaderText = "Insumo";
            dgvRequerimientos.Columns["Rubro"].HeaderText = "Rubro";
            dgvRequerimientos.Columns["Unidad_Medida"].HeaderText = "U. Medida";
            dgvRequerimientos.Columns["Cantidad_Requerida"].HeaderText = "Cant. Requerida";
            dgvRequerimientos.Columns["Stock_Actual"].HeaderText = "Stock Actual";
            dgvRequerimientos.Columns["Cantidad_Faltante"].HeaderText = "Faltante";
            dgvRequerimientos.Columns["Estado_Stock"].HeaderText = "Estado";

            foreach (DataGridViewRow row in dgvRequerimientos.Rows)
            {
                if (row.DataBoundItem is BE.REQUERIMIENTO_INSUMO item)
                {
                    if (item.Cantidad_Faltante > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void chkSoloFaltantes_CheckedChanged(object sender, EventArgs e)
        {
            MostrarListaConsolidada();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MostrarFormulario();
        }
    }

    //    private BLL.REQUERIMIENTO bllRequerimiento = new BLL.REQUERIMIENTO();
    //    private BLL.RESERVA bllReserva = new BLL.RESERVA();
    //    private List<BE.REQUERIMIENTO_INSUMO> listaConsolidada = new List<BE.REQUERIMIENTO_INSUMO>();
    //    private List<BE.RESERVA> listaEventosPlanificados = new List<BE.RESERVA>();

    //    public FrmConsultarFaltantes()
    //    {
    //        InitializeComponent();
    //    }

    //    private void FrmConsultarFaltantes_Load(object sender, EventArgs e)
    //    {
    //        MostrarFormulario();
    //    }

    //    private void MostrarFormulario()
    //    {
    //        rbFechas.Checked = true;

    //        // Rango amplio por defecto (-30 días a +60 días) para incluir todos los eventos de prueba
    //        dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
    //        dtpFechaHasta.Value = DateTime.Today.AddDays(60);

    //        ActualizarEstadoFiltros();

    //        dgvRequerimientos.DataSource = null;
    //        listaConsolidada.Clear();

    //        // Cargar la grilla con todos los eventos disponibles
    //        CargarGrillaEventosPlanificados();
    //    }

    //    private void CargarGrillaEventosPlanificados()
    //    {
    //        try
    //        {
    //            DateTime? fechaDesde = null;
    //            DateTime? fechaHasta = null;

    //            // Solo filtra por fechas si el RadioButton de fechas está activo
    //            if (rbFechas.Checked)
    //            {
    //                if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
    //                {
    //                    MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //                    return;
    //                }
    //                fechaDesde = dtpFechaDesde.Value.Date;
    //                fechaHasta = dtpFechaHasta.Value.Date;
    //            }

    //            // Si rbEvento está seleccionado, se le envían nulls para mostrar TODOS los eventos en la grilla y elegir uno
    //            listaEventosPlanificados = bllReserva.ObtenerEventosPlanificados(fechaDesde, fechaHasta);

    //            dgvEventosPlanificados.DataSource = null;
    //            dgvEventosPlanificados.DataSource = listaEventosPlanificados;

    //            FormatearGrillaEventos();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("Error al cargar eventos planificados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

    //    private void FormatearGrillaEventos()
    //    {
    //        if (dgvEventosPlanificados.Columns.Count == 0) return;

    //        if (dgvEventosPlanificados.Columns["ClienteAsociado"] != null) dgvEventosPlanificados.Columns["ClienteAsociado"].Visible = false;
    //        if (dgvEventosPlanificados.Columns["PresupuestoAsociado"] != null) dgvEventosPlanificados.Columns["PresupuestoAsociado"].Visible = false;
    //        if (dgvEventosPlanificados.Columns["Id_Cliente"] != null) dgvEventosPlanificados.Columns["Id_Cliente"].Visible = false;
    //        if (dgvEventosPlanificados.Columns["Id_Presupuesto"] != null) dgvEventosPlanificados.Columns["Id_Presupuesto"].Visible = false;
    //        if (dgvEventosPlanificados.Columns["Id_Usuario"] != null) dgvEventosPlanificados.Columns["Id_Usuario"].Visible = false;

    //        dgvEventosPlanificados.Columns["Id_Reserva"].HeaderText = "N° Reserva";
    //        dgvEventosPlanificados.Columns["Fecha_Evento"].HeaderText = "Fecha Evento";
    //        dgvEventosPlanificados.Columns["Monto_Senia"].HeaderText = "Seña Abonada";
    //        dgvEventosPlanificados.Columns["Estado"].HeaderText = "Estado";
    //        dgvEventosPlanificados.Columns["Costo_Total_Real"].HeaderText = "Costo Total";
    //        dgvEventosPlanificados.Columns["Saldo_Pendiente"].HeaderText = "Saldo Pendiente";
    //    }

    //    private void ActualizarEstadoFiltros()
    //    {
    //        // Mantiene habilitados los DateTimePicker para poder filtrar la grilla en cualquier modalidad
    //        dtpFechaDesde.Enabled = true;
    //        dtpFechaHasta.Enabled = true;

    //        // Habilita la selección directa de filas en la grilla únicamente al optar por un evento individual
    //        dgvEventosPlanificados.Enabled = rbEvento.Checked;

    //        if (!rbEvento.Checked)
    //        {
    //            dgvEventosPlanificados.ClearSelection();
    //        }
    //    }

    //    private void rbFechas_CheckedChanged(object sender, EventArgs e)
    //    {
    //        ActualizarEstadoFiltros();
    //    }

    //    private void rbEvento_CheckedChanged(object sender, EventArgs e)
    //    {
    //        ActualizarEstadoFiltros();
    //    }

    //    private void btnFiltrar_Click(object sender, EventArgs e)
    //    {
    //        // Al hacer clic en el botón de filtro se actualiza la grilla de eventos según las fechas seleccionadas
    //        CargarGrillaEventosPlanificados();
    //    }

    //    private void btnCalcular_Click(object sender, EventArgs e)
    //    {
    //        DateTime? fechaDesde = null;
    //        DateTime? fechaHasta = null;
    //        int idReserva = 0;

    //        if (rbFechas.Checked)
    //        {
    //            if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
    //            {
    //                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //                return;
    //            }
    //            fechaDesde = dtpFechaDesde.Value.Date;
    //            fechaHasta = dtpFechaHasta.Value.Date;
    //        }
    //        else if (rbEvento.Checked)
    //        {
    //            if (dgvEventosPlanificados.CurrentRow == null || dgvEventosPlanificados.CurrentRow.DataBoundItem == null)
    //            {
    //                MessageBox.Show("Seleccione un evento planificado de la grilla superior.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //                return;
    //            }

    //            BE.RESERVA reservaSeleccionada = (BE.RESERVA)dgvEventosPlanificados.CurrentRow.DataBoundItem;
    //            idReserva = reservaSeleccionada.Id_Reserva;
    //        }

    //        try
    //        {
    //            listaConsolidada = bllRequerimiento.CalcularRequerimientos(fechaDesde, fechaHasta, idReserva);
    //            MostrarListaConsolidada();
    //        }
    //        catch (Exception ex)
    //        {
    //            dgvRequerimientos.DataSource = null;
    //            listaConsolidada.Clear();

    //            if (ex.Message.Contains("Sin eventos planificados"))
    //            {
    //                MessageBox.Show("No se encontraron eventos planificados en el período seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            }
    //            else if (ex.Message.Contains("Menu sin Recetario"))
    //            {
    //                MessageBox.Show("Uno de los eventos seleccionados no tiene su recetario/menú asignado. Configure la composición del menú antes de calcular.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //            }
    //            else
    //            {
    //                MessageBox.Show("Ocurrió un error inesperado al calcular los requerimientos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            }
    //        }
    //    }

    //    private void MostrarListaConsolidada()
    //    {
    //        if (listaConsolidada == null || listaConsolidada.Count == 0)
    //        {
    //            dgvRequerimientos.DataSource = null;
    //            return;
    //        }

    //        var listaAmostrar = chkSoloFaltantes.Checked
    //            ? listaConsolidada.Where(i => i.Cantidad_Faltante > 0).ToList()
    //            : listaConsolidada;

    //        dgvRequerimientos.DataSource = null;
    //        dgvRequerimientos.DataSource = listaAmostrar;

    //        FormatearGrilla();
    //    }

    //    private void FormatearGrilla()
    //    {
    //        if (dgvRequerimientos.Columns.Count == 0) return;

    //        dgvRequerimientos.Columns["Id_Insumo"].HeaderText = "Código Insumo";
    //        dgvRequerimientos.Columns["Nombre_Insumo"].HeaderText = "Insumo";
    //        dgvRequerimientos.Columns["Rubro"].HeaderText = "Rubro";
    //        dgvRequerimientos.Columns["Unidad_Medida"].HeaderText = "U. Medida";
    //        dgvRequerimientos.Columns["Cantidad_Requerida"].HeaderText = "Cant. Requerida";
    //        dgvRequerimientos.Columns["Stock_Actual"].HeaderText = "Stock Actual";
    //        dgvRequerimientos.Columns["Cantidad_Faltante"].HeaderText = "Faltante";
    //        dgvRequerimientos.Columns["Estado_Stock"].HeaderText = "Estado";

    //        foreach (DataGridViewRow row in dgvRequerimientos.Rows)
    //        {
    //            if (row.DataBoundItem is BE.REQUERIMIENTO_INSUMO item)
    //            {
    //                if (item.Cantidad_Faltante > 0)
    //                {
    //                    row.DefaultCellStyle.BackColor = Color.LightPink;
    //                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
    //                }
    //                else
    //                {
    //                    row.DefaultCellStyle.BackColor = Color.LightGreen;
    //                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
    //                }
    //            }
    //        }
    //    }

    //    private void chkSoloFaltantes_CheckedChanged(object sender, EventArgs e)
    //    {
    //        MostrarListaConsolidada();
    //    }

    //    private void btnLimpiar_Click(object sender, EventArgs e)
    //    {
    //        MostrarFormulario();
    //    }

    //    private void dgvEventosPlanificados_CellClick(object sender, DataGridViewCellEventArgs e)
    //    {

    //    }
    //}

}
