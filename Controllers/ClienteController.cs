using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Controllers
{
    public class ClienteController
    {
        private readonly ClienteService _service = new();

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _service.ObtenerTodosAsync();
        }

        public async Task CrearClienteAsync(string nombre, string apellido, DateTime fechaNacimiento, decimal peso, decimal altura, string objetivo)
        {
            var cliente = new Cliente(nombre, apellido, fechaNacimiento, peso, altura, objetivo);
            await _service.CrearAsync(cliente);
        }

        public async Task ActualizarClienteAsync(Cliente cliente)
        {
            await _service.ActualizarAsync(cliente);
        }

        public async Task EliminarClienteAsync(int id)
        {
            await _service.EliminarAsync(id);
        }

        public async Task<Cliente?> BuscarPorIdAsync(int id)
        {
            return await _service.ObtenerPorIdAsync(id);
        }
        public async Task AsignarRutinaAsync(int idCliente, int idRutina)
        {
            var service = new ClienteService();
            await service.AsignarRutinaAsync(idCliente, idRutina);
        }

        public async Task EliminarRutinaAsync(int idCliente, int idRutina)
        {
            var service = new ClienteService();
            await service.EliminarRutinaAsync(idCliente, idRutina);
        }

        public async Task<List<Rutina>> ObtenerRutinasDeClienteAsync(int idCliente)
        {
            var service = new ClienteService();
            return await service.ObtenerRutinasDeClienteAsync(idCliente);
        }

    }
}
