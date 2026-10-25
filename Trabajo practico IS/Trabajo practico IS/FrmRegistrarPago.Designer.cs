namespace Trabajo_practico_IS
{
    partial class FrmRegistrarPago
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
            this.DGVPresupuestosPendientes = new System.Windows.Forms.DataGridView();
            this.TXTmonto = new System.Windows.Forms.TextBox();
            this.CBXmetodopago = new System.Windows.Forms.ComboBox();
            this.BTNconfirmarPago = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTtotal = new System.Windows.Forms.TextBox();
            this.TXTtipoevento = new System.Windows.Forms.TextBox();
            this.TXTcliente = new System.Windows.Forms.TextBox();
            this.lblcliente = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CBXIdiomas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPresupuestosPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVPresupuestosPendientes
            // 
            this.DGVPresupuestosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPresupuestosPendientes.Location = new System.Drawing.Point(29, 39);
            this.DGVPresupuestosPendientes.Name = "DGVPresupuestosPendientes";
            this.DGVPresupuestosPendientes.Size = new System.Drawing.Size(708, 150);
            this.DGVPresupuestosPendientes.TabIndex = 0;
            this.DGVPresupuestosPendientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPresupuestosPendientes_CellClick);
            // 
            // TXTmonto
            // 
            this.TXTmonto.Location = new System.Drawing.Point(29, 238);
            this.TXTmonto.Name = "TXTmonto";
            this.TXTmonto.Size = new System.Drawing.Size(126, 20);
            this.TXTmonto.TabIndex = 1;
            // 
            // CBXmetodopago
            // 
            this.CBXmetodopago.FormattingEnabled = true;
            this.CBXmetodopago.Location = new System.Drawing.Point(402, 238);
            this.CBXmetodopago.Name = "CBXmetodopago";
            this.CBXmetodopago.Size = new System.Drawing.Size(121, 21);
            this.CBXmetodopago.TabIndex = 2;
            // 
            // BTNconfirmarPago
            // 
            this.BTNconfirmarPago.Location = new System.Drawing.Point(651, 366);
            this.BTNconfirmarPago.Name = "BTNconfirmarPago";
            this.BTNconfirmarPago.Size = new System.Drawing.Size(98, 38);
            this.BTNconfirmarPago.TabIndex = 3;
            this.BTNconfirmarPago.Text = "Confirmar Pago";
            this.BTNconfirmarPago.UseVisualStyleBackColor = true;
            this.BTNconfirmarPago.Click += new System.EventHandler(this.BTNconfirmarPago_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Metodo de pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Presupuestos";
            // 
            // TXTtotal
            // 
            this.TXTtotal.Location = new System.Drawing.Point(29, 384);
            this.TXTtotal.Name = "TXTtotal";
            this.TXTtotal.Size = new System.Drawing.Size(126, 20);
            this.TXTtotal.TabIndex = 7;
            // 
            // TXTtipoevento
            // 
            this.TXTtipoevento.Location = new System.Drawing.Point(29, 344);
            this.TXTtipoevento.Name = "TXTtipoevento";
            this.TXTtipoevento.Size = new System.Drawing.Size(126, 20);
            this.TXTtipoevento.TabIndex = 8;
            // 
            // TXTcliente
            // 
            this.TXTcliente.Location = new System.Drawing.Point(29, 302);
            this.TXTcliente.Name = "TXTcliente";
            this.TXTcliente.Size = new System.Drawing.Size(126, 20);
            this.TXTcliente.TabIndex = 9;
            // 
            // lblcliente
            // 
            this.lblcliente.AutoSize = true;
            this.lblcliente.Location = new System.Drawing.Point(26, 286);
            this.lblcliente.Name = "lblcliente";
            this.lblcliente.Size = new System.Drawing.Size(39, 13);
            this.lblcliente.TabIndex = 10;
            this.lblcliente.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo evento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total";
            // 
            // CBXIdiomas
            // 
            this.CBXIdiomas.FormattingEnabled = true;
            this.CBXIdiomas.Location = new System.Drawing.Point(846, 39);
            this.CBXIdiomas.Name = "CBXIdiomas";
            this.CBXIdiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXIdiomas.TabIndex = 13;
            // 
            // FrmRegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 450);
            this.Controls.Add(this.CBXIdiomas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblcliente);
            this.Controls.Add(this.TXTcliente);
            this.Controls.Add(this.TXTtipoevento);
            this.Controls.Add(this.TXTtotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNconfirmarPago);
            this.Controls.Add(this.CBXmetodopago);
            this.Controls.Add(this.TXTmonto);
            this.Controls.Add(this.DGVPresupuestosPendientes);
            this.Name = "FrmRegistrarPago";
            this.Text = "FrmRegistrarPago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistrarPago_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistrarPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPresupuestosPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVPresupuestosPendientes;
        private System.Windows.Forms.TextBox TXTmonto;
        private System.Windows.Forms.ComboBox CBXmetodopago;
        private System.Windows.Forms.Button BTNconfirmarPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTtotal;
        private System.Windows.Forms.TextBox TXTtipoevento;
        private System.Windows.Forms.TextBox TXTcliente;
        private System.Windows.Forms.Label lblcliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CBXIdiomas;
    }
}