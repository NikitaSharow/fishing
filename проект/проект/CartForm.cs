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
    public partial class CartForm : Form
    {
        void rename(Dictionary<string, string> words)
        {
            label1.Text = words["Вот что вы выбрали"] + ":";
            label2.Text = words["Ничего"];
            label3.Text = words["Цена"] + ": ";
        }
        public CartForm()
        {
            InitializeComponent();
            if (Program.Language == "En")
                rename(MainForm.eng);
            else
                rename(MainForm.rus);

            label3.Text = label3.Text + Program.cartPrice;
            int y = 50;
            foreach (KeyValuePair<objects, int> pair in MainForm.korzina)
            {
                objects obj = pair.Key;
                int count = pair.Value;
                string shtuk = " штука)";
                if(count >= 2)
                    shtuk = " штуки)";
                if (count >= 5)
                    shtuk = " штук)";

                label2.Visible = false;
                Label label = new Label();
                label.Location = new Point(20, y);
                label.Size = new Size(690, 45);
                label.Text = obj.name + " (" + count.ToString() + shtuk;
                Controls.Add(label);
                y = y + 50;
            }
        }

        private void CartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
