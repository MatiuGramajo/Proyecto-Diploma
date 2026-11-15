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
    public partial class FrmRegistrarRecepcionMercaderia : Form,BE.IObserver
    {
        private BLL.ORDEN_COMPRA bllOrdenCompra = new BLL.ORDEN_COMPRA();
        private BLL.PROVEEDOR_INSUMO bllProveedor = new BLL.PROVEEDOR_INSUMO();
        private List<BE.ORDEN_COMPRA> listaOrdenesEmitidas = new List<BE.ORDEN_COMPRA>();
        private List<BE.PROVEEDOR_INSUMO> listaProveedores = new List<BE.PROVEEDOR_INSUMO>();
        private BE.ORDEN_COMPRA ordenSeleccionada = null;
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();

        public FrmRegistrarRecepcionMercaderia()
        {
            InitializeComponent();
            dgvDetalleOrden.DataError += dgvDetalleOrden_DataError;
        }

        private void FrmRegistrarRecepcionMercaderia_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
            InicializarIdioma();
        }

        private void MostrarFormulario()
        {
            try
            {
                ordenSeleccionada = null;
                dgvDetalleOrden.DataSource = null;
                dgvDetalleOrden.Columns.Clear();

                listaProveedores = bllProveedor.ListarProveedores();
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
            dgvOrdenesEmitidas.Columns.Clear();
            dgvOrdenesEmitidas.DataSource = new BindingSource { DataSource = listaOrdenesEmitidas };

            FormatearGrillaOrdenes();
        }

        private void FormatearGrillaOrdenes()
        {
            if (dgvOrdenesEmitidas.Columns.Count == 0) return;

            dgvOrdenesEmitidas.ReadOnly = true;
            dgvOrdenesEmitidas.AllowUserToAddRows = false;
            dgvOrdenesEmitidas.AllowUserToDeleteRows = false;
            dgvOrdenesEmitidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenesEmitidas.MultiSelect = false;
            dgvOrdenesEmitidas.RowHeadersVisible = false;
            dgvOrdenesEmitidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in dgvOrdenesEmitidas.Columns)
                col.Visible = false;

            dgvOrdenesEmitidas.Columns.Add("ColProveedor", "Proveedor");

            if (dgvOrdenesEmitidas.Columns.Contains("Id_OrdenCompra"))
            {
                var col = dgvOrdenesEmitidas.Columns["Id_OrdenCompra"];
                col.Visible = true;
                col.HeaderText = "N° Orden";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 65;
                col.DisplayIndex = 0;
            }

            var colProv = dgvOrdenesEmitidas.Columns["ColProveedor"];
            colProv.Visible = true;
            colProv.DisplayIndex = 1;

            if (dgvOrdenesEmitidas.Columns.Contains("Fecha_Emision"))
            {
                var col = dgvOrdenesEmitidas.Columns["Fecha_Emision"];
                col.Visible = true;
                col.HeaderText = "Fecha Emisión";
                col.DefaultCellStyle.Format = "dd/MM/yyyy";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 90;
                col.DisplayIndex = 2;
            }

            foreach (DataGridViewRow row in dgvOrdenesEmitidas.Rows)
            {
                if (row.DataBoundItem is BE.ORDEN_COMPRA ord)
                {
                    var prov = listaProveedores.FirstOrDefault(p => p.Id_Proveedor == ord.Id_Proveedor);
                    row.Cells["ColProveedor"].Value = prov != null ? prov.Razon_Social : $"Proveedor #{ord.Id_Proveedor}";
                }
            }
        }

        private void dgvOrdenesEmitidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrdenesEmitidas.CurrentRow != null)
            {
                ordenSeleccionada = (BE.ORDEN_COMPRA)dgvOrdenesEmitidas.CurrentRow.DataBoundItem;

                if (ordenSeleccionada != null)
                {
                    dgvDetalleOrden.DataSource = null;
                    dgvDetalleOrden.Columns.Clear();
                    dgvDetalleOrden.DataSource = new BindingSource { DataSource = ordenSeleccionada.Detalles };
                    FormatearGrillaDetalle();
                }
            }
        }

        private void FormatearGrillaDetalle()
        {
            if (dgvDetalleOrden.Columns.Count == 0) return;

            dgvDetalleOrden.AllowUserToAddRows = false;
            dgvDetalleOrden.AllowUserToDeleteRows = false;
            dgvDetalleOrden.RowHeadersVisible = false;
            dgvDetalleOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in dgvDetalleOrden.Columns)
                col.Visible = false;

            if (dgvDetalleOrden.Columns.Contains("Nombre_Insumo"))
            {
                var col = dgvDetalleOrden.Columns["Nombre_Insumo"];
                col.Visible = true;
                col.HeaderText = "Insumo";
                col.ReadOnly = true;
                col.DisplayIndex = 0;
            }

            if (dgvDetalleOrden.Columns.Contains("Cantidad_Solicitada"))
            {
                var col = dgvDetalleOrden.Columns["Cantidad_Solicitada"];
                col.Visible = true;
                col.HeaderText = "Cant. Solicitada";
                col.ReadOnly = true;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 105;
                col.DisplayIndex = 1;
            }

            if (dgvDetalleOrden.Columns.Contains("Cantidad_Recibida"))
            {
                var col = dgvDetalleOrden.Columns["Cantidad_Recibida"];
                col.Visible = true;
                col.HeaderText = "Cant. Recibida";
                col.ReadOnly = false; 
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.DefaultCellStyle.BackColor = Color.LightYellow;
                col.DefaultCellStyle.Font = new Font(dgvDetalleOrden.Font, FontStyle.Bold);
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 105;
                col.DisplayIndex = 2;
            }
        }

        private void dgvDetalleOrden_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ingrese un valor numérico entero válido en la cantidad recibida.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }

        private void btnRegistrarREcepcion_Click(object sender, EventArgs e)
        {
            if (ordenSeleccionada == null || ordenSeleccionada.Detalles == null || ordenSeleccionada.Detalles.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una orden de compra e ingresar cantidades válidas recibidas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvDetalleOrden.EndEdit();

            bool poseeCantidadesValidas = ordenSeleccionada.Detalles.Any(d => d.Cantidad_Recibida > 0);
            if (!poseeCantidadesValidas)
            {
                MessageBox.Show("Debe ingresar al menos una cantidad recibida mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var detalle in ordenSeleccionada.Detalles)
            {
                if (detalle.Cantidad_Recibida < 0 || detalle.Cantidad_Recibida > detalle.Cantidad_Solicitada)
                {
                    MessageBox.Show($"La cantidad recibida de '{detalle.Nombre_Insumo}' no puede ser negativa ni superar la solicitada ({detalle.Cantidad_Solicitada}).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            bool esRecepcionParcial = ordenSeleccionada.Detalles.Any(d => d.Cantidad_Recibida < d.Cantidad_Solicitada);
            if (esRecepcionParcial)
            {
                var confirmar = MessageBox.Show(
                    "Hay insumos con cantidad recibida menor a la solicitada (o en 0).\nSolo se sumará al stock lo recibido y la orden pasará a estado 'Recibida'.\n\n¿Desea confirmar la recepción de todos modos?",
                    "Confirmar recepción con faltantes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmar != DialogResult.Yes)
                    return;
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
        private void FrmRegistrarRecepcionMercaderia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
    
}
