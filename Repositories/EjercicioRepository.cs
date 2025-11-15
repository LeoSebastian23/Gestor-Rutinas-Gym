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

        public List<Ejercicio> GetAll()
        {
            return _context.Ejercicios
                .Include(e => e.EjercicioBase)
                .ToList();
        }

        public void Add(Ejercicio ejercicio)
        {
            _context.Ejercicios.Add(ejercicio);
            _context.SaveChanges();
        }

        public void Update(Ejercicio ejercicio)
        {
            _context.Ejercicios.Update(ejercicio);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ejercicio = _context.Ejercicios.Find(id);
            if (ejercicio != null)
            {
                _context.Ejercicios.Remove(ejercicio);
                _context.SaveChanges();
            }
        }
    }
}


