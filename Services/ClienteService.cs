using Gestor_de_Rutinas___GYM.Data;
using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository = new();
        private readonly RutinaRepository _rutinaRepo;

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CrearAsync(Cliente cliente)
        {
            await _repository.AddAsync(cliente);
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            await _repository.UpdateAsync(cliente);
        }

        public async Task EliminarAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<Rutina>> ObtenerRutinasDeClienteAsync(int idCliente)
        {
            var cliente = await _repository.GetByIdAsync(idCliente);
            if (cliente == null) throw new Exception("Cliente no encontrado.");
            return cliente.Rutinas;
        }

        public async Task AsignarRutinaAsync(int idCliente, int idRutina)
        {
            using var context = new GymContext();

            //  Cargamos el cliente con sus rutinas actuales
            var cliente = await context.Clientes
                .Include(c => c.Rutinas)
                .FirstOrDefaultAsync(c => c.IdCliente == idCliente);

            if (cliente == null)
                throw new Exception($"No se encontró el cliente con ID {idCliente}.");

            //  Cargamos la rutina
            var rutina = await context.Rutinas.FindAsync(idRutina);
            if (rutina == null)
                throw new Exception($"No se encontró la rutina con ID {idRutina}.");

            //  Inicializamos la lista si aún no existe
            if (cliente.Rutinas == null)
                cliente.Rutinas = new List<Rutina>();

            //  Evitamos duplicados
            if (cliente.Rutinas.Any(r => r.IdRutina == idRutina))
                throw new Exception("Esta rutina ya está asignada a este cliente.");

            //  Asignamos
            cliente.Rutinas.Add(rutina);

            await context.SaveChangesAsync();
        }


        public async Task EliminarRutinaAsync(int idCliente, int idRutina)
        {
            using var context = new GymContext();

            var cliente = await context.Clientes
                .Include(c => c.Rutinas)
                .FirstOrDefaultAsync(c => c.IdCliente == idCliente);

            if (cliente == null)
                throw new Exception("Cliente no encontrado.");

            var rutina = cliente.Rutinas.FirstOrDefault(r => r.IdRutina == idRutina);
            if (rutina == null)
                throw new Exception("Esta rutina no está asignada al cliente.");

            cliente.Rutinas.Remove(rutina);
            await context.SaveChangesAsync();
        }

    }
}
