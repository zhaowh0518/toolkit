using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolSolution.Model
{
    /// <summary>
    /// Item from web
    /// </summary>
    public class WebDataItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// <summary>
        /// 详细内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 转化成字符串
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}", Title, ImageUrl, Author, CreateDate, Content);
        }
    }
}
