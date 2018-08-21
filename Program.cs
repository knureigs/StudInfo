using System;
using System.Windows.Forms;

namespace StudInfo
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RatingService ratingService = new RatingService();
            Application.Run(new StudInfoForm(ratingService));
        }
    }
}
