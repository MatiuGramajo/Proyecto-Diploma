namespace Trabajo_practico_IS
{
    partial class FrmRegistrarEvaluacion
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
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.lblClienteInfo = new System.Windows.Forms.Label();
            this.lblFechaInfo = new System.Windows.Forms.Label();
            this.lblTipoEventoInfo = new System.Windows.Forms.Label();
            this.lblInvitadosInfo = new System.Windows.Forms.Label();
            this.cmbResultado = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnGuardarEvaluacion = new System.Windows.Forms.Button();
            this.btnVolverAlMenuPrincipal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEventos
            // 
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(12, 27);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.Size = new System.Drawing.Size(431, 150);
            this.dgvEventos.TabIndex = 0;
            this.dgvEventos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventos_CellClick);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Location = new System.Drawing.Point(531, 27);
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.Size = new System.Drawing.Size(431, 150);
            this.dgvPersonal.TabIndex = 1;
            // 
            // lblClienteInfo
            // 
            this.lblClienteInfo.AutoSize = true;
            this.lblClienteInfo.Location = new System.Drawing.Point(12, 213);
            this.lblClienteInfo.Name = "lblClienteInfo";
            this.lblClienteInfo.Size = new System.Drawing.Size(35, 13);
            this.lblClienteInfo.TabIndex = 2;
            this.lblClienteInfo.Text = "label1";
            // 
            // lblFechaInfo
            // 
            this.lblFechaInfo.AutoSize = true;
            this.lblFechaInfo.Location = new System.Drawing.Point(12, 248);
            this.lblFechaInfo.Name = "lblFechaInfo";
            this.lblFechaInfo.Size = new System.Drawing.Size(35, 13);
            this.lblFechaInfo.TabIndex = 3;
            this.lblFechaInfo.Text = "label2";
            // 
            // lblTipoEventoInfo
            // 
            this.lblTipoEventoInfo.AutoSize = true;
            this.lblTipoEventoInfo.Location = new System.Drawing.Point(12, 288);
            this.lblTipoEventoInfo.Name = "lblTipoEventoInfo";
            this.lblTipoEventoInfo.Size = new System.Drawing.Size(35, 13);
            this.lblTipoEventoInfo.TabIndex = 4;
            this.lblTipoEventoInfo.Text = "label3";
            // 
            // lblInvitadosInfo
            // 
            this.lblInvitadosInfo.AutoSize = true;
            this.lblInvitadosInfo.Location = new System.Drawing.Point(12, 330);
            this.lblInvitadosInfo.Name = "lblInvitadosInfo";
            this.lblInvitadosInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInvitadosInfo.TabIndex = 5;
            this.lblInvitadosInfo.Text = "label4";
            // 
            // cmbResultado
            // 
            this.cmbResultado.FormattingEnabled = true;
            this.cmbResultado.Location = new System.Drawing.Point(322, 213);
            this.cmbResultado.Name = "cmbResultado";
            this.cmbResultado.Size = new System.Drawing.Size(121, 21);
            this.cmbResultado.TabIndex = 6;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(322, 300);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(141, 80);
            this.txtObservaciones.TabIndex = 7;
            // 
            // btnGuardarEvaluacion
            // 
            this.btnGuardarEvaluacion.Location = new System.Drawing.Point(194, 405);
            this.btnGuardarEvaluacion.Name = "btnGuardarEvaluacion";
            this.btnGuardarEvaluacion.Size = new System.Drawing.Size(99, 33);
            this.btnGuardarEvaluacion.TabIndex = 8;
            this.btnGuardarEvaluacion.Text = "Guardar";
            this.btnGuardarEvaluacion.UseVisualStyleBackColor = true;
            this.btnGuardarEvaluacion.Click += new System.EventHandler(this.btnGuardarEvaluacion_Click);
            // 
            // btnVolverAlMenuPrincipal
            // 
            this.btnVolverAlMenuPrincipal.Location = new System.Drawing.Point(938, 390);
            this.btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            this.btnVolverAlMenuPrincipal.Size = new System.Drawing.Size(114, 48);
            this.btnVolverAlMenuPrincipal.TabIndex = 9;
            this.btnVolverAlMenuPrincipal.Text = "Volver Al Menu Principal";
            this.btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverAlMenuPrincipal.Click += new System.EventHandler(this.btnVolverAlMenuPrincipal_Click);
            // 
            // FrmRegistrarEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.btnVolverAlMenuPrincipal);
            this.Controls.Add(this.btnGuardarEvaluacion);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.cmbResultado);
            this.Controls.Add(this.lblInvitadosInfo);
            this.Controls.Add(this.lblTipoEventoInfo);
            this.Controls.Add(this.lblFechaInfo);
            this.Controls.Add(this.lblClienteInfo);
            this.Controls.Add(this.dgvPersonal);
            this.Controls.Add(this.dgvEventos);
            this.Name = "FrmRegistrarEvaluacion";
            this.Text = "FrmRegistrarEvaluacion";
            this.Load += new System.EventHandler(this.FrmRegistrarEvaluacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.Label lblClienteInfo;
        private System.Windows.Forms.Label lblFechaInfo;
        private System.Windows.Forms.Label lblTipoEventoInfo;
        private System.Windows.Forms.Label lblInvitadosInfo;
        private System.Windows.Forms.ComboBox cmbResultado;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnGuardarEvaluacion;
        private System.Windows.Forms.Button btnVolverAlMenuPrincipal;
    }
}