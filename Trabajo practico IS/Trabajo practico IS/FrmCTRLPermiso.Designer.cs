namespace Trabajo_practico_IS
{
    partial class FrmCTRLPermiso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TV_RolesPermisos = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BTNCtrlPermisoCrearRol = new System.Windows.Forms.Button();
            this.TXTCtrlPermisoNombre = new System.Windows.Forms.TextBox();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.BTNCtrlPermisoAsignar = new System.Windows.Forms.Button();
            this.BTNCtrlPermisoDesasignar = new System.Windows.Forms.Button();
            this.GB_ListRoles = new System.Windows.Forms.GroupBox();
            this.GB_TreeViewRoles = new System.Windows.Forms.GroupBox();
            this.GB_NuevoRol = new System.Windows.Forms.GroupBox();
            this.BTNCtrlPermisoModifRol = new System.Windows.Forms.Button();
            this.BTNCtrlPermisoBorrarRol = new System.Windows.Forms.Button();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.GB_ListPermisos = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.BTNvolveralmenu = new System.Windows.Forms.Button();
            this.GB_ListRoles.SuspendLayout();
            this.GB_TreeViewRoles.SuspendLayout();
            this.GB_NuevoRol.SuspendLayout();
            this.GB_ListPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // TV_RolesPermisos
            // 
            this.TV_RolesPermisos.HideSelection = false;
            this.TV_RolesPermisos.Location = new System.Drawing.Point(24, 27);
            this.TV_RolesPermisos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TV_RolesPermisos.Name = "TV_RolesPermisos";
            this.TV_RolesPermisos.Size = new System.Drawing.Size(213, 308);
            this.TV_RolesPermisos.TabIndex = 0;
            this.TV_RolesPermisos.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_RolesPermisos_NodeMouseClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(14, 27);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(231, 293);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // BTNCtrlPermisoCrearRol
            // 
            this.BTNCtrlPermisoCrearRol.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNCtrlPermisoCrearRol.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNCtrlPermisoCrearRol.Location = new System.Drawing.Point(10, 80);
            this.BTNCtrlPermisoCrearRol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNCtrlPermisoCrearRol.Name = "BTNCtrlPermisoCrearRol";
            this.BTNCtrlPermisoCrearRol.Size = new System.Drawing.Size(145, 33);
            this.BTNCtrlPermisoCrearRol.TabIndex = 2;
            this.BTNCtrlPermisoCrearRol.Text = "Crear";
            this.BTNCtrlPermisoCrearRol.UseVisualStyleBackColor = false;
            this.BTNCtrlPermisoCrearRol.Click += new System.EventHandler(this.BTNCtrlPermisoCrearRol_Click);
            // 
            // TXTCtrlPermisoNombre
            // 
            this.TXTCtrlPermisoNombre.Location = new System.Drawing.Point(10, 48);
            this.TXTCtrlPermisoNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TXTCtrlPermisoNombre.Name = "TXTCtrlPermisoNombre";
            this.TXTCtrlPermisoNombre.Size = new System.Drawing.Size(196, 23);
            this.TXTCtrlPermisoNombre.TabIndex = 4;
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Location = new System.Drawing.Point(10, 23);
            this.LBLnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(61, 17);
            this.LBLnombre.TabIndex = 5;
            this.LBLnombre.Text = "Nombre";
            // 
            // BTNCtrlPermisoAsignar
            // 
            this.BTNCtrlPermisoAsignar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNCtrlPermisoAsignar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCtrlPermisoAsignar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNCtrlPermisoAsignar.Location = new System.Drawing.Point(575, 153);
            this.BTNCtrlPermisoAsignar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNCtrlPermisoAsignar.Name = "BTNCtrlPermisoAsignar";
            this.BTNCtrlPermisoAsignar.Size = new System.Drawing.Size(145, 33);
            this.BTNCtrlPermisoAsignar.TabIndex = 6;
            this.BTNCtrlPermisoAsignar.Text = "Asignar";
            this.BTNCtrlPermisoAsignar.UseVisualStyleBackColor = false;
            this.BTNCtrlPermisoAsignar.Click += new System.EventHandler(this.BTNCtrlPermisoAsignar_Click);
            // 
            // BTNCtrlPermisoDesasignar
            // 
            this.BTNCtrlPermisoDesasignar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNCtrlPermisoDesasignar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCtrlPermisoDesasignar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNCtrlPermisoDesasignar.Location = new System.Drawing.Point(575, 193);
            this.BTNCtrlPermisoDesasignar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNCtrlPermisoDesasignar.Name = "BTNCtrlPermisoDesasignar";
            this.BTNCtrlPermisoDesasignar.Size = new System.Drawing.Size(145, 33);
            this.BTNCtrlPermisoDesasignar.TabIndex = 7;
            this.BTNCtrlPermisoDesasignar.Text = "Desasignar";
            this.BTNCtrlPermisoDesasignar.UseVisualStyleBackColor = false;
            this.BTNCtrlPermisoDesasignar.Click += new System.EventHandler(this.BTNCtrlPermisoDesasignar_Click);
            // 
            // GB_ListRoles
            // 
            this.GB_ListRoles.Controls.Add(this.listBox1);
            this.GB_ListRoles.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.GB_ListRoles.Location = new System.Drawing.Point(14, 15);
            this.GB_ListRoles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_ListRoles.Name = "GB_ListRoles";
            this.GB_ListRoles.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_ListRoles.Size = new System.Drawing.Size(262, 354);
            this.GB_ListRoles.TabIndex = 8;
            this.GB_ListRoles.TabStop = false;
            this.GB_ListRoles.Text = "Todos los roles";
            // 
            // GB_TreeViewRoles
            // 
            this.GB_TreeViewRoles.Controls.Add(this.TV_RolesPermisos);
            this.GB_TreeViewRoles.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.GB_TreeViewRoles.Location = new System.Drawing.Point(727, 15);
            this.GB_TreeViewRoles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_TreeViewRoles.Name = "GB_TreeViewRoles";
            this.GB_TreeViewRoles.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_TreeViewRoles.Size = new System.Drawing.Size(255, 354);
            this.GB_TreeViewRoles.TabIndex = 9;
            this.GB_TreeViewRoles.TabStop = false;
            this.GB_TreeViewRoles.Text = "Arbol de roles";
            // 
            // GB_NuevoRol
            // 
            this.GB_NuevoRol.Controls.Add(this.BTNCtrlPermisoModifRol);
            this.GB_NuevoRol.Controls.Add(this.TXTCtrlPermisoNombre);
            this.GB_NuevoRol.Controls.Add(this.BTNCtrlPermisoBorrarRol);
            this.GB_NuevoRol.Controls.Add(this.BTNCtrlPermisoCrearRol);
            this.GB_NuevoRol.Controls.Add(this.LBLnombre);
            this.GB_NuevoRol.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_NuevoRol.Location = new System.Drawing.Point(1022, 165);
            this.GB_NuevoRol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_NuevoRol.Name = "GB_NuevoRol";
            this.GB_NuevoRol.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_NuevoRol.Size = new System.Drawing.Size(226, 204);
            this.GB_NuevoRol.TabIndex = 10;
            this.GB_NuevoRol.TabStop = false;
            this.GB_NuevoRol.Text = "Nuevo rol";
            // 
            // BTNCtrlPermisoModifRol
            // 
            this.BTNCtrlPermisoModifRol.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNCtrlPermisoModifRol.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNCtrlPermisoModifRol.Location = new System.Drawing.Point(10, 119);
            this.BTNCtrlPermisoModifRol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNCtrlPermisoModifRol.Name = "BTNCtrlPermisoModifRol";
            this.BTNCtrlPermisoModifRol.Size = new System.Drawing.Size(145, 33);
            this.BTNCtrlPermisoModifRol.TabIndex = 12;
            this.BTNCtrlPermisoModifRol.Text = "Modificar";
            this.BTNCtrlPermisoModifRol.UseVisualStyleBackColor = false;
            this.BTNCtrlPermisoModifRol.Click += new System.EventHandler(this.BTNCtrlPermisoModifRol_Click);
            // 
            // BTNCtrlPermisoBorrarRol
            // 
            this.BTNCtrlPermisoBorrarRol.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNCtrlPermisoBorrarRol.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNCtrlPermisoBorrarRol.Location = new System.Drawing.Point(10, 159);
            this.BTNCtrlPermisoBorrarRol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNCtrlPermisoBorrarRol.Name = "BTNCtrlPermisoBorrarRol";
            this.BTNCtrlPermisoBorrarRol.Size = new System.Drawing.Size(145, 33);
            this.BTNCtrlPermisoBorrarRol.TabIndex = 11;
            this.BTNCtrlPermisoBorrarRol.Text = "Borrar";
            this.BTNCtrlPermisoBorrarRol.UseVisualStyleBackColor = false;
            this.BTNCtrlPermisoBorrarRol.Click += new System.EventHandler(this.BTNCtrlPermisoBorrarRol_Click);
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(1308, 34);
            this.CBXidiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(140, 25);
            this.CBXidiomas.TabIndex = 11;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLidiomas.Location = new System.Drawing.Point(1308, 15);
            this.LBLidiomas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(74, 17);
            this.LBLidiomas.TabIndex = 12;
            this.LBLidiomas.Text = "Language";
            // 
            // GB_ListPermisos
            // 
            this.GB_ListPermisos.Controls.Add(this.listBox2);
            this.GB_ListPermisos.Font = new System.Drawing.Font("Century Gothic", 8.75F);
            this.GB_ListPermisos.Location = new System.Drawing.Point(306, 15);
            this.GB_ListPermisos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_ListPermisos.Name = "GB_ListPermisos";
            this.GB_ListPermisos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_ListPermisos.Size = new System.Drawing.Size(262, 354);
            this.GB_ListPermisos.TabIndex = 9;
            this.GB_ListPermisos.TabStop = false;
            this.GB_ListPermisos.Text = "Todos los permisos";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 17;
            this.listBox2.Location = new System.Drawing.Point(14, 27);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(231, 293);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // BTNvolveralmenu
            // 
            this.BTNvolveralmenu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNvolveralmenu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolveralmenu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTNvolveralmenu.Location = new System.Drawing.Point(1308, 336);
            this.BTNvolveralmenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNvolveralmenu.Name = "BTNvolveralmenu";
            this.BTNvolveralmenu.Size = new System.Drawing.Size(145, 33);
            this.BTNvolveralmenu.TabIndex = 14;
            this.BTNvolveralmenu.Text = "Volver al menu ";
            this.BTNvolveralmenu.UseVisualStyleBackColor = false;
            this.BTNvolveralmenu.Click += new System.EventHandler(this.BTNvolveralmenu_Click);
            // 
            // FrmCTRLPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1463, 378);
            this.Controls.Add(this.BTNvolveralmenu);
            this.Controls.Add(this.GB_ListPermisos);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.GB_NuevoRol);
            this.Controls.Add(this.GB_ListRoles);
            this.Controls.Add(this.BTNCtrlPermisoDesasignar);
            this.Controls.Add(this.BTNCtrlPermisoAsignar);
            this.Controls.Add(this.GB_TreeViewRoles);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCTRLPermiso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCTRLPermiso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCTRLPermiso_FormClosed);
            this.Load += new System.EventHandler(this.FrmCTRLPermiso_Load);
            this.GB_ListRoles.ResumeLayout(false);
            this.GB_TreeViewRoles.ResumeLayout(false);
            this.GB_NuevoRol.ResumeLayout(false);
            this.GB_NuevoRol.PerformLayout();
            this.GB_ListPermisos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TV_RolesPermisos;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BTNCtrlPermisoCrearRol;
        private System.Windows.Forms.TextBox TXTCtrlPermisoNombre;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Button BTNCtrlPermisoAsignar;
        private System.Windows.Forms.Button BTNCtrlPermisoDesasignar;
        private System.Windows.Forms.GroupBox GB_ListRoles;
        private System.Windows.Forms.GroupBox GB_TreeViewRoles;
        private System.Windows.Forms.GroupBox GB_NuevoRol;
        private System.Windows.Forms.Button BTNCtrlPermisoModifRol;
        private System.Windows.Forms.Button BTNCtrlPermisoBorrarRol;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.GroupBox GB_ListPermisos;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button BTNvolveralmenu;
    }
}