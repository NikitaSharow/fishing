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
    public partial class CartUC : UserControl
    {
        objects obj1;
        public CartUC(objects obj, int value)
        {
            obj1 = obj;
            InitializeComponent();

            string shtuk = " штука)";
            if (value >= 2)
                shtuk = " штуки)";
            if (value >= 5)
                shtuk = " штук)";

            label1.Text = obj.name + " (" + value.ToString() + shtuk;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MainForm.korzina.Remove(obj1);
            this.Parent = null;
        }
    }
}
