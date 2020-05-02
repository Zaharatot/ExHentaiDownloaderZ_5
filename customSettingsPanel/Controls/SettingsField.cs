using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customSettingsPanel.Controls
{
    /// <summary>
    /// Класс контролла панели настроек
    /// </summary>
    public partial class SettingsField : UserControl
    {
        /// <summary>
        /// Дефолтная высота контролла
        /// </summary>
        private const int defaultHeight = 30;
        /// <summary>
        /// Дефолтная двойная высота контролла
        /// </summary>
        private const int defaultDoubleHeight = 51;

        /// <summary>
        /// Перечисление типов полей настроек
        /// </summary>
        public enum FieldType
        {
            TextBox,
            Numeric,
            ComboBox,
            CheckBox,
            Line,
            MinMaxNumeric
        }

        /// <summary>
        /// Перечисление позиций подписи
        /// </summary>
        public enum LabelPosition
        {
            Top,
            Left
        }




        /// <summary>
        /// Позиция подписи
        /// </summary>
        public LabelPosition Position
        {
            get
            {
                //Возвращаем значение
                return _position;
            }
            set
            {
                //Проставляем полученное значение
                _position = value;
                //Обновляем контролл
                update();
            }
        }

        /// <summary>
        /// Тип вводимого значения
        /// </summary>
        public FieldType Type
        {
            get
            {
                //Возвращаем значение
                return _type;
            }
            set
            {
                //Проставляем полученное значение
                _type = value;
                //Обновляем контролл
                update();
            }
        }

        /// <summary>
        /// Список значений для спискового поля
        /// </summary>
        public string[] ComboBoxValues
        {
            get
            {
                //Возвращаем значение
                return _comboBoxValues;
            }
            set
            {
                //Проставляем полученное значение
                _comboBoxValues = value;
                //Обновляем контролл
                update();
            }
        }

        /// <summary>
        /// Подпись на контролле. Перегружаем базовый параметр.
        /// </summary>
        public override string Text
        {
            get
            {
                //Возвращаем значение
                return _text;
            }
            set
            {
                //Проставляем полученное значение
                _text = value;
                //Обновляем контролл
                update();
            }
        }

        /// <summary>
        /// Значение объекта
        /// </summary>
        public string Value
        {
            get
            {
                //Возвращаем значение
                return _value;
            }
            set
            {
                //Проставляем полученное значение
                _value = value;
                //Обновляем контролл
                update();
            }
        }

        /// <summary>
        /// Минимальное значение для числового поля
        /// </summary>
        public int NumericMin
        {
            get
            {
                //Возвращаем значение
                return _numericMin;
            }
            set
            {
                //Проставляем полученное значение
                _numericMin = value;
                //Обновляем контролл
                update();
            }
        }

        /// <summary>
        /// Максимальное значение для числового поля
        /// </summary>
        public int NumericMax
        {
            get
            {
                //Возвращаем значение
                return _numericMax;
            }
            set
            {
                //Проставляем полученное значение
                _numericMax = value;
                //Обновляем контролл
                update();
            }
        }


        /// <summary>
        /// Цвет линии для типа Line
        /// </summary>
        public Color LineColor
        {
            get
            {
                //Возвращаем значение
                return _lineColor.Color;
            }
            set
            {
                //Проставляем полученное значение
                _lineColor = new Pen(value);
                //Обновляем контролл
                update();
            }
        }


        /// <summary>
        /// Позиция подписи
        /// </summary>
        private LabelPosition _position = LabelPosition.Left;
        /// <summary>
        /// Тип поля
        /// </summary>
        private FieldType _type = FieldType.TextBox;
        /// <summary>
        /// Список значений комбобокса
        /// </summary>
        private string[] _comboBoxValues = new string[0];
        /// <summary>
        /// Надпись на контролле
        /// </summary>
        private string _text = "Settings Field: ";
        /// <summary>
        /// Значение контролла
        /// </summary>
        private string _value = "";

        /// <summary>
        /// Минимальное значение для числового поля
        /// </summary>
        private int _numericMin = 0;
        /// <summary>
        /// Максимальное значение для числового поля
        /// </summary>
        private int _numericMax = 100;

        /// <summary>
        /// Цвет линии
        /// </summary>
        private Pen _lineColor = Pens.Black;


        /* Список внутренних контроллов */

        /// <summary>
        /// Подпись контролла
        /// </summary>
        private Label title;
        /// <summary>
        /// Текстовое поле
        /// </summary>
        private TextBox text;
        /// <summary>
        /// Поле ввода цифр
        /// </summary>
        private NumericUpDown numeric;
        /// <summary>
        /// Поле ввода списка
        /// </summary>
        private ComboBox combo;
        /// <summary>
        /// Поле ввода флага
        /// </summary>
        private CheckBox check;
        /// <summary>
        /// Поле ввода цифр, для минимального значения
        /// </summary>
        private NumericUpDown numericMin;
        /// <summary>
        /// Поле ввода цифр, для максимального значения
        /// </summary>
        private NumericUpDown numericMax;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public SettingsField()
        {
            //Инициализация компонентов
            InitializeComponent();
            //Инициализируем класс
            init();
        }


        /// <summary>
        /// Инициализатор класса
        /// </summary>
        private void init()
        {
            //Инициализируем все виды полей
            initControls();
            //Инициализируем обработчики событий
            initActions();
        }


        /// <summary>
        /// Инициализируем обработчики событий
        /// </summary>
        private void initActions()
        {
            //Добавляем обработчик события изменения размера контролла
            this.Resize += SettingsField_Resize;
            //Добавляем обработчик события перерисовки контролла
            this.Paint += SettingsField_Paint;
            //Добавляем обработчик события изменения значения числового поля
            numeric.ValueChanged += Numeric_ValueChanged;
            //Добавляем обработчик события выбора значения в списке
            combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
            //Добавляем обработчик события изменения содержимого текстового поля
            text.TextChanged += Text_TextChanged;
            //Добавляем обработчик события изменения значения флага
            check.CheckedChanged += Check_CheckedChanged;
        }




        /// <summary>
        /// Инициализируем все виды полей
        /// </summary>
        private void initControls()
        {
            //Инициализируем контроллы
            title = new Label();
            text = new TextBox();
            numeric = new NumericUpDown();
            combo = new ComboBox();
            check = new CheckBox();
            numericMin = new NumericUpDown();
            numericMax = new NumericUpDown();

            //Проставляем контроллам значения
            //Заголовок
            title.AutoSize = false;
            title.AutoEllipsis = true;
            title.Height = 20;

            //Добавляем проинициализированные контроллы на форму
            this.Controls.Add(title);
            this.Controls.Add(text);
            this.Controls.Add(numeric);
            this.Controls.Add(combo);
            this.Controls.Add(check);
            this.Controls.Add(numericMin);
            this.Controls.Add(numericMax);

            //Обновляем контроллы
            update();
        }

        /// <summary>
        /// Обновление контрола
        /// </summary>
        private void update()
        {
            //Скрываем все контроллы
            hideAll();
            //Обновляем подпись
            updateLabel();
            //Обновляем разположения контроллов
            updatePositions();
            //Выбираем действие по типу
            switch (_type)
            {
                case FieldType.CheckBox:
                    {
                        //Обновляем флаг
                        updateCheckBox();
                        break;
                    }
                case FieldType.ComboBox:
                    {
                        //Обновляем выпадающий список
                        updateCombo();
                        break;
                    }
                case FieldType.Numeric:
                    {
                        //Обновляем числовое поле
                        updateNumeric();
                        break;
                    }
                case FieldType.TextBox:
                    {
                        //Обновляем текстовое поле
                        updateTextBox();
                        break;
                    }
                case FieldType.Line:
                    {
                        //При линии ничего не делаем
                        break;
                    }
            }

            //Перерисовываем контролл
            this.Invalidate();
        }

        /// <summary>
        /// Обновляем подпись
        /// </summary>
        private void updateLabel()
        {
            //Если у нас не флаг
            if (_type != FieldType.CheckBox)
            {
                //Обновляем подпись
                title.Text = _text;
                //Отображаем контролл
                title.Visible = true;
            }
        }

        /// <summary>
        /// Обновляем выпадающий список
        /// </summary>
        private void updateCombo()
        {
            //Идентификатор выбранного значения
            int selectId = 0;
            //Очищаем комбобокс
            combo.Items.Clear();
            //Заполняем его заново
            combo.Items.AddRange(_comboBoxValues);
            //Если ошибка парсинга в число
            if (!int.TryParse(_value, out selectId))
                //Проставляем дефолт
                selectId = 0;
            //Если значение индекса находится в пределах доступного
            if ((selectId >= -1) && (selectId < combo.Items.Count))
                //Проставляем его
                combo.SelectedIndex = selectId;
            //Отображаем контролл
            combo.Visible = true;
        }

        /// <summary>
        /// Обновляем флаг
        /// </summary>
        private void updateCheckBox()
        {
            //Флаг чекбокса
            bool flag = false;
            //Обновляем подпись
            check.Text = _text;
            //Если ошибка парсинга во флаг
            if (!bool.TryParse(_value, out flag))
                //Проставляем дефолт
                flag = false;
            //Проставляем значение флага
            check.Checked = flag;
            //Отображаем контролл
            check.Visible = true;
        }

        /// <summary>
        /// Обновляем числовое поле
        /// </summary>
        private void updateNumeric()
        {
            //Числовое значение
            int val = 0;
            //Если ошибка парсинга в число
            if (!int.TryParse(_value, out val))
                //Проставляем дефолт
                val = 0;
            //Если значение больше максимума
            if (val > _numericMax)
                //Ставим его на максимум
                val = _numericMax;
            //Если значение меньше минимума
            else if (val < _numericMin)
                //Ставим его на минимум
                val = _numericMin;
            //Проставляем минимум и максимум
            numeric.Maximum = _numericMax;
            numeric.Minimum = _numericMin;
            //Проставляем значение
            numeric.Value = val;
            //Отображаем контролл
            numeric.Visible = true;
        }

        /// <summary>
        /// Обновляем текстовое поле
        /// </summary>
        private void updateTextBox()
        {
            //Проставляем значение
            text.Text = _value;
            //Отображаем контролл
            text.Visible = true;
        }


        /// <summary>
        /// Скрываем все контроллы
        /// </summary>
        private void hideAll()
        {
            //Проходимся по списку контроллов на форме
            foreach (Control c in this.Controls)
                //Скрываем все
                c.Visible = false;
        }


        /// <summary>
        /// Обновляем разположения контроллов
        /// </summary>
        private void updatePositions()
        {
            //Если у нас не флаг
            if (_type == FieldType.CheckBox)
            {
                //Обновляем высоту контролла
                this.Height = defaultHeight;
                //Заполняем контролл чекбоксом
                check.Dock = DockStyle.Fill;
            }
            //Если у нас линия
            else if (_type == FieldType.Line)
                //Обновляем позиции при типе - линия
                updatePositionsLine();
            else
            {
                //Обновляем позицию по типу
                switch (_position)
                {
                    case LabelPosition.Left:
                        {
                            //Обновляем позиции при левом расположении надписи
                            updatePositionsLabelLeft();
                            break;
                        }
                    case LabelPosition.Top:
                        {
                            //Обновляем позиции при верхнем расположении надписи
                            updatePositionsLabelTop();
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Обновляем позиции при типе - линия
        /// </summary>
        private void updatePositionsLine()
        {
            //Обновляем высоту контролла
            this.Height = defaultHeight;

            //Обновляем ширину лейбла, получив её из ширины текста и отступов
            title.Width = TextRenderer.MeasureText(title.Text, title.Font).Width +
                title.Padding.Horizontal;  
            //Обновляем расположение лейбла
            title.Dock = DockStyle.None;
            //Обновляем расположение надписи в лейбле
            title.TextAlign = ContentAlignment.MiddleCenter;
            //Обновляем отступ лейбла
            title.Left = (this.Width - title.Width) / 2;
            title.Top = (this.Height - title.Height) / 2;            
        }

        /// <summary>
        /// Обновляем позиции при левом расположении надписи
        /// </summary>
        private void updatePositionsLabelLeft()
        {
            //Обновляем высоту контролла
            this.Height = defaultHeight;

            //Получаем ширину рабочего поля контролла
            int width = this.Width - this.Padding.Horizontal;

            //Обновляем ширину лейбла (с отступом)
            title.Width = width / 2 - 5;
            //Обновляем расположение лейбла
            title.Dock = DockStyle.Left;
            //Обновляем расположение надписи в лейбле
            title.TextAlign = ContentAlignment.MiddleRight;

            //Остальные компоненты ставим в правую сторону
            combo.Dock = text.Dock = numeric.Dock = DockStyle.Right;
            //И прописываем им новую ширину
            combo.Width = text.Width = numeric.Width = width - title.Width;
        }

        /// <summary>
        /// Обновляем позиции при верхнем расположении надписи
        /// </summary>
        private void updatePositionsLabelTop()
        {
            //Обновляем высоту контролла
            this.Height = defaultDoubleHeight;

            //Обновляем расположение
            title.Dock = DockStyle.Top;
            //Обновляем расположение надписи в лейбле
            title.TextAlign = ContentAlignment.MiddleLeft;

            //Остальные компоненты ставим в нижнюю часть поля
            combo.Dock = text.Dock = numeric.Dock = DockStyle.Bottom;
        }


        /* Обработчики событий */

        /// <summary>
        /// Обработчик события изменения размера контролла
        /// </summary>
        private void SettingsField_Resize(object sender, EventArgs e)
        {
            //бновляем разположения контроллов
            updatePositions();
        }


        /// <summary>
        /// Обработчик события перерисовки контролла
        /// </summary>
        private void SettingsField_Paint(object sender, PaintEventArgs e)
        {
            //Если у нас тип - линия
            if(_type == FieldType.Line)
            {
                //Получаем позицию линии по высоте
                int top = defaultHeight / 2;
                //Получаем позиции левой и правой точки линии
                int left = this.Padding.Left;
                int right = this.Width - this.Padding.Right;

                //Рисуем линиию
                e.Graphics.DrawLine(_lineColor, left, top, right, top);
            }
        }

        /* События изменения значения */

        /// <summary>
        /// Обработчик события изменения значения флага
        /// </summary>
        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            //Возвращаем значение
            _value = check.Checked.ToString();
        }

        /// <summary>
        /// Обработчик события изменения содержимого текстового поля
        /// </summary>
        private void Text_TextChanged(object sender, EventArgs e)
        {
            //Возвращаем значение
            _value = text.Text;
        }

        /// <summary>
        /// Обработчик события выбора значения в списке
        /// </summary>
        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Возвращаем значение
            _value = combo.SelectedIndex.ToString();
        }

        /// <summary>
        /// Обработчик события изменения значения числового поля
        /// </summary>
        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            //Возвращаем значение
            _value = numeric.Value.ToString();
        }
    }
}
