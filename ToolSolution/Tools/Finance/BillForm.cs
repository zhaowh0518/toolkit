using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSolution.DataAccessHelper;

namespace ToolSolution.Tools.Finance
{
    public partial class BillForm : Form
    {
        /// <summary>
        /// Excel中的所有数据
        /// </summary>
        DataSet _dsBillData = new System.Data.DataSet();
        /// <summary>
        /// Excel帮助类
        /// </summary>
        ExcelHelper _excelHelper;
        /// <summary>
        /// Excel地址
        /// </summary>
        string _excelPath = string.Empty;

        public BillForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取用户选择的Excel
        /// </summary>
        /// <returns></returns>
        private void GetExcelPath()
        {
            string path = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _excelPath = fileDialog.FileName;
            }
        }
        /// <summary>
        /// 根据Sheet的名称绑定DataGridView的数据
        /// </summary>
        /// <param name="tableName"></param>
        private void BindTableData(string tableName)
        {
            dgvData.DataSource = _dsBillData.Tables[tableName];
        }
        /// <summary>
        /// 分析财务数据按日期、分类、商家分别汇总
        /// </summary>
        private void Analyze()
        {
            string path = _excelPath.Replace(".xls", ".result.txt");
            Dictionary<string, double> sumDate = new Dictionary<string, double>();
            Dictionary<string, double> sumCategory = new Dictionary<string, double>();
            Dictionary<string, double> sumTrader = new Dictionary<string, double>();
            string strDate = string.Empty;
            string strCategory = string.Empty;
            string strTrader = string.Empty;
            double money = 0;

            //遍历Table
            for (int i = 0; i < _dsBillData.Tables.Count; i++)
            {
                //处理的必须是选中的Table
                if (!cbListTable.CheckedItems.Contains(_dsBillData.Tables[i].TableName))
                {
                    continue;
                }
                strDate = _dsBillData.Tables[i].TableName.Replace("$", string.Empty).Replace("'", string.Empty);
                if (!sumDate.Keys.Contains(strDate))
                {
                    strDate = strDate.PadLeft(2, '0'); //日期以2位展示
                    sumDate.Add(strDate, 0);
                }
                //遍历每条数据
                for (int j = 0; j < _dsBillData.Tables[i].Rows.Count; j++)
                {
                    if (!string.IsNullOrEmpty(_dsBillData.Tables[i].Rows[j]["金额"].ToString()))
                    {
                        money = Convert.ToDouble(_dsBillData.Tables[i].Rows[j]["金额"]);
                        //合计行
                        if (string.IsNullOrEmpty(_dsBillData.Tables[i].Rows[j]["日期"].ToString()) || _dsBillData.Tables[i].Rows[j]["日期"].ToString().Equals("合计"))
                        {
                            sumDate[strDate] += money;
                        }
                        else
                        {
                            strCategory = _dsBillData.Tables[i].Rows[j]["分类"].ToString();
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
                            strTrader = _dsBillData.Tables[i].Rows[j]["商家"].ToString();
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
            //排序
            sumDate = sumDate.OrderBy(p => p.Key).ToDictionary(o=>o.Key,p=>p.Value);
            sumCategory = sumCategory.OrderByDescending(p => p.Value).ToDictionary(o => o.Key, p => p.Value);
            sumTrader = sumTrader.OrderByDescending(p => p.Value).ToDictionary(o => o.Key, p => p.Value);
            //输出结果
            StringBuilder sb = new StringBuilder();
            string split = "=====================================";
            string tab = "\t\t";
            int nameLength = 10;
            //日期汇总
            sb.AppendLine("日期汇总");
            sb.AppendLine(split);
            foreach (var item in sumDate.Keys)
            {
                sb.AppendFormat("{0}{1}{2}\r\n", item.PadRight(nameLength), tab, (int)sumDate[item]);
            }
            sb.AppendLine(split);
            //分类汇总
            sb.AppendLine("分类汇总");
            sb.AppendLine(split);
            foreach (var item in sumCategory.Keys)
            {
                sb.AppendFormat("{0}{1}{2}\r\n", item.PadRight(nameLength), tab, (int)sumCategory[item]);
            }
            sb.AppendLine(split);
            //商家汇总
            sb.AppendLine("商家汇总");
            sb.AppendLine(split);
            foreach (var item in sumTrader.Keys)
            {
                sb.AppendFormat("{0}{1}{2}\r\n", item.PadRight(nameLength), tab, (int)sumTrader[item]);
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
            GetExcelPath();
            string columnsName = "日期,金额,分类,明细,商家,备注";
            _excelHelper = new ExcelHelper(_excelPath, columnsName);
            List<string> tableList = _excelHelper.GetSheetList();
            _dsBillData = _excelHelper.GetData();
            cbListTable.DataSource = tableList;
            for (int i = 0; i < cbListTable.Items.Count; i++)
            {
                cbListTable.SetItemChecked(i, true); //默认全部选中
            }
        }

        private void cbListTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTableData(cbListTable.SelectedItem.ToString());
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (_dsBillData.Tables != null && _dsBillData.Tables.Count > 0)
            {
                Analyze();
            }
        }
    }
}
