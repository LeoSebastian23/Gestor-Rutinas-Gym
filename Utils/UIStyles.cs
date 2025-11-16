using System.Drawing;
using System.Windows.Forms;

namespace Gestor_de_Rutinas___GYM.Utils
{
    public static class UIStyles
    {
        // Paleta
        public static Color BackDark => Color.FromArgb(72, 72, 72);
        public static Color ControlBack => Color.FromArgb(60, 60, 60);
        public static Color Primary => Color.FromArgb(15, 146, 140);
        public static Color PrimaryLight => Color.FromArgb(0, 201, 210);
        public static Color Accent => Color.FromArgb(190, 238, 59);

        // Fuente general
        public static Font FontRegular => new("Segoe UI", 11F, FontStyle.Regular);
        public static Font FontBold => new("Segoe UI", 11F, FontStyle.Bold);

        // Aplicar estilo general al formulario
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = BackDark;
            form.Font = FontRegular;
            form.ForeColor = Color.White;
        }

        // Estilo común para TextBox
        public static void StyleTextBox(TextBox t)
        {
            t.BackColor = ControlBack;
            t.BorderStyle = BorderStyle.FixedSingle;
            t.ForeColor = Color.White;
            t.Font = FontRegular;
            t.Height = 35;
        }

        // Estilo común para ComboBox
        public static void StyleCombo(ComboBox c)
        {
            c.BackColor = ControlBack;
            c.ForeColor = Color.White;
            c.Font = FontRegular;
            c.DropDownStyle = ComboBoxStyle.DropDownList;
            c.Height = 35;
        }

        // Estilo común para NumericUpDown
        public static void StyleNumeric(NumericUpDown n)
        {
            n.BackColor = ControlBack;
            n.ForeColor = Color.White;
            n.Font = FontRegular;
            n.Height = 35;
        }

        // Estilo común para Button
        public static void StyleButton(Button b, Color color)
        {
            b.BackColor = color;
            b.FlatAppearance.BorderSize = 0;
            b.FlatStyle = FlatStyle.Flat;
            b.ForeColor = Color.White;
            b.Font = FontBold;
            b.Height = 45;
            b.Width = 150;
        }

        // Estilo específico para DataGridView
        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(50, 50, 50);
            dgv.BorderStyle = BorderStyle.None;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Primary,
                ForeColor = Color.White,
                Font = FontBold,
                SelectionBackColor = PrimaryLight,
                SelectionForeColor = Color.Black
            };

            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(0, 100, 101),
                SelectionForeColor = Color.White,
                Font = FontRegular
            };

            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(55, 55, 55),
                ForeColor = Color.White
            };
        }
    }
}
