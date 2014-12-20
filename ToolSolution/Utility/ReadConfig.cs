using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ToolSolution.Utility
{
    /// <summary>
    /// 读取配置文件
    /// </summary>
    public class ReadConfig
    {
        private string[] CONFIGCONTENT;

        /// <summary>
        /// 创建对象时把配置信息全部读入到内存中
        /// </summary>
        /// <param name="filePath"></param>
        public ReadConfig(string filePath)
        {
            CONFIGCONTENT = File.ReadAllLines(filePath);
        }
        /// <summary>
        /// 根据名称获取配置节
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetConfig(string name)
        {
            name = string.Format("[{0}]=", name);
            for (int i = 0; i < CONFIGCONTENT.Length; i++)
            {
                if (CONFIGCONTENT[i].Contains(name))
                {
                    return CONFIGCONTENT[i].Replace(name, string.Empty);
                }
            }
            return string.Empty;
        }
    }
}
