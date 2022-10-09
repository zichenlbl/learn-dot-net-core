using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Socket socket = null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //创建负责通信的Socket
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                //建立与远程主机的连接
                IPAddress iPAddress = IPAddress.Parse(textBox1.Text);
                IPEndPoint iPEndPoint = new IPEndPoint(iPAddress,
                    Convert.ToInt32(textBox2.Text));
                //获得要连接的远程服务器应用程序的ip地址和端口号
                socket.Connect(iPEndPoint);
                ShowMsg("连接成功");

                //接收服务器段的消息
                Thread thread = new Thread(Recive);
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            { 
            }
        }

        private void ShowMsg(string str)
        {
            textBox3.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 接收服务器端的消息
        /// </summary>
        private void Recive()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    int r = socket.Receive(buffer);
                    if (r < 1)
                    {
                        break;
                    }
                    switch (buffer[0])
                    {
                        case 0:
                            string str = Encoding.Default.GetString(buffer, 1, r - 1);
                            ShowMsg(socket.RemoteEndPoint + ":" + str);
                            break;
                        case 1:
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.InitialDirectory = @"H:\A";
                            saveFileDialog.Title = "请选择要保存的文件";
                            saveFileDialog.Filter = "所有文件|*.*";
                            saveFileDialog.ShowDialog(this);

                            string path = saveFileDialog.FileName;
                            using (FileStream fileStream = 
                                new FileStream(path, FileMode.OpenOrCreate,
                                FileAccess.Write))
                            {
                                fileStream.Write(buffer, 1, r - 1);
                            }
                            MessageBox.Show("保存成功");
                            break;
                        case 2:
                            Shake();
                            break;
                        default:
                            break;
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 震动
        /// </summary>
        private void Shake()
        {
            for (int i = 0; i < 500; i++)
            {
                this.Location = new Point(200, 200);
                this.Location = new Point(230, 230);
            }
        }

        /// <summary>
        /// 客户端给服务器发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text.Trim();
            byte[] buffer = Encoding.Default.GetBytes(str);
            socket.Send(buffer);

            ShowMsg("我:" + str);
            textBox4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
