using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_GDI画直线
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建GDI对象
            Graphics graphics = this.CreateGraphics();
            //创建画笔
            Pen pen = new Pen(Brushes.Black); //黑色
            //创建两个点
            Point point = new Point(30, 40);
            Point point1 = new Point(300, 300);

            graphics.DrawLine(pen, point, point1);
        }

        int i = 0;

        /// <summary>
        /// 控件需要重新绘制时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            i++;
            label1.Text = i + "";
            //创建GDI对象
            Graphics graphics = this.CreateGraphics();
            //创建画笔
            Pen pen = new Pen(Brushes.Black); //黑色
            //创建两个点
            Point point = new Point(30, 40);
            Point point1 = new Point(300, 300);

            graphics.DrawLine(pen, point, point1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();

            Pen pen = new Pen(Brushes.Blue);

            Size size = new Size(80, 190);
            Rectangle rectangle = new Rectangle(new Point(50, 50), size);
            graphics.DrawRectangle(pen, rectangle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();

            Pen pen = new Pen(Brushes.Green);

            Size size = new Size(80, 80);
            Rectangle rectangle = new Rectangle(new Point(80, 80), size);

            graphics.DrawPie(pen, rectangle, 45, 30);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.DrawString("你好",
               new Font("楷体", 20, FontStyle.Underline),
               Brushes.Red,
               new Point(200, 200)
            ); //画字
        }
    }
}
