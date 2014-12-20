using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSolution.FileHandle;

namespace ToolSolution.Tools.Video
{
    /// <summary>
    /// 采用ffmpeg编码器
    /// ffmpeg -f image2 -pattern_type glob -i 'foo-*.jpeg' -r 12 -s WxH foo.avi
    /// ffmpeg -f image2 -i %03d.jpg -r 12 -s 1024*768  foo.avi
    /// </summary>
    public partial class ImageToVideoForm : Form
    {
        /// <summary>
        /// 工具的地址
        /// </summary>
        public string ToolPath = @"\lib\ffmpeg\ffmpeg.exe";
        /// <summary>
        /// 工作目录地址，用于存放中间过程中的临时图片和音乐
        /// </summary>
        public string WorkPath = @"\Temp";
        /// <summary>
        /// 生成过程中的消息
        /// </summary>
        private string Message = string.Empty;

        public ImageToVideoForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            ToolPath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, ToolPath);
            WorkPath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, WorkPath);
            if (!Directory.Exists(WorkPath))
            {
                Directory.CreateDirectory(WorkPath);
            }

            cbResolution.SelectedIndex = 0; //默认1080P
            cbSpeed.SelectedIndex = 0;  //默认3秒，普通速度
        }

        private void ImageToVideoForm_Load(object sender, EventArgs e)
        {
            txtOutputPath.Text = string.Format("{0}\\Output", AppDomain.CurrentDomain.BaseDirectory);
            //默认音乐
            txtMusicPath.Text = string.Format(@"{0}\resource\video\music\初雪.mp3", AppDomain.CurrentDomain.BaseDirectory);
            //默认封面和封底
            txtCover.Text = string.Format(@"{0}\resource\video\cover\cover1.jpg", AppDomain.CurrentDomain.BaseDirectory);
            txtCoverBack.Text = string.Format(@"{0}\resource\video\cover\cover1.jpg", AppDomain.CurrentDomain.BaseDirectory);
            txtTitle.Text = "我的相册";
            txtTempPath.Text = string.Format("{0}\\Temp", AppDomain.CurrentDomain.BaseDirectory);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFoldPath.Text == txtTempPath.Text)
                {
                    MessageBox.Show("图片文件目录不允许和工作目录重复！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtMessage.Text = string.Empty;
                Message = string.Empty;
                //必须得有临时目录, 如果给定的目录不存在，则自动创建
                if (!string.IsNullOrEmpty(txtTempPath.Text))
                {
                    WorkPath = txtTempPath.Text;
                }
                string tempNoMusicVideo = string.Format("{0}\\temp.avi", WorkPath); //无音乐的临时avi
                string tempInMusicVideo = string.Format("{0}\\temp2.avi", WorkPath); // 加入了音乐的视频
                string tempOutputVideo = string.Format("{0}\\temp3.avi", WorkPath); //可作为输出的AVI
                string outputVideo = string.Format("{0}\\{1}.{2}", txtOutputPath.Text, txtTitle.Text, "avi"); //视频输出路径
                //计时开始
                DateTime dtCreateBegin = DateTime.Now;
                AddMessage(string.Format("开始生成，当前时间：{0}", dtCreateBegin.ToString("HH:mm:ss")));  ///Message 1
                //当目录存在并且当前不是重新生成的时候需要清理目录
                if (Directory.Exists(WorkPath) && !chbReCreate.Checked)
                {
                    Directory.Delete(WorkPath, true);
                    Directory.CreateDirectory(WorkPath);
                }
                else if (!Directory.Exists(WorkPath))
                {
                    Directory.CreateDirectory(WorkPath);
                }
                string imagePath = WorkPath;
                if (!chbQuicCreate.Checked) //不转码图片直接生成
                {
                    //图片目录
                    if (!Directory.Exists(txtFoldPath.Text))
                    {
                        AddMessage("图片目录不存在！");  ///Message 2
                        return;                                                             //=================================return
                    }
                    //拷贝图片文件到工作目录，并根据指定的分辨率转码，以高为基准
                    AddMessage("拷贝图片到工作目录...");    ///Message 3
                    int imageCount = CopyImage(txtFoldPath.Text, WorkPath, !chbReCreate.Checked);
                    if (imageCount == 0)
                    {
                        AddMessage("图片拷贝失败！");  ///Message 4
                        return;                                                              //=================================return            
                    }
                    //如果有封面和封底则生成封面
                    if (!string.IsNullOrEmpty(txtCover.Text) && System.IO.File.Exists(txtCover.Text))
                    {
                        CompressImage(txtCover.Text, string.Format("{0}\\0.jpg", WorkPath));
                        if (Convert.ToInt32(cbSpeed.SelectedItem) < 5) //如果速度小于五秒为了多显示封面，重新拷贝一遍
                        {
                            System.IO.File.Copy(string.Format("{0}\\0.jpg", WorkPath), string.Format("{0}\\00.jpg", WorkPath), true);
                        }
                    }
                    if (!string.IsNullOrEmpty(txtCoverBack.Text) && System.IO.File.Exists(txtCoverBack.Text))
                    {
                        string[] imageList = Directory.GetFiles(WorkPath);
                        CompressImage(txtCoverBack.Text, string.Format("{0}\\{1}.jpg", WorkPath, imageCount));
                    }
                    //生成视频文件
                    AddMessage(string.Format("{0}张图片拷贝完毕，开始生成视频...", imageCount));  ///Message 5
                }
                else
                {
                    imagePath = txtFoldPath.Text;
                }
                //图片之间的转化速度最后转化为framerate
                CreateVideo(imagePath, tempNoMusicVideo, Convert.ToDouble(cbSpeed.SelectedItem.ToString()));
                //第一次生成失败，则重试
                if (!System.IO.File.Exists(tempNoMusicVideo))
                {
                    CreateVideo(WorkPath, tempNoMusicVideo, Convert.ToDouble(cbSpeed.SelectedItem.ToString()));
                }
                //第二次生成失败则退出
                if (!System.IO.File.Exists(tempNoMusicVideo))
                {
                    AddMessage("视频生成失败");   ///Message 6
                    return;                                                              //=================================return
                }
                //处理视频信息
                AddVideoMetadata(tempNoMusicVideo, tempOutputVideo, txtTitle.Text);
                //合并音乐和视频,并按照输入的标题重命名文件
                AddMessage("视频生成完毕，开始生成音乐。。。");     ///Message 7

                string inputMusic = string.Format("{0}\\temp.mp3", WorkPath);
                //视频的长度固定音乐的长度，多了截取，短了重复音乐
                CommonFile.FileAttributes videoFileAtributes = CommonFile.GetFileAttributes(tempNoMusicVideo);
                //如果是音乐目录，则先合并音乐
                string musicPath = txtMusicPath.Text;
                if (!System.IO.File.Exists(musicPath) && Directory.Exists(musicPath))
                {
                    string tempMusic = string.Format("{0}\\dirMusicTemp.mp3", WorkPath);
                    AddDirMusic(musicPath, tempMusic);
                    musicPath = tempMusic;
                }
                if (System.IO.File.Exists(musicPath))
                {
                    CreateMusic(musicPath, videoFileAtributes.Length, inputMusic);
                }
                //如果输出目录不存在，则创建
                if (!Directory.Exists(txtOutputPath.Text))
                {
                    Directory.CreateDirectory(txtOutputPath.Text);
                }
                //确定音乐正常的生成
                if (System.IO.File.Exists(inputMusic))
                {
                    AddMessage("音乐生成完毕，开始合成视频和音乐");     ///Message 8
                    MixAudioAndVideo(inputMusic, tempOutputVideo, tempInMusicVideo);
                }
                else
                {
                    AddMessage("音乐生成失败，输出视频");     ///Message 9
                    System.IO.File.Copy(tempNoMusicVideo, tempInMusicVideo);
                }
                //加入视频信息
                AddMessage("处理视频信息"); ///Message 11
                //AddVideoMetadata(tempInMusicVideo, tempOutputVideo,txtTitle.Text); //加入元数据有问题
                tempOutputVideo = tempInMusicVideo;
                //拷贝视频到用户指定的目录
                System.IO.File.Copy(tempOutputVideo, outputVideo, true);
                //清除过程中的临时文件和目录
                if (chbAutoClear.Checked)
                {
                    Directory.Delete(WorkPath, true);
                }
                DateTime dtCreateEnd = DateTime.Now;
                TimeSpan ts = dtCreateEnd - dtCreateBegin;
                AddMessage(string.Format("生成成功！用时{0}分钟", Convert.ToInt32(ts.TotalMinutes)));    ///Message 11
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                txtMessage.Text = Message;
            }
        }
        /// <summary>
        /// 添加消息，统一格式处理
        /// </summary>
        /// <param name="message"></param>
        private void AddMessage(string message)
        {
            System.Threading.Thread.SpinWait(1000);
            Message += string.Format("{0}\r\n\r\n", message);
            txtMessage.Text = Message;
        }

        #region 核心流程
        /// <summary>
        /// 拷贝文件，拷贝的过程中同时压缩文件
        /// 一个文件需要多份时，直接复制压缩后的文件
        /// </summary>
        /// <param name="sourceDir">源路径</param>
        /// <param name="destDir">目标路径</param>
        /// <param name="isOverwirte">是否重写之前生成的图片</param>
        /// <returns></returns>
        public int CopyImage(string sourceDir, string destDir, bool isOverwirte = true)
        {
            int result = 0;
            List<string> sourceFileList = new List<string>();
            GetDirAllFile(sourceDir, sourceFileList);
            //按照文件的修改日期排序
            sourceFileList.Sort(new Comparison<string>(delegate(string a, string b)
            {
                return System.IO.File.GetLastWriteTimeUtc(a).CompareTo(System.IO.File.GetLastWriteTimeUtc(b));

            }));
            if (sourceFileList != null && sourceFileList.Count > 0)
            {
                string destFile = string.Empty;
                for (int i = 0; i < sourceFileList.Count; i++)
                {
                    destFile = string.Format("{0}\\{1}.jpg", destDir, i + 1); //0.jpg留给封面
                    if (!System.IO.File.Exists(destFile) || isOverwirte)
                    {
                        CompressImage(sourceFileList[i], destFile);
                        //System.IO.File.Copy(sourceFileList[i], destFile);
                    }
                    result++;
                }
            }
            return result;
        }
        /// <summary>
        /// 压缩图片，分辨率取用户选择的，质量为100L
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        private void CompressImage(string source, string dest)
        {
            int[] resolution = GetResolution();
            long quality = 100L; //图片的质量
            //必须每次都生成ImageFile对象，否则同一对象调用CompressImage次数太多会造成内存不足
            ImageFile imgFile = new ImageFile();
            imgFile.CompressImage(source, dest, resolution[0], resolution[1], quality);
        }
        /// <summary>
        /// 生成视频文件
        /// ffmpeg -f image2 -framerate 0.2 -i %d.jpg -r 12 -qscale 1 foo.avi
        /// </summary>
        /// <param name="imagePath">图片目录</param>
        /// <param name="outputFile">视频输出目录</param>
        /// <param name="seconds">图片的间隔时间</param>
        public void CreateVideo(string imagePath, string outputFile, double seconds)
        {
            //framerate指的是每帧几张图片，这儿需要的是一张图片显示多帧，算法1/seconds
            //qscale 图片质量1-31 越小越好
            string args = string.Format("-f image2 -framerate {0} -i {1}\\%d.jpg -r 12 -q:v 1 -y  {2}",
                          1.0 / seconds, imagePath, outputFile);
            CallFFMPEG(args);
        }
        /// <summary>
        /// 根据视频的时长处理对应的音频，或重复播放音乐或裁减音乐
        /// </summary>
        /// <param name="musicPath"></param>
        /// <param name="length"></param>
        /// <param name="outputFile"></param>
        public void CreateMusic(string musicPath, string length, string outputFile, int counter = 0)
        {
            counter++;
            CommonFile.FileAttributes musicFileAtributes = CommonFile.GetFileAttributes(musicPath);
            if (musicFileAtributes != null && !string.IsNullOrEmpty(musicFileAtributes.Length))
            {
                DateTime dtMusic = DateTime.Parse(musicFileAtributes.Length);
                DateTime dtVideo = DateTime.Parse(length);
                if (dtMusic < dtVideo)
                {
                    string tempPath = string.Format("{0}\\tempaddmusic{1}.mp3", WorkPath, counter);
                    AddMusic(string.Format("{0}+{0}", musicPath), tempPath);
                    string lenSource = CommonFile.GetFileAttributes(musicPath).Length;
                    string lenDest = CommonFile.GetFileAttributes(tempPath).Length;
                    if (lenSource != lenDest) //相同表示转化失败
                    {
                        CreateMusic(tempPath, length, outputFile, counter);
                    }
                }
                else
                {
                    SubMusic(musicPath, length, outputFile);
                }
            }
        }
        /// <summary>
        /// 使音乐文件时长增加一倍，重复播放自身实现
        /// </summary>
        /// <param name="musicList">音乐列表，以+连接</param>
        /// <param name="outputFile">输出音乐</param>
        public void AddMusic(string musicList, string outputFile)
        {
            string args = string.Format("/c copy /b {0} {1}", musicList, outputFile);
            CallEXE(@"cmd.exe", args);
        }
        /// <summary>
        /// 合并一个目录的音乐
        /// </summary>
        /// <param name="musicPath"></param>
        /// <param name="outputMusic"></param>
        /// <returns></returns>
        public void AddDirMusic(string musicPath, string outputMusic)
        {
            string musicList = string.Empty;
            string[] fileList = Directory.GetFiles(musicPath);
            for (int i = 0; i < fileList.Length; i++)
            {
                if (fileList[i].ToLower().Contains(".mp3")) //判断是否是音乐文件
                {
                    musicList += string.Format("{0}+", fileList[i]);

                }
            }
            if (!string.IsNullOrEmpty(musicList) && musicList.Length > 0)
            {
                musicList = musicList.Substring(0, musicList.Length - 1);//去掉最后一个加号
            }
            AddMusic(musicList, outputMusic);
        }
        /// <summary>
        /// 截取mp3长度
        /// ffmpeg -ss 00:00:10 -t 00:01:22 -i 五月天-突然好想你.mp3  output.mp3 
        /// </summary>
        public void SubMusic(string musicFile, string length, string outputFile)
        {
            string args = string.Format("-ss 00:00:00 -t {0} -i {1} {2}",
                          length, musicFile, outputFile);
            CallFFMPEG(args);
        }
        /// <summary>
        /// 合并音视频，并把结果拷贝到制定的目录
        /// ffmpeg -i 2.avi -i 3.mp3 -vcodec copy -acodec copy 0.avi 
        /// </summary>
        /// <param name="audioFile">音频文件</param>
        /// <param name="videoFile">视频文件</param>
        /// <param name="ouputFile">结果文件</param>
        public void MixAudioAndVideo(string audioFile, string videoFile, string ouputFile)
        {
            string args = string.Format(" -i {0} -i {1} -vcodec copy -acodec copy -y {2} ",
                          videoFile, audioFile, ouputFile);
            CallFFMPEG(args);
        }
        /// <summary>
        /// 加入视频信息
        /// </summary>
        /// <param name="src">源</param>
        /// <param name="dest">新视频</param>
        /// <param name="mTitle">标题</param>
        public void AddVideoMetadata(string src, string dest, string mTitle)
        {
            string metadata = string.Empty;
            metadata += string.Format(" -metadata title=\"{0}\" ", "My Album"); //标题
            metadata += string.Format(" -metadata artist=\"{0}\" ", "disappearwind"); //作者
            metadata += string.Format(" -metadata year={0} ", DateTime.Now.Year); //年
            metadata += string.Format(" -metadata genre=\"{0}\" ", "Album"); //流派
            metadata += string.Format(" -metadata copyright=\"{0}\" ", "disappearwind"); //版权
            string args = string.Format("-i {0} {1} -q:v 1 -y  {2} ", src, metadata, dest);
            CallFFMPEG(args);
        }
        #endregion

        /// <summary>
        /// 调用ffmpeg
        /// </summary>
        /// <param name="args">调用参数</param>
        private void CallFFMPEG(string args)
        {
            using (Process p = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ToolPath;
                startInfo.UseShellExecute = true;
                startInfo.Arguments = args;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();
                p.Close();
            }
        }
        /// <summary>
        /// 调用EXE程序
        /// </summary>
        /// <param name="exePath">程序目录</param>
        /// <param name="args">参数</param>
        private void CallEXE(string exePath, string args)
        {
            using (Process p = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = exePath;
                startInfo.UseShellExecute = false;
                startInfo.Arguments = args;
                startInfo.CreateNoWindow = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();
                p.Close();
            }
        }
        /// <summary>
        /// 获取设置的视频分辨率,int0宽，int1高
        /// </summary>
        /// <returns></returns>
        private int[] GetResolution()
        {
            //相机尺寸
            //EOS 600D:5184*3456 1.5
            //D5100:4928*3264 1.5
            int[] result = new int[2] { 0, 0 };
            switch (cbResolution.Text)
            {
                case "iPhone5s(1.7)": //iPhone5s
                    result = new int[2] { 1136, 640 };   //1.7
                    break;
                case "1080P(1.7)": //1080P
                    result = new int[2] { 1920, 1080 }; //1.7
                    break;
                case "iPhone4(1.5)": //iPhone4
                    result = new int[2] { 960, 640 };   //1.5
                    break;
                case "Original(1.5)": //Original
                    result = new int[2] { 0, 0 };       //1.7
                    break;
                case "1024*768(1.3)": //1024*768
                    result = new int[2] { 1024, 768 };   //1.3
                    break;
                case "iPad4(1.3)": //iPad4
                    result = new int[2] { 2048, 1536 };  //1.3
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取一个目录下的所有jpg文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileList">文件列表</param>
        public void GetDirAllFile(string path, List<string> fileList)
        {
            string[] dirs = Directory.GetDirectories(path);
            if (dirs != null && dirs.Length > 0) //有子目录
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    GetDirAllFile(dirs[i], fileList);
                }
            }
            string[] files = Directory.GetFiles(path, "*.jpg");
            for (int i = 0; i < files.Length; i++)
            {
                fileList.Add(files[i]);
            }
        }

        private void chbEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnable.Checked)
            {
                txtTempPath.ReadOnly = false;
            }
            else
            {
                txtTempPath.ReadOnly = true;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                txtMessage.Text = string.Empty;
                if (!string.IsNullOrEmpty(cbFormat.Text) && !string.IsNullOrEmpty(txtSourceVideo.Text))
                {
                    System.IO.FileInfo file = new FileInfo(txtSourceVideo.Text);
                    string resultFileName = file.FullName.Replace(file.Extension, "." + cbFormat.Text);
                    string args = string.Format("-i {0} -y {1} ", txtSourceVideo.Text, resultFileName);
                    if (cbFormat.Text.ToLower().Contains("vcd"))
                    {
                        args = string.Format("-i {0} -target pal-vcd {1}", txtSourceVideo.Text, resultFileName.Replace("vcd", "mpg"));
                    }
                    CallFFMPEG(args);
                    txtMessage.Text = "转换成功！";
                }
                else
                {
                    txtMessage.Text = "请选择或者输入要转的文件和格式！";
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = string.Format("转换失败！详细信息：\r\n {0}", ex.Message);
            }
        }

        private void btnTestMusic_Click(object sender, EventArgs e)
        {
            string inputMusic = txtMusicPath.Text;
            string outputMusic = string.Format("{0}\\testMusic.mp3", AppDomain.CurrentDomain.BaseDirectory);
            string tempMusic = string.Empty;
            try
            {
                if (!System.IO.File.Exists(inputMusic) && Directory.Exists(inputMusic))
                {
                    tempMusic = string.Format("{0}\\testMusicTemp.mp3", AppDomain.CurrentDomain.BaseDirectory);
                    AddDirMusic(inputMusic, tempMusic);
                    inputMusic = tempMusic;
                }
                CreateMusic(inputMusic, "00:20:00", outputMusic);
                if (System.IO.File.Exists(outputMusic))
                {
                    CommonFile.FileAttributes outputMusicAtributes = CommonFile.GetFileAttributes(outputMusic);
                    txtMessage.Text = string.Format("音乐合成成功！音乐时长:" + outputMusicAtributes.Length);
                    System.IO.File.Delete(outputMusic);
                }
                else
                {
                    txtMessage.Text = string.Format("音乐合成失败！");
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = string.Format("音乐合成失败，异常信息：{0}", ex.Message);
            }
            finally
            {
                if (System.IO.File.Exists(tempMusic))
                {
                    System.IO.File.Delete(tempMusic);
                }
            }
        }
    }
}
