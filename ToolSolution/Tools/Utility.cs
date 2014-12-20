using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolSolution.Tools
{
    /// <summary>
    /// 公共类
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
