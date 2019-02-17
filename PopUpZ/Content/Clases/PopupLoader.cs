using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopUpZ.Content.Forms;
using Resources;
using System.Media;

namespace PopUpZ.Content.Clases
{
    /// <summary>
    /// Класс загрузки и вывода окна с сообщением
    /// </summary>
    public class PopupLoader
    {

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="f">Шрифт fontAwewsome</param>
        public PopupLoader()
        {

        }

        /// <summary>
        /// Выводим всплывающее сообщение
        /// </summary>
        /// <param name="code">Код сообщения</param>
        /// <param name="result">Код результата</param>
        /// <returns>Результатт выполнения</returns>
        public DialogResult showMessage(int code, int result = 0)
        {
            //Инициализируем новую форму
            PopUp pf = new PopUp();
            //Инициализируем внешний вид сообщения
            initMessage(code, result, pf);
            //Проигрываем звук сообщения
            SystemSounds.Asterisk.Play();
            //Выводим сообщение и возвращаем результат
            return pf.ShowDialog();
        }

        /*
            0 - Сообщение о завершении загрузки.
            1 - Результат загрузки манги
            2 - Результат сохранения манги
            3 - Ошибка - не было выбрано ни одной строки, при удалении манги из списка.
            4 - Запрос на очистку списка манги.
            5 - Запрос подтверждения выхода из программы, в случае, если идёт загрузка.
            6 - Запрос сброса настроек на дефолтные.
            7 - Сообщение о завершении загрузки
            8 - Запрашиваем обновление пути
        */

        /// <summary>
        /// Получаем заголовок по результату
        /// </summary>
        /// <param name="result">Резальтат операции</param>
        /// <returns>Строка заголовка</returns>
        private string getHeaderByCode(int result) =>
            (result == 0) ? PopupHeaders.Done : PopupHeaders.Error;

        /// <summary>
        /// Инициализируем сообщение, под нужные нам параметры
        /// </summary>
        /// <param name="code">Код сообщения</param>
        /// <param name="result">Код результата</param>
        /// <param name="pf">Форма сообщения</param>
        private void initMessage(int code, int result, PopUp pf)
        {
            PopupMessageInfo info = new PopupMessageInfo();

            try
            {
                //Выбираем функцию получения значений сообщения
                switch (code)
                {
                    case 0:
                        {
                            // Сообщение о завершении загрузки
                            info = new PopupMessageInfo() {
                                message = PopupMessages.DownloadComplete,
                                header = PopupHeaders.Done,
                                buttons = MessageBoxButtons.OK
                            };
                            break;
                        }
                    case 1:
                        {
                            // Результат загрузки манги
                            info = new PopupMessageInfo()
                            {
                                message = ResourceLoader.loadMessageText("loadComplete_" + result.ToString()),
                                header = getHeaderByCode(result),
                                buttons = MessageBoxButtons.OK
                            };
                            break;
                        }
                    case 2:
                        {
                            // Результат сохранения манги
                            info = new PopupMessageInfo()
                            {
                                message = ResourceLoader.loadMessageText("saveComplete_" + result.ToString()),
                                header = getHeaderByCode(result),
                                buttons = MessageBoxButtons.OK
                            };
                            break;
                        }
                    case 3:
                        {
                            // Ошибка - не было выбрано ни одной строки, при удалении манги из списка.
                            info = new PopupMessageInfo()
                            {
                                message = PopupMessages.RemoveError,
                                header = PopupHeaders.Error,
                                buttons = MessageBoxButtons.OK
                            };
                            break;
                        }
                    case 4:
                        {
                            // Запрос на очистку списка манги.
                            info = new PopupMessageInfo()
                            {
                                message = PopupMessages.ClearQuestion,
                                header = PopupHeaders.ClearQuestion,
                                buttons = MessageBoxButtons.YesNo
                            };
                            break;
                        }
                    case 5:
                        {
                            // Запрос подтверждения выхода из программы, в случае, если идёт загрузка.
                            info = new PopupMessageInfo()
                            {
                                message = PopupMessages.CloseQuestion,
                                header = PopupHeaders.CloseQuestion,
                                buttons = MessageBoxButtons.YesNo
                            };
                            break;
                        }
                    case 6:
                        {
                            // Запрос сброса настроек на дефолтные.
                            info = new PopupMessageInfo()
                            {
                                message = PopupMessages.CanselSettingsQuestion,
                                header = PopupHeaders.CanselSettingsQuestion,
                                buttons = MessageBoxButtons.YesNo
                            };
                            break;
                        }
                    case 7:
                        {
                            // Сообщение о завершении загрузки
                            info = new PopupMessageInfo()
                            {
                                message = ResourceLoader.loadMessageText("SaveSettings_" + result.ToString()),
                                header = getHeaderByCode(result),
                                buttons = MessageBoxButtons.OK
                            };
                            break;
                        }
                    case 8:
                        {
                            // Запрашиваем обновление пути
                            info = new PopupMessageInfo()
                            {
                                message = PopupMessages.ResetPathQuestion,
                                header = PopupHeaders.ResetPathQuestion,
                                buttons = MessageBoxButtons.YesNo
                            };
                            break;
                        }
                    default:
                        {
                            //Ошибка - неизвестный код сообщения
                            info = new PopupMessageInfo()
                            {
                                message = PopupMessages.MessageError,
                                header = PopupHeaders.Error,
                                buttons = MessageBoxButtons.OK
                            };
                            
                            break;
                        }
                }

                //Инициализируем форму сообщения
                pf.initForm(info);
            }
            catch { MessageBox.Show("Error!", "Unknown error while generating the message"); }

        }



    }
}
