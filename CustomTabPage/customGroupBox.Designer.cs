namespace customGroupBox
{
    partial class customGroupBox
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
            this.grpupBoxName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grpupBoxName
            // 
            this.grpupBoxName.AutoSize = true;
            this.grpupBoxName.Location = new System.Drawing.Point(11, 2);
            this.grpupBoxName.Name = "grpupBoxName";
            this.grpupBoxName.Size = new System.Drawing.Size(35, 13);
            this.grpupBoxName.TabIndex = 0;
            this.grpupBoxName.Text = "label1";
            // 
            // customGroupBox
            // 
            this.Controls.Add(this.grpupBoxName);
            this.MaximumSize = new System.Drawing.Size(5000, 5000);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "customGroupBox";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(200, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label grpupBoxName;
    }
}
