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
        string product = "";

        /// <summary>
        /// Форма для удочек
        /// </summary>
        /// <param name="model">Модель удочки</param>
        public GeneralForms(string model, string Price = "")
        {
            product = model;
            InitializeComponent();
            try
            {
                pictureBox1.Load("../../../Picture/" + model + ".jpg");
                label1.Text = File.ReadAllText("../../../Files/" + model + ".txt");
                if (model == "Корзина")
                    for (int i = 0; i < MainForm.korzina.Count; i++)
                        textBox1.Text = MainForm.korzina[i].name + ",";
                else
                    textBox1.Text = File.ReadAllText("../../../Files/" + model + ".txt");
            }
            catch { label1.Text = "Ошибка"; }
                
            for (int i = 0; i < MainForm.objList.Count; i++)
                if(model == MainForm.objList[i].name)
                {
                    label2.Text = "Цена: " + MainForm.objList[i].price + " руб.";
                }

            if (model == "Волга" || model == "Енисей" || model == "Обь" || model == "Корзина")
            {
                label2.Text = "";
                button1.Text = "Выбрать";
                if (model == "Корзина")
                { button1.Visible = false; pictureBox1.Visible = false; label1.Visible = false; }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (product == MainForm.objList[i].name)
                {
                    if (Program.Mode)
                        MainForm.korzina.Add(new objects(MainForm.objList[i].name, "", 0));
                    else
                    {
                        if (MainForm.objList[i].category == "Удилища")
                            Program.ChoosedLb1 = MainForm.objList[i].name;
                        if (MainForm.objList[i].category == "Катушки")
                            Program.ChoosedLb2 = MainForm.objList[i].name;
                        if (MainForm.objList[i].category == "Лески")
                            Program.ChoosedLb3 = MainForm.objList[i].name;
                    }


                }
            label3.Visible = true;        
        }

        private void fishingForms_Load(object sender, EventArgs e)
        {

        }
    }
}
