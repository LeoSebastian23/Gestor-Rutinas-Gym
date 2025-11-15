using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class DiaEntrenamientoService
    {
        private readonly DiaEntrenamientoRepository _repo = new();

        public List<DiaEntrenamiento> ObtenerTodos() => _repo.GetAll();
        public void Crear(DiaEntrenamiento dia) => _repo.Add(dia);
        public void Actualizar(DiaEntrenamiento dia) => _repo.Update(dia);
        public void Eliminar(int id) => _repo.Delete(id);
    }
}


