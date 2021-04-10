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
    public partial class NewObj : Form
    {
        void rename(Dictionary<string, string> words)
        {
            label1.Text = words["Что бы добавить что-нибудь укажите:"];
            label2.Text = words["Название"];
            label3.Text = words["Категория"];
            label4.Text = words["Цена"];
            label5.Text = words["Описание"];
            button1.Text = words["Добавить"];
            button2.Text = words["Загрузить картинку"];
        }

        public NewObj()
        {
            InitializeComponent();
            if (Program.Language == "En")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText("../../../Objects.txt", Environment.NewLine + 
                textBox1.Text + "," + comboBox1.Text + "," + textBox2.Text);

            FileStream f = File.Create("../../../Files/" + textBox1.Text + ".txt");
            f.Close();
            File.WriteAllText("../../../Files/" + textBox1.Text + ".txt", textBox3.Text);

            if (address != "")
                File.Copy(address, "../../../Picture/" + textBox1.Text + ".jpg");
            MessageBox.Show("Успешно");
        }

        string address = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                address = openFileDialog1.FileName;
                pictureBox1.Load(address);
            }

        }
    }
}
