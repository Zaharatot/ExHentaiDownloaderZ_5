using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExHentaiDownloaderZ_5.Content.Clases.DataClases;
using Resources;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases
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
            //   notify.play();
            //Выводим сообщение и возвращаем результат
            return pf.ShowDialog();
        }

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
                            //Сообщение о завершении загрузки
                            info = new PopupMessageInfo() {
                                message = PopupMessages.DownloadComplete,
                                header = PopupHeaders.Done,
                                buttons = MessageBoxButtons.OK
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
