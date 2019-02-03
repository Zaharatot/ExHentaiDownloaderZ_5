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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.customTopBar1 = new CustomTopBar.customTopBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.ItemsPanel = new System.Windows.Forms.Panel();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.secondaryProgress = new CustomProgressBar.customProgressBar();
            this.secondaryProgressLabel = new System.Windows.Forms.Label();
            this.mainProgress = new CustomProgressBar.customProgressBar();
            this.mainProgressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ItemsPanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customTopBar1
            // 
            this.customTopBar1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customTopBar1.buttonsSelectColor = System.Drawing.Color.Fuchsia;
            this.customTopBar1.closeVisible = true;
            this.customTopBar1.Dock = System.Windows.Forms.DockStyle.Top;
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
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.url,
            this.name,
            this.pages,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Fuchsia;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(794, 233);
            this.dataGridView1.TabIndex = 2;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.Width = 250;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            // 
            // pages
            // 
            this.pages.HeaderText = "Страницы";
            this.pages.Name = "pages";
            // 
            // status
            // 
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.Width = 120;
            // 
            // controlPanel
            // 
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(3, 38);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(794, 85);
            this.controlPanel.TabIndex = 3;
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.Controls.Add(this.dataGridView1);
            this.ItemsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsPanel.Location = new System.Drawing.Point(3, 123);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.Size = new System.Drawing.Size(794, 233);
            this.ItemsPanel.TabIndex = 4;
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.secondaryProgress);
            this.progressPanel.Controls.Add(this.secondaryProgressLabel);
            this.progressPanel.Controls.Add(this.mainProgress);
            this.progressPanel.Controls.Add(this.mainProgressLabel);
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressPanel.Location = new System.Drawing.Point(3, 598);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(794, 106);
            this.progressPanel.TabIndex = 5;
            // 
            // secondaryProgress
            // 
            this.secondaryProgress.backgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.secondaryProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondaryProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryProgress.foregroundColor = System.Drawing.Color.Fuchsia;
            this.secondaryProgress.Location = new System.Drawing.Point(0, 73);
            this.secondaryProgress.max = 100;
            this.secondaryProgress.min = 0;
            this.secondaryProgress.MinimumSize = new System.Drawing.Size(100, 25);
            this.secondaryProgress.Name = "secondaryProgress";
            this.secondaryProgress.Size = new System.Drawing.Size(794, 33);
            this.secondaryProgress.TabIndex = 4;
            this.secondaryProgress.value = 100;
            // 
            // secondaryProgressLabel
            // 
            this.secondaryProgressLabel.AutoEllipsis = true;
            this.secondaryProgressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.secondaryProgressLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.secondaryProgressLabel.Location = new System.Drawing.Point(0, 53);
            this.secondaryProgressLabel.Name = "secondaryProgressLabel";
            this.secondaryProgressLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.secondaryProgressLabel.Size = new System.Drawing.Size(794, 20);
            this.secondaryProgressLabel.TabIndex = 3;
            this.secondaryProgressLabel.Text = "label1";
            this.secondaryProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainProgress
            // 
            this.mainProgress.backgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mainProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainProgress.foregroundColor = System.Drawing.Color.Fuchsia;
            this.mainProgress.Location = new System.Drawing.Point(0, 20);
            this.mainProgress.max = 100;
            this.mainProgress.min = 0;
            this.mainProgress.MinimumSize = new System.Drawing.Size(100, 25);
            this.mainProgress.Name = "mainProgress";
            this.mainProgress.Size = new System.Drawing.Size(794, 33);
            this.mainProgress.TabIndex = 2;
            this.mainProgress.value = 100;
            // 
            // mainProgressLabel
            // 
            this.mainProgressLabel.AutoEllipsis = true;
            this.mainProgressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainProgressLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.mainProgressLabel.Location = new System.Drawing.Point(0, 0);
            this.mainProgressLabel.Name = "mainProgressLabel";
            this.mainProgressLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.mainProgressLabel.Size = new System.Drawing.Size(794, 20);
            this.mainProgressLabel.TabIndex = 0;
            this.mainProgressLabel.Text = "label1";
            this.mainProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 707);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.ItemsPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.customTopBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExHentaiDownloaderZ 5";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ItemsPanel.ResumeLayout(false);
            this.progressPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTopBar.customTopBar customTopBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel ItemsPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pages;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Panel progressPanel;
        private CustomProgressBar.customProgressBar secondaryProgress;
        private System.Windows.Forms.Label secondaryProgressLabel;
        private CustomProgressBar.customProgressBar mainProgress;
        private System.Windows.Forms.Label mainProgressLabel;
    }
}

