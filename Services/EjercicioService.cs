using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class EjercicioService
    {
        private readonly EjercicioRepository _repo = new();

        public List<Ejercicio> ObtenerTodos() => _repo.GetAll();
        public void Crear(Ejercicio ejercicio) => _repo.Add(ejercicio);
        public void Actualizar(Ejercicio ejercicio) => _repo.Update(ejercicio);
        public void Eliminar(int id) => _repo.Delete(id);
    }
}


