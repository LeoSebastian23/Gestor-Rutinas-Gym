using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class DiaEntrenamientoService
    {
        private readonly DiaEntrenamientoRepository _repo = new();

        public async Task<List<DiaEntrenamiento>> ObtenerTodosAsync() => await _repo.GetAllAsync();
        public async Task CrearAsync(DiaEntrenamiento dia) => await _repo.AddAsync(dia);
        public async Task ActualizarAsync(DiaEntrenamiento dia) => await _repo.UpdateAsync(dia);
        public async Task EliminarAsync(int id) => await _repo.DeleteAsync(id);
    }
}

