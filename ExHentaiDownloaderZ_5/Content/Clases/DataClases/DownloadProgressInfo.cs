using ExHentaiDownloaderZ_5.Content.Clases.WorkClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;


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
        /// Среднее время загрузки страницы манги в секундах
        /// </summary>
        public decimal approximateLoadTime { get; set; }
        /// <summary>
        /// Оставшееся для загрузки количество страниц манги
        /// </summary>
        public int countPages { get; set; }

        /// <summary>
        /// Текущий шаг загрузки
        /// </summary>
        public DownloadStep.Steps step { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DownloadProgressInfo()
        {
            //Проставляем дефолтные значения
            finalFlag = false;
            countPages = currentCurr = currentFull = maxCurr = maxFull = 0;
            approximateLoadTime = -1;
            step = DownloadStep.Steps.Сбор_ссылок;
        }


        /// <summary>
        /// Получаем строку с названием шага
        /// </summary>
        /// <returns>Строка статуса</returns>
        private string getStatusString() =>
            ResourceLoader.loadStatusText("DownloadStep_" + ((int)step).ToString());

        /// <summary>
        /// Возвращает строку со временем
        /// </summary>
        /// <param name="time">Количество секунд</param>
        /// <returns>Красивая строка с овременем</returns>
        private string getTime(int time)
        {
            //Чисто по фану - дефолтное значение
            string ex = StatisticText.TimeInfinity;

            try
            {
                //Если время не дефолтное
                if (time > 0)
                {
                    //Если меньше минуты
                    if (time < 60)
                        ex = StatisticText.TimeLessMinute;
                    //Больше 1 минуты - идём в минуты
                    else
                    {
                        //Получаем минуты
                        time /= 60;
                        //Если меньше часа
                        if (time < 60)
                            ex = $"{time.ToString()} {StatisticText.TimeMinutes}";
                        //Больше 1 часа - идём в часы
                        else
                        {
                            //Получаем Часы
                            time /= 60;
                            //Если меньше суток
                            if (time < 24)
                                ex = $"{time.ToString()} {StatisticText.TimeHours} ";
                            //Если больше 1 дня, то считаем в днях
                            else
                            {
                                //Получаем дни
                                time /= 24;
                                ex = $"{time.ToString()} {StatisticText.TimeDays} ";
                            }
                        }
                    }
                }
            }
            catch { }


            return ex;
        }


        /// <summary>
        /// Получаем общее время загрузки
        /// </summary>
        /// <returns>Строка времени загрузки</returns>
        public string getLoadTime()
        {
            //Получаем время загрузки в секундах
            int loadTime = (int)(approximateLoadTime * countPages);
            //Выводим в красивом формате
            return $"{StatisticText.TimeLeft} {getTime(loadTime)}";
        }
        
        /// <summary>
        /// Возврат общей строки статуса 
        /// </summary>
        /// <returns>Текст общей строки</returns>
        public string getFullStatus() =>
            $"{StatisticText.DownloadStatus} {currentFull} / {maxFull}";

        /// <summary>
        /// Возврат текущей строки статуса 
        /// </summary>
        /// <returns>Текст текущей строки</returns>
        public string getCurrentStatus() =>
            $"{StatisticText.DownloadStatusCurrent} {currentCurr} / {maxCurr}";


        /// <summary>
        /// Возвращаем текущий шаг загрузки
        /// </summary>
        /// <returns>Строка с описанием шага</returns>
        public string getStep() =>
            $"{StatisticText.CurrentStep} { getStatusString() }";
    }
}
