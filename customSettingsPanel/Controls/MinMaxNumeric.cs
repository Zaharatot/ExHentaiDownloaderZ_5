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
    /// Контролл, позволяющий выбрать минимальное и максимальное значения
    /// </summary>
    public partial class MinMaxNumeric : UserControl
    {
        /// <summary>
        /// Лимит минимального значения
        /// </summary>
        public int MinimumLimit { get; set; }
        /// <summary>
        /// Лимит максимального значения
        /// </summary>
        public int MaximumLimit { get; set; }



        /// <summary>
        /// Конструктор контролла
        /// </summary>
        public MinMaxNumeric()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Инициализатор класса
        /// </summary>
        private void Init()
        {
            //Добавляем обработчик события изменения размера контролла
            this.Resize += MinMaxNumeric_Resize;
        }

        /// <summary>
        /// Обработчик события изменения размера контролла
        /// </summary>
        private void MinMaxNumeric_Resize(object sender, EventArgs e)
        {

        }
    }
}
