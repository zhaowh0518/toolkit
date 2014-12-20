using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSolution.FileHandle;
using ToolSolution.Model;
using ToolSolution.TextHandle;
using ToolSolution.Utility;

namespace ToolSolution.Tools.Net
{
    public partial class Grabber : Form
    {
        #region Private Var
        /// <summary>
        /// 文件输出路径
        /// </summary>
        string OUTPUT_PATH = AppDomain.CurrentDomain.BaseDirectory + "\\Output\\";
        /// <summary>
        /// 抓取的地址
        /// </summary>
        string url = string.Empty;
        /// <summary>
        /// 生成的文件名
        /// </summary>
        string resultFileName = string.Empty;
        /// <summary>
        /// 抓取的内容类
        /// </summary>
        WebDataItem item = new WebDataItem();
        /// <summary>
        /// 抓取到的网页
        /// </summary>
        string data = string.Empty;
        /// <summary>
        /// 数据文本的编码
        /// </summary>
        string dataEncoding = string.Empty;
        /// <summary>
        /// 页面的配置文件
        /// </summary>
        ReadConfig config;
        #endregion

        public Grabber()
        {
            InitializeComponent();
            config = new ReadConfig("Config\\GrabberConfig.txt");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            long id = 0;
            long counter = 0;
            TraceLog log = new TraceLog("GrabberLog.txt");
            try
            {
                log.AddLog("===============开始抓取===============");
                //输入参数处理
                if (string.IsNullOrEmpty(txtUrl.Text))
                {
                    txtMessage.Text = "请输入要抓取的网页地址！";
                    return;
                }
                if (!string.IsNullOrEmpty(txtOutput.Text))
                {
                    OUTPUT_PATH = txtOutput.Text;
                }
                if (!System.IO.Directory.Exists(OUTPUT_PATH))
                {
                    System.IO.Directory.CreateDirectory(OUTPUT_PATH);
                }
                long startID = Convert.ToInt64(txtStartID.Text);
                long endID = Convert.ToInt64(txtEndID.Text);

                //遍历ID的方式
                if (string.IsNullOrEmpty(txtListUrl.Text))
                {
                    for (id = startID; id <= endID; id++)
                    {
                        System.Threading.Thread.Sleep(1000);
                        url = string.Format(txtUrl.Text, id);
                        //获取抓取地址的内容
                        if (CatchContent(id, url))
                        {
                            counter++;
                            log.AddLog(id.ToString());
                        }
                    }
                    txtMessage.Text = string.Format("抓取成功！累计请求{0},其中抓取有效数据{1}条，当前时间{2}",
                    id - startID, counter, DateTime.Now.ToString());
                }
                else //先遍历列表页，列出ID，然后再逐个ID找
                {
                    dataEncoding = cbbEncoding.Text;
                    List<string> listID = new List<string>();
                    string detailUrl = txtUrl.Text;

                    string strRegex = string.Format(txtUrl.Text, "\\d+").Replace("?", "\\?");
                    Regex reg = new Regex(strRegex);
                    MatchCollection regexList;
                    string tempID;

                    for (id = startID; id <= endID; id++)
                    {
                        System.Threading.Thread.Sleep(1000);
                        url = string.Format(txtListUrl.Text, id);

                        data = WebAccess.Request(url, string.Empty, WebAccess.WebAccessMethod.POST, "text\\html", null, dataEncoding);
                        if (!string.IsNullOrEmpty(data))
                        {
                            log.AddLog(string.Format("=============第{0}页=================", id));
                            regexList = reg.Matches(data);
                            for (int i = 0; i < regexList.Count; i++)
                            {
                                tempID = regexList[i].Value.Replace(txtUrl.Text.Replace("{0}", string.Empty), string.Empty);
                                if (!listID.Contains(tempID))
                                {
                                    listID.Add(tempID);
                                }
                            }
                            //在当前页找到所有ID后立马遍历下载详情页
                            foreach (var item in listID)
                            {
                                System.Threading.Thread.Sleep(100);
                                url = string.Format(txtUrl.Text, item);
                                url = System.Web.HttpUtility.UrlDecode(url);
                                if (!url.Contains("http")) //相对Url，根据列表页Url计算前段
                                {
                                    url = string.Format("{0}/{1}", txtListUrl.Text.Substring(0, txtListUrl.Text.IndexOf("/", 7)), url);
                                }
                                if (CatchContent(Convert.ToInt32(item), url))
                                {
                                    counter++;
                                    log.AddLog(item);
                                }
                            }
                            listID.Clear();
                        }
                    }
                    txtMessage.Text = string.Format("抓取成功！抓取有效数据{0}条，当前时间{1}", counter, DateTime.Now.ToString());
                }
                log.AddLog("============抓取结束==================");
                log.EndLog();
            }
            catch (Exception ex)
            {
                txtMessage.Text = ex.Message;
                log.AddLog(ex.Message);
                log.EndLog();
            }
        }
        /// <summary>
        /// 抓取网页内容
        /// </summary>
        /// <param name="id">数据的ID，源自网页中的ID</param>
        /// <param name="url">抓取的URl</param>
        /// <returns></returns>
        private bool CatchContent(long id, string url)
        {
            dataEncoding = cbbEncoding.Text;
            data = WebAccess.Request(url, string.Empty, WebAccess.WebAccessMethod.POST, "text\\html", null, dataEncoding);
            if (!string.IsNullOrEmpty(data) && data.Contains(txtFilter.Text) && !data.Contains(txtOppFilter.Text))
            {
                try
                {
                    //匹配过滤
                    item.ID = id.ToString();
                    item.Title = FindText.Find(data, config.GetConfig("Title"));
                    item.Author = FindText.Find(data, config.GetConfig("Author"));
                    item.CreateDate = FindText.Find(data, config.GetConfig("CreateDate"));
                    item.ImageUrl = FindText.Find(data, config.GetConfig("ImageUrl"));
                    item.Content = FindText.Find(data, config.GetConfig("Content"));
                    //处理HTML内容
                    if (cbReplaceHtml.Checked)
                    {
                        item.Content = HtmlText.ToText(item.Content);
                    }
                    int contentLength = Convert.ToInt32(txtContentLength.Text);
                    if (!string.IsNullOrEmpty(item.Title) && item.Content.Length > contentLength)
                    {
                        resultFileName = string.Format("{0}//{1}.txt", OUTPUT_PATH, CommonFile.RemoveInvalidChar(item.Title));
                        System.IO.File.WriteAllText(resultFileName, item.ToString());
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    txtMessage.Text = ex.Message;
                }
            }
            return false;
        }
        /// <summary>
        /// 读取配置好的界面控件数据
        /// </summary>
        private void ReadParaConfig()
        {
            ReadConfig configPara = new ReadConfig("Config\\GrabberParaConfig.txt");

            txtListUrl.Text = configPara.GetConfig("ListUrl");
            txtUrl.Text = configPara.GetConfig("Url");
            txtStartID.Text = configPara.GetConfig("StartID");
            txtEndID.Text = configPara.GetConfig("EndID");
            txtFilter.Text = configPara.GetConfig("Filter");
            txtOppFilter.Text = configPara.GetConfig("OppFilter");
            txtOutput.Text = configPara.GetConfig("Output");
            txtContentLength.Text = configPara.GetConfig("ContentLength");
            cbbEncoding.Text = configPara.GetConfig("Encoding");
        }

        private void Grabber_Load(object sender, EventArgs e)
        {
            ReadParaConfig();
        }
    }
}
