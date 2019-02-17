using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// Класс, хранящий перечисление статусов 
    /// загрузки страницы манги
    /// </summary>
    public class PageLoadStatus
    {
        /// <summary>
        /// Статусы загрузки страницы 
        /// </summary>
        public enum status
        {
            Загрузка_успешна = 0,
            Ошибка_во_время_загрузки = 1,
            Некорректный_адрес_запроса = 2,
            Ошибка_получения_страницы = 3,
            Изображение_не_было_найдено_на_странице = 4,
            Загрузка_ещё_не_произошла = 5
        }
    }
}
