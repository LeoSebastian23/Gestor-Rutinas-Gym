using Gestor_de_Rutinas___GYM.Data;
using Gestor_de_Rutinas___GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Rutinas___GYM.Repositories
{
    public class ClienteRepository
    {
        private readonly GymContext _context = new();

        public List<Cliente> GetAll()
        {
            return _context.Clientes
                .Include(c => c.Rutinas)
                .ToList();
        }

        public Cliente? GetById(int id)
        {
            return _context.Clientes
                .Include(c => c.Rutinas)
                .FirstOrDefault(c => c.IdCliente == id);
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}

