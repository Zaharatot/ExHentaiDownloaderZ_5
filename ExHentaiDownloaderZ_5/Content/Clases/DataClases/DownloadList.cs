using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.DataClases
{
    /// <summary>
    /// Класс, хранящий информацию о списке загрузок
    /// </summary>
    public class DownloadList
    {
        /// <summary>
        /// Список загрузки
        /// </summary> 
        public string downloadPath { get; set; }

        /// <summary>
        /// Список манги, которую нужно загрузить
        /// </summary>
        public List<manga> downloadList { get; set; }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DownloadList()
        {
            //Инициализируем дефолтные значения
            downloadList = new List<manga>();
            downloadPath = "";
        }

        /// <summary>
        /// Возвращает количество страниц манги, с указанным статусом
        /// </summary>
        /// <param name="stat">Статус для поиска</param>
        /// <returns>Количество страниц</returns>
        public int getCountByStatus(MangaStatus.status stat)
        {
            int ex = 0;

            try
            {
                //Возвращаем количество страниц с указанным статусом
                ex = downloadList.Count(dl => (dl.status == stat));
            }
            catch { ex = 0; }

            return ex;
        }

        /// <summary>
        /// Возврат общего количества манги в списке загрузки
        /// </summary>
        /// <returns>Количество манг</returns>
        public int getCount()
        {
            int ex = 0;

            try
            {
                //Возвращаем количество страниц
                ex = downloadList.Count();
            }
            catch { ex = 0; }

            return ex;
        }


        /// <summary>
        /// Добавляем инфу о манге в список
        /// </summary>
        /// <param name="url">Адрес страницы манги</param>
        public void addManga(string url)
        {
            try
            {
                //Добавляем информацию о манге
                downloadList.Add(new manga(url));
            }
            catch { }
        }



        /// <summary>
        /// Удаляем инфу о манге из списка
        /// </summary>
        /// <param name="id">id удаляемой строки</param>
        public void removeManga(int id)
        {
            try
            {
                //Удаляем элемент
                downloadList.RemoveAt(id);
            }
            catch { }
        }



        /// <summary>
        /// Очищаем список загрузок
        /// </summary>
        public void clearManga()
        {
            try
            {
                //Очищаем список загрузок
                downloadList.Clear();
            }
            catch { }
        }

        /// <summary>
        /// Возвращаем путь к папке манги
        /// </summary>
        /// <param name="id">id манги в списке</param>
        /// <returns>Путь загрузки</returns>
        public string getMangePath(int id)
        {
            string ex = "";

            try
            {
                //Формируем путь загрузки
                ex = $"{downloadPath}\\{downloadList[id].name}\\";
            }
            catch { ex = ""; }

            return ex;
        }

        /// <summary>
        /// Проверка завершения загрузки
        /// </summary>
        /// <returns>True - если вся манга загружена</returns>
        public bool checkComplete() =>
            //Проверка на то, что не загруженной манги нет
            (downloadList.Count(dl => (!dl.checkLoad())) == 0);
    }
}
