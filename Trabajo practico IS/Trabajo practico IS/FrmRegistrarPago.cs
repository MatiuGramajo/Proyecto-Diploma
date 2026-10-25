using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    public partial class FrmRegistrarPago : Form, BE.IObserver

    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BLL.PRESUPUESTO gestorPresupuesto = new BLL.PRESUPUESTO();

        private BE.PRESUPUESTO presupuestoSeleccionado;
        public FrmRegistrarPago()
        {
            InitializeComponent();
            ConfigurarFormularioBase();
            DGVPresupuestosPendientes.Visible = true;

            CargarPresupuestosPendientes();
        }
        public FrmRegistrarPago(BE.PRESUPUESTO presupuestoRecienCreado)
        {
            InitializeComponent();
            ConfigurarFormularioBase();
            this.presupuestoSeleccionado = presupuestoRecienCreado;
            DGVPresupuestosPendientes.Visible = false;
            LlenarCamposLectura();
        }

        private void LlenarCamposLectura()
        {
            if(presupuestoSeleccionado!=null)
            {
                TXTcliente.Text = "Cliente ID: " + presupuestoSeleccionado.Id_Cliente.ToString();
                TXTtipoevento.Text = presupuestoSeleccionado.Tipo_Evento + " (" + presupuestoSeleccionado.Cantidad_Invitados_Estimada + " inv.)";
                TXTtotal.Text = "$ " + presupuestoSeleccionado.Subtotal.ToString("0.00");
            }
        }

        private void CargarPresupuestosPendientes()
        {
            try
            {
                DGVPresupuestosPendientes.DataSource = null;
                DGVPresupuestosPendientes.DataSource = gestorPresupuesto.ObtenerPresupuestosPendientes();
                if(DGVPresupuestosPendientes.Columns.Count >0)
                {
                    DGVPresupuestosPendientes.Columns["Id_Presupuesto"].HeaderText = "Nro.";
                    DGVPresupuestosPendientes.Columns["Id_Presupuesto"].Width = 50;

                    DGVPresupuestosPendientes.Columns["Tipo_Evento"].HeaderText = "Evento";
                    DGVPresupuestosPendientes.Columns["Cantidad_Invitados_Estimada"].HeaderText = "Invitados";
                    DGVPresupuestosPendientes.Columns["Subtotal"].HeaderText = "Total Cotizado ($)";

                    DGVPresupuestosPendientes.Columns["Id_Cliente"].Visible = false;
                    DGVPresupuestosPendientes.Columns["Id_Usuario"].Visible = false;
                    DGVPresupuestosPendientes.Columns["Estado"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de cobros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarFormularioBase()
        {
            CBXmetodopago.Items.Add("Efectivo");
            CBXmetodopago.Items.Add("Transferencia Bancaria");
            CBXmetodopago.Items.Add("Tarjeta de Crédito");
        }

        private void FrmRegistrarPago_Load(object sender, EventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);
            ActualizarIdioma();
        }

        private void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);
            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo)) this.Text = textoTitulo;
            if (CBXIdiomas.Items.Count > 0)
            {
                CBXIdiomas.SelectedIndexChanged -= CBXIdiomas_SelectedIndexChanged;
                CBXIdiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXIdiomas.SelectedIndexChanged += CBXIdiomas_SelectedIndexChanged;
            }
        }
        private void CBXIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (CBXIdiomas.SelectedValue != null && int.TryParse(CBXIdiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();
                    var traducciones = gestorIdioma.ObtenerTraducciones(idIdioma);
                    Servicios.IDIOMAS.GetInstancia().CambiarIdioma(idIdioma, traducciones);
                    if (Servicios.SESION.GetInstancia().usuactual != null)
                    {
                        BLL.USUARIO gestorUsu = new BLL.USUARIO();
                        gestorUsu.ActualizarIdiomaUsuario(Servicios.SESION.GetInstancia().usuactual, idIdioma);
                        Servicios.SESION.GetInstancia().usuactual.IdIdioma = idIdioma;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido)) control.Text = textoTraducido;
                if (control.HasChildren) TraducirControles(control.Controls, traducciones);
            }
        }

        private void DGVPresupuestosPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                this.presupuestoSeleccionado = (BE.PRESUPUESTO)DGVPresupuestosPendientes.Rows[e.RowIndex].DataBoundItem;
                LlenarCamposLectura();
            }
        }

        private void BTNconfirmarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if(presupuestoSeleccionado==null)
                {
                    MessageBox.Show("Debe seleccionar un presupuesto pendiente de la grilla para continuar con el pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if(CBXmetodopago.SelectedIndex==-1 || string.IsNullOrWhiteSpace(TXTmonto.Text))
                {
                    MessageBox.Show("Faltan campos por completar para continuar con el pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(!decimal.TryParse(TXTmonto.Text, out decimal montoAbonado) || montoAbonado<=0)
                {
                    MessageBox.Show("Ingrese un monto de seña válido.", "Validación Numérica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BE.RESERVA nuevaReserva = new BE.RESERVA();
                nuevaReserva.Id_Cliente = presupuestoSeleccionado.Id_Cliente;
                nuevaReserva.Id_Presupuesto = presupuestoSeleccionado.Id_Presupuesto;
                nuevaReserva.Id_Usuario = 1;
                nuevaReserva.Fecha_Evento = presupuestoSeleccionado.Fecha_Evento;
                nuevaReserva.Monto_Senia = montoAbonado;
                gestorReserva.RegistrarReserva(nuevaReserva, presupuestoSeleccionado);
                MessageBox.Show("Pago registrado con éxito y Fecha Reservada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el pago: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRegistrarPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }

        void IObserver.ActualizarIdioma()
        {
            ActualizarIdioma();
        }
    }
}
