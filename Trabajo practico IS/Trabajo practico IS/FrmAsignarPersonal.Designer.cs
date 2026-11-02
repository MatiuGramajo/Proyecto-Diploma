namespace Trabajo_practico_IS
{
    partial class FrmAsignarPersonal
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
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.lblInvitadosInfo = new System.Windows.Forms.Label();
            this.lblRequerimientos = new System.Windows.Forms.Label();
            this.dgvPersonalDisponible = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVolverAlMenuPrincipal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalDisponible)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReservas
            // 
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(31, 51);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.Size = new System.Drawing.Size(352, 122);
            this.dgvReservas.TabIndex = 0;
            this.dgvReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellClick);
            // 
            // lblInvitadosInfo
            // 
            this.lblInvitadosInfo.AutoSize = true;
            this.lblInvitadosInfo.Location = new System.Drawing.Point(28, 219);
            this.lblInvitadosInfo.Name = "lblInvitadosInfo";
            this.lblInvitadosInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInvitadosInfo.TabIndex = 1;
            this.lblInvitadosInfo.Text = "label1";
            // 
            // lblRequerimientos
            // 
            this.lblRequerimientos.AutoSize = true;
            this.lblRequerimientos.Location = new System.Drawing.Point(28, 258);
            this.lblRequerimientos.Name = "lblRequerimientos";
            this.lblRequerimientos.Size = new System.Drawing.Size(35, 13);
            this.lblRequerimientos.TabIndex = 2;
            this.lblRequerimientos.Text = "label2";
            // 
            // dgvPersonalDisponible
            // 
            this.dgvPersonalDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonalDisponible.Location = new System.Drawing.Point(441, 51);
            this.dgvPersonalDisponible.Name = "dgvPersonalDisponible";
            this.dgvPersonalDisponible.Size = new System.Drawing.Size(672, 316);
            this.dgvPersonalDisponible.TabIndex = 3;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(749, 400);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 37);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmarr";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnVolverAlMenuPrincipal
            // 
            this.btnVolverAlMenuPrincipal.Location = new System.Drawing.Point(970, 400);
            this.btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            this.btnVolverAlMenuPrincipal.Size = new System.Drawing.Size(96, 38);
            this.btnVolverAlMenuPrincipal.TabIndex = 5;
            this.btnVolverAlMenuPrincipal.Text = "Volver al Menu Principal";
            this.btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverAlMenuPrincipal.Click += new System.EventHandler(this.btnVolverAlMenuPrincipal_Click);
            // 
            // FrmAsignarPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 450);
            this.Controls.Add(this.btnVolverAlMenuPrincipal);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvPersonalDisponible);
            this.Controls.Add(this.lblRequerimientos);
            this.Controls.Add(this.lblInvitadosInfo);
            this.Controls.Add(this.dgvReservas);
            this.Name = "FrmAsignarPersonal";
            this.Text = "FrmAsignarPersonal";
            this.Load += new System.EventHandler(this.FrmAsignarPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalDisponible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Label lblInvitadosInfo;
        private System.Windows.Forms.Label lblRequerimientos;
        private System.Windows.Forms.DataGridView dgvPersonalDisponible;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnVolverAlMenuPrincipal;
    }
}