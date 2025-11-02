using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormEjercicioBase : Form
    {
        private readonly EjercicioBaseController _controller = new();

        public FormEjercicioBase()
        {
            InitializeComponent();
        }

        private async void FormEjercicioBase_Load(object sender, EventArgs e)
        {
            await CargarEjerciciosAsync();
        }

        private async Task CargarEjerciciosAsync()
        {
            dgvEjercicios.DataSource = await _controller.ObtenerEjerciciosAsync();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await _controller.CrearEjercicioBaseAsync(txtNombre.Text, txtGrupo.Text, txtDescripcion.Text);
            await CargarEjerciciosAsync();
            LimpiarCampos();
            DialogResult = DialogResult.OK;
            Close();

        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow == null) return;

            var ejercicio = (EjercicioBase)dgvEjercicios.CurrentRow.DataBoundItem;
            ejercicio.Nombre = txtNombre.Text;
            ejercicio.GrupoMuscular = txtGrupo.Text;
            ejercicio.Descripcion = txtDescripcion.Text;

            await _controller.ActualizarEjercicioAsync(ejercicio);
            await CargarEjerciciosAsync();
            LimpiarCampos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow == null) return;

            var ejercicio = (EjercicioBase)dgvEjercicios.CurrentRow.DataBoundItem;
            await _controller.EliminarEjercicioAsync(ejercicio.IdEjercicioBase);
            await CargarEjerciciosAsync();
        }

        private async void btnVerTodos_Click(object sender, EventArgs e)
        {
            await CargarEjerciciosAsync();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtGrupo.Clear();
            txtDescripcion.Clear();
        }
    }
}

