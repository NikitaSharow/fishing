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
        public NewObj()
        {
            InitializeComponent();
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
