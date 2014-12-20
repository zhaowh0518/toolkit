using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSolution.FileHandle;

namespace ToolSolution.Tools.File
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFile imageFile = new ImageFile();
                string destFile = string.Empty;
                string[] fileList = { };
                int counter = 0;
                long quality = GetCompressQuality();
                int width, height;
                Int32.TryParse(txtWidth.Text, out width);
                Int32.TryParse(txtHeight.Text, out height);
                if (Directory.Exists(txtCompressSource.Text))
                {
                    fileList = Directory.GetFiles(txtCompressSource.Text);
                }
                for (int i = 0; i < fileList.Length; i++)
                {
                    if (fileList[i].ToLower().Contains(".jpg") || fileList[i].ToLower().Contains(".png"))
                    {
                        destFile = fileList[i].Replace(txtCompressSource.Text, txtCompressDest.Text);
                        imageFile.CompressImage(fileList[i], destFile, width, height, quality);
                        counter++;
                    }
                }
                MessageBox.Show(string.Format("处理成功，共{0}张！", counter), "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("压缩失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMessage.Text = ex.Message;
            }
        }

        private long GetCompressQuality()
        {
            long quality = 100L;
            switch (combQuality.Text)
            {
                case "高":
                    quality = 80L;
                    break;
                case "中":
                    quality = 40L;
                    break;
                case "低":
                    quality = 20L;
                    break;
            }
            return quality;
        }
    }
}
