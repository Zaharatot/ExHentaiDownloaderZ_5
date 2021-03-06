﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// Класс, хранящий информацию о манге
    /// </summary>
    public class manga
    {
        /// <summary>
        /// Список страниц манги
        /// </summary>
        public List<page> pages { get; set; }

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
        public string url { get; set; }

        /// <summary>
        /// Статус загрузки манги
        /// </summary>
        public MangaStatus.status status { get; set; }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="url">Адрес корневой страницы манги</param>
        public manga(string url)
        {
            //Инициализируем список страниц манги
            pages = new List<page>();
            //Проставляем адрес
            this.url = url;
            //Статус - манга создана
            status = MangaStatus.status.Манга_добавлена;
        }

        /// <summary>
        /// Добавляем страницу манги
        /// </summary>
        /// <param name="url">Адрес новой страницы</param>
        public void addpage(string url)
        {
            //Добавляем страницу в список
            pages.Add(new page()
            {
                url = url
            });
        }

        /// <summary>
        /// Проверка того, что манга была загружена
        /// </summary>
        /// <returns>True - загружена</returns>
        public bool checkLoad() =>
            //Если количество страниц совпадает с загруженным количеством страниц
            (pages.Count == (pages.Count(pg => (pg.loaded == PageLoadStatus.status.Загрузка_успешна))));

        /// <summary>
        /// Проверка того, что фактическое загруженное количество 
        /// страниц совпадает с предполагаемым количеством страниц
        /// </summary>
        /// <returns>True - всё ок</returns>
        public bool checkCount() =>
            (pages.Count == countPages);

        /// <summary>
        /// Возвращает количество загруженных страниц манги
        /// </summary>
        /// <returns>Количество загруженных страниц</returns>
        public int downloadPages() =>
            (pages.Count(pg => (pg.loaded == PageLoadStatus.status.Загрузка_успешна)));
        
    }
}
