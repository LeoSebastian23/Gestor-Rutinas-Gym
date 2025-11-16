using ClosedXML.Excel;
using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Utils.Exportar
{
    public class ExportadorExcel : IExportadorRutina
    {
        public void Exportar(Cliente cliente, Rutina rutina, string rutaDestino)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Rutina");

            int f = 1;

            ws.Cell(f++, 1).Value = $"Rutina de {cliente.Nombre} {cliente.Apellido}";

            f++;

            ws.Cell(f++, 1).Value = $"Nombre Rutina: {rutina.Nombre}";
            ws.Cell(f++, 1).Value = $"Duración: {rutina.DuracionSemana}";
            ws.Cell(f++, 1).Value = $"Descripción: {rutina.Descripcion}";
            f++;

            foreach (var dia in rutina.Dias)
            {
                ws.Cell(f++, 1).Value = $"Día: {dia.DiaSemana} - {dia.GrupoMuscular}";
                ws.Cell(f, 1).Value = "Ejercicio";
                ws.Cell(f, 2).Value = "Series";
                ws.Cell(f, 3).Value = "Repeticiones";
                ws.Cell(f, 4).Value = "Descanso";
                f++;

                foreach (var ej in dia.Ejercicios)
                {
                    ws.Cell(f, 1).Value = ej.EjercicioBase.Nombre;
                    ws.Cell(f, 2).Value = ej.Series;
                    ws.Cell(f, 3).Value = ej.Repeticiones;
                    ws.Cell(f, 4).Value = ej.Descanso;
                    f++;
                }
                f++;
            }

            wb.SaveAs(rutaDestino);
        }
    }
}


