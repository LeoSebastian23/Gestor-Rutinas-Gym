using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class EjercicioBaseService
    {
        private readonly EjercicioBaseRepository _repository = new();

        public async Task<List<EjercicioBase>> ObtenerTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<EjercicioBase?> ObtenerPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CrearAsync(EjercicioBase ejercicio)
        {
            await _repository.AddAsync(ejercicio);
        }

        public async Task ActualizarAsync(EjercicioBase ejercicio)
        {
            await _repository.UpdateAsync(ejercicio);
        }

        public async Task EliminarAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

