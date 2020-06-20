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
using System.Diagnostics;
using PopUpZ.Content.Clases;
using static ExHentaiDownloaderZ_5.Content.Clases.WorkClases.Parcer.htmlGeHentaiParcer_NEW;

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
        /// <param name="finalWork">Флаг завершения работы</param>
        /// <param name="toDown">Флаг необходимости прокрутки страницы вниз</param>
        /// <param name="selected">Id выбранной задачи</param>
        public delegate void updateDownload(DownloadProgressInfo downloadInfo, 
            List<TableMangaInfo> mangaTable, bool finalWork, bool toDown, int selected);
        /// <summary>
        /// Событие обновления процесса загрузки манги
        /// </summary>
        public event updateDownload onUpdateDownload;

        /// <summary>
        /// Событие ошибки лимитов
        /// </summary>
        public event EventHandler onLimiteError;


        /// <summary>
        /// Адрес страницы ошибки
        /// </summary>
        private const string failURL = "https://exhentai.org/img/509.gif";

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
        /// Список загрузки
        /// </summary>
        private DownloadList dList;
        /// <summary>
        /// Класс сохранения и загрузки
        /// </summary>
        XmlWorker xw;
        /// <summary>
        /// Класс попапов
        /// </summary>
        private PopupLoader pl;

        /// <summary>
        /// Текущий шаг работы
        /// </summary>
        public DownloadStep.Steps workStep { get; private set; }
        /// <summary>
        /// Основной рабочий поток
        /// </summary>
        private Thread main;


        /// <summary>
        /// Средняя скорость загрузки страницы манги
        /// </summary>
        private decimal averageLoadTime;
        /// <summary>
        /// Средняя скорость загрузки информации о манге
        /// </summary>
        private decimal averageLoadInfoTime;

        /// <summary>
        /// Счётчик повторных перезапусков
        /// </summary>
        private int twinWork;

        /// <summary>
        /// Флаг лимитов загрузки
        /// </summary>
        private bool limites;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="pl">Класс загрузки попапов</param>
        public mainWorker(PopupLoader pl)
        {
            //Записываем ссылку на класс загрузки попапов
            this.pl = pl;
            //Инициализируем сканер буфера обмена
            cs = new ClipboardScanner();
            //ИНициализируем класс сохранения/загрузки
            xw = new XmlWorker();
            //Инициализиурем список манги для загрузки
            dList = new DownloadList();
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
            if (workStep == DownloadStep.Steps.Сбор_ссылок)
            {
                //Чистим адрес от лишних частей
                url = verificateUrl(url);
                //Если манга не найдена в списке
                if (dList.downloadList.Count(mn => (mn.url.Equals(url))) == 0)
                    //Добавляем страницу манги в список
                    addMangaToList(url);
            }
        }


        /// <summary>
        /// Получаем время, со значением микросекунд
        /// </summary>
        /// <returns>Дабловое число секунд</returns>
        private decimal timeMicro()
        {
            //Получаем время с долями секунды
            return (decimal)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
        }

        
        /// <summary>
        /// Проверка статусов загрузки манги
        /// </summary>
        private void checkDownloadStatuses()
        {
            manga buff;
            page pgBuff;
            string path;

            try
            {
                //Проходимся по списку манги
                for (int i = 0; i < dList.downloadList.Count; i++)
                {
                    //Получаем инфу о манге
                    buff = dList.downloadList[i];

                    //Если список страниц уже был загружен
                    if (buff.countPages != 0)
                    {
                        //Получаем путь к папке с данной мангой
                        path = dList.getMangePath(i);

                        //Проходимся по страницам манги
                        for (int j = 0; j < buff.countPages; j++)
                        {
                            //Получаем инфу о странице
                            pgBuff = buff.pages[j];

                            //Если нет имени файла или файл не найден
                            if ((pgBuff.filename == null)
                                || (!File.Exists(path + pgBuff.filename)))
                            {
                                //Стираем имя файла (на всякий случай)
                                pgBuff.filename = null;
                                //Ставим статус, что загрузки не было
                                pgBuff.loaded = PageLoadStatus.status.Загрузка_ещё_не_произошла;
                            }
                            //Если файл действительно существует
                            else
                                //Ставим статус, что файл есть
                                pgBuff.loaded = PageLoadStatus.status.Загрузка_успешна;

                            //Возвращаем инфу о странице
                            buff.pages[j] = pgBuff;
                        }

                        //Если все страницы на месте
                        if (buff.checkLoad())
                            //Ставим статус, что манга уже загружена
                            buff.status = MangaStatus.status.Страницы_загружены;
                        //Если страниц нету - статус догрузки
                        else
                            buff.status = MangaStatus.status.Информация_загружена;
                    }
                    //Если списка страниц нету
                    else
                        //Говорим, что манга ещё не загружалась
                        buff.status = MangaStatus.status.Манга_добавлена;

                    //Возвращаем значение
                    dList.downloadList[i] = buff;
                }
            }
            catch { }
        }


        /// <summary>
        /// Загружаем информацию о манге
        /// </summary>
        /// <param name="info">Информация о манге</param>
        /// <returns>Флаг загрузки информации. True - загрузка была</returns>
        private bool loadMangaInfo(ref manga info)
        {
            bool ex = false;
            //Объявляем переменные
            FindNextUrlStatus loadPagesStatus;
            string pageUrl, code;
            List<string> buff;
            htmlGeHentaiParcer_NEW hp;
            decimal startTime, finTime;

            try
            {
                //Если инфа о манге ещё не была загружена
                if (info.status == MangaStatus.status.Манга_добавлена)
                {
                    //Получаем время запуска загрузки
                    startTime = timeMicro();

                    //Загружаем страницу 
                    code = loader.loadHtmlPage(info.url);
                    //Инициализируем парсер 
                    hp = new htmlGeHentaiParcer_NEW(code);

                    //Если страница была загружена корректно
                    if (code.Length > 0)
                    {
                        //Получаем название манги
                        info.name = hp.getTitle();
                        //Получаем и парсим количество страниц
                        info.countPages = hp.getCountPages();

                        //Ставим дефолтные значения получения страниц
                        loadPagesStatus = FindNextUrlStatus.Страница_найдена;

                        //В цикле подгружаем все страницы манги
                        do
                        {
                            //Получаем картинки с текущей страницы
                            buff = hp.getPagesUrl();
                            //Добавляем их в основной список
                            addMangaPages(buff, ref info);
                            //Если есть ещё одна страница - продолжаем загрузку
                            loadPagesStatus = hp.GetNextPageUrl(out pageUrl);
                            //Если страница есть
                            if (loadPagesStatus == FindNextUrlStatus.Страница_найдена)
                            {
                                //Спим, чтобы сайт особо не бузил
                                Thread.Sleep(Program.settingsStorage.settings.rootPageLoadDelay);
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
                                hp = new htmlGeHentaiParcer_NEW(code);
                            }
                            //Если нужно ещё допарсить картинок
                        } while (loadPagesStatus == FindNextUrlStatus.Страница_найдена);

                        //Манга загружена корректно
                        info.status = MangaStatus.status.Информация_загружена;

                        //Получаем время завершения загрузки
                        finTime = timeMicro() - startTime + 
                            Program.settingsStorage.settings.mangaInfoLoadDelay / 1000;
                        //Пересчитываем среднее время загрузки
                        averageLoadInfoTime = (averageLoadInfoTime + finTime) / 2;

                        //Указываем, что загрузка была
                        ex = true;
                    }
                    else
                        //Ошибка - корневая страница не была загружена
                        info.status = MangaStatus.status.Ошибка_загрузки_информации;
                }
            }
            catch
            {
                info.status = MangaStatus.status.Общая_ошибка_загрузки;
            }

            return ex;
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
        /// Загружаем информацию о манге
        /// </summary>
        private void loadMangaInfo()
        {
            bool loadFlag;
            manga buff;

            try
            {
                //Проходимся по списку манги
                for (int i = 0; i < dList.downloadList.Count; i++)
                {
                    //Получаем инфу о манге
                    buff = dList.downloadList[i];
                    //Загружаем информацию о манге
                    loadFlag = loadMangaInfo(ref buff);
                    //Сохраняем инфу обратно
                    dList.downloadList[i] = buff;
                    //Обновляем инфу на форме
                    updateDownloadExec(i);
                    //Если загрузка была произведена
                    if (loadFlag)
                        //Спим, чтобы сайт особо не бузил
                        Thread.Sleep(Program.settingsStorage.settings.mangaInfoLoadDelay);                    
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
        /// <param name="originalFilename">Оригинальное имя файла</param>
        /// <param name="filename">Возврат итмени загруженного файла</param>
        /// <returns>0 - всё ок, оначе - ошибка загрузки</returns>
        private byte downloadPage(string url, string path, int id, out string filename)
        {
            byte ex = 1;
            string imageUrl, code, imagePath, originalFilename;
            decimal startTime, finTime;

            //Ставим дефолтное значение
            filename = null;

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
                    var hp = new htmlGeHentaiParcer_NEW(code);
                    //Загружаем адрес картинки
                    imageUrl = hp.getImageUrl();
                    //Если мы получили адрес картинки
                    if (imageUrl.Length > 0)
                    {
                        //Если адрес не входит в список косячных
                        if (imageUrl != failURL)
                        {
                            //Получаем оригинальное имя файла
                            originalFilename = hp.GetOriginalFileName();
                            //Формируем имя файла
                            filename = CompileFileName(originalFilename, imageUrl, id);
                            //Формируем путь загрузки
                            imagePath = $"{path}{filename}";
                            //Грузим страницу, и получаем результат
                            ex = loader.downloadFile(imageUrl, imagePath);
                            //Получаем время завершения загрузки, со временем ожидания
                            finTime = timeMicro() - startTime +
                                Program.settingsStorage.settings.downloadMangaPageDelay / 1000;
                            //Пересчитываем среднее время загрузки
                            averageLoadTime = (averageLoadTime + finTime) / 2;
                        }
                        else
                            //Ошибка - мы привысили лимиты
                            ex = 255;
                    }
                    else
                        //Ошибка - адрес картинки не был найден
                        ex = 4;
                }
                else
                    //Ошибка - страница не была загружена
                    ex = 3;
            }
            catch (Exception e)
            {
                ex = 1;
                //Ставим дефолтное значение
                filename = null;
            }

            return ex;
        }

        /// <summary>
        /// Компилируем новое имя файла
        /// </summary>
        /// <param name="originalFilename">Оригинальное имя файла</param>
        /// <param name="url">Адрес файла</param>
        /// <param name="id">Id файла</param>
        /// <returns>Новое имя файла</returns>
        private string CompileFileName(string originalFilename, string url, int id)
        {
            string ex = "";
            //Получаем расширение файла
            string ext = GetExt(originalFilename, url);
            //Если оригинальное имя файла не было нормально получено
            if(originalFilename == null)
                //Формируем внутреннее имя файла
                ex = $"{id}{ext}"; 
            //Если оригинальное имя файла есть
            else
            {
                //Если нужно использовать оригинальное имя файла
                ex = (Program.settingsStorage.settings.keepOriginalFileName) ?
                    //Используем его, а если нет - формируем внутреннее
                    originalFilename : $"{id}{ext}";
            }
            return ex;
        }

        /// <summary>
        /// Получаем расширение файла
        /// </summary>
        /// <param name="originalFilename">Оригинальное имя файла</param>
        /// <param name="url">Адрес файла</param>
        /// <returns>Строка расширения файла</returns>
        private string GetExt(string originalFilename, string url)
        {
            string ext;
            //Если оригинальное имя файла не было нормально получено
            if (originalFilename == null)
            {
                //Пробуем получить расширение из имени
                ext = loader.getExtWithUrl(url);
                //Если ссылка ведёт на php файл загрузки оригинального размера
                if (ext.ToLower() == ".php")
                    //Прописываем дефолтное расширение
                    ext = ".jpg";
            }
            //Если оригинальное имя файла есть
            else
                //Пробуем получить расширение из имени
                ext = loader.getExtWithUrl(originalFilename);
            return ext;
        }

        /// <summary>
        /// Загружаем страницы манги
        /// </summary>
        private void downloadPages()
        {
            byte result;
            string downloadPath, filename;
            manga buff;
            bool loadImage;
            List<string> fileNames;

            //Проходимся по списку манги
            for (int i = 0; limites && (i < dList.downloadList.Count); i++)
            {
                //Флаг того, что хоть одно изображение было загружено
                //Изначально ставится в False
                loadImage = false;

                //Получаем мангу
                buff = dList.downloadList[i];

                //Ставим статус загрузки страниц
                buff.status = MangaStatus.status.Загрузка_страниц;

                //Получаем текущий путь загрузки данной манги
                downloadPath = dList.getMangePath(i);

                //Создаём директорию, если её нету
                Directory.CreateDirectory(downloadPath);

                //Получаем список имён файлов в папке загрузки
                fileNames = getDirectoryFileNames(downloadPath);

                //Проходимся по страницам манги
                for (int j = 0; j < buff.pages.Count; j++)
                {                   
                    //Если файл не найден в папке
                    if (fileNames.Count(fn => (fn == j.ToString())) == 0)
                    {
                        //Грузим страницу, и получаем результат
                        result = downloadPage(buff.pages[j].url, downloadPath, j, out filename);
                        //Если мы превысили лимиты на загрузки
                        if (result == 255)
                        {
                            //Говорим, что у нас проблема с лимитами
                            limites = false;
                            //Выходим из этого цикла
                            break;
                        }
                        //Если всё ок
                        else
                        {
                            //Возвращаем результат загрузки
                            buff.pages[j].loaded = (PageLoadStatus.status)result;
                            //Сохраняем имя файла, для последующих проверок
                            buff.pages[j].filename = filename;
                            //Говорим, что изображение было загружено
                            loadImage = true;
                            //Спим, чтобы сайт особо не бузил
                            Thread.Sleep(Program.settingsStorage.settings.downloadMangaPageDelay);
                        }
                    }
                    //Если файл в папке таки есть
                    else
                        //Проставляем что он всё-таки есть!
                        buff.pages[j].loaded = PageLoadStatus.status.Загрузка_успешна;

                    //Обновляем инфу на форме
                    updateDownloadExec(i);
                }

                //Если манга была загружена 
                if (buff.checkLoad())
                    //Если количество страниц совпадает - то всё ок
                    //Иначе - ставим статус о несовпадении
                    buff.status = (buff.checkCount()) ? MangaStatus.status.Страницы_загружены
                        : MangaStatus.status.Ошибка_количества_страниц;
                //В противном случае
                else
                    //Ошибка загрузки
                    buff.status = MangaStatus.status.Ошибка_количества_страниц;

                //Обновляем инфу на форме
                updateDownloadExec(-1);

                //Спим только в случае, если хоть одно изображение было загружено
                if(loadImage)
                    //Спим, чтобы сайт особо не бузил
                    Thread.Sleep(Program.settingsStorage.settings.downloadMangaDelay);


                //Возвращаем информацию обратно в список
                dList.downloadList[i] = buff;                
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
        /// <param name="finalWork">Флаг завершения работы</param>
        /// <param name="onDown">Флаг необходимости прокрутки вниз</param>
        /// <param name="selected">Id задачи, над которой идёт работа</param>
        public void updateDownloadExec(int selected, bool finalWork = false, bool onDown = false)
        {
            //Инициализируем переменные
            DownloadProgressInfo info = new DownloadProgressInfo();
            List<TableMangaInfo> mangaTable = new List<TableMangaInfo>();

            int currentCurr, currentFull, maxCurr, countPages;

            //Инициализируем рассчитываемые значения нолями
            currentCurr = maxCurr = currentFull = countPages = 0;

            //Проходимся по списку загрузок
            foreach (var mn in dList.downloadList)
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
                currentFull = dList.getCountByStatus(MangaStatus.status.Страницы_загружены);

                //Передаём информацию в класс
                info = new DownloadProgressInfo()
                {
                    finalFlag = (workStep != DownloadStep.Steps.Сбор_ссылок),
                    approximateLoadTime = averageLoadTime,
                    maxFull = dList.getCount(),
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
                currentFull = dList.getCountByStatus(MangaStatus.status.Информация_загружена);

                //Передаём информацию в класс
                info = new DownloadProgressInfo()
                {
                    finalFlag = false,
                    approximateLoadTime = averageLoadInfoTime,
                    maxFull = dList.getCount(),
                    countPages = dList.getCount(),
                    currentCurr = 0,
                    currentFull = currentFull,
                    maxCurr = 0,
                    step = workStep
                };
            }
            //Если мы щас чекаем статусы
            else if(workStep == DownloadStep.Steps.Проверка_статусов_загрузки)
            {
                //Передаём информацию в класс
                info = new DownloadProgressInfo()
                {
                    finalFlag = false,
                    approximateLoadTime = 1,
                    maxFull = dList.getCount(),
                    countPages = dList.getCount(),
                    currentCurr = 0,
                    currentFull = dList.getCount(),
                    maxCurr = 0,
                    step = workStep
                };
            }

            //Вызываем событие обновления
            onUpdateDownload?.Invoke(info, mangaTable, finalWork, onDown, selected);
        }


        /// <summary>
        /// Проверяет корневой адрес страницы
        /// </summary>
        /// <param name="url">Адрес страницы</param>
        /// <returns>Проверенный адрес страницы</returns>
        private string verificateUrl(string url)
        {
            string ex = "";

            try
            {
                //Если адрес имеет длинну
                if (url.Length > 10)
                {
                    //Формируем URI по адресу
                    Uri uu = new Uri(url);
                    //Формируем путь без лишних частей
                    ex = $"{uu.Scheme}://{uu.Authority}{uu.AbsolutePath}";
                }
            }
            catch { ex = ""; }

            return ex;

        }

        /// <summary>
        /// Добавляем мангу в список
        /// </summary>
        /// <param name="url">Адрес манги</param>
        public void addMangaToList(string url)
        {
            //Добавляем информацию о манге
            dList.addManga(url);

            //Если нужно проводить автосохранение при изменении списка
            if (Program.settingsStorage.settings.addElementAutosave)
                //Сохраняем изменения
                saveManga();

            //Обновляем инфу на форме
            updateDownloadExec(-2, false, true);
        }

        /// <summary>
        /// Удаляем мангу из списка по id
        /// </summary>
        /// <param name="id">id удаляемого элемента в списке</param>
        public void removeMangaReomList(int id)
        {
            //Удаляем элемент
            dList.removeManga(id);

            //Если нужно проводить автосохранение при изменении списка
            if (Program.settingsStorage.settings.addElementAutosave)
                //Сохраняем изменения
                saveManga();

            //Обновляем инфу на форме
            updateDownloadExec(-1);
        }

        /// <summary>
        /// Очищаем список загрузки
        /// </summary>
        public void clearMangaList()
        {
            //Очищаем список загрузки
            dList.clearManga();

            //Если нужно проводить автосохранение при изменении списка
            if (Program.settingsStorage.settings.addElementAutosave)
                //Сохраняем изменения
                saveManga();

            //Обновляем инфу на форме
            updateDownloadExec(-1);
        }


        /// <summary>
        /// Загружаем информацию о манге
        /// </summary>
        private void downloadManga()
        {
            //Сбрасываем счётчик повторных попыток загрузки
            twinWork = -1;

            do
            {
                //Если нужно проводить автосохранение перед проверкой статусов
                if (Program.settingsStorage.settings.checkStatusesAutosave)
                    //Сохраняем изменения
                    saveManga();
                //Переходим к первому шагу загрузки
                workStep = DownloadStep.Steps.Проверка_статусов_загрузки;
                //Обновляем инфу на форме
                updateDownloadExec(-2);
                //Проверяем все статусы загрузки
                checkDownloadStatuses();


                //Если нужно проводить автосохранение перед загрузкой информации
                if (Program.settingsStorage.settings.loadInfoAutosave)
                    //Сохраняем изменения
                    saveManga();
                //Переходим к первому шагу загрузки
                workStep = DownloadStep.Steps.Загрузка_информации_о_манге;
                //Обновляем инфу на форме
                updateDownloadExec(-2);
                //Загружаем информацию о манге
                loadMangaInfo();

                //Если нужно проводить автосохранение перед загрузкой страниц
                if (Program.settingsStorage.settings.loadPagesAutosave)
                    //Сохраняем изменения
                    saveManga();
                //Переходим ко второму шагу загрузки
                workStep = DownloadStep.Steps.Загрузка_страниц_манги;
                //Обновляем инфу на форме
                updateDownloadExec(-2);
                //Загружаем страницы манги
                downloadPages();

                //Сохраняем изменения
                saveManga();

                //Если загрузка была успешно завершена
                //И лимиты в порядке
                if (!limites || dList.checkComplete())
                    //Выходим из цикла
                    break;

                //Переходим к следующей попытке
                twinWork++;
                //Спим 10 секунд, между попытками загрузки
                Thread.Sleep(1000 * 10);
                //Идём, пока у нас есть попытки
            } while (twinWork < Program.settingsStorage.settings.twinLoadCount);

            //Если с лимитами всё ок
            if (limites)
            {
                //Возвращаемся к сбору ссылок
                workStep = DownloadStep.Steps.Сбор_ссылок;
                //Обновляем инфу на форме, указав что работа была завершена
                updateDownloadExec(-1, true);
                //Если стоит флаг открытия папки загрузки
                if (Program.settingsStorage.settings.openDownloadFolder)
                    //Открываем папку, куда всё это грузили
                    openDownloadDirectory();
            }
            //Если ошибка по лимитам
            else
            {
                //Обновляем форму
                updateDownloadExec(-1);
                //Вызываем ивент ошибки
                onLimiteError?.Invoke(null, null);
            }
        }

        /// <summary>
        /// Открываем директорию, куда производилась загрузка
        /// </summary>
        private void openDownloadDirectory()
        {
            try
            {
                //Если список загрузки существует
                //И существует папка загрузки
                if ((dList != null) && (Directory.Exists(dList.downloadPath)))
                    //Открываем папку загрузки
                    Process.Start(dList.downloadPath);
            }
            catch { }
        }

        /// <summary>
        /// Формируем новый путь загрузки
        /// </summary>
        /// <param name="path">Дефолтный путь загрузки</param>
        /// <returns>Путь с номерной папкой</returns>
        private string getNewDownloadPath(string path)
        {
            string ex = path;
            string dir;
            int id = 0;

            try
            {
                do
                {
                    //Формируем новый путь
                    dir = $"{path}{id++}";
                }
                //Повторияем, пока не найдём не существующую директорию
                while (Directory.Exists(dir));
                //СОхраняем полученный путь
                ex = dir;
            }
            catch { ex = path; }

            return ex;
        }

        /// <summary>
        /// Устанавливаем путь загрузки манги
        /// </summary>
        /// <param name="path">Дефолтный путь загрузки</param>
        private void setDownloadPath(string path)
        {
            bool newPath = true;

            //Если нужно спрашивать о том, оставить ли старый путь загрузки
            if (Program.settingsStorage.settings.newFolderRequest)
                //Если в списке загрузки уже установлен путь
                if ((dList.downloadPath != null) && (dList.downloadPath.Length != 0))
                    //Запрашиваем обновление пути
                    newPath = (pl.showMessage(8) == System.Windows.Forms.DialogResult.Yes);

            //Если путь таки нужно обновить
            if(newPath)
                //Проставляем новый. Если нужно создавать дочерние папки - создаём.
                //иначе - базовый путь загрузки.
                dList.downloadPath = (Program.settingsStorage.settings.createChildFolder) ? 
                    getNewDownloadPath(path) :
                    path;
        }

        /// <summary>
        /// Запуск загрузки
        /// </summary>
        public void start()
        {
            //Прописываем текущий путь загрузки
            setDownloadPath(Program.settingsStorage.settings.downloadPath);

            //Инициализируем класс загрузки нужными параметрами
            loader = new geHentaiLoader(
                Program.settingsStorage.settings.ipb_member_id,
                Program.settingsStorage.settings.ipb_pass_hash);

            //Если основной поток уже существовал
            if (main != null)
                //Прерываем его выполнение
                main.Abort();

            //Сбрасываем флаг лимитов
            limites = true;

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
                    if (dList != null)
                        //Выполняем сохранение списка манги
                        ex = xw.saveManga(dList, path);
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
                if (dList != null)
                {
                    //Если путь не пустой
                    if ((path == null) || (path.Length != 0))
                    {
                        //Очищаем список загрузки
                        dList.clearManga();
                        //Загружаем мангу
                        dList = xw.loadManga(path);

                        //Если была ошибка загрузки
                        if (dList == null)
                        {
                            //РЕинициализируем список
                            dList = new DownloadList();
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
