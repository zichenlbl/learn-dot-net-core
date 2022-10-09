using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// partial 部分类
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; //按钮点击时就是Button
            MessageBox.Show("Hello World!"); //弹出文本框
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 赋值ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Form1窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Class1._form1 = this; //保存Form1窗体对象
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //在内存中创建窗体2
            Form2 form2 = new Form2();
            form2.Show(); //显示
        }

        /// <summary>
        /// 当鼠标进入按钮可见部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            //给按钮一个新的坐标
            //按钮的活动坐标 宽度:窗体宽度-按钮宽度
            int x = this.ClientSize.Width; //窗体宽度
            x -= button3.Width; //按钮活动的宽度
            int y = this.ClientSize.Height;
            y -= button3.Height;

            Random r = new Random();
            button3.Location = new Point(r.Next(0, x + 1),
                r.Next(0, y + 1));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("还是被你点到了");
            Class1._form1.Close(); //关闭窗体1
        }
    }
}
