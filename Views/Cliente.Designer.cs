using System.Drawing;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormClientes
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Panel panelCampos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblPeso;
        private TextBox txtPeso;
        private Label lblAltura;
        private TextBox txtAltura;
        private Label lblObjetivo;
        private TextBox txtObjetivo;
        private Button btnAgregar;
        private Button btnVerTodos;
        private Button btnVerDetalle;
        private DataGridView dgvClientes;

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
            lblNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblPeso = new Label();
            txtPeso = new TextBox();
            lblAltura = new Label();
            txtAltura = new TextBox();
            lblObjetivo = new Label();
            txtObjetivo = new TextBox();
            btnAgregar = new Button();
            btnVerTodos = new Button();
            btnVerDetalle = new Button();
            dgvClientes = new DataGridView();
            panelCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1000, 70);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Clientes";
            // 
            // panelCampos
            // 
            panelCampos.Controls.Add(lblNombre);
            panelCampos.Controls.Add(txtNombre);
            panelCampos.Controls.Add(lblApellido);
            panelCampos.Controls.Add(txtApellido);
            panelCampos.Controls.Add(lblNacimiento);
            panelCampos.Controls.Add(dtpFechaNacimiento);
            panelCampos.Controls.Add(lblPeso);
            panelCampos.Controls.Add(txtPeso);
            panelCampos.Controls.Add(lblAltura);
            panelCampos.Controls.Add(txtAltura);
            panelCampos.Controls.Add(lblObjetivo);
            panelCampos.Controls.Add(txtObjetivo);
            panelCampos.Controls.Add(btnAgregar);
            panelCampos.Controls.Add(btnVerTodos);
            panelCampos.Controls.Add(btnVerDetalle);
            panelCampos.Dock = DockStyle.Top;
            panelCampos.Location = new Point(0, 70);
            panelCampos.Name = "panelCampos";
            panelCampos.Size = new Size(1000, 140);
            panelCampos.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(96, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(122, 20);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(140, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            lblApellido.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellido.Location = new Point(22, 60);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(94, 23);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(122, 60);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(140, 27);
            txtApellido.TabIndex = 3;
            // 
            // lblNacimiento
            // 
            lblNacimiento.Font = new Font("Segoe UI", 11F);
            lblNacimiento.Location = new Point(570, 29);
            lblNacimiento.Name = "lblNacimiento";
            lblNacimiento.Size = new Size(248, 32);
            lblNacimiento.TabIndex = 4;
            lblNacimiento.Text = "Nacimiento:  (Calcula Edad)";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(608, 62);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(168, 27);
            dtpFechaNacimiento.TabIndex = 5;
            // 
            // lblPeso
            // 
            lblPeso.Font = new Font("Segoe UI", 10.8F);
            lblPeso.Location = new Point(314, 22);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(103, 39);
            lblPeso.TabIndex = 6;
            lblPeso.Text = "Peso (kg):";
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(423, 20);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(114, 27);
            txtPeso.TabIndex = 7;
            // 
            // lblAltura
            // 
            lblAltura.Font = new Font("Segoe UI", 10.8F);
            lblAltura.Location = new Point(300, 64);
            lblAltura.Name = "lblAltura";
            lblAltura.Size = new Size(117, 40);
            lblAltura.TabIndex = 8;
            lblAltura.Text = "Altura (cm):";
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(423, 64);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(114, 27);
            txtAltura.TabIndex = 9;
            // 
            // lblObjetivo
            // 
            lblObjetivo.Location = new Point(24, 108);
            lblObjetivo.Name = "lblObjetivo";
            lblObjetivo.Size = new Size(76, 23);
            lblObjetivo.TabIndex = 10;
            lblObjetivo.Text = "Objetivo:";
            // 
            // txtObjetivo
            // 
            txtObjetivo.Location = new Point(104, 107);
            txtObjetivo.Name = "txtObjetivo";
            txtObjetivo.Size = new Size(738, 27);
            txtObjetivo.TabIndex = 11;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(848, 15);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 30);
            btnAgregar.TabIndex = 100;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnVerTodos
            // 
            btnVerTodos.Location = new Point(848, 50);
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.Size = new Size(120, 30);
            btnVerTodos.TabIndex = 101;
            btnVerTodos.Text = "Ver Todos";
            btnVerTodos.Click += btnVerTodos_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(848, 85);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(120, 30);
            btnVerDetalle.TabIndex = 102;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ColumnHeadersHeight = 29;
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.Location = new Point(0, 210);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(1000, 390);
            dgvClientes.TabIndex = 2;
            // 
            // FormClientes
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvClientes);
            Controls.Add(panelCampos);
            Controls.Add(lblTitulo);
            Name = "FormClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Clientes";
            Load += FormClientes_Load;
            panelCampos.ResumeLayout(false);
            panelCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }
    }
}

