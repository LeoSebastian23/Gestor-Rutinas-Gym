namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormClientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelCampos = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblFecha = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblPeso = new Label();
            txtPeso = new TextBox();
            lblAltura = new Label();
            txtAltura = new TextBox();
            lblObjetivo = new Label();
            txtObjetivo = new TextBox();

            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            dgvClientes = new DataGridView();

            // --- FORMULARIO PRINCIPAL ---
            SuspendLayout();
            ClientSize = new Size(1000, 650);
            BackColor = Color.FromArgb(30, 30, 30);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            Load += FormClientes_Load;

            // --- TÍTULO ---
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Text = "Gestión de Clientes";
            lblTitulo.Height = 60;
            lblTitulo.BackColor = Color.FromArgb(40, 40, 40);

            // --- PANEL DE CAMPOS ---
            panelCampos.Location = new Point(30, 80);
            panelCampos.Size = new Size(940, 160);
            panelCampos.BackColor = Color.FromArgb(45, 45, 45);
            panelCampos.BorderStyle = BorderStyle.None;

            int labelW = 100, inputW = 200, inputH = 28;
            int startX = 20, startY = 20, spacingX = 300, spacingY = 40;

            // --- NOMBRE ---
            lblNombre.Text = "Nombre:";
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(startX, startY);
            lblNombre.Size = new Size(labelW, 25);
            txtNombre.Location = new Point(startX + labelW, startY);
            txtNombre.Size = new Size(inputW, inputH);

            // --- APELLIDO ---
            lblApellido.Text = "Apellido:";
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(startX + spacingX, startY);
            lblApellido.Size = new Size(labelW, 25);
            txtApellido.Location = new Point(startX + spacingX + labelW, startY);
            txtApellido.Size = new Size(inputW, inputH);

            // --- FECHA NACIMIENTO ---
            lblFecha.Text = "Nacimiento:";
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(startX, startY + spacingY);
            lblFecha.Size = new Size(labelW, 25);
            dtpFechaNacimiento.Location = new Point(startX + labelW, startY + spacingY);
            dtpFechaNacimiento.Size = new Size(inputW, inputH);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;

            // --- PESO ---
            lblPeso.Text = "Peso (kg):";
            lblPeso.ForeColor = Color.White;
            lblPeso.Location = new Point(startX + spacingX, startY + spacingY);
            lblPeso.Size = new Size(labelW, 25);
            txtPeso.Location = new Point(startX + spacingX + labelW, startY + spacingY);
            txtPeso.Size = new Size(inputW, inputH);

            // --- ALTURA ---
            lblAltura.Text = "Altura (m):";
            lblAltura.ForeColor = Color.White;
            lblAltura.Location = new Point(startX, startY + spacingY * 2);
            lblAltura.Size = new Size(labelW, 25);
            txtAltura.Location = new Point(startX + labelW, startY + spacingY * 2);
            txtAltura.Size = new Size(inputW, inputH);

            // --- OBJETIVO ---
            lblObjetivo.Text = "Objetivo:";
            lblObjetivo.ForeColor = Color.White;
            lblObjetivo.Location = new Point(startX + spacingX, startY + spacingY * 2);
            lblObjetivo.Size = new Size(labelW, 25);
            txtObjetivo.Location = new Point(startX + spacingX + labelW, startY + spacingY * 2);
            txtObjetivo.Size = new Size(inputW, inputH);

            panelCampos.Controls.AddRange(new Control[]
            {
                lblNombre, txtNombre,
                lblApellido, txtApellido,
                lblFecha, dtpFechaNacimiento,
                lblPeso, txtPeso,
                lblAltura, txtAltura,
                lblObjetivo, txtObjetivo
            });

            // --- BOTONES ---
            int btnW = 150, btnH = 38, btnY = 260;
            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new Point(30, btnY);
            btnAgregar.Size = new Size(btnW, btnH);
            btnAgregar.Click += btnAgregar_Click;

            btnModificar.Text = "Modificar";
            btnModificar.Location = new Point(200, btnY);
            btnModificar.Size = new Size(btnW, btnH);
            btnModificar.Click += btnModificar_Click;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(370, btnY);
            btnEliminar.Size = new Size(btnW, btnH);
            btnEliminar.Click += btnEliminar_Click;

            // --- DATAGRID ---
            dgvClientes.Location = new Point(30, 320);
            dgvClientes.Size = new Size(940, 280);
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.FromArgb(25, 25, 25);

            // --- AGREGAR TODO AL FORM ---
            Controls.AddRange(new Control[]
            {
                lblTitulo,
                panelCampos,
                btnAgregar,
                btnModificar,
                btnEliminar,
                dgvClientes
            });

            ResumeLayout(false);
        }

        private Label lblTitulo;
        private Panel panelCampos;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblFecha;
        private Label lblPeso;
        private Label lblAltura;
        private Label lblObjetivo;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtPeso;
        private TextBox txtAltura;
        private TextBox txtObjetivo;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridView dgvClientes;
    }
}



