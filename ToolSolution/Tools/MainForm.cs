using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSolution.Tools.App;
using ToolSolution.Tools.File;
using ToolSolution.Tools.Net;
using ToolSolution.Tools.Video;

namespace ToolSolution.Tools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Private Method
        /// <summary>
        /// 统一用一个方法打开窗体，处理公共属性，并关闭其他窗口
        /// </summary>
        /// <param name="f"></param>
        private void ShowForm(Form f)
        {
            //先关闭主窗体下的其他窗口
            if (this.MdiChildren != null)
            {
                for (int i = 0; i < MdiChildren.Length; i++)
                {
                    MdiChildren[i].Close();
                }
            }
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ControlBox = false;
            f.Width = 800;
            f.Height = 600;
            f.Show();
        }
        #endregion

        private void tsmiFile_Click(object sender, EventArgs e)
        {
            ShowForm(new FileForm());
        }
        private void tsmiFileList_Click(object sender, EventArgs e)
        {
            ShowForm(new FileListForm());
        }

        private void tsmiMusic_Click(object sender, EventArgs e)
        {
            ShowForm(new MusicForm());
        }

        private void tsmiQQ_Click(object sender, EventArgs e)
        {
            ShowForm(new QQForm());
        }

        private void tsmiVideo_Click(object sender, EventArgs e)
        {
            ShowForm(new ImageToVideoForm());
        }

        private void tsmiImage_Click(object sender, EventArgs e)
        {
            ShowForm(new ImageForm());
        }

        private void tsmiFolder_Click(object sender, EventArgs e)
        {
            ShowForm(new FolderForm());
        }

        private void tsmiGrabber_Click(object sender, EventArgs e)
        {
            ShowForm(new Grabber());
        }

    }
}
