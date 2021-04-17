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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                MessageBox.Show("Успешно");
                Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Войдите";
            button2.Visible = false;
        }
    }
}
