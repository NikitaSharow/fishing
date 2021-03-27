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
        public static Dictionary<objects, int> korzina = new Dictionary<objects, int>();

        public static Dictionary<string, string> rus = new Dictionary<string, string>();
        public static Dictionary<string, string> eng = new Dictionary<string, string>();

        public static void allWords()
        {
            rus.Add("Введите название", "Введите название");
            eng.Add("Введите название", "Enter the name");
            rus.Add("Категория", "Категория");
            eng.Add("Категория", "Category");
            rus.Add("Цена", "Цена");
            eng.Add("Цена", "Price");
            rus.Add("Поиск", "Поиск");
            eng.Add("Поиск", "Search");
            rus.Add("Итог", "Итог");
            eng.Add("Итог", "Result");
            rus.Add("Выбрать место ловли", "Выбрать место ловли");
            eng.Add("Выбрать место ловли", "Choose a fishing spot");
            rus.Add("Выберите категорию", "Выберите категорию");
            eng.Add("Выберите категорию", "Select a category");
            rus.Add("Настройки", "Настройки");
            eng.Add("Настройки", "Settings");
            rus.Add("Режим", "Режим");
            eng.Add("Режим", "Mode");
            rus.Add("Язык", "Язык");
            eng.Add("Язык", "Language");
            rus.Add("Применить", "Применить");
            eng.Add("Применить", "Apply");
        }

        void rename(Dictionary<string, string> words)
        {
            label2.Text = words["Введите название"];
            label1.Text = words["Категория"];
            label14.Text = words["Цена"];
            button3.Text = words["Поиск"];
            button2.Text = words["Итог"];
            button1.Text = words["Выбрать место ловли"];
            comboBox1.Text = words["Выберите категорию"];
        }

        public MainForm()
        {
            InitializeComponent();
            allWords();

            objList.Add(new objects("Удочка Deukio"    , "Удочки"  , 859 ));
            objList.Add(new objects("Удочка RAPALA"    , "Удочки"  , 1499));
            objList.Add(new objects("Катушка Daiwa"    , "Катушки" , 2772));
            objList.Add(new objects("Катушка Shimano"  , "Катушки" , 4200));
            objList.Add(new objects("Катушка Stinger"  , "Катушки" , 3300));
            objList.Add(new objects("Леска Prologic"   , "Лески"   , 349 ));
            objList.Add(new objects("Леска Sunline"    , "Лески"   , 344 ));
            objList.Add(new objects("Леска Trabucco"   , "Лески"   , 300 ));
            objList.Add(new objects("Удилище Maximus Sorcerer"     , "Удилища", 2567));
            objList.Add(new objects("Удилище Волжанка Классик"     , "Удилища", 1130));
            objList.Add(new objects("Удилище Волжанка Фортуна"     , "Удилища", 2437));
            objList.Add(new objects("Крючки Owner"     , "Крючки"  , 150 ));
            objList.Add(new objects("Крючки VMC"       , "Крючки"  , 4   ));
            objList.Add(new objects("Крючки Savage"    , "Крючки"  , 199 ));
            objList.Add(new objects("Поплавок Briscola", "Поплавки", 155 ));
            objList.Add(new objects("Поплавок Пирс Рус", "Поплавки", 23  ));
            objList.Add(new objects("Поплавок Trabucco", "Поплавки", 270 ));

            int x = 30;
            int y = 10;
            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].label.Location = new Point(x, y + 120);
                objList[i].label.Size = new Size(120, 75);
                objList[i].label.Text = objList[i].name;
                //label30.Font = new Font();
                panel2.Controls.Add(objList[i].label);

                objList[i].picture.Location = new Point(x, y);
                objList[i].picture.Size = new Size(120, 120);
                objList[i].picture.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    objList[i].picture.Load("../../../Picture/" + objList[i].name + ".jpg");
                }
                catch (Exception) { }
                panel2.Controls.Add(objList[i].picture);

                x = x + 160;
                if (x + 130 >= Width)
                { y = y + 200; x = 30; }
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
            int x = 30;
            int y = 10;
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
                    if (x + 130 >= Width)
                    { y = y + 200; x = 30; }
                }

                objList[i].label.Visible = objList[i].picture.Visible;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.CartMode)
                new CartForm().Show();
            else
                new Results().Show(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchClick(sender, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.ShowDialog();
            button4_Click(null, null);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (panel1.Size.Height > 25)
                panel1.Size = new Size(panel1.Size.Width, 25);
            else
                panel1.Size = new Size(panel1.Size.Width, 100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.Language == "Ru")
                rename(rus);
            if (Program.Language == "En")
                rename(eng);
        }
    }
}
