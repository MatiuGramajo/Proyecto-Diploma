using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS.Utilidades
{
    public static class GES_PERMISOS_GUI
    {
        public static void AplicarPermisos(Form formulario)
        {
            BE.USUARIO usuarioActual = SESION.GetInstancia().usuactual;
            if (usuarioActual == null) return;

            ValidarControlesRecursivo(formulario.Controls, usuarioActual);

            foreach (Control ctrl in formulario.Controls)
            {
                if (ctrl is MenuStrip menu)
                {
                    foreach (ToolStripMenuItem item in menu.Items)
                    {
                        ValidarMenuRecursivo(item, usuarioActual);
                    }
                }
            }
        }

        private static void ValidarControlesRecursivo(Control.ControlCollection controles, BE.USUARIO usuario)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl.Tag != null && !string.IsNullOrWhiteSpace(ctrl.Tag.ToString()))
                {
                    ctrl.Visible = usuario.TienePermiso(ctrl.Tag.ToString());
                }

                if (ctrl.HasChildren)
                {
                    ValidarControlesRecursivo(ctrl.Controls, usuario);
                }
            }
        }


        private static void ValidarMenuRecursivo(ToolStripMenuItem item, BE.USUARIO usuario)
        {
            if (item.Tag != null && !string.IsNullOrWhiteSpace(item.Tag.ToString()))
            {
                item.Visible = usuario.TienePermiso(item.Tag.ToString());
            }

            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenu)
                {
                    ValidarMenuRecursivo(subMenu, usuario);
                }
            }
        }

    }
}
