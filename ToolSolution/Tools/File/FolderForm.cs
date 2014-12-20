using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolSolution.Tools.File
{
    public partial class FolderForm : Form
    {
        public FolderForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(txtPath.Text))
                {
                    string[] dirList = Directory.GetDirectories(txtPath.Text);
                    Dictionary<string, string> folderList = new Dictionary<string, string>();
                    double size = 0;
                    for (int i = 0; i < dirList.Length; i++)
                    {
                        //把字节换算成M
                        size = GetFolderSize(dirList[i]) / (1024 * 1024);
                        folderList.Add(dirList[i].Replace(txtPath.Text + "\\", string.Empty), size.ToString("0.00"));
                    }
                    BindingSource bs = new BindingSource();
                    bs.DataSource = folderList;
                    dgvList.DataSource = folderList.OrderBy(p => Convert.ToDouble(p.Value)).ToList();
                    dgvList.Columns[0].HeaderText = "文件夹名称";
                    dgvList.Columns[0].Width = 500;
                    dgvList.Columns[1].HeaderText = "大小(M)";
                    dgvList.Columns[1].Width = 150;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败！" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 获取文件夹的大小，包含子文件夹
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        /// <returns></returns>
        private double GetFolderSize(string folderName)
        {
            double size = 0;
            //先计算文件夹下所有的文件
            DirectoryInfo dir = new DirectoryInfo(folderName);
            FileInfo[] fileList = dir.GetFiles();
            if (fileList != null && fileList.Length > 0)
            {
                for (int i = 0; i < fileList.Length; i++)
                {
                    size += fileList[i].Length;
                }
            }
            //再计算子目录
            string[] childFolder = Directory.GetDirectories(folderName);
            if (childFolder != null && childFolder.Length > 0)
            {
                for (int i = 0; i < childFolder.Length; i++)
                {
                    size += GetFolderSize(childFolder[i]);
                }
            }
            return size;
        }
    }
}
