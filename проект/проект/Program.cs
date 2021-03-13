using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace проект
{
    static class Program
    {
        public static string ChoosedPlace = "";
        public static string ChoosedLb1   = "";
        public static string ChoosedLb2   = "";
        public static string ChoosedLb3   = "";

        public static int price = 0;
        /// <summary>
        /// Режим корзины (true) или подбора деталей (false)
        /// </summary>
        public static bool CartMode = false;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
