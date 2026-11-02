namespace Trabajo_practico_IS
{
    partial class FrmRegistrarRecepcionMercaderia
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
            this.dgvOrdenesEmitidas = new System.Windows.Forms.DataGridView();
            this.dgvDetalleOrden = new System.Windows.Forms.DataGridView();
            this.btnRegistrarREcepcion = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolverAlMenuPrincipal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEmitidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdenesEmitidas
            // 
            this.dgvOrdenesEmitidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesEmitidas.Location = new System.Drawing.Point(12, 40);
            this.dgvOrdenesEmitidas.Name = "dgvOrdenesEmitidas";
            this.dgvOrdenesEmitidas.Size = new System.Drawing.Size(430, 189);
            this.dgvOrdenesEmitidas.TabIndex = 0;
            this.dgvOrdenesEmitidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesEmitidas_CellClick);
            // 
            // dgvDetalleOrden
            // 
            this.dgvDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleOrden.Location = new System.Drawing.Point(505, 40);
            this.dgvDetalleOrden.Name = "dgvDetalleOrden";
            this.dgvDetalleOrden.Size = new System.Drawing.Size(430, 189);
            this.dgvDetalleOrden.TabIndex = 1;
            // 
            // btnRegistrarREcepcion
            // 
            this.btnRegistrarREcepcion.Location = new System.Drawing.Point(41, 318);
            this.btnRegistrarREcepcion.Name = "btnRegistrarREcepcion";
            this.btnRegistrarREcepcion.Size = new System.Drawing.Size(90, 34);
            this.btnRegistrarREcepcion.TabIndex = 2;
            this.btnRegistrarREcepcion.Text = "ActualizarStock";
            this.btnRegistrarREcepcion.UseVisualStyleBackColor = true;
            this.btnRegistrarREcepcion.Click += new System.EventHandler(this.btnRegistrarREcepcion_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(340, 318);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 34);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ordenes de Compra Emitidas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detalle Compra";
            // 
            // btnVolverAlMenuPrincipal
            // 
            this.btnVolverAlMenuPrincipal.Location = new System.Drawing.Point(958, 393);
            this.btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            this.btnVolverAlMenuPrincipal.Size = new System.Drawing.Size(110, 45);
            this.btnVolverAlMenuPrincipal.TabIndex = 6;
            this.btnVolverAlMenuPrincipal.Text = "Volver al Menu Principal";
            this.btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverAlMenuPrincipal.Click += new System.EventHandler(this.btnVolverAlMenuPrincipal_Click);
            // 
            // FrmRegistrarRecepcionMercaderia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 450);
            this.Controls.Add(this.btnVolverAlMenuPrincipal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrarREcepcion);
            this.Controls.Add(this.dgvDetalleOrden);
            this.Controls.Add(this.dgvOrdenesEmitidas);
            this.Name = "FrmRegistrarRecepcionMercaderia";
            this.Text = "FrmRegistrarRecepcionMercaderia";
            this.Load += new System.EventHandler(this.FrmRegistrarRecepcionMercaderia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEmitidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenesEmitidas;
        private System.Windows.Forms.DataGridView dgvDetalleOrden;
        private System.Windows.Forms.Button btnRegistrarREcepcion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolverAlMenuPrincipal;
    }
}