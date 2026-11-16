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
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolverAlMenuPrincipal = new System.Windows.Forms.Button();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
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
            this.BtnIniciarPresupuesto.Location = new System.Drawing.Point(481, 375);
            this.BtnIniciarPresupuesto.Name = "BtnIniciarPresupuesto";
            this.BtnIniciarPresupuesto.Size = new System.Drawing.Size(133, 48);
            this.BtnIniciarPresupuesto.TabIndex = 3;
            this.BtnIniciarPresupuesto.Text = "Iniciar Presupuesto";
            this.BtnIniciarPresupuesto.UseVisualStyleBackColor = true;
            this.BtnIniciarPresupuesto.Click += new System.EventHandler(this.BtnIniciarPresupuesto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fechas Alternativas";
            // 
            // btnVolverAlMenuPrincipal
            // 
            this.btnVolverAlMenuPrincipal.Location = new System.Drawing.Point(802, 386);
            this.btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            this.btnVolverAlMenuPrincipal.Size = new System.Drawing.Size(111, 37);
            this.btnVolverAlMenuPrincipal.TabIndex = 5;
            this.btnVolverAlMenuPrincipal.Text = "Volver al Menu Principal";
            this.btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverAlMenuPrincipal.Click += new System.EventHandler(this.btnVolverAlMenuPrincipal_Click);
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(792, 40);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXidiomas.TabIndex = 6;
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(792, 24);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(43, 13);
            this.LBLidiomas.TabIndex = 7;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // FrmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 450);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.btnVolverAlMenuPrincipal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnIniciarPresupuesto);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "FrmCalendario";
            this.Text = "Calendario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCalendario_FormClosed);
            this.Load += new System.EventHandler(this.FrmCalendario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnIniciarPresupuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolverAlMenuPrincipal;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidiomas;
    }
}