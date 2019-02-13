﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExHentaiDownloaderZ_5
{
    public partial class donates : Form
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public donates()
        {
            //Инициализируем компоненты
            InitializeComponent();
            //Инициализируем форму
            init();
        }

        /// <summary>
        /// Инициализатор формы
        /// </summary>
        private void init()
        {
            //Событие перерисовки формы
            this.Paint += Preloader_Paint;
            //Добавляем номер версии в заголовок окна
            headerLabel.Text += $" (ver. {Application.ProductVersion})";
        }


        /// <summary>
        /// Обработчик событяи перерисовки формы
        /// </summary>
        private void Preloader_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем обводку формы
            e.Graphics.DrawRectangle(Pens.Purple, new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }

        /// <summary>
        /// Клик по кнопке закрытяи формы
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            //Скрываем форму
            this.Hide();
        }
    }
}
