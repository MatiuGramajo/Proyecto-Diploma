namespace Trabajo_practico_IS
{
    partial class FrmGestionarPersonal
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
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnVolverAlMenuPrincipal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Location = new System.Drawing.Point(23, 33);
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.Size = new System.Drawing.Size(530, 96);
            this.dgvPersonal.TabIndex = 0;
            this.dgvPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonal_CellClick);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(23, 171);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(23, 221);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(150, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(23, 319);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(150, 20);
            this.txtTelefono.TabIndex = 3;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(23, 370);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(150, 20);
            this.txtDireccion.TabIndex = 4;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(23, 418);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(216, 452);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(106, 42);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.Location = new System.Drawing.Point(352, 452);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(106, 42);
            this.btnCambiarEstado.TabIndex = 8;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(485, 452);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 42);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Personal";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(23, 463);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(150, 21);
            this.cmbCategoria.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Categoria";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(23, 266);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(150, 20);
            this.txtDni.TabIndex = 19;
            // 
            // btnVolverAlMenuPrincipal
            // 
            this.btnVolverAlMenuPrincipal.Location = new System.Drawing.Point(680, 447);
            this.btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            this.btnVolverAlMenuPrincipal.Size = new System.Drawing.Size(92, 47);
            this.btnVolverAlMenuPrincipal.TabIndex = 21;
            this.btnVolverAlMenuPrincipal.Text = "Volver al Menu Principal";
            this.btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverAlMenuPrincipal.Click += new System.EventHandler(this.btnVolverAlMenuPrincipal_Click);
            // 
            // FrmGestionarPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnVolverAlMenuPrincipal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgvPersonal);
            this.Name = "FrmGestionarPersonal";
            this.Text = "FrmGestionarPersonal";
            this.Load += new System.EventHandler(this.FrmGestionarPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnVolverAlMenuPrincipal;
    }
}