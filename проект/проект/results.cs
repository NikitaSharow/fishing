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
        public Results()
        {
            InitializeComponent();
            label1.Text = "Удилище: " + Program.ChoosedLb1;
            label2.Text = "Катушка: " + Program.ChoosedLb2;
            label3.Text = "Леска: "   + Program.ChoosedLb3;
            label6.Text = "Место ловли: " + Program.ChoosedPlace;
            label10.Text = "Сколько все это будет стоить: " + Program.price + " рублей";
        }
    }
}
