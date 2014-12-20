using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shell32;

namespace ToolSolution.FileHandle
{
    /// <summary>
    /// 文件通用的处理
    /// </summary>
    public static class CommonFile
    {
        /// <summary>
        /// 获取音乐文件的属性
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FileAttributes GetFileAttributes(string path)
        {
            FileAttributes attr = new FileAttributes();
            ShellClass sh = new ShellClass();
            Folder dir = sh.NameSpace(Path.GetDirectoryName(path));
            FolderItem item = dir.ParseName(Path.GetFileName(path));
            if (item != null)
            {
                attr.Name = dir.GetDetailsOf(item, 0);
                attr.Size = dir.GetDetailsOf(item, 1);
                attr.Type = dir.GetDetailsOf(item, 2);
                attr.Album = dir.GetDetailsOf(item, 14);
                attr.Title = dir.GetDetailsOf(item, 21);
                attr.Length = dir.GetDetailsOf(item, 27);
            }
            return attr;
        }

        /// <summary>
        /// 把指定路径下的所有文件名称中的特定字符替换成指定的字符
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fromText">要替换的字符</param>
        /// <param name="toText">替换后的字符</param>
        public static void ReplaceName(string path, string fromText, string toText)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fileList = dir.GetFiles();
            string fileName = string.Empty;
            if (fileList != null && fileList.Length > 0)
            {
                for (int i = 0; i < fileList.Length; i++)
                {
                    fileName = Path.Combine(fileList[i].DirectoryName, fileList[i].Name.Replace(fromText, toText));
                    fileList[i].MoveTo(fileName);
                }
            }
        }
        /// <summary>
        /// 去除文件名中的非法字符
        /// </summary>
        /// <param name="fileName">文件的名称，不包含路径</param>
        /// <returns></returns>
        public static string RemoveInvalidChar(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            for (int i = 0; i < invalidChars.Length; i++)
            {
                fileName = fileName.Replace(invalidChars[i].ToString(), string.Empty);
            }
            return fileName;
        }

        /// <summary>
        /// 文件的属性集合
        /// </summary>
        public class FileAttributes
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public string Type { get; set; }
            public string Album { get; set; }
            public string Title { get; set; }
            public string Length { get; set; }
        }
    }
}
