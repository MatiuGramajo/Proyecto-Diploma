namespace Trabajo_practico_IS
{
    partial class FrmBitacora
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
            this.BTN_CargarBitacora = new System.Windows.Forms.Button();
            this.GB_Bitacora = new System.Windows.Forms.GroupBox();
            this.DGV_BITACORA = new System.Windows.Forms.DataGridView();
            this.DTPBitacoraDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPBitacoraHasta = new System.Windows.Forms.DateTimePicker();
            this.CBXBitacoraUsuario = new System.Windows.Forms.ComboBox();
            this.GBfiltros = new System.Windows.Forms.GroupBox();
            this.CKXincluirfechas = new System.Windows.Forms.CheckBox();
            this.LBLfechafinal = new System.Windows.Forms.Label();
            this.LBLfechainicial = new System.Windows.Forms.Label();
            this.LBLcriticidad = new System.Windows.Forms.Label();
            this.LBLmodulo = new System.Windows.Forms.Label();
            this.LBLusuario = new System.Windows.Forms.Label();
            this.CBXBitacoraModulo = new System.Windows.Forms.ComboBox();
            this.CBXBitacoraCriticidad = new System.Windows.Forms.ComboBox();
            this.BTN_BitacoraVolverAlMenu = new System.Windows.Forms.Button();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.GB_Bitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).BeginInit();
            this.GBfiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_CargarBitacora
            // 
            this.BTN_CargarBitacora.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_CargarBitacora.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CargarBitacora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_CargarBitacora.Location = new System.Drawing.Point(357, 181);
            this.BTN_CargarBitacora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_CargarBitacora.Name = "BTN_CargarBitacora";
            this.BTN_CargarBitacora.Size = new System.Drawing.Size(145, 33);
            this.BTN_CargarBitacora.TabIndex = 5;
            this.BTN_CargarBitacora.Text = "Filtrar";
            this.BTN_CargarBitacora.UseVisualStyleBackColor = false;
            this.BTN_CargarBitacora.Click += new System.EventHandler(this.BTN_CargarBitacora_Click);
            // 
            // GB_Bitacora
            // 
            this.GB_Bitacora.Controls.Add(this.DGV_BITACORA);
            this.GB_Bitacora.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.GB_Bitacora.Location = new System.Drawing.Point(14, 15);
            this.GB_Bitacora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_Bitacora.Name = "GB_Bitacora";
            this.GB_Bitacora.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_Bitacora.Size = new System.Drawing.Size(929, 320);
            this.GB_Bitacora.TabIndex = 4;
            this.GB_Bitacora.TabStop = false;
            this.GB_Bitacora.Text = "Bitacora";
            // 
            // DGV_BITACORA
            // 
            this.DGV_BITACORA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_BITACORA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BITACORA.Location = new System.Drawing.Point(12, 30);
            this.DGV_BITACORA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_BITACORA.Name = "DGV_BITACORA";
            this.DGV_BITACORA.Size = new System.Drawing.Size(904, 274);
            this.DGV_BITACORA.TabIndex = 1;
            // 
            // DTPBitacoraDesde
            // 
            this.DTPBitacoraDesde.Location = new System.Drawing.Point(271, 80);
            this.DTPBitacoraDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DTPBitacoraDesde.Name = "DTPBitacoraDesde";
            this.DTPBitacoraDesde.Size = new System.Drawing.Size(269, 23);
            this.DTPBitacoraDesde.TabIndex = 6;
            // 
            // DTPBitacoraHasta
            // 
            this.DTPBitacoraHasta.Location = new System.Drawing.Point(563, 80);
            this.DTPBitacoraHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DTPBitacoraHasta.Name = "DTPBitacoraHasta";
            this.DTPBitacoraHasta.Size = new System.Drawing.Size(269, 23);
            this.DTPBitacoraHasta.TabIndex = 7;
            // 
            // CBXBitacoraUsuario
            // 
            this.CBXBitacoraUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXBitacoraUsuario.FormattingEnabled = true;
            this.CBXBitacoraUsuario.Location = new System.Drawing.Point(50, 56);
            this.CBXBitacoraUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXBitacoraUsuario.Name = "CBXBitacoraUsuario";
            this.CBXBitacoraUsuario.Size = new System.Drawing.Size(140, 25);
            this.CBXBitacoraUsuario.TabIndex = 8;
            // 
            // GBfiltros
            // 
            this.GBfiltros.Controls.Add(this.CKXincluirfechas);
            this.GBfiltros.Controls.Add(this.LBLfechafinal);
            this.GBfiltros.Controls.Add(this.LBLfechainicial);
            this.GBfiltros.Controls.Add(this.LBLcriticidad);
            this.GBfiltros.Controls.Add(this.BTN_CargarBitacora);
            this.GBfiltros.Controls.Add(this.DTPBitacoraDesde);
            this.GBfiltros.Controls.Add(this.DTPBitacoraHasta);
            this.GBfiltros.Controls.Add(this.LBLmodulo);
            this.GBfiltros.Controls.Add(this.LBLusuario);
            this.GBfiltros.Controls.Add(this.CBXBitacoraModulo);
            this.GBfiltros.Controls.Add(this.CBXBitacoraCriticidad);
            this.GBfiltros.Controls.Add(this.CBXBitacoraUsuario);
            this.GBfiltros.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.GBfiltros.Location = new System.Drawing.Point(14, 347);
            this.GBfiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBfiltros.Name = "GBfiltros";
            this.GBfiltros.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBfiltros.Size = new System.Drawing.Size(873, 239);
            this.GBfiltros.TabIndex = 9;
            this.GBfiltros.TabStop = false;
            this.GBfiltros.Text = "Filtros";
            // 
            // CKXincluirfechas
            // 
            this.CKXincluirfechas.AutoSize = true;
            this.CKXincluirfechas.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CKXincluirfechas.Location = new System.Drawing.Point(428, 28);
            this.CKXincluirfechas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CKXincluirfechas.Name = "CKXincluirfechas";
            this.CKXincluirfechas.Size = new System.Drawing.Size(112, 21);
            this.CKXincluirfechas.TabIndex = 16;
            this.CKXincluirfechas.Text = "Incluir Fechas";
            this.CKXincluirfechas.UseVisualStyleBackColor = true;
            this.CKXincluirfechas.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LBLfechafinal
            // 
            this.LBLfechafinal.AutoSize = true;
            this.LBLfechafinal.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLfechafinal.Location = new System.Drawing.Point(563, 60);
            this.LBLfechafinal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLfechafinal.Name = "LBLfechafinal";
            this.LBLfechafinal.Size = new System.Drawing.Size(80, 17);
            this.LBLfechafinal.TabIndex = 15;
            this.LBLfechafinal.Text = "Fecha Final";
            // 
            // LBLfechainicial
            // 
            this.LBLfechainicial.AutoSize = true;
            this.LBLfechainicial.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLfechainicial.Location = new System.Drawing.Point(271, 60);
            this.LBLfechainicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLfechainicial.Name = "LBLfechainicial";
            this.LBLfechainicial.Size = new System.Drawing.Size(88, 17);
            this.LBLfechainicial.TabIndex = 14;
            this.LBLfechainicial.Text = "Fecha Inicial";
            // 
            // LBLcriticidad
            // 
            this.LBLcriticidad.AutoSize = true;
            this.LBLcriticidad.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLcriticidad.Location = new System.Drawing.Point(47, 167);
            this.LBLcriticidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLcriticidad.Name = "LBLcriticidad";
            this.LBLcriticidad.Size = new System.Drawing.Size(72, 17);
            this.LBLcriticidad.TabIndex = 13;
            this.LBLcriticidad.Text = "Criticidad";
            // 
            // LBLmodulo
            // 
            this.LBLmodulo.AutoSize = true;
            this.LBLmodulo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLmodulo.Location = new System.Drawing.Point(47, 101);
            this.LBLmodulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLmodulo.Name = "LBLmodulo";
            this.LBLmodulo.Size = new System.Drawing.Size(57, 17);
            this.LBLmodulo.TabIndex = 12;
            this.LBLmodulo.Text = "Modulo";
            // 
            // LBLusuario
            // 
            this.LBLusuario.AutoSize = true;
            this.LBLusuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLusuario.Location = new System.Drawing.Point(47, 34);
            this.LBLusuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLusuario.Name = "LBLusuario";
            this.LBLusuario.Size = new System.Drawing.Size(54, 17);
            this.LBLusuario.TabIndex = 11;
            this.LBLusuario.Text = "Usuario";
            // 
            // CBXBitacoraModulo
            // 
            this.CBXBitacoraModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXBitacoraModulo.FormattingEnabled = true;
            this.CBXBitacoraModulo.Location = new System.Drawing.Point(50, 122);
            this.CBXBitacoraModulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXBitacoraModulo.Name = "CBXBitacoraModulo";
            this.CBXBitacoraModulo.Size = new System.Drawing.Size(140, 25);
            this.CBXBitacoraModulo.TabIndex = 10;
            // 
            // CBXBitacoraCriticidad
            // 
            this.CBXBitacoraCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXBitacoraCriticidad.FormattingEnabled = true;
            this.CBXBitacoraCriticidad.Location = new System.Drawing.Point(50, 188);
            this.CBXBitacoraCriticidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXBitacoraCriticidad.Name = "CBXBitacoraCriticidad";
            this.CBXBitacoraCriticidad.Size = new System.Drawing.Size(140, 25);
            this.CBXBitacoraCriticidad.TabIndex = 9;
            // 
            // BTN_BitacoraVolverAlMenu
            // 
            this.BTN_BitacoraVolverAlMenu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_BitacoraVolverAlMenu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_BitacoraVolverAlMenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_BitacoraVolverAlMenu.Location = new System.Drawing.Point(1032, 553);
            this.BTN_BitacoraVolverAlMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_BitacoraVolverAlMenu.Name = "BTN_BitacoraVolverAlMenu";
            this.BTN_BitacoraVolverAlMenu.Size = new System.Drawing.Size(145, 33);
            this.BTN_BitacoraVolverAlMenu.TabIndex = 10;
            this.BTN_BitacoraVolverAlMenu.Text = "Volver al menu ";
            this.BTN_BitacoraVolverAlMenu.UseVisualStyleBackColor = false;
            this.BTN_BitacoraVolverAlMenu.Click += new System.EventHandler(this.BTN_BitacoraVolverAlMenu_Click);
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(1036, 34);
            this.CBXidiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(140, 25);
            this.CBXidiomas.TabIndex = 11;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLidiomas.Location = new System.Drawing.Point(1036, 15);
            this.LBLidiomas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(74, 17);
            this.LBLidiomas.TabIndex = 12;
            this.LBLidiomas.Text = "Language";
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1188, 603);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.BTN_BitacoraVolverAlMenu);
            this.Controls.Add(this.GBfiltros);
            this.Controls.Add(this.GB_Bitacora);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBitacora";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBitacora_FormClosed);
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            this.GB_Bitacora.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).EndInit();
            this.GBfiltros.ResumeLayout(false);
            this.GBfiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_CargarBitacora;
        private System.Windows.Forms.GroupBox GB_Bitacora;
        private System.Windows.Forms.DataGridView DGV_BITACORA;
        private System.Windows.Forms.DateTimePicker DTPBitacoraDesde;
        private System.Windows.Forms.DateTimePicker DTPBitacoraHasta;
        private System.Windows.Forms.ComboBox CBXBitacoraUsuario;
        private System.Windows.Forms.GroupBox GBfiltros;
        private System.Windows.Forms.Label LBLcriticidad;
        private System.Windows.Forms.Label LBLmodulo;
        private System.Windows.Forms.Label LBLusuario;
        private System.Windows.Forms.ComboBox CBXBitacoraModulo;
        private System.Windows.Forms.ComboBox CBXBitacoraCriticidad;
        private System.Windows.Forms.Label LBLfechafinal;
        private System.Windows.Forms.Label LBLfechainicial;
        private System.Windows.Forms.CheckBox CKXincluirfechas;
        private System.Windows.Forms.Button BTN_BitacoraVolverAlMenu;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidiomas;
    }
}