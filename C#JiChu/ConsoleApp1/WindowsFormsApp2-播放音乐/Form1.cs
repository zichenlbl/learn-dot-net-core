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

namespace WindowsFormsApp2_播放音乐
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 存储音乐文件的全路径
        /// </summary>
        List<string> listSongs = new List<string>(); 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //打开文件对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择音乐文件";
            openFileDialog.InitialDirectory = @"H:\A"; //初始目录
            openFileDialog.Multiselect = true; //多选
            openFileDialog.Filter = "音乐文件|*.wav|所有文件|*.*|音乐|*.mp3"; //可用文件筛选
            openFileDialog.ShowDialog();

            //获取在文件夹中选择所有文件的全路径
            string[] paths = openFileDialog.FileNames;
            for (int i = 0; i < paths.Length; i++)
            {
                listBox1.Items.Add(Path.GetFileName(paths[i]));
                listSongs.Add(paths[i]); //存储音乐路径
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        SoundPlayer soundPlayer = new SoundPlayer();
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //双击音乐名 播放
            
            //列表选中的索引
            soundPlayer.SoundLocation = listSongs[listBox1.SelectedIndex];
            soundPlayer.Play();

        }

        /// <summary>
        /// 下一曲 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //获取当前选中歌曲的索引
            int index = listBox1.SelectedIndex;
            index++;
            if (index > listBox1.Items.Count - 1)
            {
                index = 0;
            }
            listBox1.SelectedIndex = index; //列表选中项改变
            soundPlayer.SoundLocation = listSongs[index];
            soundPlayer.Play();
        }

        /// <summary>
        /// 上一曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //获取当前选中歌曲的索引
            int index = listBox1.SelectedIndex;
            index--;
            if (index < 0)
            {
                index = listBox1.Items.Count - 1;
            }
            listBox1.SelectedIndex = index; //列表选中项改变
            soundPlayer.SoundLocation = listSongs[index];
            soundPlayer.Play();
        }
    }
}
