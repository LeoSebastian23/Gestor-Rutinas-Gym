using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class EjercicioBaseService
    {
        private readonly EjercicioBaseRepository _repo = new();

        public List<EjercicioBase> ObtenerTodos() => _repo.GetAll();
        public EjercicioBase? ObtenerPorId(int id) => _repo.GetById(id);
        public void Crear(EjercicioBase ejercicio) => _repo.Add(ejercicio);
        public void Actualizar(EjercicioBase ejercicio) => _repo.Update(ejercicio);
        public void Eliminar(int id) => _repo.Delete(id);
    }
}


