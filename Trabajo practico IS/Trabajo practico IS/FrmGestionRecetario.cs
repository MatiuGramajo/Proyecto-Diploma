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
    public partial class FrmGestionRecetario : Form
    {
        private BLL.RECETARIO gestorRecetario = new BLL.RECETARIO();
        private List<BE.SERVICIO_CATERING> listaServicios = new List<BE.SERVICIO_CATERING>();
        private List<BE.INSUMO> listaInsumos = new List<BE.INSUMO>();

        private List<BE.DETALLE_RECETARIO> recetarioLocal = new List<BE.DETALLE_RECETARIO>();
        private BE.SERVICIO_CATERING servicioSeleccionado = null;
        private List<BE.INSUMO> listaInsumosActivos = new List<BE.INSUMO>();
        public FrmGestionRecetario()
        {
            InitializeComponent();
        }

        private void FrmGestionRecetario_Load(object sender, EventArgs e)
        {
            MostrarFormulario();
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

            var listaPresentacion = recetarioLocal.Select(d => new
            {
                Id_Insumo = d.Id_Insumo,
                Insumo = d.InsumoAsociado != null ? d.InsumoAsociado.Nombre : "",
                Rubro = d.InsumoAsociado != null ? d.InsumoAsociado.Rubro : "",
                Cantidad_Por_Persona = d.Cantidad_Por_Persona,
                Unidad_Medida = d.InsumoAsociado != null ? d.InsumoAsociado.Unidad_Medida : ""
            }).ToList();

            DGVrecetario.DataSource = listaPresentacion;
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
    }
}
