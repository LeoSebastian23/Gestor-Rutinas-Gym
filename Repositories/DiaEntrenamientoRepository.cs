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

        public List<DiaEntrenamiento> GetAll()
        {
            return _context.DiasEntrenamiento
                .Include(d => d.Ejercicios)
                    .ThenInclude(e => e.EjercicioBase)
                .ToList();
        }

        public void Add(DiaEntrenamiento dia)
        {
            _context.DiasEntrenamiento.Add(dia);
            _context.SaveChanges();
        }

        public void Update(DiaEntrenamiento dia)
        {
            _context.DiasEntrenamiento.Update(dia);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dia = _context.DiasEntrenamiento.Find(id);
            if (dia != null)
            {
                _context.DiasEntrenamiento.Remove(dia);
                _context.SaveChanges();
            }
        }
    }
}


