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
        /// Конструктор класса
        /// </summary>
        public SettingsStorage()
        {
            //Ставим дефолтные значения

            //Параметры загрузки
            downloadPath = Application.StartupPath + @"\Files\";
            rootPageLoadDelay = 2000;
            mangaInfoLoadDelay = 3000;
            downloadMangaDelay = 10000;
            downloadMangaPageDelay = 2000;
            createChildFolder = openDownloadFolder = newFolderRequest = true;

            //Параметры подключения
            ipb_pass_hash = ipb_member_id = "";

            //Параметры сохранения
            exitAutosave = addElementAutosave = checkStatusesAutosave = loadInfoAutosave =
                loadPagesAutosave = true;
            autosaveBackup = false;

        }
    }
}
