namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormRutinaEdicion
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private NumericUpDown numDuracion;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblDuracion;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            numDuracion = new NumericUpDown();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblDuracion = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
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
            lblTitulo.Size = new Size(500, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Editar Rutina";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 80);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(320, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(130, 133);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(320, 27);
            txtDescripcion.TabIndex = 4;
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(130, 186);
            numDuracion.Maximum = new decimal(new int[] { 52, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(80, 27);
            numDuracion.TabIndex = 6;
            numDuracion.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(30, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(30, 133);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 23);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblDuracion
            // 
            lblDuracion.Location = new Point(30, 186);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(100, 23);
            lblDuracion.TabIndex = 5;
            lblDuracion.Text = "Semanas:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(350, 246);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 40);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(130, 246);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 40);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormRutinaEdicion
            // 
            ClientSize = new Size(500, 350);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDuracion);
            Controls.Add(numDuracion);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "FormRutinaEdicion";
            Text = "Editar Rutina";
            Load += FormRutinaEdicion_Load;
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
