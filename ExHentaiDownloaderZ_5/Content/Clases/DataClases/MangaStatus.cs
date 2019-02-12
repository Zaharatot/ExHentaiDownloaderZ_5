using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// Класс, хранящий перечисление статусов щагрузки манги
    /// </summary>
    class MangaStatus
    {
        /// <summary>
        /// Перечисление статусов загрузки манги
        /// </summary>
        public enum status
        {
            Манга_добавлена = 0,
            Общая_ошибка_загрузки = 1,
            Ошибка_загрузки_информации = 2,
            Ошибка_загрузки_страниц = 3,
            Загрузка_завершена = 4,
            Страницы_проверены = 5,
            Ошибка_количества_страниц = 6
        }
    }
}
