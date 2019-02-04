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
        /// Завершаем всю работу
        /// </summary>
        private void exit()
        {
            //Закрываем форму
            this.Close();
        }
    }
}
