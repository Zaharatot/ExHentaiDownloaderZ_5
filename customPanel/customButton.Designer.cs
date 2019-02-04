namespace CustomButton
{
    partial class customButton
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
            this.buttonTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTextLabel
            // 
            this.buttonTextLabel.AutoEllipsis = true;
            this.buttonTextLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTextLabel.Location = new System.Drawing.Point(3, 3);
            this.buttonTextLabel.Name = "buttonTextLabel";
            this.buttonTextLabel.Size = new System.Drawing.Size(150, 39);
            this.buttonTextLabel.TabIndex = 0;
            this.buttonTextLabel.Text = "label1";
            // 
            // customButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.Controls.Add(this.buttonTextLabel);
            this.Name = "customButton";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(156, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label buttonTextLabel;
    }
}
