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
        public static List<objects> objList = new List<objects>();

        public MainForm()
        {
            InitializeComponent();

            objList.Add(new objects("Удочка Deukio"  , "Удочки" , 859 ));
            objList.Add(new objects("Удочка RAPALA"  , "Удочки" , 1499));
            objList.Add(new objects("Катушка Daiwa"  , "Катушки", 2772));
            objList.Add(new objects("Катушка Shimano", "Катушки", 4200));
            objList.Add(new objects("Катушка Stinger", "Катушки", 3300));
            objList.Add(new objects("Леска Prologic" , "Лески"  , 349 ));
            objList.Add(new objects("Леска Sunline"  , "Лески"  , 344 ));
            objList.Add(new objects("Леска Trabucco" , "Лески"  , 300 ));
            objList.Add(new objects("Удилище Maximus Sorcerer"  , "Удилища", 2567));
            objList.Add(new objects("Удилище Волжанка Классик"  , "Удилища", 1130));
            objList.Add(new objects("Удилище Волжанка Фортуна"  , "Удилища", 2437));

            int x = 10;
            int y = 100;
            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].label.Location = new Point(x, y + 120);
                objList[i].label.Size = new Size(120, 75);
                objList[i].label.Text = objList[i].name;
                //label30.Font = new Font();
                Controls.Add(objList[i].label);

                objList[i].picture.Location = new Point(x, y);
                objList[i].picture.Size = new Size(120, 120);
                objList[i].picture.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    objList[i].picture.Load("../../../Picture/" + objList[i].name + ".jpg");
                }
                catch (Exception) { }
                Controls.Add(objList[i].picture);

                x = x + 160;
                if (x >= Width)
                { y = y + 200; x = 10; }
            }

            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].picture.Tag = objList[i].name;
                objList[i].picture.AccessibleDescription = objList[i].price.ToString();
                objList[i].picture.Click += new EventHandler(open);
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
            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].picture.Visible = true;

                if (textBox1.Text != "" &&
                    !objList[i].name.Contains(textBox1.Text))
                    objList[i].picture.Visible = false;

                if (comboBox1.Text != "Всё" && 
                    comboBox1.Text != "Выберите категорию" && 
                    comboBox1.Text != objList[i].category)
                    objList[i].picture.Visible = false;

                if (numericUpDown1.Value != 0 &&
                    numericUpDown1.Value <= objList[i].price)
                    objList[i].picture.Visible = false;

                if (objList[i].picture.Visible)
                {
                    objList[i].picture.Location = new Point(x, y);
                    objList[i].label.Location = new Point(x, y + 120);
                    x = x + 160;
                    if (x >= Width)
                    { y = y + 200; x = 10; }
                }

                objList[i].label.Visible = objList[i].picture.Visible;
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
