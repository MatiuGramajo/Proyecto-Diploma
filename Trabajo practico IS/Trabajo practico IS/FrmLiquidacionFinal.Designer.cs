namespace Trabajo_practico_IS
{
    partial class FrmLiquidacionFinal
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LBLcostototal = new System.Windows.Forms.Label();
            this.LBLsenia = new System.Windows.Forms.Label();
            this.LBLsaldopendiente = new System.Windows.Forms.Label();
            this.LBLmetodopago = new System.Windows.Forms.Label();
            this.CBXmetododepago = new System.Windows.Forms.ComboBox();
            this.BTNconfirmarliquidacion = new System.Windows.Forms.Button();
            this.BTNvolveralmenuprincipal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBXmetododepago);
            this.groupBox1.Controls.Add(this.LBLmetodopago);
            this.groupBox1.Controls.Add(this.LBLsaldopendiente);
            this.groupBox1.Controls.Add(this.LBLsenia);
            this.groupBox1.Controls.Add(this.LBLcostototal);
            this.groupBox1.Location = new System.Drawing.Point(579, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles financieros";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 322);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eventos planificados a Saldar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 37);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(501, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // LBLcostototal
            // 
            this.LBLcostototal.AutoSize = true;
            this.LBLcostototal.Location = new System.Drawing.Point(15, 37);
            this.LBLcostototal.Name = "LBLcostototal";
            this.LBLcostototal.Size = new System.Drawing.Size(119, 13);
            this.LBLcostototal.TabIndex = 0;
            this.LBLcostototal.Text = "Costo Total Real: $0,00";
            // 
            // LBLsenia
            // 
            this.LBLsenia.AutoSize = true;
            this.LBLsenia.Location = new System.Drawing.Point(15, 118);
            this.LBLsenia.Name = "LBLsenia";
            this.LBLsenia.Size = new System.Drawing.Size(105, 13);
            this.LBLsenia.TabIndex = 1;
            this.LBLsenia.Text = "Seña Pagada: $0,00";
            // 
            // LBLsaldopendiente
            // 
            this.LBLsaldopendiente.AutoSize = true;
            this.LBLsaldopendiente.Location = new System.Drawing.Point(15, 77);
            this.LBLsaldopendiente.Name = "LBLsaldopendiente";
            this.LBLsaldopendiente.Size = new System.Drawing.Size(118, 13);
            this.LBLsaldopendiente.TabIndex = 2;
            this.LBLsaldopendiente.Text = "Saldo Pendiente: $0,00";
            // 
            // LBLmetodopago
            // 
            this.LBLmetodopago.AutoSize = true;
            this.LBLmetodopago.Location = new System.Drawing.Point(15, 162);
            this.LBLmetodopago.Name = "LBLmetodopago";
            this.LBLmetodopago.Size = new System.Drawing.Size(86, 13);
            this.LBLmetodopago.TabIndex = 3;
            this.LBLmetodopago.Text = "Metodo de Pago";
            // 
            // CBXmetododepago
            // 
            this.CBXmetododepago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXmetododepago.FormattingEnabled = true;
            this.CBXmetododepago.Items.AddRange(new object[] {
            "Efectivo",
            "Transferencia Bancaria",
            "Tarjeta de Credito",
            "Tarjeta de Debito"});
            this.CBXmetododepago.Location = new System.Drawing.Point(18, 194);
            this.CBXmetododepago.Name = "CBXmetododepago";
            this.CBXmetododepago.Size = new System.Drawing.Size(164, 21);
            this.CBXmetododepago.TabIndex = 4;
            // 
            // BTNconfirmarliquidacion
            // 
            this.BTNconfirmarliquidacion.Enabled = false;
            this.BTNconfirmarliquidacion.Location = new System.Drawing.Point(579, 386);
            this.BTNconfirmarliquidacion.Name = "BTNconfirmarliquidacion";
            this.BTNconfirmarliquidacion.Size = new System.Drawing.Size(137, 39);
            this.BTNconfirmarliquidacion.TabIndex = 2;
            this.BTNconfirmarliquidacion.Text = "Confirmar Liquidacion y Generar PDF";
            this.BTNconfirmarliquidacion.UseVisualStyleBackColor = true;
            this.BTNconfirmarliquidacion.Click += new System.EventHandler(this.BTNconfirmarliquidacion_Click);
            // 
            // BTNvolveralmenuprincipal
            // 
            this.BTNvolveralmenuprincipal.Enabled = false;
            this.BTNvolveralmenuprincipal.Location = new System.Drawing.Point(817, 386);
            this.BTNvolveralmenuprincipal.Name = "BTNvolveralmenuprincipal";
            this.BTNvolveralmenuprincipal.Size = new System.Drawing.Size(104, 39);
            this.BTNvolveralmenuprincipal.TabIndex = 3;
            this.BTNvolveralmenuprincipal.Text = "Volver al menu principal";
            this.BTNvolveralmenuprincipal.UseVisualStyleBackColor = true;
            // 
            // FrmLiquidacionFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 450);
            this.Controls.Add(this.BTNvolveralmenuprincipal);
            this.Controls.Add(this.BTNconfirmarliquidacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLiquidacionFinal";
            this.Text = "FrmLiquidacionFinal";
            this.Load += new System.EventHandler(this.FrmLiquidacionFinal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CBXmetododepago;
        private System.Windows.Forms.Label LBLmetodopago;
        private System.Windows.Forms.Label LBLsaldopendiente;
        private System.Windows.Forms.Label LBLsenia;
        private System.Windows.Forms.Label LBLcostototal;
        private System.Windows.Forms.Button BTNconfirmarliquidacion;
        private System.Windows.Forms.Button BTNvolveralmenuprincipal;
    }
}