using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ExHentaiDownloaderZ_5.Content.Clases.WorkClases.SaveFile.DataClases;
using ExHentaiDownloaderZ_5.Content.Clases.DataClases;
using System.Xml.Serialization;
using System.IO;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.SaveFile
{
    /// <summary>
    /// Класс, реализующий функционал по сохранению и загрузке манги
    /// </summary>
    class XmlWorker
    {
        /// <summary>
        /// Путь автосохранения
        /// </summary>
        private string autosavePath;


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public XmlWorker()
        {
            //Инициализируем путь автосохранения
            autosavePath = Environment.CurrentDirectory + @"\autosave.EHDZS";
            //На всякий случай, перезсоздаём путь (если он не существует)
            Directory.CreateDirectory(autosavePath);
        }


        /// <summary>
        /// Сохраняем информацию о манге
        /// </summary>
        /// <param name="path">Путь сохранения. При дефолтном значении, будет использован путь автосохранения.</param>
        /// <param name="mangas">Список манги, дял сохранения</param>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public byte saveManga(List<manga> mangas, string path = null)
        {
            byte ex = 1;
            byte result;

            try
            {
                //Инициализируем сериализатор XML
                XmlSerializer xs = new XmlSerializer(typeof(DownloadList));
                //Инициализируем класс списка загрузок
                DownloadList list = new DownloadList();
                //Загружаем информацию о манге в список загрузок
                result = list.loadFromMangaList(mangas);
                //Если всё ок
                if (result == 0)
                {
                    //Если не был указан путь сохранения
                    if (path == null)
                        //Указываем путь автосохранения
                        path = autosavePath;
                    //Инициализируем поток записи в файл
                    using (StreamWriter sw = new StreamWriter(autosavePath))
                    {
                        //Сериализуем в файл наш класс
                        xs.Serialize(sw, list);
                        //Сохраняем и закрываем поток
                        sw.Flush();
                        sw.Dispose();
                    }
                    //Всё ок
                    ex = 0;
                }
                else
                    //Ошибка - манга не была загружена
                    ex = 2;
            }
            catch { ex = 1; }

            return ex;
        }

        /// <summary>
        /// Загружаем список манги из файла
        /// </summary>
        /// <param name="mangas">Список манги, который будет загружен</param>
        /// <param name="path">Путь загрузки. При дефолтном значении, будет использован путь автосохранения.</param>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public List<manga> loadManga(string path = null)
        {
            List<manga> ex = null;
            DownloadList buff;

            try
            {
                //Инициализируем сериализатор XML
                XmlSerializer xs = new XmlSerializer(typeof(DownloadList));
                //Инициализируем класс списка загрузок
                ex = new List<manga>();
                //Если не был указан путь загрузки
                if (path == null)
                    //Указываем путь автозагрузки
                    path = autosavePath;

                //Если файл для загрузки существует
                if (File.Exists(path))
                {
                    //Инициализируем поток загрузки из файла
                    using (StreamReader sr = new StreamReader(autosavePath))
                    {
                        //Десериализуем наш класс из файла
                        buff = (DownloadList)xs.Deserialize(sr);
                        //Закрываем поток
                        sr.Dispose();
                    }
                    //Загружаем список манги в основной класс
                    ex = buff.loadToMangaList();
                }
            }
            catch { ex = null; }

            return ex;
        }
    }
}
