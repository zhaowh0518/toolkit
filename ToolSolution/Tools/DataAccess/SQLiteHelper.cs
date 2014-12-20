using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.SQLite;

namespace ToolSolution.Tools.DataAccess
{
    /// <summary>
    /// 操作SQLite数据库
    /// </summary>
    public class SQLiteHelper
    {
        /// <summary>
        /// Execute sql text to db,for insert,update and delete
        /// </summary>
        /// <param name="sqlText"></param>
        public void ExcuteSQLText(string sqlText)
        {
            string datasource = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\portaldb.db3";
            //string datasource = System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
            //SQLiteConnection conn = new SQLiteConnection();
            //SQLiteConnectionStringBuilder connStr = new SQLiteConnectionStringBuilder();
            //connStr.DataSource = datasource;
            //connStr.Password = "!QAZXSW@";
            //conn.ConnectionString = connStr.ToString();
            //conn.Open();

            //SQLiteCommand cmd = new SQLiteCommand();
            //cmd.CommandText = sqlText;
            //cmd.Connection = conn;
            //cmd.ExecuteNonQuery();
            //conn.Clone();
        }
    }
}
