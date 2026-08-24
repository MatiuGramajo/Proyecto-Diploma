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
    public partial class FrmHistorial : Form, BE.IObserver
    {
        BLL.HISTORIAL_USUARIO GestorHistorialUsuario = new BLL.HISTORIAL_USUARIO();
        BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
        public FrmHistorial()
        {
            InitializeComponent();
            DGVHistorial.SelectionChanged += DGVHistorial_SelectionChanged;
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
            if (CBXIdiomas.Items.Count > 0)
            {
                CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
                CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            }
        }
        public void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido)) control.Text = textoTraducido;
                if (control.HasChildren) TraducirControles(control.Controls, traducciones);
            }
        }
        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            CBX_Entidad.SelectedIndexChanged -= CBX_Entidad_SelectedIndexChanged;

            CBX_Entidad.Items.Clear();
            CBX_Entidad.Items.Add("Usuarios");
            CBX_Entidad.Items.Add("Productos");

            CBX_Entidad.SelectedIndexChanged += CBX_Entidad_SelectedIndexChanged;
            CBX_Entidad.SelectedIndex = 0;

            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
            CBXIdiomas.DataSource = gestorIdioma.Listar();
            CBXIdiomas.DisplayMember = "Nombre";
            CBXIdiomas.ValueMember = "Id";
            CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            ActualizarIdioma();
            ActualizarEstadoBotonRestaurar();
        }

        private void BTNrestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVHistorial.CurrentRow == null || DGVHistorial.CurrentRow.DataBoundItem == null)
                {
                    throw new Exception("Por favor, seleccione de la grilla la versión específica que desea restaurar.");
                }

                if (CBX_Entidad.SelectedItem == null) return;
                string entidadSeleccionada = CBX_Entidad.SelectedItem.ToString();

                if (entidadSeleccionada == "Usuarios")
                {
                    BE.HISTORIAL_USUARIO versionSeleccionada = (BE.HISTORIAL_USUARIO)DGVHistorial.CurrentRow.DataBoundItem;

                    if (versionSeleccionada.Activo == false)
                    {
                        MessageBox.Show("No se puede restaurar una versión donde el usuario estaba dado de baja.", "Versión Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    BLL.USUARIO gestorUsu = new BLL.USUARIO();
                    BE.USUARIO usuarioActual = gestorUsu.Listar().FirstOrDefault(u => u.Id == versionSeleccionada.Id);

                    if (usuarioActual != null && usuarioActual.Activo == false)
                    {
                        MessageBox.Show("Operación denegada.\n\nNo se puede restaurar información de un registro que se encuentra dado de baja (Inactivo).", "Registro Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return; 
                    }

                    var r = MessageBox.Show(
                        $"¿Está seguro de que desea restaurar los datos de este usuario al estado exacto del día {versionSeleccionada.FechaCambio}?",
                        "Confirmar Restauración de Usuario",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (r == DialogResult.Yes)
                    {
                        GestorHistorialUsuario.RestaurarUsuario(versionSeleccionada.IdHistorial);

                        MessageBox.Show("El perfil del usuario ha sido restaurado con éxito.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CBX_Filtro_SelectedIndexChanged(null, null);
                    }
                }

                else if (entidadSeleccionada == "Productos")
                {
                    BE.HISTORIAL_PRODUCTO versionSeleccionada = (BE.HISTORIAL_PRODUCTO)DGVHistorial.CurrentRow.DataBoundItem;

                    if (versionSeleccionada.Activo == false)
                    {
                        MessageBox.Show("No se puede restaurar una versión donde el producto estaba dado de baja.", "Versión Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    BLL.PRODUCTO gestorProd = new BLL.PRODUCTO();
                    BE.PRODUCTO productoActual = gestorProd.Listar().FirstOrDefault(p => p.Id == versionSeleccionada.IdProducto);

                    if (productoActual != null && productoActual.Activo == false)
                    {
                        MessageBox.Show("Operación denegada.\n\nNo se puede restaurar información de un producto que se encuentra dado de baja (Inactivo).", "Registro Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var r = MessageBox.Show(
                        $"¿Está seguro de que desea restaurar los datos de este producto al estado exacto del día {versionSeleccionada.FechaCambio}?",
                        "Confirmar Restauración de Producto",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (r == DialogResult.Yes)
                    {
                        BLL.HISTORIAL_PRODUCTO gestorHistProd = new BLL.HISTORIAL_PRODUCTO();
                        gestorHistProd.RestaurarProducto(versionSeleccionada.IdHistorial);

                        MessageBox.Show("El producto ha sido restaurado con éxito.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CBX_Filtro_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CBXIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (CBXIdiomas.SelectedValue != null && int.TryParse(CBXIdiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
                    var traducciones = gestorIdioma.ObtenerTraducciones(idIdioma);
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

            }
        }

        private void FrmHistorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);

        }

        private void BTNvolveralmenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void CBX_Entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBX_Entidad.SelectedItem == null) return;
            string entidadSeleccionada = CBX_Entidad.SelectedItem.ToString();
            CargarGrillaGeneral(entidadSeleccionada);
            CargarComboFiltroEspecifico(entidadSeleccionada);
        }

        private void CargarComboFiltroEspecifico(string entidadSeleccionada)
        {
            CBX_Filtro.SelectedIndexChanged -= CBX_Filtro_SelectedIndexChanged;
            CBX_Filtro.DataSource = null;

            if (entidadSeleccionada == "Usuarios")
            {
                BLL.USUARIO gestorUsu = new BLL.USUARIO();
                CBX_Filtro.DataSource = gestorUsu.Listar();
                CBX_Filtro.DisplayMember = "Usuario";
                CBX_Filtro.ValueMember = "Id";
            }
            else if (entidadSeleccionada == "Productos")
            {
                BLL.PRODUCTO gestorProd = new BLL.PRODUCTO();
                CBX_Filtro.DataSource = gestorProd.Listar();
                CBX_Filtro.DisplayMember = "Nombre";
                CBX_Filtro.ValueMember = "Id";
            }

            CBX_Filtro.SelectedIndex = -1;
            CBX_Filtro.SelectedIndexChanged += CBX_Filtro_SelectedIndexChanged;
        }

        private void CargarGrillaGeneral(string entidad)
        {
            try
            {
                DGVHistorial.DataSource = null;

                if (entidad == "Usuarios")
                {
                    BLL.HISTORIAL_USUARIO gestorHistUsu = new BLL.HISTORIAL_USUARIO();
                    List<BE.HISTORIAL_USUARIO> listaUsuarios = gestorHistUsu.Listar();

                    DGVHistorial.DataSource = listaUsuarios;
                }
                else if (entidad == "Productos")
                {
                    BLL.HISTORIAL_PRODUCTO gestorHistProd = new BLL.HISTORIAL_PRODUCTO();
                    List<BE.HISTORIAL_PRODUCTO> listaProductos = gestorHistProd.Listar();

                    DGVHistorial.DataSource = listaProductos;
                }

                DGVHistorial.ReadOnly = true;
                DGVHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                AplicarFormatoGrilla(entidad);
                ActualizarEstadoBotonRestaurar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el historial de {entidad}: {ex.Message}",
                                "Error de Arquitectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBX_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBX_Filtro.SelectedItem == null || CBX_Entidad.SelectedItem == null) return;

            try
            {
                string entidadActiva = CBX_Entidad.SelectedItem.ToString();
                int idSeleccionado = (int)CBX_Filtro.SelectedValue;

                if (entidadActiva == "Usuarios")
                {
                    BLL.HISTORIAL_USUARIO gestorHistUsu = new BLL.HISTORIAL_USUARIO();
                    var historialCompleto = gestorHistUsu.Listar();

                    var historialFiltrado = historialCompleto.Where(h => h.Id == idSeleccionado).ToList();

                    DGVHistorial.DataSource = null;
                    DGVHistorial.DataSource = historialFiltrado;
                }
                else if (entidadActiva == "Productos")
                {
                    BLL.HISTORIAL_PRODUCTO gestorHistProd = new BLL.HISTORIAL_PRODUCTO();
                    var historialCompleto = gestorHistProd.Listar();

                    var historialFiltrado = historialCompleto.Where(h => h.IdProducto == idSeleccionado).ToList();

                    DGVHistorial.DataSource = null;
                    DGVHistorial.DataSource = historialFiltrado;
                }
                AplicarFormatoGrilla(entidadActiva);
                ActualizarEstadoBotonRestaurar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al filtrar");
            }
        }

        private void BTN_LimpiarFiltrosHist_Click(object sender, EventArgs e)
        {
            CBX_Filtro.SelectedIndex = -1;

            if (CBX_Entidad.SelectedItem != null)
            {
                CargarGrillaGeneral(CBX_Entidad.SelectedItem.ToString());
            }
        }

        private void ActualizarEstadoBotonRestaurar()
        {
            // 1. Si no hay nada seleccionado, apagamos el botón por seguridad
            if (DGVHistorial.CurrentRow == null || DGVHistorial.CurrentRow.DataBoundItem == null || CBX_Entidad.SelectedItem == null)
            {
                BTNrestaurar.Enabled = false;
                return;
            }

            string entidadSeleccionada = CBX_Entidad.SelectedItem.ToString();

            if (entidadSeleccionada == "Usuarios")
            {
                if (DGVHistorial.CurrentRow.DataBoundItem is BE.HISTORIAL_USUARIO version)
                {
                    BLL.USUARIO gestorUsu = new BLL.USUARIO();
                    BE.USUARIO usuActual = gestorUsu.Listar().FirstOrDefault(u => u.Id == version.Id);

                    BTNrestaurar.Enabled = (usuActual != null && usuActual.Activo == true);
                }
                else
                {
                    BTNrestaurar.Enabled = false;
                }
            }
            else if (entidadSeleccionada == "Productos")
            {
                if (DGVHistorial.CurrentRow.DataBoundItem is BE.HISTORIAL_PRODUCTO version)
                {
                    BLL.PRODUCTO gestorProd = new BLL.PRODUCTO();
                    BE.PRODUCTO prodActual = gestorProd.Listar().FirstOrDefault(p => p.Id == version.IdProducto);

                    BTNrestaurar.Enabled = (prodActual != null && prodActual.Activo == true);
                }
                else
                {
                    BTNrestaurar.Enabled = false;
                }
            }
        }
        private void AplicarFormatoGrilla(string entidadSeleccionada)
        {
            if (DGVHistorial.Columns.Count == 0) return;

            if (DGVHistorial.Columns["Id"] != null) DGVHistorial.Columns["Id"].Visible = false;
            if (DGVHistorial.Columns["IdHistorial"] != null) DGVHistorial.Columns["IdHistorial"].Visible = false;

            if (entidadSeleccionada == "Usuarios")
            {
                if (DGVHistorial.Columns["Contraseña"] != null) DGVHistorial.Columns["Contraseña"].Visible = false;
                if (DGVHistorial.Columns["DVH"] != null) DGVHistorial.Columns["DVH"].Visible = false;
                if (DGVHistorial.Columns["IntentosFallidos"] != null) DGVHistorial.Columns["IntentosFallidos"].Visible = false;
                if (DGVHistorial.Columns["IdIdioma"] != null) DGVHistorial.Columns["IdIdioma"].Visible = false;
                if (DGVHistorial.Columns["UsuarioAccion"] != null) DGVHistorial.Columns["UsuarioAccion"].HeaderText = "Responsable";
                if (DGVHistorial.Columns["TipoAccion"] != null) DGVHistorial.Columns["TipoAccion"].HeaderText = "Acción Realizada";
                if (DGVHistorial.Columns["FechaCambio"] != null) DGVHistorial.Columns["FechaCambio"].HeaderText = "Fecha de Cambio";
            }

            else if (entidadSeleccionada == "Productos")
            {
                if (DGVHistorial.Columns["IdProducto"] != null) DGVHistorial.Columns["Idproducto"].Visible = false;
                if (DGVHistorial.Columns["UsuarioAccion"] != null) DGVHistorial.Columns["UsuarioAccion"].HeaderText = "Responsable";
                if (DGVHistorial.Columns["TipoAccion"] != null) DGVHistorial.Columns["TipoAccion"].HeaderText = "Acción Realizada";
                if (DGVHistorial.Columns["FechaCambio"] != null) DGVHistorial.Columns["FechaCambio"].HeaderText = "Fecha de Cambio";
                if (DGVHistorial.Columns["Precio"] != null) DGVHistorial.Columns["Precio"].DefaultCellStyle.Format = "C2";
            }
        }

        private void DGVHistorial_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotonRestaurar();
        }
    }
}
