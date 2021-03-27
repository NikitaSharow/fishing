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
        void rename(Dictionary<string, string> words)
        {
            label1.Text = words["Настройки"];
            label2.Text = words["Режим"];
            label3.Text = words["Язык"];
            button1.Text = words["Применить"];
        }
        public Settings()
        {
            InitializeComponent();
            if (Program.Language == "En")
            {
                comboBox2.Text = "Английский";
                rename(MainForm.eng);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            if (comboBox1.Text == "Выбор отдельных комплектующих")
                Program.CartMode = false;
            else
                Program.CartMode = true;

            if (comboBox2.Text == "Русский")
                Program.Language = "Ru"; 
            else if (comboBox2.Text == "Английский")
                Program.Language = "En"; 
        }
    }
}
