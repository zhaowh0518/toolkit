using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace ToolSolution.DataAccessHandle
{
    /// <summary>
    /// SQLite 数据库操作的帮助类
    /// </summary>
    public class SQLiteHelper
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        private SQLiteConnection _conn;
        public SQLiteConnection Conn { get { return _conn; } }
        /// <summary>
        /// 初始化Helper
        /// </summary>
        /// <param name="dbPath">数据库文件的完整路径</param>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        public SQLiteHelper(string dbPath, string userName, string pwd)
        {
            SQLiteConnectionStringBuilder connStrBuilder = new SQLiteConnectionStringBuilder();
            connStrBuilder.DataSource = dbPath;
            connStrBuilder.Password = pwd;
            _conn = new SQLiteConnection(connStrBuilder.ToString());
        }
        /// <summary>
        /// 执行数据库脚本
        /// </summary>
        /// <param name="sqlText"></param>
        public void ExcuteSQLText(string sqlText)
        {
            Conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = sqlText;
            cmd.Connection = Conn;
            cmd.ExecuteNonQuery();
            Conn.Clone();
        }
    }
}
