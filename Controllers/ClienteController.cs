using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Services;

// Se encarga solo de coordinar llamadas entre la vista (Forms) y el ClienteService.
namespace Gestor_de_Rutinas___GYM.Controllers
{
    public class ClienteController
    {
        private readonly ClienteService _service = new();

        public List<Cliente> ObtenerClientes()
        {
            return _service.ObtenerTodos();
        }

        public void CrearCliente(string nombre, string apellido, DateTime fechaNacimiento, decimal peso, decimal altura, string objetivo)
        {
            var cliente = new Cliente(nombre, apellido, fechaNacimiento, peso, altura, objetivo);
            _service.Crear(cliente);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _service.Actualizar(cliente);
        }

        public void EliminarCliente(int id)
        {
            _service.Eliminar(id);
        }

        public Cliente? BuscarPorId(int id)
        {
            return _service.ObtenerPorId(id);
        }

        public void AsignarRutina(int idCliente, int idRutina)
        {
            _service.AsignarRutina(idCliente, idRutina);
        }

        public void EliminarRutina(int idCliente, int idRutina)
        {
            _service.EliminarRutina(idCliente, idRutina);
        }

        public List<Rutina> ObtenerRutinasDeCliente(int idCliente)
        {
            return _service.ObtenerRutinasDeCliente(idCliente);
        }
    }
}

