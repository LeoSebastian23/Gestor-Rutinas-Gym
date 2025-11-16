using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Utils.Exportar;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormRutinasCliente : Form
    {
        private readonly Cliente _cliente;
        private readonly ClienteController _clienteController = new();
        private readonly RutinaController _rutinaController = new();

        public FormRutinasCliente(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            Load += (_, _) => InicializarVista();
        }

        private void InicializarVista()
        {
            lblTitulo.Text = $"Rutinas de {_cliente.Nombre} {_cliente.Apellido}";
            ConfigurarEstiloFormulario();
            ConfigurarColumnasRutinas();
            CargarRutinas();
            CargarRutinasDisponibles();
        }

        private void ConfigurarEstiloFormulario()
        {
            BackColor = ColorTranslator.FromHtml("#484848");
            ForeColor = Color.White;

            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.BackColor = ColorTranslator.FromHtml("#484848");
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            ConfigurarGrid(dgvRutinasAsignadas);

            EstilizarBoton(btnAsignarRutina, ColorTranslator.FromHtml("#0f928c"));
            EstilizarBoton(btnEliminarRutina, ColorTranslator.FromHtml("#beee3b"), Color.Black);
        }

        private static void ConfigurarGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f928c");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new("Segoe UI", 10, FontStyle.Bold);

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
        }

        private static void EstilizarBoton(Button b, Color color, Color? textColor = null)
        {
            b.BackColor = color;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.ForeColor = textColor ?? Color.White;
            b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }

        private void ConfigurarColumnasRutinas()
        {
            dgvRutinasAsignadas.AutoGenerateColumns = false;
            dgvRutinasAsignadas.Columns.Clear();

            void AddCol(string header, string prop, int fill) =>
                dgvRutinasAsignadas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = header,
                    DataPropertyName = prop,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = fill
                });

            AddCol("Nombre", "Nombre", 40);
            AddCol("Semanas", "DuracionSemana", 20);
            AddCol("Descripción", "Descripcion", 40);

            dgvRutinasAsignadas.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Detalle",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                Width = 90
            });

            dgvRutinasAsignadas.CellClick -= DgvRutinasAsignadas_CellClick;
            dgvRutinasAsignadas.CellClick += DgvRutinasAsignadas_CellClick;
        }

        // *** AQUI ESTA EL CAMBIO ***
        private void CargarRutinas()
        {
            var rutinas = _clienteController.ObtenerRutinasDeCliente(_cliente.IdCliente)
                          ?? new List<Rutina>();

            dgvRutinasAsignadas.DataSource = null;
            dgvRutinasAsignadas.DataSource = rutinas;
            dgvRutinasAsignadas.Refresh();
        }

        private void CargarRutinasDisponibles()
        {
            var rutinas = _rutinaController.ObtenerTodas();
            cmbRutinasDisponibles.DataSource = rutinas;
            cmbRutinasDisponibles.DisplayMember = "Nombre";
            cmbRutinasDisponibles.ValueMember = "IdRutina";
        }

        private void btnAsignarRutina_Click(object sender, EventArgs e)
        {
            if (cmbRutinasDisponibles.SelectedItem is not Rutina rutina)
            {
                Msg("Seleccione una rutina válida.");
                return;
            }

            try
            {
                _clienteController.AsignarRutina(_cliente.IdCliente, rutina.IdRutina);

                CargarRutinas();

                foreach (DataGridViewRow row in dgvRutinasAsignadas.Rows)
                {
                    if (row.DataBoundItem is Rutina r && r.IdRutina == rutina.IdRutina)
                    {
                        row.Selected = true;
                        break;
                    }
                }

                Msg("Rutina asignada correctamente.");
            }
            catch (Exception ex)
            {
                Error("asignar rutina", ex);
            }
        }

        private void btnEliminarRutina_Click(object sender, EventArgs e)
        {
            if (dgvRutinasAsignadas.CurrentRow?.DataBoundItem is not Rutina rutina) return;

            if (!Confirm($"¿Seguro de eliminar la rutina '{rutina.Nombre}'?")) return;

            try
            {
                _clienteController.EliminarRutina(_cliente.IdCliente, rutina.IdRutina);
                CargarRutinas();
                Msg("Rutina eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Error("eliminar rutina", ex);
            }
        }

        private void DgvRutinasAsignadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvRutinasAsignadas.Columns[e.ColumnIndex].HeaderText != "Detalle") return;

            if (dgvRutinasAsignadas.Rows[e.RowIndex].DataBoundItem is not Rutina rutina)
                return;

            var rutinaCompleta = _rutinaController.ObtenerPorId(rutina.IdRutina);

            var detalle = new FormRutinaDetalle(rutinaCompleta)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            detalle.ShowDialog(this);
        }

        private static void Msg(string t) =>
            MessageBox.Show(t, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static bool Confirm(string txt) =>
            MessageBox.Show(txt, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private static void Error(string accion, Exception ex) =>
            MessageBox.Show($"Error al {accion}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            Exportar("PDF");
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Exportar("EXCEL");
        }

        private void Exportar(string tipo)
        {
            if (dgvRutinasAsignadas.CurrentRow?.DataBoundItem is not Rutina rutina)
            {
                Msg("Seleccione una rutina.");
                return;
            }

            var rutinaCompleta = _rutinaController.ObtenerPorId(rutina.IdRutina);

            using var save = new SaveFileDialog
            {
                Filter = tipo == "PDF" ? "PDF|*.pdf" : "Excel|*.xlsx",
                FileName = $"Rutina_{_cliente.Nombre}_{_cliente.Apellido}"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                var exportador = ExportadorFactory.Crear(tipo);
                exportador.Exportar(_cliente, rutinaCompleta, save.FileName);

                Msg($"{tipo} generado correctamente.");
            }
        }
    }
}
