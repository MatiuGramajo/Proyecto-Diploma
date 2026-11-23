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
   
        public void GenerarComprobantePDF(BE.ORDEN_COMPRA orden, BE.PROVEEDOR_INSUMO proveedor = null)
        {
            try
            {
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OrdenesDeCompra");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"OrdenCompra_{orden.Id_OrdenCompra}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    BaseColor azulOscuro = new BaseColor(30, 58, 95);
                    BaseColor grisFondo = new BaseColor(244, 246, 249);
                    BaseColor filaAlterna = new BaseColor(249, 251, 253);
                    BaseColor celesteSuave = new BaseColor(232, 241, 250);
                    BaseColor bordeGris = new BaseColor(210, 216, 224);
                    BaseColor azulEstado = new BaseColor(25, 95, 165);

                    Font fMarca = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.WHITE);
                    Font fSubMarca = FontFactory.GetFont(FontFactory.HELVETICA, 9, new BaseColor(210, 224, 240));
                    Font fDocTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                    Font fDocNum = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.WHITE);
                    Font fSeccion = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, azulOscuro);
                    Font fEtiqueta = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, new BaseColor(80, 88, 98));
                    Font fValor = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                    Font fValorSmall = FontFactory.GetFont(FontFactory.HELVETICA, 9, new BaseColor(60, 68, 78));
                    Font fTablaHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
                    Font fTotalBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, azulOscuro);
                    Font fEstadoBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, azulEstado);
                    Font fPie = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);

                    PdfPTable tablaHeader = new PdfPTable(2);
                    tablaHeader.WidthPercentage = 100;
                    tablaHeader.SetWidths(new float[] { 60f, 40f });

                    PdfPCell celdaIzq = new PdfPCell { BackgroundColor = azulOscuro, Border = Rectangle.NO_BORDER, Padding = 14 };
                    celdaIzq.AddElement(new Paragraph("JMA SOLUTIONS", fMarca));
                    celdaIzq.AddElement(new Paragraph("Gestión Integral de Salón y Eventos — Abastecimiento", fSubMarca));

                    PdfPCell celdaDer = new PdfPCell { BackgroundColor = azulOscuro, Border = Rectangle.NO_BORDER, Padding = 14, HorizontalAlignment = Element.ALIGN_RIGHT };
                    celdaDer.AddElement(new Paragraph("ORDEN DE COMPRA", fDocTitulo) { Alignment = Element.ALIGN_RIGHT });
                    celdaDer.AddElement(new Paragraph($"N°: OC-{orden.Id_OrdenCompra:D6}", fDocNum) { Alignment = Element.ALIGN_RIGHT });
                    celdaDer.AddElement(new Paragraph($"Emisión: {orden.Fecha_Emision:dd/MM/yyyy HH:mm}", fDocNum) { Alignment = Element.ALIGN_RIGHT });

                    tablaHeader.AddCell(celdaIzq);
                    tablaHeader.AddCell(celdaDer);
                    doc.Add(tablaHeader);

                    doc.Add(new Paragraph("\n"));

                    doc.Add(new Paragraph("DATOS DEL PROVEEDOR Y PEDIDO", fSeccion) { SpacingAfter = 6f });

                    PdfPTable tablaInfo = new PdfPTable(2);
                    tablaInfo.WidthPercentage = 100;
                    tablaInfo.SetWidths(new float[] { 58f, 42f });

                    PdfPCell celdaProv = new PdfPCell
                    {
                        BackgroundColor = grisFondo,
                        BorderColor = bordeGris,
                        PaddingTop = 8,
                        PaddingBottom = 8,
                        PaddingLeft = 10,
                        PaddingRight = 10
                    };
                    celdaProv.AddElement(new Paragraph("PROVEEDOR DESTINATARIO", fEtiqueta));

                    if (proveedor != null && !string.IsNullOrWhiteSpace(proveedor.Razon_Social))
                    {
                        celdaProv.AddElement(new Paragraph(proveedor.Razon_Social, fValor));
                        string detalleProv = $"Cód. #{orden.Id_Proveedor}";
                        if (!string.IsNullOrWhiteSpace(proveedor.Cuit)) detalleProv += $"  |  CUIT: {proveedor.Cuit}";
                        if (!string.IsNullOrWhiteSpace(proveedor.Telefono)) detalleProv += $"\nTel: {proveedor.Telefono}";
                        if (!string.IsNullOrWhiteSpace(proveedor.Email)) detalleProv += $"  |  {proveedor.Email}";
                        celdaProv.AddElement(new Paragraph(detalleProv, fValorSmall));
                    }
                    else
                    {
                        celdaProv.AddElement(new Paragraph($"Proveedor N° {orden.Id_Proveedor}", fValor));
                        celdaProv.AddElement(new Paragraph("Solicitud de reposición de insumos para depósito", fValorSmall));
                    }

                    PdfPCell celdaEstado = new PdfPCell
                    {
                        BackgroundColor = grisFondo,
                        BorderColor = bordeGris,
                        PaddingTop = 8,
                        PaddingBottom = 8,
                        PaddingLeft = 10,
                        PaddingRight = 10
                    };
                    celdaEstado.AddElement(new Paragraph("ESTADO DE LA ORDEN", fEtiqueta));
                    celdaEstado.AddElement(new Paragraph((orden.Estado ?? "Emitida").ToUpper(), fEstadoBold));
                    int cantItems = orden.Detalles != null ? orden.Detalles.Count : 0;
                    celdaEstado.AddElement(new Paragraph($"Renglones solicitados: {cantItems}", fValorSmall));

                    tablaInfo.AddCell(celdaProv);
                    tablaInfo.AddCell(celdaEstado);
                    doc.Add(tablaInfo);

                    doc.Add(new Paragraph("\n"));

                    doc.Add(new Paragraph("DETALLE DE INSUMOS SOLICITADOS", fSeccion) { SpacingAfter = 6f });

                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 10f, 18f, 52f, 20f });

                    string[] headers = { "Ítem", "Cód. Insumo", "Descripción del Insumo", "Cant. Solicitada" };
                    int[] alineaciones = { Element.ALIGN_CENTER, Element.ALIGN_CENTER, Element.ALIGN_LEFT, Element.ALIGN_CENTER };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        PdfPCell th = new PdfPCell(new Phrase(headers[i], fTablaHeader))
                        {
                            BackgroundColor = azulOscuro,
                            BorderColor = azulOscuro,
                            HorizontalAlignment = alineaciones[i],
                            Padding = 8
                        };
                        table.AddCell(th);
                    }

                    int nroItem = 1;
                    int totalUnidades = 0;

                    if (orden.Detalles != null)
                    {
                        foreach (var det in orden.Detalles)
                        {
                            BaseColor fondoFila = (nroItem % 2 == 0) ? filaAlterna : BaseColor.WHITE;
                            string codInsumo = det.Id_Insumo > 0 ? $"INS-{det.Id_Insumo:D4}" : "-";

                            table.AddCell(new PdfPCell(new Phrase(nroItem.ToString(), fValor))
                            { BackgroundColor = fondoFila, BorderColor = bordeGris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7 });

                            table.AddCell(new PdfPCell(new Phrase(codInsumo, fValor))
                            { BackgroundColor = fondoFila, BorderColor = bordeGris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7 });

                            table.AddCell(new PdfPCell(new Phrase(det.Nombre_Insumo ?? $"Insumo #{det.Id_Insumo}", fValor))
                            { BackgroundColor = fondoFila, BorderColor = bordeGris, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7 });

                            table.AddCell(new PdfPCell(new Phrase(det.Cantidad_Solicitada.ToString(), fValor))
                            { BackgroundColor = fondoFila, BorderColor = bordeGris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 7 });

                            totalUnidades += det.Cantidad_Solicitada;
                            nroItem++;
                        }
                    }

                    PdfPCell celdaTotalLabel = new PdfPCell(new Phrase("TOTAL DE UNIDADES SOLICITADAS", fTotalBold))
                    {
                        Colspan = 3,
                        BackgroundColor = celesteSuave,
                        BorderColor = bordeGris,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Padding = 8
                    };
                    PdfPCell celdaTotalValor = new PdfPCell(new Phrase(totalUnidades.ToString(), fTotalBold))
                    {
                        BackgroundColor = celesteSuave,
                        BorderColor = bordeGris,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 8
                    };
                    table.AddCell(celdaTotalLabel);
                    table.AddCell(celdaTotalValor);

                    doc.Add(table);
                    doc.Add(new Paragraph("\n\n"));

                    PdfPTable tablaNota = new PdfPTable(1);
                    tablaNota.WidthPercentage = 100;
                    PdfPCell celdaNota = new PdfPCell(new Phrase(
                        $"Instrucciones de entrega: Indicar el número de referencia OC-{orden.Id_OrdenCompra:D6} en el remito físico al momento de entregar la mercadería en el depósito de JMA Solutions.", fPie))
                    {
                        BackgroundColor = grisFondo,
                        BorderColor = bordeGris,
                        Padding = 10
                    };
                    tablaNota.AddCell(celdaNota);
                    doc.Add(tablaNota);

                    doc.Add(new Paragraph("\n\n\n"));

                    PdfPTable tablaFirmas = new PdfPTable(2);
                    tablaFirmas.WidthPercentage = 100;
                    tablaFirmas.SetWidths(new float[] { 50f, 50f });

                    tablaFirmas.AddCell(new PdfPCell(new Phrase("____________________________________\nFirma y Sello — Gerencia de Compras", fPie))
                    { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

                    tablaFirmas.AddCell(new PdfPCell(new Phrase("____________________________________\nControl y Recepción — Depósito", fPie))
                    { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

                    doc.Add(tablaFirmas);
                    doc.Close();
                }

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

        public void GenerarComprobantePDF(BE.RESERVA reserva, string metodoPago = null)
        {
            try
            {
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Comprobantes");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"Comprobante_Liquidacion_{reserva.Id_Reserva}.pdf");

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 36, 36, 36, 36);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Paleta de colores corporativa
                    BaseColor azulOscuro = new BaseColor(30, 58, 95);
                    BaseColor grisFondo = new BaseColor(244, 246, 249);
                    BaseColor celesteSuave = new BaseColor(232, 241, 250);
                    BaseColor bordeGris = new BaseColor(210, 216, 224);
                    BaseColor verdeSaldado = new BaseColor(22, 130, 65);

                    Font fMarca = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.WHITE);
                    Font fSubMarca = FontFactory.GetFont(FontFactory.HELVETICA, 9, new BaseColor(210, 224, 240));
                    Font fDocTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                    Font fDocNum = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.WHITE);
                    Font fSeccion = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, azulOscuro);
                    Font fEtiqueta = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, new BaseColor(80, 88, 98));
                    Font fValor = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                    Font fTablaHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                    Font fTotalBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, azulOscuro);
                    Font fVerdeBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, verdeSaldado);
                    Font fPie = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);

                    PdfPTable tablaHeader = new PdfPTable(2);
                    tablaHeader.WidthPercentage = 100;
                    tablaHeader.SetWidths(new float[] { 60f, 40f });

                    PdfPCell celdaIzq = new PdfPCell { BackgroundColor = azulOscuro, Border = Rectangle.NO_BORDER, Padding = 14 };
                    celdaIzq.AddElement(new Paragraph("JMA SOLUTIONS", fMarca));
                    celdaIzq.AddElement(new Paragraph("Gestión Integral de Salón y Eventos", fSubMarca));

                    PdfPCell celdaDer = new PdfPCell { BackgroundColor = azulOscuro, Border = Rectangle.NO_BORDER, Padding = 14, HorizontalAlignment = Element.ALIGN_RIGHT };
                    Paragraph pTipo = new Paragraph("LIQUIDACIÓN FINAL", fDocTitulo) { Alignment = Element.ALIGN_RIGHT };
                    Paragraph pNro = new Paragraph($"Comprobante N°: LIQ-{reserva.Id_Reserva:D6}", fDocNum) { Alignment = Element.ALIGN_RIGHT };
                    Paragraph pEmision = new Paragraph($"Emisión: {DateTime.Now:dd/MM/yyyy HH:mm}", fDocNum) { Alignment = Element.ALIGN_RIGHT };
                    celdaDer.AddElement(pTipo);
                    celdaDer.AddElement(pNro);
                    celdaDer.AddElement(pEmision);

                    tablaHeader.AddCell(celdaIzq);
                    tablaHeader.AddCell(celdaDer);
                    pdfDoc.Add(tablaHeader);

                    pdfDoc.Add(new Paragraph("\n"));

                    Paragraph lblDatos = new Paragraph("DATOS DEL EVENTO Y CLIENTE", fSeccion) { SpacingAfter = 6f };
                    pdfDoc.Add(lblDatos);

                    string nombreCliente = (reserva.ClienteAsociado != null && !string.IsNullOrWhiteSpace(reserva.ClienteAsociado.Nombre_Completo))
                        ? $"{reserva.ClienteAsociado.Nombre_Completo} (ID: {reserva.Id_Cliente})"
                        : $"Cliente #{reserva.Id_Cliente}";

                    string tipoEvento = (reserva.PresupuestoAsociado != null && !string.IsNullOrWhiteSpace(reserva.PresupuestoAsociado.Tipo_Evento))
                        ? reserva.PresupuestoAsociado.Tipo_Evento
                        : "Evento";

                    PdfPTable tablaInfo = new PdfPTable(2);
                    tablaInfo.WidthPercentage = 100;
                    tablaInfo.SetWidths(new float[] { 50f, 50f });

                    AgregarCeldaFicha(tablaInfo, "CLIENTE", nombreCliente, fEtiqueta, fValor, grisFondo, bordeGris);
                    AgregarCeldaFicha(tablaInfo, "NÚMERO DE RESERVA", $"#{reserva.Id_Reserva}", fEtiqueta, fValor, grisFondo, bordeGris);
                    AgregarCeldaFicha(tablaInfo, "TIPO DE EVENTO", tipoEvento, fEtiqueta, fValor, grisFondo, bordeGris);
                    AgregarCeldaFicha(tablaInfo, "FECHA DEL EVENTO", $"{reserva.Fecha_Evento:dd/MM/yyyy}", fEtiqueta, fValor, grisFondo, bordeGris);

                    string textoPago = !string.IsNullOrWhiteSpace(metodoPago) ? metodoPago : "Abonado en Administración";
                    AgregarCeldaFicha(tablaInfo, "MEDIO DE PAGO", textoPago, fEtiqueta, fValor, grisFondo, bordeGris);
                    AgregarCeldaFicha(tablaInfo, "ESTADO FINANCIERO", "SALDADO", fEtiqueta, fVerdeBold, grisFondo, bordeGris);

                    pdfDoc.Add(tablaInfo);
                    pdfDoc.Add(new Paragraph("\n"));

                    Paragraph lblDetalle = new Paragraph("RESUMEN DE LIQUIDACIÓN", fSeccion) { SpacingAfter = 6f };
                    pdfDoc.Add(lblDetalle);

                    PdfPTable tablaMontos = new PdfPTable(2);
                    tablaMontos.WidthPercentage = 100;
                    tablaMontos.SetWidths(new float[] { 70f, 30f });

                    PdfPCell thConcepto = new PdfPCell(new Phrase("Concepto", fTablaHeader))
                    {
                        BackgroundColor = azulOscuro,
                        BorderColor = azulOscuro,
                        Padding = 9
                    };
                    PdfPCell thImporte = new PdfPCell(new Phrase("Importe", fTablaHeader))
                    {
                        BackgroundColor = azulOscuro,
                        BorderColor = azulOscuro,
                        Padding = 9,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    tablaMontos.AddCell(thConcepto);
                    tablaMontos.AddCell(thImporte);

                    decimal montoLiquidado = reserva.Costo_Total_Real - reserva.Monto_Senia;

                    AgregarFilaMonto(tablaMontos, "Costo Total Real del Evento", $"{reserva.Costo_Total_Real:C}", fValor, fValor, BaseColor.WHITE, bordeGris);
                    AgregarFilaMonto(tablaMontos, "(-) Seña Abonada Previamente", $"- {reserva.Monto_Senia:C}", fValor, fValor, BaseColor.WHITE, bordeGris);
                    AgregarFilaMonto(tablaMontos, "IMPORTE LIQUIDADO EN EL ACTO", $"{montoLiquidado:C}", fTotalBold, fTotalBold, celesteSuave, bordeGris);
                    AgregarFilaMonto(tablaMontos, "Saldo Pendiente", "$ 0,00", fEtiqueta, fVerdeBold, grisFondo, bordeGris);

                    pdfDoc.Add(tablaMontos);
                    pdfDoc.Add(new Paragraph("\n\n"));

                    PdfPTable tablaNota = new PdfPTable(1);
                    tablaNota.WidthPercentage = 100;
                    PdfPCell celdaNota = new PdfPCell(new Phrase(
                        "El presente comprobante deja constancia de la cancelación total del saldo correspondiente al evento detallado. " +
                        "Conserve este documento como respaldo administrativo de su liquidación.", fPie))
                    {
                        BackgroundColor = grisFondo,
                        BorderColor = bordeGris,
                        Padding = 10
                    };
                    tablaNota.AddCell(celdaNota);
                    pdfDoc.Add(tablaNota);

                    pdfDoc.Add(new Paragraph("\n\n\n"));

                    PdfPTable tablaFirmas = new PdfPTable(2);
                    tablaFirmas.WidthPercentage = 100;
                    tablaFirmas.SetWidths(new float[] { 50f, 50f });

                    PdfPCell firma1 = new PdfPCell(new Phrase("____________________________________\nFirma y Aclaración — Administración", fPie))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    PdfPCell firma2 = new PdfPCell(new Phrase("____________________________________\nConformidad del Cliente", fPie))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tablaFirmas.AddCell(firma1);
                    tablaFirmas.AddCell(firma2);
                    pdfDoc.Add(tablaFirmas);

                    pdfDoc.Close();
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el comprobante PDF: " + ex.Message, ex);
            }
        }

        private void AgregarCeldaFicha(PdfPTable tabla, string etiqueta, string valor, Font fEtiqueta, Font fValor, BaseColor fondo, BaseColor borde)
        {
            PdfPCell celda = new PdfPCell
            {
                BackgroundColor = fondo,
                BorderColor = borde,
                PaddingTop = 7,
                PaddingBottom = 7,
                PaddingLeft = 10,
                PaddingRight = 10
            };
            celda.AddElement(new Paragraph(etiqueta, fEtiqueta));
            celda.AddElement(new Paragraph(valor, fValor));
            tabla.AddCell(celda);
        }

        private void AgregarFilaMonto(PdfPTable tabla, string concepto, string importe, Font fConcepto, Font fImporte, BaseColor fondo, BaseColor borde)
        {
            PdfPCell c1 = new PdfPCell(new Phrase(concepto, fConcepto))
            {
                BackgroundColor = fondo,
                BorderColor = borde,
                Padding = 9
            };
            PdfPCell c2 = new PdfPCell(new Phrase(importe, fImporte))
            {
                BackgroundColor = fondo,
                BorderColor = borde,
                Padding = 9,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };
            tabla.AddCell(c1);
            tabla.AddCell(c2);
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
