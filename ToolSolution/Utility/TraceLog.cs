using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ToolSolution.Utility
{
    /// <summary>
    /// 跟踪日志
    /// </summary>
    public class TraceLog
    {
        /// <summary>
        /// 日志写入流
        /// </summary>
        StreamWriter sw;

        public TraceLog(string fileName)
        {
            sw = File.CreateText(fileName);
        }
        /// <summary>
        /// 写日志，自动加时间戳
        /// </summary>
        /// <param name="message"></param>
        public void AddLog(string message)
        {
            sw.WriteLine(string.Format("{0}[{1}]", message, DateTime.Now));
        }
        /// <summary>
        /// 结束时调用，关闭文件流
        /// </summary>
        public void EndLog()
        {
            if (sw != null)
            {
                sw.Close();
                sw = null;
            }
        }
    }
}
