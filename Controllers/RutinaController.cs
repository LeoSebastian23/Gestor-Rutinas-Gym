using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Controllers
{
    public class RutinaController
    {
        private readonly RutinaService _rutinaService = new();
        private readonly DiaEntrenamientoService _diaService = new();
        private readonly EjercicioService _ejercicioService = new();
        private readonly EjercicioBaseService _ejercicioBaseService = new();

        private Rutina _rutinaActual = new();


        public void CrearRutina(string nombre, int duracion, string descripcion)
        {
            _rutinaActual = new Rutina(nombre, duracion, descripcion);
        }

        public void AgregarDia(string diaSemana, string grupoMuscular)
        {
            var dia = new DiaEntrenamiento(diaSemana, grupoMuscular);
            _rutinaActual.Dias.Add(dia);
        }

        public void AgregarEjercicio(DiaEntrenamiento dia, EjercicioBase baseEjercicio, int series, int reps, decimal descanso, string notas)
        {
            var ejercicio = new Ejercicio(baseEjercicio, series, reps, descanso, notas);
            dia.Ejercicios.Add(ejercicio);
        }

        public async Task GuardarRutinaAsync()
        {
            await _rutinaService.CrearAsync(_rutinaActual);
        }
        public async Task<List<Rutina>> ObtenerTodasAsync()
        {
            return await _rutinaService.ObtenerTodasAsync();
        }
        public Rutina ObtenerRutinaActual() => _rutinaActual;

        public async Task<List<EjercicioBase>> ObtenerEjerciciosBaseAsync()
        {
            return await _ejercicioBaseService.ObtenerTodosAsync();
        }

    }
}

