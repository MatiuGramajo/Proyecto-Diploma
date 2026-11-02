namespace Trabajo_practico_IS
{
    partial class FrmConsultarFaltantes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvEventosPlanificados = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.rbEvento = new System.Windows.Forms.RadioButton();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.rbFechas = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRequerimientos = new System.Windows.Forms.DataGridView();
            this.chkSoloFaltantes = new System.Windows.Forms.CheckBox();
            this.btnVolverAlMenuPrincipal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventosPlanificados)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequerimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.dgvEventosPlanificados);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnCalcular);
            this.groupBox1.Controls.Add(this.rbEvento);
            this.groupBox1.Controls.Add(this.dtpFechaHasta);
            this.groupBox1.Controls.Add(this.dtpFechaDesde);
            this.groupBox1.Controls.Add(this.lblHasta);
            this.groupBox1.Controls.Add(this.lblDesde);
            this.groupBox1.Controls.Add(this.rbFechas);
            this.groupBox1.Location = new System.Drawing.Point(524, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 390);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Seleccion";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(224, 347);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(112, 37);
            this.btnFiltrar.TabIndex = 10;
            this.btnFiltrar.Text = "Buscar Eventos";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvEventosPlanificados
            // 
            this.dgvEventosPlanificados.AllowUserToAddRows = false;
            this.dgvEventosPlanificados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEventosPlanificados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventosPlanificados.Location = new System.Drawing.Point(10, 39);
            this.dgvEventosPlanificados.Name = "dgvEventosPlanificados";
            this.dgvEventosPlanificados.ReadOnly = true;
            this.dgvEventosPlanificados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventosPlanificados.Size = new System.Drawing.Size(547, 158);
            this.dgvEventosPlanificados.TabIndex = 2;
            this.dgvEventosPlanificados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventosPlanificados_CellClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(354, 347);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 37);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(81, 347);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(112, 37);
            this.btnCalcular.TabIndex = 8;
            this.btnCalcular.Text = "Calcular Faltantes";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // rbEvento
            // 
            this.rbEvento.AutoSize = true;
            this.rbEvento.Location = new System.Drawing.Point(333, 219);
            this.rbEvento.Name = "rbEvento";
            this.rbEvento.Size = new System.Drawing.Size(133, 17);
            this.rbEvento.TabIndex = 6;
            this.rbEvento.Text = "Por Evento Planificado";
            this.rbEvento.UseVisualStyleBackColor = true;
            this.rbEvento.CheckedChanged += new System.EventHandler(this.rbEvento_CheckedChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(137, 299);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(119, 20);
            this.dtpFechaHasta.TabIndex = 5;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(137, 248);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(119, 20);
            this.dtpFechaDesde.TabIndex = 4;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(78, 306);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(78, 255);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde";
            // 
            // rbFechas
            // 
            this.rbFechas.AutoSize = true;
            this.rbFechas.Checked = true;
            this.rbFechas.Location = new System.Drawing.Point(81, 219);
            this.rbFechas.Name = "rbFechas";
            this.rbFechas.Size = new System.Drawing.Size(129, 17);
            this.rbFechas.TabIndex = 1;
            this.rbFechas.TabStop = true;
            this.rbFechas.Text = "Por Rango de Fechas";
            this.rbFechas.UseVisualStyleBackColor = true;
            this.rbFechas.CheckedChanged += new System.EventHandler(this.rbFechas_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRequerimientos);
            this.groupBox2.Controls.Add(this.chkSoloFaltantes);
            this.groupBox2.Location = new System.Drawing.Point(12, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 291);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consolidado de Insumos y Requerimientos";
            // 
            // dgvRequerimientos
            // 
            this.dgvRequerimientos.AllowUserToAddRows = false;
            this.dgvRequerimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequerimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequerimientos.Location = new System.Drawing.Point(6, 39);
            this.dgvRequerimientos.Name = "dgvRequerimientos";
            this.dgvRequerimientos.ReadOnly = true;
            this.dgvRequerimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequerimientos.Size = new System.Drawing.Size(462, 158);
            this.dgvRequerimientos.TabIndex = 1;
            // 
            // chkSoloFaltantes
            // 
            this.chkSoloFaltantes.AutoSize = true;
            this.chkSoloFaltantes.Location = new System.Drawing.Point(25, 220);
            this.chkSoloFaltantes.Name = "chkSoloFaltantes";
            this.chkSoloFaltantes.Size = new System.Drawing.Size(167, 17);
            this.chkSoloFaltantes.TabIndex = 0;
            this.chkSoloFaltantes.Text = "Mostrar solo insumos faltantes";
            this.chkSoloFaltantes.UseVisualStyleBackColor = true;
            this.chkSoloFaltantes.CheckedChanged += new System.EventHandler(this.chkSoloFaltantes_CheckedChanged);
            // 
            // btnVolverAlMenuPrincipal
            // 
            this.btnVolverAlMenuPrincipal.Location = new System.Drawing.Point(1140, 374);
            this.btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            this.btnVolverAlMenuPrincipal.Size = new System.Drawing.Size(112, 37);
            this.btnVolverAlMenuPrincipal.TabIndex = 11;
            this.btnVolverAlMenuPrincipal.Text = "Volver al Menu Principal";
            this.btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverAlMenuPrincipal.Click += new System.EventHandler(this.btnVolverAlMenuPrincipal_Click);
            // 
            // FrmConsultarFaltantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 434);
            this.Controls.Add(this.btnVolverAlMenuPrincipal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmConsultarFaltantes";
            this.Text = "FrmConsultarFaltantes";
            this.Load += new System.EventHandler(this.FrmConsultarFaltantes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventosPlanificados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequerimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEvento;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.RadioButton rbFechas;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRequerimientos;
        private System.Windows.Forms.CheckBox chkSoloFaltantes;
        private System.Windows.Forms.DataGridView dgvEventosPlanificados;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnVolverAlMenuPrincipal;
    }
}