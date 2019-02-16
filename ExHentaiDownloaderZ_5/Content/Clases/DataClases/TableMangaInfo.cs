using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExHentaiDownloaderZ_5.Content.Clases.WorkClases;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// ИНформация о манге, для вывода в таблицу
    /// </summary>
    class TableMangaInfo
    {
        /// <summary>
        /// Адрес манги
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Название манги
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Общее количество страниц у манги
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// Количество загруженных страниц манги
        /// </summary>
        public int downloadCount { get; set; }
        /// <summary>
        /// Статус загрузки манги
        /// </summary>
        public MangaStatus.status status { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public TableMangaInfo()
        {
            //Проставляем дефолтные значения
            url = name = "";
            count = downloadCount = 0;
            status = MangaStatus.status.Манга_добавлена;
        }

        /// <summary>
        /// Получаем строку с названием статуска
        /// </summary>
        /// <returns>Строка статуса</returns>
        private string getStatusString() =>
            ResourceLoader.loadStatusText("DownloadStatus_" + ((int)status).ToString());

        /// <summary>
        /// Возвращаем строку для таблицы
        /// </summary>
        /// <returns>Массив объектов</returns>
        public object[] getRow() =>
            new object[] {
                url,
                name,
                $"{downloadCount} / {count}",
                getStatusString()
            };
    }
}
