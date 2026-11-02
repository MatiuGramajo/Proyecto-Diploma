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
    public partial class FrmRegistrarRecepcionMercaderia : Form
    {
        private BLL.ORDEN_COMPRA bllOrdenCompra = new BLL.ORDEN_COMPRA();
        private List<BE.ORDEN_COMPRA> listaOrdenesEmitidas = new List<BE.ORDEN_COMPRA>();
        private BE.ORDEN_COMPRA ordenSeleccionada = null;
        public FrmRegistrarRecepcionMercaderia()
        {
            InitializeComponent();
        }

        private void FrmRegistrarRecepcionMercaderia_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            try
            {
                ordenSeleccionada = null;
                dgvDetalleOrden.DataSource = null;

                CargarOrdenesEmitidas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la pantalla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOrdenesEmitidas()
        {
            listaOrdenesEmitidas = bllOrdenCompra.ListarOrdenesEmitidas();

            dgvOrdenesEmitidas.DataSource = null;
            dgvOrdenesEmitidas.DataSource = listaOrdenesEmitidas;

            FormatearGrillaOrdenes();
        }

        private void FormatearGrillaOrdenes()
        {
            if (dgvOrdenesEmitidas.Columns.Count == 0) return;

            if (dgvOrdenesEmitidas.Columns["Id_OrdenCompra"] != null) dgvOrdenesEmitidas.Columns["Id_OrdenCompra"].HeaderText = "N° Orden";
            if (dgvOrdenesEmitidas.Columns["Id_Proveedor"] != null) dgvOrdenesEmitidas.Columns["Id_Proveedor"].HeaderText = "Cód. Proveedor";
            if (dgvOrdenesEmitidas.Columns["Fecha_Emision"] != null) dgvOrdenesEmitidas.Columns["Fecha_Emision"].HeaderText = "Fecha Emisión";
            if (dgvOrdenesEmitidas.Columns["Estado"] != null) dgvOrdenesEmitidas.Columns["Estado"].HeaderText = "Estado";
        }

        private void dgvOrdenesEmitidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrdenesEmitidas.CurrentRow != null)
            {
                ordenSeleccionada = (BE.ORDEN_COMPRA)dgvOrdenesEmitidas.CurrentRow.DataBoundItem;

                if (ordenSeleccionada != null)
                {
                    dgvDetalleOrden.DataSource = null;
                    dgvDetalleOrden.DataSource = ordenSeleccionada.Detalles;
                    FormatearGrillaDetalle();
                }
            }
        }

        private void FormatearGrillaDetalle()
        {
            if (dgvDetalleOrden.Columns.Count == 0) return;

            if (dgvDetalleOrden.Columns["Id_Detalle"] != null) dgvDetalleOrden.Columns["Id_Detalle"].Visible = false;
            if (dgvDetalleOrden.Columns["Id_OrdenCompra"] != null) dgvDetalleOrden.Columns["Id_OrdenCompra"].Visible = false;
            if (dgvDetalleOrden.Columns["Id_Insumo"] != null) dgvDetalleOrden.Columns["Id_Insumo"].HeaderText = "Cód. Insumo";

            if (dgvDetalleOrden.Columns["Nombre_Insumo"] != null)
            {
                dgvDetalleOrden.Columns["Nombre_Insumo"].HeaderText = "Insumo";
                dgvDetalleOrden.Columns["Nombre_Insumo"].ReadOnly = true;
            }

            if (dgvDetalleOrden.Columns["Cantidad_Solicitada"] != null)
            {
                dgvDetalleOrden.Columns["Cantidad_Solicitada"].HeaderText = "Cant. Solicitada";
                dgvDetalleOrden.Columns["Cantidad_Solicitada"].ReadOnly = true;
            }

            if (dgvDetalleOrden.Columns["Cantidad_Recibida"] != null)
            {
                dgvDetalleOrden.Columns["Cantidad_Recibida"].HeaderText = "Cant. Recibida";
                dgvDetalleOrden.Columns["Cantidad_Recibida"].ReadOnly = false;
            }
        }

        private void btnRegistrarREcepcion_Click(object sender, EventArgs e)
        {
            if (ordenSeleccionada == null || ordenSeleccionada.Detalles == null || ordenSeleccionada.Detalles.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una orden de compra e ingresar cantidades validas recibidas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvDetalleOrden.EndEdit();

            bool poseeCantidadesValidas = ordenSeleccionada.Detalles.Any(d => d.Cantidad_Recibida > 0);
            if (!poseeCantidadesValidas)
            {
                MessageBox.Show("Debe seleccionar una orden de compra e ingresar cantidades validas recibidas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var detalle in ordenSeleccionada.Detalles)
            {
                if (detalle.Cantidad_Recibida < 0 || detalle.Cantidad_Recibida > detalle.Cantidad_Solicitada)
                {
                    MessageBox.Show("La cantidad recibida no puede superar la cantidad solicitada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                bllOrdenCompra.RegistrarRecepcion(ordenSeleccionada);

                MessageBox.Show("Recepción de mercadería registrada y stock actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar la recepción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MostrarFormulario();
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
    }
}
