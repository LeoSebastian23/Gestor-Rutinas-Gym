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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            panelCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1000, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Clientes";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCampos
            // 
            panelCampos.BackColor = Color.FromArgb(45, 45, 45);
            panelCampos.Controls.Add(lblNombre);
            panelCampos.Controls.Add(txtNombre);
            panelCampos.Controls.Add(lblApellido);
            panelCampos.Controls.Add(txtApellido);
            panelCampos.Controls.Add(lblFecha);
            panelCampos.Controls.Add(dtpFechaNacimiento);
            panelCampos.Controls.Add(lblPeso);
            panelCampos.Controls.Add(txtPeso);
            panelCampos.Controls.Add(lblAltura);
            panelCampos.Controls.Add(txtAltura);
            panelCampos.Controls.Add(lblObjetivo);
            panelCampos.Controls.Add(txtObjetivo);
            panelCampos.Location = new Point(30, 80);
            panelCampos.Name = "panelCampos";
            panelCampos.Size = new Size(940, 180);
            panelCampos.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(30, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(131, 20);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            lblApellido.ForeColor = Color.White;
            lblApellido.Location = new Point(500, 20);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(70, 25);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(591, 20);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(220, 27);
            txtApellido.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(30, 65);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(95, 25);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(131, 60);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(220, 27);
            dtpFechaNacimiento.TabIndex = 5;
            dtpFechaNacimiento.UseWaitCursor = true;
            // 
            // lblPeso
            // 
            lblPeso.ForeColor = Color.White;
            lblPeso.Location = new Point(500, 65);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(85, 25);
            lblPeso.TabIndex = 6;
            lblPeso.Text = "Peso (kg):";
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(591, 62);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(220, 27);
            txtPeso.TabIndex = 7;
            // 
            // lblAltura
            // 
            lblAltura.ForeColor = Color.White;
            lblAltura.Location = new Point(30, 110);
            lblAltura.Name = "lblAltura";
            lblAltura.Size = new Size(86, 25);
            lblAltura.TabIndex = 8;
            lblAltura.Text = "Altura (m):";
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(131, 107);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(220, 27);
            txtAltura.TabIndex = 9;
            // 
            // lblObjetivo
            // 
            lblObjetivo.ForeColor = Color.White;
            lblObjetivo.Location = new Point(500, 110);
            lblObjetivo.Name = "lblObjetivo";
            lblObjetivo.Size = new Size(70, 25);
            lblObjetivo.TabIndex = 10;
            lblObjetivo.Text = "Objetivo:";
            // 
            // txtObjetivo
            // 
            txtObjetivo.Location = new Point(591, 110);
            txtObjetivo.Name = "txtObjetivo";
            txtObjetivo.Size = new Size(220, 27);
            txtObjetivo.TabIndex = 11;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(0, 0);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(0, 0);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(0, 0);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgvClientes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 146, 140);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.Location = new Point(30, 320);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(940, 280);
            dgvClientes.TabIndex = 5;
            // 
            // FormClientes
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1000, 650);
            Controls.Add(lblTitulo);
            Controls.Add(panelCampos);
            Controls.Add(btnAgregar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvClientes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            Load += FormClientes_Load;
            panelCampos.ResumeLayout(false);
            panelCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }

        // Helper interno para botones
        private void ConfigurarBoton(Button btn, string txt, string color, int x, int y, int w, int h, Color? textColor = null)
        {
            btn.Text = txt;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.BackColor = ColorTranslator.FromHtml(color);
            btn.ForeColor = textColor ?? Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
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
