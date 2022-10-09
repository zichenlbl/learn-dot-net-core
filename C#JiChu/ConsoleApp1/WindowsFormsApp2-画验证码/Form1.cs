using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_画验证码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Painting();
        }

        private void Painting()
        {
            Random random = new Random();
            string str = "";
            for (int i = 0; i < 4; i++)
            {
                str += random.Next(0, 10);
            }

            //创建一个图片对象
            Bitmap bitmap = new Bitmap(120, 30);
            //创建GDI对象
            Graphics graphics = Graphics.FromImage(bitmap);

            string[] fonts = { "黑体", "楷体", "微软雅黑", "宋体", "隶书" };
            Color[] colors = { Color.Red, Color.Fuchsia, Color.Blue, Color.Black, Color.Green };
            for (int i = 0; i < 4; i++)
            {
                //往图片上画数字
                Point point = new Point(i * 20 + 10, 0); //每个数字的间隔
                graphics.DrawString(str[i].ToString(),
                    new Font(fonts[random.Next(0, 4)],
                        20, FontStyle.Bold | FontStyle.Italic
                    ),
                    new SolidBrush(colors[random.Next(0, 4)]), point
                );
            }

            //画直线
            for (int i = 0; i < 20; i++)
            {
                Point point = new Point(random.Next(0, bitmap.Width),
                    random.Next(0, bitmap.Height));
                Point point1 = new Point(random.Next(0, bitmap.Width),
                    random.Next(0, bitmap.Height));
                graphics.DrawLine(new Pen(colors[random.Next(0, 5)]), point, point1);
            }

            //画噪点
            for (int i = 0; i < 30; i++)
            {
                Point point = new Point(random.Next(0, bitmap.Width),
                    random.Next(0, bitmap.Height));
                bitmap.SetPixel(point.X, point.Y, colors[random.Next(0, 5)]); //设置指定像素的颜色
            }

            //把画好的图片放到图片组件
            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Painting();
        }
    }
}
