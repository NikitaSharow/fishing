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
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
            label1.Text = "Удилище: " + Program.ChoosedLb1;
            label2.Text = "Катушка: " + Program.ChoosedLb2;
            label3.Text = "Леска: "   + Program.ChoosedLb3;
            label4.Text = "Крючок: "  + Program.ChoosedLb4;
            label5.Text = "Поплавок: " + Program.ChoosedLb5;
            label6.Text = "Место ловли: " + Program.ChoosedPlace;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb1 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb1 = "";}


            label1.Text = "Удилище: " + Program.ChoosedLb1;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb2 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb2 = ""; }

            label2.Text = "Катушка: " + Program.ChoosedLb2;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb3 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb3 = ""; }

            label3.Text = "Леска: " + Program.ChoosedLb3;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb5 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb5 = ""; }

            label5.Text = "Поплавок: " + Program.ChoosedLb5;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb4 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb4 = ""; }

            label4.Text = "Крючок: " + Program.ChoosedLb4;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Program.ChoosedPlace = "";
            label6.Text = "Место ловли: " + Program.ChoosedPlace;
        }
    }
}
