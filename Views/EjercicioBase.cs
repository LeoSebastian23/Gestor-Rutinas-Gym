using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormEjercicioBase : Form
    {
        private readonly EjercicioBaseController _controller = new();

        public FormEjercicioBase()
        {
            InitializeComponent();
            PostInitStyleSafe();
        }

        private void PostInitStyleSafe()
        {
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.White;

            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 45);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            panelCampos.BackColor = Color.FromArgb(40, 40, 40);

            EstilizarDataGrid(dgvEjercicios);
            StyleButton(btnAgregar, Color.FromArgb(46, 204, 113));
            StyleButton(btnEliminar, Color.FromArgb(231, 76, 60));
            StyleButton(btnVerTodos, Color.FromArgb(155, 89, 182));

            foreach (Control c in panelCampos.Controls)
            {
                if (c is Label lbl) lbl.ForeColor = Color.White;
                if (c is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(50, 50, 50);
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private static void EstilizarDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dgv.RowHeadersVisible = false;
            dgv.GridColor = Color.DimGray;
            dgv.Font = new Font("Segoe UI", 10);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void StyleButton(Button b, Color color)
        {
            b.BackColor = color;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.Height = 36;
        }

        // --- EVENTOS ---
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtGrupo.Text))
            {
                MessageBox.Show("Por favor, complete los campos requeridos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _controller.CrearEjercicioBase(txtNombre.Text, txtGrupo.Text, txtDescripcion.Text);
            CargarEjercicios();
            LimpiarCampos();

            MessageBox.Show("Ejercicio agregado correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow == null) return;

            var ejercicio = (EjercicioBase)dgvEjercicios.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"¿Desea eliminar el ejercicio '{ejercicio.Nombre}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                _controller.EliminarEjercicio(ejercicio.IdEjercicioBase);
                CargarEjercicios();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtGrupo.Clear();
            txtDescripcion.Clear();
        }
    }
}






