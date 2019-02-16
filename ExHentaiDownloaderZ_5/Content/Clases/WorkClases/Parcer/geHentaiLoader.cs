using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.Parcer
{
    /// <summary>
    /// Класс, реализующий загрузку страниц и изображений с сайта 
    /// exhentai
    /// </summary>
    class geHentaiLoader
    {
        /// <summary>
        /// id пользователя из куков
        /// </summary>
        private string ipb_member_id;
        /// <summary>
        /// Хеш пароля из куков
        /// </summary>
        private string ipb_pass_hash;

        /// <summary>
        /// Инициализиатор класса
        /// </summary>
        /// <param name="ipb_member_id">id пользователя из куков</param>
        /// <param name="ipb_pass_hash">Хеш пароля из куков</param>
        public geHentaiLoader(string ipb_member_id, string ipb_pass_hash)
        {
            this.ipb_member_id = ipb_member_id;
            this.ipb_pass_hash = ipb_pass_hash;
        }


        /// <summary>
        /// Загружаем html-страницу
        /// </summary>
        /// <param name="url">Адрес загрузки</param>
        /// <returns>Html-код страницы</returns>
        public string loadHtmlPage(string url)
        {
            string ex = "";

            try
            {
                //Формируем запрос к сайту
                var request = createRequest(url);
                //Если запрос корректен
                if (request != null)
                {
                    //Получаем ответ от сервера
                    using (WebResponse resp = request.GetResponse())
                    //Получаем поток ответа
                    using (Stream stream = resp.GetResponseStream())
                    //Считываем поток ответа как текст
                    using (StreamReader sr = new StreamReader(stream))
                        ex = sr.ReadToEnd();
                }
            }
            catch { ex = ""; }

            return ex;
        }

        /// <summary>
        /// Грузим файлец, с отправкой всех кук
        /// </summary>
        /// <param name="url">Путь к файлу на серваке</param>
        /// <param name="path">Путь к сохранению файла</param>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        public byte downloadFile(string url, string path)
        {
            byte ex = 1;

            try
            {
                //Формируем запрос к сайту
                var request = createRequest(url);
                //Если запрос корректен
                if (request != null)
                {
                    //Получаем ответ от сервера
                    using (WebResponse resp = request.GetResponse())
                    //Получаем поток ответа
                    using (Stream stream = resp.GetResponseStream())
                    //Создаём файловый поток
                    using (var fs = new FileStream(path, FileMode.Create))
                        //Копируем байты из потока ответа в файловый поток
                        stream.CopyTo(fs);
                    //Всё ок
                    ex = 0;
                }
                else
                    //Ошибка - запрос некорректен
                    ex = 2;
            }
            catch
            {
                ex = 1;
            }

            return ex;
        }

        /// <summary>
        /// Формируем запрос к сайту
        /// </summary>
        /// <param name="url">Адрес запроса</param>
        /// <returns>Тело запроса</returns>
        private HttpWebRequest createRequest(string url)
        {
            HttpWebRequest ex = null;

            try
            {
                //Формируем uri из адреса
                Uri address = new Uri(url);

                //Формируем запрос по указанному адресу
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                //Инициализируем контейнер для куков
                CookieContainer cc = new CookieContainer();
                //ЗАписываем необходимые куки
                cc.Add(address, new Cookie("nw", "1"));
                cc.Add(address, new Cookie("ipb_member_id", ipb_member_id));
                cc.Add(address, new Cookie("ipb_pass_hash", ipb_pass_hash));
                //Добавляем контекнер с куками в запрос
                request.CookieContainer = cc;
                //Возвращаем сформированынй запрос
                ex = request;
            }
            catch { ex = null; }

            return ex;
        }



        /// <summary>
        /// Добавляем id страницы в путь
        /// </summary>
        /// <param name="url">Корневой адрес</param>
        /// <param name="id">id страницы</param>
        /// <returns>Полный путь к странице</returns>
        public string compileUrlWithId(string url, int id)
        {
            string ex = "";

            try
            {
                //Формируем путь c id страницы
                ex = $"{url}?p={id}";
            }
            catch { ex = ""; }

            return ex;
        }



        /// <summary>
        /// Возвращаем формат файла (с точкой) из строки адреса
        /// </summary>
        /// <param name="url">Строка адреса</param>
        /// <returns>Формат файла</returns>
        public string getExtWithUrl(string url)
        {
            string ex = ".jpg";

            try
            {
                //Если адрес имеет длинну
                if (url.Length > 10)
                {
                    //Формируем URI по адресу
                    Uri uu = new Uri(url);
                    //Получаем информацию о файле
                    ex = new FileInfo(uu.LocalPath).Extension;
                }
            }
            catch { ex = ".jpg"; }

            return ex;
        }
    }
}
