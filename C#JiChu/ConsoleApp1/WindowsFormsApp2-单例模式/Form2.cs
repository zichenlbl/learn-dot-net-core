using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_单例模式
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// 静态 全局唯一的单例
        /// </summary>
        public static Form2 form2Single = null;

        private Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取一个单例的Form2对象
        /// </summary>
        /// <returns></returns>
        public static Form2 GetSingle()
        {
            if (form2Single == null)
            {
                form2Single = new Form2();
            }
            return form2Single;
        }
    }
}
