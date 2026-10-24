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
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.BtnGuardarCliente = new System.Windows.Forms.Button();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lbldni = new System.Windows.Forms.Label();
            this.lbltelefono = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(12, 60);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(234, 20);
            this.txtnombre.TabIndex = 0;
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(12, 108);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(234, 20);
            this.txtdni.TabIndex = 1;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(12, 153);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(234, 20);
            this.txttelefono.TabIndex = 2;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(12, 201);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(234, 20);
            this.txtemail.TabIndex = 3;
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
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(12, 44);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(90, 13);
            this.lblnombre.TabIndex = 5;
            this.lblnombre.Text = "Nombre completo";
            // 
            // lbldni
            // 
            this.lbldni.AutoSize = true;
            this.lbldni.Location = new System.Drawing.Point(12, 92);
            this.lbldni.Name = "lbldni";
            this.lbldni.Size = new System.Drawing.Size(26, 13);
            this.lbldni.TabIndex = 6;
            this.lbldni.Text = "DNI";
            // 
            // lbltelefono
            // 
            this.lbltelefono.AutoSize = true;
            this.lbltelefono.Location = new System.Drawing.Point(9, 137);
            this.lbltelefono.Name = "lbltelefono";
            this.lbltelefono.Size = new System.Drawing.Size(49, 13);
            this.lbltelefono.TabIndex = 7;
            this.lbltelefono.Text = "Telefono";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(12, 185);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(32, 13);
            this.lblemail.TabIndex = 8;
            this.lblemail.Text = "Email";
            // 
            // FrmRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.lbltelefono);
            this.Controls.Add(this.lbldni);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.BtnGuardarCliente);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.txtnombre);
            this.Name = "FrmRegistrarCliente";
            this.Text = "FrmRegistrarCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistrarCliente_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistrarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Button BtnGuardarCliente;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lbldni;
        private System.Windows.Forms.Label lbltelefono;
        private System.Windows.Forms.Label lblemail;
    }
}