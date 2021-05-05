using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace проект
{
    public partial class CartForm : Form
    {
        void rename(Dictionary<string, string> words)
        {
            label1.Text = words["Вот что вы выбрали"] + ":";
            label2.Text = words["Ничего"];
            label3.Text = words["Цена"] + ": ";
        }
        public CartForm()
        {
            InitializeComponent();
            if (Program.Language == "En")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);

            label3.Text = label3.Text + Program.cartPrice;
            int y = 50;
            foreach (KeyValuePair<objects, int> pair in MainForm.korzina)
            {
                /*
                objects obj = pair.Key;
                int count = pair.Value;
                string shtuk = " штука)";
                if(count >= 2)
                    shtuk = " штуки)";
                if (count >= 5)
                    shtuk = " штук)";

                label2.Visible = false;
                Label label = new Label();
                label.Location = new Point(20, y);
                label.Size = new Size(690, 45);
                label.Text = obj.name + " (" + count.ToString() + shtuk;
                Controls.Add(label);
                */

                CartUC obj1 = new CartUC(pair.Key, pair.Value);
                obj1.Location = new Point(10, y);
                Controls.Add(obj1);

                label2.Visible = false;
                y = y + 50;
            }
        }

        private void CartForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailAddress from = new MailAddress("1337coolmail1337@gmail.com", "Закзчик");
            MailAddress to = new MailAddress(textBox1.Text);
            MailMessage m = new MailMessage(from, to);

            m.Subject = "Заказ пришел";
            m.Body = "Поздравляем вы купили:";

            File.WriteAllText("MailBody.csv", "Название,Категория,Ценник,Количество,Цена", Encoding.UTF8);
            foreach(KeyValuePair<objects, int> pair in MainForm.korzina)
            {
                objects udochka = pair.Key;
                int a = udochka.price * pair.Value;
                File.AppendAllText("MailBody.csv", Environment.NewLine +
                    udochka.name + "," +
                    udochka.category + "," +
                    udochka.price + "," +
                    pair.Value.ToString() + "," +
                    a.ToString());
            }

            m.Attachments.Add(new Attachment("MailBody.csv"));

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1337coolmail1337@gmail.com", ",mnbvcxz");
            smtp.EnableSsl = true;
            smtp.Send(m);

            MessageBox.Show("Готово");
        }
    }
}
