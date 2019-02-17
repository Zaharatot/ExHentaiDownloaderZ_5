using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SettingsStorageZ.Clases.DataClases;

namespace SettingsStorageZ.Clases.WorkClases
{
    /// <summary>
    /// Класс, реализующий функционал по сохранению и загрузке параметров
    /// </summary>
    class XmlWorker
    {
        /// <summary>
        /// Путь к файлу параметров
        /// </summary>
        private string savePath;


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public XmlWorker()
        {
            //Инициализируем путь к файлу параметров
            savePath = Environment.CurrentDirectory + @"\settings.xml";
            //На всякий случай, перезсоздаём путь (если он не существует)
            Directory.CreateDirectory(Environment.CurrentDirectory);
        }


        /// <summary>
        /// Сохраняем параметры
        /// </summary>
        /// <param name="storage">Список параметров</param>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public byte saveSettings(SettingsStorage storage)
        {
            byte ex = 1;

            try
            {
                //Инициализируем сериализатор XML
                XmlSerializer xs = new XmlSerializer(typeof(SettingsStorage));
          
                //Инициализируем поток записи в файл
                using (StreamWriter sw = new StreamWriter(savePath))
                {
                    //Сериализуем в файл наш класс
                    xs.Serialize(sw, storage);
                    //Сохраняем и закрываем поток
                    sw.Flush();
                    sw.Dispose();
                }
                //Всё ок
                ex = 0;
            }
            catch { ex = 1; }

            return ex;
        }

        /// <summary>
        /// Загружаем список параметров
        /// </summary>
        /// <returns>Список параметров</returns>
        public SettingsStorage loadSettings()
        {
            //Инициализируем дефолтными параметрами
            SettingsStorage ex = new SettingsStorage();

            try
            {
                //Инициализируем сериализатор XML
                XmlSerializer xs = new XmlSerializer(typeof(SettingsStorage));           

                //Если файл для загрузки существует
                if (File.Exists(savePath))
                {
                    //Инициализируем поток загрузки из файла
                    using (StreamReader sr = new StreamReader(savePath))
                    {
                        //Десериализуем наш класс из файла
                        ex = (SettingsStorage)xs.Deserialize(sr);
                        //Закрываем поток
                        sr.Dispose();
                    }
                }
            }
            catch
            {
                //В случае ошибки, инициализируем дефолтными параметрами
                ex = new SettingsStorage();
            }

            return ex;
        }
    }
}
