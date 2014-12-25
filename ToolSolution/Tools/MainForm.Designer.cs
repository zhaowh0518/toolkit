namespace ToolSolution.Tools
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMusic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImage = new System.Windows.Forms.ToolStripMenuItem();
            this.应用程序类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQQ = new System.Windows.Forms.ToolStripMenuItem();
            this.多媒体类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.网络类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGrabber = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.财务类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi,
            this.应用程序类ToolStripMenuItem,
            this.多媒体类ToolStripMenuItem,
            this.网络类ToolStripMenuItem,
            this.财务类ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi
            // 
            this.tsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFolder,
            this.tsmiFile,
            this.tsmiFileList,
            this.tsmiMusic,
            this.tsmiImage});
            this.tsmi.Name = "tsmi";
            this.tsmi.Size = new System.Drawing.Size(56, 21);
            this.tsmi.Text = "文件类";
            // 
            // tsmiFolder
            // 
            this.tsmiFolder.Name = "tsmiFolder";
            this.tsmiFolder.Size = new System.Drawing.Size(124, 22);
            this.tsmiFolder.Text = "文件夹";
            this.tsmiFolder.Click += new System.EventHandler(this.tsmiFolder_Click);
            // 
            // tsmiFile
            // 
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(124, 22);
            this.tsmiFile.Text = "文件通用";
            this.tsmiFile.Click += new System.EventHandler(this.tsmiFile_Click);
            // 
            // tsmiFileList
            // 
            this.tsmiFileList.Name = "tsmiFileList";
            this.tsmiFileList.Size = new System.Drawing.Size(124, 22);
            this.tsmiFileList.Text = "文件列表";
            this.tsmiFileList.Click += new System.EventHandler(this.tsmiFileList_Click);
            // 
            // tsmiMusic
            // 
            this.tsmiMusic.Name = "tsmiMusic";
            this.tsmiMusic.Size = new System.Drawing.Size(124, 22);
            this.tsmiMusic.Text = "音乐";
            this.tsmiMusic.Click += new System.EventHandler(this.tsmiMusic_Click);
            // 
            // tsmiImage
            // 
            this.tsmiImage.Name = "tsmiImage";
            this.tsmiImage.Size = new System.Drawing.Size(124, 22);
            this.tsmiImage.Text = "图片";
            this.tsmiImage.Click += new System.EventHandler(this.tsmiImage_Click);
            // 
            // 应用程序类ToolStripMenuItem
            // 
            this.应用程序类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQQ});
            this.应用程序类ToolStripMenuItem.Name = "应用程序类ToolStripMenuItem";
            this.应用程序类ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.应用程序类ToolStripMenuItem.Text = "应用程序类";
            // 
            // tsmiQQ
            // 
            this.tsmiQQ.Name = "tsmiQQ";
            this.tsmiQQ.Size = new System.Drawing.Size(96, 22);
            this.tsmiQQ.Text = "QQ";
            this.tsmiQQ.Click += new System.EventHandler(this.tsmiQQ_Click);
            // 
            // 多媒体类ToolStripMenuItem
            // 
            this.多媒体类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVideo});
            this.多媒体类ToolStripMenuItem.Name = "多媒体类ToolStripMenuItem";
            this.多媒体类ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.多媒体类ToolStripMenuItem.Text = "多媒体类";
            // 
            // tsmiVideo
            // 
            this.tsmiVideo.Name = "tsmiVideo";
            this.tsmiVideo.Size = new System.Drawing.Size(100, 22);
            this.tsmiVideo.Text = "视频";
            this.tsmiVideo.Click += new System.EventHandler(this.tsmiVideo_Click);
            // 
            // 网络类ToolStripMenuItem
            // 
            this.网络类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGrabber});
            this.网络类ToolStripMenuItem.Name = "网络类ToolStripMenuItem";
            this.网络类ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.网络类ToolStripMenuItem.Text = "网络类";
            // 
            // tsmiGrabber
            // 
            this.tsmiGrabber.Name = "tsmiGrabber";
            this.tsmiGrabber.Size = new System.Drawing.Size(152, 22);
            this.tsmiGrabber.Text = "网页抓取";
            this.tsmiGrabber.Click += new System.EventHandler(this.tsmiGrabber_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // 财务类ToolStripMenuItem
            // 
            this.财务类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBill});
            this.财务类ToolStripMenuItem.Name = "财务类ToolStripMenuItem";
            this.财务类ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.财务类ToolStripMenuItem.Text = "财务类";
            // 
            // tsmiBill
            // 
            this.tsmiBill.Name = "tsmiBill";
            this.tsmiBill.Size = new System.Drawing.Size(152, 22);
            this.tsmiBill.Text = "个人账单";
            this.tsmiBill.Click += new System.EventHandler(this.tsmiBill_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiMusic;
        private System.Windows.Forms.ToolStripMenuItem 应用程序类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiQQ;
        private System.Windows.Forms.ToolStripMenuItem 多媒体类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiVideo;
        private System.Windows.Forms.ToolStripMenuItem tsmiImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFolder;
        private System.Windows.Forms.ToolStripMenuItem 网络类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiGrabber;
        private System.Windows.Forms.ToolStripMenuItem 财务类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiBill;
    }
}