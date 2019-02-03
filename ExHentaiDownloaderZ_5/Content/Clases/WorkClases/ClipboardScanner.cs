﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases
{
    /// <summary>
    /// Класс, выполняющий сканирование буфера обмена, на 
    /// предмет ссылок с нужного сайта
    /// </summary>
    class ClipboardScanner
    {
        /// <summary>
        /// Делегат события догрузки url
        /// </summary>
        public delegate void FindUrlEventHandler(string url);

        /// <summary>
        /// Событие получения url
        /// </summary>
        public event FindUrlEventHandler findUrl;

        /// <summary>
        /// Таймер получения адресов
        /// </summary>
        Thread getUrlTimer;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ClipboardScanner()
        {
            //Инициализация таймера получения адресов
            getUrlTimer = new Thread(getUrls);
            getUrlTimer.SetApartmentState(ApartmentState.STA);
        }

        /// <summary>
        /// Запуск таймера получения адресов
        /// </summary>
        public void start()
        {
            //Запускаем таймер, с секундным интервалом
            if (getUrlTimer != null)
                getUrlTimer.Start();
        }

        /// <summary>
        /// Остановка таймера получения адресов
        /// </summary>
        public void stop()
        {
            //Стопаем таймер, если он вообще был проинициализщирован
            if (getUrlTimer != null)
                getUrlTimer.Abort();
        }

        /// <summary>
        /// Проверка текста на то, что это корректный адрес
        /// </summary>
        /// <param name="text">Текст, из буфера обмена</param>
        /// <returns>True - если текст - это адрес на форчане</returns>
        private bool testClipboardText(string text)
        {
            bool ex = false;
            try
            {
                //Чекаем, чтобы текст был адресом, и, чтобы он имел 4чан в названии.
                //И ещё - отсечение слишком длинных строк
                ex = (text.Length < 500) && Uri.IsWellFormedUriString(text, UriKind.RelativeOrAbsolute) &&
                    (text.Contains("g.e-hentai.org") || text.Contains("exhentai.org"));
            }
            catch { }

            //Проверка дубовая, но сойдёт
            return ex;
        }

        /// <summary>
        /// Функция таймера
        /// </summary>
        private void getUrls()
        {
            do
            {
                try
                {
                    //Получаем текст из буфера обмена
                    var clipboardText = Clipboard.GetText();
                    //Проверяем текст, на то, что он является адресом в форчан
                    if (testClipboardText(clipboardText))
                        //Вызываем событие нахождения адреса
                        findUrl?.Invoke(clipboardText);
                }
                catch { }

                Thread.Sleep(1000);
            } while (true);
        }
    }
}
