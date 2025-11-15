using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormRutinaDetalle : Form
    {
        private readonly Rutina _rutina;

        // 🎨 PALETA OFICIAL
        private readonly Color cFondo = ColorTranslator.FromHtml("#484848");
        private readonly Color cPrimario = ColorTranslator.FromHtml("#0f928c");

        public FormRutinaDetalle(Rutina rutina)
        {
            InitializeComponent();
            _rutina = rutina;
            EstilizarFormulario();
        }

        private void FormRutinaDetalle_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = $"Detalles de {_rutina.Nombre}";

            CargarDias();

            // Evento: cambiar día → carga ejercicios
            dgvDias.SelectionChanged += (_, _) => CargarEjercicios();
        }


        // -------------------- CARGA DÍAS --------------------

        private void CargarDias()
        {
            dgvDias.AutoGenerateColumns = true;

            dgvDias.DataSource = _rutina.Dias.Select(d => new
            {
                d.DiaSemana,
                d.GrupoMuscular,
                Ejercicios = d.Ejercicios.Count,
                Ref = d
            }).ToList();

            // Oculta la columna interna
            dgvDias.Columns["Ref"].Visible = false;

            // Selecciona automáticamente el primer día
            if (dgvDias.Rows.Count > 0)
                dgvDias.Rows[0].Selected = true;
        }


        // -------------------- CARGA EJERCICIOS --------------------

        private void CargarEjercicios()
        {
            if (dgvDias.CurrentRow == null) return;

            var dia = dgvDias.CurrentRow.Cells["Ref"].Value as DiaEntrenamiento;
            if (dia == null) return;

            dgvEjercicios.AutoGenerateColumns = true;

            dgvEjercicios.DataSource = dia.Ejercicios.Select(e => new
            {
                Ejercicio = e.EjercicioBase?.Nombre ?? "Ejercicio",
                Series = e.Series,
                Repeticiones = e.Repeticiones,
                Descanso = $"{e.Descanso} seg",
                Notas = e.Notas ?? ""
            }).ToList();
        }


        // -------------------- ESTILO --------------------

        private void EstilizarFormulario()
        {
            BackColor = cFondo;

            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.BackColor = Color.FromArgb(60, 60, 60);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            EstilizarGrid(dgvDias);
            EstilizarGrid(dgvEjercicios);

            // Botón cerrar acorde a tu paleta
            btnCerrar.BackColor = cPrimario;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
        }

        private void EstilizarGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(70, 70, 70);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(55, 55, 55);
            dgv.DefaultCellStyle.ForeColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = cPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}




