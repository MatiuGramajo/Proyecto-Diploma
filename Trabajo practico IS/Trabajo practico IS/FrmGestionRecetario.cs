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
    public partial class FrmGestionRecetario : Form,BE.IObserver
    {
        private BLL.RECETARIO gestorRecetario = new BLL.RECETARIO();
        private List<BE.SERVICIO_CATERING> listaServicios = new List<BE.SERVICIO_CATERING>();
        private List<BE.INSUMO> listaInsumos = new List<BE.INSUMO>();

        private List<BE.DETALLE_RECETARIO> recetarioLocal = new List<BE.DETALLE_RECETARIO>();
        private BE.SERVICIO_CATERING servicioSeleccionado = null;
        private List<BE.INSUMO> listaInsumosActivos = new List<BE.INSUMO>();
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmGestionRecetario()
        {
            InitializeComponent(); EstiloUI.Aplicar(this);
        }

        private void FrmGestionRecetario_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
            InicializarIdioma();
        }

        private void MostrarFormulario()
        {
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            try
            {
                var datos = gestorRecetario.ObtenerDatosIniciales();
                listaServicios = datos.servicios;

                CBXserviciocatering.DataSource = null;
                CBXserviciocatering.DataSource = listaServicios;
                CBXserviciocatering.DisplayMember = "Nombre_Servicio";
                CBXserviciocatering.ValueMember = "Id_Servicio";
                CBXserviciocatering.SelectedIndex = -1;

                listaInsumosActivos = datos.insumos
                            .Where(i => !string.IsNullOrEmpty(i.Estado) && i.Estado.Trim().Equals("Activo", StringComparison.OrdinalIgnoreCase))
                            .ToList();

                CBXinsumo.DataSource = null;
                CBXinsumo.DataSource = listaInsumosActivos;
                CBXinsumo.DisplayMember = "Nombre";
                CBXinsumo.ValueMember = "Id_Insumo";
                CBXinsumo.SelectedIndex = -1;

                LBLunidadmedida.Text = "(Unidad: -)";
                recetarioLocal.Clear();
                ActualizarGrillaRecetario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos iniciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrillaRecetario()
        {
            DGVrecetario.DataSource = null;
            DGVrecetario.Columns.Clear();

            var listaPresentacion = recetarioLocal.Select(d => new
            {
                Id_Insumo = d.Id_Insumo,
                Insumo = d.InsumoAsociado != null ? d.InsumoAsociado.Nombre : "",
                Rubro = d.InsumoAsociado != null ? d.InsumoAsociado.Rubro : "",
                Cantidad_Por_Persona = d.Cantidad_Por_Persona,
                Unidad_Medida = d.InsumoAsociado != null ? d.InsumoAsociado.Unidad_Medida : ""
            }).ToList();

            DGVrecetario.DataSource = new BindingSource { DataSource = listaPresentacion };

            FormatearGrillaRecetario();
        }

        private void FormatearGrillaRecetario()
        {
            if (DGVrecetario.Columns.Count == 0) return;

            DGVrecetario.ReadOnly = true;
            DGVrecetario.AllowUserToAddRows = false;
            DGVrecetario.AllowUserToDeleteRows = false;
            DGVrecetario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVrecetario.MultiSelect = false;
            DGVrecetario.RowHeadersVisible = false;
            DGVrecetario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (DGVrecetario.Columns.Contains("Id_Insumo"))
                DGVrecetario.Columns["Id_Insumo"].Visible = false;

            if (DGVrecetario.Columns.Contains("Insumo"))
            {
                var col = DGVrecetario.Columns["Insumo"];
                col.HeaderText = "Insumo";
                col.DisplayIndex = 0;
            }

            if (DGVrecetario.Columns.Contains("Rubro"))
            {
                var col = DGVrecetario.Columns["Rubro"];
                col.HeaderText = "Rubro";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 80;
                col.DisplayIndex = 1;
            }

            if (DGVrecetario.Columns.Contains("Cantidad_Por_Persona"))
            {
                var col = DGVrecetario.Columns["Cantidad_Por_Persona"];
                col.HeaderText = "Cant. x Persona";
                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 100;
                col.DisplayIndex = 2;
            }

            if (DGVrecetario.Columns.Contains("Unidad_Medida"))
            {
                var col = DGVrecetario.Columns["Unidad_Medida"];
                col.HeaderText = "Unidad";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 65;
                col.DisplayIndex = 3;
            }
        }

        private void CBXserviciocatering_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBXserviciocatering.SelectedItem == null || !(CBXserviciocatering.SelectedItem is BE.SERVICIO_CATERING))
            {
                servicioSeleccionado = null;
                recetarioLocal.Clear();
                ActualizarGrillaRecetario();
                return;
            }

            servicioSeleccionado = (BE.SERVICIO_CATERING)CBXserviciocatering.SelectedItem;

            try
            {
                recetarioLocal = gestorRecetario.ObtenerRecetarioPorServicio(servicioSeleccionado.Id_Servicio);
                ActualizarGrillaRecetario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la receta del servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBXinsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBXinsumo.SelectedItem != null && CBXinsumo.SelectedItem is BE.INSUMO insumo)
            {
                LBLunidadmedida.Text = $"Unidad: {insumo.Unidad_Medida}";
            }
            else
            {
                LBLunidadmedida.Text = "(Unidad: -)";
            }
        }

        private void BTNagregarinsumo_Click(object sender, EventArgs e)
        {
            if (servicioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione un servicio de catering.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CBXinsumo.SelectedItem == null || !(CBXinsumo.SelectedItem is BE.INSUMO insumoSel))
            {
                MessageBox.Show("Seleccione un insumo del catálogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.Equals(insumoSel.Estado?.Trim(), "Activo", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El insumo seleccionado se encuentra inactivo y no se puede agregar a la receta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(TXTcantidadporpersona.Text.Trim(), out decimal cantidadPorPersona) || cantidadPorPersona <= 0)
            {
                MessageBox.Show("Ingrese una cantidad valida por persona.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (recetarioLocal.Any(d => d.Id_Insumo == insumoSel.Id_Insumo))
            {
                MessageBox.Show("El insumo ya se encuentra agregado al menu. Modifique su cantidad desde la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BE.DETALLE_RECETARIO nuevoDetalle = new BE.DETALLE_RECETARIO
            {
                Id_Servicio = servicioSeleccionado.Id_Servicio,
                Id_Insumo = insumoSel.Id_Insumo,
                Cantidad_Por_Persona = cantidadPorPersona,
                InsumoAsociado = insumoSel
            };

            recetarioLocal.Add(nuevoDetalle);

            TXTcantidadporpersona.Clear();
            CBXinsumo.SelectedIndex = -1;
            CBXinsumo.Text = string.Empty;
            LBLunidadmedida.Text = "(Unidad: -)";

            ActualizarGrillaRecetario();
        }

        private void BTNquitarinsumo_Click(object sender, EventArgs e)
        {
;
            if (DGVrecetario.CurrentRow == null || DGVrecetario.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Seleccione un insumo de la lista de composición para quitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic itemSeleccionado = DGVrecetario.CurrentRow.DataBoundItem;
            int idInsumo = itemSeleccionado.Id_Insumo;

            BE.DETALLE_RECETARIO detalleQuitar = recetarioLocal.FirstOrDefault(d => d.Id_Insumo == idInsumo);
            if (detalleQuitar != null)
            {
                recetarioLocal.Remove(detalleQuitar);
            }

            ActualizarGrillaRecetario();
        
        }

        private void BTNguardarrecetario_Click(object sender, EventArgs e)
        {
            if (servicioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un servicio de catering.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (recetarioLocal.Count == 0)
            {
                MessageBox.Show("Debe asignar al menos un insumo para guardar el recetario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                gestorRecetario.GuardarRecetario(servicioSeleccionado.Id_Servicio, recetarioLocal);

                MessageBox.Show("Recetario guardado con exito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el recetario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void FrmGestionRecetario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
