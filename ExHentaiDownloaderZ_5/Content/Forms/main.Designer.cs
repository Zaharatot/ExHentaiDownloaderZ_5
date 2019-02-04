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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.secondaryProgress = new CustomProgressBar.customProgressBar();
            this.secondaryProgressLabel = new System.Windows.Forms.Label();
            this.mainProgress = new CustomProgressBar.customProgressBar();
            this.mainProgressLabel = new System.Windows.Forms.Label();
            this.customTopBar1 = new CustomTopBar.customTopBar();
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
            this.controlPanel.Controls.Add(this.button5);
            this.controlPanel.Controls.Add(this.button4);
            this.controlPanel.Controls.Add(this.button3);
            this.controlPanel.Controls.Add(this.button2);
            this.controlPanel.Controls.Add(this.button1);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(3, 38);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(794, 62);
            this.controlPanel.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.button5.Location = new System.Drawing.Point(608, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 32);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.button4.Location = new System.Drawing.Point(458, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 32);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.button3.Location = new System.Drawing.Point(308, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.button2.Location = new System.Drawing.Point(158, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.Location = new System.Drawing.Point(8, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
    }
}

