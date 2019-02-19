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
        /// Путь автосохранения
        /// </summary>
        private string autosaveBackupPath;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public XmlWorker()
        {
            //Инициализируем путь автосохранения
            autosavePath = Environment.CurrentDirectory + @"\autosave.EHDZS";
            //Путь создания бекапов файла автосохранения
            autosaveBackupPath = Environment.CurrentDirectory + @"\Backups\";
            //На всякий случай, перезсоздаём путь (если он не существует)
            Directory.CreateDirectory(Environment.CurrentDirectory);
        }


        /// <summary>
        /// Сохраняем информацию о манге
        /// </summary>
        /// <param name="path">Путь сохранения. При дефолтном значении, будет использован путь автосохранения.</param>
        /// <param name="dList">Список загрузки</param>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public byte saveManga(DownloadList dList, string path = null)
        {
            byte ex = 1;
            byte result;

            try
            {
                //Инициализируем сериализатор XML
                XmlSerializer xs = new XmlSerializer(typeof(DownloadListXml));
                //Инициализируем класс списка загрузок
                DownloadListXml list = new DownloadListXml();
                //Загружаем информацию о манге в список загрузок
                result = list.loadFromMangaList(dList);
                //Если всё ок
                if (result == 0)
                {
                    //Если не был указан путь сохранения
                    if (path == null)
                    {
                        //Указываем путь автосохранения
                        path = autosavePath;
                        //Делаем бекап файла автосохранения (если он нужен)
                        backupAutosave();
                    }

                    //Инициализируем поток записи в файл
                    using (StreamWriter sw = new StreamWriter(path))
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
        /// Получаем текущую метку времени
        /// </summary>
        /// <returns>Число секунд, в виде строки</returns>
        private string timeMicro()
        {
            //Получаем время с долями секунды
            return ((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString("F5");
        }

        /// <summary>
        /// Создаём бекап файла автосохранения
        /// </summary>
        private void backupAutosave()
        {
            //Если стоит флаг создания бекапов файла автосохранения
            if (Program.settingsStorage.settings.autosaveBackup)
            {
                //Если файл автосохранения существует
                if (File.Exists(autosavePath))
                {
                    //Проверяем файл автосохранения, на его размер.
                    // Делать бекапы пустых файлов смысла нету.
                    if (checkautosaveFile())
                    {
                        //Создаём директорию автосохранения, если её не было
                        Directory.CreateDirectory(autosaveBackupPath);
                        //Формируем новое имя файла (с меткой времени)
                        string name = $"autosave_{timeMicro()}.EHDZS";
                        //Переносим файл сохранения в бекапы
                        File.Move(autosavePath, autosaveBackupPath + name);
                    }
                }                
            }
        }

        /// <summary>
        /// Проверяем файл автосохранения, на его размер.
        /// Делать бекапы пустых файлов смысла нету.
        /// </summary>
        /// <returns>True - файл не пустой</returns>
        private bool checkautosaveFile() =>
            //Файл бекапа хоть с одной ссылкой весит в районе 400 байт.
            //Файл без ссылок, но с путём весит в районе 300 байт.
            //350 байт - приемлемый лимит, для определния пустых файлов.
            (File.ReadAllBytes(autosavePath).Length > 350);
        

        /// <summary>
        /// Загружаем список манги из файла
        /// </summary>
        /// <param name="mangas">Список манги, который будет загружен</param>
        /// <param name="path">Путь загрузки. При дефолтном значении, будет использован путь автосохранения.</param>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public DownloadList loadManga(string path = null)
        {
            DownloadList ex = null;
            DownloadListXml buff;

            try
            {
                //Инициализируем сериализатор XML
                XmlSerializer xs = new XmlSerializer(typeof(DownloadListXml));
                //Инициализируем класс списка загрузок
                ex = new DownloadList();
                //Если не был указан путь загрузки
                if (path == null)
                    //Указываем путь автозагрузки
                    path = autosavePath;

                //Если файл для загрузки существует
                if (File.Exists(path))
                {
                    //Инициализируем поток загрузки из файла
                    using (StreamReader sr = new StreamReader(path))
                    {
                        //Десериализуем наш класс из файла
                        buff = (DownloadListXml)xs.Deserialize(sr);
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
