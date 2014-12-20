using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ToolSolution.TextHandle
{
    /// <summary>
    /// 处理文本
    /// </summary>
    public static class FindText
    {
        const string SPLIT = "{0}";
        /// <summary>
        /// 先用正则找，正则找不到再用索引找
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string Find(string data, string expression)
        {
            string result = string.Empty;
            string regexHtml = @"<[^>]*>";
            Regex reg = new Regex(expression);
            Match m = reg.Match(data);
            if (m != null && !string.IsNullOrEmpty(m.Value))
            {
                result = m.Value;
                reg = new Regex(regexHtml);
                result = reg.Replace(result, string.Empty);
            }
            else
            {
                if (!string.IsNullOrEmpty(expression))
                {
                    int index;
                    index = expression.IndexOf(SPLIT);
                    string startSign = expression.Substring(0, index);
                    string endSign = expression.Substring(index + SPLIT.Length);
                    index = data.IndexOf(startSign);
                    if (index >= 0)
                    {
                        result = data.Substring(index + startSign.Length);
                    }
                    index = result.IndexOf(endSign);
                    if (index >= 0)
                    {
                        result = result.Substring(0, index);
                    }
                }
            }
            return result;
        }
    }
}
