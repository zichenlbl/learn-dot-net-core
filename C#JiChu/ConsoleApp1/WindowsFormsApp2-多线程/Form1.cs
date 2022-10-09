using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_多线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread thread = null;

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个线程执行Test方法
            thread = new Thread(Test);
            thread.IsBackground = true; //设置为后台线程
            //标记线程就绪
            thread.Start();
            //Test();
        }

        private void Test()
        {
            for (int i = 0; i < 90000; i++)
            {
                //Console.WriteLine(i);
                textBox1.Text = i.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程访问
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //点击关闭窗口的时候, 判断新线程是否为null
            if (thread != null)
            {
                thread.Abort(); //终止线程
            }
        }
    }
}
