namespace Trabajo_practico_IS
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AdministracionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeIdiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restauracionDeBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LBLbienvenida = new System.Windows.Forms.Label();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidioma = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnCerrarSesion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrarSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCerrarSesion.Location = new System.Drawing.Point(606, 386);
            this.BtnCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(145, 33);
            this.BtnCerrarSesion.TabIndex = 0;
            this.BtnCerrarSesion.Text = "Cerrar Sesion";
            this.BtnCerrarSesion.UseVisualStyleBackColor = false;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdministracionMenuItem,
            this.BitacoraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(762, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AdministracionMenuItem
            // 
            this.AdministracionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlDeUsuariosToolStripMenuItem,
            this.controlDePermisosToolStripMenuItem,
            this.controlDeIdiomasToolStripMenuItem,
            this.restauracionDeBaseToolStripMenuItem,
            this.historialDeCambiosToolStripMenuItem,
            this.productosToolStripMenuItem});
            this.AdministracionMenuItem.Name = "AdministracionMenuItem";
            this.AdministracionMenuItem.Size = new System.Drawing.Size(116, 21);
            this.AdministracionMenuItem.Text = "Administración";
            // 
            // controlDeUsuariosToolStripMenuItem
            // 
            this.controlDeUsuariosToolStripMenuItem.Name = "controlDeUsuariosToolStripMenuItem";
            this.controlDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.controlDeUsuariosToolStripMenuItem.Tag = "ABM_USUARIO";
            this.controlDeUsuariosToolStripMenuItem.Text = "Control de usuarios";
            this.controlDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.controlDeUsuariosToolStripMenuItem_Click);
            // 
            // controlDePermisosToolStripMenuItem
            // 
            this.controlDePermisosToolStripMenuItem.Name = "controlDePermisosToolStripMenuItem";
            this.controlDePermisosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.controlDePermisosToolStripMenuItem.Tag = "ABM_PERMISOS";
            this.controlDePermisosToolStripMenuItem.Text = "Control de permisos";
            this.controlDePermisosToolStripMenuItem.Click += new System.EventHandler(this.controlDePermisosToolStripMenuItem_Click);
            // 
            // controlDeIdiomasToolStripMenuItem
            // 
            this.controlDeIdiomasToolStripMenuItem.Name = "controlDeIdiomasToolStripMenuItem";
            this.controlDeIdiomasToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.controlDeIdiomasToolStripMenuItem.Tag = "ABM_IDIOMAS";
            this.controlDeIdiomasToolStripMenuItem.Text = "Control de idiomas";
            this.controlDeIdiomasToolStripMenuItem.Click += new System.EventHandler(this.controlDeIdiomasToolStripMenuItem_Click);
            // 
            // restauracionDeBaseToolStripMenuItem
            // 
            this.restauracionDeBaseToolStripMenuItem.Name = "restauracionDeBaseToolStripMenuItem";
            this.restauracionDeBaseToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.restauracionDeBaseToolStripMenuItem.Tag = "RESTAURACION_BASE";
            this.restauracionDeBaseToolStripMenuItem.Text = "Control de restauracion";
            this.restauracionDeBaseToolStripMenuItem.Click += new System.EventHandler(this.restauracionDeBaseToolStripMenuItem_Click);
            // 
            // historialDeCambiosToolStripMenuItem
            // 
            this.historialDeCambiosToolStripMenuItem.Name = "historialDeCambiosToolStripMenuItem";
            this.historialDeCambiosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.historialDeCambiosToolStripMenuItem.Tag = "HISTORIAL_CAMBIOS";
            this.historialDeCambiosToolStripMenuItem.Text = "Historial de cambios";
            this.historialDeCambiosToolStripMenuItem.Click += new System.EventHandler(this.historialDeCambiosToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.productosToolStripMenuItem.Tag = "ABM_PRODUCTOS";
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // BitacoraToolStripMenuItem
            // 
            this.BitacoraToolStripMenuItem.Name = "BitacoraToolStripMenuItem";
            this.BitacoraToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.BitacoraToolStripMenuItem.Tag = "BITACORA";
            this.BitacoraToolStripMenuItem.Text = "Bitacora";
            this.BitacoraToolStripMenuItem.Click += new System.EventHandler(this.BitacoraToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LBLbienvenida
            // 
            this.LBLbienvenida.AutoSize = true;
            this.LBLbienvenida.Font = new System.Drawing.Font("Century Gothic", 30F);
            this.LBLbienvenida.Location = new System.Drawing.Point(4, 44);
            this.LBLbienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLbienvenida.Name = "LBLbienvenida";
            this.LBLbienvenida.Size = new System.Drawing.Size(239, 49);
            this.LBLbienvenida.TabIndex = 9;
            this.LBLbienvenida.Text = "Bienvenido";
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(607, 64);
            this.CBXidiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(140, 25);
            this.CBXidiomas.TabIndex = 10;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidioma
            // 
            this.LBLidioma.AutoSize = true;
            this.LBLidioma.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLidioma.Location = new System.Drawing.Point(603, 44);
            this.LBLidioma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidioma.Name = "LBLidioma";
            this.LBLidioma.Size = new System.Drawing.Size(59, 17);
            this.LBLidioma.TabIndex = 11;
            this.LBLidioma.Text = "Idiomas";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(762, 428);
            this.Controls.Add(this.LBLidioma);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.LBLbienvenida);
            this.Controls.Add(this.BtnCerrarSesion);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bibliotech";
            this.Activated += new System.EventHandler(this.FrmMenuPrincipal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AdministracionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BitacoraToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label LBLbienvenida;
        private System.Windows.Forms.ToolStripMenuItem controlDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDePermisosToolStripMenuItem;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidioma;
        private System.Windows.Forms.ToolStripMenuItem controlDeIdiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restauracionDeBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeCambiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
    }
}

