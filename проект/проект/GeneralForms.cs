using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace проект
{
    public partial class GeneralForms : Form
    {
        /// <summary>
        /// Форма для удочек
        /// </summary>
        /// <param name="Name">Модель удочки</param>
        public GeneralForms(string Name)
        {
            InitializeComponent();

            pictureBox1.Load("../../../Picture/" + Name + ".jpg");
            label1.Text = File.ReadAllText("../../../Files/" + Name + ".txt");

            if (Name == "Удочка Deukio")
            {
                label2.Text = "Цена: 859 руб.";
            }
            if (Name == "Удочка RAPALA")
            {
                label2.Text = "Цена: 1499 руб.";
            }
            if (Name == "Волга" || Name == "Енисей" || Name == "Обь")
            {
                label2.Text = "";
                button1.Text = "Выбрать";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void fishingForms_Load(object sender, EventArgs e)
        {

        }
    }
}
