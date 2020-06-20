using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ExHentaiDownloaderZ_5.Content.Clases.DataClases;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.Parcer
{
    /// <summary>
    /// Класс парсинга html-страниц сайта exhentai
    /// </summary>
    class htmlGeHentaiParcer_NEW
    {

        /// <summary>
        /// Список статусов получения адреса следующей страницы
        /// </summary>
        public enum FindNextUrlStatus
        {
            /// <summary>
            /// Проставляется в случае, если на текущей странице
            /// есть ссылка на следующую
            /// </summary>
            Страница_найдена,
            /// <summary>
            /// Проставляется при ошибках загрузки адреса
            /// следующей страницы галереи
            /// </summary>
            Ошибка_получения_адреса_страницы,
            /// <summary>
            /// Проставляется в случае, если на странице больше нет кнопки
            /// перехода на следующую страницу галереи
            /// </summary>
            Последняя_страница
        }

        /// <summary>
        /// Наш объект HTML-документа
        /// </summary>
        private IHtmlDocument document;
        /// <summary>
        /// Класс очистки строк
        /// </summary>
        private HtmlCleaner cleaner;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="code">Код страницы</param>
        public htmlGeHentaiParcer_NEW(string code)
        {
            //Инициализируем класс очистки
            cleaner = new HtmlCleaner();
            //Инициализируем контекст браузера с дефолтными параметрами
            var context = BrowsingContext.New(Configuration.Default);
            //Инициализируем парсер
            var parser = context.GetService<IHtmlParser>();
            //Парсим документ
            document = parser.ParseDocument(code);
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
                //Получаем название
                ex = cleaner.ClearString(document.Title);
            }
            catch { ex = ""; }

            return ex;
        }



        /// <summary>
        /// Возвращает количество картинок
        /// </summary>
        /// <returns>Количество картинок, в виде строки</returns>
        public int getCountPages()
        {
            int ex = -1;
            try
            {
                //Получаем первый попавшийся тег "<p>", с классом "gpc"
                var countInfo = document.QuerySelector("p.gpc");
                //Если информация была получена
                if (countInfo != null)
                {
                    //Showing 1 - 17 of 17 images
                    //Получаем строку содержимого и чистим её от лишнего
                    string count = cleaner.ClearString(countInfo.TextContent, new string[] {
                        "Showing 1 - ",
                        "images"
                    });
                    //Если строка была получена корректно
                    if ((count != null) && (count.Length > 0))
                    {
                        //Сплитим строку на 2 части
                        string[] parts = count.Split(new string[] { " of " },
                            StringSplitOptions.RemoveEmptyEntries);
                        //Если с частями всё в порядке
                        if (parts.Length == 2)
                            //Парсим вторую часть строки
                            ex = cleaner.ParseIntValue(parts[1]);
                    }
                }
            }
            catch { ex = -1; }
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
                //Получаем все div-ы с картинками
                var pages = document.QuerySelectorAll("div.gdtl");
                //Если div-ы получены
                if (pages != null)
                {
                    //Проходимся по их списку
                    for (int i = 0; i < pages.Length; i++)
                        //Парсим инфу о картинке и втыкаем в список
                        ex.Add(ParceImageInfo(pages[i]));
                }
            }
            //При ошибках
            catch { ex = new List<string>(); }

            return ex;
        }



        /// <summary>
        /// Парсим информацию о картинке на странице галереи
        /// </summary>
        /// <param name="page">Div с информацией</param>
        /// <returns>Класс информации о картинке</returns>
        private string ParceImageInfo(IElement page)
        {
            string ex = "";
            //Если дочерние элементы есть
            if (page.ChildElementCount != 0)
            {
                //Получаем первый (он там 1) - это ссылка
                var href = page.Children[0];
                //Получаем строку ссылки на страницу картинки
                ex = href.GetAttribute("href");
            }
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
                //Если нужно искать полный размер файла
                if (Program.settingsStorage.settings.tryFindOriginalSize)
                {
                    //Путаемся получить адрес картинки в полном размере
                    string fullUrl = GetFullImageUrl();
                    // если нет адреса полной кратинки
                    if (fullUrl == null)
                        //Загружаем ссылку на оригинальный размер картинки
                        ex = GetOriginalSizeImageUrl();
                    //Если всё ок
                    else
                        //Возвращаем адрес полного размера
                        ex = fullUrl;
                }
                //Если нужен только обычный размер
                else
                    //Загружаем ссылку на оригинальный размер картинки
                    ex = GetOriginalSizeImageUrl();
            }
            catch { ex = ""; }

            return ex;
        }

        /// <summary>
        /// Загружаем ссылку на оригинальный размер картинки
        /// </summary>
        /// <returns>Адрес картинки</returns>
        private string GetOriginalSizeImageUrl()
        {
            string ex = "";


            try
            {
                //Получаем нужный тег
                var img = document.QuerySelector("img#img");
                //Если тег получен
                if (img != null)
                    //Получаем ссылку на основную картинку
                    ex = img.GetAttribute("src");
            }
            catch { ex = ""; }

            return ex;
        }

        /// <summary>
        /// Получаем адрес фулловой картинки
        /// </summary>
        /// <returns>Строка адреса полной версии  картинки</returns>
        private string GetFullImageUrl()
        {
            string ex = null;

            try
            {
                //Получаем все ссылки со страницы
                var hrefs = document.QuerySelectorAll("a");
                //Еслы ссылки были найдены
                if (hrefs != null)
                {
                    //Получаем первую, в описании которой предлагают скачать фулл
                    var first = hrefs.FirstOrDefault(hr =>
                        (hr.TextContent.Contains("Download original")));
                    //Если найдена ссылка на фулл
                    if (first != null)
                        //Получаем адрес ссылки
                        ex = first.GetAttribute("href");
                }
            }
            catch { ex = null; }

            return ex;
        }

        /// <summary>
        /// Получаем оригинальное имя файла
        /// </summary>
        /// <returns>Строка имени</returns>
        public string GetOriginalFileName()
        {
            string ex = null;

            try
            {
                //Получаем верхний блок управленяи страницей
                var block = document.QuerySelector("#i2");
                //Еслы блок был найден
                if (block != null)
                {
                    //Получаем DIV в котором находится текст описания картинки
                    var infoElem = GetNameElem(block);
                    //Если информация была найдена
                    if (infoElem != null)
                    {
                        //Получаем текст элемента
                        string infoString = infoElem.TextContent;
                        //Если строка информации была получена корректно
                        if((infoString != null) && (infoString.Length > 0))
                        {
                            //02.jpg :: 1280 x 1946 :: 485.7 KB
                            //Сплитим строку по разделителю
                            string[] parts = infoString.Split(
                                new string[] { " :: " }, 
                                StringSplitOptions.RemoveEmptyEntries
                            );
                            //Если все части были получены
                            if ((parts != null) && (parts.Length == 3))
                                //Возвращаем строку имени файла
                                ex = parts[0];
                        }
                    }
                }
            }
            catch { ex = null; }

            return ex;
        }

        /// <summary>
        /// Получаем элемент с имененм файла
        /// </summary>
        /// <param name="parent">Родительский элемент</param>
        /// <returns>Элемент с именем файла</returns>
        private IElement GetNameElem(IElement parent)
        {
            IElement ex = null;
            //Если есть дочерние элементы
            if(parent.ChildElementCount > 0)
            {
                //Проходимся по дечерним элементам
                foreach(IElement elem in parent.Children)
                    //Если у элемента нету дочерних
                    if(elem.ChildElementCount == 0)
                    {
                        //Возвращаем его
                        ex = elem;
                        //И выходим из цикла
                        break;
                    }
            }

            return ex;
        }


        /// <summary>
        /// Получаем ссылку на следующую страницу
        /// </summary>
        /// <param name="result">Результирующая ссылка</param>
        /// <returns>
        /// 3 варианта возврата:
        ///     0 - Всё ок
        ///     1 - Ошибка во время выполнения
        ///     2 - Ссылок больше нет
        /// </returns>
        public FindNextUrlStatus GetNextPageUrl(out string result)
        {
            FindNextUrlStatus ex = FindNextUrlStatus.Ошибка_получения_адреса_страницы;
            result = "";

            try
            {
                //Получаем табличку листания
                var table = document.QuerySelector("table.ptt");
                //Если мы получили таблицу
                if (table != null)
                {
                    //Получаем все ссылки из неё
                    var links = table.QuerySelectorAll("a");
                    //Если ссылки получены
                    if (links != null)
                    {
                        //Получаем ссылку на следующую страницу
                        var nextLink = links.FirstOrDefault(ln => (ln.TextContent == ">"));
                        //Если ссылка есть
                        if (nextLink != null)
                        {
                            //Получаем из неё адрес следующей страницы
                            result = nextLink.GetAttribute("href");
                            //Всё ок
                            ex = FindNextUrlStatus.Страница_найдена;
                        }
                        else
                            //Ссылки нет - страницы закончились
                            ex = FindNextUrlStatus.Последняя_страница;
                    }
                }
            }
            catch { }

            return ex;
        }

    }
}
