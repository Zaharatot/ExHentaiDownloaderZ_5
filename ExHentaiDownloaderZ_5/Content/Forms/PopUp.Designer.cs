namespace ExHentaiDownloaderZ_5
{
    partial class PopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUp));
            this.customTopBar1 = new CustomTopBar.customTopBar();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.firstButton = new System.Windows.Forms.Button();
            this.secondButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.thridButton = new System.Windows.Forms.Button();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customTopBar1
            // 
            this.customTopBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.customTopBar1.buttonsSelectColor = System.Drawing.Color.Purple;
            this.customTopBar1.closeVisible = true;
            this.customTopBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customTopBar1.headerColor = System.Drawing.Color.MediumSlateBlue;
            this.customTopBar1.headerText = "PopUpMessage";
            this.customTopBar1.icon = global::ExHentaiDownloaderZ_5.Properties.Resources.icon_256;
            this.customTopBar1.iconVisible = false;
            this.customTopBar1.Location = new System.Drawing.Point(3, 3);
            this.customTopBar1.maximizeVisible = false;
            this.customTopBar1.MaximumSize = new System.Drawing.Size(9999, 100);
            this.customTopBar1.minimizeVisible = false;
            this.customTopBar1.MinimumSize = new System.Drawing.Size(300, 35);
            this.customTopBar1.Name = "customTopBar1";
            this.customTopBar1.Padding = new System.Windows.Forms.Padding(2);
            this.customTopBar1.Size = new System.Drawing.Size(493, 35);
            this.customTopBar1.TabIndex = 1;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.thridButton);
            this.buttonsPanel.Controls.Add(this.firstButton);
            this.buttonsPanel.Controls.Add(this.secondButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(3, 219);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.buttonsPanel.Size = new System.Drawing.Size(493, 38);
            this.buttonsPanel.TabIndex = 2;
            // 
            // firstButton
            // 
            this.firstButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.firstButton.Location = new System.Drawing.Point(113, 5);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(120, 28);
            this.firstButton.TabIndex = 4;
            this.firstButton.Text = "ОК";
            this.firstButton.UseVisualStyleBackColor = true;
            // 
            // secondButton
            // 
            this.secondButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secondButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.secondButton.Location = new System.Drawing.Point(239, 5);
            this.secondButton.Name = "secondButton";
            this.secondButton.Size = new System.Drawing.Size(120, 28);
            this.secondButton.TabIndex = 3;
            this.secondButton.Text = "ОК";
            this.secondButton.UseVisualStyleBackColor = true;
            // 
            // messageLabel
            // 
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.messageLabel.Location = new System.Drawing.Point(3, 38);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Padding = new System.Windows.Forms.Padding(5);
            this.messageLabel.Size = new System.Drawing.Size(493, 181);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thridButton
            // 
            this.thridButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thridButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.thridButton.Location = new System.Drawing.Point(365, 5);
            this.thridButton.Name = "thridButton";
            this.thridButton.Size = new System.Drawing.Size(120, 28);
            this.thridButton.TabIndex = 5;
            this.thridButton.Text = "ОК";
            this.thridButton.UseVisualStyleBackColor = true;
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(499, 260);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.customTopBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopUp";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopUp";
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTopBar.customTopBar customTopBar1;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button secondButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button thridButton;
    }
}