using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases
{
    /// <summary>
    /// Класс загрузки из ресурсов
    /// </summary>
    class ResourceLoader
    {

        /// <summary>
        /// Загружаем текст статуса
        /// </summary>
        /// <param name="name">Название ресурса</param>
        /// <returns>Строка ресурса</returns>
        public static string loadStatusText(string name)
        {
            string ex = "";

            try
            {
                //Гразим ресурс по имени
                ex = StatisticText.ResourceManager.GetString(name);
            }
            catch { ex = ""; }

            return ex;
        }

    }
}
