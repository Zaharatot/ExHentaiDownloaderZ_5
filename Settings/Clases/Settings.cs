using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingsStorageZ.Clases.DataClases;
using SettingsStorageZ.Clases.WorkClases;

namespace SettingsStorageZ.Clases
{
    /// <summary>
    /// Базовый класс настроек приложения
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Класс сохранения и загрузки
        /// </summary>
        private XmlWorker xw;
        /// <summary>
        /// Класс, хранящий настройки
        /// </summary>
        public SettingsStorage settings;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Settings()
        {
            //Инициализируем класс работы с параметрами
            xw = new XmlWorker();
            //Загружаем настройки из файла (или ставим дефолтные)
            settings = xw.loadSettings();
        }

        /// <summary>
        /// Проверяем установленные параметры, перед сохранением
        /// </summary>
        private void checkSettings()
        {
            //Проверка установленного пути
            //Если последний символ - не слеш
            if (settings.downloadPath.Last() != '\\')
                //Добавляем слеш в конец
                settings.downloadPath += "\\";
        }

        /// <summary>
        /// Сохраняем параметры в файл
        /// </summary>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public byte saveSettings()
        {
            byte ex = 1;

            try
            {
                //Проверяем установленные параметры, перед сохранением
                checkSettings();
                //Сохраняем параметры
                ex = xw.saveSettings(settings);
            }
            catch { ex = 1; }

            return ex;
        }
    }
}
