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
    public partial class MusicForm : Form
    {
        public MusicForm()
        {
            InitializeComponent();
        }

        private void btnGatherAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPath.Text))
                {
                    Utility.ShowMessage("音乐文件所在的路径不能为空！");
                }
                MusicFile musicFile = new MusicFile();
                musicFile.GatherMusic(txtPath.Text, MusicFile.MusicInfoType.Album);
                Utility.ShowMessage("处理成功！");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex.Message);
            }
        }

    }
}
