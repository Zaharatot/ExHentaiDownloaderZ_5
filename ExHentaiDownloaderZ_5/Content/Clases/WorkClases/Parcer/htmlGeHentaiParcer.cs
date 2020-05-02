using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.Parcer
{
    /// <summary>
    /// Класс парсинга html-страниц сайта exhentai
    /// </summary>
    class htmlGeHentaiParcer
    {
        /// <summary>
        /// Html-код страницы
        /// </summary>
        private string code;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="code">Код страницы</param>
        public htmlGeHentaiParcer(string code)
        {
            this.code = code;
        }


        /// <summary>
        /// Возвращает заголовок страницы
        /// </summary>
        /// <returns>Заголовок страницы</returns>
        public string getTitle()
        {
            string ex = "";

            try
            {
                //Формируем паттерн строки, и получаем первое вхождение
                string title = getFirstEntrance("<title>(.*?)</title>");
                //Удаляем лишние вхождения
                ex = clearString(title, new string[] { "<title>", "</title>" });
                //Удаляем пробелы из начала и конца заголовка
                ex = ex.Trim(' ');
            }
            catch { ex = ""; }

            return ex;
        }



        /// <summary>
        /// Возвращает количество картинок
        /// </summary>
        /// <returns>Количество картинок, в виде строки</returns>
        public string getCountPages()
        {
            string ex = "";

            try
            {
                //Формируем паттерн строки, и получаем первое вхождение
                string count = getFirstEntrance("<p class=\"gpc\">Showing 1 - ([0-9]*?) of ([0-9]*?) images</p>");
                //Удаляем лишние вхождения
                ex = clearString(count, new string[] { "<p class=\"gpc\">Showing 1 - ([0-9]*?) of", "images</p>", " " });
            }
            catch { ex = ""; }

            return ex;
        }


        /// <summary>
        /// Возвращает список ссылок на картинки с текущей страницы
        /// </summary>
        /// <returns>Список ссылок на картинки</returns>
        public List<string> getPagesUrl()
        {
            List<string> ex = new List<string>();

            try
            {
                //Формируем паттерн строки, и получаем первое вхождение
                var urls = getAllEntrances("<a href=\"([\\w:/\\.-]*?)\"><img alt=\"([0-9].*?)\" title=\"(.*?)></a>");

                //Проходимся по списку полученных адресов
                foreach (var url in urls)
                    //Чистим адрес от мусора и добавляем в выходной массив
                    ex.Add(clearString(url, new string[] { "<a href=\"", "\"><img alt=\"([0-9].*?)\" title=\"(.*?)></a>", " " }, false));
            }
            catch { ex = new List<string>(); }

            return ex;
        }




        /// <summary>
        /// Возвращает адрес картинки
        /// </summary>
        /// <returns>Адрес картинки</returns>
        public string getImageUrl()
        {
            string ex = "";

            try
            {
                //Формируем паттерн строки, и получаем первое вхождение
                string url = getFirstEntrance("<img id=\"img\" src=\"(.*?)\" style=\"");
                //Удаляем лишние вхождения
                ex = clearString(url, new string[] { "<img id=\"img\" src=\"", "\" style=\"", "width:", "amp;", " " }, false);
            }
            catch { ex = ""; }

            return ex;
        }

        /// <summary>
        /// Проверка существования следующей страницы
        /// </summary>
        /// <returns>True - существует</returns>
        public bool nextPageExists()
        {
            bool ex = false;

            try
            {
                //Формируем паттерн строки, и получаем первое вхождение
                string td = getFirstEntrance("<td class=\"ptdd\">\\&gt;</td>");
                //Если вхождений нету - значит кнопка перехода на следующую страницу - активна
                ex = (td.Length == 0);
            }
            catch { ex = false; }

            return ex;
        }


        /// <summary>
        /// Возвращает всех вхождения элемента
        /// </summary>
        /// <param name="regex">Код регулярного выражения</param>
        /// <returns>Все случаи вхождения</returns>
        private List<string> getAllEntrances(string regex)
        {
            List<string> ex = new List<string>();

            try
            {
                //Вытягиваем из строки кусок текста регулярным выражением
                var matches = Regex.Matches(code, regex);
                //Проходимся по всем вхождениям, доабвляя элементы в список
                for (int i = 0; i < matches.Count; i++)
                    ex.Add(matches[i].Value);
            }
            catch { ex = new List<string>(); }

            return ex;
        }

        /// <summary>
        /// Вытягиваем из html-кода первое вхождение элемента
        /// </summary>
        /// <param name="regex">Код регулярного выражения</param>
        /// <returns>Первое вхождение, либо пустая строка</returns>
        private string getFirstEntrance(string regex)
        {
            string ex = "";

            try
            {
                //Вытягиваем из строки кусок текста регулярным выражением
                var matches = Regex.Matches(code, regex);
                //Если совпадения найдены
                if (matches.Count > 0)
                    //Возвращаем первый попавшийся элемент
                    ex = matches[0].Value;
            }
            catch { ex = ""; }

            return ex;
        }

        /// <summary>
        /// Удаление, через регулярные выражения
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="regex">Регулярное выражение</param>
        /// <returns>Выходная строка</returns>
        private string regexReplace(string input, string regex)
        {
            string ex = "";

            try
            {
                //Замена символа на упстой регулярным выражением по шаблону
                ex = Regex.Replace(input, regex, "");
            }
            catch { ex = ""; }

            return ex;
        }

        /// <summary>
        /// Очистка текста в строке, от нежелательных символов
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="clearValues">Список дополнительных значений, которые нужно удалить</param>
        /// <param name="clearAdd">True - удаляем дополнительные части</param>
        /// <returns>Очищенная строка</returns>
        private string clearString(string input, string[] clearValues = null, bool clearAdd = true)
        {

            string ex = "";

            try
            {
                //Инициализируем список удаляемых элементов
                List<string> clear = new List<string>();

                //Если есть доп. очистки
                if (clearValues != null)
                    //Добавляем эти значения в основной массив очистки
                    clear.AddRange(clearValues);

                //Добавляем однозначно удаляемые элементы, если это надо
                if (clearAdd)
                    clear.AddRange(new string[] {
                        "&#039;", "&amp;", ":", @"\\", "/", @"\|", ";", @"\*",
                        @"\?", "#", "\"", "<", ">", "'", "\t", "\r", "\n" });

                //Проходимся по массиву и убираем символы
                foreach (string val in clear)
                    input = regexReplace(input, val);

                //Если строка получилась слишком длинная и нужно обрезать - обрезаем её
                if (clearAdd && (input.Length > 100))
                    input = input.Substring(0, 100);

                //Возвращаем значение
                ex = input;
            }
            catch { ex = ""; }

            return ex;
        }
    }
}
