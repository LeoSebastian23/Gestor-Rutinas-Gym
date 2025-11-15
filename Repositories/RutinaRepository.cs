using Gestor_de_Rutinas___GYM.Data;
using Gestor_de_Rutinas___GYM.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Rutinas___GYM.Repositories
{
    public class RutinaRepository
    {
        private readonly GymContext _context = new();

        public List<Rutina> GetAll()
        {
            return _context.Rutinas
                .Include(r => r.Dias)
                    .ThenInclude(d => d.Ejercicios)
                        .ThenInclude(e => e.EjercicioBase)
                .ToList();
        }

        public Rutina? GetById(int id)
        {
            return _context.Rutinas
                .Include(r => r.Dias)
                    .ThenInclude(d => d.Ejercicios)
                        .ThenInclude(e => e.EjercicioBase)
                .FirstOrDefault(r => r.IdRutina == id);
        }

        public void Add(Rutina rutina)
        {
            foreach (var dia in rutina.Dias)
            {
                foreach (var ejercicio in dia.Ejercicios)
                {
                    if (ejercicio.EjercicioBase != null)
                        _context.Attach(ejercicio.EjercicioBase);
                }
            }

            _context.Rutinas.Add(rutina);
            _context.SaveChanges();
        }

        public void Update(Rutina rutina)
        {
            _context.Rutinas.Update(rutina);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rutina = _context.Rutinas.Find(id);
            if (rutina != null)
            {
                _context.Rutinas.Remove(rutina);
                _context.SaveChanges();
            }
        }
    }
}


