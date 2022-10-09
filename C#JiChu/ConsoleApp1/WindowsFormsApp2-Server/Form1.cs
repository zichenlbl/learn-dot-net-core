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

        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //创建负责监听的Socket Dgram(UDP)
                Socket socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp); //ipv4地址, tcp(Stream), 协议
                                                          //创建IP地址和端口号 可以改变
                IPAddress iPAddress = IPAddress.Any; //IPAddress.Parse(textBox1.Text);
                IPEndPoint iPEndPoint = new IPEndPoint(iPAddress,
                    Convert.ToInt32(textBox2.Text)); //ip, 端口号
                //让Socket绑定iP和端口
                socket.Bind(iPEndPoint);

                ShowMsg("监听成功");

                //设置监听队列 在某一个时间点能连入的客户端数量
                socket.Listen(2);

                //多线程监听客户端连接
                Thread thread = new Thread(Listen);
                thread.IsBackground = true; //后台线程
                thread.Start(socket);
            }
            catch (Exception)
            {
            }
        }

        private void ShowMsg(string str)
        {
            //追加文本
            textBox3.AppendText(str + "\r\n");
        }

        Socket socket1 = null; //负责通信的Socket
        //将每个连接的客户端ip地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
        /// <summary>
        /// 等待客户端的连接 并且创建一个负责通信的Socket
        /// </summary>
        /// <param name="socket"></param>
        private void Listen(Object o)
        {
            Socket socket = o as Socket;
            ////等待接受客户端的连接 并且创建一个负责通信的Socket
            while (true)
            {
                try
                {
                    //负责跟客户端通信的socket
                    socket1 = socket.Accept(); //一直等待一个连接
                    dicSocket.Add(socket1.RemoteEndPoint.ToString(),
                        socket1); //保存连接的客户端
                    //客户端ip存到下拉框
                    comboBox1.Items.Add(socket1.RemoteEndPoint.ToString());
                    //cmd连接命令 telnet 192.168.62.193 5000 
                    ShowMsg(socket1.RemoteEndPoint.ToString() + "连接成功");
                    //一直接收客户端发送的消息
                    Thread thread = new Thread(Recive);
                    thread.IsBackground = true;
                    thread.Start(socket1);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 接收客户端发送信息
        /// </summary>
        private void Recive(object o)
        {
            Socket socket = o as Socket;
            while (true)
            {
                try
                {
                    //接收客户端发送的消息
                    byte[] buffer = new byte[1024 * 1024 * 1]; //1MB
                    int r = socket.Receive(buffer); //实际接收的长度
                    if (r < 1)
                    {
                        break;
                    }
                    string str = Encoding.Default.GetString(buffer, 0, r);
                    ShowMsg(socket.RemoteEndPoint + ":" + str);
                }
                catch (Exception)
                {
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowMsg("测试信息");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消线程安全问题 从不是创建控件xx的线程访问它
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text.Trim();
            byte[] buffer = Encoding.Default.GetBytes(str);
            //自定义第一位标记发送的消息类型 0 1 2 
            List<byte> list = new List<byte>();
            list.Add(0); //文本消息
            list.AddRange(buffer);
            byte[] newBuffer = list.ToArray();
            //获取要发送给哪个客户端
            string ip = comboBox1.SelectedItem.ToString();
            Socket socket = dicSocket[ip];
            socket.Send(newBuffer);

            ShowMsg("我:" + str);
            textBox4.Text = "";
        }

        /// <summary>
        /// 选择要发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"H:\A";
            openFileDialog.Title = "请选择要发送的文件";
            openFileDialog.Filter = "所有文件|*.*";
            openFileDialog.ShowDialog(); //运行

            textBox5.Text = openFileDialog.FileName.ToString();
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string path = textBox5.Text;
            using (FileStream fileStream = 
                new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fileStream.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1); //标记1为文件
                list.AddRange(buffer);
                byte[] newBuffer = list.ToArray();
                dicSocket[comboBox1.SelectedItem.ToString()]
                    .Send(newBuffer, 0, r + 1, SocketFlags.None);
            }
        }

        /// <summary>
        /// 发送震动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 2; //震动
            dicSocket[comboBox1.SelectedItem.ToString()]
                .Send(buffer);
        }
    }
}
