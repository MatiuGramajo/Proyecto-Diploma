namespace Trabajo_practico_IS
{
    partial class FrmLogIn
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
            this.TxtBoxUsuario = new System.Windows.Forms.TextBox();
            this.TxtBoxPassword = new System.Windows.Forms.TextBox();
            this.BTN_IniciarSesion = new System.Windows.Forms.Button();
            this.LBLusuario = new System.Windows.Forms.Label();
            this.LBLpassword = new System.Windows.Forms.Label();
            this.CBXIdiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtBoxUsuario
            // 
            this.TxtBoxUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtBoxUsuario.Location = new System.Drawing.Point(53, 57);
            this.TxtBoxUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtBoxUsuario.Name = "TxtBoxUsuario";
            this.TxtBoxUsuario.Size = new System.Drawing.Size(116, 23);
            this.TxtBoxUsuario.TabIndex = 0;
            // 
            // TxtBoxPassword
            // 
            this.TxtBoxPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtBoxPassword.Location = new System.Drawing.Point(53, 143);
            this.TxtBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtBoxPassword.Name = "TxtBoxPassword";
            this.TxtBoxPassword.Size = new System.Drawing.Size(116, 23);
            this.TxtBoxPassword.TabIndex = 1;
            // 
            // BTN_IniciarSesion
            // 
            this.BTN_IniciarSesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_IniciarSesion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_IniciarSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_IniciarSesion.Location = new System.Drawing.Point(59, 186);
            this.BTN_IniciarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_IniciarSesion.Name = "BTN_IniciarSesion";
            this.BTN_IniciarSesion.Size = new System.Drawing.Size(105, 28);
            this.BTN_IniciarSesion.TabIndex = 2;
            this.BTN_IniciarSesion.Text = "Iniciar Sesion";
            this.BTN_IniciarSesion.UseVisualStyleBackColor = false;
            this.BTN_IniciarSesion.Click += new System.EventHandler(this.BTN_IniciarSesion_Click_1);
            // 
            // LBLusuario
            // 
            this.LBLusuario.AutoSize = true;
            this.LBLusuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLusuario.Location = new System.Drawing.Point(85, 36);
            this.LBLusuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLusuario.Name = "LBLusuario";
            this.LBLusuario.Size = new System.Drawing.Size(54, 17);
            this.LBLusuario.TabIndex = 4;
            this.LBLusuario.Text = "Usuario";
            // 
            // LBLpassword
            // 
            this.LBLpassword.AutoSize = true;
            this.LBLpassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLpassword.Location = new System.Drawing.Point(69, 122);
            this.LBLpassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLpassword.Name = "LBLpassword";
            this.LBLpassword.Size = new System.Drawing.Size(84, 17);
            this.LBLpassword.TabIndex = 5;
            this.LBLpassword.Text = "Contraseña";
            // 
            // CBXIdiomas
            // 
            this.CBXIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXIdiomas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBXIdiomas.FormattingEnabled = true;
            this.CBXIdiomas.Location = new System.Drawing.Point(218, 34);
            this.CBXIdiomas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBXIdiomas.Name = "CBXIdiomas";
            this.CBXIdiomas.Size = new System.Drawing.Size(140, 25);
            this.CBXIdiomas.TabIndex = 6;
            this.CBXIdiomas.SelectedIndexChanged += new System.EventHandler(this.CBXIdiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLidiomas.Location = new System.Drawing.Point(218, 15);
            this.LBLidiomas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(54, 17);
            this.LBLidiomas.TabIndex = 7;
            this.LBLidiomas.Text = "Idioma";
            this.LBLidiomas.Click += new System.EventHandler(this.LBLidiomas_Click);
            // 
            // FrmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(369, 242);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXIdiomas);
            this.Controls.Add(this.LBLpassword);
            this.Controls.Add(this.LBLusuario);
            this.Controls.Add(this.BTN_IniciarSesion);
            this.Controls.Add(this.TxtBoxPassword);
            this.Controls.Add(this.TxtBoxUsuario);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogIn_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxUsuario;
        private System.Windows.Forms.TextBox TxtBoxPassword;
        private System.Windows.Forms.Button BTN_IniciarSesion;
        private System.Windows.Forms.Label LBLusuario;
        private System.Windows.Forms.Label LBLpassword;
        private System.Windows.Forms.ComboBox CBXIdiomas;
        private System.Windows.Forms.Label LBLidiomas;
    }
}