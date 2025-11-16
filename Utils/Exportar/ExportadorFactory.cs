using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Utils.Exportar
{
    public static class ExportadorFactory
    {
        public static IExportadorRutina Crear(string tipo)
        {
            return tipo switch
            {
                "PDF" => new ExportadorPDF(),
                "EXCEL" => new ExportadorExcel(),
                _ => throw new NotImplementedException($"El exportador '{tipo}' no está implementado.")
            };
        }
    }
}

