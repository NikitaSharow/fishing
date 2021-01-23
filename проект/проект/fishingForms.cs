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
        /// <summary>
        /// Форма для удочек
        /// </summary>
        /// <param name="fishing">Модель удочки</param>
        public fishingForms(string fishing)
        {
            InitializeComponent();
            if (fishing == "Удочка Deukio")
            {
                label2.Text = "Цена: 859 руб.";
                label1.Text = "Простая и доступная удочка в компактном исполнении для ловли на всех видах водоемов." +
                    " Лучший выбор для путешественника не займет много места в сумке, чемодане, багажника автомобиля.";
                pictureBox1.Load("../../../Picture/удочка зеленая.jpg");
            }
            if (fishing == "Удочка RAPALA")
            {
                label2.Text = "Цена: 1499 руб.";
                label1.Text = "Бланк удилища из стекловолокна, рукоятка из нескользящего материала EVA." +
                    " Мощное, сбалансированное  и чувствительное удилище, сверхпрочные кольца из оксида алюминия" +
                    " Катушка имеет графитовый корпус с  прочной и легкой пластиковой шпулей." +
                    " Имеет передний фрикцион и возможность перестановки под правую/левую руку";
                pictureBox1.Load("../../../Picture/удочка зимняя.jpg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
