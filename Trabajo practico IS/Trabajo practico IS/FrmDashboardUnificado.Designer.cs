namespace Trabajo_practico_IS
{
    partial class FrmDashboardUnificado
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cmbMetrica = new System.Windows.Forms.ComboBox();
            this.lblMetrica = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.chartPrincipal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.pnlFiltros.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.LBLidiomas);
            this.pnlFiltros.Controls.Add(this.CBXidiomas);
            this.pnlFiltros.Controls.Add(this.btnConsultar);
            this.pnlFiltros.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltros.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.cmbMetrica);
            this.pnlFiltros.Controls.Add(this.lblMetrica);
            this.pnlFiltros.Controls.Add(this.cmbArea);
            this.pnlFiltros.Controls.Add(this.lblArea);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1036, 355);
            this.pnlFiltros.TabIndex = 2;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(421, 273);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(105, 32);
            this.btnConsultar.TabIndex = 17;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(514, 194);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(126, 20);
            this.dtpFechaHasta.TabIndex = 16;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(300, 194);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(126, 20);
            this.dtpFechaDesde.TabIndex = 15;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(511, 147);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 14;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(297, 147);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 13;
            this.lblDesde.Text = "Desde:";
            // 
            // cmbMetrica
            // 
            this.cmbMetrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetrica.FormattingEnabled = true;
            this.cmbMetrica.Location = new System.Drawing.Point(443, 83);
            this.cmbMetrica.Name = "cmbMetrica";
            this.cmbMetrica.Size = new System.Drawing.Size(355, 21);
            this.cmbMetrica.TabIndex = 12;
            this.cmbMetrica.SelectedIndexChanged += new System.EventHandler(this.cmbMetrica_SelectedIndexChanged);
            // 
            // lblMetrica
            // 
            this.lblMetrica.AutoSize = true;
            this.lblMetrica.Location = new System.Drawing.Point(297, 91);
            this.lblMetrica.Name = "lblMetrica";
            this.lblMetrica.Size = new System.Drawing.Size(99, 13);
            this.lblMetrica.TabIndex = 11;
            this.lblMetrica.Text = "Metrica/Dashboard";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(443, 43);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(355, 21);
            this.cmbArea.TabIndex = 10;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(297, 43);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(90, 13);
            this.lblArea.TabIndex = 9;
            this.lblArea.Text = "Area de Negocio:";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.dgvDetalle);
            this.pnlContenedor.Controls.Add(this.chartPrincipal);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 355);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1036, 337);
            this.pnlContenedor.TabIndex = 18;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.Size = new System.Drawing.Size(1036, 337);
            this.dgvDetalle.TabIndex = 1;
            this.dgvDetalle.Visible = false;
            // 
            // chartPrincipal
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPrincipal.ChartAreas.Add(chartArea2);
            this.chartPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartPrincipal.Legends.Add(legend2);
            this.chartPrincipal.Location = new System.Drawing.Point(0, 0);
            this.chartPrincipal.Name = "chartPrincipal";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPrincipal.Series.Add(series2);
            this.chartPrincipal.Size = new System.Drawing.Size(1036, 337);
            this.chartPrincipal.TabIndex = 0;
            this.chartPrincipal.Text = "chart1";
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(903, 27);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(43, 13);
            this.LBLidiomas.TabIndex = 19;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(903, 43);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXidiomas.TabIndex = 18;
            // 
            // FrmDashboardUnificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 692);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlFiltros);
            this.Name = "FrmDashboardUnificado";
            this.Text = "FrmDashboardUnificado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDashboardUnificado_FormClosed);
            this.Load += new System.EventHandler(this.FrmDashboardUnificado_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.ComboBox cmbMetrica;
        private System.Windows.Forms.Label lblMetrica;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrincipal;
        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.ComboBox CBXidiomas;
    }
}