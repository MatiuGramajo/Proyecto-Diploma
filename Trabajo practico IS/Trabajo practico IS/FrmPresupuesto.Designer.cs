namespace Trabajo_practico_IS
{
    partial class FrmPresupuesto
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.lblSubottal = new System.Windows.Forms.Label();
            this.BtnGeneralCotizacionFormal = new System.Windows.Forms.Button();
            this.BTNnuevoCliente = new System.Windows.Forms.Button();
            this.cbxclientes = new System.Windows.Forms.ComboBox();
            this.lblclienteseleccionado = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(313, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.Location = new System.Drawing.Point(182, 106);
            this.BtnCalcular.Name = "BtnCalcular";
            this.BtnCalcular.Size = new System.Drawing.Size(133, 42);
            this.BtnCalcular.TabIndex = 2;
            this.BtnCalcular.Text = "Calcular";
            this.BtnCalcular.UseVisualStyleBackColor = true;
            this.BtnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // lblSubottal
            // 
            this.lblSubottal.AutoSize = true;
            this.lblSubottal.Location = new System.Drawing.Point(16, 258);
            this.lblSubottal.Name = "lblSubottal";
            this.lblSubottal.Size = new System.Drawing.Size(0, 13);
            this.lblSubottal.TabIndex = 3;
            // 
            // BtnGeneralCotizacionFormal
            // 
            this.BtnGeneralCotizacionFormal.Enabled = false;
            this.BtnGeneralCotizacionFormal.Location = new System.Drawing.Point(19, 308);
            this.BtnGeneralCotizacionFormal.Name = "BtnGeneralCotizacionFormal";
            this.BtnGeneralCotizacionFormal.Size = new System.Drawing.Size(123, 34);
            this.BtnGeneralCotizacionFormal.TabIndex = 4;
            this.BtnGeneralCotizacionFormal.Text = "Generar Cotizacion";
            this.BtnGeneralCotizacionFormal.UseVisualStyleBackColor = true;
            this.BtnGeneralCotizacionFormal.Click += new System.EventHandler(this.BtnGeneralCotizacionFormal_Click);
            // 
            // BTNnuevoCliente
            // 
            this.BTNnuevoCliente.Enabled = false;
            this.BTNnuevoCliente.Location = new System.Drawing.Point(148, 40);
            this.BTNnuevoCliente.Name = "BTNnuevoCliente";
            this.BTNnuevoCliente.Size = new System.Drawing.Size(24, 23);
            this.BTNnuevoCliente.TabIndex = 5;
            this.BTNnuevoCliente.Text = "+";
            this.BTNnuevoCliente.UseVisualStyleBackColor = true;
            this.BTNnuevoCliente.Click += new System.EventHandler(this.BTNnuevoCliente_Click);
            // 
            // cbxclientes
            // 
            this.cbxclientes.FormattingEnabled = true;
            this.cbxclientes.Location = new System.Drawing.Point(6, 40);
            this.cbxclientes.Name = "cbxclientes";
            this.cbxclientes.Size = new System.Drawing.Size(121, 21);
            this.cbxclientes.TabIndex = 6;
            // 
            // lblclienteseleccionado
            // 
            this.lblclienteseleccionado.AutoSize = true;
            this.lblclienteseleccionado.Location = new System.Drawing.Point(72, 93);
            this.lblclienteseleccionado.Name = "lblclienteseleccionado";
            this.lblclienteseleccionado.Size = new System.Drawing.Size(0, 13);
            this.lblclienteseleccionado.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxclientes);
            this.groupBox1.Controls.Add(this.lblclienteseleccionado);
            this.groupBox1.Controls.Add(this.BTNnuevoCliente);
            this.groupBox1.Location = new System.Drawing.Point(549, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 173);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BtnGeneralCotizacionFormal);
            this.groupBox2.Controls.Add(this.lblSubottal);
            this.groupBox2.Controls.Add(this.BtnCalcular);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 413);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cotizar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cantidad de invitados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo de evento";
            // 
            // FrmPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPresupuesto";
            this.Text = "FrmPresupuesto";
            this.Load += new System.EventHandler(this.FrmPresupuesto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnCalcular;
        private System.Windows.Forms.Label lblSubottal;
        private System.Windows.Forms.Button BtnGeneralCotizacionFormal;
        private System.Windows.Forms.Button BTNnuevoCliente;
        private System.Windows.Forms.ComboBox cbxclientes;
        private System.Windows.Forms.Label lblclienteseleccionado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}