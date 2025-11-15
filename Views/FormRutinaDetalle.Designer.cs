namespace Gestor_de_Rutinas___GYM.Views
{
    partial class FormRutinaDetalle
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private DataGridView dgvDias;
        private DataGridView dgvEjercicios;
        private Button btnCerrar;

        /// <summary>
        ///  Clean up any resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvDias = new System.Windows.Forms.DataGridView();
            this.dgvEjercicios = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblTitulo.Height = 60;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Text = "Detalles de la Rutina";

            // 
            // dgvDias
            // 
            this.dgvDias.AllowUserToAddRows = false;
            this.dgvDias.AllowUserToDeleteRows = false;
            this.dgvDias.ReadOnly = true;
            this.dgvDias.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDias.Height = 220;
            this.dgvDias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDias.RowHeadersVisible = false;
            this.dgvDias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDias.BackgroundColor = System.Drawing.Color.FromArgb(55, 55, 55);
            this.dgvDias.GridColor = System.Drawing.Color.Gray;

            // 
            // dgvEjercicios
            // 
            this.dgvEjercicios.AllowUserToAddRows = false;
            this.dgvEjercicios.AllowUserToDeleteRows = false;
            this.dgvEjercicios.ReadOnly = true;
            this.dgvEjercicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEjercicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEjercicios.RowHeadersVisible = false;
            this.dgvEjercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEjercicios.BackgroundColor = System.Drawing.Color.FromArgb(55, 55, 55);
            this.dgvEjercicios.GridColor = System.Drawing.Color.Gray;

            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Height = 45;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(15, 146, 140);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // 
            // FormRutinaDetalle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvEjercicios);
            this.Controls.Add(this.dgvDias);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormRutinaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Rutina";

            // 🔥 ESTA LINEA ERA LA QUE FALTABA 🔥
            this.Load += new System.EventHandler(this.FormRutinaDetalle_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).EndInit();
            this.ResumeLayout(false);
        }



        #endregion
    }
}


