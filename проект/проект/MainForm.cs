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
    public struct objects
    {
        public PictureBox picture;
        public string name;
        public int price;
    }
    public partial class MainForm : Form
    {
        public objects[] obj = new objects[11];
        public MainForm()
        {
            InitializeComponent();

            obj[0] = new objects();
            obj[0].name = "Удочка Deukio";
            obj[0].picture = pictureBox1;
            obj[0].price = 859; 
            obj[1] = new objects();
            obj[1].name = "Удочка RAPALA";
            obj[1].picture = pictureBox2;
            obj[1].price = 1499;
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
            for(int i = 0; i <= 1; i++)
            {
                obj[i].picture.Visible = false;

                if (obj[i].name.Contains(textBox1.Text))
                    obj[i].picture.Visible = true;
            }

            label3.Visible = pictureBox1.Visible;
            label4.Visible = pictureBox2.Visible;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GeneralForms form = new GeneralForms(obj[1].name);
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           GeneralForms form = new GeneralForms(obj[2].name);
           form.Show();
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
