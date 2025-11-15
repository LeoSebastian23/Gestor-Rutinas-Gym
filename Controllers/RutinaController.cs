using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Services;
using System;
using System.Collections.Generic;

namespace Gestor_de_Rutinas___GYM.Controllers
{
    public class RutinaController
    {
        private readonly RutinaService _rutinaService = new();
        private readonly DiaEntrenamientoService _diaService = new();
        private readonly EjercicioService _ejercicioService = new();
        private readonly EjercicioBaseService _ejercicioBaseService = new();

        private Rutina _rutinaActual = new();

        // --- CRUD Rutina ---
        public void CrearRutina(string nombre, int duracion, string descripcion)
        {
            _rutinaActual = new Rutina(nombre, duracion, descripcion);
        }

        public void GuardarRutina()
        {
            if (_rutinaActual == null)
                throw new InvalidOperationException("No hay rutina creada para guardar.");

            _rutinaService.Crear(_rutinaActual);
        }

        public List<Rutina> ObtenerTodas() => _rutinaService.ObtenerTodas();

        public Rutina ObtenerRutinaActual() => _rutinaActual;

        public void ActualizarRutina(Rutina rutina)
        {
            if (rutina == null)
                throw new ArgumentNullException(nameof(rutina));

            _rutinaService.Actualizar(rutina);
        }

        public void EliminarRutina(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido para eliminar rutina.");

            _rutinaService.Eliminar(id);
        }

        // --- Días ---
        public void AgregarDia(string diaSemana, string grupoMuscular)
        {
            var dia = new DiaEntrenamiento(diaSemana, grupoMuscular);
            _rutinaActual.Dias.Add(dia);
        }

        // Método para eliminar un día de entrenamiento
        public void EliminarDia(DiaEntrenamiento dia)
        {
            if (dia == null)
                throw new ArgumentNullException(nameof(dia));

            _rutinaActual.Dias.Remove(dia);
        }

        // --- Ejercicios ---
        public void AgregarEjercicio(DiaEntrenamiento dia, EjercicioBase baseEjercicio, int series, int reps, decimal descanso, string notas)
        {
            if (dia == null)
                throw new ArgumentNullException(nameof(dia));

            var ejercicio = new Ejercicio(baseEjercicio, series, reps, descanso, notas);
            dia.Ejercicios.Add(ejercicio);
        }

        // Método para eliminar un ejercicio específico
        public void EliminarEjercicio(DiaEntrenamiento dia, Ejercicio ejercicio)
        {
            if (dia == null)
                throw new ArgumentNullException(nameof(dia));
            if (ejercicio == null)
                throw new ArgumentNullException(nameof(ejercicio));

            dia.Ejercicios.Remove(ejercicio);
        }

        // --- Ejercicio Base ---
        public List<EjercicioBase> ObtenerEjerciciosBase() => _ejercicioBaseService.ObtenerTodos();
    }
}


