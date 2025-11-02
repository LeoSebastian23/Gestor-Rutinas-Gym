using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Services;

namespace Gestor_de_Rutinas___GYM.Controllers
{
    public class EjercicioBaseController
    {
        private readonly EjercicioBaseService _service = new();

        public async Task<List<EjercicioBase>> ObtenerEjerciciosAsync()
        {
            return await _service.ObtenerTodosAsync();
        }

        public async Task CrearEjercicioBaseAsync(string nombre, string grupo, string descripcion)
        {
            var ejercicio = new EjercicioBase(nombre, grupo, descripcion);
            await _service.CrearAsync(ejercicio);
        }

        public async Task ActualizarEjercicioAsync(EjercicioBase ejercicio)
        {
            await _service.ActualizarAsync(ejercicio);
        }

        public async Task EliminarEjercicioAsync(int id)
        {
            await _service.EliminarAsync(id);
        }
    }
}

