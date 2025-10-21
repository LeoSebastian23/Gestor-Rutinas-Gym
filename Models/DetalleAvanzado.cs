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
        public int IdEjercicio { get; set; }
        public double PorcentajeRM { get; set; }
        public double RM { get; set; }
        public string Objetivo { get; set; } = string.Empty;

        public Ejercicio Ejercicio { get; set; } = null!;

        public DetalleAvanzado() { }

        public DetalleAvanzado(double porcentajeRM, double pesoUtilizado, string objetivo)
        {
            PorcentajeRM = porcentajeRM;
            RM = RM;
            Objetivo = objetivo;
        }
        public double CalcularPeso() => RM * (PorcentajeRM / 100);
    }
}
