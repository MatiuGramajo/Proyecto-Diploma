using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void GenerarComprobantePDF(BE.ORDEN_COMPRA orden)
        {
            try
            {
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OrdenesDeCompra");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, $"OrdenCompra_{orden.Id_OrdenCompra}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                doc.Open();

                Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
                Font subTituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.DARK_GRAY);
                Font textoFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                Font textoBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);

                doc.Add(new Paragraph("ORDEN DE COMPRA", tituloFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"N°: OC-{orden.Id_OrdenCompra:D6}", subTituloFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Fecha de Emisión: {orden.Fecha_Emision:dd/MM/yyyy HH:mm}", textoFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Estado: {orden.Estado}", textoFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Chunk("\n"));

                doc.Add(new Paragraph($"Código Proveedor: {orden.Id_Proveedor}", textoFont));
                doc.Add(new Chunk("\n"));

                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 20f, 60f, 20f });

                PdfPCell cell1 = new PdfPCell(new Phrase("Cód. Insumo", textoBold)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY };
                PdfPCell cell2 = new PdfPCell(new Phrase("Insumo", textoBold)) { HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = BaseColor.LIGHT_GRAY };
                PdfPCell cell3 = new PdfPCell(new Phrase("Cant. Solicitada", textoBold)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.LIGHT_GRAY };

                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cell3);

                foreach (var det in orden.Detalles)
                {
                    table.AddCell(new PdfPCell(new Phrase(det.Id_Insumo.ToString(), textoFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(det.Nombre_Insumo ?? "Insumo " + det.Id_Insumo, textoFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(det.Cantidad_Solicitada.ToString(), textoFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                }

                doc.Add(table);
                doc.Close();

                try
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                catch { }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el comprobante PDF: " + ex.Message);
            }
        }

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

                    Paragraph titulo = new Paragraph("COMPROBANTE DE LIQUIDACIÓN FINAL", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(titulo);
                    pdfDoc.Add(new Paragraph("\n----------------------------------------------------------------------------------------------------------------------------------\n\n"));

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

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el comprobante PDF: " + ex.Message, ex);
            }
        }
        public void GenerarReporteDashboardGrafico(string area, string metrica, DateTime desde, DateTime hasta, byte[] imagenGrafico)
        {
            try
            {
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReportesDashboard");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string nombreLimpio = string.Join("_", metrica.Split(Path.GetInvalidFileNameChars()));
                string filePath = Path.Combine(folderPath, $"Dashboard_{nombreLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    AgregarEncabezadoDashboard(doc, area, metrica, desde, hasta);

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagenGrafico);
                    img.ScaleToFit(540f, 360f);
                    img.Alignment = Element.ALIGN_CENTER;
                    doc.Add(img);

                    doc.Close();
                }

                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el PDF del dashboard: " + ex.Message, ex);
            }
        }

        public void GenerarReporteDashboardTabla(string area, string metrica, DateTime desde, DateTime hasta, List<string> encabezados, List<List<string>> filas)
        {
            try
            {
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReportesDashboard");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string nombreLimpio = string.Join("_", metrica.Split(Path.GetInvalidFileNameChars()));
                string filePath = Path.Combine(folderPath, $"Dashboard_{nombreLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    AgregarEncabezadoDashboard(doc, area, metrica, desde, hasta);

                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
                    Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

                    PdfPTable table = new PdfPTable(encabezados.Count)
                    {
                        WidthPercentage = 100
                    };

                    foreach (string tituloCol in encabezados)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(tituloCol, headerFont))
                        {
                            BackgroundColor = new BaseColor(52, 73, 94),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 6
                        };
                        table.AddCell(cell);
                    }

                    foreach (var fila in filas)
                    {
                        foreach (string valor in fila)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(valor ?? "", cellFont))
                            {
                                HorizontalAlignment = valor != null && valor.StartsWith("$") ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT,
                                Padding = 5
                            };
                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }

                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el PDF de la tabla del dashboard: " + ex.Message, ex);
            }
        }

        private void AgregarEncabezadoDashboard(Document doc, string area, string metrica, DateTime desde, DateTime hasta)
        {
            Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            Font subTituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY);
            Font infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);

            doc.Add(new Paragraph("REPORTE DE INDICADORES DE GESTIÓN", tituloFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph($"{area.ToUpper()} - {metrica}", subTituloFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Chunk("\n"));

            doc.Add(new Paragraph($"Período analizado: {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}", infoFont));
            doc.Add(new Paragraph($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm}", infoFont));
            doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------"));
            doc.Add(new Chunk("\n"));
        }
    }
}
