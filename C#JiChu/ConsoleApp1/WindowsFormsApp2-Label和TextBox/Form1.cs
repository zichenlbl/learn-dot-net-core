using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_Label和TextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文本框中的内容发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 定时器 每当经过指定时间间隔时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("你中病毒了,关不掉了");

            //跑马灯
            //⭐ ✨ 🌰🌼💛💙🧡🖤★☆
            //★☆★☆★☆★☆★☆★☆★☆★☆
            string str = label2.Text.Substring(1) + 
                label2.Text.Substring(0, 1); //12345 => 23451
            label2.Text = str;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 每隔一秒种把时间赋值给label3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();

            if (DateTime.Now.Hour == 13 &&
                DateTime.Now.Minute == 15 &&
                DateTime.Now.Second == 35)
            {
                //播放音乐 格式:wav
                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.SoundLocation = @"E:\胡歌  忘记时间.wav";
                
                soundPlayer.Play();
            }
        }

        /// <summary>
        /// Form1加载时的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }
    }
}
