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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Place form = new Place();
            form.Show();
        }
        /// <summary>
        /// Клик на кнопку "поиск"
        /// </summary>
        private void SearchClick(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower() == "удочка")
            { pictureBox2.Visible = true; pictureBox1.Visible = true;}

            else if (textBox1.Text.Contains("Удочка Deukio"))
            { pictureBox1.Visible = true; pictureBox2.Visible = false;}

            else if (textBox1.Text.Contains("Удочка RAPALA"))
            { pictureBox2.Visible = true; pictureBox1.Visible = false; }

            else if (textBox1.Text == "")
            { pictureBox2.Visible = true; pictureBox1.Visible = true; }

            else 
            { pictureBox2.Visible = false; pictureBox1.Visible = false; }

            label3.Visible = pictureBox1.Visible;
            label4.Visible = pictureBox2.Visible;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            GeneralForms form = new GeneralForms("");
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           // GeneralForms form = new GeneralForms("Удочка RAPALA");
           // form.Show();
           // label5.Text = "Удочка RAPALA";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            results form = new results();
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchClick(sender, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
