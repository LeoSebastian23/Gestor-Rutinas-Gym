using System;
using System.Drawing;
using System.Linq;
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
            AplicarEstilo();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            ConfigurarColumnaRutinas();
        }

        // ≡ ESTILO ==============================================================
        private void AplicarEstilo()
        {
            BackColor = ColorTranslator.FromHtml("#484848");
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new("Segoe UI", 18, FontStyle.Bold);

            panelCampos.BackColor = Color.FromArgb(45, 45, 45);
            panelCampos.Controls.OfType<Label>().ToList()
                .ForEach(l => l.ForeColor = Color.White);

            ConfigurarBoton(btnAgregar, "#0f928c");
            ConfigurarBoton(btnModificar, "#00c9d2");
            ConfigurarBoton(btnEliminar, "#beee3b", Color.Black);

            ConfigurarGrid(dgvClientes);
        }

        private static void ConfigurarBoton(Button btn, string color, Color? texto = null)
        {
            btn.BackColor = ColorTranslator.FromHtml(color);
            btn.ForeColor = texto ?? Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private static void ConfigurarGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f928c");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ReadOnly = true;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ≡ DATOS ===============================================================
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

            // Asegura que la columna del botón exista una sola vez
            if (!dgvClientes.Columns.Contains("btnVerRutinas"))
                ConfigurarColumnaRutinas();

            dgvClientes.Columns["IdCliente"].Visible = false;
        }



        private void ConfigurarColumnaRutinas()
        {
            if (dgvClientes.Columns.Contains("btnVerRutinas")) return;

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

        // ≡ VALIDACIÓN =========================================================
        private bool SeleccionInvalida(string msj)
        {
            if (dgvClientes.CurrentRow == null)
            {
                Msg(msj);
                return true;
            }
            return false;
        }

        private bool IntentarParseDecimal(TextBox txt, string campo, out decimal valor)
        {
            if (!decimal.TryParse(txt.Text, out valor))
            {
                Msg($"El valor de {campo} no es válido.");
                return false;
            }
            return true;
        }

        // ≡ CRUD ===============================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!IntentarParseDecimal(txtPeso, "Peso", out decimal peso)) return;
            if (!IntentarParseDecimal(txtAltura, "Altura", out decimal altura)) return;

            try
            {
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
                Msg("Cliente agregado correctamente ✅");
            }
            catch (Exception ex)
            {
                Msg($"Error al agregar: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (SeleccionInvalida("Seleccione un cliente para modificar.")) return;

            int id = (int)dgvClientes.CurrentRow.Cells["IdCliente"].Value;
            var cliente = _controller.BuscarPorId(id);
            if (cliente == null) return;

            if (!IntentarParseDecimal(txtPeso, "Peso", out decimal peso)) return;
            if (!IntentarParseDecimal(txtAltura, "Altura", out decimal altura)) return;

            try
            {
                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Apellido = txtApellido.Text.Trim();
                cliente.FechaNacimiento = dtpFechaNacimiento.Value;
                cliente.Peso = peso;
                cliente.Altura = altura;
                cliente.Objetivo = txtObjetivo.Text.Trim();

                _controller.ActualizarCliente(cliente);
                CargarClientes();

                Msg("Cliente modificado correctamente ✅");
            }
            catch (Exception ex)
            {
                Msg($"Error al modificar: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (SeleccionInvalida("Seleccione un cliente para eliminar.")) return;

            int id = (int)dgvClientes.CurrentRow.Cells["IdCliente"].Value;
            if (!Confirm("¿Está seguro de eliminar este cliente?")) return;

            _controller.EliminarCliente(id);
            CargarClientes();

            Msg("Cliente eliminado correctamente ✅");
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (SeleccionInvalida("Seleccione un cliente.")) return;

            int id = (int)dgvClientes.CurrentRow.Cells["IdCliente"].Value;
            var c = _controller.BuscarPorId(id);
            if (c == null) return;

            Msg($"👤 {c.Nombre} {c.Apellido}\n" +
                $"Edad: {CalcularEdad(c.FechaNacimiento)} años\n" +
                $"Peso: {c.Peso} kg\n" +
                $"Altura: {c.Altura} m\n" +
                $"Objetivo: {c.Objetivo}",
                "Detalle de Cliente");
        }

        private void btnVerTodos_Click(object sender, EventArgs e) => CargarClientes();


        // ≡ EVENTOS EXTRA ======================================================
        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evita clics inválidos
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Verifica si la columna del botón existe antes de acceder
            var columna = dgvClientes.Columns[e.ColumnIndex];
            if (columna == null || columna.Name != "btnVerRutinas") return;

            // Asegura que haya datos en la fila
            if (e.RowIndex >= dgvClientes.Rows.Count) return;

            // Recupera el IdCliente de forma segura
            var fila = dgvClientes.Rows[e.RowIndex];
            if (!fila.Cells.Contains(fila.Cells["IdCliente"])) return;

            int id = Convert.ToInt32(fila.Cells["IdCliente"].Value);
            var cliente = _controller.BuscarPorId(id);
            if (cliente == null) return;

            using var form = new FormRutinasCliente(cliente)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            form.ShowDialog(this);

            CargarClientes(); // refresca la grilla
        }



        // ≡ HELPERS ============================================================
        private static int CalcularEdad(DateTime fecha)
        {
            int edad = DateTime.Today.Year - fecha.Year;
            if (fecha > DateTime.Today.AddYears(-edad)) edad--;
            return edad;
        }

        private void Limpiar()
        {
            foreach (var t in new[] { txtNombre, txtApellido, txtPeso, txtAltura, txtObjetivo })
                t.Clear();

            dtpFechaNacimiento.Value = DateTime.Today;
        }

        private static void Msg(string texto, string titulo = "Aviso", MessageBoxIcon icono = MessageBoxIcon.Information)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, icono);
        }

        private static bool Confirm(string txt)
        {
            return MessageBox.Show(txt, "Confirmar", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}