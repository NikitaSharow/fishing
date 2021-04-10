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
        void rename(Dictionary<string, string> words)
        {
            label7.Text = words["Вот что вы выбрали"];
            label1.Text = words["Удилище: "];
            label2.Text = words["Катушка: "];
            label3.Text = words["Леска: "];
            label4.Text = words["Крючок: "];
            label5.Text = words["Поплавок: "];
            label6.Text = words["Место ловли: "];
            label8.Text = words["Вот что вы сможете поймать"];
            label10.Text = words["Сколько все это будет стоить: "];
        }
        public Results()
        {
            InitializeComponent();
            if (Program.Language == "En")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);

            label1.Text = label1.Text + Program.ChoosedLb1;
            label2.Text = label2.Text + Program.ChoosedLb2;
            label3.Text = label3.Text + Program.ChoosedLb3;
            label4.Text = label4.Text + Program.ChoosedLb4;
            label5.Text = label5.Text + Program.ChoosedLb5;
            label6.Text = label6.Text + Program.ChoosedPlace;
            if (Program.Language == "En")
                label10.Text = label10.Text + Program.price + " rubles";
            else
                label10.Text = label10.Text + Program.price + " рублей";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb1 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb1 = "";}


            label1.Text = label1.Text + Program.ChoosedLb1;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb2 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb2 = ""; }

            label2.Text = label2.Text + Program.ChoosedLb2;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb3 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb3 = ""; }

            label3.Text = label3.Text + Program.ChoosedLb3;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb5 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb5 = ""; }

            label5.Text = label5.Text + Program.ChoosedLb5;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb4 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb4 = ""; }

            label4.Text = label4.Text + Program.ChoosedLb4;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Program.ChoosedPlace = "";
            label6.Text = label6.Text + Program.ChoosedPlace;
        }
    }
}
