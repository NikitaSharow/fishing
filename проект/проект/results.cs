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
            label12.Text = words["Наживка: "] + Program.ChoosedLb12;
            label6.Text = words["Место ловли: "] + Program.ChoosedPlace;
            label8.Text = words["Вот что вы сможете поймать"];
            label9.Text = words["Ничего (Вы не всё выбрали)"];
            label10.Text = words["Сколько все это будет стоить: "] + Program.price + words["рублей"];
            label11.Text = words["Введите свою почту:"];
            button1.Text = words["Заказать"];

            if (Program.ChoosedLb1 != "" & Program.ChoosedLb2 != "" &
                Program.ChoosedLb3 != "" & Program.ChoosedLb4 != "" &
                Program.ChoosedLb5 != "" & Program.ChoosedLb12 != "" &
                Program.ChoosedPlace != "")
            {
                if (Program.ChoosedPlace == "Волга")
                    label9.Text = "Жерех, судак, щука, окунь, вобла, красноперка и плотва";
                if (Program.ChoosedPlace == "Енисей")
                    label9.Text = "Окунь, ёрш, щука, язь, гольян, осётр, стерлядь, таймень, хариус, нельма, муксун, налим, пелядь, ряпушка и омуль";
                if (Program.ChoosedPlace == "Обь")
                    label9.Text = "Карась, сазан, нельма, лещ, окунь, щука";
            }
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
       
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainForm.objList.Count; i++)
                if (Program.ChoosedLb12 == MainForm.objList[i].name)
                { Program.price = Program.price - MainForm.objList[i].price; Program.ChoosedLb12 = ""; }

            label12.Text = label12.Text + Program.ChoosedLb12;
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
            m.Body = " Поздравляем вы купили:" +
                Environment.NewLine +
                Environment.NewLine + label1.Text +
                Environment.NewLine + label2.Text +
                Environment.NewLine + label3.Text +
                Environment.NewLine + label4.Text +
                Environment.NewLine + label5.Text +
                Environment.NewLine + label12.Text +
                Environment.NewLine + " По цене:" + Program.price + "рублей";
            m.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1337coolmail1337@gmail.com", ",mnbvcxz");
            smtp.EnableSsl = true;
            smtp.Send(m);

            MessageBox.Show("Готово");
        }
    }
}
