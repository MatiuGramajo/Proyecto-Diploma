using BE;
using BLL;
using Servicios;
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
    public partial class FrmCTRLPermiso : Form, BE.IObserver
    {
        BE.USUARIO UsuarioActual = SESION.GetInstancia().usuactual;
        BLL.PERMISO GestorPermisos = new BLL.PERMISO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        BLL.IDIOMA GestorIdioma= new BLL.IDIOMA();
        BE.COMPONENTE componenteSeleccionado;

        public FrmCTRLPermiso()
        {
            InitializeComponent();
        }

        private void FrmCTRLPermiso_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            ActualizarIdioma();
            CargarTreeView();
            CargarListBox();
        }

        private void CBXidiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBXidiomas.SelectedValue != null && int.TryParse(CBXidiomas.SelectedValue.ToString(), out int idIdioma))
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

        private void CargarTreeView()
        {
            TV_RolesPermisos.Nodes.Clear();
            List<BE.COMPONENTE> raices = GestorPermisos.ObtenerArbolCompleto();

            foreach (var componente in raices)
    {
                TreeNode nodoRaiz = new TreeNode(componente.Nombre);
                nodoRaiz.Tag = componente; 
                AgregarNodosRecursivos(nodoRaiz, componente);

                TV_RolesPermisos.Nodes.Add(nodoRaiz);
            }
            TV_RolesPermisos.ExpandAll();
        }

        private void AgregarNodosRecursivos(TreeNode nodoPadre, BE.COMPONENTE componentePadre)
        {
            int cantidad = componentePadre.GetCantidadHijos();
            for (int i = 0; i < cantidad; i++)
            {
                BE.COMPONENTE hijo = componentePadre.GetHijo(i);

                if (hijo != null)
                {
                    TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                    nodoHijo.Tag = hijo;
                    nodoPadre.Nodes.Add(nodoHijo);

                    AgregarNodosRecursivos(nodoHijo, hijo);
                }
            }
        }

        private void CargarListBox()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            var TodosLospermisos = GestorPermisos.Listar();

            var roles = TodosLospermisos.Where(x => x.EsCompuesto).ToArray();
            var permisos = TodosLospermisos.Where(x => !x.EsCompuesto).ToArray();
            listBox1.Items.AddRange(roles);
            listBox2.Items.AddRange(permisos);

        }

        private void BTNCtrlPermisoCrearRol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TXTCtrlPermisoNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el Rol.");
                return;
            }

            BE.PERMISO_COMPUESTO nuevoRol = new BE.PERMISO_COMPUESTO();
            nuevoRol.Nombre = TXTCtrlPermisoNombre.Text;

            GestorPermisos.GuardarComponente(nuevoRol);

            MessageBox.Show("Rol compuesto creado con éxito.");

            TXTCtrlPermisoNombre.Text = "";

            GestorBitacora.RegistrarEvento("Administracion", $"Se dio de alta el nuevo rol {nuevoRol.Nombre}", 2);
            CargarTreeView();
            CargarListBox();
        }

        private void BTNCtrlPermisoAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                BE.COMPONENTE Hijo = null;

                if (listBox1.SelectedItem != null)
                {
                    Hijo = listBox1.SelectedItem as BE.COMPONENTE;
                }
                else if (listBox2.SelectedItem != null)
                {
                    Hijo = listBox2.SelectedItem as BE.COMPONENTE;
                }

                if (Hijo == null)
                {
                    throw new Exception("Por favor, seleccione un ROL o PERMISO de las listas.");
                }
                if (TV_RolesPermisos.SelectedNode == null)
                {
                    throw new Exception("Por favor, seleccione un ROL del treeview.");
                }

                var Padre = TV_RolesPermisos.SelectedNode.Tag as BE.COMPONENTE;

                GestorPermisos.GuardarRelacion(Padre, Hijo);

                CargarTreeView();
                CargarListBox();
                GestorBitacora.RegistrarEvento("Administracion", $"Se asigno {Hijo.Nombre}, dentro del rol {Padre.Nombre}", 2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BTNCtrlPermisoDesasignar_Click(object sender, EventArgs e)
        {
            try
            {

                if (TV_RolesPermisos.SelectedNode == null)
                {
                    throw new Exception("Por favor, seleccione un ROL del treeview.");
                }
                if (TV_RolesPermisos.SelectedNode.Parent == null)
                {
                    MessageBox.Show("No puede desasignar un Rol principal (Raíz).", "Operación Inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                var Padre = TV_RolesPermisos.SelectedNode.Parent.Tag as BE.COMPONENTE;
                var Hijo = TV_RolesPermisos.SelectedNode.Tag as BE.COMPONENTE;

                DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea quitar '{Hijo.Nombre}' del rol '{Padre.Nombre}'?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    GestorPermisos.BorrarRelacion(Padre, Hijo);
                }

                CargarTreeView();
                CargarListBox();
                GestorBitacora.RegistrarEvento("Administracion", $"Se desasigno {Hijo.Nombre}, dentro del rol {Padre.Nombre}", 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
            if (CBXidiomas.Items.Count > 0)
            {
                CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
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

        private void FrmCTRLPermiso_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        private void TV_RolesPermisos_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            componenteSeleccionado = (BE.COMPONENTE)e.Node.Tag;
            TXTCtrlPermisoNombre.Text = componenteSeleccionado.Nombre;

            bool esRol = componenteSeleccionado.EsCompuesto;

            BTNCtrlPermisoBorrarRol.Enabled = esRol;
            BTNCtrlPermisoModifRol.Enabled = esRol;
        }

        private void BTNCtrlPermisoModifRol_Click(object sender, EventArgs e)
        {
            if (componenteSeleccionado != null && !string.IsNullOrWhiteSpace(TXTCtrlPermisoNombre.Text))
            {
                componenteSeleccionado.Nombre = TXTCtrlPermisoNombre.Text;

                GestorPermisos.Modificar(componenteSeleccionado);

                CargarTreeView();
                CargarListBox();
                GestorBitacora.RegistrarEvento("Administracion", $"Se Se modifico el Rol/Permiso {componenteSeleccionado.Nombre}", 2);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Rol");
            }
        }

        private void BTNCtrlPermisoBorrarRol_Click(object sender, EventArgs e)
        {
            if (componenteSeleccionado != null)
            {
                DialogResult respuesta = MessageBox.Show($"¿Está seguro de eliminar el rol '{componenteSeleccionado.Nombre}' por completo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        GestorPermisos.Baja(componenteSeleccionado);
                        MessageBox.Show("Rol eliminado.");
                        CargarTreeView();
                        CargarListBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Rol para borrar");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.ClearSelected();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.ClearSelected();
            }
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
    }
}
