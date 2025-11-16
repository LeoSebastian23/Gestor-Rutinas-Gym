namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormRutina
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDuracion;
        private NumericUpDown numDuracionSemana;
        private TextBox txtDescripcion;
        private Button btnCrearRutina;
        private Button btnGuardarRutina;
        private Button btnAgregarDia;
        private ComboBox cmbDiaSemana;
        private TextBox txtGrupoMuscular;
        private DataGridView dgvDias;
        private DataGridView dgvEjercicios;
        private Button btnAgregarEjercicio;
        private NumericUpDown numSeries;
        private NumericUpDown numReps;
        private NumericUpDown numDescanso;
        private TextBox txtNotas;
        private SplitContainer splitContainer;
        private ComboBox cmbEjercicioBase;
        private Button btnNuevoEjercicioBase;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDuracion = new Label();
            numDuracionSemana = new NumericUpDown();
            txtDescripcion = new TextBox();
            btnCrearRutina = new Button();
            btnNuevoEjercicioBase = new Button();
            btnGuardarRutina = new Button();
            btnAgregarDia = new Button();
            cmbDiaSemana = new ComboBox();
            txtGrupoMuscular = new TextBox();
            dgvDias = new DataGridView();
            dgvEjercicios = new DataGridView();
            btnAgregarEjercicio = new Button();
            numSeries = new NumericUpDown();
            numReps = new NumericUpDown();
            numDescanso = new NumericUpDown();
            txtNotas = new TextBox();
            splitContainer = new SplitContainer();
            cmbEjercicioBase = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numDuracionSemana).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDescanso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(75, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(101, 17);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblDuracion
            // 
            lblDuracion.Location = new Point(301, 20);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(84, 23);
            lblDuracion.TabIndex = 2;
            lblDuracion.Text = "Semanas:";
            // 
            // numDuracionSemana
            // 
            numDuracionSemana.Location = new Point(391, 18);
            numDuracionSemana.Maximum = new decimal(new int[] { 52, 0, 0, 0 });
            numDuracionSemana.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracionSemana.Name = "numDuracionSemana";
            numDuracionSemana.Size = new Size(120, 27);
            numDuracionSemana.TabIndex = 3;
            numDuracionSemana.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(20, 55);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripción...";
            txtDescripcion.Size = new Size(730, 27);
            txtDescripcion.TabIndex = 4;
            // 
            // btnCrearRutina
            // 
            btnCrearRutina.Location = new Point(628, 17);
            btnCrearRutina.Name = "btnCrearRutina";
            btnCrearRutina.Size = new Size(122, 29);
            btnCrearRutina.TabIndex = 5;
            btnCrearRutina.Text = "Crear Rutina";
            btnCrearRutina.Click += btnCrearRutina_Click;
            // 
            // btnNuevoEjercicioBase
            // 
            btnNuevoEjercicioBase.Location = new Point(827, 651);
            btnNuevoEjercicioBase.Name = "btnNuevoEjercicioBase";
            btnNuevoEjercicioBase.Size = new Size(75, 33);
            btnNuevoEjercicioBase.TabIndex = 16;
            btnNuevoEjercicioBase.Text = "➕ Nuevo";
            btnNuevoEjercicioBase.Click += btnNuevoEjercicioBase_Click;
            // 
            // btnGuardarRutina
            // 
            btnGuardarRutina.Location = new Point(940, 651);
            btnGuardarRutina.Name = "btnGuardarRutina";
            btnGuardarRutina.Size = new Size(84, 58);
            btnGuardarRutina.TabIndex = 17;
            btnGuardarRutina.Text = "Guardar Rutina";
            btnGuardarRutina.Click += btnGuardarRutina_Click;
            // 
            // btnAgregarDia
            // 
            btnAgregarDia.Location = new Point(494, 96);
            btnAgregarDia.Name = "btnAgregarDia";
            btnAgregarDia.Size = new Size(146, 32);
            btnAgregarDia.TabIndex = 6;
            btnAgregarDia.Text = "Agregar Día";
            btnAgregarDia.Click += btnAgregarDia_Click;
            // 
            // cmbDiaSemana
            // 
            cmbDiaSemana.Items.AddRange(new object[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" });
            cmbDiaSemana.Location = new Point(131, 98);
            cmbDiaSemana.Name = "cmbDiaSemana";
            cmbDiaSemana.Size = new Size(121, 28);
            cmbDiaSemana.TabIndex = 7;
            // 
            // txtGrupoMuscular
            // 
            txtGrupoMuscular.Location = new Point(272, 99);
            txtGrupoMuscular.Name = "txtGrupoMuscular";
            txtGrupoMuscular.PlaceholderText = "Grupo muscular";
            txtGrupoMuscular.Size = new Size(203, 27);
            txtGrupoMuscular.TabIndex = 8;
            // 
            // dgvDias
            // 
            dgvDias.ColumnHeadersHeight = 29;
            dgvDias.Dock = DockStyle.Fill;
            dgvDias.Location = new Point(0, 0);
            dgvDias.Name = "dgvDias";
            dgvDias.RowHeadersWidth = 51;
            dgvDias.Size = new Size(1003, 258);
            dgvDias.TabIndex = 0;
            // 
            // dgvEjercicios
            // 
            dgvEjercicios.ColumnHeadersHeight = 29;
            dgvEjercicios.Dock = DockStyle.Fill;
            dgvEjercicios.Location = new Point(0, 0);
            dgvEjercicios.Name = "dgvEjercicios";
            dgvEjercicios.RowHeadersWidth = 51;
            dgvEjercicios.Size = new Size(1003, 254);
            dgvEjercicios.TabIndex = 0;
            // 
            // btnAgregarEjercicio
            // 
            btnAgregarEjercicio.Location = new Point(646, 655);
            btnAgregarEjercicio.Name = "btnAgregarEjercicio";
            btnAgregarEjercicio.Size = new Size(134, 56);
            btnAgregarEjercicio.TabIndex = 10;
            btnAgregarEjercicio.Text = "Agregar Ejercicio";
            btnAgregarEjercicio.Click += btnAgregarEjercicio_Click;
            // 
            // numSeries
            // 
            numSeries.Location = new Point(318, 651);
            numSeries.Name = "numSeries";
            numSeries.Size = new Size(60, 27);
            numSeries.TabIndex = 11;
            // 
            // numReps
            // 
            numReps.Location = new Point(318, 684);
            numReps.Name = "numReps";
            numReps.Size = new Size(60, 27);
            numReps.TabIndex = 12;
            // 
            // numDescanso
            // 
            numDescanso.Location = new Point(469, 651);
            numDescanso.Name = "numDescanso";
            numDescanso.Size = new Size(80, 27);
            numDescanso.TabIndex = 13;
            // 
            // txtNotas
            // 
            txtNotas.Location = new Point(391, 684);
            txtNotas.Name = "txtNotas";
            txtNotas.PlaceholderText = "Notas...";
            txtNotas.Size = new Size(249, 27);
            txtNotas.TabIndex = 14;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(20, 130);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgvDias);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(dgvEjercicios);
            splitContainer.Size = new Size(1003, 516);
            splitContainer.SplitterDistance = 258;
            splitContainer.TabIndex = 9;
            // 
            // cmbEjercicioBase
            // 
            cmbEjercicioBase.AccessibleDescription = "";
            cmbEjercicioBase.AccessibleName = "";
            cmbEjercicioBase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEjercicioBase.FormatString = "Catalogo de ejercicios";
            cmbEjercicioBase.Location = new Point(20, 676);
            cmbEjercicioBase.Name = "cmbEjercicioBase";
            cmbEjercicioBase.Size = new Size(180, 28);
            cmbEjercicioBase.TabIndex = 15;
            cmbEjercicioBase.Tag = "Catalogo de ejercicios";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 98);
            label1.Name = "label1";
            label1.Size = new Size(105, 23);
            label1.TabIndex = 18;
            label1.Text = "Agregar Día:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(218, 654);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 19;
            label2.Text = "Series";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 687);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 20;
            label3.Text = "Repeticiones";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(391, 655);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 21;
            label4.Text = "Descanso";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(786, 687);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 22;
            label5.Text = "Crear Ejercicio nuevo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(81, 653);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 23;
            label6.Text = "Ejercicio";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormRutina
            // 
            ClientSize = new Size(1053, 716);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDuracion);
            Controls.Add(numDuracionSemana);
            Controls.Add(txtDescripcion);
            Controls.Add(btnCrearRutina);
            Controls.Add(btnAgregarDia);
            Controls.Add(cmbDiaSemana);
            Controls.Add(txtGrupoMuscular);
            Controls.Add(splitContainer);
            Controls.Add(btnAgregarEjercicio);
            Controls.Add(numSeries);
            Controls.Add(numReps);
            Controls.Add(numDescanso);
            Controls.Add(txtNotas);
            Controls.Add(cmbEjercicioBase);
            Controls.Add(btnNuevoEjercicioBase);
            Controls.Add(btnGuardarRutina);
            Name = "FormRutina";
            Text = "Gestión de Rutinas";
            Load += FormRutina_Load;
            ((System.ComponentModel.ISupportInitialize)numDuracionSemana).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeries).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReps).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDescanso).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}