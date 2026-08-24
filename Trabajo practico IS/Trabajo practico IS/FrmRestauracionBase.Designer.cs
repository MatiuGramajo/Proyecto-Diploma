namespace Trabajo_practico_IS
{
    partial class FrmRestauracionBase
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
            this.LBMensajeError = new System.Windows.Forms.Label();
            this.OFDBackUp = new System.Windows.Forms.OpenFileDialog();
            this.SFDBackUp = new System.Windows.Forms.SaveFileDialog();
            this.BTNHacerBackUp = new System.Windows.Forms.Button();
            this.TXTRutaBackUp = new System.Windows.Forms.TextBox();
            this.BTNRestaurarBase = new System.Windows.Forms.Button();
            this.BTNRecalcularDigito = new System.Windows.Forms.Button();
            this.BTNRestauracionVolverMenu = new System.Windows.Forms.Button();
            this.BTNExaminarBackUp = new System.Windows.Forms.Button();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBMensajeError
            // 
            this.LBMensajeError.AutoSize = true;
            this.LBMensajeError.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBMensajeError.Location = new System.Drawing.Point(14, 31);
            this.LBMensajeError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBMensajeError.Name = "LBMensajeError";
            this.LBMensajeError.Size = new System.Drawing.Size(47, 17);
            this.LBMensajeError.TabIndex = 1;
            this.LBMensajeError.Text = "label1";
            // 
            // BTNHacerBackUp
            // 
            this.BTNHacerBackUp.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNHacerBackUp.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.BTNHacerBackUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNHacerBackUp.Location = new System.Drawing.Point(14, 192);
            this.BTNHacerBackUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNHacerBackUp.Name = "BTNHacerBackUp";
            this.BTNHacerBackUp.Size = new System.Drawing.Size(145, 33);
            this.BTNHacerBackUp.TabIndex = 2;
            this.BTNHacerBackUp.Text = "Crear BackUp";
            this.BTNHacerBackUp.UseVisualStyleBackColor = false;
            this.BTNHacerBackUp.Click += new System.EventHandler(this.BTNHacerBackUp_Click);
            // 
            // TXTRutaBackUp
            // 
            this.TXTRutaBackUp.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTRutaBackUp.Location = new System.Drawing.Point(14, 236);
            this.TXTRutaBackUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TXTRutaBackUp.Name = "TXTRutaBackUp";
            this.TXTRutaBackUp.ReadOnly = true;
            this.TXTRutaBackUp.Size = new System.Drawing.Size(396, 23);
            this.TXTRutaBackUp.TabIndex = 3;
            // 
            // BTNRestaurarBase
            // 
            this.BTNRestaurarBase.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNRestaurarBase.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.BTNRestaurarBase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNRestaurarBase.Location = new System.Drawing.Point(569, 231);
            this.BTNRestaurarBase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNRestaurarBase.Name = "BTNRestaurarBase";
            this.BTNRestaurarBase.Size = new System.Drawing.Size(145, 33);
            this.BTNRestaurarBase.TabIndex = 4;
            this.BTNRestaurarBase.Text = "Restaurar Base";
            this.BTNRestaurarBase.UseVisualStyleBackColor = false;
            this.BTNRestaurarBase.Click += new System.EventHandler(this.BTNRestaurarBase_Click);
            // 
            // BTNRecalcularDigito
            // 
            this.BTNRecalcularDigito.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNRecalcularDigito.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.BTNRecalcularDigito.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNRecalcularDigito.Location = new System.Drawing.Point(14, 272);
            this.BTNRecalcularDigito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNRecalcularDigito.Name = "BTNRecalcularDigito";
            this.BTNRecalcularDigito.Size = new System.Drawing.Size(212, 33);
            this.BTNRecalcularDigito.TabIndex = 5;
            this.BTNRecalcularDigito.Text = "Recalcular digito verificador";
            this.BTNRecalcularDigito.UseVisualStyleBackColor = false;
            this.BTNRecalcularDigito.Click += new System.EventHandler(this.BTNRecalcularDigito_Click);
            // 
            // BTNRestauracionVolverMenu
            // 
            this.BTNRestauracionVolverMenu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNRestauracionVolverMenu.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.BTNRestauracionVolverMenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNRestauracionVolverMenu.Location = new System.Drawing.Point(746, 348);
            this.BTNRestauracionVolverMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNRestauracionVolverMenu.Name = "BTNRestauracionVolverMenu";
            this.BTNRestauracionVolverMenu.Size = new System.Drawing.Size(145, 33);
            this.BTNRestauracionVolverMenu.TabIndex = 6;
            this.BTNRestauracionVolverMenu.Text = "Volver al menu";
            this.BTNRestauracionVolverMenu.UseVisualStyleBackColor = false;
            this.BTNRestauracionVolverMenu.Click += new System.EventHandler(this.BTNRestauracionVolverMenu_Click);
            // 
            // BTNExaminarBackUp
            // 
            this.BTNExaminarBackUp.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNExaminarBackUp.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.BTNExaminarBackUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNExaminarBackUp.Location = new System.Drawing.Point(418, 231);
            this.BTNExaminarBackUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTNExaminarBackUp.Name = "BTNExaminarBackUp";
            this.BTNExaminarBackUp.Size = new System.Drawing.Size(145, 33);
            this.BTNExaminarBackUp.TabIndex = 7;
            this.BTNExaminarBackUp.Text = "Examinar";
            this.BTNExaminarBackUp.UseVisualStyleBackColor = false;
            this.BTNExaminarBackUp.Click += new System.EventHandler(this.BTNExaminarBackUp_Click);
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(749, 47);
            this.CBXidiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(140, 25);
            this.CBXidiomas.TabIndex = 8;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLidiomas.Location = new System.Drawing.Point(749, 27);
            this.LBLidiomas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(59, 17);
            this.LBLidiomas.TabIndex = 9;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // FrmRestauracionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(901, 395);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.BTNExaminarBackUp);
            this.Controls.Add(this.BTNRestauracionVolverMenu);
            this.Controls.Add(this.BTNRecalcularDigito);
            this.Controls.Add(this.BTNRestaurarBase);
            this.Controls.Add(this.TXTRutaBackUp);
            this.Controls.Add(this.BTNHacerBackUp);
            this.Controls.Add(this.LBMensajeError);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmRestauracionBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRestauracionBase";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRestauracionBase_FormClosed);
            this.Load += new System.EventHandler(this.FrmRestauracionBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBMensajeError;
        private System.Windows.Forms.OpenFileDialog OFDBackUp;
        private System.Windows.Forms.SaveFileDialog SFDBackUp;
        private System.Windows.Forms.Button BTNHacerBackUp;
        private System.Windows.Forms.TextBox TXTRutaBackUp;
        private System.Windows.Forms.Button BTNRestaurarBase;
        private System.Windows.Forms.Button BTNRecalcularDigito;
        private System.Windows.Forms.Button BTNRestauracionVolverMenu;
        private System.Windows.Forms.Button BTNExaminarBackUp;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidiomas;
    }
}