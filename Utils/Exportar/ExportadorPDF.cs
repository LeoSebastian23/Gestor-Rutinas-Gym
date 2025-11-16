using Gestor_de_Rutinas___GYM.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;
// Alias opcionales si los necesitás en otros lados
using ITextFont = iTextSharp.text.Font;
using PdfRectangle = iTextSharp.text.Rectangle;

namespace Gestor_de_Rutinas___GYM.Utils.Exportar
{
    public class ExportadorPDF : IExportadorRutina
    {
        public void Exportar(Cliente cliente, Rutina rutina, string rutaDestino)
        {
            // Paleta de la app
            var teal = new BaseColor(0x0f, 0x92, 0x8c); // #0f928c
            var tealClaro = new BaseColor(0x00, 0xc9, 0xd2); // #00c9d2 (por si lo querés usar)
            var acentoLima = new BaseColor(0xbe, 0xee, 0x3b); // #beee3b
            var grisTexto = new BaseColor(0x48, 0x48, 0x48); // #484848
            var grisFondoSuave = new BaseColor(0xf5, 0xf5, 0xf5);

            var doc = new Document(PageSize.A4, 40, 40, 40, 40);
            var writer = PdfWriter.GetInstance(doc, new FileStream(rutaDestino, FileMode.Create));
            doc.Open();

            // Fuentes
            var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, BaseColor.BLACK);
            var subTituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, grisTexto);
            var labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, grisTexto);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, grisTexto);
            var headerTablaFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            var footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, grisTexto);

            // =========================
            // HEADER PRINCIPAL
            // =========================
            var titulo = new Paragraph("PLAN DE ENTRENAMIENTO", tituloFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10f
            };
            doc.Add(titulo);

            // Línea fina bajo el título
            var linea = new Paragraph(new Chunk(new LineSeparator(0.5f, 80f, teal, Element.ALIGN_CENTER, -2)));
            doc.Add(linea);
            doc.Add(new Paragraph(" ", normalFont)); // pequeño espacio

            // =========================
            // BLOQUE DATOS DEL CLIENTE
            // =========================
            var infoTable = new PdfPTable(3)
            {
                WidthPercentage = 100
            };
            infoTable.SetWidths(new float[] { 40f, 20f, 40f });

            string nombreCliente = cliente == null
                ? "Rutina general"
                : $"{cliente.Nombre} {cliente.Apellido}";

            string edadTexto = cliente == null
                ? "-"
                : CalcularEdad(cliente.FechaNacimiento).ToString();

            string fechaTexto = DateTime.Today.ToString("dd/MM/yyyy");

            void AddInfoCell(string label, string value)
            {
                var p = new Paragraph();
                p.Add(new Chunk(label + " ", labelFont));
                p.Add(new Chunk(value, normalFont));

                var cell = new PdfPCell(p)
                {
                    Border = PdfRectangle.NO_BORDER,
                    BackgroundColor = grisFondoSuave,
                    Padding = 6f
                };
                infoTable.AddCell(cell);
            }

            AddInfoCell("Rutina de:", nombreCliente);
            AddInfoCell("Edad:", edadTexto);
            AddInfoCell("Fecha:", fechaTexto);

            doc.Add(infoTable);
            doc.Add(new Paragraph(" ", normalFont)); // espacio extra

            // =========================
            // DATOS GENERALES DE RUTINA
            // =========================
            var datosRutina = new Paragraph
            {
                SpacingAfter = 10f
            };
            datosRutina.Add(new Chunk("Nombre de rutina: ", labelFont));
            datosRutina.Add(new Chunk(rutina.Nombre + "\n", normalFont));
            datosRutina.Add(new Chunk("Duración: ", labelFont));
            datosRutina.Add(new Chunk($"{rutina.DuracionSemana} semanas\n", normalFont));

            if (!string.IsNullOrWhiteSpace(rutina.Descripcion))
            {
                datosRutina.Add(new Chunk("Descripción: ", labelFont));
                datosRutina.Add(new Chunk(rutina.Descripcion, normalFont));
            }

            doc.Add(datosRutina);

            // =========================
            // DÍAS Y TABLAS DE EJERCICIOS
            // =========================
            int indiceDia = 1;
            foreach (var dia in rutina.Dias)
            {
                // Barra fina de color (estilo C)
                var barraTabla = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };

                var tituloDia = $"DÍA {indiceDia} — {dia.DiaSemana}  |  {dia.GrupoMuscular}";
                var cellDia = new PdfPCell(new Phrase(tituloDia, subTituloFont))
                {
                    BackgroundColor = teal,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingTop = 4f,
                    PaddingBottom = 4f,
                    Border = PdfRectangle.NO_BORDER
                };

                // Texto en blanco dentro de la barra
                cellDia.Phrase.Font.Color = BaseColor.WHITE;

                barraTabla.AddCell(cellDia);
                barraTabla.SpacingBefore = 12f;
                barraTabla.SpacingAfter = 4f;

                doc.Add(barraTabla);

                // Tabla de ejercicios
                var tabla = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };
                tabla.SetWidths(new float[] { 50f, 10f, 25f, 20f });

                PdfPCell HeaderCell(string txt)
                {
                    return new PdfPCell(new Phrase(txt, headerTablaFont))
                    {
                        BackgroundColor = BaseColor.DARK_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5f
                    };
                }

                tabla.AddCell(HeaderCell("EJERCICIO"));
                tabla.AddCell(HeaderCell("SERIES"));
                tabla.AddCell(HeaderCell("REPETICIONES"));
                tabla.AddCell(HeaderCell("DESCANSO (min)"));

                bool alterna = false;
                foreach (var ej in dia.Ejercicios)
                {
                    BaseColor bg = alterna ? grisFondoSuave : BaseColor.WHITE;
                    alterna = !alterna;

                    tabla.AddCell(CeldaDato(ej.EjercicioBase?.Nombre ?? "-", normalFont, bg));
                    tabla.AddCell(CeldaDato(ej.Series.ToString(), normalFont, bg, Element.ALIGN_CENTER));
                    tabla.AddCell(CeldaDato(ej.Repeticiones.ToString(), normalFont, bg, Element.ALIGN_CENTER));

                    // Mostramos minutos en vez de "segundos"
                    tabla.AddCell(CeldaDato($"{ej.Descanso} min", normalFont, bg, Element.ALIGN_CENTER));
                }

                doc.Add(tabla);
                indiceDia++;
            }

            // =========================
            // FOOTER (simple, centrado)
            // =========================
            var cb = writer.DirectContent;
            var footerText = new Phrase(
                $"Gestor de Rutinas - GYM  •  {DateTime.Now.Year}",
                footerFont
            );

            ColumnText.ShowTextAligned(
                cb,
                Element.ALIGN_CENTER,
                footerText,
                doc.PageSize.Width / 2,
                doc.BottomMargin / 2,
                0
            );

            doc.Close();
        }

        private static PdfPCell CeldaDato(
            string texto,
            ITextFont font,
            BaseColor bg,
            int align = Element.ALIGN_LEFT)
        {
            return new PdfPCell(new Phrase(texto, font))
            {
                BackgroundColor = bg,
                HorizontalAlignment = align,
                Padding = 4f
            };
        }

        private static int CalcularEdad(DateTime fecha)
        {
            int edad = DateTime.Today.Year - fecha.Year;
            if (fecha > DateTime.Today.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
