using System.Drawing;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Views
{
    partial class MenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Panel panelClientes;
        private Panel panelRutinas;
        private Panel panelEjercicios;
        private Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelClientes = new Panel();
            panelRutinas = new Panel();
            panelEjercicios = new Panel();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1120, 133);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "🏋️‍♂️  Gestor de Rutinas - GYM";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelClientes
            // 
            panelClientes.BackColor = Color.FromArgb(52, 152, 219);
            panelClientes.BorderStyle = BorderStyle.FixedSingle;
            panelClientes.Cursor = Cursors.Hand;
            panelClientes.Location = new Point(69, 173);
            panelClientes.Margin = new Padding(3, 4, 3, 4);
            panelClientes.Name = "panelClientes";
            panelClientes.Size = new Size(285, 199);
            panelClientes.TabIndex = 1;
            panelClientes.Click += panelClientes_Click;
            panelClientes.Paint += panelClientes_Paint;
            panelClientes.MouseEnter += panel_MouseEnter;
            panelClientes.MouseLeave += panel_MouseLeave;
            // 
            // panelRutinas
            // 
            panelRutinas.BackColor = Color.FromArgb(46, 204, 113);
            panelRutinas.BorderStyle = BorderStyle.FixedSingle;
            panelRutinas.Cursor = Cursors.Hand;
            panelRutinas.Location = new Point(411, 173);
            panelRutinas.Margin = new Padding(3, 4, 3, 4);
            panelRutinas.Name = "panelRutinas";
            panelRutinas.Size = new Size(285, 199);
            panelRutinas.TabIndex = 2;
            panelRutinas.Click += panelRutinas_Click;
            panelRutinas.Paint += panelRutinas_Paint;
            panelRutinas.MouseEnter += panel_MouseEnter;
            panelRutinas.MouseLeave += panel_MouseLeave;
            // 
            // panelEjercicios
            // 
            panelEjercicios.BackColor = Color.FromArgb(231, 76, 60);
            panelEjercicios.BorderStyle = BorderStyle.FixedSingle;
            panelEjercicios.Cursor = Cursors.Hand;
            panelEjercicios.Location = new Point(754, 173);
            panelEjercicios.Margin = new Padding(3, 4, 3, 4);
            panelEjercicios.Name = "panelEjercicios";
            panelEjercicios.Size = new Size(285, 199);
            panelEjercicios.TabIndex = 3;
            panelEjercicios.Click += panelEjercicios_Click;
            panelEjercicios.Paint += panelEjercicios_Paint;
            panelEjercicios.MouseEnter += panel_MouseEnter;
            panelEjercicios.MouseLeave += panel_MouseLeave;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Gray;
            btnSalir.FlatAppearance.BorderColor = Color.Silver;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(903, 467);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(137, 53);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1120, 560);
            Controls.Add(btnSalir);
            Controls.Add(panelEjercicios);
            Controls.Add(panelRutinas);
            Controls.Add(panelClientes);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal - Gestor GYM";
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
        }
    }
}
