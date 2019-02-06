namespace ExHentaiDownloaderZ_5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.downloadTable = new System.Windows.Forms.DataGridView();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.settingsButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.secondaryProgress = new CustomProgressBar.customProgressBar();
            this.secondaryProgressLabel = new System.Windows.Forms.Label();
            this.mainProgress = new CustomProgressBar.customProgressBar();
            this.mainProgressLabel = new System.Windows.Forms.Label();
            this.customTopBar1 = new CustomTopBar.customTopBar();
            this.loadDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTable)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadTable
            // 
            this.downloadTable.AllowUserToAddRows = false;
            this.downloadTable.AllowUserToDeleteRows = false;
            this.downloadTable.AllowUserToResizeColumns = false;
            this.downloadTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.downloadTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.downloadTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.downloadTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.downloadTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.downloadTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.downloadTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.downloadTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.url,
            this.name,
            this.pages,
            this.status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.downloadTable.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.downloadTable.Size = new System.Drawing.Size(788, 598);
            this.downloadTable.TabIndex = 2;
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
            // 
            // status
            // 
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.status.Width = 120;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.settingsButton);
            this.controlPanel.Controls.Add(this.downloadButton);
            this.controlPanel.Controls.Add(this.loadButton);
            this.controlPanel.Controls.Add(this.saveButton);
            this.controlPanel.Controls.Add(this.removeButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(3, 38);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(794, 62);
            this.controlPanel.TabIndex = 3;
            // 
            // settingsButton
            // 
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.settingsButton.Location = new System.Drawing.Point(625, 14);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(144, 32);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadButton.Location = new System.Drawing.Point(475, 14);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(144, 32);
            this.downloadButton.TabIndex = 3;
            this.downloadButton.Text = "Запуск загрузки";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.loadButton.Location = new System.Drawing.Point(325, 14);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(144, 32);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Загрузить список";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.saveButton.Location = new System.Drawing.Point(175, 14);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(144, 32);
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
            this.removeButton.Size = new System.Drawing.Size(144, 32);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Удалить из списка";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // tablePanel
            // 
            this.tablePanel.Controls.Add(this.downloadTable);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(3, 100);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Padding = new System.Windows.Forms.Padding(3);
            this.tablePanel.Size = new System.Drawing.Size(794, 604);
            this.tablePanel.TabIndex = 4;
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.secondaryProgress);
            this.progressPanel.Controls.Add(this.secondaryProgressLabel);
            this.progressPanel.Controls.Add(this.mainProgress);
            this.progressPanel.Controls.Add(this.mainProgressLabel);
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressPanel.Location = new System.Drawing.Point(3, 604);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Padding = new System.Windows.Forms.Padding(3);
            this.progressPanel.Size = new System.Drawing.Size(794, 100);
            this.progressPanel.TabIndex = 5;
            // 
            // secondaryProgress
            // 
            this.secondaryProgress.backgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.secondaryProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondaryProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryProgress.foregroundColor = System.Drawing.Color.Purple;
            this.secondaryProgress.Location = new System.Drawing.Point(3, 70);
            this.secondaryProgress.max = 100;
            this.secondaryProgress.min = 0;
            this.secondaryProgress.MinimumSize = new System.Drawing.Size(100, 25);
            this.secondaryProgress.Name = "secondaryProgress";
            this.secondaryProgress.Size = new System.Drawing.Size(788, 27);
            this.secondaryProgress.TabIndex = 4;
            this.secondaryProgress.value = 100;
            // 
            // secondaryProgressLabel
            // 
            this.secondaryProgressLabel.AutoEllipsis = true;
            this.secondaryProgressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.secondaryProgressLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.secondaryProgressLabel.Location = new System.Drawing.Point(3, 50);
            this.secondaryProgressLabel.Name = "secondaryProgressLabel";
            this.secondaryProgressLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.secondaryProgressLabel.Size = new System.Drawing.Size(788, 20);
            this.secondaryProgressLabel.TabIndex = 3;
            this.secondaryProgressLabel.Text = "label1";
            this.secondaryProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainProgress
            // 
            this.mainProgress.backgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mainProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainProgress.foregroundColor = System.Drawing.Color.Purple;
            this.mainProgress.Location = new System.Drawing.Point(3, 23);
            this.mainProgress.max = 100;
            this.mainProgress.min = 0;
            this.mainProgress.MinimumSize = new System.Drawing.Size(100, 25);
            this.mainProgress.Name = "mainProgress";
            this.mainProgress.Size = new System.Drawing.Size(788, 27);
            this.mainProgress.TabIndex = 2;
            this.mainProgress.value = 100;
            // 
            // mainProgressLabel
            // 
            this.mainProgressLabel.AutoEllipsis = true;
            this.mainProgressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainProgressLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.mainProgressLabel.Location = new System.Drawing.Point(3, 3);
            this.mainProgressLabel.Name = "mainProgressLabel";
            this.mainProgressLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.mainProgressLabel.Size = new System.Drawing.Size(788, 20);
            this.mainProgressLabel.TabIndex = 0;
            this.mainProgressLabel.Text = "label1";
            this.mainProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.customTopBar1.maximizeVisible = true;
            this.customTopBar1.MaximumSize = new System.Drawing.Size(9999, 100);
            this.customTopBar1.minimizeVisible = true;
            this.customTopBar1.MinimumSize = new System.Drawing.Size(300, 35);
            this.customTopBar1.Name = "customTopBar1";
            this.customTopBar1.Padding = new System.Windows.Forms.Padding(2);
            this.customTopBar1.Size = new System.Drawing.Size(794, 35);
            this.customTopBar1.TabIndex = 0;
            // 
            // loadDialog
            // 
            this.loadDialog.Filter = "Файл сохранения|*.EHDZS";
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "Файл сохранения|*.EHDZS";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 707);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.customTopBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExHentaiDownloaderZ 5";
            ((System.ComponentModel.ISupportInitialize)(this.downloadTable)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            this.progressPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTopBar.customTopBar customTopBar1;
        private System.Windows.Forms.DataGridView downloadTable;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel tablePanel;
        private System.Windows.Forms.Panel progressPanel;
        private CustomProgressBar.customProgressBar secondaryProgress;
        private System.Windows.Forms.Label secondaryProgressLabel;
        private CustomProgressBar.customProgressBar mainProgress;
        private System.Windows.Forms.Label mainProgressLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pages;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.OpenFileDialog loadDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}

