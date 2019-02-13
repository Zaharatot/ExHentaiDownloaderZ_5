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


namespace ExHentaiDownloaderZ_5
{
    public partial class main : Form
    {
        /// <summary>
        /// Главный рабочий класс программы
        /// </summary>
        private mainWorker mw;
        /// <summary>
        /// Путь загрузки
        /// </summary>
        private string downloadPath;

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
            //Инициализируем основной рабочий класс
            mw = new mainWorker();
            //Инициализируем события
            initEvents();
        }

        /// <summary>
        /// Инициализируем события
        /// </summary>
        private void initEvents()
        {
            //Событие обновления процесса загрузки
            mw.onUpdateDownload += Mw_onUpdateDownload;

            //Клики по кнопкам управления окном
            customTopBar1.onCloseButtonClick += CustomTopBar1_onCloseButtonClick;
            customTopBar1.onMaximizeButtonClick += CustomTopBar1_onMaximizeButtonClick;
            customTopBar1.onMinimizeButtonClick += CustomTopBar1_onMinimizeButtonClick;
            //Событие перерисовки формы
            this.Paint += Main_Paint;
            //Событие изменения размера формы
            this.Resize += Main_Resize;
            //Событие завершения загрузки формы
            this.Load += Main_Load;
        }

        /// <summary>
        /// Обработчик события первой загрузки формы
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            //Запрашиваем обновление данных на форме 
            mw.updateDownloadExec();
        }

        /// <summary>
        /// Событие обновления процесса загрузки
        /// </summary>
        /// <param name="downloadInfo">Информация о процессе загрузки</param>
        /// <param name="mangaTable">Список манги, для таблицы</param>
        private void Mw_onUpdateDownload(DownloadProgressInfo downloadInfo, List<TableMangaInfo> mangaTable)
        {
            //Выполняем действия в основном потоке
            this.BeginInvoke(new Action(()=> {
                //Обновляем таблицу манги
                updateTable(mangaTable);
                //Обновляем значения контроллов
                updateElems(downloadInfo);
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
            //Очищаем список строк
            downloadTable.Rows.Clear();

            //Проходимся по списку
            foreach (var row in mangaTable)
                //Добавляем строку
                downloadTable.Rows.Add(row.getRow());

            /*
             Этот метод самый примитивный, и имеет много минусов.
             Но, на первое время сойдёт.
             */
        }

        /// <summary>
        /// Запускаем загрузку списка
        /// </summary>
        private void load()
        {
            //Если файл был открыт
            if(loadDialog.ShowDialog() == DialogResult.OK)
            {
                string s = loadDialog.FileName;
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
                string s = saveDialog.FileName;
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
            }
        }

        /// <summary>
        /// Запуск загрузки
        /// </summary>
        private void download()
        {
            //Делаем все кнопки неактивными
            setButtonsEnableStatus(false);
            //Зaпускаем загрузку
            mw.start(downloadPath);
        }


        /// <summary>
        /// Открытие окна настроек
        /// </summary>
        private void settings()
        {

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
            //Останавливаем все рабочие потоки приложения
            mw.stop();
            //Закрываем форму
            this.Close();
        }

    }
}
