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

namespace WindowsFormsApp2_摇奖机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool flag = false;

        private void button1_Click(object sender, EventArgs e)
        {
            flag = !flag;
            if (flag)
            {
                button1.Text = "停止";
            }
            else
            {
                button1.Text = "摇奖";
            }
            Thread thread = new Thread(PlayGame);
            thread.IsBackground = true; //后台线程
            thread.Start("str"); //str 传给方法的参数 str
            //PlayGame();
        }

        private void PlayGame(object str)
        {
            Random random = new Random();
            while (flag)
            {
                label1.Text = random.Next(0, 10).ToString();
                label2.Text = random.Next(0, 10).ToString();
                label3.Text = random.Next(0, 10).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程访问
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
