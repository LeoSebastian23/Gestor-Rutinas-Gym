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
    public class EjercicioBaseRepository
    {
        private readonly GymContext _context;

        public EjercicioBaseRepository()
        {
            _context = new GymContext();
        }

        public async Task<List<EjercicioBase>> GetAllAsync()
        {
            return await _context.EjerciciosBase.ToListAsync();
        }

        public async Task<EjercicioBase?> GetByIdAsync(int id)
        {
            return await _context.EjerciciosBase.FindAsync(id);
        }

        public async Task AddAsync(EjercicioBase ejercicio)
        {
            await _context.EjerciciosBase.AddAsync(ejercicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EjercicioBase ejercicio)
        {
            _context.EjerciciosBase.Update(ejercicio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ejercicio = await _context.EjerciciosBase.FindAsync(id);
            if (ejercicio != null)
            {
                _context.EjerciciosBase.Remove(ejercicio);
                await _context.SaveChangesAsync();
            }
        }
    }
}

