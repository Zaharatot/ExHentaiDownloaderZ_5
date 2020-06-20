using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases.Parcer
{
    /// <summary>
    /// Класс, выполняющий очистку строк
    /// </summary>
    internal class HtmlCleaner
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public HtmlCleaner()
        {

        }


        /// <summary>
        /// Очищаем оригинальное имя файла
        /// </summary>
        /// <param name="number">Номер страницы</param>
        /// <param name="source">Исходная строка</param>
        /// <returns>Строка имени</returns>
        public string ClearOriginalFileName(string source, string number) =>
            //Удаляем из имени файла всё лишнее
            source.Replace($"Page {ParseIntValue(number)}: ", "");

        /// <summary>
        /// Очищаем строку от мусорных символов
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <param name="additional">Дополнительные фильтры для очистки</param>
        /// <returns>Очищенная строка</returns>
        public string ClearString(string source, string[] additional = null)
        {
            string ex;

            try
            {
                //Получаем список "мусорных" символов
                List<string> trash = new List<string> {
                    "&#039;", "&amp;", ":", @"\\", "/", @"\|", ";", @"\*",
                    @"\?", "\"", "<", ">", "'", "\t", "\r", "\n", " - ExHentai.org" };
                //Если есть дополнительные фильтры
                if (additional != null)
                    //Добавляем их
                    trash.AddRange(additional);

                //Примечание - впервые за 6 лет развития этой программы
                //я решил таки нахрен удалять из названия манги строчку "ExHentai.org"

                //Проходимся по массиву мусорных символов
                for (int i = 0; i < trash.Count; i++)
                    //Удаляем значение
                    source = source.Replace(trash[i], "");
                //Удаляем пробелы из начала и конца строки
                ex = source.Trim(' ');
            }
            catch { ex = null; }

            return ex;
        }

        /// <summary>
        /// Парсим целочисленное значение
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <returns>Итоговое значение</returns>
        public int ParseIntValue(string source)
        {
            int ex = -1;

            try
            {
                //Парсим строку в число
                if (int.TryParse(source, out int res))
                    //Если всё ок - возвращаем
                    ex = res;
            }
            catch { ex = -1; }

            return ex;
        }
    }
}
