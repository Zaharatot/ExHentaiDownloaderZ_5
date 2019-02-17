using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// Класс, хранящий перечисление шагов загрузки
    /// </summary>
    class DownloadStep
    {
        /// <summary>
        /// Перечисление шагов загрузки
        /// </summary>
        public enum Steps
        {
            Сбор_ссылок = 0,
            Загрузка_информации_о_манге = 1,
            Загрузка_страниц_манги = 2,
            Проверка_статусов_загрузки = 3
        }
    }
}
