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
    public partial class Place : Form
    {
        public Place()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GeneralForms form = new GeneralForms("Волга");
            form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GeneralForms form = new GeneralForms("Енисей");
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GeneralForms form = new GeneralForms("Обь");
            form.Show();
        }
    }
}
