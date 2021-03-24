using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace проект
{
    public partial class GeneralForms : Form
    {
        /// <summary>
        /// Модель удочки
        /// </summary>
        objects product;

        /// <summary>
        /// Форма для удочек
        /// </summary>
        /// <param name="model">Модель удочки</param>
        public GeneralForms(string model, string Price = "")
        {
            InitializeComponent();

            //Что за удочка прилетела на форму
            foreach (objects choosenProduct in MainForm.objList)
            {
                if (model == choosenProduct.name)
                {
                    product = choosenProduct;
                    label2.Text = "Цена: " + product.price + " руб.";
                    pictureBox1.Image = product.picture.Image;
                }
            }

            try
            {
                label1.Text = File.ReadAllText("../../../Files/" + model + ".txt");

                textBox1.Text = File.ReadAllText("../../../Files/" + model + ".txt");
            }
            catch { label1.Text = "Ошибка"; }


            if (model == "Волга" || model == "Енисей" || model == "Обь" || model == "Корзина")
            {
                label2.Text = "";
                button1.Text = "Выбрать";
                if (model == "Корзина")
                {
                    button1.Visible = false; pictureBox1.Visible = false;
                    label1.Visible = false; textBox1.Visible = false;
                }
            }

            if (model == Program.ChoosedLb1 ||
                model == Program.ChoosedLb2 ||
                model == Program.ChoosedLb3 ||
                model == Program.ChoosedLb4 ||
                model == Program.ChoosedLb5)
                label3.Visible = true;

        }
        public bool buy = false;
        public int number = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Program.CartMode)
            {
                if (MainForm.korzina.ContainsKey(product))
                    MainForm.korzina[product]++;
                else
                    MainForm.korzina.Add(product, 1);
            }

            else
            {
                if (buy == false)
                { 
                    Program.price = Program.price + product.price; 
                    buy = true; 
                }
                if (product.category == "Удилища")
                {
                    for (int i = 0; i < MainForm.objList.Count; i++)
                        if (Program.ChoosedLb1 == MainForm.objList[i].name && Program.ChoosedLb1 != "")
                            Program.price = Program.price - MainForm.objList[i].price;
                    Program.ChoosedLb1 = product.name;
                }
                if (product.category == "Катушки")
                {
                    for (int i = 0; i < MainForm.objList.Count; i++)
                        if (Program.ChoosedLb2 == MainForm.objList[i].name && Program.ChoosedLb2 != "")
                            Program.price = Program.price - MainForm.objList[i].price;
                    Program.ChoosedLb2 = product.name;
                }
                if (product.category == "Лески")
                {
                    for (int i = 0; i < MainForm.objList.Count; i++)
                        if (Program.ChoosedLb3 == MainForm.objList[i].name && Program.ChoosedLb3 != "")
                            Program.price = Program.price - MainForm.objList[i].price;
                    Program.ChoosedLb3 = product.name;
                }
                if (product.category == "Крючки")
                {
                    for (int i = 0; i < MainForm.objList.Count; i++)
                        if (Program.ChoosedLb4 == MainForm.objList[i].name && Program.ChoosedLb4 != "")
                            Program.price = Program.price - MainForm.objList[i].price;
                    Program.ChoosedLb4 = product.name;
                }
                if (product.category == "Поплавки")
                {
                    for (int i = 0; i < MainForm.objList.Count; i++)
                        if (Program.ChoosedLb5 == MainForm.objList[i].name && Program.ChoosedLb5 != "")
                            Program.price = Program.price - MainForm.objList[i].price;
                    Program.ChoosedLb5 = product.name;
                }

            }

            if (Program.CartMode)
            {label3.Text = "Добавлено" + number++; label3.Visible = true; }
            else
                label3.Visible = true;        
        }

        private void fishingForms_Load(object sender, EventArgs e)
        {

        }
    }
}
