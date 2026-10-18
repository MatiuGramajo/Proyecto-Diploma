namespace Trabajo_practico_IS
{
    partial class FrmCalendario
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.BtnIniciarPresupuesto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 40);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(481, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(262, 290);
            this.listBox1.TabIndex = 1;
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Location = new System.Drawing.Point(79, 271);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(133, 48);
            this.BtnConsultar.TabIndex = 2;
            this.BtnConsultar.Text = "Consultar Fecha";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // BtnIniciarPresupuesto
            // 
            this.BtnIniciarPresupuesto.Enabled = false;
            this.BtnIniciarPresupuesto.Location = new System.Drawing.Point(523, 381);
            this.BtnIniciarPresupuesto.Name = "BtnIniciarPresupuesto";
            this.BtnIniciarPresupuesto.Size = new System.Drawing.Size(133, 48);
            this.BtnIniciarPresupuesto.TabIndex = 3;
            this.BtnIniciarPresupuesto.Text = "Iniciar Presupuesto";
            this.BtnIniciarPresupuesto.UseVisualStyleBackColor = true;
            this.BtnIniciarPresupuesto.Click += new System.EventHandler(this.BtnIniciarPresupuesto_Click);
            // 
            // FrmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnIniciarPresupuesto);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "FrmCalendario";
            this.Text = "FrmCalendario";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnIniciarPresupuesto;
    }
}