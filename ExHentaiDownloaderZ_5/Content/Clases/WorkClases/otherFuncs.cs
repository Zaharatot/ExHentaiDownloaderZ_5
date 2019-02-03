using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExHentaiDownloaderZ_5.Content.Clases.WorkClases
{
    /// <summary>
    /// Дополнительные функции
    /// </summary>
    class otherFuncs
    {

        /// <summary>
        /// Парсим id из строки в число
        /// </summary>
        /// <param name="id">Id, в виде строки</param>
        /// <returns>Число</returns>
        public static long parceLong(string value)
        {
            long ex = -1;

            try
            {
                //Чистим строку для парсинга
                clearToParce(ref value);
                //Конвертим строку в число
                ex = Convert.ToInt64(value);
            }
            catch { ex = -1; }

            return ex;
        }

        /// <summary>
        /// Парсим значение из строки в число
        /// </summary>
        /// <param name="value">Значение в виде строки</param>
        /// <returns>Число</returns>
        public static byte parceByte(string value)
        {
            byte ex = 0;

            //Чистим строку для парсинга
            clearToParce(ref value);
            //Если косяк парсинга, то возвращаем 0
            if (!byte.TryParse(value, out ex))
                ex = 0;

            return ex;
        }

        /// <summary>
        /// Парсим значение из строки в число
        /// </summary>
        /// <param name="value">Значение в виде строки</param>
        /// <returns>Число</returns>
        public static int parceInt(string value)
        {
            int ex = -1;

            //Чистим строку для парсинга
            clearToParce(ref value);
            //Если косяк парсинга, то возвращаем -1
            if (!int.TryParse(value, out ex))
                ex = -1;

            return ex;
        }

        /// <summary>
        /// Парсим суммма из строки в число
        /// </summary>
        /// <param name="value">Сумма в виде строки</param>
        /// <returns>Число</returns>
        public static decimal parceDecimal(string value)
        {
            decimal ex = -1;


            try
            {
                //Чистим строку для парсинга
                clearToParce(ref value);
                //Указываем, что парсим, для конкретной культуры, под 
                //которую заранее переформатировали число
                var cultureInfo = CultureInfo.GetCultureInfo("ru");
                //Парсим число
                ex = decimal.Parse(value, cultureInfo);
            }
            catch
            {
                //В случае ошибки вернём -1
                ex = -1;
            }

            return ex;
        }

        /// <summary>
        /// Очищаем строку для парсинга в число
        /// </summary>
        /// <param name="value">Изначальная строка</param>
        /// <returns>Чистая строка</returns>
        private static void clearToParce(ref string value)
        {
            try
            {
                //Меняем точку на запятую
                value = value.Replace('.', ',');
                //на всякий случай - грохаем всё, кроме цифр и запятых
                value = new Regex("[^0-9,]").Replace(value, "");
            }
            catch { }
        }
    }
}
