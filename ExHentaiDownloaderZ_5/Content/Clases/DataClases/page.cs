using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// Страница манги
    /// </summary>
    class page
    {
        /// <summary>
        /// Адрес страницы на сайте
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Флаг загрузки
        /// </summary>
        public bool loaded { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public page()
        {
            //Ставим дефолтные значения
            loaded = false;
        }

    }
}
