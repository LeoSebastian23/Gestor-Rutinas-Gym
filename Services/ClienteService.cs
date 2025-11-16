using Gestor_de_Rutinas___GYM.Data;
using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository = new();
        private readonly RutinaRepository _rutinaRepo = new();

        public List<Cliente> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public Cliente? ObtenerPorId(int id)
        {
            return _repository.GetById(id);
        }

        public void Crear(Cliente cliente)
        {
            _repository.Add(cliente);
        }

        public void Actualizar(Cliente cliente)
        {
            _repository.Update(cliente);
        }

        public void Eliminar(int id)
        {
            _repository.Delete(id);
        }

        // Siempre recargar las rutinas desde DB usando un contexto LIMPIO
        public List<Rutina> ObtenerRutinasDeCliente(int idCliente)
        {
            using var context = new GymContext();

            var cliente = context.Clientes
                .Include(c => c.Rutinas)
                .FirstOrDefault(c => c.IdCliente == idCliente)
                ?? throw new Exception("Cliente no encontrado.");

            return cliente.Rutinas.ToList();
        }

        public void AsignarRutina(int idCliente, int idRutina)
        {
            using var context = new GymContext();

            var cliente = context.Clientes
                .Include(c => c.Rutinas)
                .FirstOrDefault(c => c.IdCliente == idCliente)
                ?? throw new Exception($"No se encontró el cliente con ID {idCliente}.");

            var rutina = context.Rutinas.Find(idRutina)
                ?? throw new Exception($"No se encontró la rutina con ID {idRutina}.");

            if (cliente.Rutinas == null)
                cliente.Rutinas = new List<Rutina>();

            if (cliente.Rutinas.Any(r => r.IdRutina == idRutina))
                throw new Exception("Esta rutina ya está asignada a este cliente.");

            cliente.Rutinas.Add(rutina);
            context.SaveChanges();
        }

        public void EliminarRutina(int idCliente, int idRutina)
        {
            using var context = new GymContext();

            var cliente = context.Clientes
                .Include(c => c.Rutinas)
                .FirstOrDefault(c => c.IdCliente == idCliente)
                ?? throw new Exception("Cliente no encontrado.");

            var rutina = cliente.Rutinas.FirstOrDefault(r => r.IdRutina == idRutina)
                ?? throw new Exception("Esta rutina no está asignada al cliente.");

            cliente.Rutinas.Remove(rutina);
            context.SaveChanges();
        }
    }
}
