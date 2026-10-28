namespace Trabajo_practico_IS
{
    partial class FrmFichaTecnica
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CBXcatering = new System.Windows.Forms.ComboBox();
            this.CLBprestadores = new System.Windows.Forms.CheckedListBox();
            this.GBseleccionarevento = new System.Windows.Forms.GroupBox();
            this.GBplanificarevento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LBLsaldopendiente = new System.Windows.Forms.Label();
            this.LBLseñapagada = new System.Windows.Forms.Label();
            this.LBLcostoprestadores = new System.Windows.Forms.Label();
            this.LBLcostototal = new System.Windows.Forms.Label();
            this.LBLcostocaterring = new System.Windows.Forms.Label();
            this.BTNlimpiar = new System.Windows.Forms.Button();
            this.BTNguardarficha = new System.Windows.Forms.Button();
            this.BTNvolverAlMenuPrincipal = new System.Windows.Forms.Button();
            this.BTNarrmarfichatecnica = new System.Windows.Forms.Button();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.LBLtipoevento = new System.Windows.Forms.Label();
            this.LBLseñapagada2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.GBseleccionarevento.SuspendLayout();
            this.GBplanificarevento.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // CBXcatering
            // 
            this.CBXcatering.FormattingEnabled = true;
            this.CBXcatering.Location = new System.Drawing.Point(135, 80);
            this.CBXcatering.Name = "CBXcatering";
            this.CBXcatering.Size = new System.Drawing.Size(189, 21);
            this.CBXcatering.TabIndex = 1;
            this.CBXcatering.SelectedIndexChanged += new System.EventHandler(this.CBXcatering_SelectedIndexChanged);
            // 
            // CLBprestadores
            // 
            this.CLBprestadores.FormattingEnabled = true;
            this.CLBprestadores.Location = new System.Drawing.Point(9, 209);
            this.CLBprestadores.Name = "CLBprestadores";
            this.CLBprestadores.Size = new System.Drawing.Size(315, 94);
            this.CLBprestadores.TabIndex = 2;
            this.CLBprestadores.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBprestadores_ItemCheck);
            // 
            // GBseleccionarevento
            // 
            this.GBseleccionarevento.Controls.Add(this.LBLseñapagada2);
            this.GBseleccionarevento.Controls.Add(this.LBLtipoevento);
            this.GBseleccionarevento.Controls.Add(this.LBLnombre);
            this.GBseleccionarevento.Controls.Add(this.dataGridView1);
            this.GBseleccionarevento.Location = new System.Drawing.Point(12, 22);
            this.GBseleccionarevento.Name = "GBseleccionarevento";
            this.GBseleccionarevento.Size = new System.Drawing.Size(585, 348);
            this.GBseleccionarevento.TabIndex = 3;
            this.GBseleccionarevento.TabStop = false;
            this.GBseleccionarevento.Text = "Seleccionar Evento";
            // 
            // GBplanificarevento
            // 
            this.GBplanificarevento.Controls.Add(this.label3);
            this.GBplanificarevento.Controls.Add(this.label2);
            this.GBplanificarevento.Controls.Add(this.textBox1);
            this.GBplanificarevento.Controls.Add(this.CLBprestadores);
            this.GBplanificarevento.Controls.Add(this.label1);
            this.GBplanificarevento.Controls.Add(this.CBXcatering);
            this.GBplanificarevento.Location = new System.Drawing.Point(622, 22);
            this.GBplanificarevento.Name = "GBplanificarevento";
            this.GBplanificarevento.Size = new System.Drawing.Size(350, 349);
            this.GBplanificarevento.TabIndex = 4;
            this.GBplanificarevento.TabStop = false;
            this.GBplanificarevento.Text = "Detalles de la Ficha Tecnica";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Prestadores de Servicios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Catering";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invitados Confirmados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LBLsaldopendiente);
            this.groupBox2.Controls.Add(this.LBLseñapagada);
            this.groupBox2.Controls.Add(this.LBLcostoprestadores);
            this.groupBox2.Controls.Add(this.LBLcostototal);
            this.groupBox2.Controls.Add(this.LBLcostocaterring);
            this.groupBox2.Location = new System.Drawing.Point(12, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 176);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resumen financiero";
            // 
            // LBLsaldopendiente
            // 
            this.LBLsaldopendiente.AutoSize = true;
            this.LBLsaldopendiente.Location = new System.Drawing.Point(6, 128);
            this.LBLsaldopendiente.Name = "LBLsaldopendiente";
            this.LBLsaldopendiente.Size = new System.Drawing.Size(108, 13);
            this.LBLsaldopendiente.TabIndex = 8;
            this.LBLsaldopendiente.Text = "SALDO PENDIENTE";
            // 
            // LBLseñapagada
            // 
            this.LBLseñapagada.AutoSize = true;
            this.LBLseñapagada.Location = new System.Drawing.Point(296, 87);
            this.LBLseñapagada.Name = "LBLseñapagada";
            this.LBLseñapagada.Size = new System.Drawing.Size(72, 13);
            this.LBLseñapagada.TabIndex = 7;
            this.LBLseñapagada.Text = "Seña Pagada";
            // 
            // LBLcostoprestadores
            // 
            this.LBLcostoprestadores.AutoSize = true;
            this.LBLcostoprestadores.Location = new System.Drawing.Point(296, 41);
            this.LBLcostoprestadores.Name = "LBLcostoprestadores";
            this.LBLcostoprestadores.Size = new System.Drawing.Size(93, 13);
            this.LBLcostoprestadores.TabIndex = 6;
            this.LBLcostoprestadores.Text = "Costo Prestadores";
            // 
            // LBLcostototal
            // 
            this.LBLcostototal.AutoSize = true;
            this.LBLcostototal.Location = new System.Drawing.Point(6, 87);
            this.LBLcostototal.Name = "LBLcostototal";
            this.LBLcostototal.Size = new System.Drawing.Size(119, 13);
            this.LBLcostototal.TabIndex = 5;
            this.LBLcostototal.Text = "COSTO TOTAL REAL: ";
            // 
            // LBLcostocaterring
            // 
            this.LBLcostocaterring.AutoSize = true;
            this.LBLcostocaterring.Location = new System.Drawing.Point(6, 41);
            this.LBLcostocaterring.Name = "LBLcostocaterring";
            this.LBLcostocaterring.Size = new System.Drawing.Size(90, 13);
            this.LBLcostocaterring.TabIndex = 4;
            this.LBLcostocaterring.Text = "Costo de catering";
            // 
            // BTNlimpiar
            // 
            this.BTNlimpiar.Location = new System.Drawing.Point(622, 398);
            this.BTNlimpiar.Name = "BTNlimpiar";
            this.BTNlimpiar.Size = new System.Drawing.Size(96, 50);
            this.BTNlimpiar.TabIndex = 6;
            this.BTNlimpiar.Text = "Limpiar ";
            this.BTNlimpiar.UseVisualStyleBackColor = true;
            // 
            // BTNguardarficha
            // 
            this.BTNguardarficha.Location = new System.Drawing.Point(832, 400);
            this.BTNguardarficha.Name = "BTNguardarficha";
            this.BTNguardarficha.Size = new System.Drawing.Size(96, 49);
            this.BTNguardarficha.TabIndex = 7;
            this.BTNguardarficha.Text = "Guardar Ficha Tecnica";
            this.BTNguardarficha.UseVisualStyleBackColor = true;
            this.BTNguardarficha.Click += new System.EventHandler(this.BTNguardarficha_Click);
            // 
            // BTNvolverAlMenuPrincipal
            // 
            this.BTNvolverAlMenuPrincipal.Location = new System.Drawing.Point(1006, 461);
            this.BTNvolverAlMenuPrincipal.Name = "BTNvolverAlMenuPrincipal";
            this.BTNvolverAlMenuPrincipal.Size = new System.Drawing.Size(101, 51);
            this.BTNvolverAlMenuPrincipal.TabIndex = 8;
            this.BTNvolverAlMenuPrincipal.Text = "Volver al menu principal";
            this.BTNvolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            // 
            // BTNarrmarfichatecnica
            // 
            this.BTNarrmarfichatecnica.Location = new System.Drawing.Point(730, 399);
            this.BTNarrmarfichatecnica.Name = "BTNarrmarfichatecnica";
            this.BTNarrmarfichatecnica.Size = new System.Drawing.Size(96, 50);
            this.BTNarrmarfichatecnica.TabIndex = 9;
            this.BTNarrmarfichatecnica.Text = "Armar Ficha Tecnica";
            this.BTNarrmarfichatecnica.UseVisualStyleBackColor = true;
            this.BTNarrmarfichatecnica.Click += new System.EventHandler(this.BTNarrmarfichatecnica_Click);
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Location = new System.Drawing.Point(14, 227);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(44, 13);
            this.LBLnombre.TabIndex = 1;
            this.LBLnombre.Text = "Nombre";
            // 
            // LBLtipoevento
            // 
            this.LBLtipoevento.AutoSize = true;
            this.LBLtipoevento.Location = new System.Drawing.Point(14, 264);
            this.LBLtipoevento.Name = "LBLtipoevento";
            this.LBLtipoevento.Size = new System.Drawing.Size(80, 13);
            this.LBLtipoevento.TabIndex = 2;
            this.LBLtipoevento.Text = "Tipo de Evento";
            // 
            // LBLseñapagada2
            // 
            this.LBLseñapagada2.AutoSize = true;
            this.LBLseñapagada2.Location = new System.Drawing.Point(14, 309);
            this.LBLseñapagada2.Name = "LBLseñapagada2";
            this.LBLseñapagada2.Size = new System.Drawing.Size(72, 13);
            this.LBLseñapagada2.TabIndex = 8;
            this.LBLseñapagada2.Text = "Seña Pagada";
            // 
            // FrmFichaTecnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 564);
            this.Controls.Add(this.BTNarrmarfichatecnica);
            this.Controls.Add(this.BTNvolverAlMenuPrincipal);
            this.Controls.Add(this.BTNguardarficha);
            this.Controls.Add(this.BTNlimpiar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GBplanificarevento);
            this.Controls.Add(this.GBseleccionarevento);
            this.Name = "FrmFichaTecnica";
            this.Text = "FrmFichaTecnica";
            this.Load += new System.EventHandler(this.FrmFichaTecnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.GBseleccionarevento.ResumeLayout(false);
            this.GBseleccionarevento.PerformLayout();
            this.GBplanificarevento.ResumeLayout(false);
            this.GBplanificarevento.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CBXcatering;
        private System.Windows.Forms.CheckedListBox CLBprestadores;
        private System.Windows.Forms.GroupBox GBseleccionarevento;
        private System.Windows.Forms.GroupBox GBplanificarevento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LBLcostocaterring;
        private System.Windows.Forms.Label LBLsaldopendiente;
        private System.Windows.Forms.Label LBLseñapagada;
        private System.Windows.Forms.Label LBLcostoprestadores;
        private System.Windows.Forms.Label LBLcostototal;
        private System.Windows.Forms.Button BTNlimpiar;
        private System.Windows.Forms.Button BTNguardarficha;
        private System.Windows.Forms.Button BTNvolverAlMenuPrincipal;
        private System.Windows.Forms.Button BTNarrmarfichatecnica;
        private System.Windows.Forms.Label LBLseñapagada2;
        private System.Windows.Forms.Label LBLtipoevento;
        private System.Windows.Forms.Label LBLnombre;
    }
}