using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Models
{
    public class DetalleAvanzado
    {
        public int IdDetalle { get; set; }

        // FK al ejercicio al que pertenece
        public int EjercicioId { get; set; }

        // Datos específicos de detalle avanzado
        public double PorcentajeRM { get; set; }
        public double RM { get; set; }
        public string Objetivo { get; set; } = string.Empty;
        public string? Nota { get; set; }

        // Constructor vacío (necesario para EF Core)
        public DetalleAvanzado() { }

        // Constructor para crear nuevos detalles manualmente
        public DetalleAvanzado(double porcentajeRM, double rm, string objetivo, string? nota = null)
        {
            PorcentajeRM = porcentajeRM;
            RM = rm;
            Objetivo = objetivo;
            Nota = nota;
        }

        // Método de utilidad: calcula peso según %RM
        public double CalcularPeso() => RM * (PorcentajeRM / 100);
    }
}
