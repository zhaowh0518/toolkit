using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolSolution.Model;

namespace ToolSolution.FileHandle
{
    /// <summary>
    /// 索引文件
    /// </summary>
    public class FileIndex
    {
        /// <summary>
        /// 返回指定路径的文件索引信息，返回的数据构造成了树节点类型
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public List<TSTreeNode> GetFileIndexList(string dir)
        {
            List<TSTreeNode> list = new List<TSTreeNode>();
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            TSTreeNode root = new TSTreeNode();
            root.ID = Guid.NewGuid().ToString();
            root.Name = dirInfo.Name;
            root.IsLeaf = false;
            list = IndexFile(dirInfo, root);
            list.Add(root);
            return list;
        }
        /// <summary>
        /// 递归索引目录下的文件
        /// </summary>
        /// <param name="parentDir"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private List<TSTreeNode> IndexFile(DirectoryInfo parentDir, TSTreeNode parentNode)
        {
            List<TSTreeNode> list = new List<TSTreeNode>();
            DirectoryInfo[] childDir = parentDir.GetDirectories();
            if (childDir != null && childDir.Length > 0)
            {
                for (int i = 0; i < childDir.Length; i++)
                {
                    //加目录
                    TSTreeNode node = new TSTreeNode();
                    node.ID = Guid.NewGuid().ToString();
                    node.PID = parentNode.ID;
                    node.Name = childDir[i].Name;
                    node.IsLeaf = false;
                    list.Add(node);
                    List<TSTreeNode> tempList = IndexFile(childDir[i], node);
                    foreach (var item in tempList)
                    {
                        list.Add(item);
                    }
                }
            }
            //加文件
            FileInfo[] fileList = parentDir.GetFiles();
            for (int i = 0; i < fileList.Length; i++)
            {
                TSTreeNode node = new TSTreeNode();
                node.ID = Guid.NewGuid().ToString();
                node.PID = parentNode.ID;
                node.Name = fileList[i].Name;
                node.IsLeaf = true;
                list.Add(node);
            }
            return list;
        }
    }
}
