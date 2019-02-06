using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExHentaiDownloaderZ_5.Content.Clases.DataClases;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.SaveFile.DataClases
{
    /// <summary>
    /// Класс, использующийся для сохранения информации о манге
    /// </summary>
    class Manga
    {
        /// <summary>
        /// Список страниц манги
        /// </summary>
        public List<MangaPage> pages { get; set; }

        /// <summary>
        /// Название манги
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Количество страниц манги
        /// </summary>
        public int countPages { get; set; }

        /// <summary>
        /// Адрес корневой страницы манги
        /// </summary>
        public string url { get; private set; }
        /// <summary>
        /// Путь к папке, куда качаем
        /// </summary>
        public string rootPath { get; private set; }

        /// <summary>
        /// Статус загрузки манги
        /// </summary>
        public byte status { get; set; }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Manga()
        {
            //Инициализируем дефолтные значения.
            //Всё что будет в NULL в итоговый XML-файл не войдёт.
            pages = null;
            name = url = rootPath = null;
            countPages = 0;
            status = 0;
        }

        /// <summary>
        /// Загружаем мангу из стандартного класса
        /// </summary>
        /// <param name="manga">Манга, которую нужно загрузить</param>
        /// <returns>0 - если всё ок, иначе - код ошибки.</returns>
        public byte loadFromManga(manga manga)
        {
            byte ex = 1;
            MangaPage buff;
            byte result;

            try
            {
                //Проставляем значения
                name = manga.name;
                countPages = manga.countPages;
                url = manga.url;
                rootPath = manga.rootPath;
                status = manga.status;

                //Инициализируем список страниц
                pages = new List<MangaPage>();
                //Проходимся по списку страниц
                foreach (var pg in manga.pages)
                {
                    //Инициализируем новую страницу
                    buff = new MangaPage();
                    //Загружаем в неё информацию
                    result = buff.loadFromPage(pg);
                    //Если всё ок
                    if(result == 0)
                        //Добавляем её в общий список
                        pages.Add(buff);
                    else
                    {
                        //Возвращаем ошибку загрузки
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
        /// Загружаем мангу в стандартный класс
        /// </summary>
        /// <returns>Информация о манге, либо null, в случае ошибки</returns>
        public manga loadToManga()
        {
            manga ex = null;
            page buff;

            try
            {
                //Инициализируем мангу
                ex = new manga(url);
                //Проставляем значения
                ex.name = name;
                ex.countPages = countPages;
                ex.rootPath = rootPath;
                ex.status = status;

                //Проходимся по списку страниц
                foreach (var pg in pages)
                {
                    //Загружаем инфу о странице
                    buff = pg.loadToPage();
                    //Если всё ок
                    if (buff != null)
                        //Добавляем её в общий список
                        ex.pages.Add(buff);
                    else
                    {
                        //Возвращаем ошибку загрузки
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
