using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CustomProgressBar
{
    /// <summary>
    /// Кастомный прогрессбар
    /// </summary>
    public class customProgressBar : UserControl
    {
        /// <summary>
        /// Кисть, которой будем рисовать бар
        /// </summary>
        private TextureBrush barBrush;
        /// <summary>
        /// Первый цвет переднего плана
        /// </summary>
        public Color fgColor;
        /// <summary>
        /// Список прямоугольников бара
        /// </summary>
        private Rectangle[] rectBar;
        /// <summary>
        /// Прямоугольник, закрывающий пустую часть
        /// </summary>
        private Rectangle closeBar;
        /// <summary>
        /// Цвет заднего плана
        /// </summary>
        private SolidBrush bgColor;
        /// <summary>
        /// Текущее значение бара
        /// </summary>
        private int val;
        /// <summary>
        /// Минимальное значение
        /// </summary>
        public int minVal;
        /// <summary>
        /// Максимальное значение
        /// </summary>
        public int maxVal;


        /// <summary>
        /// Цвет переднего плана
        /// </summary>
        public Color foregroundColor
        {
            get
            {
                //Возвращаем цвет
                return fgColor;
            }
            set
            {
                //Проставляем значение
                fgColor = value;
                //Обновляем кисть
                updateBrush();
                //Перерисовываем контролл
                this.Invalidate();
            }
        }

        /// <summary>
        /// Цвет фона
        /// </summary>
        public Color backgroundColor
        {
            get
            {
                //Возвращаем цвет
                return bgColor.Color;
            }
            set
            {
                //Проставляем значение
                bgColor = new SolidBrush(value);
                //Перерисовываем контролл
                this.Invalidate();
            }
        }

        /// <summary>
        /// Текущее значение бара
        /// </summary>
        public int value
        {
            get
            {
                //Возвращаем значение
                return val;
            }
            set
            {
                //Проставляем значение
                val = value;
                //Обновляем значение
                updateValue();
            }
        }
        /// <summary>
        /// Минимальное значение бара
        /// </summary>
        public int min
        {
            get
            {
                //Возвращаем значение
                return minVal;
            }
            set
            {
                //Проставляем значение
                minVal = value;
                //Обновляем значение
                updateValue();
            }
        }
        /// <summary>
        /// Максимальное значение бара
        /// </summary>
        public int max
        {
            get
            {
                //Возвращаем значение
                return maxVal;
            }
            set
            {
                //Проставляем значение
                maxVal = value;
                //Обновляем значение
                updateValue();
            }
        }

        /// <summary>
        /// Конструктор прогрессбара
        /// </summary>
        public customProgressBar()
        {
            //Инициализируем контролл
            InitializeComponent();
            //Инциализация всего
            init();
        }

        /// <summary>
        /// Обновляем значение
        /// </summary>
        private void updateValue()
        {
            //Проверка на выход за границу
            if (val > maxVal)
                val = maxVal;
            else if (val < minVal)
                val = minVal;

            //Инициализируем бар перекрытия пустого места
            initCloseBar();
            //Перерисовываем контролл
            this.Invalidate();
        }


        /// <summary>
        /// Инициализация компонента
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // customProgressBar
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(100, 25);
            this.Name = "customProgressBar";
            this.Size = new System.Drawing.Size(655, 27);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Инциализация всего
        /// </summary>
        private void init()
        {
            //Инициализируем дефолтные значения
            initDefaults();
            //Инициализируем события контролла
            initActions();
        }

        /// <summary>
        /// Инициализируем события контролла
        /// </summary>
        private void initActions()
        {
            //Добавляем обработчик смены размера
            this.Resize += ManualProgressBar_Resize;
            //Добавляем обработчик перерисовки контролла
            this.Paint += ManualProgressBar_Paint;
        }

        /// <summary>
        /// Инициализируем дефолтные значения
        /// </summary>
        public void initDefaults()
        {
            minVal = 0;
            maxVal = 100;
            val = 0;
            bgColor = new SolidBrush(Color.Black);
            fgColor = Color.Red;
            //Перерассччёт размеров областей контролла
            setSizes();
        }

        /// <summary>
        /// Обновляем кисть
        /// </summary>
        private void updateBrush()
        {
            //Создаём картинку по ширине и высоте контролла
            using (Bitmap pic = new Bitmap(this.Width, this.Height))
            {
                //Создаём полотно для рисования
                using (Graphics gr = Graphics.FromImage(pic))
                {
                    //Заливаем картинку цветом
                    gr.Clear(fgColor);
                    //Применяем изменения
                    gr.Flush();
                }
                //Инициализируем кисть нашей картинкой
                barBrush = new TextureBrush(pic);
            }
        }

        /// <summary>
        /// Перерассччёт размеров областей контролла
        /// </summary>
        private void setSizes()
        {
            int wi = 2;
            int he = this.Height - 6;
            //Считаем количество прямоугольников бара, с 
            //учётом отступа между ними в 2 пикселя
            int count = (this.Width - 4) / (wi + 2);
            //Если окно не свёрнуто
            if (count > 0)
            {
                //Инициализируем их
                rectBar = new Rectangle[count];
                //Инициализируем их
                for (int i = 0; i < count; i++)
                    rectBar[i] = new Rectangle(2 + i * 4, 2, wi, he);
                //Инициализируем бар перекрытия пустого места
                initCloseBar();
                //Обновляем кисть
                updateBrush();
                //Перерисовываем форму
                this.Invalidate();
            }
        }

        /// <summary>
        /// Инициализируем бар перекрытия пустого места
        /// </summary>
        private void initCloseBar()
        {   //Получаем процентное значение
            double percentVal = (val * 100.0) / maxVal;
            //Рассчитываем текущую ширину заполненной части            
            int left = (int)((this.Width * percentVal) / 100);
            //Рассчитываем ширину нашего бара
            int width = this.Width - left;
            //Инициализируем наш бал
            closeBar = new Rectangle(left, 0, width, this.Height);
        }

        /// <summary>
        /// Обработчик смены размера
        /// </summary>
        private void ManualProgressBar_Resize(object sender, EventArgs e)
        {
            //Перерассччёт размеров областей контролла
            setSizes();
        }

        /// <summary>
        /// Обработчик перерисовки контролла
        /// </summary>
        private void ManualProgressBar_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем прогрессбар
            paint(e.Graphics);
        }

        /// <summary>
        /// Рисуем прогрессбар
        /// </summary>
        /// <param name="gr">Полотно для рисования</param>
        private void paint(Graphics gr)
        {
            //Зарисовываем фон
            gr.Clear(bgColor.Color);
            //Рисуем бары на фоне
            gr.FillRectangles(barBrush, rectBar);
            //Зарисовываем пустое место цветом фона
            gr.FillRectangle(bgColor, closeBar);
        }

    }
}
