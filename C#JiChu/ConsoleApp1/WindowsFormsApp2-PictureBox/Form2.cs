using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_PictureBox
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 在窗体加载的时候 给每个图片组件放一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            //播放音乐
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"H:\A\胡歌  忘记时间.wav";
            soundPlayer.Play();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"H:\A\picture\20191114_IMG_0985.JPG");
            pictureBox2.Image = Image.FromFile(@"H:\A\picture\20191114_IMG_0985.JPG");
            pictureBox3.Image = Image.FromFile(@"H:\A\picture\20191114_IMG_0985.JPG");
            pictureBox4.Image = Image.FromFile(@"H:\A\picture\20191114_IMG_0985.JPG");
            pictureBox5.Image = Image.FromFile(@"H:\A\picture\20191114_IMG_0985.JPG");
            pictureBox6.Image = Image.FromFile(@"H:\A\picture\20191114_IMG_0985.JPG");
        }

        int i = 0;
        string[] paths = Directory.GetFiles(@"H:\A\picture\");
        Random random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            //每隔2秒换一组图片
            i++;
            if (i > paths.Length - 1)
            {
                i = 0;
            }
            pictureBox1.Image = Image.FromFile(paths[i]);
            //随机照片
            pictureBox2.Image = Image.FromFile(paths[random.Next(0, paths.Length)]);
            pictureBox3.Image = Image.FromFile(paths[random.Next(0, paths.Length)]);
            pictureBox4.Image = Image.FromFile(paths[random.Next(0, paths.Length)]);
            pictureBox5.Image = Image.FromFile(paths[random.Next(0, paths.Length)]);
            pictureBox6.Image = Image.FromFile(paths[random.Next(0, paths.Length)]);
        }
    }
}
