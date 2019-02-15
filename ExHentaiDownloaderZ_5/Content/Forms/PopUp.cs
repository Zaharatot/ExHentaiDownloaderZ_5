using ExHentaiDownloaderZ_5.Content.Clases.DataClases;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExHentaiDownloaderZ_5
{
    /// <summary>
    /// Класс форма всплывающего сообщения
    /// </summary>
    public partial class PopUp : Form
    {
        /// <summary>
        /// Список названий кнопок
        /// </summary>
        MessageBoxButtons buttons;


        //Эти 2 класса дают возможность перемещать форму за любое место
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        static extern bool ReleaseCapture();
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public PopUp()
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
          
            //Инициализируем события
            initEvents();
        }

        /// <summary>
        /// Инициализируем события
        /// </summary>
        private void initEvents()
        {
            //Клики по кнопкам управления окном
            customTopBar1.onCloseButtonClick += CustomTopBar1_onCloseButtonClick; ;
            //Событие перерисовки формы
            this.Paint += PopUp_Paint;

            //События, для перемещения формы за любое место
            messageLabel.MouseMove += MoveForm_MouseMove;
            buttonsPanel.MouseMove += MoveForm_MouseMove;

            //Обработчики основных кнопок
            firstButton.Click += ActionButton_Click;
            secondButton.Click += ActionButton_Click;
            thridButton.Click += ActionButton_Click;
        }


        /// <summary>
        /// Обработчик клика по кнопке действия
        /// </summary>
        private void ActionButton_Click(object sender, EventArgs e)
        {
            //Возращаем результат нажатия кнопки
            this.DialogResult = getActionButtonResult(getButtonName(sender));
        }


        /// <summary>
        /// Обработчик события перемещения мыши
        /// </summary>
        private void MoveForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Еслии нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                //Перемещаем форму
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// Событие перерисовки формы
        /// </summary>
        private void PopUp_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем обводку формы
            e.Graphics.DrawRectangle(Pens.Purple, new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }

        /// <summary>
        /// Событие клика по кнопке закрытия форму
        /// </summary>
        private void CustomTopBar1_onCloseButtonClick()
        {
            //Результат диалога у нас - "Cancel"
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Изменяем высоту сообщения
        /// </summary>
        private void initHeight()
        {
            //Получаем высоту текста
            Size sz = TextRenderer.MeasureText(messageLabel.Text, messageLabel.Font, new Size(messageLabel.Width, 5000), TextFormatFlags.WordBreak);
            //Рассчитываем высоту контролла по высоте всех панелей
            //+ отступ 3px от края формы со всех сторон
            //+ отступ 20px для текст от верхней и нижней панели
            this.Height = sz.Height + 50 + customTopBar1.Height + buttonsPanel.Height;
        }

        /// <summary>
        /// Отображаем кнопку
        /// </summary>
        /// <param name="elem">Кнопка, для отображения</param>
        /// <param name="text">Текст кнопки</param>
        private void showButton(Button elem, string text)
        {
            elem.Text = text;
            elem.Visible = true;
        }

        /// <summary>
        /// Инициализируем кнопки
        /// </summary>
        private void initButtons()
        {
            // Скрываем кнопки
            clearButtons();
            //Выбираем кнопки
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        showButton(firstButton, ButtonsText.Abort);
                        showButton(secondButton, ButtonsText.Retry);
                        showButton(thridButton, ButtonsText.Ignore);
                        break;
                    }
                case MessageBoxButtons.OK:
                    {
                        showButton(thridButton, ButtonsText.Ok);
                        break;
                    }
                case MessageBoxButtons.OKCancel:
                    {
                        showButton(secondButton, ButtonsText.Ok);
                        showButton(thridButton, ButtonsText.Cancel);
                        break;
                    }
                case MessageBoxButtons.RetryCancel:
                    {
                        showButton(secondButton, ButtonsText.Retry);
                        showButton(thridButton, ButtonsText.Cancel);
                        break;
                    }
                case MessageBoxButtons.YesNo:
                    {
                        showButton(secondButton, ButtonsText.Yes);
                        showButton(thridButton, ButtonsText.No);
                        break;
                    }
                case MessageBoxButtons.YesNoCancel:
                    {
                        showButton(firstButton, ButtonsText.Yes);
                        showButton(secondButton, ButtonsText.No);
                        showButton(thridButton, ButtonsText.Cancel);
                        break;
                    }
            }
        }

        /// <summary>
        /// Возвращаем результат нажатия кнопки
        /// </summary>
        /// <param name="name">Имя кнопки</param>
        /// <returns>Результат нажатия</returns>
        private DialogResult getActionButtonResult(string name)
        {
            DialogResult ex = DialogResult.None;

            //Выбираем кнопки
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        //Выбираем действие по кнопке
                        if (name.Equals("thridButton"))
                            ex = DialogResult.Ignore;
                        else if (name.Equals("secondButton"))
                            ex = DialogResult.Retry;
                        else
                            ex = DialogResult.Abort;

                        break;
                    }
                case MessageBoxButtons.OK:
                    {
                        //тут тупо одна кнопка
                        ex = DialogResult.OK;
                        break;
                    }
                case MessageBoxButtons.OKCancel:
                    {
                        //Выбираем действие по кнопке
                        if (name.Equals("secondButton"))
                            ex = DialogResult.OK;
                        else
                            ex = DialogResult.Cancel;

                        break;
                    }
                case MessageBoxButtons.RetryCancel:
                    {
                        //Выбираем действие по кнопке
                        if (name.Equals("thridButton"))
                            ex = DialogResult.Cancel;
                        else
                            ex = DialogResult.Retry;
                        break;
                    }
                case MessageBoxButtons.YesNo:
                    {
                        //Выбираем действие по кнопке
                        if (name.Equals("secondButton"))
                            ex = DialogResult.Yes;
                        else
                            ex = DialogResult.No;
                        break;
                    }
                case MessageBoxButtons.YesNoCancel:
                    {
                        //Выбираем действие по кнопке
                        if (name.Equals("thridButton"))
                            ex = DialogResult.Cancel;
                        else if (name.Equals("secondButton"))
                            ex = DialogResult.No;
                        else
                            ex = DialogResult.Yes;
                        break;
                    }
            }

            return ex;
        }

        /// <summary>
        /// Возвращаем название кнопки по объекту
        /// </summary>
        /// <param name="button">Объект кнопки</param>
        /// <returns>Имя элемента</returns>
        private string getButtonName(object button) =>
            ((Button)button).Name;


        /// <summary>
        /// Скрываем кнопки
        /// </summary>
        private void clearButtons()
        {
            //Проходимся по всем элементам нижней панели, скрывая их
            foreach (Control elem in buttonsPanel.Controls)
                elem.Visible = false;
        }



        /// <summary>
        /// ИНициализация формы попапов
        /// </summary>
        /// <param name="info">Информация о содержимом сообщения</param>
        public void initForm(PopupMessageInfo info)
        {
            //Ставим заголовок сообщения
            customTopBar1.headerText = info.header;
            //Выводим текст в текстовое поле
            messageLabel.Text = info.message;
            //Устанавливаем информацию о кнопках
            buttons = info.buttons;
            //Обновляем высоту контролла
            initHeight();
            //Инициализируем кнопки
            initButtons();
        }
    }
}
