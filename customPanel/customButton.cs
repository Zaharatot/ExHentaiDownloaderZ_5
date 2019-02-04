using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomButton
{
    /// <summary>
    /// Кастомная плоская кнопка
    /// </summary>
    public partial class customButton : UserControl
    {



        /// <summary>
        /// Конструктор класса
        /// </summary>
        public customButton()
        {
            //Инициализируем элементы
            InitializeComponent();
            //Инициализируем класс
            init();
        }

        /// <summary>
        /// Инициализатор класса
        /// </summary>
        private void init()
        {
            //Инициализируем события
            initEvents();
        }

        /// <summary>
        /// Инициализируем события
        /// </summary>
        private void initEvents()
        {
            //Инициализируем обработчик события перерисовки элемента
            this.Paint += CustomButton_Paint;
        }

        /// <summary>
        /// Событие перерисовки элемента
        /// </summary>
        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
      /*      //Рисуем обводку формы
            e.Graphics.DrawRectangle(Pens.Purple, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            e.Graphics.DrawRectangle(Pens.Purple, new Rectangle(1, 1, this.Width - 2, this.Height - 2));*/
        }
    }
}
