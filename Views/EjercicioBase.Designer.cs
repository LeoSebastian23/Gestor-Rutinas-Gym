using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormEjercicioBase : Form
    {
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblGrupo;
        private TextBox txtGrupo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnVerTodos;
        private DataGridView dgvEjercicios;

        private void InitializeComponent()
        {
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblGrupo = new Label();
            txtGrupo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnVerTodos = new Button();
            dgvEjercicios = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(25, 89);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(83, 27);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(148, 89);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(495, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblGrupo
            // 
            lblGrupo.Location = new Point(25, 140);
            lblGrupo.Name = "lblGrupo";
            lblGrupo.Size = new Size(117, 23);
            lblGrupo.TabIndex = 2;
            lblGrupo.Text = "Grupo Muscular:";
            lblGrupo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(148, 140);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(495, 27);
            txtGrupo.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(25, 187);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 23);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(148, 185);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(495, 27);
            txtDescripcion.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(504, 236);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(196, 32);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(606, 274);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(94, 28);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(504, 274);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(96, 28);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVerTodos
            // 
            btnVerTodos.Location = new Point(25, 272);
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.Size = new Size(133, 32);
            btnVerTodos.TabIndex = 9;
            btnVerTodos.Text = "Ver Todos";
            btnVerTodos.Click += btnVerTodos_Click;
            // 
            // dgvEjercicios
            // 
            dgvEjercicios.ColumnHeadersHeight = 29;
            dgvEjercicios.Location = new Point(25, 320);
            dgvEjercicios.Name = "dgvEjercicios";
            dgvEjercicios.ReadOnly = true;
            dgvEjercicios.RowHeadersWidth = 51;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjercicios.Size = new Size(675, 90);
            dgvEjercicios.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 26F);
            label1.Location = new Point(148, 9);
            label1.Name = "label1";
            label1.Size = new Size(495, 53);
            label1.TabIndex = 11;
            label1.Text = "Catalogo de Ejercicos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormEjercicioBase
            // 
            ClientSize = new Size(740, 440);
            Controls.Add(label1);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblGrupo);
            Controls.Add(txtGrupo);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnVerTodos);
            Controls.Add(dgvEjercicios);
            Name = "FormEjercicioBase";
            Text = "Catálogo de Ejercicios Base";
            Load += FormEjercicioBase_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
