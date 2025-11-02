using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormRutina : Form
    {
        private readonly RutinaController _controller = new();

        private BindingSource diasBinding = new();
        private BindingSource ejerciciosBinding = new();

        private DiaEntrenamiento? diaSeleccionado;

        public FormRutina()
        {
            InitializeComponent();
        }

        // =====================================================
        // EVENTO LOAD
        // =====================================================
        private async void FormRutina_Load(object sender, EventArgs e)
        {
            dgvDias.DataSource = diasBinding;
            dgvEjercicios.DataSource = ejerciciosBinding;

            dgvDias.SelectionChanged += DgvDias_SelectionChanged;
            dgvEjercicios.CellFormatting += DgvEjercicios_CellFormatting;


            await CargarEjerciciosBaseAsync();
            PersonalizarColumnas();
        }

        // =====================================================
        // CAMBIO DE DÍA SELECCIONADO
        // =====================================================
        private void DgvDias_SelectionChanged(object? sender, EventArgs e)
        {
            diaSeleccionado = dgvDias.CurrentRow?.DataBoundItem as DiaEntrenamiento;
            ejerciciosBinding.DataSource = diaSeleccionado?.Ejercicios ?? new List<Ejercicio>();
        }

        // =====================================================
        // CREAR RUTINA
        // =====================================================
        private void btnCrearRutina_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para la rutina.");
                return;
            }

            _controller.CrearRutina(txtNombre.Text, (int)numDuracion.Value, txtDescripcion.Text);
            diasBinding.DataSource = _controller.ObtenerRutinaActual().Dias;

            MessageBox.Show("Rutina creada. Ahora puede agregar días de entrenamiento.");
        }

        // =====================================================
        // AGREGAR DÍA
        // =====================================================
        private void btnAgregarDia_Click(object sender, EventArgs e)
        {
            var diaSemana = cmbDiaSemana.SelectedItem?.ToString();
            var grupo = txtGrupoMuscular.Text;

            if (string.IsNullOrWhiteSpace(diaSemana) || string.IsNullOrWhiteSpace(grupo))
            {
                MessageBox.Show("Complete los campos del día de entrenamiento.");
                return;
            }

            _controller.AgregarDia(diaSemana, grupo);
            diasBinding.ResetBindings(false);
        }

        // =====================================================
        // AGREGAR EJERCICIO
        // =====================================================
        private void btnAgregarEjercicio_Click(object sender, EventArgs e)
        {
            if (diaSeleccionado == null)
            {
                MessageBox.Show("Seleccione un día primero.");
                return;
            }

            if (cmbEjercicioBase.SelectedItem is not EjercicioBase baseEj)
            {
                MessageBox.Show("Seleccione un ejercicio base.");
                return;
            }

            _controller.AgregarEjercicio(
                diaSeleccionado,
                baseEj,
                (int)numSeries.Value,
                (int)numReps.Value,
                numDescanso.Value,
                txtNotas.Text
            );

            ejerciciosBinding.ResetBindings(false);
        }

        // =====================================================
        // GUARDAR RUTINA
        // =====================================================
        private async void btnGuardarRutina_Click(object sender, EventArgs e)
        {
            await _controller.GuardarRutinaAsync();
            MessageBox.Show("Rutina guardada correctamente ✅");
            Close();
        }

        // =====================================================
        // CARGAR EJERCICIOS BASE
        // =====================================================
        private async Task CargarEjerciciosBaseAsync()
        {
            try
            {
                var ejercicios = await _controller.ObtenerEjerciciosBaseAsync();
                cmbEjercicioBase.DataSource = ejercicios;
                cmbEjercicioBase.DisplayMember = "Nombre";
                cmbEjercicioBase.ValueMember = "IdEjercicioBase";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejercicios base: {ex.Message}");
            }
        }

        // =====================================================
        // ABRIR MODAL NUEVO EJERCICIO BASE
        // =====================================================
        private async void btnNuevoEjercicioBase_Click(object sender, EventArgs e)
        {
            using var modal = new FormEjercicioBase
            {
                StartPosition = FormStartPosition.CenterParent
            };

            // Si se guardó correctamente en el modal
            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                await CargarEjerciciosBaseAsync();
                MessageBox.Show("✅ Ejercicio Base agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =====================================================
        // PERSONALIZAR COLUMNAS
        // =====================================================
        private void PersonalizarColumnas()
        {
            // ---- DataGridView Días ----
            dgvDias.AutoGenerateColumns = false;
            dgvDias.Columns.Clear();

            dgvDias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Día",
                DataPropertyName = "DiaSemana",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Grupo Muscular",
                DataPropertyName = "GrupoMuscular",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ---- DataGridView Ejercicios ----
            dgvEjercicios.AutoGenerateColumns = false;
            dgvEjercicios.Columns.Clear();

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Ejercicio",
                DataPropertyName = "EjercicioBase",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Series",
                DataPropertyName = "Series",
                Width = 70
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Reps",
                DataPropertyName = "Repeticiones",
                Width = 70
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Descanso (s)",
                DataPropertyName = "Descanso",
                Width = 100
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Notas",
                DataPropertyName = "Notas",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void DgvEjercicios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEjercicios.Columns[e.ColumnIndex].HeaderText == "Ejercicio")
            {
                if (e.Value is EjercicioBase baseEj)
                {
                    e.Value = baseEj.Nombre; // Mostramos nombre del ejercico
                }
            }
        }

    }
}



