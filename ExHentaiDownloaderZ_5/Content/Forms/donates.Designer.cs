namespace ExHentaiDownloaderZ_5
{
    partial class donates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(donates));
            this.headerLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.wmzTextBox = new System.Windows.Forms.TextBox();
            this.wmrTextBox = new System.Windows.Forms.TextBox();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.headerLabel.Location = new System.Drawing.Point(40, 30);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(320, 20);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "ExHentaiDownloaderZ_5";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messageLabel
            // 
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageLabel.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.messageLabel.Location = new System.Drawing.Point(40, 370);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(320, 95);
            this.messageLabel.TabIndex = 11;
            this.messageLabel.Text = resources.GetString("messageLabel.Text");
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wmzTextBox
            // 
            this.wmzTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.wmzTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmzTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wmzTextBox.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.wmzTextBox.Location = new System.Drawing.Point(40, 465);
            this.wmzTextBox.Multiline = true;
            this.wmzTextBox.Name = "wmzTextBox";
            this.wmzTextBox.ReadOnly = true;
            this.wmzTextBox.Size = new System.Drawing.Size(320, 20);
            this.wmzTextBox.TabIndex = 10;
            this.wmzTextBox.Text = "WMZ: Z212202783923";
            this.wmzTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wmrTextBox
            // 
            this.wmrTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.wmrTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wmrTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wmrTextBox.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.wmrTextBox.Location = new System.Drawing.Point(40, 485);
            this.wmrTextBox.Multiline = true;
            this.wmrTextBox.Name = "wmrTextBox";
            this.wmrTextBox.ReadOnly = true;
            this.wmrTextBox.Size = new System.Drawing.Size(320, 15);
            this.wmrTextBox.TabIndex = 8;
            this.wmrTextBox.Text = "WMR: R588584485809";
            this.wmrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconPictureBox.Image = global::ExHentaiDownloaderZ_5.Properties.Resources.icon_256;
            this.iconPictureBox.Location = new System.Drawing.Point(40, 50);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(320, 320);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox.TabIndex = 9;
            this.iconPictureBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.closeButton.Location = new System.Drawing.Point(138, 513);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(120, 32);
            this.closeButton.TabIndex = 12;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // donates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(400, 560);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.wmzTextBox);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.wmrTextBox);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "donates";
            this.Padding = new System.Windows.Forms.Padding(40, 30, 40, 60);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "preloader";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox wmzTextBox;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.TextBox wmrTextBox;
        private System.Windows.Forms.Button closeButton;
    }
}