namespace CustomTopBar
{
    partial class customTopBar
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.maximizePictureBox = new System.Windows.Forms.PictureBox();
            this.minimizePictureBox = new System.Windows.Forms.PictureBox();
            this.headerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPictureBox.Location = new System.Drawing.Point(3, 5);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.iconPictureBox.Size = new System.Drawing.Size(37, 25);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // closePictureBox
            // 
            this.closePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closePictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.closePictureBox.Location = new System.Drawing.Point(744, 5);
            this.closePictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.closePictureBox.Size = new System.Drawing.Size(39, 25);
            this.closePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closePictureBox.TabIndex = 1;
            this.closePictureBox.TabStop = false;
            this.closePictureBox.Click += new System.EventHandler(this.closePictureBox_Click);
            // 
            // maximizePictureBox
            // 
            this.maximizePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximizePictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximizePictureBox.Location = new System.Drawing.Point(705, 5);
            this.maximizePictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.maximizePictureBox.Name = "maximizePictureBox";
            this.maximizePictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.maximizePictureBox.Size = new System.Drawing.Size(39, 25);
            this.maximizePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maximizePictureBox.TabIndex = 2;
            this.maximizePictureBox.TabStop = false;
            this.maximizePictureBox.Click += new System.EventHandler(this.maximizePictureBox_Click);
            // 
            // minimizePictureBox
            // 
            this.minimizePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizePictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizePictureBox.Location = new System.Drawing.Point(666, 5);
            this.minimizePictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.minimizePictureBox.Name = "minimizePictureBox";
            this.minimizePictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.minimizePictureBox.Size = new System.Drawing.Size(39, 25);
            this.minimizePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimizePictureBox.TabIndex = 3;
            this.minimizePictureBox.TabStop = false;
            this.minimizePictureBox.Click += new System.EventHandler(this.minimizePictureBox_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoEllipsis = true;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabel.Location = new System.Drawing.Point(40, 5);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.headerLabel.Size = new System.Drawing.Size(626, 25);
            this.headerLabel.TabIndex = 4;
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customTopBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.minimizePictureBox);
            this.Controls.Add(this.maximizePictureBox);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.iconPictureBox);
            this.MaximumSize = new System.Drawing.Size(9999, 100);
            this.MinimumSize = new System.Drawing.Size(300, 35);
            this.Name = "customTopBar";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Size = new System.Drawing.Size(786, 35);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.PictureBox closePictureBox;
        private System.Windows.Forms.PictureBox maximizePictureBox;
        private System.Windows.Forms.PictureBox minimizePictureBox;
        private System.Windows.Forms.Label headerLabel;
    }
}
