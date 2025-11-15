using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormEjercicioBase
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Panel panelCampos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblGrupo;
        private TextBox txtGrupo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnVerTodos;
        private DataGridView dgvEjercicios;

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
            lblGrupo = new Label();
            txtGrupo = new TextBox();
            btnVerTodos = new Button();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            dgvEjercicios = new DataGridView();
            panelCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(800, 60);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "📋 Catálogo de Ejercicios Base";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCampos
            // 
            panelCampos.Controls.Add(lblNombre);
            panelCampos.Controls.Add(btnAgregar);
            panelCampos.Controls.Add(txtNombre);
            panelCampos.Controls.Add(btnEliminar);
            panelCampos.Controls.Add(lblGrupo);
            panelCampos.Controls.Add(txtGrupo);
            panelCampos.Controls.Add(btnVerTodos);
            panelCampos.Controls.Add(lblDescripcion);
            panelCampos.Controls.Add(txtDescripcion);
            panelCampos.Dock = DockStyle.Top;
            panelCampos.Location = new Point(0, 60);
            panelCampos.Name = "panelCampos";
            panelCampos.Padding = new Padding(20);
            panelCampos.Size = new Size(800, 160);
            panelCampos.TabIndex = 5;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 17);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblGrupo
            // 
            lblGrupo.AutoSize = true;
            lblGrupo.Location = new Point(400, 20);
            lblGrupo.Name = "lblGrupo";
            lblGrupo.Size = new Size(116, 20);
            lblGrupo.TabIndex = 2;
            lblGrupo.Text = "Grupo Muscular:";
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(520, 17);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.Size = new Size(250, 27);
            txtGrupo.TabIndex = 3;
            // 
            // btnVerTodos
            // 
            btnVerTodos.Location = new Point(0, 0);
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.Size = new Size(75, 23);
            btnVerTodos.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 65);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 62);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(650, 52);
            txtDescripcion.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(532, 120);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 34);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(659, 120);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(111, 34);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvEjercicios
            // 
            dgvEjercicios.ColumnHeadersHeight = 29;
            dgvEjercicios.Dock = DockStyle.Fill;
            dgvEjercicios.Location = new Point(0, 220);
            dgvEjercicios.Name = "dgvEjercicios";
            dgvEjercicios.ReadOnly = true;
            dgvEjercicios.RowHeadersWidth = 51;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjercicios.Size = new Size(800, 280);
            dgvEjercicios.TabIndex = 0;
            // 
            // FormEjercicioBase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(dgvEjercicios);
            Controls.Add(panelCampos);
            Controls.Add(lblTitulo);
            Name = "FormEjercicioBase";
            Text = "Catálogo de Ejercicios Base";
            Load += FormEjercicioBase_Load;
            panelCampos.ResumeLayout(false);
            panelCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).EndInit();
            ResumeLayout(false);
        }
    }
}