using ExHentaiDownloaderZ_5.Content.Clases.DataClases;
using ExHentaiDownloaderZ_5.Content.Clases.WorkClases.Parcer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases
{
    /// <summary>
    /// Основной рабочий класс
    /// </summary>
    class mainWorker
    {
        /// <summary>
        /// Делей между подгрузками страниц на корневой
        /// при получении полного списка страниц манги
        /// </summary>
        private const int rootPageLoadDelay = 2000;
        /// <summary>
        /// Делей между подгрузками информации о каждой
        /// из манг в списке
        /// </summary>
        private const int mangaInfoLoadDelay = 3000;
        /// <summary>
        /// Делей между загрузками разных манг
        /// </summary>
        private const int downloadMangaDelay = 10000;
        /// <summary>
        /// Делей между загрузками страниц манги
        /// </summary>
        private const int downloadMangaPageDelay = 2000;

        /// <summary>
        /// Класс сканера буфера обмена
        /// </summary>
        private ClipboardScanner cs;
        /// <summary>
        /// Класс, реализующий загрузку всякого
        /// </summary>
        private geHentaiLoader loader;
        /// <summary>
        /// Путь к папке, куда качаем
        /// </summary>
        private string downloadPath;

        /// <summary>
        /// Список манги, которую нужно загрузить
        /// </summary>
        private List<manga> downloadList;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="downloadPath">Путь к папке загрузки, без слеша</param>
        public mainWorker(string downloadPath)
        {
            //Инициализируем сканер буфера обмена
            cs = new ClipboardScanner();
            //Инициализируем класс загрузки
            loader = new geHentaiLoader("2279705", "264fea3a06727ea0cd68b52867415b43");
            //Запоминаем путь
            this.downloadPath = downloadPath;
            //Инициализиурем список манги для загрузки
            downloadList = new List<manga>();
        }

        /// <summary>
        /// Загружаем информацию о манге
        /// </summary>
        /// <param name="info">Информация о манге</param>
        /// <returns>ЗЩагруженная инфомрация о манге</returns>
        private manga loadMangaInfo(manga info)
        {
            //Объявляем переменные
            bool complete;
            string pageUrl, code;
            int pageId;
            List<string> buff;
            htmlGeHentaiParcer hp;

            try
            {
                //Загружаем страницу 
                code = loader.loadHtmlPage(info.url);
                //Инициализируем парсер 
                hp = new htmlGeHentaiParcer(code);

                //Если страница была загружена корректно
                if (code.Length > 0)
                {
                    //Получаем название манги
                    info.name = hp.getTitle();
                    //Получаем и парсим количество страниц
                    info.countPages = otherFuncs.parceInt(hp.getCountPages());
                    //Прописываем путь загрузки
                    info.setRootPath(downloadPath);
                    //Ставим дефолтные значения получения страниц
                    complete = true;
                    pageId = 0;

                    //В цикле подгружаем все страницы манги
                    do
                    {
                        //Получаем картинки с текущей страницы
                        buff = hp.getPagesUrl();
                        //Добавляем их в основной список
                        addMangaPages(buff, ref info);
                        //Если есть ещё одна страница - продолжаем загрузку
                        complete = hp.nextPageExists();
                        //Если страница есть
                        if (complete)
                        {
                            //Спим, чтобы сайт особо не бузил
                            Thread.Sleep(rootPageLoadDelay);
                            //Переходим к id новой страницы
                            pageId++;
                            //Формируем путь к новой странице
                            pageUrl = loader.compileUrlWithId(info.url, pageId);
                            //Загружаем страницу 
                            code = loader.loadHtmlPage(pageUrl);
                            //Если ошибка загрузки страницы
                            if (code.Length == 0)
                            {
                                //ОШибка - во время загрузки списка страниц манги
                                info.status = 3;
                                //То выходим из цикла
                                break;
                            }
                            //Инициализируем парсер 
                            hp = new htmlGeHentaiParcer(code);
                        }
                        //Если нужно ещё допарсить картинок
                    } while (complete);

                    //Манга загружена корректно
                    info.status = 4;
                }
                else
                    //Ошибка - корневая страница не была загружена
                    info.status = 2;
            }
            catch
            {
                info.status = 1;
            }

            return info;
        }

        /// <summary>
        /// Добавляем страницы к манге
        /// </summary>
        /// <param name="pages">Список адресов страниц</param>
        /// <param name="mn">Инфомрация о манге</param>
        private void addMangaPages(List<string> pages, ref manga mn)
        {
            //Проходимся по списку адресов
            foreach (var url in pages)
                //Добавляем информацию о странице манги
                mn.addpage(url);
        }

        /// <summary>
        /// Загружаем мангу
        /// </summary>
        /// <param name="info">Информация о манге</param>
        private void loadManga(ref List<manga> info)
        {
            try
            {
                //Проходимся по списку манги
                for (int i = 0; i < info.Count; i++)
                {
                    //Загружаем информацию о манге
                    info[i] = loadMangaInfo(info[i]);
                    //Спим, чтобы сайт особо не бузил
                    Thread.Sleep(mangaInfoLoadDelay);
                }
            }
            catch { }
        }

        /// <summary>
        /// Загружаем страницу манги
        /// </summary>
        /// <param name="url">Адрес страницы</param>
        /// <param name="path">Путь сохранения кратинки со страницы</param>
        /// <param name="id">Id страницы в списке</param>
        /// <returns>0 - всё ок, оначе - ошибка загрузки</returns>
        private byte downloadPage(string url, string path, int id)
        {
            byte ex = 1;
            string imageUrl, code, ext, imagePath;

            try
            {
                //Загружаем страницу 
                code = loader.loadHtmlPage(url);
                //Если страница была загружена
                if (code.Length > 0)
                {
                    //Инициализируем парсер 
                    var hp = new htmlGeHentaiParcer(code);

                    //Загружаем адрес картинки
                    imageUrl = hp.getImageUrl();
                    //Если мы получили адрес картинки
                    if (imageUrl.Length > 0)
                    {
                        //Получаем расишрение файла
                        ext = loader.getExtWithUrl(imageUrl);
                        //Формируем путь загрузки
                        imagePath = $"{path}{id}{ext}";
                        //Грузим страницу, и получаем результат
                        ex = loader.downloadFile(imageUrl, imagePath);
                    }
                    else
                        //Ошибка - адрес картинки не был найден
                        ex = 4;
                }
                else
                    //Ошибка - страница не была загружена
                    ex = 3;
            }
            catch { ex = 1; }

            return ex;
        }


        /// <summary>
        /// Загружаем страницы манги
        /// </summary>
        /// <param name="info">Список манги, которую нужно загрузить</param>
        private void downloadPages(ref List<manga> info)
        {
            byte result;
            List<string> files;
            string fileName;

            //Проходимся по списку манги
            for (int i = 0; i < info.Count; i++)
            {
                //Если данная манга ещё не была загружена,
                //и её статус - корректен
                if (info[i].status == 4)
                {
                    //Получаем список файлов
                    files = getDirectoryFileNames(info[i].rootPath);
                    //Проходимся по страницам манги
                    for (int j = 0; j < info[i].pages.Count; j++)
                    {
                        //Грузим, если данная страница ещё не была загружена
                        if (!info[i].pages[j].loaded)
                        {
                            //Получаем имя файла
                            fileName = j.ToString();

                            //Если файл не найден в папке
                            if (files.Count(fi => (fi.Equals(fileName))) == 0)
                            {
                                //Грузим страницу, и получаем результат
                                result = downloadPage(info[i].pages[j].url, info[i].rootPath, j);
                                //Возвращаем результат загрузки
                                info[i].pages[j].loaded = (result == 0);
                                //Спим, чтобы сайт особо не бузил
                                Thread.Sleep(downloadMangaPageDelay);
                            }
                            //Если файл в папке таки есть
                            else
                                //Проставляем что он всё-таки есть!
                                info[i].pages[j].loaded = true;
                        }
                    }

                    //Если манга была загружена 
                    if (info[i].checkLoad())
                        //Если количество страниц совпадает - то всё ок
                        //Иначе - ставим статус о несовпадении
                        info[i].status = (byte)((info[i].checkCount()) ? 5 : 6);

                    //Спим, чтобы сайт особо не бузил
                    Thread.Sleep(downloadMangaDelay);
                }
            }
        }

        /// <summary>
        /// Получаем список имён файлов из папки, удостоверяясь 
        /// что она реально существует
        /// </summary>
        /// <param name="path">Путь к папке</param>
        /// <returns>Список имён файлов</returns>
        private List<string> getDirectoryFileNames(string path)
        {
            List<string> ex = new List<string>();

            try
            {
                //ИНициализируем информацию о директории
                DirectoryInfo di = new DirectoryInfo(path);
                //Формируем путь к загрузке манги, если его не существет
                di.Create();
                //Получаем список файлов в директории
                var files = di.GetFiles().ToList();
                //Проходимся по списку файлов
                foreach (var file in files)
                    //И добавляем в список только имя, без расширения
                    ex.Add(file.Name.Replace(file.Extension, ""));
            }
            catch { ex = new List<string>(); }

            return ex;
        }

        /// <summary>
        /// Добавляем мангу в список
        /// </summary>
        /// <param name="url">Адрес манги</param>
        public void addMangaToList(string url)
        {
            //Чистим адрес от лишних частей
            url = loader.verificateUrl(url);
            //Добавляем информацию о манге
            downloadList.Add(new manga(url));
        }

        /// <summary>
        /// Очищаем список загрузки
        /// </summary>
        public void clearMangaList()
        {
            downloadList.Clear();
        }

        /// <summary>
        /// Загружаем информацию о манге
        /// </summary>
        public void downloadManga()
        {
            new Thread(() => {
                //Загружаем информацию о манге
                loadManga(ref downloadList);
                //Загружаем страницы манги
                downloadPages(ref downloadList);

                System.Windows.Forms.MessageBox.Show("Fin");
            }).Start();
        }
    }
}
