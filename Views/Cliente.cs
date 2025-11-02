using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestor_de_Rutinas___GYM.Controllers;
using Gestor_de_Rutinas___GYM.Models;

namespace Gestor_de_Rutinas___GYM.Views
{
    public partial class FormClientes : Form
    {
        private readonly ClienteController _controller = new();

        public FormClientes()
        {
            InitializeComponent();
            // Todo lo “custom” lo hacemos fuera del diseñador:
            PostInitStyleSafe();
        }

        private void PostInitStyleSafe()
        {
            // Colores y estilo
            this.BackColor = Color.FromArgb(30, 30, 30);

            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.BackColor = Color.FromArgb(40, 40, 40);

            panelCampos.BackColor = Color.FromArgb(45, 45, 45);

            // Botones
            StyleButtonFlat(btnAgregar, Color.FromArgb(46, 204, 113));
            StyleButtonFlat(btnVerTodos, Color.FromArgb(52, 152, 219));
            StyleButtonFlat(btnVerDetalle, Color.FromArgb(231, 76, 60));

            // Labels
            foreach (Control c in panelCampos.Controls)
            {
                if (c is Label l) l.ForeColor = Color.White;
            }

            // DataGridView moderno
            dgvClientes.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvClientes.DefaultCellStyle.ForeColor = Color.White;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.GridColor = Color.DimGray;
            dgvClientes.Font = new Font("Segoe UI", 10);
        }

        private static void StyleButtonFlat(Button b, Color back)
        {
            b.BackColor = back;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private async void FormClientes_Load(object sender, EventArgs e)
        {
            await CargarClientesAsync();

            // Evita columnas duplicadas si ya existen
            if (!dgvClientes.Columns.Contains("btnVerRutinas"))
            {
                var colRutinas = new DataGridViewButtonColumn
                {
                    Name = "btnVerRutinas",
                    HeaderText = "Rutinas",
                    Text = "Ver Rutinas",
                    UseColumnTextForButtonValue = true,
                    Width = 120,
                };

                dgvClientes.Columns.Add(colRutinas);
                dgvClientes.CellClick += DgvClientes_CellClick;

                // 💅 Aplicamos un estilo visual moderno al botón
                dgvClientes.CellFormatting += (s, e) =>
                {
                    if (dgvClientes.Columns[e.ColumnIndex].Name == "btnVerRutinas")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(46, 204, 113);
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
                    }
                };
            }
        }

        private async Task CargarClientesAsync()
        {
            dgvClientes.DataSource = await _controller.ObtenerClientesAsync();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var nombre = txtNombre.Text.Trim();
                var apellido = txtApellido.Text.Trim();
                var fecha = dtpFechaNacimiento.Value.Date; // solo fecha
                var peso = decimal.Parse(txtPeso.Text);
                var altura = decimal.Parse(txtAltura.Text);
                var objetivo = txtObjetivo.Text.Trim();

                await _controller.CrearClienteAsync(nombre, apellido, fecha, peso, altura, objetivo);
                await CargarClientesAsync();
                LimpiarCampos();

                MessageBox.Show("Cliente agregado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtPeso.Clear();
            txtAltura.Clear();
            txtObjetivo.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
        }

        private async void btnVerTodos_Click(object sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            MessageBox.Show(
                $"Cliente: {cliente.Nombre} {cliente.Apellido}\n" +
                $"Edad: {DateTime.Today.Year - cliente.FechaNacimiento.Year} años\n" +
                $"Peso: {cliente.Peso} kg\n" +
                $"Altura: {cliente.Altura} m\n" +
                $"Objetivo: {cliente.Objetivo}",
                "Detalle de Cliente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "btnVerRutinas")
            {
                // Obtenemos el cliente actual
                if (dgvClientes.Rows[e.RowIndex].DataBoundItem is Cliente clienteSeleccionado)
                {
                    using (var formRutinas = new FormRutinasCliente(clienteSeleccionado))
                    {
                        formRutinas.ShowDialog(); // abre modal
                    }

                    // Refresca la grilla al cerrar el modal
                    _ = CargarClientesAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el cliente seleccionado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
