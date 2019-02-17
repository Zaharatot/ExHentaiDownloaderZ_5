using PopUpZ.Content.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Resources;

namespace ExHentaiDownloaderZ_5
{
    /// <summary>
    /// Форма настроек приложения
    /// </summary>
    public partial class settings : Form
    {
        /// <summary>
        /// Класс попапов
        /// </summary>
        private PopupLoader pl;



        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="pl">Класс попапов</param>
        public settings(PopupLoader pl)
        {
            //Инициализируем компоненты
            InitializeComponent();
            //Сохраняем класс попапов, переданный из главной формы
            this.pl = pl; 
            //Инициализируем форму
            init();
        }

        /// <summary>
        /// Инициализатор формы
        /// </summary>
        public void init()
        {
            //Загружаем текст в контроллы
            loadTextFromResources();
            //Выводим все параметры на экран
            loadSettings();
            //Инициализируем события
            initEvents();
        }


        /// <summary>
        /// Загружаем текст из ресурсов в элементы
        /// </summary>
        private void loadTextFromResources()
        {
            //Заголовок
            customTopBar1.headerText = SettingsText.customTopBarHeader;
            //Подписи
            downloadPathLabel.Text = SettingsText.downloadPathLabel;
            memberIdLabel.Text = SettingsText.memberIdLabel;
            passHashLabel.Text = SettingsText.passHashLabel;
            //Кнопки
            saveSettingsButton.Text = SettingsText.saveSettingsButton;
            cancelSettingsButton.Text = SettingsText.cancelSettingsButton;
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
        /// Установка всех значений в дефолтные
        /// </summary>
        private void setSettingsAsDefault()
        {
            //Инициализируем все параметры дефолтными значениями
            Program.settingsStorage = new SettingsStorageZ.Clases.Settings();

            //Сохраняем изменения настроек
            Program.settingsStorage.saveSettings();

            //Подгружаем изменённые значения настроек на форму
            loadSettings();
        }

        /// <summary>
        /// Загрузка настроек из файла параметров
        /// </summary>
        private void loadSettings()
        {
            //Выводим параметры в текстовые поля
            downloadPathTextBox.Text = Program.settingsStorage.settings.downloadPath;
            memberIdTextBox.Text = Program.settingsStorage.settings.ipb_member_id;
            passHashTextBox.Text = Program.settingsStorage.settings.ipb_pass_hash;
        }


        /// <summary>
        /// Сохранение настроек настроек в файл параметров
        /// </summary>
        /// <returns>0 - всё ок, иначе - код ошибки</returns>
        private byte saveSettings()
        {
            byte ex = 1;

            try
            {
                //Прописываем новые параметры
                Program.settingsStorage.settings.downloadPath = downloadPathTextBox.Text;
                Program.settingsStorage.settings.ipb_member_id = memberIdTextBox.Text;
                Program.settingsStorage.settings.ipb_pass_hash = passHashTextBox.Text;

                //Сохраняем изменения настроек
                Program.settingsStorage.saveSettings();

                //Загружаем параметры, на случай если при сохранении были правки
                loadSettings();

                //Всё ок
                ex = 0;
            }
            catch { ex = 1; }

            return ex;
        }

        /// <summary>
        /// Событие клика по кнопке сброса настроек в дефолтные
        /// </summary>
        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {
            //Запрос сброса настроек на дефолтные
            if(pl.showMessage(6) == DialogResult.Yes)
                //Прописываем дефолтные настройки
                setSettingsAsDefault();
        }

        /// <summary>
        /// Событие клика по кнопке сохранения параметров
        /// </summary>
        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            //Сохраняем текущие параметры
            byte result = saveSettings();
            //Результат сохранения настроек
            pl.showMessage(7, result);
        }
    }
}
