﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// Страница манги
    /// </summary>
    public class page
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
        /// Имя загруженного файла
        /// </summary>
        public string filename { get; set; }
        /// <summary>
        /// Флаг загрузки
        /// </summary>
        public PageLoadStatus.status loaded { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public page()
        {
            //Ставим дефолтные значения
            loaded = PageLoadStatus.status.Загрузка_ещё_не_произошла;
            filename = url = null;
        }

    }
}
