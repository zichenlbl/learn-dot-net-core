using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp2_委托.Form1;

namespace WindowsFormsApp2_委托
{
    //声明一个委托
    public delegate void MyDelegate(string str);

    public partial class Form2 : Form
    {
        //事件
        public event MyDelegate _myDelegate;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(MyDelegate myDelegate)
        {
            this._myDelegate = myDelegate;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (string.IsNullOrEmpty(str))
            {
                _myDelegate(DateTime.Now.ToString());
            }
            else
            {
                _myDelegate(textBox1.Text);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
