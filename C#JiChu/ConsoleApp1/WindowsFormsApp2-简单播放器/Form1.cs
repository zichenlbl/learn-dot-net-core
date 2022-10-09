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

namespace WindowsFormsApp2_简单播放器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消播放器的自动播放
            axWindowsMediaPlayer1.settings.autoStart = false;
            axWindowsMediaPlayer1.URL = @"E:\我的备份\202209090200PM备份\c盘2022-09-09\音乐\中文歌\我还想她 - (《爱情睡醒了》电视剧插曲) - 林俊杰 (JJ Lin).mp3";
        }

        /// <summary>
        /// 播放/暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "播放")
            {
                axWindowsMediaPlayer1.Ctlcontrols.play(); //播放
                button4.Text = "暂停";
            }
            else if (button4.Text == "暂停")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause(); //暂停
                button4.Text = "播放";
            }
        }

        List<string> listPath = new List<string>(); //存音乐的路径

        /// <summary>
        /// 打开对话框 选择音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"H:\音乐\音乐";
            openFileDialog.Filter = "MP3音乐|*.mp3|音乐文件|*.wav|所有文件|*.*";
            openFileDialog.Title = "请选择音乐文件";
            openFileDialog.Multiselect = true; //多选
            openFileDialog.ShowDialog();

            //获取选择的音乐路径
            string[] path = openFileDialog.FileNames;
            for (int i = 0; i < path.Length; i++)
            {
                listPath.Add(path[i]); //存音乐的路径

                //把文件名添加到ListBox组件中
                listBox1.Items.Add(Path.GetFileName(path[i]));
            }
        }

        /// <summary>
        /// 双击播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count < 1)
                {
                    MessageBox.Show("请先选择音乐文件");
                    return;
                }
                axWindowsMediaPlayer1.URL = listPath[listBox1.SelectedIndex];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                button4.Text = "暂停";
            }
            catch
            { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            index++;
            if (index == listBox1.Items.Count)
            {
                index = 0;
            }
            listBox1.SelectedIndices.Clear(); //移除选中
            listBox1.SelectedIndex = index;
            axWindowsMediaPlayer1.URL = listPath[index];
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
