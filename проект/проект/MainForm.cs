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
        public string catecategory;

    }
    public partial class MainForm : Form
    {
        public objects[] obj = new objects[11];
        public MainForm()
        {
            InitializeComponent();

            obj[0] = new objects();
            obj[0].name = "Удочка Deukio";
            obj[0].price = 859;
            obj[0].catecategory = "Удочки";


            obj[1] = new objects();
            obj[1].name = "Удочка RAPALA";
            obj[1].price = 1499;
            obj[1].catecategory = "Удочки";

            obj[2] = new objects();
            obj[2].name = "Катушка Daiwa";
            obj[2].price = 0;
            obj[2].catecategory = "Катушки";

            obj[3] = new objects();
            obj[3].name = "Катушка Shimano";
            obj[3].price = 0;
            obj[3].catecategory = "Катушки";

            obj[4] = new objects();
            obj[4].name = "Катушка Stinger";
            obj[4].price = 0;
            obj[4].catecategory = "Катушки";

            obj[5] = new objects();
            obj[5].name = "Леска Prologic";
            obj[5].price = 0;
            obj[5].catecategory = "Лески";

            obj[6] = new objects();
            obj[6].name = "Леска Sunline";
            obj[6].price = 0;
            obj[6].catecategory = "Лески";

            obj[7] = new objects();
            obj[7].name = "Леска Trabucco";
            obj[7].price = 0;
            obj[7].catecategory = "Лески";

            int x = 10;
            int y = 100;
            for (int i = 0; i < 8; i++)
            {
                Label label30 = new Label();
                label30.Location = new Point(x, y + 120);
                label30.Size = new Size(120, 55);
                label30.Text = obj[i].name;
                //label30.Font = new Font();
                Controls.Add(label30);

                PictureBox pb1 = new PictureBox();
                pb1.Location = new Point(x, y);
                pb1.Size = new Size(120, 120);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    pb1.Load("../../../Picture/" + obj[i].name + ".jpg");
                }
                catch (Exception) { }
                Controls.Add(pb1);

                x = x + 160;
                if (x >= Width)
                { y = y + 200; x = 10; }
            }

            for (int i = 0; i < 8; i++)
            {
                obj[i].picture.Tag = obj[i].names;
                obj[i].picture.Click += new EventHandler(open);
            }
        }

        private void open(object sender, EventArgs e)
        {
            PictureBox pb1 = (PictureBox)sender;
            GeneralForms form = new GeneralForms(pb1.Tag.ToString());
            form.Show();
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
            for(int i = 0; i < 8; i++)
            {
                if (textBox1.Text != "")
                {
                    obj[i].picture.Visible = false;

                    if (obj[i].name.Contains(textBox1.Text))
                        obj[i].picture.Visible = true;
                }

                else
                {
                    obj[i].picture.Visible = true;

                    if(comboBox1.Text != "Всё" && comboBox1.Text != obj[i].catecategory)
                        obj[i].picture.Visible = false;
                }
                

            }

            label3.Visible = pictureBox1.Visible;
            label4.Visible = pictureBox2.Visible;
            label5.Visible = pictureBox3.Visible;
            label6.Visible = pictureBox4.Visible;
            label7.Visible = pictureBox5.Visible;
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
