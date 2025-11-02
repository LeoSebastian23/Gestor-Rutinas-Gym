using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Services;
using System;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormRutinasCliente : Form
    {
        private readonly Cliente _cliente;
        private readonly ClienteController _clienteController;
        private readonly RutinaController _rutinaController;

        public FormRutinasCliente(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            _clienteController = new ClienteController();
            _rutinaController = new RutinaController();

            // ⚙️ Evitamos que cargue antes de InitializeComponent()
            Load += FormRutinasCliente_Load;
        }

        private async void FormRutinasCliente_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = $"Rutinas de {_cliente.Nombre} {_cliente.Apellido}";
            await CargarRutinasAsync();
            await CargarRutinasDisponiblesAsync();
            ConfigurarColumnasRutinas();
        }
        private void ConfigurarColumnasRutinas()
        {
            dgvRutinasAsignadas.AutoGenerateColumns = false;
            dgvRutinasAsignadas.Columns.Clear();

            // 🏋️ Nombre
            dgvRutinasAsignadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 35
            });

            // ⏱️ Duración
            dgvRutinasAsignadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Duración (Semanas)",
                DataPropertyName = "DuracionSemanas",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 20
            });

            // 📝 Descripción
            dgvRutinasAsignadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 35
            });

            // 🔍 Botón “Ver Detalle”
            var btnDetalle = new DataGridViewButtonColumn
            {
                HeaderText = "Detalle",
                Text = "🔍 Ver Detalle",
                UseColumnTextForButtonValue = true,
                Width = 110
            };
            dgvRutinasAsignadas.Columns.Add(btnDetalle);

            // 📅 Botón “Ver Días”
            var btnDias = new DataGridViewButtonColumn
            {
                HeaderText = "Días",
                Text = "📅 Ver Días",
                UseColumnTextForButtonValue = true,
                Width = 110
            };
            dgvRutinasAsignadas.Columns.Add(btnDias);

            // 🎨 Estilo
            dgvRutinasAsignadas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRutinasAsignadas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 🎯 Evento Click
            dgvRutinasAsignadas.CellClick -= DgvRutinasAsignadas_CellClick;
            dgvRutinasAsignadas.CellClick += DgvRutinasAsignadas_CellClick;
        }

        private async Task CargarRutinasAsync()
        {
            if (_cliente == null)
            {
                MessageBox.Show("No se encontró el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rutinas = await _clienteController.ObtenerRutinasDeClienteAsync(_cliente.IdCliente);
            dgvRutinasAsignadas.DataSource = rutinas ?? new List<Rutina>();
        }

        private async Task CargarRutinasDisponiblesAsync()
        {
            var todas = await _rutinaController.ObtenerTodasAsync();
            cmbRutinasDisponibles.DataSource = todas;
            cmbRutinasDisponibles.DisplayMember = "Nombre";
            cmbRutinasDisponibles.ValueMember = "IdRutina";
        }

        private async void btnAsignarRutina_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRutinasDisponibles.SelectedItem is not Rutina rutinaSeleccionada)
                {
                    MessageBox.Show("Seleccione una rutina válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _clienteController.AsignarRutinaAsync(_cliente.IdCliente, rutinaSeleccionada.IdRutina);

                // 🔄 Actualizar la lista de rutinas en tiempo real
                await CargarRutinasAsync();

                MessageBox.Show("Rutina asignada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar rutina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminarRutina_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRutinasAsignadas.CurrentRow?.DataBoundItem is not Rutina rutinaSeleccionada)
                {
                    MessageBox.Show("Seleccione una rutina para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Seguro que desea eliminar la rutina '{rutinaSeleccionada.Nombre}' del cliente?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    await _clienteController.EliminarRutinaAsync(_cliente.IdCliente, rutinaSeleccionada.IdRutina);

                    // Recargar la grilla sin cerrar el formulario
                    await CargarRutinasAsync();

                    MessageBox.Show("Rutina eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rutina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvRutinasAsignadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rutina = dgvRutinasAsignadas.Rows[e.RowIndex].DataBoundItem as Rutina;
            if (rutina == null) return;

            // Si se presionó el botón de Detalle
            if (dgvRutinasAsignadas.Columns[e.ColumnIndex].HeaderText == "Detalle")
            {
                MessageBox.Show(
                    $"{rutina.Nombre}\n\n" +
                    $" Duración: {rutina.DuracionSemana} semanas\n" +
                    $" Descripción:\n{rutina.Descripcion}",
                    "Detalle de Rutina",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            // Si se presionó el botón de Días
            else if (dgvRutinasAsignadas.Columns[e.ColumnIndex].HeaderText == "Días")
            {
                var formDias = new FormDiasRutina(rutina);
                formDias.ShowDialog();
            }
        }

    }
}

