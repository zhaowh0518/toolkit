using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToolSolution.FileHandle
{
    /// <summary>
    /// 音乐相关的处理
    /// </summary>
    public class MusicFile
    {
        /// <summary>
        /// 把指定路径下的所有音乐名称中的特定字符替换成指定的字符
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fromText"></param>
        /// <param name="toText"></param>
        public void ReplaceName(string path, string fromText, string toText)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fileList = dir.GetFiles();
            if (fileList != null && fileList.Length > 0)
            {
                for (int i = 0; i < fileList.Length; i++)
                {
                    fileList[i].MoveTo(fileList[i].FullName.Replace(fromText, toText));
                }
            }
        }
        /// <summary>
        /// 把音乐按照指定的音乐信息归类
        /// </summary>
        /// <param name="path"></param>
        public void GatherMusic(string path, MusicInfoType type)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fileList = dir.GetFiles();
            string albumName = string.Empty;
            string newPath = string.Empty;
            if (fileList != null && fileList.Length > 0)
            {
                FileStream fs = null;
                for (int i = 0; i < fileList.Length; i++)
                {
                    fs = new FileStream(fileList[i].FullName, FileMode.Open);
                    byte[] data = new byte[128];
                    fs.Seek(-128, SeekOrigin.End);
                    fs.Read(data, 0, 128);
                    fs.Close();

                    albumName = GetMusicInfo(data, type);
                    //处理windows目录拒绝使用的字符
                    albumName = albumName.Replace(":", "").Replace(">", "").Replace("<", "").Replace("?", "")
                        .Replace("\\", "").Replace("/", "").Replace("\"", "");
                    newPath = string.Format("{0}\\{1}", albumName, fileList[i].Name);
                    newPath = fileList[i].FullName.Replace(fileList[i].Name, newPath);
                    if (!Directory.Exists(newPath.Replace(fileList[i].Name, "")))
                    {
                        Directory.CreateDirectory(newPath.Replace(fileList[i].Name, ""));
                    }
                    if (!File.Exists(newPath))
                    {
                        fileList[i].MoveTo(newPath);
                    }
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
        /// <summary>
        /// 获取音乐文件的属性
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetMusicInfo(string path, MusicInfoType type)
        {
            byte[] data = new byte[128];
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                fs.Seek(-128, SeekOrigin.End);
                fs.Read(data, 0, 128);
                fs.Close();
            }

            return GetMusicInfo(data, type);
        }
        /// <summary>
        /// 获取音乐中的相关信息，为了避免出现重复的数字调用，封装成了枚举
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetMusicInfo(byte[] data, MusicInfoType type)
        {
            string info = string.Empty;
            //先检查文件中是否包含音乐信息
            info = Encoding.Default.GetString(data, 0, 3);
            byte[] bInfo = new byte[30];
            if (info.Equals("TAG"))
            {
                switch (type)
                {
                    case MusicInfoType.Album:
                        info = Encoding.Default.GetString(data, 63, 30);
                        break;
                    default:
                        break;
                }
                info = info.TrimEnd('\0');
            }
            else
            {
                info = string.Empty;
            }
            return info;
        }

        /// <summary>
        /// 枚举音乐信息
        /// </summary>
        public enum MusicInfoType
        {
            Album,
            Length
        }
    }
}
