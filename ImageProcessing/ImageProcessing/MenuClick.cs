using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class MenuClick
    {
        public static string getBitmapDirectory()
        {
            //创建用于打开文件的对话框
            OpenFileDialog addFileDialog = new OpenFileDialog();
            addFileDialog.Filter = "位图|*.png;*.bmp;*.dib|图片文件|*.jpg;*.JPG;*.jpeg;*.ico";
            string fileDirectory = "";
            //判断打开文件窗口是否打开
            if (addFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (addFileDialog.FileName != null)
                {
                    //得到文件路径
                    fileDirectory = addFileDialog.FileName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
            return fileDirectory;
        }

        public static void saveAsBitmap(Bitmap bmp)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "另存为";
            saveDlg.OverwritePrompt = true;
            saveDlg.Filter =
                "PNG文件 (*.png) | *.png" +
                "JPEG文件 (*.jpg) | *.jpg|" +
                "Gif文件 (*.gif) | *.gif|"+
                "BMP文件 (*.bmp) | *.bmp|";
            saveDlg.DefaultExt = ".png";
            saveDlg.ShowHelp = true;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDlg.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
