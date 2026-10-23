namespace Trabajo_practico_IS
{
    partial class FrmRegistrarCliente
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.BtnGuardarCliente = new System.Windows.Forms.Button();
            this.txtnombre = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 108);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(234, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 153);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(234, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 201);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(234, 20);
            this.textBox4.TabIndex = 3;
            // 
            // BtnGuardarCliente
            // 
            this.BtnGuardarCliente.Location = new System.Drawing.Point(64, 280);
            this.BtnGuardarCliente.Name = "BtnGuardarCliente";
            this.BtnGuardarCliente.Size = new System.Drawing.Size(114, 62);
            this.BtnGuardarCliente.TabIndex = 4;
            this.BtnGuardarCliente.Text = "Guardar";
            this.BtnGuardarCliente.UseVisualStyleBackColor = true;
            this.BtnGuardarCliente.Click += new System.EventHandler(this.BtnGuardarCliente_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.AutoSize = true;
            this.txtnombre.Location = new System.Drawing.Point(12, 44);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(90, 13);
            this.txtnombre.TabIndex = 5;
            this.txtnombre.Text = "Nombre completo";
            // 
            // txtdni
            // 
            this.txtdni.AutoSize = true;
            this.txtdni.Location = new System.Drawing.Point(12, 92);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(26, 13);
            this.txtdni.TabIndex = 6;
            this.txtdni.Text = "DNI";
            // 
            // txttelefono
            // 
            this.txttelefono.AutoSize = true;
            this.txttelefono.Location = new System.Drawing.Point(9, 137);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(49, 13);
            this.txttelefono.TabIndex = 7;
            this.txttelefono.Text = "Telefono";
            // 
            // txtemail
            // 
            this.txtemail.AutoSize = true;
            this.txtemail.Location = new System.Drawing.Point(12, 185);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(32, 13);
            this.txtemail.TabIndex = 8;
            this.txtemail.Text = "Email";
            // 
            // FrmRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.BtnGuardarCliente);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "FrmRegistrarCliente";
            this.Text = "FrmRegistrarCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistrarCliente_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistrarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button BtnGuardarCliente;
        private System.Windows.Forms.Label txtnombre;
        private System.Windows.Forms.Label txtdni;
        private System.Windows.Forms.Label txttelefono;
        private System.Windows.Forms.Label txtemail;
    }
}