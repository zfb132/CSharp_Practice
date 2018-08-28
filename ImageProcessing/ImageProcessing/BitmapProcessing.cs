using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageProcessing
{
    public class BitmapProcessing
    {
        /// <summary>
        /// 指针法实现图片向左转动90度
        /// </summary>
        /// <param name="bmp">要进行转动操作的Bitmap</param>
        /// <returns></returns>
        public static Bitmap RotateLeft(Bitmap bmp)
        {
            if (bmp != null)
            {
                int width = bmp.Width;
                int height = bmp.Height;
                BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                IntPtr Scan0 = data.Scan0;
                int stride = data.Stride;
                //int length = height * 3 * width;
                //byte[] RGB = new byte[length];
                //Marshal.Copy(Scan0, RGB, 0, length);

                int rotatedheight = height;
                //保证新图像的宽度可以被4整除
                for (int i = 0; i < 4; i++)
                {
                    if ((rotatedheight % 4).Equals(0))
                        break;
                    rotatedheight++;
                }
                //新的位图文件宽为rotatedheight，高为width，每个像素点RGB值
                byte[] bmpData = new byte[width * rotatedheight * 3];
                //数组转换为Intptr  
                IntPtr pData = Marshal.AllocHGlobal(width * rotatedheight * 3);
                //指针法操作像素
                unsafe
                {
                    byte* p = (byte*)Scan0;
                    int offset = stride - width * 3;
                    long count = 0;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {

                            int x1 = y;
                            int y1 = width-1-x;
                            count = 3 * (rotatedheight * y1 + x1);
                            bmpData[count++] = p[0];
                            bmpData[count++] = p[1];
                            bmpData[count] = p[2];
                            //因为每次访问3个值
                            p += 3;
                        }
                        //无内容的值跳过
                        p += offset;
                    }
                    ////将为了凑4的倍数的列的值全部设置为RGB=(100,100,100)
                    ////设置为该行前一个点的像素
                    //for(int j=0;j<width;j++)
                    //for(int i = height; i<rotatedheight; i++)
                    //{
                    //        //bmpData[i + j * rotatedheight] = bmpData[j * rotatedheight+height - 3];
                    //        //bmpData[i + 1 + j * rotatedheight] = bmpData[j * rotatedheight+height - 2];
                    //        //bmpData[i + 2 + j * rotatedheight] = bmpData[j * rotatedheight+height - 1];
                    //        bmpData[i + j * rotatedheight] = 100;
                    //        bmpData[i + 1 + j * rotatedheight] = 100;
                    //        bmpData[i + 2 + j * rotatedheight] = 100;
                    //}
                }
                bmp.UnlockBits(data);
                Marshal.Copy(bmpData, 0, pData, width * rotatedheight * 3);
                bmp = new Bitmap(rotatedheight, width, rotatedheight*3, PixelFormat.Format24bppRgb, pData);
            }
            return bmp;
        }

        /// <summary>
        /// 指针法实现图片向右转动90度
        /// </summary>
        /// <param name="bmp">要进行转动操作的Bitmap</param>
        /// <returns></returns>
        public static Bitmap RotateRight(Bitmap bmp)
        {
            if (bmp != null)
            {
                int width = bmp.Width;
                int height = bmp.Height;
                BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                IntPtr Scan0 = data.Scan0;
                int stride = data.Stride;
                //int length = height * 3 * width;
                //byte[] RGB = new byte[length];
                //Marshal.Copy(Scan0, RGB, 0, length);

                int rotatedheight = height;
                //保证新图像的宽度可以被4整除
                for (int i = 0; i < 4; i++)
                {
                    if ((rotatedheight % 4).Equals(0))
                        break;
                    rotatedheight++;
                }
                //新的位图文件宽为rotatedheight，高为width，每个像素点RGB值
                byte[] bmpData = new byte[width * rotatedheight * 3];
                //数组转换为Intptr  
                IntPtr pData = Marshal.AllocHGlobal(width * rotatedheight * 3);
                //指针法操作像素
                unsafe
                {
                    byte* p = (byte*)Scan0;
                    int offset = stride - width * 3;
                    long count = 0;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {

                            int x1 = height-1-y;
                            int y1 = x;
                            count = 3 * (rotatedheight * y1 + x1);
                            bmpData[count++] = p[0];
                            bmpData[count++] = p[1];
                            bmpData[count] = p[2];
                            //因为每次访问3个值
                            p += 3;
                        }
                        //无内容的值跳过
                        p += offset;
                    }
                    ////将为了凑4的倍数的列的值全部设置为RGB=(100,100,100)
                    ////设置为该行前一个点的像素
                    //for(int j=0;j<width;j++)
                    //for(int i = height; i<rotatedheight; i++)
                    //{
                    //        //bmpData[i + j * rotatedheight] = bmpData[j * rotatedheight+height - 3];
                    //        //bmpData[i + 1 + j * rotatedheight] = bmpData[j * rotatedheight+height - 2];
                    //        //bmpData[i + 2 + j * rotatedheight] = bmpData[j * rotatedheight+height - 1];
                    //        bmpData[i + j * rotatedheight] = 100;
                    //        bmpData[i + 1 + j * rotatedheight] = 100;
                    //        bmpData[i + 2 + j * rotatedheight] = 100;
                    //}
                }
                bmp.UnlockBits(data);
                Marshal.Copy(bmpData, 0, pData, width * rotatedheight * 3);
                bmp = new Bitmap(rotatedheight, width, rotatedheight * 3, PixelFormat.Format24bppRgb, pData);
            }
            return bmp;
        }

        /// <summary>
        /// 提取像素法GetPixel实现上下翻转
        /// </summary>
        /// <param name="bmp">要进行翻转操作的Bitmap</param>
        /// <returns></returns>
        public static Bitmap RotateFlipUpDown(Bitmap bmp)
        {
            if (bmp != null)
            {
                int width = bmp.Width;
                int height = bmp.Height;
                //初始化一个记录经过处理后的图片对象
                Bitmap bm = new Bitmap(width, height);
                //记录像素点的x坐标的变化的
                int count;
                Color pixel;
                for (int y = 0; y <width; y++)
                {
                    count = 0;
                    for (int x = width - 1; x >= 0; x--)
                    {
                        pixel = bmp.GetPixel(y, x);//获取当前像素的值
                        bm.SetPixel(y, count++, Color.FromArgb(pixel.R, pixel.G, pixel.B));
                    }
                }
                return bm;
            }
            return bmp;
        }

        /// <summary>
        /// 提取像素法GetPixel实现左右翻转
        /// </summary>
        /// <param name="bmp">要进行翻转操作的Bitmap</param>
        /// <returns></returns>
        public static Bitmap RotateFlipRL(Bitmap bmp)
        {
            if (bmp != null)
            {
                int width = bmp.Width;
                int height = bmp.Height;
                //初始化一个记录经过处理后的图片对象
                Bitmap bm = new Bitmap(width, height);
                //记录像素点的x坐标的变化的
                int count;
                Color pixel;
                for (int y = height - 1; y >= 0; y--)
                {
                    count = 0;
                    for (int x = width - 1; x >= 0; x--)
                    {
                        pixel = bmp.GetPixel(x, y);//获取当前像素的值
                        bm.SetPixel(count++, y, Color.FromArgb(pixel.R, pixel.G, pixel.B));
                    }
                }
                return bm;
            }
            return bmp;
        }

        /// <summary>
        /// 指针法实现灰度化
        /// </summary>
        /// <param name="bmp">要进行灰度化的Bitmap</param>
        /// <returns></returns>
        public static Bitmap RGB2Gray(Bitmap bmp)
        {
            if (bmp != null)
            {
                int width = bmp.Width;
                int height = bmp.Height;
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                IntPtr scan0 = bmpData.Scan0;
                //stride一定为4的倍数，但实际图片像素宽度不一定是stride
                int stride = bmpData.Stride;
                unsafe
                {
                    byte* p = (byte*)scan0;
                    //不访问无用像素点
                    int offset = stride - width * 3;
                    double gray = 0;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            gray = 0.3 * p[2] + 0.59 * p[1] + 0.11 * p[0];
                            p[2] = p[1] = p[0] = (byte)gray;
                            p += 3;
                        }
                        p += offset;
                    }
                }
                bmp.UnlockBits(bmpData);
            }
            return bmp;
        }

        /// <summary>
        /// 内存法实现对图片转动180度
        /// </summary>
        /// <param name="bmp">要进行转动操作的Bitmap</param>
        /// <returns></returns>
        public static Bitmap RotateLeft180(Bitmap bmp)
        {
            if (bmp != null)
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int length = height * 3 * width;
                byte[] RGB = new byte[length];
                BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                IntPtr Scan0 = data.Scan0;
                Marshal.Copy(Scan0, RGB, 0, length);
                for (int i = 0; i < RGB.Length / 2; i = i + 3)
                {
                    //RGB.Length-1位最后一个像素的索引
                    byte temp = new byte();
                    //交换像素点的第一个分量的值
                    temp = RGB[i];
                    RGB[i] = RGB[RGB.Length - i - 3];
                    RGB[RGB.Length - i - 3] = temp;
                    //交换像素点的第二个分量的值
                    temp = RGB[i + 1];
                    RGB[i + 1] = RGB[RGB.Length - i - 2];
                    RGB[RGB.Length - i - 2] = temp;
                    //交换像素点的第三个分量的值
                    temp = RGB[i + 2];
                    RGB[i + 2] = RGB[RGB.Length - 1 - i];
                    RGB[RGB.Length - i - 1] = temp;
                }
                Marshal.Copy(RGB, 0, Scan0, length);
                bmp.UnlockBits(data);
            }
            return bmp;
        }
    }
}
