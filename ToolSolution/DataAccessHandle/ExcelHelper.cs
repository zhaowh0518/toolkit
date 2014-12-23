using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace ToolSolution.DataAccessHandle
{
    /// <summary>
    /// Excel操作的帮助类
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 1997-2003格式的Excel导入所使用的连接字符串
        /// </summary>
        private const string CONN_STR_97 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
        /// <summary>
        /// 2007以后格式的Excel导入所使用的连接字符串
        /// </summary>
        private const string CONN_STR_07 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
        /// <summary>
        /// 查询数据的SQL
        /// </summary>
        private const string SQL_SELECT_DATA = "select * from [{0}]";

        /// <summary>
        /// 真实的连接字符串，判断了Excel版本
        /// </summary>
        private string _connStr = string.Empty;
        public string ConnStr { get { return _connStr; } }
        /// <summary>
        /// 初始化Helper
        /// </summary>
        /// <param name="filePath"></param>
        public ExcelHelper(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("文件名不能为空！");
            }
            if (filePath.ToLower().Substring(filePath.LastIndexOf(".")).Equals(".xls")) //97-2003版本的Excel
            {
                _connStr = string.Format(CONN_STR_97, filePath);
            }
            else
            {
                _connStr = string.Format(CONN_STR_07, filePath);
            }
        }
        /// <summary>
        /// 获取Excel中的Sheet信息
        /// </summary>
        /// <returns></returns>
        public List<string> GetSheetList()
        {
            List<string> sheetList = new List<string>();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                conn.Open();
                DataTable dt = conn.GetSchema("Tables");
                conn.Close();
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sheetList.Add(dr[2].ToString());
                    }
                }
            }
            return sheetList;
        }
        /// <summary>
        /// 获取Excel中的数据
        /// </summary>
        /// <param name="sheetList">需要过滤的Sheet，如果为空则取sheet1</param>
        /// <returns></returns>
        public DataSet GetData(List<string> sheetList)
        {
            DataSet ds = new DataSet();
            string tableName = "sheet1$"; //默认值
            string sqlText = string.Empty;
            OleDbDataAdapter dataAdapter;
            //处理sheetList为空的情况
            if (sheetList == null)
            {
                sheetList = new List<string>();                
            }
            if (sheetList.Count == 0)
            {
                sheetList.Add(tableName);
            }
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                conn.Open();
                foreach (var item in sheetList)
                {
                    sqlText = string.Format(SQL_SELECT_DATA, item);
                    dataAdapter = new OleDbDataAdapter(sqlText, conn);
                    dataAdapter.Fill(ds, item);
                }
                conn.Close();
            }
            return ds;
        }
    }
}
