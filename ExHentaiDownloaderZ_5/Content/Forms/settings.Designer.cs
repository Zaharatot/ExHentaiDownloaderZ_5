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
            this.passHashTextBox = new System.Windows.Forms.TextBox();
            this.passHashLabel = new System.Windows.Forms.Label();
            this.memberIdTextBox = new System.Windows.Forms.TextBox();
            this.memberIdLabel = new System.Windows.Forms.Label();
            this.downloadPathTextBox = new System.Windows.Forms.TextBox();
            this.downloadPathLabel = new System.Windows.Forms.Label();
            this.buttonsPanel.SuspendLayout();
            this.elementsPanel.SuspendLayout();
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
            this.customTopBar1.Size = new System.Drawing.Size(569, 35);
            this.customTopBar1.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.cancelSettingsButton);
            this.buttonsPanel.Controls.Add(this.saveSettingsButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(3, 168);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(569, 55);
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
            this.saveSettingsButton.Location = new System.Drawing.Point(439, 8);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(120, 32);
            this.saveSettingsButton.TabIndex = 1;
            this.saveSettingsButton.Text = "Сохранить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // elementsPanel
            // 
            this.elementsPanel.Controls.Add(this.passHashTextBox);
            this.elementsPanel.Controls.Add(this.passHashLabel);
            this.elementsPanel.Controls.Add(this.memberIdTextBox);
            this.elementsPanel.Controls.Add(this.memberIdLabel);
            this.elementsPanel.Controls.Add(this.downloadPathTextBox);
            this.elementsPanel.Controls.Add(this.downloadPathLabel);
            this.elementsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementsPanel.Location = new System.Drawing.Point(3, 38);
            this.elementsPanel.Name = "elementsPanel";
            this.elementsPanel.Padding = new System.Windows.Forms.Padding(10);
            this.elementsPanel.Size = new System.Drawing.Size(569, 130);
            this.elementsPanel.TabIndex = 2;
            // 
            // passHashTextBox
            // 
            this.passHashTextBox.Location = new System.Drawing.Point(289, 91);
            this.passHashTextBox.Name = "passHashTextBox";
            this.passHashTextBox.Size = new System.Drawing.Size(267, 20);
            this.passHashTextBox.TabIndex = 5;
            // 
            // passHashLabel
            // 
            this.passHashLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.passHashLabel.Location = new System.Drawing.Point(13, 89);
            this.passHashLabel.Name = "passHashLabel";
            this.passHashLabel.Size = new System.Drawing.Size(270, 23);
            this.passHashLabel.TabIndex = 4;
            this.passHashLabel.Text = "Значение \"ipb_pass_hash\" из куков:";
            this.passHashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memberIdTextBox
            // 
            this.memberIdTextBox.Location = new System.Drawing.Point(289, 65);
            this.memberIdTextBox.Name = "memberIdTextBox";
            this.memberIdTextBox.Size = new System.Drawing.Size(267, 20);
            this.memberIdTextBox.TabIndex = 3;
            // 
            // memberIdLabel
            // 
            this.memberIdLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.memberIdLabel.Location = new System.Drawing.Point(13, 63);
            this.memberIdLabel.Name = "memberIdLabel";
            this.memberIdLabel.Size = new System.Drawing.Size(270, 23);
            this.memberIdLabel.TabIndex = 2;
            this.memberIdLabel.Text = "Значение \"ipb_member_id\" из куков:";
            this.memberIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // downloadPathTextBox
            // 
            this.downloadPathTextBox.Location = new System.Drawing.Point(289, 23);
            this.downloadPathTextBox.Name = "downloadPathTextBox";
            this.downloadPathTextBox.Size = new System.Drawing.Size(267, 20);
            this.downloadPathTextBox.TabIndex = 1;
            // 
            // downloadPathLabel
            // 
            this.downloadPathLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.downloadPathLabel.Location = new System.Drawing.Point(13, 21);
            this.downloadPathLabel.Name = "downloadPathLabel";
            this.downloadPathLabel.Size = new System.Drawing.Size(270, 23);
            this.downloadPathLabel.TabIndex = 0;
            this.downloadPathLabel.Text = "Путь загрузки:";
            this.downloadPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(575, 226);
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
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTopBar.customTopBar customTopBar1;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.Panel elementsPanel;
        private System.Windows.Forms.Label downloadPathLabel;
        private System.Windows.Forms.TextBox passHashTextBox;
        private System.Windows.Forms.Label passHashLabel;
        private System.Windows.Forms.TextBox memberIdTextBox;
        private System.Windows.Forms.Label memberIdLabel;
        private System.Windows.Forms.TextBox downloadPathTextBox;
    }
}