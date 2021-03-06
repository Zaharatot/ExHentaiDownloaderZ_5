﻿using PopUpZ.Content.Clases;
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
using SettingsStorageZ.Clases.DataClases;

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

            //Настройки загрузки
            downloadSettingsGroupBox.headerText = SettingsText.downloadSettingsGroupBox;
            rootPageLoadDelayLabel.Text = SettingsText.rootPageLoadDelayLabel;
            mangaInfoLoadDelayLabel.Text = SettingsText.mangaInfoLoadDelayLabel;
            downloadMangaDelayLabel.Text = SettingsText.downloadMangaDelayLabel;
            downloadMangaPageDelayLabel.Text = SettingsText.downloadMangaPageDelayLabel;
            openDownloadFolderFlag.Text = SettingsText.openDownloadFolderFlag;
            newFolderRequestFlag.Text = SettingsText.newFolderRequestFlag;
            createChildFolderFlag.Text = SettingsText.createChildFolderFlag;
            scrollToAddCheckBox.Text = SettingsText.scrollToAddCheckBox;
            scrollToActiveCheckBox.Text = SettingsText.scrollToActiveCheckBox;       
            twinLoadLabel.Text = SettingsText.twinLoadLabel;
            keepOriginalFileNameCheckBox.Text = SettingsText.keepOriginalFileNameCheckBox;
            tryFindOriginalSizeCheckBox.Text = SettingsText.tryFindOriginalSizeCheckBox;

            //Настройки подключения к exhentai
            exhentaiSettingsGroupBox.headerText = SettingsText.exhentaiSettingsGroupBox;
            memberIdLabel.Text = SettingsText.memberIdLabel;
            passHashLabel.Text = SettingsText.passHashLabel;


            //Настройки сохранения
            saveSettingsGroupBox.headerText = SettingsText.saveSettingsGroupBox;
            exitAutosaveFlag.Text = SettingsText.exitAutosaveFlag;
            addElementAutosaveFlag.Text = SettingsText.addElementAutosaveFlag;
            checkStatusesAutosaveFlag.Text = SettingsText.checkStatusesAutosaveFlag;
            loadInfoAutosaveFlag.Text = SettingsText.loadInfoAutosaveFlag;
            loadPagesAutosaveFlag.Text = SettingsText.loadPagesAutosaveFlag;
            autosaveBackupFlag.Text = SettingsText.autosaveBackupFlag;


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
            Program.settingsStorage.settings = new SettingsStorage();

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

            //Параметры загрузки

            //Проставляем путь
            downloadPathTextBox.Text = Program.settingsStorage.settings.downloadPath;
            //Проставляем делеи
            rootPageLoadDelayVal.Value = Program.settingsStorage.settings.rootPageLoadDelay;
            mangaInfoLoadDelayVal.Value = Program.settingsStorage.settings.mangaInfoLoadDelay;
            downloadMangaDelayVal.Value = Program.settingsStorage.settings.downloadMangaDelay;
            downloadMangaPageDelayVal.Value = Program.settingsStorage.settings.downloadMangaPageDelay;
            //Проставляем флаги
            openDownloadFolderFlag.Checked = Program.settingsStorage.settings.openDownloadFolder;
            newFolderRequestFlag.Checked = Program.settingsStorage.settings.newFolderRequest;
            createChildFolderFlag.Checked = Program.settingsStorage.settings.createChildFolder;
            keepOriginalFileNameCheckBox.Checked = Program.settingsStorage.settings.keepOriginalFileName;
            tryFindOriginalSizeCheckBox.Checked = Program.settingsStorage.settings.tryFindOriginalSize;

            //Параметры подключения к exhentai
            memberIdTextBox.Text = Program.settingsStorage.settings.ipb_member_id;
            passHashTextBox.Text = Program.settingsStorage.settings.ipb_pass_hash;

            //Параметры сохранения
            exitAutosaveFlag.Checked = Program.settingsStorage.settings.exitAutosave;
            addElementAutosaveFlag.Checked = Program.settingsStorage.settings.addElementAutosave;
            checkStatusesAutosaveFlag.Checked = Program.settingsStorage.settings.checkStatusesAutosave;
            loadInfoAutosaveFlag.Checked = Program.settingsStorage.settings.loadInfoAutosave;
            loadPagesAutosaveFlag.Checked = Program.settingsStorage.settings.loadPagesAutosave;
            autosaveBackupFlag.Checked = Program.settingsStorage.settings.autosaveBackup;

            scrollToAddCheckBox.Checked = Program.settingsStorage.settings.scrollToAdd;
            scrollToActiveCheckBox.Checked = Program.settingsStorage.settings.scrollToActive;


            twinLoadVal.Value = Program.settingsStorage.settings.twinLoadCount;
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
                //Параметры загрузки

                //Проставляем путь
                Program.settingsStorage.settings.downloadPath = downloadPathTextBox.Text;
                //Проставляем делеи
                Program.settingsStorage.settings.rootPageLoadDelay = (int)rootPageLoadDelayVal.Value;
                Program.settingsStorage.settings.mangaInfoLoadDelay = (int)mangaInfoLoadDelayVal.Value;
                Program.settingsStorage.settings.downloadMangaDelay = (int)downloadMangaDelayVal.Value;
                Program.settingsStorage.settings.downloadMangaPageDelay = (int)downloadMangaPageDelayVal.Value;
                //Проставляем флаги
                Program.settingsStorage.settings.openDownloadFolder = openDownloadFolderFlag.Checked;
                Program.settingsStorage.settings.newFolderRequest = newFolderRequestFlag.Checked;
                Program.settingsStorage.settings.createChildFolder = createChildFolderFlag.Checked;
                Program.settingsStorage.settings.keepOriginalFileName = keepOriginalFileNameCheckBox.Checked;
                Program.settingsStorage.settings.tryFindOriginalSize = tryFindOriginalSizeCheckBox.Checked;

                //Параметры подключения к exhentai
                Program.settingsStorage.settings.ipb_member_id = memberIdTextBox.Text;
                Program.settingsStorage.settings.ipb_pass_hash = passHashTextBox.Text;

                //Параметры сохранения
                Program.settingsStorage.settings.exitAutosave = exitAutosaveFlag.Checked;
                Program.settingsStorage.settings.addElementAutosave = addElementAutosaveFlag.Checked;
                Program.settingsStorage.settings.checkStatusesAutosave = checkStatusesAutosaveFlag.Checked;
                Program.settingsStorage.settings.loadInfoAutosave = loadInfoAutosaveFlag.Checked;
                Program.settingsStorage.settings.loadPagesAutosave = loadPagesAutosaveFlag.Checked;
                Program.settingsStorage.settings.autosaveBackup = autosaveBackupFlag.Checked;

                Program.settingsStorage.settings.scrollToAdd = scrollToAddCheckBox.Checked;
                Program.settingsStorage.settings.scrollToActive = scrollToActiveCheckBox.Checked;

                Program.settingsStorage.settings.twinLoadCount = (int)twinLoadVal.Value;

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
