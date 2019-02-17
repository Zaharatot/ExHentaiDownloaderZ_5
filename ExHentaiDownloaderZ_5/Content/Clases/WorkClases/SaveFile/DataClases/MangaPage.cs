using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExHentaiDownloaderZ_5.Content.Clases.DataClases;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.SaveFile.DataClases
{
    /// <summary>
    /// Класс, реализующий информацию о странице манги
    /// для сохранения в xml
    /// </summary>
    [Serializable]
    public class MangaPage
    {
        /// <summary>
        /// id страницы
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Адрес страницы на сайте
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Флаг загрузки
        /// </summary>
        public PageLoadStatus.status loaded { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public MangaPage()
        {
            //Инициализируем дефолтные значения.
            //Всё что будет в NULL в итоговый XML-файл не войдёт.
            id = 0;
            url = null;
            loaded = PageLoadStatus.status.Загрузка_ещё_не_произошла;
        }

        /// <summary>
        /// Загружаем информацию о странице, из основного списка
        /// </summary>
        /// <param name="pg">Информация о странице, для загрузки</param>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public byte loadFromPage(page pg)
        {
            byte ex = 1;

            try
            {
                //Проставляем значения
                id = pg.id;
                url = pg.url;
                loaded = pg.loaded;

                //Всё ок
                ex = 0;
            }
            catch { ex = 1; }

            return ex;
        }


        /// <summary>
        /// Загружаем информацию о странице, в основной список
        /// </summary>
        /// <returns>Информация о странице манги, либо null в случае ошибки</returns>
        public page loadToPage()
        {
            page ex = null;

            try
            {
                //Инициализируем страницу
                ex = new page();
                //Проставляем значения
                ex.id = id;
                ex.url = url;
                ex.loaded = loaded;
            }
            catch { ex = null; }

            return ex;
        }
    }
}
