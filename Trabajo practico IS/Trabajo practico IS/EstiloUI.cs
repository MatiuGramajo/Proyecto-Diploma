using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    public static class EstiloUI
    {
        // Paleta de colores moderna (Azul Corporativo + Gris Pizarra)
        private static readonly Color ColorFondoForm = Color.FromArgb(244, 246, 249);
        private static readonly Color ColorPrimario = Color.FromArgb(30, 58, 138);     // Azul profundo
        private static readonly Color ColorSecundario = Color.FromArgb(71, 85, 105);   // Gris pizarra
        private static readonly Color ColorPeligro = Color.FromArgb(185, 28, 28);      // Rojo sobrio
        private static readonly Color ColorExito = Color.FromArgb(21, 128, 61);        // Verde sobrio
        private static readonly Color ColorTexto = Color.FromArgb(30, 41, 59);
        private static readonly Color ColorGrillaHeader = Color.FromArgb(30, 41, 59);
        private static readonly Color ColorGrillaAlterno = Color.FromArgb(248, 250, 252);
        private static readonly Color ColorGrillaSeleccion = Color.FromArgb(219, 234, 254);

        private static readonly Font FuenteBase = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        private static readonly Font FuenteNegrita = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        private static readonly Font FuenteTitulo = new Font("Segoe UI", 13F, FontStyle.Bold);

        private class MedidasOriginales
        {
            public Rectangle Bounds { get; set; }
            public float FontSize { get; set; }
        }

        public static void Aplicar(Form form)
        {
            form.BackColor = ColorFondoForm;
            form.Font = FuenteBase;

            // 1. Aplicar estilos visuales (colores, fuentes, grillas)
            AplicarEstilosEnControles(form.Controls);

            // 2. Guardar medidas originales del diseñador ANTES de maximizar
            Size tamanoBaseForm = form.ClientSize;
            var mapaMedidas = new Dictionary<Control, MedidasOriginales>();
            GuardarMedidas(form.Controls, mapaMedidas);

            // 3. Suscribir escalado proporcional cuando el form se maximice o cambie de tamaño
            form.Load += (s, e) => EscalarControles(form, tamanoBaseForm, mapaMedidas);
            form.Resize += (s, e) => EscalarControles(form, tamanoBaseForm, mapaMedidas);

            // 4. Abrir el formulario ocupando toda la pantalla
            // (Si querés que el Login no se maximice, descomenta la siguiente línea:)
            if (form.Name.ToLower().Contains("login")) return;
            form.WindowState = FormWindowState.Maximized;
        }

        private static void AplicarEstilosEnControles(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is Button btn)
                {
                    EstilizarBoton(btn);
                }
                else if (ctrl is DataGridView dgv)
                {
                    EstilizarGrilla(dgv);
                }
                else if (ctrl is Label lbl)
                {
                    EstilizarLabel(lbl);
                }
                else if (ctrl is TextBox txt)
                {
                    txt.Font = FuenteBase;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.Font = FuenteBase;
                    cmb.FlatStyle = FlatStyle.Flat;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Font = FuenteBase;
                }
                else if (ctrl is GroupBox grp)
                {
                    grp.Font = FuenteNegrita;
                    grp.ForeColor = ColorPrimario;
                }
                else if (ctrl is MenuStrip menu)
                {
                    menu.BackColor = Color.White;
                    menu.ForeColor = ColorTexto;
                    menu.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                    menu.Padding = new Padding(10, 8, 10, 8);
                }
                if (ctrl.HasChildren)
                {
                    AplicarEstilosEnControles(ctrl.Controls);
                }
            }
        }

        private static void GuardarMedidas(Control.ControlCollection controles, Dictionary<Control, MedidasOriginales> mapa)
        {
            foreach (Control ctrl in controles)
            {
                mapa[ctrl] = new MedidasOriginales
                {
                    Bounds = ctrl.Bounds,
                    FontSize = ctrl.Font.Size
                };

                if (ctrl.HasChildren)
                {
                    GuardarMedidas(ctrl.Controls, mapa);
                }
            }
        }

        private static void EscalarControles(Form form, Size tamanoBase, Dictionary<Control, MedidasOriginales> mapa)
        {
            if (tamanoBase.Width <= 0 || tamanoBase.Height <= 0) return;
            if (form.ClientSize.Width <= 0 || form.ClientSize.Height <= 0) return;

            float factorX = (float)form.ClientSize.Width / tamanoBase.Width;
            float factorY = (float)form.ClientSize.Height / tamanoBase.Height;

            // Escalado suave de tipografía (crece hasta un 30% en pantallas grandes sin desbordar botones)
            float factorMin = Math.Min(factorX, factorY);
            float factorFuente = Math.Max(0.9F, Math.Min(1.30F, 1F + (factorMin - 1F) * 0.35F));

            form.SuspendLayout();
            AplicarEscalaRecursiva(form.Controls, factorX, factorY, factorFuente, mapa);
            form.ResumeLayout(true);
        }

        private static void AplicarEscalaRecursiva(
            Control.ControlCollection controles,
            float factorX,
            float factorY,
            float factorFuente,
            Dictionary<Control, MedidasOriginales> mapa)
        {
            foreach (Control ctrl in controles)
            {
                // TabPage se redimensiona solo junto con su TabControl, solo escalamos lo que tiene adentro
                if (!(ctrl is TabPage) && mapa.TryGetValue(ctrl, out MedidasOriginales orig))
                {
                    int nuevoX = (int)Math.Round(orig.Bounds.X * factorX);
                    int nuevoY = (int)Math.Round(orig.Bounds.Y * factorY);
                    int nuevoAncho = (int)Math.Round(orig.Bounds.Width * factorX);
                    int nuevoAlto = (int)Math.Round(orig.Bounds.Height * factorY);

                    ctrl.SetBounds(nuevoX, nuevoY, nuevoAncho, nuevoAlto);

                    float nuevoTamanoFuente = orig.FontSize * factorFuente;
                    if (Math.Abs(ctrl.Font.Size - nuevoTamanoFuente) > 0.2F)
                    {
                        ctrl.Font = new Font(ctrl.Font.FontFamily, nuevoTamanoFuente, ctrl.Font.Style);
                    }
                }

                if (ctrl.HasChildren)
                {
                    AplicarEscalaRecursiva(ctrl.Controls, factorX, factorY, factorFuente, mapa);
                }
            }
        }

        private static void EstilizarBoton(Button btn)
        {
            string nombre = btn.Name.ToLower();

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = FuenteNegrita;
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;

            if (nombre.Contains("eliminar") || nombre.Contains("baja") || nombre.Contains("anular") ||
                nombre.Contains("cancelar") || nombre.Contains("salir") || nombre.Contains("cerrar"))
            {
                btn.BackColor = ColorPeligro;
            }
            else if (nombre.Contains("confirmar") || nombre.Contains("guardar") || nombre.Contains("registrar") ||
                     nombre.Contains("emitir") || nombre.Contains("aprobar") || nombre.Contains("saldar"))
            {
                btn.BackColor = ColorExito;
            }
            else if (nombre.Contains("limpiar") || nombre.Contains("buscar") || nombre.Contains("consultar") ||
                     nombre.Contains("imprimir") || nombre.Contains("exportar") || nombre.Contains("volver"))
            {
                btn.BackColor = ColorSecundario;
            }
            else
            {
                btn.BackColor = ColorPrimario;
            }
        }

        private static void EstilizarGrilla(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;

            // Hacer que las columnas ocupen todo el ancho de la grilla siempre
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DataBindingComplete += (s, e) =>
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            };

            // Encabezado
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorGrillaHeader;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;

            // Filas
            dgv.DefaultCellStyle.Font = FuenteBase;
            dgv.DefaultCellStyle.ForeColor = ColorTexto;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = ColorGrillaSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = ColorTexto;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorGrillaAlterno;
            dgv.RowTemplate.Height = 30;
        }

        private static void EstilizarLabel(Label lbl)
        {
            if (lbl.Font.Size >= 12F || lbl.Name.ToLower().Contains("titulo"))
            {
                lbl.Font = FuenteTitulo;
                lbl.ForeColor = ColorPrimario;
            }
            else
            {
                lbl.Font = lbl.Font.Bold ? FuenteNegrita : FuenteBase;
                lbl.ForeColor = ColorTexto;
            }
        }
        //// Paleta de colores moderna (Azul Corporativo + Gris Pizarra)
        //private static readonly Color ColorFondoForm = Color.FromArgb(244, 246, 249);
        //private static readonly Color ColorPrimario = Color.FromArgb(30, 58, 138);     // Azul profundo
        //private static readonly Color ColorSecundario = Color.FromArgb(71, 85, 105);   // Gris pizarra
        //private static readonly Color ColorPeligro = Color.FromArgb(185, 28, 28);      // Rojo sobrio
        //private static readonly Color ColorExito = Color.FromArgb(21, 128, 61);        // Verde sobrio
        //private static readonly Color ColorTexto = Color.FromArgb(30, 41, 59);
        //private static readonly Color ColorGrillaHeader = Color.FromArgb(30, 41, 59);
        //private static readonly Color ColorGrillaAlterno = Color.FromArgb(248, 250, 252);
        //private static readonly Color ColorGrillaSeleccion = Color.FromArgb(219, 234, 254);

        //private static readonly Font FuenteBase = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        //private static readonly Font FuenteNegrita = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        //private static readonly Font FuenteTitulo = new Font("Segoe UI", 13F, FontStyle.Bold);

        //public static void Aplicar(Form form)
        //{
        //    form.BackColor = ColorFondoForm;
        //    form.Font = FuenteBase;

        //    if (form.StartPosition == FormStartPosition.WindowsDefaultLocation)
        //        form.StartPosition = FormStartPosition.CenterScreen;

        //    AplicarEnControles(form.Controls);
        //}

        //private static void AplicarEnControles(Control.ControlCollection controles)
        //{
        //    foreach (Control ctrl in controles)
        //    {
        //        if (ctrl is Button btn)
        //        {
        //            EstilizarBoton(btn);
        //        }
        //        else if (ctrl is DataGridView dgv)
        //        {
        //            EstilizarGrilla(dgv);
        //        }
        //        else if (ctrl is Label lbl)
        //        {
        //            EstilizarLabel(lbl);
        //        }
        //        else if (ctrl is TextBox txt)
        //        {
        //            txt.Font = FuenteBase;
        //            txt.BorderStyle = BorderStyle.FixedSingle;
        //        }
        //        else if (ctrl is ComboBox cmb)
        //        {
        //            cmb.Font = FuenteBase;
        //            cmb.FlatStyle = FlatStyle.Flat;
        //        }
        //        else if (ctrl is DateTimePicker dtp)
        //        {
        //            dtp.Font = FuenteBase;
        //        }
        //        else if (ctrl is GroupBox grp)
        //        {
        //            grp.Font = FuenteNegrita;
        //            grp.ForeColor = ColorPrimario;
        //        }

        //        // Recursividad para paneles, pestañas, groupboxes, etc.
        //        if (ctrl.HasChildren)
        //        {
        //            AplicarEnControles(ctrl.Controls);
        //        }
        //    }
        //}

        //private static void EstilizarBoton(Button btn)
        //{
        //    string nombre = btn.Name.ToLower();

        //    btn.FlatStyle = FlatStyle.Flat;
        //    btn.FlatAppearance.BorderSize = 0;
        //    btn.Font = FuenteNegrita;
        //    btn.ForeColor = Color.White;
        //    btn.Cursor = Cursors.Hand;

        //    // Asignación automática de color según la acción del botón
        //    if (nombre.Contains("eliminar") || nombre.Contains("baja") || nombre.Contains("anular") ||
        //        nombre.Contains("cancelar") || nombre.Contains("salir") || nombre.Contains("cerrar"))
        //    {
        //        btn.BackColor = ColorPeligro;
        //    }
        //    else if (nombre.Contains("confirmar") || nombre.Contains("guardar") || nombre.Contains("registrar") ||
        //             nombre.Contains("emitir") || nombre.Contains("aprobar") || nombre.Contains("saldar"))
        //    {
        //        btn.BackColor = ColorExito;
        //    }
        //    else if (nombre.Contains("limpiar") || nombre.Contains("buscar") || nombre.Contains("consultar") ||
        //             nombre.Contains("imprimir") || nombre.Contains("exportar") || nombre.Contains("volver"))
        //    {
        //        btn.BackColor = ColorSecundario;
        //    }
        //    else
        //    {
        //        btn.BackColor = ColorPrimario;
        //    }
        //}

        //private static void EstilizarGrilla(DataGridView dgv)
        //{
        //    dgv.BackgroundColor = Color.White;
        //    dgv.BorderStyle = BorderStyle.None;
        //    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        //    dgv.GridColor = Color.FromArgb(226, 232, 240);
        //    dgv.EnableHeadersVisualStyles = false;
        //    dgv.RowHeadersVisible = false;
        //    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgv.AllowUserToResizeRows = false;

        //    // Encabezado
        //    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        //    dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorGrillaHeader;
        //    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgv.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
        //    dgv.ColumnHeadersHeight = 32;

        //    // Filas
        //    dgv.DefaultCellStyle.Font = FuenteBase;
        //    dgv.DefaultCellStyle.ForeColor = ColorTexto;
        //    dgv.DefaultCellStyle.BackColor = Color.White;
        //    dgv.DefaultCellStyle.SelectionBackColor = ColorGrillaSeleccion;
        //    dgv.DefaultCellStyle.SelectionForeColor = ColorTexto;
        //    dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorGrillaAlterno;
        //    dgv.RowTemplate.Height = 28;
        //}

        //private static void EstilizarLabel(Label lbl)
        //{
        //    // Respeta si ya era un título grande en el diseñador
        //    if (lbl.Font.Size >= 12F || lbl.Name.ToLower().Contains("titulo"))
        //    {
        //        lbl.Font = FuenteTitulo;
        //        lbl.ForeColor = ColorPrimario;
        //    }
        //    else
        //    {
        //        lbl.Font = lbl.Font.Bold ? FuenteNegrita : FuenteBase;
        //        lbl.ForeColor = ColorTexto;
        //    }
        //}
    }
}
