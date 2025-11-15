using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;


namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormRutina : Form
    {
        private readonly RutinaController _controller = new();
        private readonly BindingSource diasBinding = new();
        private readonly BindingSource ejerciciosBinding = new();
        private DiaEntrenamiento? diaSeleccionado;
        private Button btnVerRutinas;

        public FormRutina()
        {
            InitializeComponent();
            InicializarBotonVerRutinas();
            AplicarEstilo();

            // Refresca TODO cada vez que volvés a la pantalla
            this.Activated += (_, _) => RefreshData();
        }

        private void FormRutina_Load(object sender, EventArgs e)
        {
            dgvDias.DataSource = diasBinding;
            dgvEjercicios.DataSource = ejerciciosBinding;

            dgvDias.SelectionChanged += (_, _) => ActualizarEjercicios();
            dgvDias.CellClick += Dgv_CellClick;
            dgvEjercicios.CellClick += Dgv_CellClick;
            dgvEjercicios.CellFormatting += (_, e) =>
            {
                if (dgvEjercicios.Columns[e.ColumnIndex].HeaderText == "Ejercicio" && e.Value is EjercicioBase b) e.Value = b.Nombre;
            };

            CargarEjerciciosBase();
            ConfigurarGrid(dgvDias, "DiaSemana", "Día", "GrupoMuscular", "Grupo Muscular");
            ConfigurarGrid(dgvEjercicios, "EjercicioBase", "Ejercicio", "Series", "Series", "Repeticiones", "Reps", "Descanso", "Descanso (s)", "Notas", "Notas");
        }

        private void RefreshData()
        {
            // Vuelve a cargar los ejercicios base
            CargarEjerciciosBase();

            // Refresca el Binding de días y ejercicios si ya existe una rutina creada
            var rutina = _controller.ObtenerRutinaActual();
            if (rutina != null)
            {
                diasBinding.DataSource = rutina.Dias;
                diasBinding.ResetBindings(false);
                ActualizarEjercicios();
            }
        }

        private void AplicarEstilo()
        {
            BackColor = ColorTranslator.FromHtml("#484848");
            ForeColor = Color.White;
            btnGuardarRutina.BackColor = ColorTranslator.FromHtml("#0f928c");
            btnAgregarDia.BackColor = ColorTranslator.FromHtml("#00c9d2");
            btnAgregarEjercicio.BackColor = ColorTranslator.FromHtml("#006465");
            btnNuevoEjercicioBase.BackColor = ColorTranslator.FromHtml("#beee3b");
            btnNuevoEjercicioBase.ForeColor = Color.Black;

            foreach (var dgv in new[] { dgvDias, dgvEjercicios })
            {
                dgv.BackgroundColor = Color.FromArgb(50, 50, 50);
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = false;
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f928c");
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void ConfigurarGrid(DataGridView dgv, params string[] columnas)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            for (int i = 0; i < columnas.Length; i += 2)
                dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = columnas[i + 1], DataPropertyName = columnas[i], AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv.Columns.Add(new DataGridViewButtonColumn { HeaderText = "🗑", Text = "🗑", Name = "Eliminar", UseColumnTextForButtonValue = true, Width = 50 });
        }

        private void btnCrearRutina_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Msg("Debe ingresar un nombre para la rutina.", "Aviso");
                return;
            }

            _controller.CrearRutina(txtNombre.Text, (int)numDuracion.Value, txtDescripcion.Text);
            diasBinding.DataSource = _controller.ObtenerRutinaActual().Dias;
            Msg("Rutina creada. Ahora puede agregar días de entrenamiento.");
        }

        private void btnAgregarDia_Click(object sender, EventArgs e)
        {
            if (cmbDiaSemana.SelectedItem == null || string.IsNullOrWhiteSpace(txtGrupoMuscular.Text))
            {
                Msg("Complete los campos del día.");
                return;
            }

            _controller.AgregarDia(cmbDiaSemana.Text, txtGrupoMuscular.Text);
            diasBinding.ResetBindings(false);
        }

        private void btnAgregarEjercicio_Click(object sender, EventArgs e)
        {
            if (diaSeleccionado == null)
            {
                Msg("Seleccione un día primero.");
                return;
            }

            if (cmbEjercicioBase.SelectedItem is not EjercicioBase baseEj)
            {
                Msg("Seleccione un ejercicio base.");
                return;
            }

            _controller.AgregarEjercicio(
                diaSeleccionado, baseEj,
                (int)numSeries.Value, (int)numReps.Value, numDescanso.Value, txtNotas.Text
            );

            ejerciciosBinding.ResetBindings(false);
        }


        private void btnGuardarRutina_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.GuardarRutina();
                Msg("Rutina guardada correctamente ✅", "Éxito");
                Close();
            }
            catch (Exception ex)
            {
                Msg($"Error al guardar rutina: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void CargarEjerciciosBase()
        {
            try
            {
                var ejercicios = _controller.ObtenerEjerciciosBase();
                cmbEjercicioBase.DataSource = ejercicios;
                cmbEjercicioBase.DisplayMember = "Nombre";
                cmbEjercicioBase.ValueMember = "IdEjercicioBase";
            }
            catch (Exception ex) { Msg($"Error al cargar ejercicios base: {ex.Message}", "Error", MessageBoxIcon.Error); }
        }

        private void btnNuevoEjercicioBase_Click(object sender, EventArgs e)
        {
            using var modal = new FormEjercicioBase { StartPosition = FormStartPosition.CenterParent };
            if (modal.ShowDialog(this) == DialogResult.OK)
                RefreshData();
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var dgv = sender as DataGridView;
            if (dgv?.Columns[e.ColumnIndex].Name != "Eliminar") return;

            if (dgv == dgvDias && dgv.Rows[e.RowIndex].DataBoundItem is DiaEntrenamiento dia)
            {
                if (Confirm($"¿Eliminar el día '{dia.DiaSemana}'?")) { _controller.EliminarDia(dia); diasBinding.ResetBindings(false); }
            }
            else if (dgv == dgvEjercicios && dgv.Rows[e.RowIndex].DataBoundItem is Ejercicio ej)
            {
                if (Confirm("¿Eliminar este ejercicio?")) { _controller.EliminarEjercicio(diaSeleccionado, ej); ejerciciosBinding.ResetBindings(false); }
            }
        }

        private void ActualizarEjercicios()
        {
            diaSeleccionado = dgvDias.CurrentRow?.DataBoundItem as DiaEntrenamiento;
            ejerciciosBinding.DataSource = diaSeleccionado?.Ejercicios ?? new List<Ejercicio>();
        }

        private void InicializarBotonVerRutinas()
        {
            btnVerRutinas = new Button
            {
                Text = "📋 Ver Rutinas",
                Location = new Point(800, 20),
                Size = new Size(140, 30),
                BackColor = ColorTranslator.FromHtml("#0f928c"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnVerRutinas.Click += (_, _) => new FormListadoRutinas().ShowDialog(this);
            Controls.Add(btnVerRutinas);
        }

        private static void Msg(string txt, string title = "Aviso", MessageBoxIcon icon = MessageBoxIcon.Information) =>
            MessageBox.Show(txt, title, MessageBoxButtons.OK, icon);

        private static bool Confirm(string txt) =>
            MessageBox.Show(txt, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }
}