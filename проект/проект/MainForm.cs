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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "удочка")
            { pictureBox2.Visible = true; label4.Visible = true; pictureBox1.Visible = true; label3.Visible = true; }

            else if (textBox1.Text.Contains("удочка1"))
            { pictureBox1.Visible = true; label3.Visible = true; pictureBox2.Visible = false; label4.Visible = false; }

            else if (textBox1.Text.Contains("удочка2"))
            { pictureBox2.Visible = true; label4.Visible = true; pictureBox1.Visible = false; label3.Visible = false; }

            else if (textBox1.Text.Contains(""))
            { pictureBox2.Visible = true; label4.Visible = true; pictureBox1.Visible = true; label3.Visible = true; }

            else 
            { pictureBox2.Visible = false; label4.Visible = false; pictureBox1.Visible = false; label3.Visible = false; }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fishingForms form = new fishingForms("удочка 1");
            form.Show();
            label5.Text = "Удочка1";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fishingForms form = new fishingForms("удочка 2");
            form.Show();
            label5.Text = "Удочка2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            najivka form = new najivka();
            form.Show();
        }
    }
}
