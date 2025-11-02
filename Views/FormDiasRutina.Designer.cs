namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormDiasRutina
    {
        private DataGridView dgvDias;

        private void InitializeComponent()
        {
            this.dgvDias = new DataGridView();
            this.SuspendLayout();

            this.ClientSize = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Días de Entrenamiento";

            dgvDias.Dock = DockStyle.Fill;
            dgvDias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDias.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvDias.DefaultCellStyle.ForeColor = Color.White;
            dgvDias.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvDias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvDias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDias.EnableHeadersVisualStyles = false;

            this.Controls.Add(dgvDias);
            this.ResumeLayout(false);
        }
    }
}