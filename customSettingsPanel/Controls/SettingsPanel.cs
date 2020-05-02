using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using customSettingsPanel.Clases;

namespace customSettingsPanel.Controls
{
    /// <summary>
    /// Контролл универсальной панели настроек
    /// </summary>
    public partial class SettingsPanel : UserControl
    {
        /// <summary>
        /// Отступ между полями
        /// </summary>
        private const int fieldsPadding = 5;

        /// <summary>
        /// Список полей контролла
        /// </summary>
        public SettingsField[] Fields
        {
            get
            {
                //Возвращаем значение
                return _fields.ToArray();
            }
            set
            {
                //Проставляем полученное значение
                _fields = value.ToList();
                //Обновляем контролл
                update();
            }
        }

        /// <summary>
        /// Обводка контролла
        /// </summary>
        public Border ControlBorder
        {
            get
            {
                //Возвращаем значение
                return _border;
            }
            set
            {
                //Проставляем полученное значение
                _border = value;
                //Добавляем обработчик события перерисовки обводки
                _border.ReDrawEventArgs += _border_ReDrawEventArgs;
                //Перерисовываем контролл
                this.Invalidate();
            }
        }

        /// <summary>
        /// Список полей контролла
        /// </summary>
        private List<SettingsField> _fields = new List<SettingsField>();
        /// <summary>
        /// Обводка контролла
        /// </summary>
        public Border _border = new Border();




        /// <summary>
        /// Конструктор класса
        /// </summary>
        public SettingsPanel()
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
            //Добавляем обработчик события перерисовки контролла
            this.Paint += SettingsPanel_Paint;
            //Добавляем обработчик события перерисовки обводки
            _border.ReDrawEventArgs += _border_ReDrawEventArgs;
            //Обновляем и перерисовываем контролл
            update();
            this.Invalidate();
        }



        /// <summary>
        /// Обновление контрола
        /// </summary>
        private void update()
        {
            //Очищаем список контроллов на панели
            this.Controls.Clear();
            //Проходимся по списку полей
            for(int i = 0; i < _fields.Count; i++)
            {
                //Прописываем позицию контролла
                _fields[i].Dock = DockStyle.Top;
                //Для всех кроме первого поля
                if (i > 0)
                    //Проставляем отступы
                    _fields[i].Margin = new Padding(0, 0, 0, fieldsPadding);
                 

                //Добавляем поле на панель
                this.Controls.Add(_fields[i]);
            }
        }



        /// <summary>
        /// Обработчик события перерисовки контролла
        /// </summary>
        private void SettingsPanel_Paint(object sender, PaintEventArgs e)
        {
            //Если обводка нужна
            if(_border.DrawBorder)
                //Рисуем обводку
                e.Graphics.DrawRectangle(_border.getPen(), _border.GetRectangle(this.Width, this.Height));
        }

        /// <summary>
        /// Обработчик события перерисовки обводки
        /// </summary>
        private void _border_ReDrawEventArgs()
        {
            //Перерисовываем панель
            this.Invalidate();
        }

        /// <summary>
        /// Возвращаем значение поля, по его названию
        /// </summary>
        /// <param name="name">Название поля, из которого получаем значение</param>
        /// <returns></returns>
        public object getFieldValue(string name)
        {
            //По умолчанию будем возвращать пустое значение
            object ex = null;

            try
            {
                //Ищем поле с таким названием
                var field = _fields.FirstOrDefault(fl => (fl.Name == name));
                //Если поле найдено
                if(field != null)
                {

                }
            }
            catch { }

            //Возвращаем результат
            return ex;
        }

        /// <summary>
        /// Возвращает список названий полей
        /// </summary>
        /// <returns>Список имён</returns>
        public string[] getFieldsNames()
        {
            //По умолчанию вернём пустой массив
            string[] ex = new string[0];

            try
            {
                //Инициализируем выходной массив
                ex = new string[_fields.Count];
                //Проходимся по списку полей
                for (int i = 0; i < _fields.Count; i++)
                    //Добавляем имя в выходной массив
                    ex[i] = _fields[i].Name;
            }
            catch { ex = new string[0]; }

            //Возвращаем результат
            return ex;
        }
    }
}
