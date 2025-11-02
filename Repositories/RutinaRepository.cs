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
    public class RutinaRepository
    {
        private readonly GymContext _context = new();

        public async Task<List<Rutina>> GetAllAsync()
        {
            return await _context.Rutinas
                .Include(r => r.Dias)
                .ThenInclude(d => d.Ejercicios)
                .ToListAsync();
        }

        public async Task<Rutina?> GetByIdAsync(int id)
        {
            return await _context.Rutinas
                .Include(r => r.Dias)
                    .ThenInclude(d => d.Ejercicios)
                        .ThenInclude(e => e.EjercicioBase)
                .FirstOrDefaultAsync(r => r.IdRutina == id);
        }

        public async Task AddAsync(Rutina rutina)
        {
            // Recorremos todos los días y ejercicios
            foreach (var dia in rutina.Dias)
            {
                foreach (var ejercicio in dia.Ejercicios)
                {
                    // Si el ejercicio base existe (no es nuevo), solo lo adjuntamos al contexto
                    if (ejercicio.EjercicioBase != null)
                    {
                        _context.Attach(ejercicio.EjercicioBase);
                    }
                }
            }

            // Ahora EF solo insertará lo nuevo (Rutina, Día, Ejercicio)
            await _context.Rutinas.AddAsync(rutina);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rutina rutina)
        {
            _context.Rutinas.Update(rutina);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina != null)
            {
                _context.Rutinas.Remove(rutina);
                await _context.SaveChangesAsync();
            }
        }
    }
}

