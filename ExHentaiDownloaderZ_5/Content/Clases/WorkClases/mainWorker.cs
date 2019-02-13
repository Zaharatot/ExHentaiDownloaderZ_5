using ExHentaiDownloaderZ_5.Content.Clases.DataClases;
using ExHentaiDownloaderZ_5.Content.Clases.WorkClases.Parcer;
using ExHentaiDownloaderZ_5.Content.Clases.WorkClases.SaveFile;
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
        /// Делегат события обновления информации о загрузке манги
        /// </summary>
        /// <param name="downloadInfo">ИНформация о процессе загрузки</param>
        /// <param name="mangaTable">Список манги, для вывода в таблицу</param>
        public delegate void updateDownload(DownloadProgressInfo downloadInfo, List<TableMangaInfo> mangaTable);
        /// <summary>
        /// Событие обновления процесса загрузки манги
        /// </summary>
        public event updateDownload onUpdateDownload;

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
        /// Дефолтная средняя скорость загрузки страницы манги
        /// </summary>
        private const int defaultAverageLoadTime = 5;
        /// <summary>
        /// Дефолтная средняя скорость загрузки информации о манге
        /// </summary>
        private const int defaultAverageLoadInfoTime = 5;

        /// <summary>
        /// Класс сканера буфера обмена
        /// </summary>
        private ClipboardScanner cs;
        /// <summary>
        /// Класс, реализующий загрузку всякого
        /// </summary>
        private geHentaiLoader loader;
        /// <summary>
        /// Класс сохранения и загрузки
        /// </summary>
        XmlWorker xw;

        /// <summary>
        /// Путь к папке, куда качаем
        /// </summary>
        private string downloadPath;
        /// <summary>
        /// Текущий шаг работы
        /// </summary>
        private DownloadStep.Steps workStep;
        /// <summary>
        /// Основной рабочий поток
        /// </summary>
        private Thread main;

        /// <summary>
        /// Список манги, которую нужно загрузить
        /// </summary>
        private List<manga> downloadList;

        /// <summary>
        /// Средняя скорость загрузки страницы манги
        /// </summary>
        private decimal averageLoadTime;
        /// <summary>
        /// Средняя скорость загрузки информации о манге
        /// </summary>
        private decimal averageLoadInfoTime;



        /// <summary>
        /// Конструктор класса
        /// </summary>
        public mainWorker()
        {
            //Инициализируем сканер буфера обмена
            cs = new ClipboardScanner();
            //ИНициализируем класс сохранения/загрузки
            xw = new XmlWorker();
            //Инициализиурем список манги для загрузки
            downloadList = new List<manga>();
            //Ставим шаг в режим сбора ссылок
            workStep = DownloadStep.Steps.Сбор_ссылок;
            //Ставим время загрузки страницы в дефолтное
            averageLoadTime = defaultAverageLoadTime;
            averageLoadInfoTime = defaultAverageLoadInfoTime;
            //Добавляем обработчик события нахождения ссылки в буфере обмена
            cs.findUrl += Cs_findUrl;

            //Запускаем загрузку манги
            loadManga();
            //Запускаем поиск ссылок
            cs.start();
        }
        
        /// <summary>
        /// Событие нахождения адреса страницы манги в буфере обмена
        /// </summary>
        /// <param name="url">Полученный из буфера адрес</param>
        private void Cs_findUrl(string url)
        {
            //Ссылки не могут добавляться во время работы
            if(workStep == DownloadStep.Steps.Сбор_ссылок)
                //Если манга не найдена в списке
                if (downloadList.Count(mn => (mn.url.Equals(url))) == 0)
                    //Добавляем страницу манги в список
                    addMangaToList(url);
        }


        /// <summary>
        /// Получаем время, со значением микросекунд
        /// </summary>
        /// <returns>Дабловое число секунд</returns>
        public static decimal timeMicro()
        {
            //Получаем время с долями секунды
            return (decimal)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
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
            decimal startTime, finTime;

            try
            {
                //Получаем время запуска загрузки
                startTime = timeMicro();

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
                                info.status = MangaStatus.status.Ошибка_загрузки_страниц;
                                //То выходим из цикла
                                break;
                            }
                            //Инициализируем парсер 
                            hp = new htmlGeHentaiParcer(code);
                        }
                        //Если нужно ещё допарсить картинок
                    } while (complete);

                    //Манга загружена корректно
                    info.status = MangaStatus.status.Информация_загружена;

                    //Получаем время завершения загрузки
                    finTime = timeMicro();
                    //Пересчитываем среднее время загрузки
                    averageLoadInfoTime = (averageLoadInfoTime + (finTime - startTime)) / 2;
                }
                else
                    //Ошибка - корневая страница не была загружена
                    info.status = MangaStatus.status.Ошибка_загрузки_информации;
            }
            catch
            {
                info.status = MangaStatus.status.Общая_ошибка_загрузки;
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
                    //Обновляем инфу на форме
                    updateDownloadExec();
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
            decimal startTime, finTime;

            try
            {
                //Получаем время запуска загрузки
                startTime = timeMicro();

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


                        //Получаем время завершения загрузки
                        finTime = timeMicro();
                        //Пересчитываем среднее время загрузки
                        averageLoadTime = (averageLoadTime + (finTime - startTime)) / 2;
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
                if (info[i].status == MangaStatus.status.Информация_загружена)
                {
                    //Ставим статус загрузки страниц
                    info[i].status = MangaStatus.status.Загрузка_страниц;

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

                            //Обновляем инфу на форме
                            updateDownloadExec();
                        }
                    }

                    //Если манга была загружена 
                    if (info[i].checkLoad())
                        //Если количество страниц совпадает - то всё ок
                        //Иначе - ставим статус о несовпадении
                        info[i].status = (info[i].checkCount()) ? MangaStatus.status.Страницы_загружены 
                            : MangaStatus.status.Ошибка_количества_страниц;

                    //Обновляем инфу на форме
                    updateDownloadExec();
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
        /// Вызываем обновление списков загрузки
        /// </summary>
        public void updateDownloadExec()
        {
            //Инициализируем переменные
            DownloadProgressInfo info = new DownloadProgressInfo();
            List<TableMangaInfo> mangaTable = new List<TableMangaInfo>();

            int currentCurr, currentFull, maxCurr, countPages;

            //Инициализируем рассчитываемые значения нолями
            currentCurr = maxCurr = currentFull = countPages = 0;

            //Проходимся по списку загрузок
            foreach (var mn in downloadList)
            {
                //Добавляем мангу в список загрузок
                mangaTable.Add(new TableMangaInfo() {
                    count = mn.countPages,
                    downloadCount = mn.downloadPages(),
                    name = mn.name,
                    status = mn.status,
                    url = mn.url
                });

                //Если данная манга сейчас загружается
                if (mn.status == MangaStatus.status.Загрузка_страниц)
                {
                    //Указываем количество страниц текущей загружаемой манги
                    maxCurr = mn.countPages;
                    //Указываем количество загруженных страниц текущей манги
                    currentCurr = mn.downloadPages();
                    //Добавляем количество страниц, которые нужно загрузить в расчете
                    countPages += (maxCurr - currentCurr);
                }
                //Если для данной манги загружена инфа
                else if (mn.status == MangaStatus.status.Информация_загружена)
                    //Добавляем все страницы под загрузку
                    countPages += mn.countPages;
            }

            //Если мы щас грузим страницы
            if (workStep == DownloadStep.Steps.Загрузка_страниц_манги)
            {
                //Количество загруженных манг равно количеству загруженных старниц
                currentFull = downloadList.Count(dl => (dl.status == MangaStatus.status.Страницы_загружены));

                //Передаём информацию в класс
                info = new DownloadProgressInfo()
                {
                    finalFlag = (workStep != DownloadStep.Steps.Сбор_ссылок),
                    approximateLoadTime = averageLoadTime,
                    maxFull = downloadList.Count,
                    countPages = countPages,
                    currentCurr = currentCurr,
                    currentFull = currentFull,
                    maxCurr = maxCurr,
                    step = workStep
                };
            }
            //Если мы щас грузим инфу
            else if (workStep == DownloadStep.Steps.Загрузка_информации_о_манге)
            {
                //Количество загруженных манг равно количеству загруженных старниц
                currentFull = downloadList.Count(dl => (dl.status == MangaStatus.status.Информация_загружена));

                //Передаём информацию в класс
                info = new DownloadProgressInfo()
                {
                    finalFlag = false,
                    approximateLoadTime = averageLoadInfoTime,
                    maxFull = downloadList.Count,
                    countPages = downloadList.Count,
                    currentCurr = 0,
                    currentFull = currentFull,
                    maxCurr = 0,
                    step = workStep
                };
            }

            //Вызываем событие обновления
            onUpdateDownload?.Invoke(info, mangaTable);
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
            //Обновляем инфу на форме
            updateDownloadExec();
        }

        /// <summary>
        /// Удаляем мангу из списка по id
        /// </summary>
        /// <param name="id">id удаляемого элемента в списке</param>
        public void removeMangaReomList(int id)
        {
            //Удаляем элемент
            downloadList.RemoveAt(id);
            //Обновляем инфу на форме
            updateDownloadExec();
        }

        /// <summary>
        /// Очищаем список загрузки
        /// </summary>
        public void clearMangaList()
        {
            //Очищаем список загрузки
            downloadList.Clear();
            //Обновляем инфу на форме
            updateDownloadExec();
        }

        /// <summary>
        /// Загружаем информацию о манге
        /// </summary>
        private void downloadManga()
        {
            //Перед началом загрузки, автоматом сохраняем список манги
            saveManga();
            //Переходим к первому шагу загрузки
            workStep = DownloadStep.Steps.Загрузка_информации_о_манге;
            //Обновляем инфу на форме
            updateDownloadExec();
            //Загружаем информацию о манге
            loadManga(ref downloadList);
            
            //После загрузки инфы, автоматом сохраняем список манги
            saveManga();
            //Переходим ко второму шагу загрузки
            workStep = DownloadStep.Steps.Загрузка_страниц_манги;
            //Обновляем инфу на форме
            updateDownloadExec();
            //Загружаем страницы манги
            downloadPages(ref downloadList);

            //Возвращаемся к сбору ссылок
            workStep = DownloadStep.Steps.Сбор_ссылок;
            //Обновляем инфу на форме
            updateDownloadExec();
        }

        /// <summary>
        /// Запуск загрузки
        /// </summary>
        public void start()
        {
            //Прописываем текущий путь загрузки
            downloadPath = Properties.Settings.Default.downloadPath;

            //Инициализируем класс загрузки нужными параметрами
            loader = new geHentaiLoader(
                Properties.Settings.Default.ipb_member_id,
                Properties.Settings.Default.ipb_pass_hash);

            //Если основной поток уже существовал
            if (main != null)
                //Прерываем его выполнение
                main.Abort();
            //Инициализируем поток
            main = new Thread(downloadManga);
            //Запускаем основной рабочий поток
            main.Start();
        }

        /// <summary>
        /// Равершение работы всех потоков
        /// </summary>
        public void stop()
        {
            //Завершаем поток сканера буфера обмена
            cs.stop();

            //Если основной поток уже существовал
            if (main != null)
            {
                //Прерываем его выполнение
                main.Abort();
                //Очищаем информацию о потоке
                main = null;
            }
        }

        /// <summary>
        /// Сохраняем мангу
        /// </summary>
        /// <param name="path">Путь сохранения манги. По дефолту - путь автосохранения</param>
        /// <returns>Результат выполнения операции. 0 - всё ок, иначе - код ошибки.</returns>
        public byte saveManga(string path = null)
        {
            byte ex = 1;

            try
            {
                //Если путь не пустой
                if ((path == null) || (path.Length != 0))
                {
                    //Если список загрузки был создан
                    if (downloadList != null)
                        //Выполняем сохранение списка манги
                        ex = xw.saveManga(downloadList, path);
                    else
                        //Список загрузки ещё не было проинициализирован
                        ex = 3;
                }
                else
                    //ОШибка - пустой путь
                    ex = 4;
            }
            catch { ex = 1; }

            return ex;
        }

        /// <summary>
        /// Загружаем мангу
        /// </summary>
        /// <param name="path">Путь загрузки манги. По дефолту - путь автозагрузки</param>
        /// <returns>Результат выполнения операции. 0 - всё ок, иначе - код ошибки.</returns>
        public byte loadManga(string path = null)
        {
            byte ex = 1;

            try
            {
                //Если список загрузки был создан
                if (downloadList != null)
                {
                    //Если путь не пустой
                    if ((path == null) || (path.Length != 0))
                    {
                        //Очищаем список загрузки
                        downloadList.Clear();
                        //Загружаем мангу
                        downloadList = xw.loadManga(path);

                        //Если была ошибка загрузки
                        if (downloadList == null)
                        {
                            //РЕинициализируем список
                            downloadList = new List<manga>();
                            //Возвращаем код ошибки загрузки
                            ex = 3;
                        }
                        else
                            //Всё ок
                            ex = 0;
                    }
                    else
                        //ОШибка - пустой путь
                        ex = 4;
                }
                else
                    //Список загрузки ещё не было проинициализирован
                    ex = 2;
            }
            catch { ex = 1; }

            return ex;
        }

    }
}
