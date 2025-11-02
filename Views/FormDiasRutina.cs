using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Gestor_de_Rutinas___GYM.Models;
using System.Linq;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormDiasRutina : Form
    {
        private readonly Rutina _rutina;

        public FormDiasRutina(Rutina rutina)
        {
            InitializeComponent();
            _rutina = rutina;
            Text = $"Días de {_rutina.Nombre}";
            CargarDias();
        }

        private void CargarDias()
        {
            var lista = _rutina.Dias?.Select(d => new
            {
                Día = d.DiaSemana,
                Grupo = d.GrupoMuscular,
                Ejercicios = d.Ejercicios?.Count ?? 0
            }).ToList();

            dgvDias.DataSource = lista;
        }
    }
}

