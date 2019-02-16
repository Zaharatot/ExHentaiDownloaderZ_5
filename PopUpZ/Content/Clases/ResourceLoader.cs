using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace PopUpZ.Content.Clases
{
    /// <summary>
    /// Класс загрузки из ресурсов
    /// </summary>
    class ResourceLoader
    {

        /// <summary>
        /// Загружаем текст сообщения
        /// </summary>
        /// <param name="name">Название ресурса</param>
        /// <returns>Строка ресурса</returns>
        public static string loadMessageText(string name)
        {
            string ex = "";

            try
            {
                //Гразим ресурс по имени
                ex = PopupMessages.ResourceManager.GetString(name);
            }
            catch { ex = ""; }

            return ex;
        }

    }
}
