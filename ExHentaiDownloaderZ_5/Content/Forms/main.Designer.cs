﻿namespace ExHentaiDownloaderZ_5
{
    partial class main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.controlPanel = new System.Windows.Forms.Panel();
            this.donateButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.secondaryProgress = new CustomProgressBar.customProgressBar();
            this.secondaryProgressLabel = new System.Windows.Forms.Label();
            this.mainProgress = new CustomProgressBar.customProgressBar();
            this.mainProgressLabel = new System.Windows.Forms.Label();
            this.stepInfoPanel = new System.Windows.Forms.Panel();
            this.loadTimeLabel = new System.Windows.Forms.Label();
            this.stepInfoLabel = new System.Windows.Forms.Label();
            this.loadDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.customTopBar1 = new CustomTopBar.customTopBar();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.downloadTable = new System.Windows.Forms.DataGridView();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlPanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.stepInfoPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTable)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.donateButton);
            this.controlPanel.Controls.Add(this.clearButton);
            this.controlPanel.Controls.Add(this.settingsButton);
            this.controlPanel.Controls.Add(this.downloadButton);
            this.controlPanel.Controls.Add(this.loadButton);
            this.controlPanel.Controls.Add(this.saveButton);
            this.controlPanel.Controls.Add(this.removeButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(3, 38);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(844, 62);
            this.controlPanel.TabIndex = 3;
            // 
            // donateButton
            // 
            this.donateButton.BackgroundImage = global::ExHentaiDownloaderZ_5.Properties.Resources.donate;
            this.donateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.donateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.donateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.donateButton.Location = new System.Drawing.Point(787, 14);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(32, 32);
            this.donateButton.TabIndex = 6;
            this.donateButton.UseVisualStyleBackColor = true;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.clearButton.Location = new System.Drawing.Point(151, 14);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(120, 32);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Очистить список";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.settingsButton.Location = new System.Drawing.Point(655, 14);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(120, 32);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadButton.Location = new System.Drawing.Point(529, 14);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(120, 32);
            this.downloadButton.TabIndex = 3;
            this.downloadButton.Text = "Запуск загрузки";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.loadButton.Location = new System.Drawing.Point(403, 14);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(120, 32);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Загрузить список";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.saveButton.Location = new System.Drawing.Point(277, 14);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 32);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить список";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.removeButton.Location = new System.Drawing.Point(25, 14);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(120, 32);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Удалить из списка";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.secondaryProgress);
            this.progressPanel.Controls.Add(this.secondaryProgressLabel);
            this.progressPanel.Controls.Add(this.mainProgress);
            this.progressPanel.Controls.Add(this.mainProgressLabel);
            this.progressPanel.Controls.Add(this.stepInfoPanel);
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressPanel.Location = new System.Drawing.Point(3, 627);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Padding = new System.Windows.Forms.Padding(3);
            this.progressPanel.Size = new System.Drawing.Size(844, 120);
            this.progressPanel.TabIndex = 5;
            // 
            // secondaryProgress
            // 
            this.secondaryProgress.backgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.secondaryProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondaryProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryProgress.foregroundColor = System.Drawing.Color.Purple;
            this.secondaryProgress.Location = new System.Drawing.Point(3, 90);
            this.secondaryProgress.max = 100;
            this.secondaryProgress.min = 0;
            this.secondaryProgress.MinimumSize = new System.Drawing.Size(100, 25);
            this.secondaryProgress.Name = "secondaryProgress";
            this.secondaryProgress.Size = new System.Drawing.Size(838, 27);
            this.secondaryProgress.TabIndex = 17;
            this.secondaryProgress.value = 100;
            // 
            // secondaryProgressLabel
            // 
            this.secondaryProgressLabel.AutoEllipsis = true;
            this.secondaryProgressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.secondaryProgressLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.secondaryProgressLabel.Location = new System.Drawing.Point(3, 70);
            this.secondaryProgressLabel.Name = "secondaryProgressLabel";
            this.secondaryProgressLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.secondaryProgressLabel.Size = new System.Drawing.Size(838, 20);
            this.secondaryProgressLabel.TabIndex = 16;
            this.secondaryProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainProgress
            // 
            this.mainProgress.backgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mainProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainProgress.foregroundColor = System.Drawing.Color.Purple;
            this.mainProgress.Location = new System.Drawing.Point(3, 43);
            this.mainProgress.max = 100;
            this.mainProgress.min = 0;
            this.mainProgress.MinimumSize = new System.Drawing.Size(100, 25);
            this.mainProgress.Name = "mainProgress";
            this.mainProgress.Size = new System.Drawing.Size(838, 27);
            this.mainProgress.TabIndex = 15;
            this.mainProgress.value = 100;
            // 
            // mainProgressLabel
            // 
            this.mainProgressLabel.AutoEllipsis = true;
            this.mainProgressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainProgressLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.mainProgressLabel.Location = new System.Drawing.Point(3, 23);
            this.mainProgressLabel.Name = "mainProgressLabel";
            this.mainProgressLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.mainProgressLabel.Size = new System.Drawing.Size(838, 20);
            this.mainProgressLabel.TabIndex = 7;
            this.mainProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stepInfoPanel
            // 
            this.stepInfoPanel.Controls.Add(this.loadTimeLabel);
            this.stepInfoPanel.Controls.Add(this.stepInfoLabel);
            this.stepInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.stepInfoPanel.Location = new System.Drawing.Point(3, 3);
            this.stepInfoPanel.Name = "stepInfoPanel";
            this.stepInfoPanel.Size = new System.Drawing.Size(838, 20);
            this.stepInfoPanel.TabIndex = 1;
            // 
            // loadTimeLabel
            // 
            this.loadTimeLabel.AutoEllipsis = true;
            this.loadTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadTimeLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.loadTimeLabel.Location = new System.Drawing.Point(375, 0);
            this.loadTimeLabel.Name = "loadTimeLabel";
            this.loadTimeLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.loadTimeLabel.Size = new System.Drawing.Size(463, 20);
            this.loadTimeLabel.TabIndex = 8;
            this.loadTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stepInfoLabel
            // 
            this.stepInfoLabel.AutoEllipsis = true;
            this.stepInfoLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.stepInfoLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.stepInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.stepInfoLabel.Name = "stepInfoLabel";
            this.stepInfoLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.stepInfoLabel.Size = new System.Drawing.Size(375, 20);
            this.stepInfoLabel.TabIndex = 7;
            this.stepInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadDialog
            // 
            this.loadDialog.Filter = "Файл сохранения|*.EHDZS";
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Файл сохранения|*.EHDZS";
            // 
            // customTopBar1
            // 
            this.customTopBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.customTopBar1.buttonsSelectColor = System.Drawing.Color.Purple;
            this.customTopBar1.closeVisible = true;
            this.customTopBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customTopBar1.headerColor = System.Drawing.Color.MediumSlateBlue;
            this.customTopBar1.headerText = "ExHentaiDownloaderZ_5";
            this.customTopBar1.icon = global::ExHentaiDownloaderZ_5.Properties.Resources.icon_256;
            this.customTopBar1.iconVisible = true;
            this.customTopBar1.Location = new System.Drawing.Point(3, 3);
            this.customTopBar1.maximizeVisible = false;
            this.customTopBar1.MaximumSize = new System.Drawing.Size(9999, 100);
            this.customTopBar1.minimizeVisible = true;
            this.customTopBar1.MinimumSize = new System.Drawing.Size(300, 35);
            this.customTopBar1.Name = "customTopBar1";
            this.customTopBar1.Padding = new System.Windows.Forms.Padding(2);
            this.customTopBar1.Size = new System.Drawing.Size(844, 35);
            this.customTopBar1.TabIndex = 0;
            // 
            // tablePanel
            // 
            this.tablePanel.Controls.Add(this.downloadTable);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(3, 100);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Padding = new System.Windows.Forms.Padding(3);
            this.tablePanel.Size = new System.Drawing.Size(844, 527);
            this.tablePanel.TabIndex = 6;
            // 
            // downloadTable
            // 
            this.downloadTable.AllowUserToAddRows = false;
            this.downloadTable.AllowUserToDeleteRows = false;
            this.downloadTable.AllowUserToResizeColumns = false;
            this.downloadTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.downloadTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.downloadTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.downloadTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.downloadTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.downloadTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.downloadTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.downloadTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.url,
            this.name,
            this.pages,
            this.status});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.downloadTable.DefaultCellStyle = dataGridViewCellStyle9;
            this.downloadTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.downloadTable.EnableHeadersVisualStyles = false;
            this.downloadTable.GridColor = System.Drawing.Color.Purple;
            this.downloadTable.Location = new System.Drawing.Point(3, 3);
            this.downloadTable.MultiSelect = false;
            this.downloadTable.Name = "downloadTable";
            this.downloadTable.ReadOnly = true;
            this.downloadTable.RowHeadersVisible = false;
            this.downloadTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.downloadTable.RowTemplate.ReadOnly = true;
            this.downloadTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.downloadTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.downloadTable.ShowEditingIcon = false;
            this.downloadTable.Size = new System.Drawing.Size(838, 521);
            this.downloadTable.TabIndex = 4;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.ReadOnly = true;
            this.url.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.url.Width = 250;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pages
            // 
            this.pages.HeaderText = "Страницы";
            this.pages.Name = "pages";
            this.pages.ReadOnly = true;
            this.pages.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pages.Width = 120;
            // 
            // status
            // 
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.status.Width = 170;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(850, 750);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.customTopBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExHentaiDownloaderZ 5";
            this.controlPanel.ResumeLayout(false);
            this.progressPanel.ResumeLayout(false);
            this.stepInfoPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.downloadTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTopBar.customTopBar customTopBar1;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.OpenFileDialog loadDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private CustomProgressBar.customProgressBar secondaryProgress;
        private System.Windows.Forms.Label secondaryProgressLabel;
        private CustomProgressBar.customProgressBar mainProgress;
        private System.Windows.Forms.Label mainProgressLabel;
        private System.Windows.Forms.Panel stepInfoPanel;
        private System.Windows.Forms.Label loadTimeLabel;
        private System.Windows.Forms.Label stepInfoLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.Panel tablePanel;
        private System.Windows.Forms.DataGridView downloadTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pages;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}

