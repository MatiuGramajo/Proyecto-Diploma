using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Servicios
{
    public class GESTOR_PDF
    {

        public void GenerarComprobantePDF(BE.RESERVA reserva)
        {
            try
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Comprobantes");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"Comprobante_Liquidacion_{reserva.Id_Reserva}.pdf");

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Encabezado
                    Paragraph titulo = new Paragraph("COMPROBANTE DE LIQUIDACIÓN FINAL", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(titulo);
                    pdfDoc.Add(new Paragraph("\n----------------------------------------------------------------------------------------------------------------------------------\n\n"));

                    // Detalles del Comprobante
                    pdfDoc.Add(new Paragraph($"Número de Reserva: {reserva.Id_Reserva}"));
                    pdfDoc.Add(new Paragraph($"Fecha del Evento: {reserva.Fecha_Evento:dd/MM/yyyy}"));
                    pdfDoc.Add(new Paragraph($"Cliente ID: {reserva.Id_Cliente}"));
                    pdfDoc.Add(new Paragraph($"Costo Total del Evento: {reserva.Costo_Total_Real:C}"));
                    pdfDoc.Add(new Paragraph($"Seña Abonada Previamente: {reserva.Monto_Senia:C}"));
                    pdfDoc.Add(new Paragraph($"Monto Liquidado: {(reserva.Costo_Total_Real - reserva.Monto_Senia):C}"));
                    pdfDoc.Add(new Paragraph($"Saldo Pendiente: $ 0,00"));
                    pdfDoc.Add(new Paragraph($"Estado del Evento: SALDADO"));
                    pdfDoc.Add(new Paragraph($"Fecha de Emisión: {DateTime.Now:dd/MM/yyyy HH:mm}"));

                    pdfDoc.Close();
                }

                // Abre automáticamente el PDF generado
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // Relanzamos la excepción para que la capture el try/catch de la GUI (FrmLiquidacionFinal.cs)
                throw new Exception("Error al generar el comprobante PDF: " + ex.Message, ex);
            }
        }
    }
}
