using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class EjercicioService
    {
        private readonly EjercicioRepository _repo = new();

        public async Task<List<Ejercicio>> ObtenerTodosAsync() => await _repo.GetAllAsync();
        public async Task CrearAsync(Ejercicio ejercicio) => await _repo.AddAsync(ejercicio);
        public async Task ActualizarAsync(Ejercicio ejercicio) => await _repo.UpdateAsync(ejercicio);
        public async Task EliminarAsync(int id) => await _repo.DeleteAsync(id);
    }
}

