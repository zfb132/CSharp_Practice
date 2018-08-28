namespace ImageProcessing
{
    partial class ImageProcessing
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageProcessing));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Left90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Right90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.工具TToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.OpenToolStripMenuItem.Text = "打开(&O)";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.SaveToolStripMenuItem.Text = "保存(&S)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.SaveAsToolStripMenuItem.Text = "另存为(&A)";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ExitToolStripMenuItem.Text = "退出(&X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Left90ToolStripMenuItem,
            this.Right90ToolStripMenuItem,
            this.UpDownToolStripMenuItem,
            this.LeftRightToolStripMenuItem,
            this.GrayToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // Left90ToolStripMenuItem
            // 
            this.Left90ToolStripMenuItem.Name = "Left90ToolStripMenuItem";
            this.Left90ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.Left90ToolStripMenuItem.Text = "左旋90度(&L)";
            this.Left90ToolStripMenuItem.Click += new System.EventHandler(this.Left90ToolStripMenuItem_Click);
            // 
            // Right90ToolStripMenuItem
            // 
            this.Right90ToolStripMenuItem.Name = "Right90ToolStripMenuItem";
            this.Right90ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.Right90ToolStripMenuItem.Text = "右旋90度(&R)";
            this.Right90ToolStripMenuItem.Click += new System.EventHandler(this.Right90ToolStripMenuItem_Click);
            // 
            // UpDownToolStripMenuItem
            // 
            this.UpDownToolStripMenuItem.Name = "UpDownToolStripMenuItem";
            this.UpDownToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.UpDownToolStripMenuItem.Text = "上下翻转(&U)";
            this.UpDownToolStripMenuItem.Click += new System.EventHandler(this.UpDownToolStripMenuItem_Click);
            // 
            // LeftRightToolStripMenuItem
            // 
            this.LeftRightToolStripMenuItem.Name = "LeftRightToolStripMenuItem";
            this.LeftRightToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.LeftRightToolStripMenuItem.Text = "左右翻转(&T)";
            this.LeftRightToolStripMenuItem.Click += new System.EventHandler(this.LeftRightToolStripMenuItem_Click);
            // 
            // GrayToolStripMenuItem
            // 
            this.GrayToolStripMenuItem.Name = "GrayToolStripMenuItem";
            this.GrayToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.GrayToolStripMenuItem.Text = "灰度化(&G)";
            this.GrayToolStripMenuItem.Click += new System.EventHandler(this.GrayToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(579, 376);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ImageProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 417);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ImageProcessing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像处理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Left90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Right90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeftRightToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

