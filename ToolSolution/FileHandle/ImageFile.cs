using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ToolSolution.FileHandle
{
    /// <summary>
    /// 图片类的文件处理
    /// </summary>
    public class ImageFile
    {
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="source">源图片地址</param>
        /// <param name="dest">目标图片地址</param>
        /// <param name="width">压缩后图片的宽度，如果为0则采用原图片的宽度</param>
        /// <param name="height">压缩后图片的高度，如果为0则采用原图片高度</param>
        /// <param name="quality">压缩质量，默认100L</param>
        /// <param name="ratio">强制图片的纵横比，默认为0.如果不为0则按照高度算宽度</param>
        /// <param name="mimeType">图片类型，默认image/jpeg</param>
        public void CompressImage(string source, string dest, int width = 0, int height = 0, long quality = 100L,
           float ratio = 0, string mimeType = "image/jpeg")
        {
            Image imgSrc = Image.FromFile(source);
            if (width == 0 && height > 0)
            {
                if (ratio == 0)
                {
                    width = Convert.ToInt32(((double)height / (double)imgSrc.Height) * imgSrc.Width);
                }
                else
                {
                    width = Convert.ToInt32(ratio * height);
                }
            }
            if (height == 0 && width > 0)
            {
                height = Convert.ToInt32(((double)width / (double)imgSrc.Width) * imgSrc.Height);
            }
            if (width == 0 && height == 0)
            {
                width = imgSrc.Width;
                height = imgSrc.Height;
            }
            Image imgDest = new Bitmap(width, height);
            //先以高为基准，按比例缩放图片
            int tempWidth = Convert.ToInt32(((double)height / (double)imgSrc.Height) * imgSrc.Width); ;
            //对中间的图片按照指定的宽度生成，无图像的部分以透明色填充
            using (Graphics g = Graphics.FromImage(imgDest))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                int x = 0; //x轴坐标
                if (width > tempWidth)
                {
                    x = (width - tempWidth) / 2;
                }
                Rectangle rect = new Rectangle(x, 0, tempWidth, height); //图像真实的矩形区域
                g.DrawImage(imgSrc, rect, new Rectangle(0, 0, imgSrc.Width, imgSrc.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }

            ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().SingleOrDefault(p => p.MimeType == mimeType);
            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            imgDest.Save(dest, jpegCodec, encoderParams);
            imgDest.Dispose();
            imgSrc.Dispose();
        }
    }
}
