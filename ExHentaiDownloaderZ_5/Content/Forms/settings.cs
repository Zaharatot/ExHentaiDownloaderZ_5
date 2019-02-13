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
    /// <summary>
    /// Форма настроек приложения
    /// </summary>
    public partial class settings : Form
    {


        /// <summary>
        /// Конструктор формы
        /// </summary>
        public settings()
        {
            //Инициализируем компоненты
            InitializeComponent();
            //Инициализируем форму
            init();
        }

        /// <summary>
        /// Инициализатор формы
        /// </summary>
        public void init()
        {
            //Проверяем наличие настроек приложения
            checkEmptySettings();
            //Инициализируем события
            initEvents();
        }

        /// <summary>
        /// Инициализируем события
        /// </summary>
        private void initEvents()
        {
            //Клик по кнопке закрытия формы
            customTopBar1.onCloseButtonClick += CustomTopBar1_onCloseButtonClick;

            //Событие перерисовки формы
            this.Paint += Settings_Paint;
        }

        /// <summary>
        /// Обработчик соыбтия закрытия формы
        /// </summary>
        private void CustomTopBar1_onCloseButtonClick()
        {
            //Скрываем форму
            this.Hide();
        }


        /// <summary>
        /// Обработчик событяи перерисовки формы
        /// </summary>
        private void Settings_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем обводку формы
            e.Graphics.DrawRectangle(Pens.Purple, new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }

        /// <summary>
        /// Проверка пустых настроек
        /// </summary>
        private void checkEmptySettings()
        {
            //Если у нас нету пути сохранения
            if ((Properties.Settings.Default.downloadPath == null)
                || (Properties.Settings.Default.downloadPath.Length == 0))
                //Прописываем дефолтные настройки
                setSettingsAsDefault();
            else
                //Выводим настройки
                loadSettings();
        }

        /// <summary>
        /// Установка всех значений в дефолтные
        /// </summary>
        private void setSettingsAsDefault()
        {
            //Прописываем параметры
            Properties.Settings.Default.downloadPath = Application.StartupPath + @"\Files\";
            Properties.Settings.Default.ipb_member_id = "";
            Properties.Settings.Default.ipb_pass_hash = "";

            //Сохраняем изменения настроек
            Properties.Settings.Default.Save();

            //Подгружаем изменённые значения настроек на форму
            loadSettings();
        }

        /// <summary>
        /// Загрузка настроек из файла параметров
        /// </summary>
        private void loadSettings()
        {
            //Выводим параметры в текстовые поля
            downloadPathTextBox.Text = Properties.Settings.Default.downloadPath;
            memberIdTextBox.Text = Properties.Settings.Default.ipb_member_id;
            passHashTextBox.Text = Properties.Settings.Default.ipb_pass_hash;
        }


        /// <summary>
        /// Сохранение настроек настроек в файл параметров
        /// </summary>
        private void saveSettings()
        {
            //Прописываем новые параметры
            Properties.Settings.Default.downloadPath = downloadPathTextBox.Text;
            Properties.Settings.Default.ipb_member_id = memberIdTextBox.Text;
            Properties.Settings.Default.ipb_pass_hash = passHashTextBox.Text;

            //Сохраняем изменения настроек
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Событие клика по кнопке сброса настроек в дефолтные
        /// </summary>
        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {
            //Прописываем дефолтные настройки
            setSettingsAsDefault();
        }

        /// <summary>
        /// Событие клика по кнопке сохранения параметров
        /// </summary>
        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            //Сохраняем текущие параметры
            saveSettings();
        }
    }
}
