using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string[] rusLines = File.ReadAllLines("../../../Переводы/rus.txt");
            foreach (string line in rusLines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                rus.Add(parts[0], parts[1]);
            }
            string[] engLines = File.ReadAllLines("../../../Переводы/eng.txt");
            foreach (string line in engLines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                eng.Add(parts[0], parts[1]);
            }
        }

        void rename(Dictionary<string, string> words)
        {
            label2.Text = words["Введите название"];
            label1.Text = words["Категория"];
            label14.Text = words["Цена"];
            button4.Text = words["Добавить"];
            button3.Text = words["Поиск"];
            button2.Text = words["Итог"];
            button1.Text = words["Выбрать место ловли"];
            comboBox1.Text = words["Выберите категорию"];
        }

        void ReadAllProducts()
        {
            objList.Clear();
            string[] lines = File.ReadAllLines("../../../Objects.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                objList.Add(new objects(parts[0], parts[1], Convert.ToInt32(parts[2])));
            }
        }
        
        public MainForm()
        {
            InitializeComponent();
            allWords();
            ReadAllProducts();

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
                panel1.Size = new Size(panel1.Size.Width, 111);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.Language == "Ru")
                rename(rus);
            if (Program.Language == "En")
                rename(eng);
            if (Registration.login != "")
                label15.Text = "Вы вошли в аккаунт " + Registration.login;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if(Registration.login != "Admin")
                MessageBox.Show("Вы не админ");
            else
            {
                NewObj form = new NewObj();
                form.ShowDialog();
                form.Dispose();
                ReadAllProducts();
             }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            form.ShowDialog();
            button4_Click(null, null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.huntworld.ru/blog/kak-vybrat-katushku-dlya-spinninga-video/");
        }   

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.huntworld.ru/blog/kak-vybrat-spinningovoe-udilishche-/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.huntworld.ru/blog/top-9-lesok-dlya-zimney-rybalki/");
        }
    }
}
