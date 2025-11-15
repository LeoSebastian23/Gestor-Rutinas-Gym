using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Services;

// Se encarga solo de coordinar llamadas entre la vista (Forms) y el EjercicioBaseService.
namespace Gestor_de_Rutinas___GYM.Controllers
{
    public class EjercicioBaseController
    {
        private readonly EjercicioBaseService _service = new();

        public List<EjercicioBase> ObtenerEjercicios()
        {
            return _service.ObtenerTodos();
        }

        public void CrearEjercicioBase(string nombre, string grupo, string descripcion)
        {
            var ejercicio = new EjercicioBase(nombre, grupo, descripcion);
            _service.Crear(ejercicio);
        }

        public void ActualizarEjercicio(EjercicioBase ejercicio)
        {
            _service.Actualizar(ejercicio);
        }

        public void EliminarEjercicio(int id)
        {
            _service.Eliminar(id);
        }
    }
}


