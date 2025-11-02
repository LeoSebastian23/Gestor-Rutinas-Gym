namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormRutinasCliente
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private DataGridView dgvRutinasAsignadas;
        private ComboBox cmbRutinasDisponibles;
        private Button btnAsignarRutina;
        private Button btnEliminarRutina;
        private Panel panelSuperior;
        private Panel panelInferior;

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
            dgvRutinasAsignadas = new DataGridView();
            cmbRutinasDisponibles = new ComboBox();
            btnAsignarRutina = new Button();
            btnEliminarRutina = new Button();
            panelSuperior = new Panel();
            panelInferior = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvRutinasAsignadas).BeginInit();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(45, 45, 45);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(800, 60);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Rutinas de Cliente";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvRutinasAsignadas
            // 
            dgvRutinasAsignadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutinasAsignadas.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgvRutinasAsignadas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRutinasAsignadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRutinasAsignadas.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRutinasAsignadas.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRutinasAsignadas.Dock = DockStyle.Fill;
            dgvRutinasAsignadas.EnableHeadersVisualStyles = false;
            dgvRutinasAsignadas.Font = new Font("Segoe UI", 10F);
            dgvRutinasAsignadas.GridColor = Color.DimGray;
            dgvRutinasAsignadas.Location = new Point(10, 10);
            dgvRutinasAsignadas.Name = "dgvRutinasAsignadas";
            dgvRutinasAsignadas.RowHeadersVisible = false;
            dgvRutinasAsignadas.RowHeadersWidth = 51;
            dgvRutinasAsignadas.Size = new Size(780, 440);
            dgvRutinasAsignadas.TabIndex = 0;
            // 
            // cmbRutinasDisponibles
            // 
            cmbRutinasDisponibles.BackColor = Color.FromArgb(50, 50, 50);
            cmbRutinasDisponibles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRutinasDisponibles.Font = new Font("Segoe UI", 10F);
            cmbRutinasDisponibles.ForeColor = Color.White;
            cmbRutinasDisponibles.Location = new Point(10, 25);
            cmbRutinasDisponibles.Name = "cmbRutinasDisponibles";
            cmbRutinasDisponibles.Size = new Size(250, 31);
            cmbRutinasDisponibles.TabIndex = 0;
            // 
            // btnAsignarRutina
            // 
            btnAsignarRutina.BackColor = Color.FromArgb(46, 204, 113);
            btnAsignarRutina.FlatAppearance.BorderSize = 0;
            btnAsignarRutina.FlatStyle = FlatStyle.Flat;
            btnAsignarRutina.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAsignarRutina.ForeColor = Color.White;
            btnAsignarRutina.Location = new Point(280, 25);
            btnAsignarRutina.Name = "btnAsignarRutina";
            btnAsignarRutina.Size = new Size(191, 31);
            btnAsignarRutina.TabIndex = 1;
            btnAsignarRutina.Text = "➕ Asignar Rutina";
            btnAsignarRutina.UseVisualStyleBackColor = false;
            btnAsignarRutina.Click += btnAsignarRutina_Click;
            // 
            // btnEliminarRutina
            // 
            btnEliminarRutina.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminarRutina.FlatAppearance.BorderSize = 0;
            btnEliminarRutina.FlatStyle = FlatStyle.Flat;
            btnEliminarRutina.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminarRutina.ForeColor = Color.White;
            btnEliminarRutina.Location = new Point(496, 25);
            btnEliminarRutina.Name = "btnEliminarRutina";
            btnEliminarRutina.Size = new Size(152, 31);
            btnEliminarRutina.TabIndex = 2;
            btnEliminarRutina.Text = "🗑️ Eliminar";
            btnEliminarRutina.UseVisualStyleBackColor = false;
            btnEliminarRutina.Click += btnEliminarRutina_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(40, 40, 40);
            panelSuperior.Controls.Add(cmbRutinasDisponibles);
            panelSuperior.Controls.Add(btnAsignarRutina);
            panelSuperior.Controls.Add(btnEliminarRutina);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 60);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Padding = new Padding(10);
            panelSuperior.Size = new Size(800, 80);
            panelSuperior.TabIndex = 1;
            // 
            // panelInferior
            // 
            panelInferior.Controls.Add(dgvRutinasAsignadas);
            panelInferior.Dock = DockStyle.Fill;
            panelInferior.Location = new Point(0, 140);
            panelInferior.Name = "panelInferior";
            panelInferior.Padding = new Padding(10);
            panelInferior.Size = new Size(800, 460);
            panelInferior.TabIndex = 0;
            // 
            // FormRutinasCliente
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 600);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormRutinasCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rutinas del Cliente";
            ((System.ComponentModel.ISupportInitialize)dgvRutinasAsignadas).EndInit();
            panelSuperior.ResumeLayout(false);
            panelInferior.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

