namespace Trabajo_practico_IS
{
    partial class FrmAnularReasignarOrdenCompra
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
            this.rbAnular = new System.Windows.Forms.RadioButton();
            this.rbReasignar = new System.Windows.Forms.RadioButton();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEmitidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdenesEmitidas
            // 
            this.dgvOrdenesEmitidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesEmitidas.Location = new System.Drawing.Point(12, 48);
            this.dgvOrdenesEmitidas.Name = "dgvOrdenesEmitidas";
            this.dgvOrdenesEmitidas.Size = new System.Drawing.Size(367, 126);
            this.dgvOrdenesEmitidas.TabIndex = 0;
            this.dgvOrdenesEmitidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesEmitidas_CellClick);
            // 
            // dgvDetalleOrden
            // 
            this.dgvDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleOrden.Location = new System.Drawing.Point(431, 48);
            this.dgvDetalleOrden.Name = "dgvDetalleOrden";
            this.dgvDetalleOrden.Size = new System.Drawing.Size(367, 126);
            this.dgvDetalleOrden.TabIndex = 1;
            // 
            // rbAnular
            // 
            this.rbAnular.AutoSize = true;
            this.rbAnular.Location = new System.Drawing.Point(12, 227);
            this.rbAnular.Name = "rbAnular";
            this.rbAnular.Size = new System.Drawing.Size(141, 17);
            this.rbAnular.TabIndex = 2;
            this.rbAnular.TabStop = true;
            this.rbAnular.Text = "Anular Orden de Compra";
            this.rbAnular.UseVisualStyleBackColor = true;
            this.rbAnular.CheckedChanged += new System.EventHandler(this.rbAnular_CheckedChanged);
            // 
            // rbReasignar
            // 
            this.rbReasignar.AutoSize = true;
            this.rbReasignar.Location = new System.Drawing.Point(220, 227);
            this.rbReasignar.Name = "rbReasignar";
            this.rbReasignar.Size = new System.Drawing.Size(159, 17);
            this.rbReasignar.TabIndex = 3;
            this.rbReasignar.TabStop = true;
            this.rbReasignar.Text = "Reasignar Orden de Compra";
            this.rbReasignar.UseVisualStyleBackColor = true;
            this.rbReasignar.CheckedChanged += new System.EventHandler(this.rbReasignar_CheckedChanged);
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(220, 284);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(121, 21);
            this.cmbProveedores.TabIndex = 4;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(12, 285);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(100, 20);
            this.txtMotivo.TabIndex = 5;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(273, 390);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(106, 48);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 390);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 48);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Motivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Proveedores";
            // 
            // FrmAnularReasignarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.cmbProveedores);
            this.Controls.Add(this.rbReasignar);
            this.Controls.Add(this.rbAnular);
            this.Controls.Add(this.dgvDetalleOrden);
            this.Controls.Add(this.dgvOrdenesEmitidas);
            this.Name = "FrmAnularReasignarOrdenCompra";
            this.Text = "FrmAnularReasignarOrdenCompra";
            this.Load += new System.EventHandler(this.FrmAnularReasignarOrdenCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEmitidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenesEmitidas;
        private System.Windows.Forms.DataGridView dgvDetalleOrden;
        private System.Windows.Forms.RadioButton rbAnular;
        private System.Windows.Forms.RadioButton rbReasignar;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}