using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormEjercicioBase : Form
    {
        private readonly EjercicioBaseController _controller = new();

        // PALETA OFICIAL
        private readonly Color cFondo = ColorTranslator.FromHtml("#484848");
        private readonly Color cPrimario = ColorTranslator.FromHtml("#0f928c");
        private readonly Color cSecundario = ColorTranslator.FromHtml("#006465");
        private readonly Color cHover = ColorTranslator.FromHtml("#00c9d2");
        private readonly Color cAcento = ColorTranslator.FromHtml("#beee3b");

        public FormEjercicioBase()
        {
            InitializeComponent();
            EstilizarFormulario();
        }

        // -------------------- ESTILO GENERAL --------------------

        private void EstilizarFormulario()
        {
            BackColor = cFondo;
            ForeColor = Color.White;

            EstilizarTitulo(lblTitulo);
            EstilizarPanel(panelCampos);
            EstilizarGrid(dgvEjercicios);

            EstilizarBoton(btnAgregar, cPrimario);
            EstilizarBoton(btnEliminar, Color.FromArgb(231, 76, 60)); // rojo elegante

            // Estilo general para todos los TextBox dentro del panel
            foreach (Control c in panelCampos.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(55, 55, 55);
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void EstilizarTitulo(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void EstilizarPanel(Panel p)
        {
            p.BackColor = Color.FromArgb(55, 55, 55);
        }

        private void EstilizarBoton(Button b, Color color)
        {
            b.BackColor = color;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.Height = 36;
        }

        private void EstilizarGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(70, 70, 70);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(25, 130, 140);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = cPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // -------------------- EVENTOS --------------------

        private void FormEjercicioBase_Load(object sender, EventArgs e)
        {
            CargarEjercicios();
        }

        private void CargarEjercicios()
        {
            dgvEjercicios.DataSource = _controller.ObtenerEjercicios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtGrupo.Text))
            {
                MessageBox.Show("Por favor, complete los campos requeridos.", "Aviso");
                return;
            }

            _controller.CrearEjercicioBase(
                txtNombre.Text,
                txtGrupo.Text,
                txtDescripcion.Text
            );

            CargarEjercicios();
            LimpiarCampos();

            MessageBox.Show("Ejercicio agregado correctamente.", "Éxito");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow == null) return;

            if (MessageBox.Show("¿Desea eliminar el ejercicio seleccionado?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No) return;

            var ejercicio = (EjercicioBase)dgvEjercicios.CurrentRow.DataBoundItem;
            _controller.EliminarEjercicio(ejercicio.IdEjercicioBase);

            CargarEjercicios();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtGrupo.Clear();
            txtDescripcion.Clear();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}







