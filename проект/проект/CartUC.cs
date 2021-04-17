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
        public CartUC(objects obj)
        {
            obj1 = obj;
            InitializeComponent();

            label1.Text = obj.name;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MainForm.korzina.Remove(obj1);
            this.Parent = null;
        }
    }
}
