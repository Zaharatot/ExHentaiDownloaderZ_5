using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CustomTopBar
{
    /// <summary>
    /// Контролл, реализующий кастомную верхнюю панель
    /// </summary>
    public partial class customTopBar : UserControl
    {
        /// <summary>
        /// Делегат события клика по кнопке панели
        /// </summary>
        public delegate void buttonClick();

        /// <summary>
        /// Событие нажатия на кнопку закрытия
        /// </summary>
        public event buttonClick onCloseButtonClick;
        /// <summary>
        /// Событие нажатия на кнопку разворачивания
        /// </summary>
        public event buttonClick onMaximizeButtonClick;
        /// <summary>
        /// Событие нажатия на кнопку сворачивания
        /// </summary>
        public event buttonClick onMinimizeButtonClick;


        /// <summary>
        /// Старые координаты для перемещения формы
        /// </summary>
        private Point oldPos;

        /// <summary>
        /// Иконка
        /// </summary>
        private Bitmap iconVal;
        /// <summary>
        /// Картинки для кнопок
        /// </summary>
        private Bitmap[] buttonsImages;
        /// <summary>
        /// Картинки для кнопок, с выделением
        /// </summary>
        private Bitmap[] buttonsSelectImages;
        /// <summary>
        /// Картинки для кнопок, с выделением и применённым цветом
        /// </summary>
        private Bitmap[] buttonsColoredSelectImages;
        /// <summary>
        /// Цвет выделения кнопок
        /// </summary>
        private Color buttonsSelectColorVal;
        /// <summary>
        /// Цвет текста заголовка
        /// </summary>
        private Color headerColorVal;

        /// <summary>
        /// Флаг значения видимости иконки
        /// </summary>
        private bool iconVisibleVal;
        /// <summary>
        /// Флаг видимости кнопки закрытия
        /// </summary>
        private bool closeVisibleVal;
        /// <summary>
        /// Флаг видимости кнопки разворачивания
        /// </summary>
        private bool maximizeVisibleVal;
        /// <summary>
        /// Флаг видимости кнопки сворачивания
        /// </summary>
        private bool minimizeVisibleVal;

        /// <summary>
        /// Строка заголовка программы
        /// </summary>
        private string headerVal;


        /// <summary>
        /// Флаг видимости иконки
        /// </summary>
        public bool iconVisible {
            get
            {
                //Возвращаем значение
                return iconVisibleVal;
            }
            set
            {
                //Проставляем значение
                iconVisibleVal = value;
                //Проставляем видимость иконки
                setVisible(iconPictureBox, iconVisibleVal);
            }
        }

        /// <summary>
        /// Иконка контролла
        /// </summary>
        public Bitmap icon
        {
            get
            {
                return iconVal;
            }
            set
            {
                //Проставляем значение иконки
                iconVal = value;
                //Отображаем иконку
                setIcon();
            }
        }


        /// <summary>
        /// Цвет выделения кнопок
        /// </summary>
        public Color buttonsSelectColor
        {
            get
            {
                return buttonsSelectColorVal;
            }
            set
            {
                //Проставляем значение цвета
                buttonsSelectColorVal = value;
                //Обновляем цвета выделения
                updateColors();
            }
        }

        /// <summary>
        /// Цвет текста заголовка
        /// </summary>
        public Color headerColor
        {
            get
            {
                return headerColorVal;
            }
            set
            {
                //Проставляем значение цвета
                headerColorVal = value;
                //Обновляем цвет
                headerLabel.ForeColor = headerColorVal;
            }
        }



        /// <summary>
        /// Флаг видимости кнопки закрытия
        /// </summary>
        public bool closeVisible
        {
            get
            {
                //Возвращаем значение
                return closeVisibleVal;
            }
            set
            {
                //Проставляем значение
                closeVisibleVal = value;
                //Проставляем видимость иконки
                setVisible(closePictureBox, closeVisibleVal);
            }
        }

        /// <summary>
        /// Флаг видимости кнопки разворачивания
        /// </summary>
        public bool maximizeVisible
        {
            get
            {
                //Возвращаем значение
                return maximizeVisibleVal;
            }
            set
            {
                //Проставляем значение
                maximizeVisibleVal = value;
                //Проставляем видимость иконки
                setVisible(maximizePictureBox, maximizeVisibleVal);
            }
        }

        /// <summary>
        /// Флаг видимости кнопки сворачивания
        /// </summary>
        public bool minimizeVisible
        {
            get
            {
                //Возвращаем значение
                return minimizeVisibleVal;
            }
            set
            {
                //Проставляем значение
                minimizeVisibleVal = value;
                //Проставляем видимость иконки
                setVisible(minimizePictureBox, minimizeVisibleVal);
            }
        }
        
        

        /// <summary>
        /// Строка заголовка
        /// </summary>
        public string headerText
        {
            get
            {
                //Возвращаем значение
                return headerVal;
            }
            set
            {
                //Проставляем значение
                headerVal = value;
                //Проставляем текст заголовка
                headerLabel.Text = headerVal;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public customTopBar()
        {
            //Инициализируем автоматически сгенерированные данные
            InitializeComponent();
            //Инициализируем свои данные
            init();
        }

        /// <summary>
        /// Инициализатор контролла
        /// </summary>
        private void init()
        {
            //Загружаем изображения
            loadImages();
            //Инициализируем значения
            initVariables();
            //Инициализируем события
            initEvents();
            //Инициализируем изображения на кнопках
            initButtons();
        }

        /// <summary>
        /// Инициализируем значения
        /// </summary>
        private void initVariables()
        {
            //Проставляем дефолтные значения
            iconVisibleVal = false;
            iconVal = null;
            //Проставляем видимость кнопок
            closeVisibleVal = maximizeVisibleVal = minimizeVisibleVal = true;
            //Простоаяляем нулевую позицию курсора
            oldPos = new Point(0, 0);
            //Выставляем цвет выделения
            buttonsSelectColorVal = Color.Red;
            //Выставляем цвет текста заголовка
            headerColorVal = Color.Black;
            //Обновляем цвета выделения
            updateColors();
        }

        /// <summary>
        /// Загружаем картинки для кнопок
        /// </summary>
        private void loadImages()
        {
            //Обычные картинки
            buttonsImages = new Bitmap[] {
                Resources.Resources.close,
                Resources.Resources.maximize,
                Resources.Resources.minimize
            };
            //Картинки с выделением
            buttonsSelectImages = new Bitmap[] {
                Resources.Resources.close_select,
                Resources.Resources.maximize_select,
                Resources.Resources.minimize_select
            };
            //картинки с цветным выделением
            buttonsColoredSelectImages = new Bitmap[0];
        }

        /// <summary>
        /// ИНициализируем события
        /// </summary>
        private void initEvents()
        {
            //Перемещаем форму, при клике над этими контроллами:
            //Лейбл
            headerLabel.MouseMove += move_form;
            //Иконки
            iconPictureBox.MouseMove += move_form;
            //Обработчик события ресайза панели
            this.Resize += CustomTopBar_Resize;

            //Событие наведения указателя мыши на кнопку
            closePictureBox.MouseEnter += ClosePictureBox_MouseEnter;
            maximizePictureBox.MouseEnter += MaximizePictureBox_MouseEnter;
            minimizePictureBox.MouseEnter += MinimizePictureBox_MouseEnter;
            //Событие убирания указателя мыши с кнопки
            closePictureBox.MouseLeave += ClosePictureBox_MouseLeave;
            maximizePictureBox.MouseLeave += MaximizePictureBox_MouseLeave;
            minimizePictureBox.MouseLeave += MinimizePictureBox_MouseLeave;
        }

        /// <summary>
        /// Обработчик события ресайза панели
        /// </summary>
        private void CustomTopBar_Resize(object sender, EventArgs e)
        {
            //Меняем размер элементов
            resizeElements();
        }

        /// <summary>
        /// Инициализируем кнопки
        /// </summary>
        private void initButtons()
        {
            //Проставляем картинки
            minimizePictureBox.Image = buttonsImages[2];
            maximizePictureBox.Image = buttonsImages[1];
            closePictureBox.Image = buttonsImages[0];
        }

        /// <summary>
        /// Меняем размер элементов
        /// </summary>
        private void resizeElements()
        {
            //Проставляем ширину кнопок
            setVisible(minimizePictureBox, minimizeVisibleVal);
            setVisible(maximizePictureBox, maximizeVisibleVal);
            setVisible(closePictureBox, closeVisibleVal);
            //Проставляем ширину иконки
            setVisible(iconPictureBox, iconVisibleVal);
        }

        /// <summary>
        /// Проставляем видимость
        /// </summary>
        /// <param name="icon">Икнока, которую скрываем</param>
        /// <param name="visibleVal">Флаг видимости</param>
        private void setVisible(PictureBox icon, bool visibleVal)
        {
            //Ширина иконки либо равна высоте, либо 0, в зависимости от типа видимости
            icon.Width = (visibleVal) ? icon.Height : 0;
        }

        /// <summary>
        /// Отображаем иконку
        /// </summary>
        private void setIcon()
        {
            //Проставляем иконку
            iconPictureBox.Image = iconVal;
            //Если иконка не задана
            if (iconVal == null)
            {
                //Убираем видимость иконки
                iconVisibleVal = false;
                setVisible(iconPictureBox, iconVisibleVal);
            }
        }


        /// <summary>
        /// Обработчик события перемещения мыши над элементом
        /// </summary>
        private void move_form(object sender, MouseEventArgs e)
        {
            //Еслии нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                //Получаем текущие координаты родительской формы
                Point tmp = getFormPosition();

                //Если координат старого местоположения нету
                if (oldPos.IsEmpty)
                    //Проставляем их
                    oldPos = e.Location;

                //Рассчитываем новые координаты, учитывая сдвиг
                tmp.X += e.X - oldPos.X;
                tmp.Y += e.Y - oldPos.Y;

                //Проставляем новые координаты
                setFormPosition(tmp);
            }
            //Если кнопка была отпущена
            else if(e.Button == MouseButtons.None)
                //Обновляем старые координаты курсора
                oldPos = e.Location;
        }

        /// <summary>
        /// Устанавливаем координаты формы
        /// </summary>
        /// <param name="pos">Новые координаты формы</param>
        private void setFormPosition(Point pos)
        {
            try
            {
                //Проставляем координаты родительской форме
                this.ParentForm.Left = pos.X;
                this.ParentForm.Top = pos.Y;
            }
            catch { }
        }

        /// <summary>
        /// Получаем координаты формы
        /// </summary>
        /// <returns>Координаты формы</returns>
        private Point getFormPosition()
        {
            Point ex = new Point(0, 0);
            
            try
            {
                //Простоавляем координаты
                ex = new Point(this.ParentForm.Left, this.ParentForm.Top);
            }
            catch { ex = new Point(0, 0); }

            return ex;
        }

        /// <summary>
        /// Обновляем цвета выделения
        /// </summary>
        private void updateColors()
        {
            //Буфер цвета
            Color buff;

            //Очищаем старые картинки цветного выделения
            for (int i = 0; i < buttonsColoredSelectImages.Length; i++)
                buttonsColoredSelectImages[i].Dispose();

            //Инициализируем новый массив цветного выделения
            buttonsColoredSelectImages = new Bitmap[buttonsSelectImages.Length];

            //Проходимся по списку картинок выделения
            for (int i = 0; i < buttonsSelectImages.Length; i++)
            {
                //Инициализируем новую картинку
                buttonsColoredSelectImages[i] = new Bitmap(buttonsSelectImages[i].Width, 
                    buttonsSelectImages[i].Height);

                //Проходимся по пикселям
                for (int x = 0; x < buttonsSelectImages[i].Width; x++)
                {
                    for (int y = 0; y < buttonsSelectImages[i].Height; y++)
                    {
                        //Получаем цвет пикселя
                        buff = buttonsSelectImages[i].GetPixel(x, y);
                        //Если цвет не белый
                        if (!testWhite(buff))
                            //Подмешиваем цвет выделения
                            buff = Color.FromArgb(
                                buff.A,
                                (buff.R + buttonsSelectColorVal.R) / 2,
                                (buff.G + buttonsSelectColorVal.G) / 2,
                                (buff.B + buttonsSelectColorVal.B) / 2
                            );
                        //Встраиваем пиксель
                        buttonsColoredSelectImages[i].SetPixel(x, y, buff);
                    }
                }
            }
        }

        /// <summary>
        /// Проверка на то, что цвет близок к белому
        /// </summary>
        /// <param name="col">Проверяемый цвет</param>
        /// <returns>True - цвет близок к белому</returns>
        private bool testWhite(Color col) =>
            (col.R + col.G + col.B >= 750);


        /// <summary>
        /// Убирание мыши с кнопки сворачивания
        /// </summary>
        private void MinimizePictureBox_MouseLeave(object sender, EventArgs e)
        {
            //Проставляем картинки
            minimizePictureBox.Image = buttonsImages[2];
        }
        /// <summary>
        /// Убирание мыши с кнопки разворачивания
        /// </summary>
        private void MaximizePictureBox_MouseLeave(object sender, EventArgs e)
        {
            //Проставляем картинки
            maximizePictureBox.Image = buttonsImages[1];
        }
        /// <summary>
        /// Убирание мыши с кнопки закрытия
        /// </summary>
        private void ClosePictureBox_MouseLeave(object sender, EventArgs e)
        {
            //Проставляем картинки
            closePictureBox.Image = buttonsImages[0];
        }

        /// <summary>
        /// Наведение мыши на кнопку сворачивания
        /// </summary>
        private void MinimizePictureBox_MouseEnter(object sender, EventArgs e)
        {
            //Проставляем картинки
            minimizePictureBox.Image = buttonsColoredSelectImages[2];
        }
        /// <summary>
        /// Наведение мыши на кнопку разворачивания
        /// </summary>
        private void MaximizePictureBox_MouseEnter(object sender, EventArgs e)
        {
            //Проставляем картинки
            maximizePictureBox.Image = buttonsColoredSelectImages[1];
        }
        /// <summary>
        /// Наведение мыши на кнопку закрытия
        /// </summary>
        private void ClosePictureBox_MouseEnter(object sender, EventArgs e)
        {
            //Проставляем картинки
            closePictureBox.Image = buttonsColoredSelectImages[0];
        }



        /// <summary>
        /// Клик по кнопке сворачивания
        /// </summary>
        private void minimizePictureBox_Click(object sender, EventArgs e)
        {
            //Вызываем событие
            onMinimizeButtonClick?.Invoke();
        }

        /// <summary>
        /// Клик по кнопке разворачивания
        /// </summary>
        private void maximizePictureBox_Click(object sender, EventArgs e)
        {
            //Вызываем событие
            onMaximizeButtonClick?.Invoke();
        }


        /// <summary>
        /// Клик по кнопке закрытия
        /// </summary>
        private void closePictureBox_Click(object sender, EventArgs e)
        {
            //Вызываем событие
            onCloseButtonClick?.Invoke();
        }
    }
}
