using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_PictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;
        //获取指定文件夹的所有文件的全路径
        string[] paths = Directory.GetFiles(@"H:\A\picture\");

        /// <summary>
        /// 下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //如何显示图像  拉伸或收缩图片
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            i++;
            if (i > paths.Length - 1)
            {
                i = 0;
            }
            pictureBox1.Image = Image.FromFile(paths[i]);
            label1.Text = (i + 1) + "/" + paths.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"H:\A\picture\20191114_IMG_0985.JPG");
            label1.Text = (i + 1)  + "/" + paths.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //如何显示图像  拉伸或收缩图片
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            i--;
            if (i < 0)
            {
                i = paths.Length - 1;
            }
            pictureBox1.Image = Image.FromFile(paths[i]);
            label1.Text = (i + 1) + "/" + paths.Length;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
