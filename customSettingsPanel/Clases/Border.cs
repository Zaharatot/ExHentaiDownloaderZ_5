using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace customSettingsPanel.Clases
{
    /// <summary>
    /// Класс, описывающий обводку
    /// </summary>
    [TypeConverter(typeof(BorderConverter))]
    public class Border
    {
        /// <summary>
        /// Делегат события перерисовки объекта
        /// </summary>
        public delegate void ReDrawEventHandler();
        /// <summary>
        /// Событие перерисовки объекта
        /// </summary>
        public event ReDrawEventHandler ReDrawEventArgs;

        /// <summary>
        /// Цвет линии обводки
        /// </summary>
        public Color LineColor
        {
            get
            {
                //Возвращаем цвет
                return _lineColor.Color;
            }
            set
            {
                //Проставляем новый карандаш
                _lineColor = new Pen(value);
                //Вызываем событие перерисовки
                ReDrawEventArgs?.Invoke();
            }
        }

        /// <summary>
        /// Флаг отрисовки обводки
        /// </summary>
        public bool DrawBorder
        {
            get
            {
                //Возвращаем значение
                return _drawBorder;
            }
            set
            {
                //Проставляем значение
                _drawBorder = value;
                //Вызываем событие перерисовки
                ReDrawEventArgs?.Invoke();
            }
        }

        /// <summary>
        /// Значение отступа у обводки 
        /// </summary>
        public int Padding
        {
            get
            {
                //Возвращаем значение
                return _padding;
            }
            set
            {
                //Проставляем значение
                _padding = value;
                //Вызываем событие перерисовки
                ReDrawEventArgs?.Invoke();
            }
        }

        /// <summary>
        /// Цвет линии обводки
        /// </summary>
        private Pen _lineColor = Pens.Black;
        /// <summary>
        /// Флаг отрисовки обводки
        /// </summary>
        private bool _drawBorder = false;
        /// <summary>
        /// Значение отступа у обводки
        /// </summary>
        private int _padding = 1;


        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Border()
        {
            //Проставляем дефолтные значения
            _lineColor = Pens.Black;
            _drawBorder = false;
            _padding = 1;
        }

        /// <summary>
        /// Конструктор класса с аргументами
        /// </summary>
        /// <param name="DrawBorder">Флаг отрисовки обводки</param>
        /// <param name="LineColor">Цвет линии обводки</param>
        /// <param name="Padding">Значение отступа у обводки</param>
        public Border(bool DrawBorder, Color LineColor, int Padding)
        {
            //Проставляем переданные значения
            _lineColor = new Pen(LineColor);
            _drawBorder = DrawBorder;
            _padding = Padding;
        }


        /// <summary>
        /// Возвращаем карандаш
        /// </summary>
        /// <returns>Карандаш указанного цвета</returns>
        public Pen getPen() =>
            //Возвращае карандаш
            _lineColor;

        /// <summary>
        /// Возвращаем прямоугольник для обводки
        /// </summary>
        /// <param name="width">Ширина родительского контролла</param>
        /// <param name="height">Высота родительского контролла</param>
        /// <returns>Прямоугольник для обводки</returns>
        public Rectangle GetRectangle(int width, int height) =>
            //Формируем прямоугольник
            new Rectangle(_padding, _padding, width - _padding * 2, height - _padding * 2);
    }
}
