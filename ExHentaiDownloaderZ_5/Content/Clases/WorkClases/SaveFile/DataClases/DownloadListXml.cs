using ExHentaiDownloaderZ_5.Content.Clases.DataClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.SaveFile.DataClases
{
    /// <summary>
    /// Класс, реализующий список загружаемой манги, для сохранения в xml
    /// </summary>
    [Serializable]
    public class DownloadListXml
    {
        /// <summary>
        /// ПУть загрузки
        /// </summary>
        public string downloadPath { get; set; }

        /// <summary>
        /// Список манги, для загрузки
        /// </summary>
        public List<Manga> downloadList { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DownloadListXml()
        {
            //Инициализируем дефолтные значения.
            //Всё что будет в NULL в итоговый XML-файл не войдёт.
            downloadList = null;
        }

        /// <summary>
        /// Загружаем мангу из основного списка
        /// </summary>
        /// <param name="dList">Список загрузки</param>
        /// <returns>0 - если всё ок, иначе - код ошибки.</returns>
        public byte loadFromMangaList(DownloadList dList)
        {
            byte ex = 1;
            Manga buff;
            byte result;

            try
            {
                //Поулчаем путь сохранения
                downloadPath = dList.downloadPath;
                //Инициализируем список
                downloadList = new List<Manga>();

                //Проходимся по списку манги
                foreach (var mn in dList.downloadList)
                {
                    //Инициализируем новую мангу
                    buff = new Manga();
                    //Загружаем в неё информацию о манге
                    result = buff.loadFromManga(mn);
                    //Если всё ок
                    if(result == 0)
                        //Добавляем мангу в список загрузки
                        downloadList.Add(buff);
                    else
                    {
                        //Добавляем ошибку загрузки
                        ex = 2;
                        //Выходим из цикла
                        break;
                    }
                }

                //Всё ок
                ex = 0;
            }
            catch { ex = 1; }

            return ex;
        }



        /// <summary>
        /// Загружаем мангу из основного списка
        /// </summary>
        /// <returns>Список манги, или null в случае ошибки</returns>
        public DownloadList loadToMangaList()
        {
            DownloadList ex = null;
            manga buff;

            try
            {
                //Инициализируем список
                ex = new DownloadList();
                //Записываем путь загрузки
                ex.downloadPath = downloadPath;

                //Проходимся по списку манги
                foreach (var mn in downloadList)
                {
                    //Загружаем мангу
                    buff = mn.loadToManga();
                    //Если всё ок
                    if (buff != null)
                        //Добавляем мангу в список загрузки
                        ex.downloadList.Add(buff);
                    else
                    {
                        //Добавляем ошибку загрузки
                        ex = null;
                        //Выходим из цикла
                        break;
                    }
                }
            }
            catch { ex = null; }

            return ex;
        }
    }
}
