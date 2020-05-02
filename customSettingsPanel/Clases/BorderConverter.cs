using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customSettingsPanel.Clases
{
    /// <summary>
    /// Конвертер типов, для рамки
    /// </summary>
    class BorderConverter : TypeConverter
    {
        /// <summary>
        /// Проверка возможности конвертации значения
        /// </summary>
        /// <param name="context">Контекстная информация о компоненте (контекнер, дескриптор свойства и т.п.)</param>
        /// <param name="sourceType">Тип исходного свойства</param>
        /// <returns>True - конвертация возможна</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            //Заранее ставим в отказ
            bool ex = false;

            try
            {
                //Если передана строка - то точно можно, если нет - проверяем стандартными средствами
                ex = (sourceType == typeof(string)) ? true : base.CanConvertFrom(context, sourceType);
            }
            catch
            {
                //В случае какой-либо ошибки ответим отказом
                ex = false;
            }

            //Возвращаем результат
            return ex;
        }

        /// <summary>
        /// Пытаемся сконвертировать объект из полученных данных
        /// </summary>
        /// <param name="context">Контекстная информация о компоненте (контекнер, дескриптор свойства и т.п.)</param>
        /// <param name="culture">Информация о культуре в которой передано значение</param>
        /// <param name="value">Конвертируемое значение</param>
        /// <returns>Сконвертированный результат</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            //По дефолту вернём пустое значение
            object ex = null;

            try
            {
                //Если нам передана строка
                if (value is string)
                {
                    //Получаем эту строку
                    string val = (string)value;

                    //Если значение передано пустым
                    if ((val == null) || (val.Length == 0) || (val == "Disabled"))
                        //Возвращаем значение без обводки (т.е. - дефолтное)
                        ex = new Border();
                    //Если там что-то есть
                    else
                    {
                        //Парсим полученную строку в данные
                        bool enabled = ConvertValueFromString(val, out Color color, out int padding);
                        //Возвращаем результат
                        ex = new Border(enabled, color, padding);
                    }
                }
                //Если передано что-то непонятное
                else
                    //Пытаемся сконвертировать стандартным способом
                    ex = base.ConvertFrom(context, culture, value);
            }
            catch { }


            //Возвращаем результат
            return ex;
        }

        /// <summary>
        /// Конвертируем наше значение в указанное
        /// </summary>
        /// <param name="context">Контекстная информация о компоненте (контекнер, дескриптор свойства и т.п.)</param>
        /// <param name="culture">Информация о культуре в которой передано значение</param>
        /// <param name="value">Конвертируемое значение</param>
        /// <param name="destinationType">Тип, в которвый мы должны сконвертировать</param>
        /// <returns>Результирующий объект</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            //По дефолту вернём пустое значение
            object ex = null;

            try
            {
                //Если нужно сконвертировать в строку
                if (destinationType == typeof(string))
                {
                    //Получаем наше значение
                    var val = (Border)value;
                    //Если отрисовка нужна, то описываем цвет по каналам и значение сдвига, если нет - пишем "Disabled"
                    ex = (val.DrawBorder) ? $"{val.LineColor.R}; {val.LineColor.G}; {val.LineColor.B} | {val.Padding}"
                        : "Disabled";
                }
                //Если в другой тип
                else 
                    //Используем стандартный метод
                    ex = base.ConvertTo(context, culture, value, destinationType);
            }
            catch { }

            //Возвращаем результат
            return ex;
        }

        /// <summary>
        /// Флаг того, что данный класс поддерживает свойства
        /// </summary>
        /// <param name="context">Контекстная информация о компоненте (контекнер, дескриптор свойства и т.п.)</param>
        /// <returns>Флаг наличия поддержки свойств</returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            //Сразу возвращаем True, т.к. нам это и нужно
            return true;
        }

        /// <summary>
        /// Возвращаем список свойств класса
        /// </summary>
        /// <param name="context">Контекстная информация о компоненте (контекнер, дескриптор свойства и т.п.)</param>
        /// <param name="value">Обхект нашего типа, из которого будем получать свойства</param>
        /// <param name="attributes">Массив типа Attribute, используемый в качестве фильтра.</param>
        /// <returns>Коллекция свойств нашего класса</returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            //Просто используем стандартный метод получения свойств
            return TypeDescriptor.GetProperties(value, attributes);
        }



        /// <summary>
        /// Конвертируем информацию из строки типа "{r}; {g}; {b} | {padding}" в значения
        /// </summary>
        /// <param name="value">Строковое значение цвета</param>
        /// <param name="color">Результирующий цвет</param>
        /// <param name="padding">Значение отступа</param>
        /// <returns>True - конвертация удалась</returns>
        private bool ConvertValueFromString(string value, out Color color, out int padding)
        {
            bool ex = false;
            //Сразу ставим дефолтные значения
            color = Color.Black;
            padding = 1;

            try
            {
                //Удаляем из строки пробелы
                value = value.Replace(" ", "");
                //Парсим строку по разделителю
                var elems = value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                //Если в строке есть все части
                if (elems.Length == 2)
                {
                    //Парсим значение отступа
                    if (int.TryParse(elems[1], out int pad))
                    {
                        //Проставляем распарешнный отступ
                        padding = pad;
                        //Сплитим строку по значку ';'
                        var channels = elems[0].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        //Если передано 3 канала цвета (R, G, B)
                        if (channels.Length == 3)
                        {
                            //Если удалось успешно спарсить все 3 значения
                            if (int.TryParse(channels[0], out int R) &&
                                int.TryParse(channels[1], out int G) &&
                                int.TryParse(channels[2], out int B))
                            {
                                //Формируем указанный цвет
                                color = Color.FromArgb(R, G, B);
                                //Всё ок
                                ex = true;
                            }
                        }
                    }
                }
            }
            catch { }

            //Возвращаем значение
            return ex;
        }
    }
}
