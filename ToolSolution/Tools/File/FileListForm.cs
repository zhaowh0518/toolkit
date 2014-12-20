using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSolution.Model;
using ToolSolution.FileHandle;

namespace ToolSolution.Tools.File
{
    public partial class FileListForm : Form
    {
        public FileListForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string dir = txtDir.Text;
            if (string.IsNullOrEmpty(dir))
            {
                Utility.ShowMessage("目录不能为空！");
                return;
            }

            try
            {
                FileIndex fileIndex = new FileIndex();
                List<TSTreeNode> list = fileIndex.GetFileIndexList(dir);

                tvFileList.Nodes.Clear();
                TreeNode root = new TreeNode();
                TSTreeNode rootNode = list.SingleOrDefault(p => string.IsNullOrEmpty(p.PID));
                if (rootNode != null)
                {
                    root.Text = rootNode.Name;
                    root.Name = rootNode.ID;
                    root.ForeColor = Color.Blue;
                    BindTreeNode(root, list);
                    tvFileList.Nodes.Add(root);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// 递归绑定树的节点
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="list"></param>
        private TreeNode BindTreeNode(TreeNode parentNode, List<TSTreeNode> list)
        {
            List<TSTreeNode> currentList = list.FindAll(p => p.PID == parentNode.Name);
            foreach (var item in currentList)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Name;
                node.Name = item.ID;

                if (!item.IsLeaf)
                {
                    node = BindTreeNode(node, list);
                    node.ForeColor = Color.Blue;
                }
                parentNode.Nodes.Add(node);
            }
            return parentNode;
        }
    }
}
