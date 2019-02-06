using System;
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
    public partial class main : Form
    {
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
            Content.Clases.WorkClases.ClipboardScanner cs = new Content.Clases.WorkClases.ClipboardScanner();

            cs.findUrl += Cs_findUrl;
            cs.start();


            downloadTable.Rows.Add(new object[] {
                "https://exhentai.org/g/1354108/b3daf602b9/",
                "[Odenden] Korekara Onii-chan ni 〇〇〇 Shichaimasu [Chinese] [墨染个人汉化]",
                "0/25",
                "Busy"
            });
            downloadTable.Rows.Add(new object[] {
                "https://exhentai.org/g/1323041/e1e1601f40/",
                "[Anthology] 2D Comic Magazine Otokonoko o Shiriana Kairaku de Mesu Ochi Ryoujoku! Vol. 1 [Korean] [Digital]",
                "0/93",
                "Busy"
            });
            downloadTable.Rows.Add(new object[] {
                "https://exhentai.org/g/1331624/15a549933d/",
                "[Binbi] Tabegoro Otokonoko [Digital]",
                "0/207",
                "Busy"
            });


            //Инициализируем события
            initEvents();
        }

        private void Cs_findUrl(string url)
        {
            this.BeginInvoke(new Action(() => { 
                //listBox1.Items.Add(url);
            }));
        }

        /// <summary>
        /// Инициализируем события
        /// </summary>
        private void initEvents()
        {
            //Клики по кнопкам управления окном
            customTopBar1.onCloseButtonClick += CustomTopBar1_onCloseButtonClick;
            customTopBar1.onMaximizeButtonClick += CustomTopBar1_onMaximizeButtonClick;
            customTopBar1.onMinimizeButtonClick += CustomTopBar1_onMinimizeButtonClick;
            //Событие перерисовки формы
            this.Paint += Main_Paint;
            //Событие изменения размера формы
            this.Resize += Main_Resize;
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
            //Закрываем форму
            this.Close();
        }

    }
}
