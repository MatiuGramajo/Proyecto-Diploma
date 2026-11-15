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
    public partial class FrmCalendario : Form, BE.IObserver
    {
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();
        private BLL.IDIOMA GestorIdioma = new BLL.IDIOMA();
        public FrmCalendario()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fechaSolicitada = monthCalendar1.SelectionStart.Date;

                if(fechaSolicitada< DateTime.Now.Date)
                {
                    MessageBox.Show("Por favor, seleccione una fecha futura para la reserva.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                bool estaDisponible = gestorReserva.ConsultarDisponibilidad(fechaSolicitada);
                if (!estaDisponible)
                {
                    List<DateTime> alternativas = gestorReserva.ConsultarFechasCercanas(fechaSolicitada);
                    ResaltarFecha(fechaSolicitada, false);
                    CargarFechas(alternativas);
                    BtnIniciarPresupuesto.Enabled = false;
                    MessageBox.Show("La fecha solicitada se encuentra ocupada. Hemos cargado fechas alternativas en la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ResaltarFecha(fechaSolicitada, true);
                    HabilitarBotonPresupuesto();
                    listBox1.DataSource = null;
                    MessageBox.Show("¡La fecha está libre! Ya puede iniciar el presupuesto.", "Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la consulta: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);   }


        }

        private void ResaltarFecha(DateTime fechaSolicitada, bool libre)
        {
            try
            {
                List<DateTime> fechasOcupadas = gestorReserva.ListarFechasOcupadas();
                ResaltarEnNegrita(fechasOcupadas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error visual al resaltar el calendario: " + ex.Message, "Error Menor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void CargarFechas(List<DateTime> fechasAlternativas)
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DataSource = fechasAlternativas;
                listBox1.FormatString = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de alternativas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HabilitarBotonPresupuesto()
        {
            BtnIniciarPresupuesto.Enabled = true;
        }

        private void BtnIniciarPresupuesto_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaValidada = monthCalendar1.SelectionStart.Date;
                FrmPresupuesto frmpresupuesto = new FrmPresupuesto(fechaValidada);
                frmpresupuesto.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo iniciar el presupuesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void FrmCalendario_Load(object sender, EventArgs e)
        {
            InicializarIdioma();
            try
            {
                List<DateTime> fechasOcupadas = gestorReserva.ListarFechasOcupadas();
                ResaltarEnNegrita(fechasOcupadas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las fechas ocupadas: " + ex.Message);
            }

        }

        private void ResaltarEnNegrita(List<DateTime> fechasOcupadas)
        {
            monthCalendar1.RemoveAllBoldedDates();
            foreach(DateTime fecha in fechasOcupadas)
            {
                monthCalendar1.AddBoldedDate(fecha);
            }
            monthCalendar1.UpdateBoldedDates();
        }

        private void btnVolverAlMenuPrincipal_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea volver al menu principal?", "Atención",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }
        private void InicializarIdioma()
        {
            Servicios.IDIOMAS.GetInstancia().Suscribir(this);

            CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
            CBXidiomas.DataSource = GestorIdioma.Listar();
            CBXidiomas.DisplayMember = "Nombre";
            CBXidiomas.ValueMember = "Id";
            CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
            CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;

            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            var traducciones = Servicios.IDIOMAS.GetInstancia().Traducciones;
            TraducirControles(this.Controls, traducciones);

            if (traducciones.TryGetValue($"{this.Name}_Titulo", out string textoTitulo))
                this.Text = textoTitulo;

            if (CBXidiomas.Items.Count > 0)
            {
                CBXidiomas.SelectedIndexChanged -= CBXidiomas_SelectedIndexChanged;
                CBXidiomas.SelectedValue = Servicios.IDIOMAS.GetInstancia().IdIdiomaActual;
                CBXidiomas.SelectedIndexChanged += CBXidiomas_SelectedIndexChanged;
            }
        }

        private void TraducirControles(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            foreach (Control control in controles)
            {
                string clave = $"{this.Name}_{control.Name}";
                if (traducciones.TryGetValue(clave, out string textoTraducido))
                    control.Text = textoTraducido;

                if (control.HasChildren)
                    TraducirControles(control.Controls, traducciones);
            }
        }

        private void CBXidiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBXidiomas.SelectedValue != null && int.TryParse(CBXidiomas.SelectedValue.ToString(), out int idIdioma))
                {
                    var traducciones = GestorIdioma.ObtenerTraducciones(idIdioma);
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
                MessageBox.Show("Error al cambiar el idioma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCalendario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Servicios.IDIOMAS.GetInstancia().Desuscribir(this);
        }
    }
}
