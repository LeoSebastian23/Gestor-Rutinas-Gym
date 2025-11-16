using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;
using Gestor_de_Rutinas___GYM.Utils.Exportar;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormListadoRutinas : Form
    {
        private readonly RutinaController _controller = new();
        private List<Rutina> _rutinas = new();

        private readonly Color cFondo = ColorTranslator.FromHtml("#484848");
        private readonly Color cPrimario = ColorTranslator.FromHtml("#0f928c");
        private readonly Color cSecundario = ColorTranslator.FromHtml("#006465");
        private readonly Color cHover = ColorTranslator.FromHtml("#00c9d2");
        private readonly Color cAcento = ColorTranslator.FromHtml("#beee3b");

        public FormListadoRutinas()
        {
            InitializeComponent();
            EstilizarFormulario();
        }

        private void FormListadoRutinas_Load(object sender, EventArgs e)
        {
            CargarRutinas();
        }
        // -------------------- CARGA --------------------
        private void CargarRutinas()
        {
            try
            {
                _rutinas = _controller.ObtenerTodas();

                dgvRutinas.DataSource = _rutinas.Select(r => new
                {
                    r.IdRutina,
                    r.Nombre,
                    r.Descripcion,
                    Duración = $"{r.DuracionSemana} semanas",
                    Dias = r.Dias.Count
                }).ToList();

                if (dgvRutinas.Columns["IdRutina"] != null)
                    dgvRutinas.Columns["IdRutina"].Visible = false;
            }
            catch (Exception ex) { Msg($"Error al cargar rutinas: {ex.Message}", "Error"); }
        }
        // -------------------- CRUD --------------------
        private void btnVerDias_Click(object sender, EventArgs e)
        {
            if (TryGetRutina(out var rutina))
                new FormRutinaDetalle(rutina)
                {
                    StartPosition = FormStartPosition.CenterParent
                }.ShowDialog(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!TryGetRutina(out var rutina)) return;

            using var modal = new FormRutinaEdicion(rutina)
            { StartPosition = FormStartPosition.CenterParent };

            if (modal.ShowDialog(this) == DialogResult.OK)
                CargarRutinas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!TryGetRutina(out var rutina)) return;

            if (Confirm($"¿Eliminar la rutina '{rutina.Nombre}'?"))
            {
                _controller.EliminarRutina(rutina.IdRutina);
                CargarRutinas();
            }
        }

        // -------------------- AUXILIARES --------------------
        private bool TryGetRutina(out Rutina rutina)
        {
            rutina = null;

            if (dgvRutinas.CurrentRow == null)
            {
                Msg("Seleccione una rutina primero.");
                return false;
            }

            int id = Convert.ToInt32(dgvRutinas.CurrentRow.Cells["IdRutina"].Value);
            rutina = _rutinas.FirstOrDefault(r => r.IdRutina == id);
            return rutina != null;
        }

        private static void Msg(string t, string title = "Aviso") =>
            MessageBox.Show(t, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static bool Confirm(string t) =>
            MessageBox.Show(t, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

        // -------------------- ESTILO --------------------
        private void EstilizarFormulario()
        {
            BackColor = cFondo;

            EstilizarTitulo(lblTitulo);
            EstilizarGrid(dgvRutinas);

            EstilizarBoton(btnVerDias, cPrimario);
            EstilizarBoton(btnModificar, cHover);
            EstilizarBoton(btnEliminar, cSecundario);
            EstilizarBoton(btnCerrar, Color.Gray);
        }

        private void EstilizarTitulo(Label lbl)
        {
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lbl.BackColor = Color.FromArgb(60, 60, 60);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void EstilizarBoton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private void EstilizarGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(70, 70, 70);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(55, 55, 55);
            dgv.DefaultCellStyle.ForeColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = cPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();


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
            if (!TryGetRutina(out var rutina))
                return;

            using var save = new SaveFileDialog
            {
                Filter = tipo == "PDF" ? "PDF|*.pdf" : "Excel|*.xlsx",
                FileName = $"Rutina_{rutina.Nombre}"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                var exportador = ExportadorFactory.Crear(tipo);
                exportador.Exportar(null, rutina, save.FileName);

                Msg($"{tipo} generado correctamente.");
            }
        }
    }
    }


