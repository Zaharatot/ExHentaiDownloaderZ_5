using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopUpZ.Content.Clases
{
    /// <summary>
    /// Класс информации о всплывающем сообщении
    /// </summary>
    public class PopupMessageInfo
    {
        /// <summary>
        /// Заголовок сообщения
        /// </summary>
        public string header { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Список кнопок в попапе
        /// </summary>
        public MessageBoxButtons buttons { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public PopupMessageInfo()
        {
            //Инициализируем дефолтными значениями
            header = message = "";
            buttons = MessageBoxButtons.OK;
        }
    }
}
