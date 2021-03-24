using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace проект
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Выбор отдельных комплектующих")
                Program.CartMode = false;
            else
                Program.CartMode = true;

            if (comboBox2.Text == "Русский")
            { Program.Language = "Ru"; comboBox2.Text = "Русский"; }
            if (comboBox2.Text == "Английский")
            { Program.Language = "En"; comboBox2.Text = "Английский"; }
        }
    }
}
