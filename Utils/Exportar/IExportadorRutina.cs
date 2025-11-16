using Gestor_de_Rutinas___GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Rutinas___GYM.Utils.Exportar
{
    public interface IExportadorRutina
    {
        void Exportar(Cliente cliente, Rutina rutina, string rutaDestino);
    }
}

