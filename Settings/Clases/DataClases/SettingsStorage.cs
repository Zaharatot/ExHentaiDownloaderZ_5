using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsStorageZ.Clases.DataClases
{
    /// <summary>
    /// Класс-хранилище настроек
    /// </summary>
    [Serializable]
    public class SettingsStorage
    {
        /* Параметры загрузки */

        /// <summary>
        /// Базовый путь загрузки
        /// </summary>
        public string downloadPath { get; set; }


        /// <summary>
        /// Делей между подгрузками страниц на корневой
        /// при получении полного списка страниц манги
        /// </summary>
        public int rootPageLoadDelay { get; set; }
        /// <summary>
        /// Делей между подгрузками информации о каждой
        /// из манг в списке
        /// </summary>
        public int mangaInfoLoadDelay { get; set; }
        /// <summary>
        /// Делей между загрузками разных манг
        /// </summary>
        public int downloadMangaDelay { get; set; }
        /// <summary>
        /// Делей между загрузками страниц манги
        /// </summary>
        public int downloadMangaPageDelay  { get; set; }


        /// <summary>
        /// Количество дополнительных ожиданий (-1 если отключено)
        /// </summary>
        public int addWaitCount { get; set; }
        /// <summary>
        /// Минимальное время дополнительного ожидания
        /// </summary>
        public int addWaitTimeMin { get; set; }
        /// <summary>
        /// Максимальное время дополнттельного ожидания
        /// </summary>
        public int addWaitTimeMax { get; set; }



        /// <summary>
        /// Флаг сохранения оригинального имени файла
        /// </summary>
        public bool keepOriginalFileName { get; set; }
        /// <summary>
        /// Флаг поиска изображения в оригинальном размере
        /// </summary>
        public bool tryFindOriginalSize { get; set; }


        /// <summary>
        /// Автоматическое открытие папки, куда велась загрузка, после её завершения.
        /// </summary>
        public bool openDownloadFolder { get; set; }
        
        /// <summary>
        /// Автоматическое создание дочерних номерных папок в базовой папке загрузки, и 
        /// выполнение загрузки в них.
        /// </summary>
        public bool createChildFolder { get; set; }

        /// <summary>
        /// В случае, если для списка загрузки уже прописан путь, выполнение запроса о
        /// смене пути загрузки, перед началом загрузки.
        /// </summary>
        public bool newFolderRequest { get; set; }


        /// <summary>
        /// В случае, если флаг будет проставлен, при добавлении манги в 
        /// список, произойдёт автоматическая прокрутка к добавленной манге.
        /// </summary>
        public bool scrollToAdd { get; set; }
        /// <summary>
        /// В случае, если флаг будет проставлен, будет выполняться 
        /// автоматическая прокрутка к активной в данный момент манге.
        /// </summary>
        public bool scrollToActive { get; set; }


        /* Параметры подключения */

        /// <summary>
        /// Хеш пароля от geHentai
        /// </summary>
        public string ipb_pass_hash { get; set; }
        /// <summary>
        /// Id пользователя от geHentai
        /// </summary>
        public string ipb_member_id { get; set; }


        /* Параметры сохранения */

        /// <summary>
        /// Автосохранение, при выходе из программы, во время работы.
        /// </summary>
        public bool exitAutosave { get; set; }
        /// <summary>
        /// Автосохранение, после добавления/удаления ссылки из списка.
        /// </summary>
        public bool addElementAutosave { get; set; }

        /// <summary>
        /// Автосохранение, перед проверкой статусов
        /// (сохраняется список добавленных ссылок)
        /// </summary>
        public bool checkStatusesAutosave { get; set; }
        /// <summary>
        /// Автосохранение, перед загрузкой информации о манге
        /// (сохраняются проверенные статусы)
        /// </summary>
        public bool loadInfoAutosave { get; set; }
        /// <summary>
        /// Автосохранение, перед загрузкой страниц манги 
        /// (сохраняется загруженная информация о манге)
        /// </summary>
        public bool loadPagesAutosave { get; set; }

        /// <summary>
        /// Создание бекапа файла автосохранения, перед перезаписью файла.
        /// </summary>
        public bool autosaveBackup { get; set; }


        /// <summary>
        /// Максимальное количество повторных попыток загрузки 
        /// манги, в случае, если не вся манга была загружена
        /// </summary>
        public int twinLoadCount { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public SettingsStorage()
        {
            //Ставим дефолтные значения

            //Параметры загрузки
            downloadPath = Application.StartupPath + @"\Files\";
            rootPageLoadDelay = 3000;
            mangaInfoLoadDelay = 4000;
            downloadMangaDelay = 15000;
            downloadMangaPageDelay = 3000;
            createChildFolder = openDownloadFolder = newFolderRequest = true;

            twinLoadCount = 3;
            //Параметры подключения
            ipb_pass_hash = ipb_member_id = "";

            //Параметры сохранения
            scrollToAdd = exitAutosave = addElementAutosave = checkStatusesAutosave = loadInfoAutosave =
                scrollToActive = loadPagesAutosave = true;
            autosaveBackup = keepOriginalFileName = tryFindOriginalSize = false;            
        }
    }
}
