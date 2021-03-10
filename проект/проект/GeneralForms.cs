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
                { button1.Visible = false; pictureBox1.Visible = false; 
                    label1.Visible = false; textBox1.Visible = false;
                }
            }

        }

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
                if (product.category == "Удилища")
                    Program.ChoosedLb1 = product.name;
                if (product.category == "Катушки")
                    Program.ChoosedLb2 = product.name;
                if (product.category == "Лески")
                    Program.ChoosedLb3 = product.name;
            }

            if (Program.CartMode)
            {label3.Text = "Добавлено"; label3.Visible = true; }
            else
                label3.Visible = true;        
        }

        private void fishingForms_Load(object sender, EventArgs e)
        {

        }
    }
}
