using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingsStorageZ.Clases;

namespace ExHentaiDownloaderZ_5
{
    static class Program
    {
        /// <summary>
        /// Класс параметров приложения
        /// </summary>
        public static Settings settingsStorage;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Инициализируем параметры приложения
            settingsStorage = new Settings();

            //Включаем визуальные стили
            Application.EnableVisualStyles();
            //Проставляем параметры рендеринга текста
            Application.SetCompatibleTextRenderingDefault(false);
            //Запускаем main-фалому, как UI-поток
            Application.Run(new main());
        }
    }
}
