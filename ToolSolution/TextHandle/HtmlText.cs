using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ToolSolution.TextHandle
{
    /// <summary>
    /// HTML与Text处理相关
    /// </summary>
    public static class HtmlText
    {
        /// <summary>
        /// 把HTML内容转成文本格式的
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public static string ToText(string htmlText)
        {
            string regexHtml = @"<[^>]*>";
            Regex reg = new Regex(regexHtml);
            htmlText = htmlText.Replace("<br>", "\r\n").Replace("<br />", "\r\n").Replace("</p>", "\r\n\r\n").Replace("</div>", "\r\n\r\n")
                .Replace("&nbsp;", " ");
            htmlText = reg.Replace(htmlText, string.Empty);
            htmlText = System.Web.HttpUtility.HtmlDecode(htmlText);
            return htmlText;
        }
    }
}
