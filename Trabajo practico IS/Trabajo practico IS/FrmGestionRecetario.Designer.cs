namespace Trabajo_practico_IS
{
    partial class FrmGestionRecetario
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBXserviciocatering = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LBLunidadmedida = new System.Windows.Forms.Label();
            this.BTNagregarinsumo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTcantidadporpersona = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBXinsumo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BTNguardarrecetario = new System.Windows.Forms.Button();
            this.BTNquitarinsumo = new System.Windows.Forms.Button();
            this.DGVrecetario = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVrecetario)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBXserviciocatering);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccion de Servicio de Catering";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servicio de Catering";
            // 
            // CBXserviciocatering
            // 
            this.CBXserviciocatering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXserviciocatering.FormattingEnabled = true;
            this.CBXserviciocatering.Location = new System.Drawing.Point(6, 53);
            this.CBXserviciocatering.Name = "CBXserviciocatering";
            this.CBXserviciocatering.Size = new System.Drawing.Size(175, 21);
            this.CBXserviciocatering.TabIndex = 0;
            this.CBXserviciocatering.SelectedIndexChanged += new System.EventHandler(this.CBXserviciocatering_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LBLunidadmedida);
            this.groupBox2.Controls.Add(this.BTNagregarinsumo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TXTcantidadporpersona);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CBXinsumo);
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 251);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Ingrediente a la Receta";
            // 
            // LBLunidadmedida
            // 
            this.LBLunidadmedida.AutoSize = true;
            this.LBLunidadmedida.Location = new System.Drawing.Point(5, 95);
            this.LBLunidadmedida.Name = "LBLunidadmedida";
            this.LBLunidadmedida.Size = new System.Drawing.Size(109, 13);
            this.LBLunidadmedida.TabIndex = 6;
            this.LBLunidadmedida.Text = "Cantidad por Persona";
            // 
            // BTNagregarinsumo
            // 
            this.BTNagregarinsumo.Location = new System.Drawing.Point(155, 185);
            this.BTNagregarinsumo.Name = "BTNagregarinsumo";
            this.BTNagregarinsumo.Size = new System.Drawing.Size(127, 40);
            this.BTNagregarinsumo.TabIndex = 5;
            this.BTNagregarinsumo.Text = "Agregar Insumo";
            this.BTNagregarinsumo.UseVisualStyleBackColor = true;
            this.BTNagregarinsumo.Click += new System.EventHandler(this.BTNagregarinsumo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad por Persona";
            // 
            // TXTcantidadporpersona
            // 
            this.TXTcantidadporpersona.Location = new System.Drawing.Point(239, 54);
            this.TXTcantidadporpersona.Name = "TXTcantidadporpersona";
            this.TXTcantidadporpersona.Size = new System.Drawing.Size(83, 20);
            this.TXTcantidadporpersona.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Insumo del Catalogo";
            // 
            // CBXinsumo
            // 
            this.CBXinsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXinsumo.FormattingEnabled = true;
            this.CBXinsumo.Location = new System.Drawing.Point(8, 53);
            this.CBXinsumo.Name = "CBXinsumo";
            this.CBXinsumo.Size = new System.Drawing.Size(175, 21);
            this.CBXinsumo.TabIndex = 2;
            this.CBXinsumo.SelectedIndexChanged += new System.EventHandler(this.CBXinsumo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BTNguardarrecetario);
            this.groupBox3.Controls.Add(this.BTNquitarinsumo);
            this.groupBox3.Controls.Add(this.DGVrecetario);
            this.groupBox3.Location = new System.Drawing.Point(456, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 275);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Composicion del Menu";
            // 
            // BTNguardarrecetario
            // 
            this.BTNguardarrecetario.Location = new System.Drawing.Point(333, 219);
            this.BTNguardarrecetario.Name = "BTNguardarrecetario";
            this.BTNguardarrecetario.Size = new System.Drawing.Size(127, 40);
            this.BTNguardarrecetario.TabIndex = 8;
            this.BTNguardarrecetario.Text = "Guardar Recetario";
            this.BTNguardarrecetario.UseVisualStyleBackColor = true;
            this.BTNguardarrecetario.Click += new System.EventHandler(this.BTNguardarrecetario_Click);
            // 
            // BTNquitarinsumo
            // 
            this.BTNquitarinsumo.Location = new System.Drawing.Point(19, 219);
            this.BTNquitarinsumo.Name = "BTNquitarinsumo";
            this.BTNquitarinsumo.Size = new System.Drawing.Size(127, 40);
            this.BTNquitarinsumo.TabIndex = 7;
            this.BTNquitarinsumo.Text = "Quitar Insumo Seleccionado";
            this.BTNquitarinsumo.UseVisualStyleBackColor = true;
            this.BTNquitarinsumo.Click += new System.EventHandler(this.BTNquitarinsumo_Click);
            // 
            // DGVrecetario
            // 
            this.DGVrecetario.AllowUserToAddRows = false;
            this.DGVrecetario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVrecetario.Location = new System.Drawing.Point(19, 37);
            this.DGVrecetario.MultiSelect = false;
            this.DGVrecetario.Name = "DGVrecetario";
            this.DGVrecetario.ReadOnly = true;
            this.DGVrecetario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVrecetario.Size = new System.Drawing.Size(441, 150);
            this.DGVrecetario.TabIndex = 0;
            // 
            // FrmGestionRecetario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGestionRecetario";
            this.Text = "FrmGestionRecetario";
            this.Load += new System.EventHandler(this.FrmGestionRecetario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVrecetario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBXserviciocatering;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LBLunidadmedida;
        private System.Windows.Forms.Button BTNagregarinsumo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTcantidadporpersona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBXinsumo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGVrecetario;
        private System.Windows.Forms.Button BTNguardarrecetario;
        private System.Windows.Forms.Button BTNquitarinsumo;
    }
}