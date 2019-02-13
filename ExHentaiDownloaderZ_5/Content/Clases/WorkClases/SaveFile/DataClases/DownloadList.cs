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
    public class DownloadList
    {
        /// <summary>
        /// Список манги, для загрузки
        /// </summary>
        public List<Manga> downloadList { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DownloadList()
        {
            //Инициализируем дефолтные значения.
            //Всё что будет в NULL в итоговый XML-файл не войдёт.
            downloadList = null;
        }

        /// <summary>
        /// Загружаем мангу из основного списка
        /// </summary>
        /// <param name="mangas">Список манги, для загрузки</param>
        /// <returns>0 - если всё ок, иначе - код ошибки.</returns>
        public byte loadFromMangaList(List<manga> mangas)
        {
            byte ex = 1;
            Manga buff;
            byte result;

            try
            {
                //Инициализируем список
                downloadList = new List<Manga>();
                //Проходимся по списку манги
                foreach (var mn in mangas)
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
        public List<manga> loadToMangaList()
        {
            List<manga> ex = null;
            manga buff;

            try
            {
                //Инициализируем список
                ex = new List<manga>();
                //Проходимся по списку манги
                foreach (var mn in downloadList)
                {
                    //Загружаем мангу
                    buff = mn.loadToManga();
                    //Если всё ок
                    if (buff != null)
                        //Добавляем мангу в список загрузки
                        ex.Add(buff);
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
