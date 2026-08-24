namespace Trabajo_practico_IS
{
    partial class FrmHistorial
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
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.CBXIdiomas = new System.Windows.Forms.ComboBox();
            this.BTNvolveralmenu = new System.Windows.Forms.Button();
            this.BTNrestaurar = new System.Windows.Forms.Button();
            this.DGVHistorial = new System.Windows.Forms.DataGridView();
            this.CBX_Filtro = new System.Windows.Forms.ComboBox();
            this.CBX_Entidad = new System.Windows.Forms.ComboBox();
            this.BTN_LimpiarFiltrosHist = new System.Windows.Forms.Button();
            this.GB_Historial = new System.Windows.Forms.GroupBox();
            this.GB_FiltrarHistorial = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).BeginInit();
            this.GB_Historial.SuspendLayout();
            this.GB_FiltrarHistorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLidiomas.Location = new System.Drawing.Point(1082, 11);
            this.LBLidiomas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(59, 17);
            this.LBLidiomas.TabIndex = 15;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // CBXIdiomas
            // 
            this.CBXIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXIdiomas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBXIdiomas.FormattingEnabled = true;
            this.CBXIdiomas.Location = new System.Drawing.Point(1082, 31);
            this.CBXIdiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXIdiomas.Name = "CBXIdiomas";
            this.CBXIdiomas.Size = new System.Drawing.Size(140, 25);
            this.CBXIdiomas.TabIndex = 14;
            this.CBXIdiomas.SelectedIndexChanged += new System.EventHandler(this.CBXIdiomas_SelectedIndexChanged);
            // 
            // BTNvolveralmenu
            // 
            this.BTNvolveralmenu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNvolveralmenu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolveralmenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNvolveralmenu.Location = new System.Drawing.Point(1079, 512);
            this.BTNvolveralmenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNvolveralmenu.Name = "BTNvolveralmenu";
            this.BTNvolveralmenu.Size = new System.Drawing.Size(145, 33);
            this.BTNvolveralmenu.TabIndex = 13;
            this.BTNvolveralmenu.Text = "Volver al menu ";
            this.BTNvolveralmenu.UseVisualStyleBackColor = false;
            this.BTNvolveralmenu.Click += new System.EventHandler(this.BTNvolveralmenu_Click);
            // 
            // BTNrestaurar
            // 
            this.BTNrestaurar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNrestaurar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNrestaurar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNrestaurar.Location = new System.Drawing.Point(387, 498);
            this.BTNrestaurar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNrestaurar.Name = "BTNrestaurar";
            this.BTNrestaurar.Size = new System.Drawing.Size(145, 33);
            this.BTNrestaurar.TabIndex = 12;
            this.BTNrestaurar.Text = "Restaurar";
            this.BTNrestaurar.UseVisualStyleBackColor = false;
            this.BTNrestaurar.Click += new System.EventHandler(this.BTNrestaurar_Click);
            // 
            // DGVHistorial
            // 
            this.DGVHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistorial.Location = new System.Drawing.Point(10, 64);
            this.DGVHistorial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGVHistorial.MultiSelect = false;
            this.DGVHistorial.Name = "DGVHistorial";
            this.DGVHistorial.Size = new System.Drawing.Size(1018, 369);
            this.DGVHistorial.TabIndex = 8;
            this.DGVHistorial.SelectionChanged += new System.EventHandler(this.DGVHistorial_SelectionChanged);
            // 
            // CBX_Filtro
            // 
            this.CBX_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Filtro.FormattingEnabled = true;
            this.CBX_Filtro.Location = new System.Drawing.Point(7, 31);
            this.CBX_Filtro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBX_Filtro.Name = "CBX_Filtro";
            this.CBX_Filtro.Size = new System.Drawing.Size(187, 25);
            this.CBX_Filtro.TabIndex = 16;
            this.CBX_Filtro.SelectedIndexChanged += new System.EventHandler(this.CBX_Filtro_SelectedIndexChanged);
            // 
            // CBX_Entidad
            // 
            this.CBX_Entidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Entidad.FormattingEnabled = true;
            this.CBX_Entidad.Location = new System.Drawing.Point(10, 26);
            this.CBX_Entidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBX_Entidad.Name = "CBX_Entidad";
            this.CBX_Entidad.Size = new System.Drawing.Size(140, 25);
            this.CBX_Entidad.TabIndex = 17;
            this.CBX_Entidad.SelectedIndexChanged += new System.EventHandler(this.CBX_Entidad_SelectedIndexChanged);
            // 
            // BTN_LimpiarFiltrosHist
            // 
            this.BTN_LimpiarFiltrosHist.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_LimpiarFiltrosHist.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_LimpiarFiltrosHist.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_LimpiarFiltrosHist.Location = new System.Drawing.Point(202, 26);
            this.BTN_LimpiarFiltrosHist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_LimpiarFiltrosHist.Name = "BTN_LimpiarFiltrosHist";
            this.BTN_LimpiarFiltrosHist.Size = new System.Drawing.Size(145, 33);
            this.BTN_LimpiarFiltrosHist.TabIndex = 18;
            this.BTN_LimpiarFiltrosHist.Text = "Ver Todo";
            this.BTN_LimpiarFiltrosHist.UseVisualStyleBackColor = false;
            this.BTN_LimpiarFiltrosHist.Click += new System.EventHandler(this.BTN_LimpiarFiltrosHist_Click);
            // 
            // GB_Historial
            // 
            this.GB_Historial.Controls.Add(this.DGVHistorial);
            this.GB_Historial.Controls.Add(this.CBX_Entidad);
            this.GB_Historial.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_Historial.Location = new System.Drawing.Point(18, 15);
            this.GB_Historial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_Historial.Name = "GB_Historial";
            this.GB_Historial.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_Historial.Size = new System.Drawing.Size(1040, 450);
            this.GB_Historial.TabIndex = 19;
            this.GB_Historial.TabStop = false;
            this.GB_Historial.Text = "Historial de cambios";
            // 
            // GB_FiltrarHistorial
            // 
            this.GB_FiltrarHistorial.Controls.Add(this.BTN_LimpiarFiltrosHist);
            this.GB_FiltrarHistorial.Controls.Add(this.CBX_Filtro);
            this.GB_FiltrarHistorial.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_FiltrarHistorial.Location = new System.Drawing.Point(18, 473);
            this.GB_FiltrarHistorial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_FiltrarHistorial.Name = "GB_FiltrarHistorial";
            this.GB_FiltrarHistorial.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_FiltrarHistorial.Size = new System.Drawing.Size(361, 73);
            this.GB_FiltrarHistorial.TabIndex = 20;
            this.GB_FiltrarHistorial.TabStop = false;
            this.GB_FiltrarHistorial.Text = "Filtrar";
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1231, 558);
            this.Controls.Add(this.GB_FiltrarHistorial);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXIdiomas);
            this.Controls.Add(this.BTNvolveralmenu);
            this.Controls.Add(this.BTNrestaurar);
            this.Controls.Add(this.GB_Historial);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHistorial";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).EndInit();
            this.GB_Historial.ResumeLayout(false);
            this.GB_FiltrarHistorial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.ComboBox CBXIdiomas;
        private System.Windows.Forms.Button BTNvolveralmenu;
        private System.Windows.Forms.Button BTNrestaurar;
        private System.Windows.Forms.DataGridView DGVHistorial;
        private System.Windows.Forms.ComboBox CBX_Filtro;
        private System.Windows.Forms.ComboBox CBX_Entidad;
        private System.Windows.Forms.Button BTN_LimpiarFiltrosHist;
        private System.Windows.Forms.GroupBox GB_Historial;
        private System.Windows.Forms.GroupBox GB_FiltrarHistorial;
    }
}