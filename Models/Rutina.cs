using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Models
{
    public class Rutina
    {
        public int IdRutina { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int DuracionSemana { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public List<DiaEntrenamiento> Dias { get; set; } = new();

        // --- Constructores ---
        public Rutina() { }

        public Rutina(string nombre, int duracionSemana, string descripcion)
        {
            Nombre = nombre;
            DuracionSemana = duracionSemana;
            Descripcion = descripcion;
        }
    }
}
