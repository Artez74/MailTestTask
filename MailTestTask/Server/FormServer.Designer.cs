namespace Server
{
    partial class FormServer
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
            this.lstPrint = new System.Windows.Forms.ListBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.PrintMainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPrint
            // 
            this.lstPrint.FormattingEnabled = true;
            this.lstPrint.Location = new System.Drawing.Point(12, 27);
            this.lstPrint.Name = "lstPrint";
            this.lstPrint.Size = new System.Drawing.Size(342, 134);
            this.lstPrint.TabIndex = 4;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintMainMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(367, 24);
            this.MainMenu.TabIndex = 5;
            this.MainMenu.Text = "menuStrip1";
            // 
            // PrintMainMenuItem
            // 
            this.PrintMainMenuItem.Name = "PrintMainMenuItem";
            this.PrintMainMenuItem.Size = new System.Drawing.Size(58, 20);
            this.PrintMainMenuItem.Text = "Печать";
            this.PrintMainMenuItem.Click += new System.EventHandler(this.PrintMainMenuItem_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(265, 167);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 37);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 167);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(93, 37);
            this.btnStartStop.TabIndex = 7;
            this.btnStartStop.Text = "Старт";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 216);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstPrint);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrint;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem PrintMainMenuItem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStartStop;
    }
}

