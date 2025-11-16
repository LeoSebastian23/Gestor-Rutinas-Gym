namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormRutinasCliente
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Panel panelSuperior;
        private Panel panelInferior;
        private ComboBox cmbRutinasDisponibles;
        private Button btnAsignarRutina;
        private Button btnEliminarRutina;
        private DataGridView dgvRutinasAsignadas;
        private Button btnExportarPDF;
        private Button btnExportarExcel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelSuperior = new Panel();
            cmbRutinasDisponibles = new ComboBox();
            btnAsignarRutina = new Button();
            btnEliminarRutina = new Button();
            panelInferior = new Panel();
            dgvRutinasAsignadas = new DataGridView();
            btnExportarPDF = new Button();
            btnExportarExcel = new Button();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRutinasAsignadas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(45, 45, 45);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(800, 60);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Rutinas del Cliente";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
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
            panelSuperior.TabIndex = 3;
            // 
            // cmbRutinasDisponibles
            // 
            cmbRutinasDisponibles.Location = new Point(10, 25);
            cmbRutinasDisponibles.Name = "cmbRutinasDisponibles";
            cmbRutinasDisponibles.Size = new Size(250, 28);
            cmbRutinasDisponibles.TabIndex = 0;
            // 
            // btnAsignarRutina
            // 
            btnAsignarRutina.BackColor = Color.FromArgb(46, 204, 113);
            btnAsignarRutina.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAsignarRutina.Location = new Point(270, 25);
            btnAsignarRutina.Name = "btnAsignarRutina";
            btnAsignarRutina.Size = new Size(150, 32);
            btnAsignarRutina.TabIndex = 1;
            btnAsignarRutina.Text = "➕ Asignar";
            btnAsignarRutina.UseVisualStyleBackColor = false;
            btnAsignarRutina.Click += btnAsignarRutina_Click;
            // 
            // btnEliminarRutina
            // 
            btnEliminarRutina.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminarRutina.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminarRutina.Location = new Point(430, 25);
            btnEliminarRutina.Name = "btnEliminarRutina";
            btnEliminarRutina.Size = new Size(120, 32);
            btnEliminarRutina.TabIndex = 2;
            btnEliminarRutina.Text = "🗑 Eliminar";
            btnEliminarRutina.UseVisualStyleBackColor = false;
            btnEliminarRutina.Click += btnEliminarRutina_Click;
            // 
            // panelInferior
            // 
            panelInferior.Controls.Add(dgvRutinasAsignadas);
            panelInferior.Dock = DockStyle.Fill;
            panelInferior.Location = new Point(0, 140);
            panelInferior.Name = "panelInferior";
            panelInferior.Padding = new Padding(10);
            panelInferior.Size = new Size(800, 460);
            panelInferior.TabIndex = 2;
            // 
            // dgvRutinasAsignadas
            // 
            dgvRutinasAsignadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutinasAsignadas.ColumnHeadersHeight = 29;
            dgvRutinasAsignadas.Dock = DockStyle.Fill;
            dgvRutinasAsignadas.Location = new Point(10, 10);
            dgvRutinasAsignadas.Name = "dgvRutinasAsignadas";
            dgvRutinasAsignadas.RowHeadersVisible = false;
            dgvRutinasAsignadas.RowHeadersWidth = 51;
            dgvRutinasAsignadas.Size = new Size(780, 440);
            dgvRutinasAsignadas.TabIndex = 0;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.FromArgb(15, 146, 140);
            btnExportarPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportarPDF.Location = new Point(10, 520);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(154, 40);
            btnExportarPDF.TabIndex = 0;
            btnExportarPDF.Text = "📄 Exportar PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.FromArgb(0, 100, 101);
            btnExportarExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportarExcel.Location = new Point(170, 520);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(174, 40);
            btnExportarExcel.TabIndex = 1;
            btnExportarExcel.Text = "📊 Exportar Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // FormRutinasCliente
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 600);
            Controls.Add(btnExportarPDF);
            Controls.Add(btnExportarExcel);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            Controls.Add(lblTitulo);
            Name = "FormRutinasCliente";
            panelSuperior.ResumeLayout(false);
            panelInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRutinasAsignadas).EndInit();
            ResumeLayout(false);
        }
    }
}
