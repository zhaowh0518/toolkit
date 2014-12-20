using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSolution.AppHandle;

namespace ToolSolution.Tools.App
{
    public partial class QQForm : Form
    {
        public QQForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 跟某人聊天的频次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrep_Click(object sender, EventArgs e)
        {
            try
            {
                QQ q = new QQ();
                Dictionary<string, int> list = q.StatCount(txtPath.Text, txtParam.Text);
                string msg = string.Empty;
                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        msg += string.Format("{0}\t{1}\r\n", item.Key, item.Value);
                    }
                    txtContent.Text = msg;
                    Utility.ShowMessage("获取成功！");
                }
                else
                {
                    Utility.ShowMessage("无消息记录！");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 按时间逆向输出聊天记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReverse_Click(object sender, EventArgs e)
        {
            try
            {
                QQ q = new QQ();
                q.RevertChat(txtPath.Text);
                Utility.ShowMessage("转化成功！");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex.Message);
            }
        }
    }
}
