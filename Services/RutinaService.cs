using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Repositories;

namespace Gestor_de_Rutinas___GYM.Services
{
    public class RutinaService
    {
        private readonly RutinaRepository _repo = new();

        public List<Rutina> ObtenerTodas() => _repo.GetAll();
        public Rutina? ObtenerPorId(int id) => _repo.GetById(id);
        public void Crear(Rutina rutina) => _repo.Add(rutina);
        public void Actualizar(Rutina rutina) => _repo.Update(rutina);
        public void Eliminar(int id) => _repo.Delete(id);
    }
}


