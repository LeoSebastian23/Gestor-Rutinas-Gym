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

        public RutinaController() { }

        public void CrearRutina(string nombre, int duracion, string descripcion)
        {
            _rutinaActual = new Rutina(nombre, duracion, descripcion);
        }

        public void GuardarRutina()
        {
            if (_rutinaActual == null)
                throw new InvalidOperationException("No existe una rutina creada.");

            _rutinaService.Crear(_rutinaActual);
        }

        public List<Rutina> ObtenerTodas() => _rutinaService.ObtenerTodas();

        public Rutina ObtenerRutinaActual() => _rutinaActual;

        public Rutina ObtenerPorId(int idRutina)
        {
            if (idRutina <= 0)
                throw new ArgumentException("ID inválido.", nameof(idRutina));

            return _rutinaService.ObtenerPorId(idRutina)
                ?? throw new Exception($"No se encontró la rutina con ID {idRutina}.");
        }

        public void ActualizarRutina(Rutina rutina)
        {
            if (rutina == null)
                throw new ArgumentNullException(nameof(rutina));

            _rutinaService.Actualizar(rutina);
        }

        public void EliminarRutina(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            _rutinaService.Eliminar(id);
        }

        public void AgregarDia(string diaSemana, string grupoMuscular)
        {
            _rutinaActual.Dias.Add(new DiaEntrenamiento(diaSemana, grupoMuscular));
        }

        public void EliminarDia(DiaEntrenamiento dia)
        {
            if (dia == null)
                throw new ArgumentNullException(nameof(dia));

            _rutinaActual.Dias.Remove(dia);
        }

        public void AgregarEjercicio(
            DiaEntrenamiento dia,
            EjercicioBase baseEjercicio,
            int series,
            int reps,
            decimal descanso,
            string notas)
        {
            if (dia == null)
                throw new ArgumentNullException(nameof(dia));

            dia.Ejercicios.Add(new Ejercicio(baseEjercicio, series, reps, descanso, notas));
        }

        public void EliminarEjercicio(DiaEntrenamiento dia, Ejercicio ejercicio)
        {
            if (dia == null)
                throw new ArgumentNullException(nameof(dia));
            if (ejercicio == null)
                throw new ArgumentNullException(nameof(ejercicio));

            dia.Ejercicios.Remove(ejercicio);
        }

        public List<EjercicioBase> ObtenerEjerciciosBase()
            => _ejercicioBaseService.ObtenerTodos();
    }
}
