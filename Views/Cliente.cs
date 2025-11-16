using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormClientes : Form
    {
        private readonly ClienteController _controller = new();

        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            ConfigurarColumnaRutinas();
        }

        private void CargarClientes()
        {
            var clientes = _controller.ObtenerClientes()
                .Select(c => new
                {
                    c.IdCliente,
                    c.Nombre,
                    c.Apellido,
                    Edad = CalcularEdad(c.FechaNacimiento),
                    Peso = $"{c.Peso} kg",
                    Altura = $"{c.Altura} m",
                    c.Objetivo
                })
                .ToList();

            dgvClientes.DataSource = clientes;

            dgvClientes.Columns["IdCliente"].Visible = false;
        }

        private void ConfigurarColumnaRutinas()
        {
            if (!dgvClientes.Columns.Contains("btnVerRutinas"))
            {
                dgvClientes.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "btnVerRutinas",
                    HeaderText = "Rutinas",
                    Text = "📋 Ver",
                    UseColumnTextForButtonValue = true,
                    Width = 90
                });

                dgvClientes.CellClick += DgvClientes_CellClick;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPeso.Text, out decimal peso) ||
                !decimal.TryParse(txtAltura.Text, out decimal altura))
            {
                Msg("Peso o altura no válidos.");
                return;
            }

            _controller.CrearCliente(
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                dtpFechaNacimiento.Value,
                peso,
                altura,
                txtObjetivo.Text.Trim()
            );

            CargarClientes();
            Limpiar();
            Msg("Cliente agregado correctamente.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                Msg("Seleccione un cliente.");
                return;
            }

            int id = (int)dgvClientes.CurrentRow.Cells["IdCliente"].Value;
            var cliente = _controller.BuscarPorId(id);

            if (!decimal.TryParse(txtPeso.Text, out decimal peso) ||
                !decimal.TryParse(txtAltura.Text, out decimal altura))
            {
                Msg("Peso o altura inválidos.");
                return;
            }

            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Apellido = txtApellido.Text.Trim();
            cliente.FechaNacimiento = dtpFechaNacimiento.Value;
            cliente.Peso = peso;
            cliente.Altura = altura;
            cliente.Objetivo = txtObjetivo.Text.Trim();

            _controller.ActualizarCliente(cliente);
            CargarClientes();
            Msg("Cliente modificado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                Msg("Seleccione un cliente.");
                return;
            }

            int id = (int)dgvClientes.CurrentRow.Cells["IdCliente"].Value;

            if (!Confirm("¿Está seguro de eliminar este cliente?")) return;

            _controller.EliminarCliente(id);
            CargarClientes();
            Msg("Cliente eliminado correctamente.");
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvClientes.Columns[e.ColumnIndex].Name != "btnVerRutinas")
                return;

            if (!dgvClientes.Columns.Contains("IdCliente"))
                return;

            int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value);

            var cliente = _controller.BuscarPorId(id);
            if (cliente == null) return;

            new FormRutinasCliente(cliente)
            {
                StartPosition = FormStartPosition.CenterParent
            }.ShowDialog();

            CargarClientes();
        }


        private static int CalcularEdad(DateTime fecha)
        {
            int edad = DateTime.Today.Year - fecha.Year;
            if (fecha > DateTime.Today.AddYears(-edad)) edad--;
            return edad;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtPeso.Clear();
            txtAltura.Clear();
            txtObjetivo.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
        }

        private static void Msg(string t) =>
            MessageBox.Show(t, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static bool Confirm(string t) =>
            MessageBox.Show(t, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }
}
