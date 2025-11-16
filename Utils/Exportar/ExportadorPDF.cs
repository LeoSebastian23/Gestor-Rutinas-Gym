using Gestor_de_Rutinas___GYM.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Gestor_de_Rutinas___GYM.Utils.Exportar
{
    public class ExportadorPDF : IExportadorRutina
    {
        public void Exportar(Cliente cliente, Rutina rutina, string rutaDestino)
        {
            Document pdf = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(pdf, new FileStream(rutaDestino, FileMode.Create));

            pdf.Open();

            // =============================
            // ENCABEZADO
            // =============================

            string tituloCliente = cliente == null
                ? "Rutina General"
                : $"Rutina de {cliente.Nombre} {cliente.Apellido}";

            var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
            var subFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            pdf.Add(new Paragraph(tituloCliente, tituloFont));
            pdf.Add(new Paragraph("\n"));

            // =============================
            // DATOS DE RUTINA
            // =============================
            pdf.Add(new Paragraph($"Rutina: {rutina.Nombre}", subFont));
            pdf.Add(new Paragraph($"Duración: {rutina.DuracionSemana} semanas", normalFont));
            pdf.Add(new Paragraph($"Descripción: {rutina.Descripcion}\n\n", normalFont));

            // =============================
            // DÍAS Y EJERCICIOS
            // =============================
            foreach (var dia in rutina.Dias)
            {
                pdf.Add(new Paragraph(
                    $"Día: {dia.DiaSemana} - {dia.GrupoMuscular}",
                    subFont));

                PdfPTable tabla = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };

                tabla.AddCell("Ejercicio");
                tabla.AddCell("Series");
                tabla.AddCell("Reps");
                tabla.AddCell("Descanso");

                foreach (var ej in dia.Ejercicios)
                {
                    tabla.AddCell(ej.EjercicioBase.Nombre);
                    tabla.AddCell(ej.Series.ToString());
                    tabla.AddCell(ej.Repeticiones.ToString());
                    tabla.AddCell($"{ej.Descanso} seg");
                }

                pdf.Add(tabla);
                pdf.Add(new Paragraph("\n"));
            }

            pdf.Close();
        }
    }
}
