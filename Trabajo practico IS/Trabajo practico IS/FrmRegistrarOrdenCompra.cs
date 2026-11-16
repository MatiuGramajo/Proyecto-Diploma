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
    public partial class FrmRegistrarOrdenCompra : Form, BE.IObserver
    {
        private BLL.PROVEEDOR_INSUMO bllProveedorInsumo = new BLL.PROVEEDOR_INSUMO();
        private BLL.INSUMO bllInsumo = new BLL.INSUMO();
        private BLL.ORDEN_COMPRA bllOrdenCompra = new BLL.ORDEN_COMPRA();
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();

        private List<BE.DETALLE_ORDEN_COMPRA> listaDetalles = new List<BE.DETALLE_ORDEN_COMPRA>();
        public FrmRegistrarOrdenCompra()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmRegistrarOrdenCompra_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
            InicializarIdioma();
        }

        private void MostrarFormulario()
        {
            try
            {
                cmbProveedores.DataSource = null;
                cmbProveedores.DataSource = bllProveedorInsumo.ListarProveedores();
                cmbProveedores.DisplayMember = "Razon_Social";
                cmbProveedores.ValueMember = "Id_Proveedor";
                cmbProveedores.SelectedIndex = -1;

                cmbInsumos.DataSource = null;
                cmbInsumos.DataSource = bllInsumo.ListarInsumos();
                cmbInsumos.DisplayMember = "Nombre";
                cmbInsumos.ValueMember = "Id_Insumo";
                cmbInsumos.SelectedIndex = -1;

                listaDetalles.Clear();
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la pantalla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrilla()
        {
            if (dgvDetalle.Columns.Count == 0) return;

            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in dgvDetalle.Columns)
            {
                col.Visible = false;
            }

            if (dgvDetalle.Columns.Contains("Nombre_Insumo"))
            {
                var col = dgvDetalle.Columns["Nombre_Insumo"];
                col.Visible = true;
                col.HeaderText = "Insumo";
                col.DisplayIndex = 0; 
            }

            if (dgvDetalle.Columns.Contains("Cantidad_Solicitada"))
            {
                var col = dgvDetalle.Columns["Cantidad_Solicitada"];
                col.Visible = true;
                col.HeaderText = "Cant. Solicitada";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 110;
                col.DisplayIndex = 1;
            }
        }
        private void ActualizarGrilla()
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = new BindingSource { DataSource = listaDetalles };
            FormatearGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbInsumos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un insumo del catálogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad numérica válida mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BE.INSUMO insumoSeleccionado = (BE.INSUMO)cmbInsumos.SelectedItem;

            BE.DETALLE_ORDEN_COMPRA existente = listaDetalles.FirstOrDefault(d => d.Id_Insumo == insumoSeleccionado.Id_Insumo);
            if (existente != null)
            {
                existente.Cantidad_Solicitada += cantidad;
            }
            else
            {
                listaDetalles.Add(new BE.DETALLE_ORDEN_COMPRA
                {
                    Id_Insumo = insumoSeleccionado.Id_Insumo,
                    Nombre_Insumo = insumoSeleccionado.Nombre,
                    Cantidad_Solicitada = cantidad,
                    Cantidad_Recibida = 0 
                });
            }

            txtCantidad.Text = ""; 
            cmbInsumos.SelectedIndex = -1; 
            ActualizarGrilla();
        }

        private void btnEmitirOrden_Click(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor para emitir la Orden de Compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listaDetalles == null || listaDetalles.Count == 0 || listaDetalles.Any(d => d.Cantidad_Solicitada <= 0))
            {
                MessageBox.Show("Ingrese al menos un insumo con cantidad valida mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BE.PROVEEDOR_INSUMO prov = (BE.PROVEEDOR_INSUMO)cmbProveedores.SelectedItem;

                BE.ORDEN_COMPRA nuevaOrden = new BE.ORDEN_COMPRA
                {
                    Id_Proveedor = prov.Id_Proveedor,
                    Detalles = listaDetalles
                };

                bllOrdenCompra.RegistrarOrdenCompra(nuevaOrden);

                MessageBox.Show("Orden de Compra emitida con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormulario(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al emitir la Orden de Compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void FrmRegistrarOrdenCompra_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        private void btnImportarXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar Orden de Compra en XML";
                ofd.Filter = "Archivos XML (*.xml)|*.xml";

                string carpetaOrdenes = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "OrdenesDeCompra"
                );

                if (System.IO.Directory.Exists(carpetaOrdenes))
                {
                    ofd.InitialDirectory = carpetaOrdenes;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        BE.ORDEN_COMPRA ordenImportada = bllOrdenCompra.ImportarOrdenXML(ofd.FileName);

                        if (ordenImportada == null || ordenImportada.Detalles == null)
                        {
                            MessageBox.Show("El archivo XML no contiene una Orden de Compra válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cmbProveedores.SelectedValue = ordenImportada.Id_Proveedor;
                        listaDetalles = ordenImportada.Detalles;
                        ActualizarGrilla();

                        MessageBox.Show($"Orden N° {ordenImportada.Id_OrdenCompra} cargada correctamente ({listaDetalles.Count} insumos).", "XML Importado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al leer el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }
    }
}
