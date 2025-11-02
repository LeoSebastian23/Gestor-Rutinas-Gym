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

        public decimal Peso { get; set; } 

        public decimal Altura { get; set; }
        public string Objetivo { get; set; } = string.Empty;
        

        public List<Rutina> Rutinas { get; set; } = new();

        // --- Constructores ---
        public Cliente() { }

        public Cliente(string nombre, string apellido, DateTime fechaNacimiento, decimal peso, decimal altura, string objetivo)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Objetivo = objetivo;
            Peso = peso;
            Altura = altura;
        }
    }
}