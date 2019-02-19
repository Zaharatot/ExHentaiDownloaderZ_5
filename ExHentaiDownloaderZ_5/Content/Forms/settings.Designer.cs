namespace ExHentaiDownloaderZ_5
{
    partial class settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customTopBar1 = new CustomTopBar.customTopBar();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.elementsPanel = new System.Windows.Forms.Panel();
            this.autosaveBackupFlag = new System.Windows.Forms.CheckBox();
            this.loadPagesAutosaveFlag = new System.Windows.Forms.CheckBox();
            this.checkStatusesAutosaveFlag = new System.Windows.Forms.CheckBox();
            this.addElementAutosaveFlag = new System.Windows.Forms.CheckBox();
            this.loadInfoAutosaveFlag = new System.Windows.Forms.CheckBox();
            this.exitAutosaveFlag = new System.Windows.Forms.CheckBox();
            this.saveSettingsGroupBox = new customGroupBox.customGroupBox();
            this.newFolderRequestFlag = new System.Windows.Forms.CheckBox();
            this.openDownloadFolderFlag = new System.Windows.Forms.CheckBox();
            this.createChildFolderFlag = new System.Windows.Forms.CheckBox();
            this.downloadMangaPageDelayLabel = new System.Windows.Forms.Label();
            this.downloadMangaDelayLabel = new System.Windows.Forms.Label();
            this.mangaInfoLoadDelayLabel = new System.Windows.Forms.Label();
            this.rootPageLoadDelayLabel = new System.Windows.Forms.Label();
            this.downloadMangaPageDelayVal = new System.Windows.Forms.NumericUpDown();
            this.downloadMangaDelayVal = new System.Windows.Forms.NumericUpDown();
            this.mangaInfoLoadDelayVal = new System.Windows.Forms.NumericUpDown();
            this.rootPageLoadDelayVal = new System.Windows.Forms.NumericUpDown();
            this.passHashTextBox = new System.Windows.Forms.TextBox();
            this.passHashLabel = new System.Windows.Forms.Label();
            this.memberIdTextBox = new System.Windows.Forms.TextBox();
            this.memberIdLabel = new System.Windows.Forms.Label();
            this.exhentaiSettingsGroupBox = new customGroupBox.customGroupBox();
            this.downloadPathTextBox = new System.Windows.Forms.TextBox();
            this.downloadPathLabel = new System.Windows.Forms.Label();
            this.downloadSettingsGroupBox = new customGroupBox.customGroupBox();
            this.buttonsPanel.SuspendLayout();
            this.elementsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadMangaPageDelayVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadMangaDelayVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mangaInfoLoadDelayVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootPageLoadDelayVal)).BeginInit();
            this.SuspendLayout();
            // 
            // customTopBar1
            // 
            this.customTopBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.customTopBar1.buttonsSelectColor = System.Drawing.Color.Purple;
            this.customTopBar1.closeVisible = true;
            this.customTopBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customTopBar1.headerColor = System.Drawing.Color.MediumSlateBlue;
            this.customTopBar1.headerText = "Settings";
            this.customTopBar1.icon = null;
            this.customTopBar1.iconVisible = false;
            this.customTopBar1.Location = new System.Drawing.Point(3, 3);
            this.customTopBar1.maximizeVisible = false;
            this.customTopBar1.MaximumSize = new System.Drawing.Size(9999, 100);
            this.customTopBar1.minimizeVisible = false;
            this.customTopBar1.MinimumSize = new System.Drawing.Size(300, 35);
            this.customTopBar1.Name = "customTopBar1";
            this.customTopBar1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.customTopBar1.Size = new System.Drawing.Size(794, 35);
            this.customTopBar1.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.cancelSettingsButton);
            this.buttonsPanel.Controls.Add(this.saveSettingsButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(3, 501);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(794, 55);
            this.buttonsPanel.TabIndex = 1;
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelSettingsButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelSettingsButton.Location = new System.Drawing.Point(16, 8);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(120, 32);
            this.cancelSettingsButton.TabIndex = 2;
            this.cancelSettingsButton.Text = "Сброс параметров";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.cancelSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSettingsButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.saveSettingsButton.Location = new System.Drawing.Point(658, 8);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(120, 32);
            this.saveSettingsButton.TabIndex = 1;
            this.saveSettingsButton.Text = "Сохранить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // elementsPanel
            // 
            this.elementsPanel.Controls.Add(this.autosaveBackupFlag);
            this.elementsPanel.Controls.Add(this.loadPagesAutosaveFlag);
            this.elementsPanel.Controls.Add(this.checkStatusesAutosaveFlag);
            this.elementsPanel.Controls.Add(this.addElementAutosaveFlag);
            this.elementsPanel.Controls.Add(this.loadInfoAutosaveFlag);
            this.elementsPanel.Controls.Add(this.exitAutosaveFlag);
            this.elementsPanel.Controls.Add(this.saveSettingsGroupBox);
            this.elementsPanel.Controls.Add(this.newFolderRequestFlag);
            this.elementsPanel.Controls.Add(this.openDownloadFolderFlag);
            this.elementsPanel.Controls.Add(this.createChildFolderFlag);
            this.elementsPanel.Controls.Add(this.downloadMangaPageDelayLabel);
            this.elementsPanel.Controls.Add(this.downloadMangaDelayLabel);
            this.elementsPanel.Controls.Add(this.mangaInfoLoadDelayLabel);
            this.elementsPanel.Controls.Add(this.rootPageLoadDelayLabel);
            this.elementsPanel.Controls.Add(this.downloadMangaPageDelayVal);
            this.elementsPanel.Controls.Add(this.downloadMangaDelayVal);
            this.elementsPanel.Controls.Add(this.mangaInfoLoadDelayVal);
            this.elementsPanel.Controls.Add(this.rootPageLoadDelayVal);
            this.elementsPanel.Controls.Add(this.passHashTextBox);
            this.elementsPanel.Controls.Add(this.passHashLabel);
            this.elementsPanel.Controls.Add(this.memberIdTextBox);
            this.elementsPanel.Controls.Add(this.memberIdLabel);
            this.elementsPanel.Controls.Add(this.exhentaiSettingsGroupBox);
            this.elementsPanel.Controls.Add(this.downloadPathTextBox);
            this.elementsPanel.Controls.Add(this.downloadPathLabel);
            this.elementsPanel.Controls.Add(this.downloadSettingsGroupBox);
            this.elementsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementsPanel.Location = new System.Drawing.Point(3, 38);
            this.elementsPanel.Name = "elementsPanel";
            this.elementsPanel.Padding = new System.Windows.Forms.Padding(10);
            this.elementsPanel.Size = new System.Drawing.Size(794, 463);
            this.elementsPanel.TabIndex = 2;
            // 
            // autosaveBackupFlag
            // 
            this.autosaveBackupFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.autosaveBackupFlag.Location = new System.Drawing.Point(387, 418);
            this.autosaveBackupFlag.Name = "autosaveBackupFlag";
            this.autosaveBackupFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.autosaveBackupFlag.Size = new System.Drawing.Size(377, 17);
            this.autosaveBackupFlag.TabIndex = 35;
            this.autosaveBackupFlag.Text = "Создание бекапов файла автосохранения";
            this.autosaveBackupFlag.UseVisualStyleBackColor = true;
            // 
            // loadPagesAutosaveFlag
            // 
            this.loadPagesAutosaveFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.loadPagesAutosaveFlag.Location = new System.Drawing.Point(387, 395);
            this.loadPagesAutosaveFlag.Name = "loadPagesAutosaveFlag";
            this.loadPagesAutosaveFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.loadPagesAutosaveFlag.Size = new System.Drawing.Size(377, 17);
            this.loadPagesAutosaveFlag.TabIndex = 34;
            this.loadPagesAutosaveFlag.Text = "Автосохранение перед загрузкой страниц";
            this.loadPagesAutosaveFlag.UseVisualStyleBackColor = true;
            // 
            // checkStatusesAutosaveFlag
            // 
            this.checkStatusesAutosaveFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.checkStatusesAutosaveFlag.Location = new System.Drawing.Point(38, 418);
            this.checkStatusesAutosaveFlag.Name = "checkStatusesAutosaveFlag";
            this.checkStatusesAutosaveFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkStatusesAutosaveFlag.Size = new System.Drawing.Size(343, 17);
            this.checkStatusesAutosaveFlag.TabIndex = 33;
            this.checkStatusesAutosaveFlag.Text = "Автосохранение перед проверкой статусов";
            this.checkStatusesAutosaveFlag.UseVisualStyleBackColor = true;
            // 
            // addElementAutosaveFlag
            // 
            this.addElementAutosaveFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.addElementAutosaveFlag.Location = new System.Drawing.Point(38, 395);
            this.addElementAutosaveFlag.Name = "addElementAutosaveFlag";
            this.addElementAutosaveFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addElementAutosaveFlag.Size = new System.Drawing.Size(343, 17);
            this.addElementAutosaveFlag.TabIndex = 32;
            this.addElementAutosaveFlag.Text = "Автосохранение при изменении списка загрузок";
            this.addElementAutosaveFlag.UseVisualStyleBackColor = true;
            // 
            // loadInfoAutosaveFlag
            // 
            this.loadInfoAutosaveFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.loadInfoAutosaveFlag.Location = new System.Drawing.Point(387, 372);
            this.loadInfoAutosaveFlag.Name = "loadInfoAutosaveFlag";
            this.loadInfoAutosaveFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.loadInfoAutosaveFlag.Size = new System.Drawing.Size(377, 17);
            this.loadInfoAutosaveFlag.TabIndex = 31;
            this.loadInfoAutosaveFlag.Text = "Автосохранение перед загрузкой информации о манге";
            this.loadInfoAutosaveFlag.UseVisualStyleBackColor = true;
            // 
            // exitAutosaveFlag
            // 
            this.exitAutosaveFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.exitAutosaveFlag.Location = new System.Drawing.Point(38, 372);
            this.exitAutosaveFlag.Name = "exitAutosaveFlag";
            this.exitAutosaveFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exitAutosaveFlag.Size = new System.Drawing.Size(343, 17);
            this.exitAutosaveFlag.TabIndex = 30;
            this.exitAutosaveFlag.Text = "Автосохранение при выходе из программы";
            this.exitAutosaveFlag.UseVisualStyleBackColor = true;
            // 
            // saveSettingsGroupBox
            // 
            this.saveSettingsGroupBox.borderColor = System.Drawing.Color.MediumSlateBlue;
            this.saveSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveSettingsGroupBox.headerColor = System.Drawing.Color.MediumSlateBlue;
            this.saveSettingsGroupBox.headerText = "SaveSettings";
            this.saveSettingsGroupBox.Location = new System.Drawing.Point(10, 345);
            this.saveSettingsGroupBox.MaximumSize = new System.Drawing.Size(5000, 5000);
            this.saveSettingsGroupBox.MinimumSize = new System.Drawing.Size(200, 100);
            this.saveSettingsGroupBox.Name = "saveSettingsGroupBox";
            this.saveSettingsGroupBox.Padding = new System.Windows.Forms.Padding(7);
            this.saveSettingsGroupBox.Size = new System.Drawing.Size(774, 111);
            this.saveSettingsGroupBox.TabIndex = 29;
            // 
            // newFolderRequestFlag
            // 
            this.newFolderRequestFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.newFolderRequestFlag.Location = new System.Drawing.Point(35, 209);
            this.newFolderRequestFlag.Name = "newFolderRequestFlag";
            this.newFolderRequestFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.newFolderRequestFlag.Size = new System.Drawing.Size(729, 17);
            this.newFolderRequestFlag.TabIndex = 28;
            this.newFolderRequestFlag.Text = "Запрос нового пути загрузки при запуске (если убрать флаг всегда будет новый путь" +
    " загрузки)";
            this.newFolderRequestFlag.UseVisualStyleBackColor = true;
            // 
            // openDownloadFolderFlag
            // 
            this.openDownloadFolderFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.openDownloadFolderFlag.Location = new System.Drawing.Point(35, 186);
            this.openDownloadFolderFlag.Name = "openDownloadFolderFlag";
            this.openDownloadFolderFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openDownloadFolderFlag.Size = new System.Drawing.Size(343, 17);
            this.openDownloadFolderFlag.TabIndex = 27;
            this.openDownloadFolderFlag.Text = "Открытие папки загрузки после завершения";
            this.openDownloadFolderFlag.UseVisualStyleBackColor = true;
            // 
            // createChildFolderFlag
            // 
            this.createChildFolderFlag.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.createChildFolderFlag.Location = new System.Drawing.Point(386, 186);
            this.createChildFolderFlag.Name = "createChildFolderFlag";
            this.createChildFolderFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.createChildFolderFlag.Size = new System.Drawing.Size(378, 17);
            this.createChildFolderFlag.TabIndex = 26;
            this.createChildFolderFlag.Text = "Загрузка в номерные дочерние папки";
            this.createChildFolderFlag.UseVisualStyleBackColor = true;
            // 
            // downloadMangaPageDelayLabel
            // 
            this.downloadMangaPageDelayLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadMangaPageDelayLabel.Location = new System.Drawing.Point(32, 148);
            this.downloadMangaPageDelayLabel.Name = "downloadMangaPageDelayLabel";
            this.downloadMangaPageDelayLabel.Size = new System.Drawing.Size(348, 23);
            this.downloadMangaPageDelayLabel.TabIndex = 22;
            this.downloadMangaPageDelayLabel.Text = "Задержка между загрузкой страниц манги:";
            this.downloadMangaPageDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // downloadMangaDelayLabel
            // 
            this.downloadMangaDelayLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadMangaDelayLabel.Location = new System.Drawing.Point(32, 122);
            this.downloadMangaDelayLabel.Name = "downloadMangaDelayLabel";
            this.downloadMangaDelayLabel.Size = new System.Drawing.Size(348, 23);
            this.downloadMangaDelayLabel.TabIndex = 21;
            this.downloadMangaDelayLabel.Text = "Задержка между загрузкой страниц разных манг:";
            this.downloadMangaDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mangaInfoLoadDelayLabel
            // 
            this.mangaInfoLoadDelayLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.mangaInfoLoadDelayLabel.Location = new System.Drawing.Point(32, 96);
            this.mangaInfoLoadDelayLabel.Name = "mangaInfoLoadDelayLabel";
            this.mangaInfoLoadDelayLabel.Size = new System.Drawing.Size(348, 23);
            this.mangaInfoLoadDelayLabel.TabIndex = 20;
            this.mangaInfoLoadDelayLabel.Text = "Задержка между загрузкой информации о разных мангах:";
            this.mangaInfoLoadDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rootPageLoadDelayLabel
            // 
            this.rootPageLoadDelayLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.rootPageLoadDelayLabel.Location = new System.Drawing.Point(32, 70);
            this.rootPageLoadDelayLabel.Name = "rootPageLoadDelayLabel";
            this.rootPageLoadDelayLabel.Size = new System.Drawing.Size(348, 23);
            this.rootPageLoadDelayLabel.TabIndex = 19;
            this.rootPageLoadDelayLabel.Text = "Задержка между подгрузками списков страниц:";
            this.rootPageLoadDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // downloadMangaPageDelayVal
            // 
            this.downloadMangaPageDelayVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.downloadMangaPageDelayVal.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadMangaPageDelayVal.Location = new System.Drawing.Point(386, 151);
            this.downloadMangaPageDelayVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.downloadMangaPageDelayVal.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.downloadMangaPageDelayVal.Name = "downloadMangaPageDelayVal";
            this.downloadMangaPageDelayVal.Size = new System.Drawing.Size(378, 20);
            this.downloadMangaPageDelayVal.TabIndex = 18;
            this.downloadMangaPageDelayVal.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // downloadMangaDelayVal
            // 
            this.downloadMangaDelayVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.downloadMangaDelayVal.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadMangaDelayVal.Location = new System.Drawing.Point(386, 125);
            this.downloadMangaDelayVal.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.downloadMangaDelayVal.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.downloadMangaDelayVal.Name = "downloadMangaDelayVal";
            this.downloadMangaDelayVal.Size = new System.Drawing.Size(378, 20);
            this.downloadMangaDelayVal.TabIndex = 17;
            this.downloadMangaDelayVal.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // mangaInfoLoadDelayVal
            // 
            this.mangaInfoLoadDelayVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mangaInfoLoadDelayVal.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.mangaInfoLoadDelayVal.Location = new System.Drawing.Point(386, 99);
            this.mangaInfoLoadDelayVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mangaInfoLoadDelayVal.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.mangaInfoLoadDelayVal.Name = "mangaInfoLoadDelayVal";
            this.mangaInfoLoadDelayVal.Size = new System.Drawing.Size(378, 20);
            this.mangaInfoLoadDelayVal.TabIndex = 16;
            this.mangaInfoLoadDelayVal.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // rootPageLoadDelayVal
            // 
            this.rootPageLoadDelayVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rootPageLoadDelayVal.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.rootPageLoadDelayVal.Location = new System.Drawing.Point(386, 73);
            this.rootPageLoadDelayVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rootPageLoadDelayVal.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rootPageLoadDelayVal.Name = "rootPageLoadDelayVal";
            this.rootPageLoadDelayVal.Size = new System.Drawing.Size(378, 20);
            this.rootPageLoadDelayVal.TabIndex = 15;
            this.rootPageLoadDelayVal.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // passHashTextBox
            // 
            this.passHashTextBox.Location = new System.Drawing.Point(386, 302);
            this.passHashTextBox.Name = "passHashTextBox";
            this.passHashTextBox.Size = new System.Drawing.Size(378, 20);
            this.passHashTextBox.TabIndex = 14;
            // 
            // passHashLabel
            // 
            this.passHashLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.passHashLabel.Location = new System.Drawing.Point(35, 300);
            this.passHashLabel.Name = "passHashLabel";
            this.passHashLabel.Size = new System.Drawing.Size(345, 23);
            this.passHashLabel.TabIndex = 13;
            this.passHashLabel.Text = "Значение \"ipb_pass_hash\" из куков:";
            this.passHashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memberIdTextBox
            // 
            this.memberIdTextBox.Location = new System.Drawing.Point(386, 276);
            this.memberIdTextBox.Name = "memberIdTextBox";
            this.memberIdTextBox.Size = new System.Drawing.Size(378, 20);
            this.memberIdTextBox.TabIndex = 12;
            // 
            // memberIdLabel
            // 
            this.memberIdLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.memberIdLabel.Location = new System.Drawing.Point(35, 274);
            this.memberIdLabel.Name = "memberIdLabel";
            this.memberIdLabel.Size = new System.Drawing.Size(345, 23);
            this.memberIdLabel.TabIndex = 11;
            this.memberIdLabel.Text = "Значение \"ipb_member_id\" из куков:";
            this.memberIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exhentaiSettingsGroupBox
            // 
            this.exhentaiSettingsGroupBox.borderColor = System.Drawing.Color.MediumSlateBlue;
            this.exhentaiSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.exhentaiSettingsGroupBox.headerColor = System.Drawing.Color.MediumSlateBlue;
            this.exhentaiSettingsGroupBox.headerText = "exHentaiSettings";
            this.exhentaiSettingsGroupBox.Location = new System.Drawing.Point(10, 245);
            this.exhentaiSettingsGroupBox.MaximumSize = new System.Drawing.Size(5000, 5000);
            this.exhentaiSettingsGroupBox.MinimumSize = new System.Drawing.Size(200, 100);
            this.exhentaiSettingsGroupBox.Name = "exhentaiSettingsGroupBox";
            this.exhentaiSettingsGroupBox.Padding = new System.Windows.Forms.Padding(7);
            this.exhentaiSettingsGroupBox.Size = new System.Drawing.Size(774, 100);
            this.exhentaiSettingsGroupBox.TabIndex = 10;
            // 
            // downloadPathTextBox
            // 
            this.downloadPathTextBox.Location = new System.Drawing.Point(386, 38);
            this.downloadPathTextBox.Name = "downloadPathTextBox";
            this.downloadPathTextBox.Size = new System.Drawing.Size(378, 20);
            this.downloadPathTextBox.TabIndex = 9;
            // 
            // downloadPathLabel
            // 
            this.downloadPathLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadPathLabel.Location = new System.Drawing.Point(32, 36);
            this.downloadPathLabel.Name = "downloadPathLabel";
            this.downloadPathLabel.Size = new System.Drawing.Size(348, 23);
            this.downloadPathLabel.TabIndex = 8;
            this.downloadPathLabel.Text = "Путь загрузки:";
            this.downloadPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // downloadSettingsGroupBox
            // 
            this.downloadSettingsGroupBox.borderColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.downloadSettingsGroupBox.headerColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadSettingsGroupBox.headerText = "Download Settings";
            this.downloadSettingsGroupBox.Location = new System.Drawing.Point(10, 10);
            this.downloadSettingsGroupBox.MaximumSize = new System.Drawing.Size(5000, 5000);
            this.downloadSettingsGroupBox.MinimumSize = new System.Drawing.Size(200, 100);
            this.downloadSettingsGroupBox.Name = "downloadSettingsGroupBox";
            this.downloadSettingsGroupBox.Padding = new System.Windows.Forms.Padding(7);
            this.downloadSettingsGroupBox.Size = new System.Drawing.Size(774, 235);
            this.downloadSettingsGroupBox.TabIndex = 7;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.elementsPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.customTopBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "settings";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "settings";
            this.buttonsPanel.ResumeLayout(false);
            this.elementsPanel.ResumeLayout(false);
            this.elementsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadMangaPageDelayVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadMangaDelayVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mangaInfoLoadDelayVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootPageLoadDelayVal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTopBar.customTopBar customTopBar1;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.Panel elementsPanel;
        private customGroupBox.customGroupBox exhentaiSettingsGroupBox;
        private System.Windows.Forms.TextBox downloadPathTextBox;
        private System.Windows.Forms.Label downloadPathLabel;
        private customGroupBox.customGroupBox downloadSettingsGroupBox;
        private System.Windows.Forms.TextBox passHashTextBox;
        private System.Windows.Forms.Label passHashLabel;
        private System.Windows.Forms.TextBox memberIdTextBox;
        private System.Windows.Forms.Label memberIdLabel;
        private System.Windows.Forms.Label downloadMangaPageDelayLabel;
        private System.Windows.Forms.Label downloadMangaDelayLabel;
        private System.Windows.Forms.Label mangaInfoLoadDelayLabel;
        private System.Windows.Forms.Label rootPageLoadDelayLabel;
        private System.Windows.Forms.NumericUpDown downloadMangaPageDelayVal;
        private System.Windows.Forms.NumericUpDown downloadMangaDelayVal;
        private System.Windows.Forms.NumericUpDown mangaInfoLoadDelayVal;
        private System.Windows.Forms.NumericUpDown rootPageLoadDelayVal;
        private System.Windows.Forms.CheckBox newFolderRequestFlag;
        private System.Windows.Forms.CheckBox openDownloadFolderFlag;
        private System.Windows.Forms.CheckBox createChildFolderFlag;
        private customGroupBox.customGroupBox saveSettingsGroupBox;
        private System.Windows.Forms.CheckBox exitAutosaveFlag;
        private System.Windows.Forms.CheckBox autosaveBackupFlag;
        private System.Windows.Forms.CheckBox loadPagesAutosaveFlag;
        private System.Windows.Forms.CheckBox checkStatusesAutosaveFlag;
        private System.Windows.Forms.CheckBox addElementAutosaveFlag;
        private System.Windows.Forms.CheckBox loadInfoAutosaveFlag;
    }
}