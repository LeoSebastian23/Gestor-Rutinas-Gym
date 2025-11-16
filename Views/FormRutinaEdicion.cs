using System;
using System.Drawing;
using System.Windows.Forms;
using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormRutinaEdicion : Form
    {
        private readonly RutinaController _controller = new();
        private readonly Rutina _rutina;

        public FormRutinaEdicion(Rutina rutina)
        {
            InitializeComponent();
            _rutina = rutina;
            EstilizarFormulario();
        }

        private void FormRutinaEdicion_Load(object sender, EventArgs e)
        {
            txtNombre.Text = _rutina.Nombre;
            txtDescripcion.Text = _rutina.Descripcion;
            numDuracion.Value = Math.Max(
         _rutina.DuracionSemana,
         numDuracion.Minimum
     );
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _rutina.Nombre = txtNombre.Text;
            _rutina.Descripcion = txtDescripcion.Text;
            _rutina.DuracionSemana = (int)numDuracion.Value;

            _controller.ActualizarRutina(_rutina);
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => Close();

        private void EstilizarFormulario()
        {
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.OfType<Label>().ToList().ForEach(l => l.ForeColor = Color.White);
            foreach (var btn in Controls.OfType<Button>())
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }
            btnGuardar.BackColor = Color.FromArgb(46, 204, 113);
            btnCancelar.BackColor = Color.FromArgb(231, 76, 60);
        }
    }
}

