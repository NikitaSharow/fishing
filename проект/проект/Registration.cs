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
    public partial class Registration : Form
    {
        public static string login = "";
        List<string> logPass = new List<string>();

        void ReadAllLogPass()
        {
            logPass.Clear();
            string[] lines = File.ReadAllLines("../../../loginPasswords.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "," }, StringSplitOptions.None);
                logPass.Add(parts[0]); logPass.Add(parts[1]);
            }
        }

        public Registration()
        {
            InitializeComponent();
            ReadAllLogPass();

            //logPass.Add("Admin"); logPass.Add("Admin");
            //logPass.Add("123"); logPass.Add("123");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < logPass.Count; i = i + 2)
            {
                if (textBox1.Text != "" & textBox2.Text != "")
                {
                
                    if (textBox1.Text == logPass[i] & textBox2.Text == logPass[i + 1])
                    { MessageBox.Show("Вы уже зарегистрированы"); login = textBox1.Text; Close();}
                    else
                    {
                        File.AppendAllText("../../../loginPasswords.txt", Environment.NewLine +
                        textBox1.Text + "," + textBox2.Text);
                        MessageBox.Show("Вы зарегистрировались");
                        login = textBox1.Text;
                        Close();
                    }
                }  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Войдите";
            button2.Visible = false;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < logPass.Count; i = i + 2)
            {
                if (textBox1.Text != "" & textBox2.Text != "")
                {
                    if (textBox1.Text == logPass[i] & textBox2.Text == logPass[i + 1])
                    {
                        if (logPass[i] == "Admin")
                            MessageBox.Show("Вы вошли в аккаунт админа");
                        else
                            MessageBox.Show("Вы вошли в аккаунт");
                        login = textBox1.Text;
                        Close();
                    }
                    else
                        MessageBox.Show("Вы не зарегистрированы");
                }
            }
        }
    }
}
