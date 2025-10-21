using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Models
{
    public class EjercicioBase
    {
        public int IdEjercicioBase { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // --- Constructores ---
        public EjercicioBase() { }

        public EjercicioBase(string nombre, string grupoMuscular, string descripcion)
        {
            Nombre = nombre;
            GrupoMuscular = grupoMuscular;
            Descripcion = descripcion;
        }
    }
}
