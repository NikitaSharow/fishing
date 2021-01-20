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
    public partial class fishingForms : Form
    {
        public fishingForms(string fishing)
        {
            InitializeComponent();
            if (fishing == "удочка 1")
            {
                label1.Text = "Описание удочки 1";
                pictureBox1.Load("../../../Picture/удочка зеленая.jpg");
            }
            if (fishing == "удочка 2")
            {
                label1.Text = "Описание удочки 2";
                pictureBox1.Load("../../../Picture/удочка зимняя.jpg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
