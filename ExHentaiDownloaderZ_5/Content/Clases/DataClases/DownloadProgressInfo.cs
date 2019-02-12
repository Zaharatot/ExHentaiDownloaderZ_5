using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// ИНформация о прогрессе загрузки манги
    /// </summary>
    class DownloadProgressInfo
    {
        /// <summary>
        /// Флаг завершения загрузки
        /// </summary>
        public bool finalFlag { get; set; }

        /// <summary>
        /// Максимум общего прогрессбара
        /// </summary>
        public int maxFull { get; set; }
        /// <summary>
        /// Текущее значение общего прогрессбара
        /// </summary>
        public int currentFull { get; set; }
        /// <summary>
        /// Максимум текущего прогрессбара
        /// </summary>
        public int maxCurr { get; set; }
        /// <summary>
        /// Текущее значение текущего прогрессбара
        /// </summary>
        public int currentCurr { get; set; }

        /// <summary>
        /// Среднее время общей загрузки в секундах
        /// </summary>
        public decimal approximateFullTime { get; set; }

        /// <summary>
        /// Среднее время текущей загрузки в секундах
        /// </summary>
        public decimal approximateCurrentTime { get; set; }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DownloadProgressInfo()
        {
            //Проставляем дефолтные значения
            finalFlag = false;
            currentCurr = currentFull = maxCurr = maxFull = 0;
            approximateFullTime = approximateCurrentTime = -1;
        }

        /// <summary>
        /// Получаем общее время загрузки
        /// </summary>
        /// <param name="apprTime">Среднее время загрузки</param>
        /// <param name="count">Количество</param>
        /// <returns>Строка времени загрузки</returns>
        private string getLoadTime(decimal apprTime, int count) =>
            $"Осталось примерно {apprTime * count} секунд.";

        /// <summary>
        /// Возврат общей строки статуса 
        /// </summary>
        /// <returns>Текст общей строки</returns>
        public string getFullStatus() =>
            $"Статус загрузки: {currentFull} / {maxFull}. {getLoadTime(approximateFullTime, maxFull)}";

        /// <summary>
        /// Возврат текущей строки статуса 
        /// </summary>
        /// <returns>Текст текущей строки</returns>
        public string getCurrentStatus() =>
            $"Статус загрузки: {currentCurr} / {maxCurr}. {getLoadTime(approximateCurrentTime, maxCurr)}";

    }
}
