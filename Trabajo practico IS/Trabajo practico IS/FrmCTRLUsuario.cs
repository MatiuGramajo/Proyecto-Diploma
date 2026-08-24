using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    public partial class FrmCTRLUsuario : Form,BE.IObserver
    {

        BLL.USUARIO GestorUsuarios = new BLL.USUARIO();
        BLL.BITACORA GestorBitacora = new BLL.BITACORA();
        BLL.PERMISO GestorPermisos = new BLL.PERMISO();
        BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        BE.USUARIO usuario;

        public FrmCTRLUsuario()
        {
            InitializeComponent();
        }

        private void FrmCTRLUsuario_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged+= CBXidiomas_SelectedIndexChanged;
            ActualizarIdioma();
            EnlazarUsuarios();
            CargarComboBoxRoles();
            Cb_CTRLUsuarioRol.SelectedIndex = -1;

            ActualizarEstadoBotones();
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


        public void EnlazarUsuarios()
        {
            var ListaUsuarios = GestorUsuarios.Listar().AsEnumerable();

            if (CKXmostrarbloqueados.Checked==false)
            {
                ListaUsuarios = ListaUsuarios.Where(u => u.EstadoBloqueado == false);
            }
            
            if (CKXmostrarInactivos.Checked == false)
            {
                ListaUsuarios = ListaUsuarios.Where(u => u.Activo == true);
            }

            DGV_CtrlUsuUsuarios.DataSource = null;
            DGV_CtrlUsuUsuarios.DataSource = ListaUsuarios.ToList();
            DGV_CtrlUsuUsuarios.ReadOnly = true;
            DGV_CtrlUsuUsuarios.Columns["Id"].Visible = false;
            DGV_CtrlUsuUsuarios.Columns["Contraseña"].Visible = false;
            DGV_CtrlUsuUsuarios.Columns["IntentosFallidos"].Visible = false;
            DGV_CtrlUsuUsuarios.Columns["DVH"].Visible = false;
            DGV_CtrlUsuUsuarios.Columns["Activo"].Visible = false;
        }

        private void BTNCtrlUsuAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TXT_CtrlUsuUsuario.Text) || string.IsNullOrEmpty(TXT_CtrlUsuContraseña.Text) || string.IsNullOrEmpty(TXT_CtrlUsuDNI.Text) || string.IsNullOrEmpty(TXT_CtrlUsuEmail.Text) || Cb_CTRLUsuarioRol.SelectedItem==null))
                {
                    BE.USUARIO usuario = new BE.USUARIO();
                    BE.COMPONENTE rolSeleccionado = (BE.COMPONENTE)Cb_CTRLUsuarioRol.SelectedItem;

                    usuario.Usuario = TXT_CtrlUsuUsuario.Text;
                    usuario.Contraseña = ENCRIPTADOR.Hashear(TXT_CtrlUsuContraseña.Text);
                    usuario.Dni = int.Parse(TXT_CtrlUsuDNI.Text);
                    usuario.Email = TXT_CtrlUsuEmail.Text;
                    usuario.Permisos.Add(rolSeleccionado);

                    BE.USUARIO inactivoDuplicado = GestorUsuarios.ObtenerInactivoDuplicado(usuario);

                    if (inactivoDuplicado != null)
                    {
                        var result = MessageBox.Show("El DNI o Nombre ingresado pertenece a una cuenta inactiva.\n\n¿Desea reactivar la cuenta original?",
                                                     "Usuario Inactivo Detectado",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            GestorUsuarios.Reactivar(inactivoDuplicado);
                            GestorBitacora.RegistrarEvento("Administracion", $"Se reactivó al usuario {inactivoDuplicado.Usuario}", 3);
                            MessageBox.Show("La cuenta original ha sido reactivada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            EnlazarUsuarios();
                            LimpiarControles();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }

                    GestorUsuarios.Insertar(usuario);
                    GestorBitacora.RegistrarEvento("Administracion", $"Se dio de alta al usuario {usuario.Usuario}", 2);
                    EnlazarUsuarios();
                    LimpiarControles();
                }
                else
                {
                    throw new Exception("Debe completar todos los datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void LimpiarControles()
        {
            TXT_CtrlUsuUsuario.Text = "";
            TXT_CtrlUsuContraseña.Text = "";
            TXT_CtrlUsuDNI.Text = "";
            TXT_CtrlUsuEmail.Text = "";
            Cb_CTRLUsuarioRol.SelectedIndex = -1;
            usuario = null;

            ActualizarEstadoBotones();
        }
        private void BTNCtrlUsuBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuario != null && usuario.Activo == true)
                {
                    var result = MessageBox.Show($"¿Esta seguro que desea dar de baja a: {usuario.Usuario}?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        GestorUsuarios.Borrar(usuario);
                        GestorBitacora.RegistrarEvento("Administracion", $"Se dio de baja al usuario {usuario.Usuario}", 4);
                        EnlazarUsuarios();
                        LimpiarControles();
                        usuario = null;
                        ActualizarEstadoBotones();
                    }
                }
                else
                {
                    throw new Exception("Seleccione un usuario para borrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void BTNCtrlUsuModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuario != null && !(string.IsNullOrEmpty(TXT_CtrlUsuUsuario.Text) || string.IsNullOrEmpty(TXT_CtrlUsuDNI.Text) || string.IsNullOrEmpty(TXT_CtrlUsuEmail.Text)))
                {
                    usuario.Usuario = TXT_CtrlUsuUsuario.Text;
                    if (!string.IsNullOrEmpty(TXT_CtrlUsuContraseña.Text))
                    {
                        usuario.Contraseña = ENCRIPTADOR.Hashear(TXT_CtrlUsuContraseña.Text);
                    }
                    usuario.Dni = int.Parse(TXT_CtrlUsuDNI.Text);
                    usuario.Email = TXT_CtrlUsuEmail.Text;

                    usuario.Permisos.Clear();

                    if (Cb_CTRLUsuarioRol.SelectedItem != null)
                    {
                        BE.COMPONENTE rolSeleccionado = (BE.COMPONENTE)Cb_CTRLUsuarioRol.SelectedItem;
                        usuario.Permisos.Add(rolSeleccionado);
                    }
                    else
                    {
                        throw new Exception("El usuario debe tener al menos un rol asignado para poder operar en el sistema.");
                    }

                    GestorUsuarios.Modificar(usuario);
                    EnlazarUsuarios();
                    GestorBitacora.RegistrarEvento("Administracion", $"Se modificó al usuario: {usuario.Usuario}", 3);
                    LimpiarControles();
                }
                else
                {
                    throw new Exception("Seleccione un campo para modificar.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                EnlazarUsuarios();
            }

        }

        private void BTNCtrlUsuDesbloquear_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                if (usuario.EstadoBloqueado == true)
                {
                    usuario.EstadoBloqueado = false;
                    usuario.IntentosFallidos = 0;
                    GestorUsuarios.DesbloquearUsuario(usuario);
                    GestorBitacora.RegistrarEvento("Administracion", $"Se desbloqueó manualmente al usuario {usuario.Usuario}", 3);
                    MessageBox.Show($"El usuario {usuario.Usuario} ha sido desbloqueado con éxito.");
                    EnlazarUsuarios();
                }
                else
                {
                    MessageBox.Show("El usuario seleccionado no se encuentra bloqueado.");
                }
            }
            else
            {
                MessageBox.Show("Primero seleccione un usuario para desbloquearlo.");
            }
        }

        private void BTNCtrlUsuVolverMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DGV_CtrlUsuUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                usuario = DGV_CtrlUsuUsuarios.Rows[e.RowIndex].DataBoundItem as BE.USUARIO;

                TXT_CtrlUsuUsuario.Text = usuario.Usuario;
                TXT_CtrlUsuContraseña.Text = "";
                TXT_CtrlUsuDNI.Text = usuario.Dni.ToString();
                TXT_CtrlUsuEmail.Text = usuario.Email;

                usuario.Permisos = GestorPermisos.ObtenerPermisosUsuario(usuario.Id);
                Cb_CTRLUsuarioRol.SelectedIndex = -1;

                if (usuario.Permisos != null && usuario.Permisos.Count > 0)
                {
                    BE.COMPONENTE permisoActual = usuario.Permisos[0];
                    Cb_CTRLUsuarioRol.SelectedValue = permisoActual.Id;
                }

                ActualizarEstadoBotones();
            }
        }

        private void ActualizarEstadoBotones()
        {

            if (usuario == null)
            {
                BTNCtrlUsuModificar.Enabled = false;
                BTNCtrlUsuBaja.Enabled = false;
                BTNCtrlUsuReactivar.Enabled = false;
                BTNCtrlUsuDesbloquear.Enabled = false;
                return;
            }

            if (usuario.Id == Servicios.SESION.GetInstancia().usuactual.Id)
            {
                BTNCtrlUsuModificar.Enabled = false;
                BTNCtrlUsuBaja.Enabled = false;
                BTNCtrlUsuReactivar.Enabled = false;
                BTNCtrlUsuDesbloquear.Enabled = false;
            }
            else
            {

                if (usuario.Activo == false)
                {
                    BTNCtrlUsuModificar.Enabled = false;
                    BTNCtrlUsuBaja.Enabled = false;
                    BTNCtrlUsuReactivar.Enabled = true;
                    BTNCtrlUsuDesbloquear.Enabled = false;
                }

                else
                {
                    BTNCtrlUsuModificar.Enabled = true;
                    BTNCtrlUsuBaja.Enabled = true;
                    BTNCtrlUsuReactivar.Enabled = false;
                    BTNCtrlUsuDesbloquear.Enabled = usuario.EstadoBloqueado;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            EnlazarUsuarios();
            LimpiarControles();
            usuario = null;
        }

        private void CargarComboBoxRoles()
        {
            List<BE.COMPONENTE> todosLosPermisos = GestorPermisos.Listar();

            List<BE.COMPONENTE> soloRoles = todosLosPermisos.Where(p => p.EsCompuesto).ToList();

            Cb_CTRLUsuarioRol.DataSource = soloRoles;
            Cb_CTRLUsuarioRol.DisplayMember = "Nombre";
            Cb_CTRLUsuarioRol.ValueMember = "Id";
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

        private void FrmCTRLUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        private void CKXmostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            EnlazarUsuarios();
            LimpiarControles();
            usuario = null;
        }

        private void BTNCtrlUsuReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuario != null && usuario.Activo == false)
                {
                    var result = MessageBox.Show($"¿Desea reactivar a: {usuario.Usuario}?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        GestorUsuarios.Reactivar(usuario);
                        GestorBitacora.RegistrarEvento("Administracion", $"Se reactivó al usuario {usuario.Usuario}", 3);
                        EnlazarUsuarios();
                        LimpiarControles();
                        usuario = null;
                        ActualizarEstadoBotones();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario inactivo para reactivar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Reactivar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
