namespace Image01
{
    partial class form
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
            this.picture = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.DDAOtsech = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamOtsech = new System.Windows.Forms.ToolStripMenuItem();
            this.DDArast = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamRast = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.Window;
            this.picture.Location = new System.Drawing.Point(0, 24);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(700, 700);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DDArast,
            this.bresenhamRast,
            this.DDAOtsech,
            this.bresenhamOtsech});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(702, 24);
            this.menu.TabIndex = 1;
            // 
            // DDAOtsech
            // 
            this.DDAOtsech.Name = "DDAOtsech";
            this.DDAOtsech.Size = new System.Drawing.Size(106, 20);
            this.DDAOtsech.Text = "ЦДА Отсечение";
            this.DDAOtsech.Click += new System.EventHandler(this.DDA_Click);
            // 
            // bresenhamOtsech
            // 
            this.bresenhamOtsech.Name = "bresenhamOtsech";
            this.bresenhamOtsech.Size = new System.Drawing.Size(139, 20);
            this.bresenhamOtsech.Text = "Брезенхам Отсечение";
            this.bresenhamOtsech.Click += new System.EventHandler(this.bresenham_Click);
            // 
            // DDArast
            // 
            this.DDArast.Name = "DDArast";
            this.DDArast.Size = new System.Drawing.Size(122, 20);
            this.DDArast.Text = "ЦДА Растеризация";
            this.DDArast.Click += new System.EventHandler(this.DDArast_Click);
            // 
            // bresenhamRast
            // 
            this.bresenhamRast.Name = "bresenhamRast";
            this.bresenhamRast.Size = new System.Drawing.Size(155, 20);
            this.bresenhamRast.Text = "Брезенхам Растеризация";
            this.bresenhamRast.Click += new System.EventHandler(this.bresenhamRast_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 732);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Компьютерная графика";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem DDAOtsech;
        private System.Windows.Forms.ToolStripMenuItem bresenhamOtsech;
        private System.Windows.Forms.ToolStripMenuItem DDArast;
        private System.Windows.Forms.ToolStripMenuItem bresenhamRast;
    }
}

