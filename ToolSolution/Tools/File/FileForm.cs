using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSolution.FileHandle;

namespace ToolSolution.Tools.File
{
    public partial class FileForm : Form
    {
        public FileForm()
        {
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFilePath.Text))
                {
                    Utility.ShowMessage("文件所在的路径不能为空！");
                }
                CommonFile.ReplaceName(txtFilePath.Text, txtReplaceChar.Text, txtReplaceToChar.Text);
                Utility.ShowMessage("替换成功！");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex.Message);
            }
        }
    }
}
