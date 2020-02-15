using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExHentaiDownloaderZ_5.Content.Clases.DataClases;
using ExHentaiDownloaderZ_5.Content.Clases.WorkClases;
using PopUpZ.Content.Clases;
using Resources;


namespace ExHentaiDownloaderZ_5
{
    /// <summary>
    /// Класс основной формы приложения
    /// </summary>
    public partial class main : Form
    {
        /// <summary>
        /// Главный рабочий класс программы
        /// </summary>
        private mainWorker mw;
        /// <summary>
        /// Класс попапов
        /// </summary>
        private PopupLoader pl;

        /// <summary>
        /// Форма настроек приложения
        /// </summary>
        private settings sf;
        /// <summary>
        /// Форма донатов
        /// </summary>
        private donates df;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public main()
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
            //Инициализхируем класс всплывающих сообщений
            pl = new PopupLoader();
            //Инициализируем основной рабочий класс
            mw = new mainWorker(pl);

            //Инициализируем форму настроек
            sf = new settings(pl);
            //Инициализируем форму предзагрузчика
            df = new donates();

            //Загружаем текст в контроллы
            loadTextFromResources();

            //Добавляем номер версии в заголовок окна
            customTopBar1.headerText += $" (ver. {Application.ProductVersion})";

            //Инициализируем события
            initEvents();
        }


        /// <summary>
        /// Загружаем текст из ресурсов в элементы
        /// </summary>
        private void loadTextFromResources()
        {
            //Заголовок
            customTopBar1.headerText = MainText.customTopBarHeader;
            //Кнопки
            removeButton.Text = MainText.removeButton;
            clearButton.Text = MainText.clearButton;
            saveButton.Text = MainText.saveButton;
            loadButton.Text = MainText.loadButton;
            downloadButton.Text = MainText.downloadButton;
            settingsButton.Text = MainText.settingsButton;
            //Заголовки столбцов
            downloadTable.Columns["url"].HeaderText = MainText.urlColumnHeader;
            downloadTable.Columns["name"].HeaderText = MainText.nameColumnHeader;
            downloadTable.Columns["pages"].HeaderText = MainText.pagesColumnHeader;
            downloadTable.Columns["status"].HeaderText = MainText.statusColumnHeader;
        }



        /// <summary>
        /// Инициализируем события
        /// </summary>
        private void initEvents()
        {
            //Событие обновления процесса загрузки
            mw.onUpdateDownload += Mw_onUpdateDownload;
            //Событие ошибки по лимитам
            mw.onLimiteError += Mw_onLimiteError;

            //Клики по кнопкам управления окном
            customTopBar1.onCloseButtonClick += CustomTopBar1_onCloseButtonClick;
            //Кнопку разворачивания мы пока что отключили
            //   customTopBar1.onMaximizeButtonClick += CustomTopBar1_onMaximizeButtonClick;
            customTopBar1.onMinimizeButtonClick += CustomTopBar1_onMinimizeButtonClick;
            //Событие перерисовки формы
            this.Paint += Main_Paint;
            //Событие изменения размера формы
            this.Resize += Main_Resize;
            //Событие завершения загрузки формы
            this.Load += Main_Load;
        }

        /// <summary>
        /// Обработчик события ошибки по лимитам
        /// </summary>
        private void Mw_onLimiteError(object sender, EventArgs e)
        {
            //Запускаем событие в UI-потоке
            this.BeginInvoke(new Action(() => { 
                //Выводим сообщение об ошибке
                pl.showMessage(9);
                //Проставляем активность кнопкам
                setButtonsEnableStatus(true);
            }));
        }

        /// <summary>
        /// Обработчик события первой загрузки формы
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            //Запрашиваем обновление данных на форме 
            mw.updateDownloadExec(-1);
        }

        /// <summary>
        /// Событие обновления процесса загрузки
        /// </summary>
        /// <param name="downloadInfo">Информация о процессе загрузки</param>
        /// <param name="mangaTable">Список манги, для таблицы</param>
        /// <param name="finalWork">Флаг завершения работы</param>
        /// <param name="toDown">Флаг необходимости прокрутки страницы вниз</param>
        /// <param name="selected">Id выбранной задачи</param>
        private void Mw_onUpdateDownload(DownloadProgressInfo downloadInfo, 
            List<TableMangaInfo> mangaTable, bool finalWork, bool toDown, int selected)
        {
            //Выполняем действия в основном потоке
            this.BeginInvoke(new Action(()=> {
                //Обновляем таблицу манги
                updateTable(mangaTable);
                //Обновляем значения контроллов
                updateElems(downloadInfo);

                //Если нужно опустить вниз
                if (toDown)
                    //Опускаем
                    scrollToDown();

                //Если работа была завершена
                if (finalWork)
                    //Вызываем сообщение о завершении загрузки
                    pl.showMessage(0);

                //Выделяем строку активной задачи
                scrollToActive(selected);
            }));
        }

        /// <summary>
        /// Обновляем значеняи контроллов
        /// </summary>
        /// <param name="info">ИНформация о процессе загрузки</param>
        private void updateElems(DownloadProgressInfo info)
        {
            //Обновляем строки статусов
            mainProgressLabel.Text = info.getFullStatus();
            secondaryProgressLabel.Text = info.getCurrentStatus();
            loadTimeLabel.Text = info.getLoadTime();
            stepInfoLabel.Text = info.getStep();
            //Обновляем прогрессбары
            mainProgress.max = info.maxFull;
            mainProgress.value = info.currentFull;
            secondaryProgress.max = info.maxCurr;
            secondaryProgress.value = info.currentCurr;
            //Проставляем активность кнопкам
            setButtonsEnableStatus(!info.finalFlag);
        }

        /// <summary>
        /// Проставляем активность кнопкам
        /// </summary>
        /// <param name="status">Статус активности. True - если активны</param>
        private void setButtonsEnableStatus(bool status)
        {
            //Проходимся по панели с кнопками
            foreach (var elem in controlPanel.Controls)
                //Если элемент - кнопка
                if (elem.GetType().Equals(typeof(Button)))
                    //Проставляем активность
                    ((Button)elem).Enabled = status;
        }


        /// <summary>
        /// Обновляем таблицу манги
        /// </summary>
        /// <param name="mangaTable">Список манги, для таблицы</param>
        private void updateTable(List<TableMangaInfo> mangaTable)
        {
            object[] buff;
            //Получаем id выделенной строки
            int selId = getSelectedRowId();
            //Получаем id первой видимой в элементе строки
            int scrollId = downloadTable.FirstDisplayedScrollingRowIndex;


            //Считаем разницу в количестве строк
            int diff = downloadTable.RowCount - mangaTable.Count;
            //Если строк нужно больше
            if (diff < 0)
                //Добавляем пустые строки в таблицу
                for (int i = 0; i < -diff; i++)
                    downloadTable.Rows.Add(new object[6]);
            else if (diff > 0)
                //Удаляем из таблицы лишние строки
                for (int i = 0; i < diff; i++)
                    downloadTable.Rows.RemoveAt(0);

            //Проходимся по списку манги
            for (int i = 0; i < mangaTable.Count; i++)
            {
                //Получаем массив значений
                buff = mangaTable[i].getRow();
                //Проходимся по ячейкам строки
                for (int j = 0; j < buff.Length; j++)
                    //Обновляем ячейку
                    downloadTable.Rows[i].Cells[j].Value = buff[j];
            }
         
            //Проставляем выделение строке
            setSelectedRow(selId);
            //Проставляем скролл
            setFirstDisplayedRow(scrollId);
        }


        /// <summary>
        /// Проставляем скролл
        /// </summary>
        /// <param name="id">id первой отображаемой строки</param>
        private void setFirstDisplayedRow(int id)
        {
            try
            {
                //Если старое выделение находится за пределами списка
                if (id >= downloadTable.Rows.Count)
                    //Проставляем выделенным крайний элемент
                    id = downloadTable.Rows.Count - 1;
                //Если старое выделение находится за пределами ноля
                else if (id < 0)
                    //Возвращаем 0
                    id = 0;

                //Указываем первую видимую строку
                downloadTable.FirstDisplayedScrollingRowIndex = id;
            }
            catch { }
        }

        /// <summary>
        /// Проставляем выделение строке
        /// </summary>
        /// <param name="id">id выделенной строки</param>
        private void setSelectedRow(int id)
        {
            try
            {
                //Если старое выделение находится за пределами списка
                if (id >= downloadTable.Rows.Count)
                    //Проставляем выделенным крайний элемент
                    id = downloadTable.Rows.Count - 1;
                //Если старое выделение находится за пределами ноля
                else if (id < 0)
                    //Возвращаем 0
                    id = 0;

                //Ставим выделение на элемент
                downloadTable.Rows[id].Selected = true;
            }
            catch { }
        }

        /// <summary>
        /// Возвращает id выделенной строки
        /// </summary>
        /// <returns>Id выделенной строки</returns>
        private int getSelectedRowId()
        {
            int ex = 0;

            try
            {
                //Получаем список выделенных строк
                var rows = downloadTable.SelectedRows;
                //Если выделена хоть одна строка
                if (rows.Count > 0)
                    //Получаем её id
                    ex = rows[0].Index;
            }
            catch { ex = 0; }

            return ex;
        }

        /// <summary>
        /// Запускаем загрузку списка
        /// </summary>
        private void load()
        {
            //Если файл был открыт
            if (loadDialog.ShowDialog() == DialogResult.OK)
            {
                //Загружаем список манги
                byte result = mw.loadManga(loadDialog.FileName);
                //Если загрузка была успешна
                if (result == 0)
                    //Обновляем инфу на форме
                    mw.updateDownloadExec(-2);
                
                //Результат загрузки манги
                pl.showMessage(1, result);
            }
        }

        /// <summary>
        /// Запускаем сохранение списка
        /// </summary>
        private void save()
        {
            //Если файл был открыт
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                //Загружаем список манги
                byte result = mw.saveManga(saveDialog.FileName);
                //Результат сохранения манги
                pl.showMessage(2, result);
            }
        }

        /// <summary>
        /// Удаляем выделенный элемент из списка
        /// </summary>
        private void remove()
        {
            //Получаем список выбранных строк
            var select = downloadTable.SelectedRows;
            //Если выбрана хоть одна строка
            if(select.Count > 0)
            {
                //Получаем её ID
                int id = select[0].Index;
                //Удаляем мангу из списка
                mw.removeMangaReomList(id);
            }
            //В противном случае
            else
                //ОШибка - не было выбрано ни одной строки
                pl.showMessage(3);
        }

        /// <summary>
        /// Удаляем все элементы из списка
        /// </summary>
        private void clear()
        {
            //Запрос очистки списка загрузки манги
            if(pl.showMessage(4) == DialogResult.Yes)
                //Очищаем список манги
                mw.clearMangaList();
        }


        /// <summary>
        /// Запуск загрузки
        /// </summary>
        private void download()
        {
            //Делаем все кнопки неактивными
            setButtonsEnableStatus(false);
            //Скрываем форму настроек
            sf.Hide();
            //Зaпускаем загрузку
            mw.start();
        }


        /// <summary>
        /// Открытие окна настроек
        /// </summary>
        private void settings()
        {
            //Отображаем форму настроек приложения
            sf.Show();
        }

        /// <summary>
        /// Событие изменения размера формы
        /// </summary>
        private void Main_Resize(object sender, EventArgs e)
        {
            //Перерисовываем форму
            this.Invalidate();
        }

        /// <summary>
        /// Соыбтие перерисовки формы
        /// </summary>
        private void Main_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем обводку формы
            e.Graphics.DrawRectangle(Pens.Purple, new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }

        /// <summary>
        /// Клик по кнопке сворачивания формы
        /// </summary>
        private void CustomTopBar1_onMinimizeButtonClick()
        {
            //Сворачиваем форму
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Клик по кнопке разворачивания формы
        /// </summary>
        private void CustomTopBar1_onMaximizeButtonClick()
        {
            //Если форма в норме
            if(this.WindowState == FormWindowState.Normal)
                //Разворачиваем форму
                this.WindowState = FormWindowState.Maximized;
            //В противном случае
            else
                //Возвращаем форму в нормальный вид
                this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Клик по кнопке закрытия формы
        /// </summary>
        private void CustomTopBar1_onCloseButtonClick()
        {
            //Завершаем всю работу
            exit();
        }


        /// <summary>
        /// Клик по кнопке загрузки
        /// </summary>
        private void loadButton_Click(object sender, EventArgs e)
        {
            //Запускаем загрузку списка
            load();
        }

        /// <summary>
        /// Клик по кнопке сохранения
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Запускаем сохранение списка
            save();
        }

        /// <summary>
        /// Клик по кнопке удаления
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            //Удаляем выбранный элемент
            remove();
        }

        /// <summary>
        /// Клик по кнопке очистки
        /// </summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            //Удаляем все элементы из списка
            clear();
        }

        /// <summary>
        /// Клик по кнопке запуска загрузки
        /// </summary>
        private void downloadButton_Click(object sender, EventArgs e)
        {
            //Запускаем загрузку
            download();
        }

        /// <summary>
        /// Клик по кнопке настроек
        /// </summary>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            //Открываем окно настроек
            settings();
        }

        /// <summary>
        /// Завершаем всю работу
        /// </summary>
        private void exit()
        {
            bool ex = true;

            //В случае, если идёт загрузка манги
            if (mw.workStep != DownloadStep.Steps.Сбор_ссылок)
                //Запрашиваем подтверждение выхода
                ex = (pl.showMessage(5) == DialogResult.Yes);

            //Если мы всё-таки выходим
            if (ex)
            {
                //Останавливаем все рабочие потоки приложения
                mw.stop();
                //Если нужно проводить автосохранение при выходе из программы
                if (Program.settingsStorage.settings.exitAutosave)
                   //Выполняем автосохранение
                   mw.saveManga();
                //Закрываем форму
                this.Close();
            }
        }

        /// <summary>
        /// Клик по кнопке доната
        /// </summary>
        private void donateButton_Click(object sender, EventArgs e)
        {
            //Отображаем форму предзагрузчика
            df.Show();
        }

        /// <summary>
        /// Прокрутка таблицы вниз
        /// </summary>
        private void scrollToDown()
        {
            //Если включен параметр прокрутки к добавленной строке
            if(Program.settingsStorage.settings.scrollToAdd)
                //Указываем последнюю строку, как первую видимую строку
                downloadTable.FirstDisplayedScrollingRowIndex = downloadTable.RowCount - 1;
        }

        /// <summary>
        /// Прокрутка таблицы к активной строке
        /// </summary>
        /// <param name="id">
        ///     Id активной строки.
        ///         -1 - сброс выделения. 
        ///         -2 - последняя строка.
        /// </param>
        private void scrollToActive(int id)
        {
            //Если включен параметр прокрутки к активной строке
            if (Program.settingsStorage.settings.scrollToActive)
            {
                //Если нужно последний id указать
                if (id == -2)
                    id = downloadTable.RowCount - 1;

                //Если не нужно сбросить выделение
                if (id != -1)
                    //Указываем нашу строку, как первую видимую строку
                    downloadTable.FirstDisplayedScrollingRowIndex = id;

                //Выделяем строку
                setSelectedRow(id);
            }
        }
    }
}
