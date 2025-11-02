using System;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            // Opcional: mejora de renderizado para evitar parpadeo
            this.DoubleBuffered = true;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Gestor de Rutinas";
        }

        // --- Navegación ---
        private void panelClientes_Click(object sender, EventArgs e)
        {
            using var form = new FormClientes();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        private void panelRutinas_Click(object sender, EventArgs e)
        {
            using var form = new FormRutina();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        private void panelEjercicios_Click(object sender, EventArgs e)
        {
            using var form = new FormEjercicioBase();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // --- Tarjetas ---
        private void panelClientes_Paint(object sender, PaintEventArgs e)
        {
            DibujarPanel(e, "Clientes", panelClientes);
        }

        private void panelRutinas_Paint(object sender, PaintEventArgs e)
        {
            DibujarPanel(e, "Rutinas", panelRutinas);
        }

        private void panelEjercicios_Paint(object sender, PaintEventArgs e)
        {
            DibujarPanel(e, "Ejercicios", panelEjercicios);
        }

        // --- Hover opcional para efecto visual ---
        private void panel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel p) p.BackColor = ControlPaint.Light(p.BackColor);
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel p)
            {
                if (p == panelClientes) p.BackColor = Color.FromArgb(52, 152, 219);
                else if (p == panelRutinas) p.BackColor = Color.FromArgb(46, 204, 113);
                else if (p == panelEjercicios) p.BackColor = Color.FromArgb(231, 76, 60);
            }
        }

        // --- Dibuja texto centrado dentro del panel ---
        private void DibujarPanel(PaintEventArgs e, string texto, Panel panel)
        {
                using var font = new Font("Segoe UI", 18, FontStyle.Bold);
                var formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawString(texto, font, Brushes.White, panel.ClientRectangle, formato);
            }
        }
}


