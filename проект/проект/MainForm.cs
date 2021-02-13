﻿using System;
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
            obj[0].picture = pictureBox1;
            obj[0].price = 859;
            obj[0].catecategory = "Удочки";


            obj[1] = new objects();
            obj[1].name = "Удочка RAPALA";
            obj[1].picture = pictureBox2;
            obj[1].price = 1499;
            obj[1].catecategory = "Удочки";

            obj[2] = new objects();
            obj[2].name = "Катушка Daiwa";
            obj[2].picture = pictureBox3;
            obj[2].price = 0;
            obj[2].catecategory = "Катушки";

            obj[3] = new objects();
            obj[3].name = "Катушка Shimano";
            obj[3].picture = pictureBox4;
            obj[3].price = 0;
            obj[3].catecategory = "Катушки";

            obj[4] = new objects();
            obj[4].name = "Катушка Stinger";
            obj[4].picture = pictureBox5;
            obj[4].price = 0;
            obj[4].catecategory = "Катушки";

            for(int i = 0; i < 4; i++)
            {
                Label label30 = new Label();
                label30.Location = new Point(10 + 160 * i, 223);
                label30.Size = new Size(120, 55);
                label30.Text = obj[i].name;
                //label30.Font = new Font();
                Controls.Add(label30);

                PictureBox pb1 = new PictureBox();
                pb1.Location = new Point(10 + 160 * i, 100);
                pb1.Size = new Size(120, 120);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                pb1.Load("../../../Picture/" + obj[i].name + ".jpg");
                Controls.Add(pb1);
            }

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
            for(int i = 0; i <= 4; i++)
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GeneralForms form = new GeneralForms(obj[0].name);
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           GeneralForms form = new GeneralForms(obj[1].name);
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
