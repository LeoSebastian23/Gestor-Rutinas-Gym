using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Models
{
    public class DiaEntrenamiento
    {
        public int IdDia { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;

        // Relación: un día tiene varios ejercicios
        public List<Ejercicio> Ejercicios { get; set; } = new();

        // --- Constructores ---
        public DiaEntrenamiento() { }

        public DiaEntrenamiento(string diaSemana, string grupoMuscular)
        {
            DiaSemana = diaSemana;
            GrupoMuscular = grupoMuscular;
        }
    }
}
