using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Objetivo { get; set; } = string.Empty;

        // Relación: un cliente tiene muchas rutinas
        public List<Rutina> Rutinas { get; set; } = new();

        // --- Constructores ---
        public Cliente() { }

        public Cliente(string nombre, string apellido, DateTime fechaNacimiento, string objetivo)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Objetivo = objetivo;
        }
    }
}