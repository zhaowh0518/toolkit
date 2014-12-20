using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using ToolSolution.AppHandle;
using ToolSolution.FileHandle;
using ToolSolution.Tools.Video;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.TestFile();
        }
        /// <summary>
        /// 测试微博
        /// </summary>
        public void TestWeibo()
        {
            SinaWeibo weibo = new SinaWeibo();
            string path = "E:\\t";
            List<string> messageList = new List<string>();
            Console.WriteLine("======开始读取==========");
            messageList = weibo.GetMessageList(path);
            if (messageList != null && messageList.Count > 0)
            {
                Console.WriteLine("Message Count = " + messageList.Count);
            }
            Console.WriteLine("======结束读取==========");
            Console.WriteLine("======开始写文件==========");
            string fileName = "E:\\weibo.txt";
            weibo.OutputMessage(messageList, fileName);
            Console.WriteLine("======写文件成功==========");
            Console.ReadKey();
        }
        public void TestVideo()
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    File.Copy(@"E:\Test\Green\001.jpg",string.Format(@"E:\Test\Green\list\{0}.jpg",i));
            //    File.Copy(@"E:\Test\Green\002.jpg", string.Format(@"E:\Test\Green\list\{0}.jpg", i+1));
            //    i++;
            //}
            string[] filelist = Directory.GetFiles(@"E:\Test\Green\list2");
            string desDir = @"E:\Test\Green\list3";
            string[] clsFileList = Directory.GetFiles(desDir);

            for (int i = 0; i < clsFileList.Length; i++)
            {
                if (!clsFileList[i].Contains("exe"))
                {
                    File.Delete(clsFileList[i]);
                }
            }
            ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().SingleOrDefault(p => p.MimeType == "image/jpeg");
            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 40L);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            Image img;
            int counter = 0;
            for (int i = 0; i < filelist.Length; i++)
            {
                img = Image.FromFile(filelist[i]);
                img.Save(string.Format(@"E:\Test\Green\list3\{0}.jpg", counter), jpegCodec, encoderParams);
                for (int j = 0; j < 8 * 10; j++)
                {
                    File.Copy(filelist[i], string.Format(@"E:\Test\Green\list3\{0}.jpg", ++counter));
                    Console.WriteLine(string.Format("第{0}张", counter));
                }
            }
            Console.ReadKey();
        }
        public void TestMusic()
        {
            string fileName = @"E:\Test\1.mp3";
            //CommonFile.FileAttributes result = CommonFile.GetFileAttributes(fileName);
            //Console.WriteLine(result.Length);
            ImageToVideoForm f = new ImageToVideoForm();
            //f.CreateMusic(fileName, "00:30:00", @"E:\Test\10.mp3");
            //f.AddMusic(fileName, @"E:\Test\10.mp3");
            //f.SubMusic(fileName, "00:00:10", @"E:\Test\2.mp3");
            //f.AddDirMusic(@"E:\Test");
            Console.WriteLine("调用完毕");
            Console.ReadKey();
        }
        public void TestFile()
        {
            string fileName = @"2<sss.mp3";
            //ImageToVideoForm f = new ImageToVideoForm();
            //string length = f.GetFileLength(fileName);
            //Console.WriteLine("Length=" + length);
            Console.WriteLine(CommonFile.RemoveInvalidChar(fileName));
            Console.ReadKey();
        }
        public void TestImage()
        {
            string strSrc = @"E:\Test\Files\1.JPG";
            string strDest = @"E:\Test\Files\3.JPG";
            ImageFile imgFile = new ImageFile();
            imgFile.CompressImage(strSrc, strDest, 720, 480);
        }
        public void TestDir()
        {
            string dir = @"E:\Test\Files\list4";
            List<string> fileList = new List<string>();
            ImageToVideoForm f = new ImageToVideoForm();
            f.GetDirAllFile(dir, fileList);
            fileList.Sort(new Comparison<string>(delegate(string a, string b)
            {
                return System.IO.File.GetLastWriteTime(a).CompareTo(System.IO.File.GetLastWriteTime(b));

            }));
            for (int i = 0; i < fileList.Count; i++)
            {
                Console.WriteLine(fileList[i]);
            }
            Console.ReadKey();
        }
        public void TestVideoMetadata()
        {
            string inputFile = @"D:\Project\DevByMyself\ToolSolution\Tools\bin\Debug\Temp\temp2.avi";
            string outputFile = @"D:\Project\DevByMyself\ToolSolution\Tools\bin\Debug\Temp\temp3.avi";
            string title = "测试";
            title = System.Text.UTF8Encoding.UTF8.GetString(System.Text.UTF8Encoding.UTF8.GetBytes(title));
            ImageToVideoForm f = new ImageToVideoForm();
            f.AddVideoMetadata(inputFile, outputFile, title);
        }
    }
}
