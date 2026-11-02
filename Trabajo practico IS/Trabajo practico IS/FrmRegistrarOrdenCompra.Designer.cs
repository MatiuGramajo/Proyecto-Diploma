namespace Trabajo_practico_IS
{
    partial class FrmRegistrarOrdenCompra
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
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.cmbInsumos = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnEmitirOrden = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolverAlMenuPrincipal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(12, 210);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(121, 21);
            this.cmbProveedores.TabIndex = 0;
            // 
            // cmbInsumos
            // 
            this.cmbInsumos.FormattingEnabled = true;
            this.cmbInsumos.Location = new System.Drawing.Point(205, 210);
            this.cmbInsumos.Name = "cmbInsumos";
            this.cmbInsumos.Size = new System.Drawing.Size(121, 21);
            this.cmbInsumos.TabIndex = 1;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(392, 211);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 20);
            this.txtCantidad.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(44, 355);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(96, 40);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar a la Lista";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 25);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(726, 150);
            this.dgvDetalle.TabIndex = 4;
            // 
            // btnEmitirOrden
            // 
            this.btnEmitirOrden.Location = new System.Drawing.Point(230, 355);
            this.btnEmitirOrden.Name = "btnEmitirOrden";
            this.btnEmitirOrden.Size = new System.Drawing.Size(96, 40);
            this.btnEmitirOrden.TabIndex = 5;
            this.btnEmitirOrden.Text = "Emitir Orden de Compra";
            this.btnEmitirOrden.UseVisualStyleBackColor = true;
            this.btnEmitirOrden.Click += new System.EventHandler(this.btnEmitirOrden_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cantidad ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Proveedores";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Insumos";
            // 
            // btnVolverAlMenuPrincipal
            // 
            this.btnVolverAlMenuPrincipal.Location = new System.Drawing.Point(754, 390);
            this.btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            this.btnVolverAlMenuPrincipal.Size = new System.Drawing.Size(110, 35);
            this.btnVolverAlMenuPrincipal.TabIndex = 9;
            this.btnVolverAlMenuPrincipal.Text = "Volver al Menu Principal";
            this.btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverAlMenuPrincipal.Click += new System.EventHandler(this.btnVolverAlMenuPrincipal_Click);
            // 
            // FrmRegistrarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 450);
            this.Controls.Add(this.btnVolverAlMenuPrincipal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEmitirOrden);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbInsumos);
            this.Controls.Add(this.cmbProveedores);
            this.Name = "FrmRegistrarOrdenCompra";
            this.Text = "FrmRegistrarOrdenCompra";
            this.Load += new System.EventHandler(this.FrmRegistrarOrdenCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.ComboBox cmbInsumos;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnEmitirOrden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolverAlMenuPrincipal;
    }
}