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
    public class EjercicioRepository
    {
        private readonly GymContext _context = new();

        public async Task<List<Ejercicio>> GetAllAsync()
        {
            return await _context.Ejercicios
                .Include(e => e.EjercicioBase)
                .ToListAsync();
        }

        public async Task AddAsync(Ejercicio ejercicio)
        {
            await _context.Ejercicios.AddAsync(ejercicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ejercicio ejercicio)
        {
            _context.Ejercicios.Update(ejercicio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio != null)
            {
                _context.Ejercicios.Remove(ejercicio);
                await _context.SaveChangesAsync();
            }
        }
    }
}

