﻿using System;
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
    public partial class results : Form
    {
        public results()
        {
            InitializeComponent();

            label6.Text = "Место ловли: " + Program.ChoosedPlace;
        }
    }
}
