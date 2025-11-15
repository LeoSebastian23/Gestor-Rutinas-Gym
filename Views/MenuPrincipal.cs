using System.Drawing;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ConfigurarPaneles();
            AplicarPaletaColores();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Gestor de Rutinas Personalizadas";
        }

        // --- CONFIGURACIÓN ---
        private void ConfigurarPaneles()
        {
            var paneles = new[] { panelClientes, panelRutinas, panelEjercicios };

            foreach (var p in paneles)
            {
                p.Cursor = Cursors.Hand;
                p.MouseEnter += (_, _) => p.BackColor = ControlPaint.Light(p.BackColor, 0.25f);
                p.MouseLeave += (_, _) => p.BackColor = ObtenerColorBase(p);
                p.Paint += (s, e) => DibujarTextoCentrado(e.Graphics, ObtenerTexto(p), p.ClientRectangle);
            }
        }

        private void AplicarPaletaColores()
        {
            BackColor = ColorTranslator.FromHtml("#484848");
            lblTitulo.BackColor = ColorTranslator.FromHtml("#484848");
            lblTitulo.ForeColor = Color.White;

            panelClientes.BackColor = ColorTranslator.FromHtml("#006465");
            panelRutinas.BackColor = ColorTranslator.FromHtml("#0f928c");
            panelEjercicios.BackColor = ColorTranslator.FromHtml("#00c9d2");

            btnSalir.BackColor = ColorTranslator.FromHtml("#beee3b");
            btnSalir.ForeColor = Color.Black;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Cursor = Cursors.Hand;
        }

        // --- NAVEGACIÓN ---
        private void panelClientes_Click(object sender, EventArgs e) => Abrir(new FormClientes());
        private void panelRutinas_Click(object sender, EventArgs e) => Abrir(new FormRutina());
        private void panelEjercicios_Click(object sender, EventArgs e) => Abrir(new FormEjercicioBase());
        private void btnSalir_Click(object sender, EventArgs e) => Close();

        private static void Abrir(Form f)
        {
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        // --- UTILITARIOS ---
        private static string ObtenerTexto(Panel p) => p.Name switch
        {
            nameof(panelClientes) => "Gestión de Clientes",
            nameof(panelRutinas) => "Gestión de Rutinas",
            nameof(panelEjercicios) => "Catálogo de Ejercicios",
            _ => string.Empty
        };

        private static Color ObtenerColorBase(Panel p) => p.Name switch
        {
            nameof(panelClientes) => ColorTranslator.FromHtml("#006465"),
            nameof(panelRutinas) => ColorTranslator.FromHtml("#0f928c"),
            nameof(panelEjercicios) => ColorTranslator.FromHtml("#00c9d2"),
            _ => p.BackColor
        };

        private static void DibujarTextoCentrado(Graphics g, string texto, Rectangle rect)
        {
            using var font = new Font("Segoe UI", 18, FontStyle.Bold);
            using var brush = new SolidBrush(Color.White);
            var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(texto, font, brush, rect, format);
        }
    }
}





