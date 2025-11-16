namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormListadoRutinas
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnVerDias;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnCerrar;
        private Button btnExportarPDF;
        private Button btnExportarExcel;
        private DataGridView dgvRutinas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnVerDias = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            btnExportarPDF = new Button();
            btnExportarExcel = new Button();
            dgvRutinas = new DataGridView();
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
            dgvRutinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutinas.Location = new Point(30, 80);
            dgvRutinas.Name = "dgvRutinas";
            dgvRutinas.ReadOnly = true;
            dgvRutinas.RowHeadersWidth = 51;
            dgvRutinas.Size = new Size(840, 340);
            dgvRutinas.TabIndex = 1;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.FromArgb(15, 146, 140);
            btnExportarPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportarPDF.Location = new Point(30, 430);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(120, 40);
            btnExportarPDF.TabIndex = 2;
            btnExportarPDF.Text = "📄 PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.FromArgb(0, 100, 101);
            btnExportarExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportarExcel.Location = new Point(170, 430);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(120, 40);
            btnExportarExcel.TabIndex = 3;
            btnExportarExcel.Text = "📊 Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // btnVerDias
            // 
            btnVerDias.Font = new Font("Segoe UI", 12F);
            btnVerDias.Location = new Point(30, 480);
            btnVerDias.Name = "btnVerDias";
            btnVerDias.Size = new Size(248, 60);
            btnVerDias.TabIndex = 4;
            btnVerDias.Text = "Ver Días / Ejercicios";
            btnVerDias.Click += btnVerDias_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(494, 480);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(154, 60);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(654, 480);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 60);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 12F);
            btnCerrar.Location = new Point(790, 480);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(80, 60);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormListadoRutinas
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(900, 600);
            Controls.Add(lblTitulo);
            Controls.Add(dgvRutinas);
            Controls.Add(btnExportarPDF);
            Controls.Add(btnExportarExcel);
            Controls.Add(btnVerDias);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCerrar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de Rutinas";
            Load += FormListadoRutinas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).EndInit();
            ResumeLayout(false);
        }
    }
}
