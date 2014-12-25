using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ToolSolution.DataAccessHelper;

namespace ToolSolution.Tools.Finance
{
    public partial class BillForm : Form
    {
        /// <summary>
        /// Excel中的所有数据
        /// </summary>
        DataSet dsBillData = new System.Data.DataSet();
        /// <summary>
        /// Excel帮助类
        /// </summary>
        ExcelHelper excelHelper;

        public BillForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取用户选择的Excel
        /// </summary>
        /// <returns></returns>
        private string GetExcelPath()
        {
            string path = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fileDialog.FileName;
            }
            return path;
        }
        /// <summary>
        /// 根据Sheet的名称绑定DataGridView的数据
        /// </summary>
        /// <param name="tableName"></param>
        private void BindTableData(string tableName)
        {
            dgvData.DataSource = dsBillData.Tables[tableName];
        }
        /// <summary>
        /// 分析财务数据按日期、分类、商家分别汇总
        /// </summary>
        private void Analyze()
        {
            string path = @"D:\1.txt";
            Dictionary<string, double> sumDate = new Dictionary<string, double>();
            Dictionary<string, double> sumCategory = new Dictionary<string, double>();
            Dictionary<string, double> sumTrader = new Dictionary<string, double>();
            string strDate = string.Empty;
            string strCategory = string.Empty;
            string strTrader = string.Empty;
            double money = 0;

            //遍历Table
            for (int i = 0; i < dsBillData.Tables.Count; i++)
            {
                strDate = dsBillData.Tables[i].TableName.Replace("$", string.Empty).Replace("'",string.Empty);
                if (!sumDate.Keys.Contains(strDate))
                {
                    sumDate.Add(strDate, 0);
                }
                //遍历每条数据
                for (int j = 0; j < dsBillData.Tables[i].Rows.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dsBillData.Tables[i].Rows[j]["金额"].ToString()))
                    {
                        money = Convert.ToDouble(dsBillData.Tables[i].Rows[j]["金额"]);
                        //合计行
                        if (string.IsNullOrEmpty(dsBillData.Tables[i].Rows[j]["日期"].ToString()) || dsBillData.Tables[i].Rows[j]["日期"].ToString().Equals("合计"))
                        {
                            sumDate[strDate] += money;
                        }
                        else
                        {
                            strCategory = dsBillData.Tables[i].Rows[j]["分类"].ToString();
                            if (!string.IsNullOrEmpty(strCategory))
                            {
                                if (!sumCategory.Keys.Contains(strCategory))
                                {
                                    sumCategory.Add(strCategory, money);
                                }
                                else
                                {
                                    sumCategory[strCategory] += money;
                                }
                            }
                            strTrader = dsBillData.Tables[i].Rows[j]["商家"].ToString();
                            if (!string.IsNullOrEmpty(strTrader))
                            {
                                if (!sumTrader.Keys.Contains(strTrader))
                                {
                                    sumTrader.Add(strTrader, money);
                                }
                                else
                                {
                                    sumTrader[strTrader] += money;
                                }
                            }
                        }
                    }
                }
            }

            //输出结果
            StringBuilder sb = new StringBuilder();
            string split = "=====================================";
            string tab = "\t\t\t\t";
            //日期汇总
            sb.AppendLine("日期汇总");
            sb.AppendLine(split);
            foreach (var item in sumDate.Keys)
            {
                sb.AppendFormat("{0}{1}{2}\r\n", item,tab, sumDate[item]);
            }
            sb.AppendLine("");
            //分类汇总
            sb.AppendLine("分类汇总");
            sb.AppendLine(split);
            foreach (var item in sumCategory.Keys)
            {
                sb.AppendFormat("{0}{1}{2}\r\n", item,tab, sumCategory[item]);
            }
            sb.AppendLine(split);
            //商家汇总
            sb.AppendLine("商家汇总");
            sb.AppendLine(split);
            foreach (var item in sumTrader.Keys)
            {
                sb.AppendFormat("{0}{1}{2}\r\n", item, tab,sumTrader[item]);
            }
            sb.AppendLine(split);

            using (System.IO.StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.Write(sb.ToString());
                sw.Close();
            }
            MessageBox.Show("分析完毕！");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //string path = GetExcelPath();
            string path = @"D:\2014.xls";
            excelHelper = new ExcelHelper(path);
            List<string> tableList = excelHelper.GetSheetList();
            dsBillData = excelHelper.GetData();
            cbListTable.DataSource = tableList;
        }
        private void cbListTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTableData(cbListTable.SelectedItem.ToString());
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (dsBillData.Tables != null && dsBillData.Tables.Count > 0)
            {
                Analyze();
            }
        }
    }
}
