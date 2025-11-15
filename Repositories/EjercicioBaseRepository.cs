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
        private readonly GymContext _context = new();

        public List<EjercicioBase> GetAll()
        {
            return _context.EjerciciosBase.ToList();
        }

        public EjercicioBase? GetById(int id)
        {
            return _context.EjerciciosBase.Find(id);
        }

        public void Add(EjercicioBase ejercicio)
        {
            _context.EjerciciosBase.Add(ejercicio);
            _context.SaveChanges();
        }

        public void Update(EjercicioBase ejercicio)
        {
            _context.EjerciciosBase.Update(ejercicio);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ejercicio = _context.EjerciciosBase.Find(id);
            if (ejercicio != null)
            {
                _context.EjerciciosBase.Remove(ejercicio);
                _context.SaveChanges();
            }
        }
    }
}


