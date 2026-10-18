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
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(544, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.Location = new System.Drawing.Point(22, 174);
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
            this.lblSubottal.Location = new System.Drawing.Point(305, 309);
            this.lblSubottal.Name = "lblSubottal";
            this.lblSubottal.Size = new System.Drawing.Size(35, 13);
            this.lblSubottal.TabIndex = 3;
            this.lblSubottal.Text = "label1";
            // 
            // BtnGeneralCotizacionFormal
            // 
            this.BtnGeneralCotizacionFormal.Enabled = false;
            this.BtnGeneralCotizacionFormal.Location = new System.Drawing.Point(374, 234);
            this.BtnGeneralCotizacionFormal.Name = "BtnGeneralCotizacionFormal";
            this.BtnGeneralCotizacionFormal.Size = new System.Drawing.Size(123, 34);
            this.BtnGeneralCotizacionFormal.TabIndex = 4;
            this.BtnGeneralCotizacionFormal.Text = "Generar Cotizacion";
            this.BtnGeneralCotizacionFormal.UseVisualStyleBackColor = true;
            // 
            // FrmPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnGeneralCotizacionFormal);
            this.Controls.Add(this.lblSubottal);
            this.Controls.Add(this.BtnCalcular);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "FrmPresupuesto";
            this.Text = "FrmPresupuesto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnCalcular;
        private System.Windows.Forms.Label lblSubottal;
        private System.Windows.Forms.Button BtnGeneralCotizacionFormal;
    }
}