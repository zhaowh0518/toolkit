using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolSolution.Model
{
    /// <summary>
    /// 树节点数据结构
    /// </summary>
    public class TSTreeNode
    {
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// 是否是叶子节点
        /// </summary>
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 扩展字段，备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 获取节点的信息，用字符串描述
        /// </summary>
        /// <returns></returns>
        public string GetNodeInfo()
        {
            return string.Format("ID:{0};\tName:{1};\tPID:{2};\tIsLeaf:{3};\tRemark:{4}", ID, Name, PID, IsLeaf, Remark);
        }
    }
}
