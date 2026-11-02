namespace Trabajo_practico_IS
{
    partial class FrmCalibrarRatios
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
            this.lblTotalEventosInfo = new System.Windows.Forms.Label();
            this.lblAprobadosInfo = new System.Windows.Forms.Label();
            this.lblRecomendacionInfo = new System.Windows.Forms.Label();
            this.lblDesaprobadosInfo = new System.Windows.Forms.Label();
            this.dgvRatios = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAplicarRatios = new System.Windows.Forms.Button();
            this.btnVolverAlMenu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDesaprobadosInfo);
            this.groupBox1.Controls.Add(this.lblRecomendacionInfo);
            this.groupBox1.Controls.Add(this.lblAprobadosInfo);
            this.groupBox1.Controls.Add(this.lblTotalEventosInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metricas";
            // 
            // lblTotalEventosInfo
            // 
            this.lblTotalEventosInfo.AutoSize = true;
            this.lblTotalEventosInfo.Location = new System.Drawing.Point(21, 43);
            this.lblTotalEventosInfo.Name = "lblTotalEventosInfo";
            this.lblTotalEventosInfo.Size = new System.Drawing.Size(35, 13);
            this.lblTotalEventosInfo.TabIndex = 1;
            this.lblTotalEventosInfo.Text = "label1";
            // 
            // lblAprobadosInfo
            // 
            this.lblAprobadosInfo.AutoSize = true;
            this.lblAprobadosInfo.Location = new System.Drawing.Point(21, 75);
            this.lblAprobadosInfo.Name = "lblAprobadosInfo";
            this.lblAprobadosInfo.Size = new System.Drawing.Size(35, 13);
            this.lblAprobadosInfo.TabIndex = 2;
            this.lblAprobadosInfo.Text = "label1";
            // 
            // lblRecomendacionInfo
            // 
            this.lblRecomendacionInfo.AutoSize = true;
            this.lblRecomendacionInfo.Location = new System.Drawing.Point(21, 151);
            this.lblRecomendacionInfo.Name = "lblRecomendacionInfo";
            this.lblRecomendacionInfo.Size = new System.Drawing.Size(35, 13);
            this.lblRecomendacionInfo.TabIndex = 3;
            this.lblRecomendacionInfo.Text = "label1";
            // 
            // lblDesaprobadosInfo
            // 
            this.lblDesaprobadosInfo.AutoSize = true;
            this.lblDesaprobadosInfo.Location = new System.Drawing.Point(21, 114);
            this.lblDesaprobadosInfo.Name = "lblDesaprobadosInfo";
            this.lblDesaprobadosInfo.Size = new System.Drawing.Size(35, 13);
            this.lblDesaprobadosInfo.TabIndex = 4;
            this.lblDesaprobadosInfo.Text = "label1";
            // 
            // dgvRatios
            // 
            this.dgvRatios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatios.Location = new System.Drawing.Point(6, 30);
            this.dgvRatios.Name = "dgvRatios";
            this.dgvRatios.Size = new System.Drawing.Size(445, 194);
            this.dgvRatios.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAplicarRatios);
            this.groupBox2.Controls.Add(this.dgvRatios);
            this.groupBox2.Location = new System.Drawing.Point(539, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 307);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ratios";
            // 
            // btnAplicarRatios
            // 
            this.btnAplicarRatios.Location = new System.Drawing.Point(175, 255);
            this.btnAplicarRatios.Name = "btnAplicarRatios";
            this.btnAplicarRatios.Size = new System.Drawing.Size(110, 35);
            this.btnAplicarRatios.TabIndex = 2;
            this.btnAplicarRatios.Text = "Aplicar Ratios";
            this.btnAplicarRatios.UseVisualStyleBackColor = true;
            this.btnAplicarRatios.Click += new System.EventHandler(this.btnAplicarRatios_Click);
            // 
            // btnVolverAlMenu
            // 
            this.btnVolverAlMenu.Location = new System.Drawing.Point(880, 394);
            this.btnVolverAlMenu.Name = "btnVolverAlMenu";
            this.btnVolverAlMenu.Size = new System.Drawing.Size(110, 35);
            this.btnVolverAlMenu.TabIndex = 3;
            this.btnVolverAlMenu.Text = "Volver al Menu Principal";
            this.btnVolverAlMenu.UseVisualStyleBackColor = true;
            this.btnVolverAlMenu.Click += new System.EventHandler(this.btnVolverAlMenu_Click);
            // 
            // FrmCalibrarRatios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.btnVolverAlMenu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCalibrarRatios";
            this.Text = "FrmCalibrarRatios";
            this.Load += new System.EventHandler(this.FrmCalibrarRatios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDesaprobadosInfo;
        private System.Windows.Forms.Label lblRecomendacionInfo;
        private System.Windows.Forms.Label lblAprobadosInfo;
        private System.Windows.Forms.Label lblTotalEventosInfo;
        private System.Windows.Forms.DataGridView dgvRatios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAplicarRatios;
        private System.Windows.Forms.Button btnVolverAlMenu;
    }
}