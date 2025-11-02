using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class RutinaService
    {
        private readonly RutinaRepository _repo = new();

        public async Task<List<Rutina>> ObtenerTodasAsync()
        {
            return await _repo.GetAllAsync();
        }
        public async Task<Rutina?> ObtenerPorIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task CrearAsync(Rutina rutina) => await _repo.AddAsync(rutina);
        public async Task ActualizarAsync(Rutina rutina) => await _repo.UpdateAsync(rutina);
        public async Task EliminarAsync(int id) => await _repo.DeleteAsync(id);
    }
}

