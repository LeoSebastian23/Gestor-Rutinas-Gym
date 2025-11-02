using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Data;
using Gestor_de_Rutinas___GYM.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Rutinas___GYM.Repositories
{
    public class DiaEntrenamientoRepository
    {
        private readonly GymContext _context = new();

        public async Task<List<DiaEntrenamiento>> GetAllAsync()
        {
            return await _context.DiasEntrenamiento
                .Include(d => d.Ejercicios)
                    .ThenInclude(e => e.EjercicioBase)
                .ToListAsync();
        }

        public async Task AddAsync(DiaEntrenamiento dia)
        {
            await _context.DiasEntrenamiento.AddAsync(dia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DiaEntrenamiento dia)
        {
            _context.DiasEntrenamiento.Update(dia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dia = await _context.DiasEntrenamiento.FindAsync(id);
            if (dia != null)
            {
                _context.DiasEntrenamiento.Remove(dia);
                await _context.SaveChangesAsync();
            }
        }
    }
}

