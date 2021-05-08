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
    public partial class ResponseForm : Form
    {
        public ResponseForm()
        {
            InitializeComponent();
        }

        string Address1 = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "" & comboBox1.Text != "")
            {
                MailAddress from = new MailAddress("1337coolmail1337@gmail.com", "Закзчик");
                MailAddress to = new MailAddress("nikita.coterig@gmail.com");
                MailMessage m = new MailMessage(from, to);

                m.Subject = "Справочник по удочкам. " + comboBox1.Text;
                m.Body = textBox3.Text + Environment.NewLine;

                if (comboBox1.Text == "Отзыв")
                    m.Body = m.Body + "Контакт: " + textBox1.Text + Environment.NewLine;

                if (comboBox1.Text == "Отзыв")
                {
                    if (radioButton1.Checked == true)
                        m.Body = m.Body + "Оценка - 1";
                    if (radioButton2.Checked == true)
                        m.Body = m.Body + "Оценка - 2";
                    if (radioButton4.Checked == true)
                        m.Body = m.Body + "Оценка - 3";
                    if (radioButton3.Checked == true)
                        m.Body = m.Body + "Оценка - 4";
                    if (radioButton6.Checked == true)
                        m.Body = m.Body + "Оценка - 5";
                }
                m.IsBodyHtml = false;

                if (Address1 != "")
                {
                    Attachment attachment = new Attachment(Address1);
                    attachment.Name = "1.jpg";
                    m.Attachments.Add(attachment);
                }


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("1337coolmail1337@gmail.com", ",mnbvcxz");
                smtp.EnableSsl = true;
                smtp.Send(m);

                MessageBox.Show("Готово");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Address1 = openFileDialog1.FileName;
                pictureBox1.Load(Address1);
            }
        } 
    }
}
