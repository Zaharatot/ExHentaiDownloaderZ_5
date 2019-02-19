using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace customGroupBox
{
    /// <summary>
    /// Контролл, представляющий из себя панель с 
    /// </summary>
    public partial class customGroupBox : UserControl
    {
        /// <summary>
        /// Цвет обводки рамки
        /// </summary>
        private Pen borderPen;
        /// <summary>
        /// Форма рамки
        /// </summary>
        private GraphicsPath borderPath;

        /// <summary>
        /// Текст заголовка элемента
        /// </summary>
        public string headerText
        {
            get
            {
                //Возвращаем имя элемента
                return grpupBoxName.Text;
            }
            set
            {
                //Проставляем имя элемента
                grpupBoxName.Text = value;
            }
        }


        /// <summary>
        /// Цвет текста заголовка
        /// </summary>
        public Color headerColor
        {
            get
            {
                //Возвращаем цвет рамки
                return grpupBoxName.ForeColor;
            }
            set
            {
                //Инициализируем нвоый цвет
                grpupBoxName.ForeColor = value;
            }
        }

        /// <summary>
        /// Цвет рамки элемента
        /// </summary>
        public Color borderColor
        {
            get
            {
                //Возвращаем цвет рамки
                return borderPen.Color;
            }
            set
            {
                //Инициализируем нвоый цвет
                borderPen = new Pen(value);
                //Перерисовываем элемент
                this.Invalidate();
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public customGroupBox()
        {
            //Инициализируем компоненты
            InitializeComponent();
            //Инициализируем даныне
            init();
        }

        /// <summary>
        /// Инициализатор класса
        /// </summary>
        private void init()
        {
            //Инициализируем значения
            initValues();
            //Инициализируем события
            initEvents();
        }

        /// <summary>
        /// Инициализируем значения
        /// </summary>
        private void initValues()
        {
            //Проставляем дефолтные значения
            grpupBoxName.Text = "customGroupBox";
            borderPen = Pens.Red;
            grpupBoxName.ForeColor = Color.Red;

            //Обновляем размеры рамки
            resizeBorder();
        }

        /// <summary>
        /// Обновляем размеры рамки
        /// </summary>
        private void resizeBorder()
        {
            //Параметры рамки
            int x = 6;
            int y = 9;
            int width = this.Width - 12;
            int height = this.Height - 15;
            int radius = 8;

            //Если путь существовал
            if(borderPath != null)
                //Очищаем старый путь
                borderPath.Dispose();
            //Инициализируем новый путь
            borderPath = new GraphicsPath();

            //Создаём новые
            borderPath.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            borderPath.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            borderPath.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            borderPath.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            borderPath.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            borderPath.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            borderPath.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            borderPath.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner

            //Закрываем фигуру
            borderPath.CloseFigure();
        }

        /// <summary>
        /// Инициализируем события
        /// </summary>
        private void initEvents()
        {
            //Привязываем событие на перерисовку элемента
            this.Paint += CustomGroupBox_Paint;
            //Привязываем событие на смену размера
            this.Resize += CustomGroupBox_Resize;
        }



        /// <summary>
        /// Обработчик изменения размера элемента
        /// </summary>
        private void CustomGroupBox_Resize(object sender, EventArgs e)
        {
            //Обновляем размеры рамки
            resizeBorder();
            //Перерисовываем элемент
            this.Invalidate();
        }

        /// <summary>
        /// Событие перерисовки элемента
        /// </summary>
        private void CustomGroupBox_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем рамку
            //            e.Graphics.DrawRectangle(borderPen, new Rectangle(6, 6, this.Width - 12, this.Height - 12));
            e.Graphics.DrawPath(borderPen, borderPath);
        }
    }
}
