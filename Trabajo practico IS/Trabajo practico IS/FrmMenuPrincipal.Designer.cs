namespace Trabajo_practico_IS
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AdministracionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeIdiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.restauracionDeBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionCatalogoDeInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionRecetarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarFaltantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichaTecnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionFinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionProveedoresDeInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarOrdenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularReasignarOrdenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarRecepcionDeMercaderiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarPersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarPersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrarRatiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEvaluacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriaYReportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metricasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LBLbienvenida = new System.Windows.Forms.Label();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidioma = new System.Windows.Forms.Label();
            this.BtnFrmCalendario = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegistrarOrdenCompra = new System.Windows.Forms.Button();
            this.btnCalibrarRatios = new System.Windows.Forms.Button();
            this.btnLiquidacionFinal = new System.Windows.Forms.Button();
            this.registrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnCerrarSesion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrarSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCerrarSesion.Location = new System.Drawing.Point(647, 382);
            this.BtnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(145, 33);
            this.BtnCerrarSesion.TabIndex = 0;
            this.BtnCerrarSesion.Text = "Cerrar Sesion";
            this.BtnCerrarSesion.UseVisualStyleBackColor = false;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdministracionMenuItem,
            this.stockToolStripMenuItem,
            this.eventosToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.personalToolStripMenuItem,
            this.auditoriaYReportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(858, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AdministracionMenuItem
            // 
            this.AdministracionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlDeUsuariosToolStripMenuItem,
            this.controlDePermisosToolStripMenuItem,
            this.controlDeIdiomasToolStripMenuItem,
            this.toolStripMenuItem2,
            this.restauracionDeBaseToolStripMenuItem,
            this.historialDeCambiosToolStripMenuItem});
            this.AdministracionMenuItem.Name = "AdministracionMenuItem";
            this.AdministracionMenuItem.Size = new System.Drawing.Size(128, 24);
            this.AdministracionMenuItem.Text = "Administración";
            // 
            // controlDeUsuariosToolStripMenuItem
            // 
            this.controlDeUsuariosToolStripMenuItem.Name = "controlDeUsuariosToolStripMenuItem";
            this.controlDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(258, 24);
            this.controlDeUsuariosToolStripMenuItem.Tag = "ABM_USUARIO";
            this.controlDeUsuariosToolStripMenuItem.Text = "Control de usuarios";
            this.controlDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.controlDeUsuariosToolStripMenuItem_Click);
            // 
            // controlDePermisosToolStripMenuItem
            // 
            this.controlDePermisosToolStripMenuItem.Name = "controlDePermisosToolStripMenuItem";
            this.controlDePermisosToolStripMenuItem.Size = new System.Drawing.Size(258, 24);
            this.controlDePermisosToolStripMenuItem.Tag = "ABM_PERMISOS";
            this.controlDePermisosToolStripMenuItem.Text = "Control de permisos";
            this.controlDePermisosToolStripMenuItem.Click += new System.EventHandler(this.controlDePermisosToolStripMenuItem_Click);
            // 
            // controlDeIdiomasToolStripMenuItem
            // 
            this.controlDeIdiomasToolStripMenuItem.Name = "controlDeIdiomasToolStripMenuItem";
            this.controlDeIdiomasToolStripMenuItem.Size = new System.Drawing.Size(258, 24);
            this.controlDeIdiomasToolStripMenuItem.Tag = "ABM_IDIOMAS";
            this.controlDeIdiomasToolStripMenuItem.Text = "Control de idiomas";
            this.controlDeIdiomasToolStripMenuItem.Click += new System.EventHandler(this.controlDeIdiomasToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(258, 24);
            this.toolStripMenuItem2.Text = "------------------------------------";
            // 
            // restauracionDeBaseToolStripMenuItem
            // 
            this.restauracionDeBaseToolStripMenuItem.Name = "restauracionDeBaseToolStripMenuItem";
            this.restauracionDeBaseToolStripMenuItem.Size = new System.Drawing.Size(258, 24);
            this.restauracionDeBaseToolStripMenuItem.Tag = "RESTAURACION_BASE";
            this.restauracionDeBaseToolStripMenuItem.Text = "Control de restauracion";
            this.restauracionDeBaseToolStripMenuItem.Click += new System.EventHandler(this.restauracionDeBaseToolStripMenuItem_Click);
            // 
            // historialDeCambiosToolStripMenuItem
            // 
            this.historialDeCambiosToolStripMenuItem.Name = "historialDeCambiosToolStripMenuItem";
            this.historialDeCambiosToolStripMenuItem.Size = new System.Drawing.Size(258, 24);
            this.historialDeCambiosToolStripMenuItem.Tag = "HISTORIAL_CAMBIOS";
            this.historialDeCambiosToolStripMenuItem.Text = "Historial de cambios";
            this.historialDeCambiosToolStripMenuItem.Click += new System.EventHandler(this.historialDeCambiosToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionCatalogoDeInsumosToolStripMenuItem,
            this.gestionRecetarioToolStripMenuItem,
            this.consultarFaltantesToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.stockToolStripMenuItem.Text = "Stock";
            // 
            // gestionCatalogoDeInsumosToolStripMenuItem
            // 
            this.gestionCatalogoDeInsumosToolStripMenuItem.Name = "gestionCatalogoDeInsumosToolStripMenuItem";
            this.gestionCatalogoDeInsumosToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.gestionCatalogoDeInsumosToolStripMenuItem.Tag = "ABM_INSUMOS";
            this.gestionCatalogoDeInsumosToolStripMenuItem.Text = "Gestion Catalogo de Insumos";
            this.gestionCatalogoDeInsumosToolStripMenuItem.Click += new System.EventHandler(this.gestionCatalogoDeInsumosToolStripMenuItem_Click);
            // 
            // gestionRecetarioToolStripMenuItem
            // 
            this.gestionRecetarioToolStripMenuItem.Name = "gestionRecetarioToolStripMenuItem";
            this.gestionRecetarioToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.gestionRecetarioToolStripMenuItem.Tag = "GESTION_RECETARIO";
            this.gestionRecetarioToolStripMenuItem.Text = "Gestion Recetario";
            this.gestionRecetarioToolStripMenuItem.Click += new System.EventHandler(this.gestionRecetarioToolStripMenuItem_Click);
            // 
            // consultarFaltantesToolStripMenuItem
            // 
            this.consultarFaltantesToolStripMenuItem.Name = "consultarFaltantesToolStripMenuItem";
            this.consultarFaltantesToolStripMenuItem.Size = new System.Drawing.Size(294, 24);
            this.consultarFaltantesToolStripMenuItem.Tag = "CONSULTAR_STOCK";
            this.consultarFaltantesToolStripMenuItem.Text = "Consultar Faltantes";
            this.consultarFaltantesToolStripMenuItem.Click += new System.EventHandler(this.consultarFaltantesToolStripMenuItem_Click);
            // 
            // eventosToolStripMenuItem
            // 
            this.eventosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarioToolStripMenuItem,
            this.registrarPagoToolStripMenuItem,
            this.fichaTecnicaToolStripMenuItem,
            this.liquidacionFinalToolStripMenuItem,
            this.registrarClienteToolStripMenuItem});
            this.eventosToolStripMenuItem.Name = "eventosToolStripMenuItem";
            this.eventosToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.eventosToolStripMenuItem.Text = "Eventos";
            // 
            // calendarioToolStripMenuItem
            // 
            this.calendarioToolStripMenuItem.Name = "calendarioToolStripMenuItem";
            this.calendarioToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.calendarioToolStripMenuItem.Tag = "GESTION_CALENDARIO";
            this.calendarioToolStripMenuItem.Text = "Calendario";
            this.calendarioToolStripMenuItem.Click += new System.EventHandler(this.calendarioToolStripMenuItem_Click);
            // 
            // registrarPagoToolStripMenuItem
            // 
            this.registrarPagoToolStripMenuItem.Name = "registrarPagoToolStripMenuItem";
            this.registrarPagoToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.registrarPagoToolStripMenuItem.Tag = "GESTION_PAGO";
            this.registrarPagoToolStripMenuItem.Text = "Registrar Pago";
            this.registrarPagoToolStripMenuItem.Click += new System.EventHandler(this.registrarPagoToolStripMenuItem_Click);
            // 
            // fichaTecnicaToolStripMenuItem
            // 
            this.fichaTecnicaToolStripMenuItem.Name = "fichaTecnicaToolStripMenuItem";
            this.fichaTecnicaToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.fichaTecnicaToolStripMenuItem.Tag = "GESTION_FICHA_TECNICA";
            this.fichaTecnicaToolStripMenuItem.Text = "Ficha Tecnica";
            this.fichaTecnicaToolStripMenuItem.Click += new System.EventHandler(this.fichaTecnicaToolStripMenuItem_Click_1);
            // 
            // liquidacionFinalToolStripMenuItem
            // 
            this.liquidacionFinalToolStripMenuItem.Name = "liquidacionFinalToolStripMenuItem";
            this.liquidacionFinalToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.liquidacionFinalToolStripMenuItem.Tag = "GESTION_LIQUIDACION_FINAL";
            this.liquidacionFinalToolStripMenuItem.Text = "Liquidacion Final";
            this.liquidacionFinalToolStripMenuItem.Click += new System.EventHandler(this.liquidacionFinalToolStripMenuItem_Click_1);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionProveedoresDeInsumosToolStripMenuItem,
            this.registrarOrdenDeCompraToolStripMenuItem,
            this.anularReasignarOrdenDeCompraToolStripMenuItem,
            this.registrarRecepcionDeMercaderiaToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // gestionProveedoresDeInsumosToolStripMenuItem
            // 
            this.gestionProveedoresDeInsumosToolStripMenuItem.Name = "gestionProveedoresDeInsumosToolStripMenuItem";
            this.gestionProveedoresDeInsumosToolStripMenuItem.Size = new System.Drawing.Size(343, 24);
            this.gestionProveedoresDeInsumosToolStripMenuItem.Tag = "ABM_PROVEEDOR_INSUMO";
            this.gestionProveedoresDeInsumosToolStripMenuItem.Text = "Gestion Proveedores de Insumos";
            this.gestionProveedoresDeInsumosToolStripMenuItem.Click += new System.EventHandler(this.gestionProveedoresDeInsumosToolStripMenuItem_Click_1);
            // 
            // registrarOrdenDeCompraToolStripMenuItem
            // 
            this.registrarOrdenDeCompraToolStripMenuItem.Name = "registrarOrdenDeCompraToolStripMenuItem";
            this.registrarOrdenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(343, 24);
            this.registrarOrdenDeCompraToolStripMenuItem.Tag = "GESTION_ORDEN_COMPRA";
            this.registrarOrdenDeCompraToolStripMenuItem.Text = "Registrar Orden de Compra";
            this.registrarOrdenDeCompraToolStripMenuItem.Click += new System.EventHandler(this.registrarOrdenDeCompraToolStripMenuItem_Click_1);
            // 
            // anularReasignarOrdenDeCompraToolStripMenuItem
            // 
            this.anularReasignarOrdenDeCompraToolStripMenuItem.Name = "anularReasignarOrdenDeCompraToolStripMenuItem";
            this.anularReasignarOrdenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(343, 24);
            this.anularReasignarOrdenDeCompraToolStripMenuItem.Tag = "GESTION_ANULAR_REASIGNAR_ORDEN_COMPRA";
            this.anularReasignarOrdenDeCompraToolStripMenuItem.Text = "Anular/Reasignar Orden de Compra";
            this.anularReasignarOrdenDeCompraToolStripMenuItem.Click += new System.EventHandler(this.anularReasignarOrdenDeCompraToolStripMenuItem_Click_1);
            // 
            // registrarRecepcionDeMercaderiaToolStripMenuItem
            // 
            this.registrarRecepcionDeMercaderiaToolStripMenuItem.Name = "registrarRecepcionDeMercaderiaToolStripMenuItem";
            this.registrarRecepcionDeMercaderiaToolStripMenuItem.Size = new System.Drawing.Size(343, 24);
            this.registrarRecepcionDeMercaderiaToolStripMenuItem.Tag = "GESTION_RECEPCIONAR_STOCK";
            this.registrarRecepcionDeMercaderiaToolStripMenuItem.Text = "Registrar Recepcion de Mercaderia";
            this.registrarRecepcionDeMercaderiaToolStripMenuItem.Click += new System.EventHandler(this.registrarRecepcionDeMercaderiaToolStripMenuItem_Click_1);
            // 
            // personalToolStripMenuItem
            // 
            this.personalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarPersonalToolStripMenuItem,
            this.asignarPersonalToolStripMenuItem,
            this.calibrarRatiosToolStripMenuItem,
            this.registrarEvaluacionToolStripMenuItem});
            this.personalToolStripMenuItem.Name = "personalToolStripMenuItem";
            this.personalToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.personalToolStripMenuItem.Text = "Personal";
            // 
            // gestionarPersonalToolStripMenuItem
            // 
            this.gestionarPersonalToolStripMenuItem.Name = "gestionarPersonalToolStripMenuItem";
            this.gestionarPersonalToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.gestionarPersonalToolStripMenuItem.Tag = "ABM_PERSONAL";
            this.gestionarPersonalToolStripMenuItem.Text = "Gestionar Personal";
            this.gestionarPersonalToolStripMenuItem.Click += new System.EventHandler(this.gestionarPersonalToolStripMenuItem_Click_1);
            // 
            // asignarPersonalToolStripMenuItem
            // 
            this.asignarPersonalToolStripMenuItem.Name = "asignarPersonalToolStripMenuItem";
            this.asignarPersonalToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.asignarPersonalToolStripMenuItem.Tag = "GESTION_PERSONAL";
            this.asignarPersonalToolStripMenuItem.Text = "Asignar Personal";
            this.asignarPersonalToolStripMenuItem.Click += new System.EventHandler(this.asignarPersonalToolStripMenuItem_Click_1);
            // 
            // calibrarRatiosToolStripMenuItem
            // 
            this.calibrarRatiosToolStripMenuItem.Name = "calibrarRatiosToolStripMenuItem";
            this.calibrarRatiosToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.calibrarRatiosToolStripMenuItem.Tag = "GESTION_RATIOS";
            this.calibrarRatiosToolStripMenuItem.Text = "Calibrar Ratios";
            this.calibrarRatiosToolStripMenuItem.Click += new System.EventHandler(this.calibrarRatiosToolStripMenuItem_Click_1);
            // 
            // registrarEvaluacionToolStripMenuItem
            // 
            this.registrarEvaluacionToolStripMenuItem.Name = "registrarEvaluacionToolStripMenuItem";
            this.registrarEvaluacionToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.registrarEvaluacionToolStripMenuItem.Tag = "GESTION_EVALUACION";
            this.registrarEvaluacionToolStripMenuItem.Text = "Registrar Evaluacion";
            this.registrarEvaluacionToolStripMenuItem.Click += new System.EventHandler(this.registrarEvaluacionToolStripMenuItem_Click_1);
            // 
            // auditoriaYReportesToolStripMenuItem
            // 
            this.auditoriaYReportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BitacoraToolStripMenuItem,
            this.metricasToolStripMenuItem});
            this.auditoriaYReportesToolStripMenuItem.Name = "auditoriaYReportesToolStripMenuItem";
            this.auditoriaYReportesToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.auditoriaYReportesToolStripMenuItem.Text = "Auditoria y Reportes";
            // 
            // BitacoraToolStripMenuItem
            // 
            this.BitacoraToolStripMenuItem.Name = "BitacoraToolStripMenuItem";
            this.BitacoraToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.BitacoraToolStripMenuItem.Tag = "BITACORA";
            this.BitacoraToolStripMenuItem.Text = "Bitacora";
            this.BitacoraToolStripMenuItem.Click += new System.EventHandler(this.BitacoraToolStripMenuItem_Click_1);
            // 
            // metricasToolStripMenuItem
            // 
            this.metricasToolStripMenuItem.Name = "metricasToolStripMenuItem";
            this.metricasToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.metricasToolStripMenuItem.Tag = "VER_DASHBOARD";
            this.metricasToolStripMenuItem.Text = "Metricas";
            this.metricasToolStripMenuItem.Click += new System.EventHandler(this.metricasToolStripMenuItem_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LBLbienvenida
            // 
            this.LBLbienvenida.AutoSize = true;
            this.LBLbienvenida.Font = new System.Drawing.Font("Century Gothic", 30F);
            this.LBLbienvenida.Location = new System.Drawing.Point(14, 40);
            this.LBLbienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLbienvenida.Name = "LBLbienvenida";
            this.LBLbienvenida.Size = new System.Drawing.Size(239, 49);
            this.LBLbienvenida.TabIndex = 9;
            this.LBLbienvenida.Text = "Bienvenido";
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(607, 64);
            this.CBXidiomas.Margin = new System.Windows.Forms.Padding(4);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(140, 25);
            this.CBXidiomas.TabIndex = 10;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidioma
            // 
            this.LBLidioma.AutoSize = true;
            this.LBLidioma.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLidioma.Location = new System.Drawing.Point(603, 44);
            this.LBLidioma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLidioma.Name = "LBLidioma";
            this.LBLidioma.Size = new System.Drawing.Size(59, 17);
            this.LBLidioma.TabIndex = 11;
            this.LBLidioma.Text = "Idiomas";
            // 
            // BtnFrmCalendario
            // 
            this.BtnFrmCalendario.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnFrmCalendario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFrmCalendario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnFrmCalendario.Location = new System.Drawing.Point(7, 21);
            this.BtnFrmCalendario.Margin = new System.Windows.Forms.Padding(4);
            this.BtnFrmCalendario.Name = "BtnFrmCalendario";
            this.BtnFrmCalendario.Size = new System.Drawing.Size(146, 58);
            this.BtnFrmCalendario.TabIndex = 12;
            this.BtnFrmCalendario.Text = "Calendario";
            this.BtnFrmCalendario.UseVisualStyleBackColor = false;
            this.BtnFrmCalendario.Click += new System.EventHandler(this.BtnFrmCalendario_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 137);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 35F);
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1083, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sistema de Gestion Integral - Salon de Eventos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegistrarOrdenCompra);
            this.groupBox1.Controls.Add(this.btnCalibrarRatios);
            this.groupBox1.Controls.Add(this.btnLiquidacionFinal);
            this.groupBox1.Controls.Add(this.BtnFrmCalendario);
            this.groupBox1.Location = new System.Drawing.Point(9, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "ADMIN";
            this.groupBox1.Text = "Acceso Rapido";
            // 
            // btnRegistrarOrdenCompra
            // 
            this.btnRegistrarOrdenCompra.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRegistrarOrdenCompra.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarOrdenCompra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarOrdenCompra.Location = new System.Drawing.Point(550, 21);
            this.btnRegistrarOrdenCompra.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarOrdenCompra.Name = "btnRegistrarOrdenCompra";
            this.btnRegistrarOrdenCompra.Size = new System.Drawing.Size(146, 58);
            this.btnRegistrarOrdenCompra.TabIndex = 15;
            this.btnRegistrarOrdenCompra.Text = "Registrar Orden de Compra";
            this.btnRegistrarOrdenCompra.UseVisualStyleBackColor = false;
            this.btnRegistrarOrdenCompra.Click += new System.EventHandler(this.btnRegistrarOrdenCompra_Click);
            // 
            // btnCalibrarRatios
            // 
            this.btnCalibrarRatios.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCalibrarRatios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrarRatios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCalibrarRatios.Location = new System.Drawing.Point(371, 21);
            this.btnCalibrarRatios.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalibrarRatios.Name = "btnCalibrarRatios";
            this.btnCalibrarRatios.Size = new System.Drawing.Size(146, 58);
            this.btnCalibrarRatios.TabIndex = 14;
            this.btnCalibrarRatios.Text = "Calibrar Ratios";
            this.btnCalibrarRatios.UseVisualStyleBackColor = false;
            this.btnCalibrarRatios.Click += new System.EventHandler(this.btnCalibrarRatios_Click);
            // 
            // btnLiquidacionFinal
            // 
            this.btnLiquidacionFinal.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLiquidacionFinal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiquidacionFinal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLiquidacionFinal.Location = new System.Drawing.Point(184, 21);
            this.btnLiquidacionFinal.Margin = new System.Windows.Forms.Padding(4);
            this.btnLiquidacionFinal.Name = "btnLiquidacionFinal";
            this.btnLiquidacionFinal.Size = new System.Drawing.Size(146, 58);
            this.btnLiquidacionFinal.TabIndex = 13;
            this.btnLiquidacionFinal.Text = "Liquidacion Final";
            this.btnLiquidacionFinal.UseVisualStyleBackColor = false;
            this.btnLiquidacionFinal.Click += new System.EventHandler(this.btnLiquidacionFinal_Click);
            // 
            // registrarClienteToolStripMenuItem
            // 
            this.registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            this.registrarClienteToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.registrarClienteToolStripMenuItem.Tag = "ABM_CLIENTE";
            this.registrarClienteToolStripMenuItem.Text = "Registrar Cliente";
            this.registrarClienteToolStripMenuItem.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(858, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBLidioma);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.LBLbienvenida);
            this.Controls.Add(this.BtnCerrarSesion);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bibliotech";
            this.Activated += new System.EventHandler(this.FrmMenuPrincipal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AdministracionMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label LBLbienvenida;
        private System.Windows.Forms.ToolStripMenuItem controlDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDePermisosToolStripMenuItem;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidioma;
        private System.Windows.Forms.ToolStripMenuItem controlDeIdiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restauracionDeBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeCambiosToolStripMenuItem;
        private System.Windows.Forms.Button BtnFrmCalendario;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionCatalogoDeInsumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionRecetarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarFaltantesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem eventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditoriaYReportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichaTecnicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidacionFinalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionProveedoresDeInsumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarOrdenDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularReasignarOrdenDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarRecepcionDeMercaderiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarPersonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarPersonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrarRatiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarEvaluacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metricasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btnRegistrarOrdenCompra;
        private System.Windows.Forms.Button btnCalibrarRatios;
        private System.Windows.Forms.Button btnLiquidacionFinal;
        private System.Windows.Forms.ToolStripMenuItem registrarClienteToolStripMenuItem;
    }
}

