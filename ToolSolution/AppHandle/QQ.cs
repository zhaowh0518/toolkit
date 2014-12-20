using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace ToolSolution.AppHandle
{
    /// <summary>
    /// QQ聊天记录
    /// </summary>
    public class QQ
    {
        /// <summary>
        /// 统计跟某个聊天的次数，按照日期分组，只统计一方的数目
        /// </summary>
        /// <param name="file">QQ聊天记录文件 txt格式</param>
        /// <param name="senderName">统计人的QQ名称或者备注</param>
        /// <returns></returns>
        public Dictionary<string, int> StatCount(string file, string senderName)
        {
            if (!File.Exists(file))
            {
                throw new Exception("File does not exit.");
            }
            Dictionary<string, int> senderList = new Dictionary<string, int>();
            try
            {
                string strDate = string.Empty;
                string[] chatList = File.ReadAllLines(file);
                DateTime dt;
                foreach (var item in chatList)
                {
                    if (item.Contains(senderName) && item.Length > 10)
                    {
                        strDate = item.Substring(0, 10);
                        DateTime.TryParse(strDate, out dt);
                        if (dt != null && dt.Year > 2000)
                        {
                            if (senderList.ContainsKey(strDate))
                            {
                                senderList[strDate] = (int)senderList[strDate] + 1;
                            }
                            else
                            {
                                senderList[strDate] = 1;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
            return senderList;
        }

        /// <summary>
        /// 逆向聊天记录，按照时间逆序
        /// </summary>
        /// <param name="fileName"></param>
        public void RevertChat(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("File does not exit.");
            }
            try
            {
                string strResult = string.Empty;
                string strP = string.Empty;
                string strDate = string.Empty;
                string[] chatList = File.ReadAllLines(fileName);
                DateTime dt = DateTime.MinValue;
                foreach (var item in chatList)
                {
                    if (item.Length > 10)
                    {
                        strDate = item.Substring(0, 10);
                        DateTime.TryParse(strDate, out dt);
                    }

                    if (dt != null && dt.Year > 2000)
                    {
                        strResult = strP + "\r\n" + strResult;
                        strP = string.Empty;
                        strP = item;
                        dt = DateTime.MinValue;
                    }
                    else
                    {
                        strP += "\r\n\r\n" + item;
                    }
                }
                string resultFileName = fileName.Replace(".txt","").Replace(".TXT","");
                resultFileName += "_revert.txt";
                if (File.Exists(resultFileName)) 
                    File.Delete(resultFileName);
                using (StreamWriter sw = File.CreateText(resultFileName))
                {
                    sw.Write(strResult);
                    sw.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
        }
    }
}
