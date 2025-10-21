using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Models
{
    public class Ejercicio
    {
        public int IdEjercicio { get; set; }

        // FK a EjercicioBase
        public int IdEjercicioBase { get; set; }
        public EjercicioBase EjercicioBase { get; set; } = null!;


        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public decimal Descanso { get; set; }
        public string Notas { get; set; } = string.Empty;

        // Relación opcional 1:1
        public DetalleAvanzado? DetalleAvanzado { get; set; }

        // --- Constructores ---
        public Ejercicio() { }

        public Ejercicio(int idEjercicioBase, int series, int repeticiones, decimal descanso, string notas = "")
        {
            IdEjercicioBase = idEjercicioBase;
            Series = series;
            Repeticiones = repeticiones;
            Descanso = descanso;
            Notas = notas;
        }
    }
}
