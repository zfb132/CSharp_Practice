using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        private Bitmap bmp = null;
        private Bitmap currentbmp = null;
        private string fileName = "";
        public ImageProcessing()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MenuClick.getBitmapDirectory());
            fileName = MenuClick.getBitmapDirectory();
            try
            {
                Image image = Image.FromFile(fileName);
                //将文件保存到内存流中，防止对原文件的占用
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Bmp);
                //释放文件
                image.Dispose();
                //从内存流创建bmp
                bmp = new Bitmap(ms);
                currentbmp = bmp;
                pictureBox1.Image = (Image)bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentbmp = BitmapProcessing.RGB2Gray(currentbmp);
            Image img = currentbmp;
            pictureBox1.Image = img;
        }

        private void Left90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentbmp = BitmapProcessing.RotateLeft(currentbmp);
            Image img = currentbmp;
            pictureBox1.Image = img;
        }

        private void Right90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentbmp = BitmapProcessing.RotateRight(currentbmp);
            Image img = currentbmp;
            pictureBox1.Image = img;
        }

        private void UpDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentbmp = BitmapProcessing.RotateFlipUpDown(currentbmp);
            Image img = currentbmp;
            pictureBox1.Image = img;
        }

        private void LeftRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentbmp = BitmapProcessing.RotateFlipRL(currentbmp);
            Image img = currentbmp;
            pictureBox1.Image = img;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentbmp == null)
            {
                return;
            }
            try
            {
                currentbmp.Save(fileName, pictureBox1.Image.RawFormat);
                MessageBox.Show("保存文件成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentbmp == null)
            {
                return;
            }
            try
            {
                MenuClick.saveAsBitmap(currentbmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
