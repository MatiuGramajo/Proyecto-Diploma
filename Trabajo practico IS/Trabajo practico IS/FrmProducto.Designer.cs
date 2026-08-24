namespace Trabajo_practico_IS
{
    partial class FrmProducto
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
            this.DGV_Productos = new System.Windows.Forms.DataGridView();
            this.BTN_ProductoAlta = new System.Windows.Forms.Button();
            this.BTN_ProductoBaja = new System.Windows.Forms.Button();
            this.BTN_ProductoModificar = new System.Windows.Forms.Button();
            this.TXT_ProductoNombre = new System.Windows.Forms.TextBox();
            this.NUD_PrecioProd = new System.Windows.Forms.NumericUpDown();
            this.NUD_StockProd = new System.Windows.Forms.NumericUpDown();
            this.CBXIdiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.GB_Producto = new System.Windows.Forms.GroupBox();
            this.LBLStockProducto = new System.Windows.Forms.Label();
            this.LBLNombreProducto = new System.Windows.Forms.Label();
            this.LBLPrecioProducto = new System.Windows.Forms.Label();
            this.GB_Productos = new System.Windows.Forms.GroupBox();
            this.BTNvolveralmenu = new System.Windows.Forms.Button();
            this.BTN_ProductoReactivar = new System.Windows.Forms.Button();
            this.CKXmostrarInactivos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Productos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PrecioProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StockProd)).BeginInit();
            this.GB_Producto.SuspendLayout();
            this.GB_Productos.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Productos
            // 
            this.DGV_Productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Productos.Location = new System.Drawing.Point(12, 30);
            this.DGV_Productos.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_Productos.Name = "DGV_Productos";
            this.DGV_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Productos.Size = new System.Drawing.Size(746, 268);
            this.DGV_Productos.TabIndex = 0;
            this.DGV_Productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Productos_CellClick);
            this.DGV_Productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Productos_CellContentClick);
            // 
            // BTN_ProductoAlta
            // 
            this.BTN_ProductoAlta.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_ProductoAlta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ProductoAlta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_ProductoAlta.Location = new System.Drawing.Point(316, 388);
            this.BTN_ProductoAlta.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_ProductoAlta.Name = "BTN_ProductoAlta";
            this.BTN_ProductoAlta.Size = new System.Drawing.Size(145, 33);
            this.BTN_ProductoAlta.TabIndex = 1;
            this.BTN_ProductoAlta.Text = "Alta";
            this.BTN_ProductoAlta.UseVisualStyleBackColor = false;
            this.BTN_ProductoAlta.Click += new System.EventHandler(this.BTN_ProductoAlta_Click);
            // 
            // BTN_ProductoBaja
            // 
            this.BTN_ProductoBaja.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_ProductoBaja.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ProductoBaja.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_ProductoBaja.Location = new System.Drawing.Point(468, 388);
            this.BTN_ProductoBaja.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_ProductoBaja.Name = "BTN_ProductoBaja";
            this.BTN_ProductoBaja.Size = new System.Drawing.Size(145, 33);
            this.BTN_ProductoBaja.TabIndex = 2;
            this.BTN_ProductoBaja.Text = "Baja";
            this.BTN_ProductoBaja.UseVisualStyleBackColor = false;
            this.BTN_ProductoBaja.Click += new System.EventHandler(this.BTN_ProductoBaja_Click);
            // 
            // BTN_ProductoModificar
            // 
            this.BTN_ProductoModificar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_ProductoModificar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ProductoModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_ProductoModificar.Location = new System.Drawing.Point(620, 388);
            this.BTN_ProductoModificar.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_ProductoModificar.Name = "BTN_ProductoModificar";
            this.BTN_ProductoModificar.Size = new System.Drawing.Size(145, 33);
            this.BTN_ProductoModificar.TabIndex = 3;
            this.BTN_ProductoModificar.Text = "Modificar";
            this.BTN_ProductoModificar.UseVisualStyleBackColor = false;
            this.BTN_ProductoModificar.Click += new System.EventHandler(this.BTN_ProductoModificar_Click);
            // 
            // TXT_ProductoNombre
            // 
            this.TXT_ProductoNombre.Location = new System.Drawing.Point(10, 47);
            this.TXT_ProductoNombre.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_ProductoNombre.Name = "TXT_ProductoNombre";
            this.TXT_ProductoNombre.Size = new System.Drawing.Size(257, 23);
            this.TXT_ProductoNombre.TabIndex = 4;
            // 
            // NUD_PrecioProd
            // 
            this.NUD_PrecioProd.BackColor = System.Drawing.SystemColors.Window;
            this.NUD_PrecioProd.DecimalPlaces = 2;
            this.NUD_PrecioProd.Location = new System.Drawing.Point(10, 97);
            this.NUD_PrecioProd.Margin = new System.Windows.Forms.Padding(4);
            this.NUD_PrecioProd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUD_PrecioProd.Name = "NUD_PrecioProd";
            this.NUD_PrecioProd.Size = new System.Drawing.Size(117, 23);
            this.NUD_PrecioProd.TabIndex = 5;
            // 
            // NUD_StockProd
            // 
            this.NUD_StockProd.Location = new System.Drawing.Point(10, 148);
            this.NUD_StockProd.Margin = new System.Windows.Forms.Padding(4);
            this.NUD_StockProd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_StockProd.Name = "NUD_StockProd";
            this.NUD_StockProd.Size = new System.Drawing.Size(117, 23);
            this.NUD_StockProd.TabIndex = 6;
            // 
            // CBXIdiomas
            // 
            this.CBXIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXIdiomas.FormattingEnabled = true;
            this.CBXIdiomas.Location = new System.Drawing.Point(804, 43);
            this.CBXIdiomas.Margin = new System.Windows.Forms.Padding(4);
            this.CBXIdiomas.Name = "CBXIdiomas";
            this.CBXIdiomas.Size = new System.Drawing.Size(140, 24);
            this.CBXIdiomas.TabIndex = 7;
            this.CBXIdiomas.SelectedIndexChanged += new System.EventHandler(this.CBXIdiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.LBLidiomas.Location = new System.Drawing.Point(804, 23);
            this.LBLidiomas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(47, 17);
            this.LBLidiomas.TabIndex = 8;
            this.LBLidiomas.Text = "label1";
            // 
            // GB_Producto
            // 
            this.GB_Producto.Controls.Add(this.LBLStockProducto);
            this.GB_Producto.Controls.Add(this.LBLNombreProducto);
            this.GB_Producto.Controls.Add(this.LBLPrecioProducto);
            this.GB_Producto.Controls.Add(this.TXT_ProductoNombre);
            this.GB_Producto.Controls.Add(this.NUD_PrecioProd);
            this.GB_Producto.Controls.Add(this.NUD_StockProd);
            this.GB_Producto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.GB_Producto.Location = new System.Drawing.Point(15, 350);
            this.GB_Producto.Margin = new System.Windows.Forms.Padding(4);
            this.GB_Producto.Name = "GB_Producto";
            this.GB_Producto.Padding = new System.Windows.Forms.Padding(4);
            this.GB_Producto.Size = new System.Drawing.Size(294, 188);
            this.GB_Producto.TabIndex = 9;
            this.GB_Producto.TabStop = false;
            this.GB_Producto.Text = "Datos del producto";
            // 
            // LBLStockProducto
            // 
            this.LBLStockProducto.AutoSize = true;
            this.LBLStockProducto.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLStockProducto.Location = new System.Drawing.Point(10, 127);
            this.LBLStockProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLStockProducto.Name = "LBLStockProducto";
            this.LBLStockProducto.Size = new System.Drawing.Size(42, 17);
            this.LBLStockProducto.TabIndex = 12;
            this.LBLStockProducto.Text = "Stock";
            // 
            // LBLNombreProducto
            // 
            this.LBLNombreProducto.AutoSize = true;
            this.LBLNombreProducto.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLNombreProducto.Location = new System.Drawing.Point(10, 26);
            this.LBLNombreProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLNombreProducto.Name = "LBLNombreProducto";
            this.LBLNombreProducto.Size = new System.Drawing.Size(56, 17);
            this.LBLNombreProducto.TabIndex = 10;
            this.LBLNombreProducto.Text = "Nombre";
            // 
            // LBLPrecioProducto
            // 
            this.LBLPrecioProducto.AutoSize = true;
            this.LBLPrecioProducto.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLPrecioProducto.Location = new System.Drawing.Point(10, 76);
            this.LBLPrecioProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLPrecioProducto.Name = "LBLPrecioProducto";
            this.LBLPrecioProducto.Size = new System.Drawing.Size(46, 17);
            this.LBLPrecioProducto.TabIndex = 11;
            this.LBLPrecioProducto.Text = "Precio";
            // 
            // GB_Productos
            // 
            this.GB_Productos.Controls.Add(this.DGV_Productos);
            this.GB_Productos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_Productos.Location = new System.Drawing.Point(15, 14);
            this.GB_Productos.Margin = new System.Windows.Forms.Padding(4);
            this.GB_Productos.Name = "GB_Productos";
            this.GB_Productos.Padding = new System.Windows.Forms.Padding(4);
            this.GB_Productos.Size = new System.Drawing.Size(771, 313);
            this.GB_Productos.TabIndex = 10;
            this.GB_Productos.TabStop = false;
            this.GB_Productos.Text = "Productos";
            // 
            // BTNvolveralmenu
            // 
            this.BTNvolveralmenu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTNvolveralmenu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolveralmenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNvolveralmenu.Location = new System.Drawing.Point(773, 505);
            this.BTNvolveralmenu.Margin = new System.Windows.Forms.Padding(4);
            this.BTNvolveralmenu.Name = "BTNvolveralmenu";
            this.BTNvolveralmenu.Size = new System.Drawing.Size(145, 33);
            this.BTNvolveralmenu.TabIndex = 11;
            this.BTNvolveralmenu.Text = "Volver al menu";
            this.BTNvolveralmenu.UseVisualStyleBackColor = false;
            this.BTNvolveralmenu.Click += new System.EventHandler(this.BTNvolveralmenu_Click);
            // 
            // BTN_ProductoReactivar
            // 
            this.BTN_ProductoReactivar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BTN_ProductoReactivar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ProductoReactivar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_ProductoReactivar.Location = new System.Drawing.Point(773, 388);
            this.BTN_ProductoReactivar.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_ProductoReactivar.Name = "BTN_ProductoReactivar";
            this.BTN_ProductoReactivar.Size = new System.Drawing.Size(145, 33);
            this.BTN_ProductoReactivar.TabIndex = 12;
            this.BTN_ProductoReactivar.Text = "Reactivar";
            this.BTN_ProductoReactivar.UseVisualStyleBackColor = false;
            this.BTN_ProductoReactivar.Click += new System.EventHandler(this.BTN_ProductoReactivar_Click);
            // 
            // CKXmostrarInactivos
            // 
            this.CKXmostrarInactivos.AutoSize = true;
            this.CKXmostrarInactivos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CKXmostrarInactivos.Location = new System.Drawing.Point(316, 357);
            this.CKXmostrarInactivos.Margin = new System.Windows.Forms.Padding(4);
            this.CKXmostrarInactivos.Name = "CKXmostrarInactivos";
            this.CKXmostrarInactivos.Size = new System.Drawing.Size(136, 21);
            this.CKXmostrarInactivos.TabIndex = 13;
            this.CKXmostrarInactivos.Text = "Mostrar Inactivos";
            this.CKXmostrarInactivos.UseVisualStyleBackColor = true;
            this.CKXmostrarInactivos.CheckedChanged += new System.EventHandler(this.CKXmostrarInactivos_CheckedChanged);
            // 
            // FrmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(951, 549);
            this.Controls.Add(this.CKXmostrarInactivos);
            this.Controls.Add(this.BTN_ProductoReactivar);
            this.Controls.Add(this.BTNvolveralmenu);
            this.Controls.Add(this.GB_Producto);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXIdiomas);
            this.Controls.Add(this.BTN_ProductoModificar);
            this.Controls.Add(this.BTN_ProductoBaja);
            this.Controls.Add(this.BTN_ProductoAlta);
            this.Controls.Add(this.GB_Productos);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "FrmProducto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProducto_FormClosing);
            this.Load += new System.EventHandler(this.FrmProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Productos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PrecioProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StockProd)).EndInit();
            this.GB_Producto.ResumeLayout(false);
            this.GB_Producto.PerformLayout();
            this.GB_Productos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Productos;
        private System.Windows.Forms.Button BTN_ProductoAlta;
        private System.Windows.Forms.Button BTN_ProductoBaja;
        private System.Windows.Forms.Button BTN_ProductoModificar;
        private System.Windows.Forms.TextBox TXT_ProductoNombre;
        private System.Windows.Forms.NumericUpDown NUD_PrecioProd;
        private System.Windows.Forms.NumericUpDown NUD_StockProd;
        private System.Windows.Forms.ComboBox CBXIdiomas;
        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.GroupBox GB_Producto;
        private System.Windows.Forms.Label LBLStockProducto;
        private System.Windows.Forms.Label LBLNombreProducto;
        private System.Windows.Forms.Label LBLPrecioProducto;
        private System.Windows.Forms.GroupBox GB_Productos;
        private System.Windows.Forms.Button BTNvolveralmenu;
        private System.Windows.Forms.Button BTN_ProductoReactivar;
        private System.Windows.Forms.CheckBox CKXmostrarInactivos;
    }
}