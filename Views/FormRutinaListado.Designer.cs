namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormListadoRutinas
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private DataGridView dgvRutinas;
        private Button btnVerDetalle;
        private Button btnVerDias;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvRutinas = new DataGridView();
            btnVerDetalle = new Button();
            btnVerDias = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(900, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Rutinas";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvRutinas
            // 
            dgvRutinas.AllowUserToAddRows = false;
            dgvRutinas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRutinas.ColumnHeadersHeight = 29;
            dgvRutinas.Location = new Point(30, 80);
            dgvRutinas.Name = "dgvRutinas";
            dgvRutinas.ReadOnly = true;
            dgvRutinas.RowHeadersWidth = 51;
            dgvRutinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutinas.Size = new Size(840, 380);
            dgvRutinas.TabIndex = 1;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(0, 0);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(75, 23);
            btnVerDetalle.TabIndex = 2;
            // 
            // btnVerDias
            // 
            btnVerDias.Font = new Font("Segoe UI", 12F);
            btnVerDias.Location = new Point(30, 480);
            btnVerDias.Name = "btnVerDias";
            btnVerDias.Size = new Size(248, 60);
            btnVerDias.TabIndex = 3;
            btnVerDias.Text = "Ver Días / Ejercicios";
            btnVerDias.Click += btnVerDias_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(494, 480);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(154, 60);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(654, 480);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 60);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 12F);
            btnCerrar.Location = new Point(790, 480);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(80, 60);
            btnCerrar.TabIndex = 6;
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormListadoRutinas
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(900, 600);
            Controls.Add(lblTitulo);
            Controls.Add(dgvRutinas);
            Controls.Add(btnVerDetalle);
            Controls.Add(btnVerDias);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCerrar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormListadoRutinas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Listado de Rutinas";
            Load += FormListadoRutinas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).EndInit();
            ResumeLayout(false);
        }
    }
}
