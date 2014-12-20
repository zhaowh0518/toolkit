using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToolSolution.AppHandle
{
    /// <summary>
    /// 网页版本的新浪微博
    /// </summary>
    public class SinaWeibo
    {
        public int MessageCount = 0;
        /// <summary>
        /// 私信每行的格式
        /// </summary>
        private string messageFormat = "{0} {1}\r\n{2}\r\n\r\n"; //发送时间 发信人 /r/n信息内容/r/n/r/n
        /// <summary>
        /// 表情格式
        /// </summary>
        private string faceFormat = "[face={0}]";
        /// <summary>
        /// 从Htm文件中抓取微博的私信
        /// </summary>
        /// <param name="path">htm文件存放的路径，1.htm</param>
        /// <returns></returns>
        public List<string> GetMessageList(string path)
        {
            List<string> messageList = new List<string>();
            string[] fileList = Directory.GetFiles(path);
            for (int i = 0; i < fileList.Length; i++)
            {
                foreach (var item in GetMessage(string.Format("{0}\\{1}.htm", path, i + 1)))
                {
                    messageList.Add(item);
                }
            }
            return messageList;
        }
        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="messageList"></param>
        /// <param name="fileName"></param>
        public void OutputMessage(List<string> messageList, string fileName)
        {
            StringBuilder sb = new StringBuilder();
            messageList.Distinct();
            sb.AppendLine(string.Format("新浪微博私信对话，共{0}条",MessageCount));
            sb.AppendLine("================================");
            sb.AppendLine();
            for (int i = messageList.Count - 1; i >= 0; i--)
            {
                sb.Append(messageList[i]);
            }
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
        /// <summary>
        /// 读取htm中的内容，并转化为指定的格式输出
        /// </summary>
        /// <param name="file">htm文件地址</param>
        /// <returns></returns>
        private List<string> GetMessage(string file)
        {
            List<string> messageList = new List<string>();
            //读取文件
            string htmlContent = string.Empty;
            using (StreamReader reader = new StreamReader(file))
            {
                htmlContent = reader.ReadToEnd();
            }
            //第一步：按照dl标签拆分html
            List<string> htmlList = new List<string>();
            htmlList = SpanHtml(htmlList, htmlContent, 0);
            //第二步：提取每段dl中的内容并转化为指定格式
            foreach (var item in htmlList)
            {
                messageList.Add(FilterMessage(item));
            }
            return messageList;
        }
        /// <summary>
        /// 按照前后标志把Html内容截取为类似的一段
        /// </summary>
        /// <param name="htmlList"></param>
        /// <param name="htmlContent"></param>
        /// <param name="startSpan"></param>
        /// <returns></returns>
        private List<string> SpanHtml(List<string> htmlList, string htmlContent, int startSpan)
        {
            string beginTag = "<dl class=\"private_SRLl clearfix\" node-type=\"msgList\">";
            string endTag = " <div class=\"arrow\"></div>";
            htmlContent = htmlContent.Replace("private_SRLr", "private_SRLl");
            //此时使用startSpan特别有必要，之前是在递归前调用SubString，传递剩余的String，内存直线上升
            //所有递归使用的htmlContent共用同一个后就没有内存的问题了
            int startIndex = htmlContent.IndexOf(beginTag, startSpan);
            if (startIndex > 0)
            {
                int endIndex = htmlContent.IndexOf(endTag, startIndex);
                int length = endIndex - startIndex + endTag.Length;
                string text = htmlContent.Substring(startIndex, length);
                htmlList.Add(text);
                return SpanHtml(htmlList, htmlContent, endIndex);
            }
            else
            {
                return htmlList;
            }
        }
        /// <summary>
        /// 过滤Html，转化为实际的内容
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string FilterMessage(string html)
        {
            string message = string.Empty;
            string createDate = string.Empty;
            string sender = string.Empty;
            string messageContent = string.Empty;

            //判断的标签
            //日期
            string dateBeginTag = "<em class=\"S_txt2  date\" href=\"\">";
            string dateEndTag = "</em>";
            //内容
            string contentBeginTag = "：";
            string contentEndTag = "</span>";
            string mutiMssgTag = "<div class=\"W_linedot\"></div>"; //一个人可以发多条消息后等待对方回复
            bool isMuti = true;

            //索引
            int startIndex = 0;
            int dateBeginIndex = 0;
            int dateEndIndex = 0;
            int contentBeginIndex = 0;
            int contentEndIndex = 0;

            while (isMuti) //默认多条
            {
                //获取日期
                dateBeginIndex = html.IndexOf(dateBeginTag,startIndex);
                dateBeginIndex = dateBeginIndex + dateBeginTag.Length;
                dateEndIndex = html.IndexOf(dateEndTag, dateBeginIndex);
                createDate = html.Substring(dateBeginIndex, dateEndIndex - dateBeginIndex);

                //获取发信人
                if (html.IndexOf("我：") > 0)
                {
                    sender = "#自己#";
                }
                else
                {
                    sender = "#对方#";
                }

                //获取私信内容
                contentBeginIndex = html.IndexOf(contentBeginTag,startIndex);
                contentBeginIndex = contentBeginIndex + contentBeginTag.Length;
                contentEndIndex = html.IndexOf(contentEndTag, contentBeginIndex);
                messageContent = html.Substring(contentBeginIndex, contentEndIndex - contentBeginIndex);
                messageContent = FilterFace(messageContent);

                //先判断是否还有消息(isMuti), 再计算startIndex
                isMuti = html.IndexOf(mutiMssgTag, startIndex) > 0;
                startIndex = html.IndexOf(mutiMssgTag, startIndex) + mutiMssgTag.Length;
                message += string.Format(messageFormat, createDate, sender, messageContent);
                MessageCount++;
            }
            return message;
        }
        /// <summary>
        /// 处理表情,一条消息中可能有多个表情
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string FilterFace(string content)
        {
            //处理前：<img src="./1_files/good_org.gif" title="[good]" alt="[good]" type="face">
            //处理后：[face=good]
            while (content.Contains("type=\"face\""))
            {
                //获取表情
                string beginTag = "title=\"[";
                string endTag = "]";
                int beginIndex = content.IndexOf(beginTag) + beginTag.Length;
                int endIndex = content.IndexOf(endTag, beginIndex);
                string faceType = content.Substring(beginIndex, endIndex - beginIndex);
                string face = string.Format(faceFormat, faceType);
                content = content.Replace("type=\"face\">", "type=\"face\">" + face);
                //删除HTML字符
                beginTag = "<img src=";
                endTag = "type=\"face\">";
                beginIndex = content.IndexOf(beginTag);
                endIndex = content.IndexOf(endTag, beginIndex) + endTag.Length;
                string htmlFace = content.Substring(beginIndex, endIndex - beginIndex);
                content = content.Replace(htmlFace, string.Empty);
            }
            return content;
        }
    }
}
