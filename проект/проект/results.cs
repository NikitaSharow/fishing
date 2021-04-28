using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            label1.Text = words["Удилище: "] + Program.ChoosedLb1;
            label2.Text = words["Катушка: "] + Program.ChoosedLb2;
            label3.Text = words["Леска: "] + Program.ChoosedLb3;
            label4.Text = words["Крючок: "] + Program.ChoosedLb4;
            label5.Text = words["Поплавок: "] + Program.ChoosedLb5;
            label6.Text = words["Место ловли: "] + Program.ChoosedPlace;
            label8.Text = words["Вот что вы сможете поймать"];
            label10.Text = words["Сколько все это будет стоить: "] + Program.price + words["рублей"];
        }
        public Results()
        {
            InitializeComponent();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.Language == "En")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailAddress from = new MailAddress("1337coolmail1337@gmail.com", "Закзчик");
            MailAddress to = new MailAddress(textBox1.Text);
            MailMessage m = new MailMessage(from, to);

            m.Subject = "Заказ пришел";
            m.Body = "Поздравляем вы купили ничего за ничего!!!";
            m.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1337coolmail1337@gmail.com", ",mnbvcxz");
            smtp.EnableSsl = true;
            smtp.Send(m);

            MessageBox.Show("Готово");
        }
    }
}
