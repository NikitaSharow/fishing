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
        public Label label;
        public int price;
        public string category;

        public objects (string name1, string category1, int price1)
        {
            picture = new PictureBox();
            label = new Label();
            name = name1;
            price = price1;
            category = category1;
        }
    }

    public partial class MainForm : Form
    {
        public objects[] obj = new objects[11];
        //List<objects> obj1 = new List<objects>();

        public MainForm()
        {
            InitializeComponent();

            //obj1.Add(new objects("Удочка Deukio", "Удочки", 859));
            obj[0]  = new objects("Удочка Deukio"  , "Удочки" , 859 );
            obj[1]  = new objects("Удочка RAPALA"  , "Удочки" , 1499);
            obj[2]  = new objects("Катушка Daiwa"  , "Катушки", 2772);
            obj[3]  = new objects("Катушка Shimano", "Катушки", 4200);
            obj[4]  = new objects("Катушка Stinger", "Катушки", 3300);
            obj[5]  = new objects("Леска Prologic" , "Лески"  , 349 );
            obj[6]  = new objects("Леска Sunline"  , "Лески"  , 344 );
            obj[7]  = new objects("Леска Trabucco" , "Лески"  , 300 );
            obj[8]  = new objects("Удилище Maximus Sorcerer"  , "Удилища", 2567);
            obj[9]  = new objects("Удилище Волжанка Классик"  , "Удилища", 1130);
            obj[10] = new objects("Удилище Волжанка Фортуна"  , "Удилища", 2437 );

            int x = 10;
            int y = 100;
            for (int i = 0; i < 11; i++)
            {
                Label label30 = new Label();
                label30.Location = new Point(x, y + 120);
                label30.Size = new Size(120, 75);
                label30.Text = obj[i].name;
                //label30.Font = new Font();
                Controls.Add(label30);
                obj[i].label = label30;

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
                obj[i].picture = pb1;

                x = x + 160;
                if (x >= Width)
                { y = y + 200; x = 10; }
            }

            for (int i = 0; i < 11; i++)
            {
                obj[i].picture.Tag = obj[i].name;
                obj[i].picture.AccessibleDescription = obj[i].price.ToString();
                obj[i].picture.Click += new EventHandler(open);
            }
        }

        private void open(object sender, EventArgs e)
        {
            PictureBox pb1 = (PictureBox)sender;
            GeneralForms form = new GeneralForms(pb1.Tag.ToString(), pb1.AccessibleDescription);
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
            int x = 10;
            int y = 100;
            for (int i = 0; i < 11; i++)
            {
                obj[i].picture.Visible = true;

                if (textBox1.Text != "" &&
                    !obj[i].name.Contains(textBox1.Text))
                    obj[i].picture.Visible = false;

                if (comboBox1.Text != "Всё" && 
                    comboBox1.Text != "Выберите категорию" && 
                    comboBox1.Text != obj[i].category)
                    obj[i].picture.Visible = false;

                if(obj[i].picture.Visible)
                {
                    obj[i].picture.Location = new Point(x, y);
                    obj[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x >= Width)
                    { y = y + 200; x = 10; }
                }
                
                obj[i].label.Visible = obj[i].picture.Visible;
            }

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
