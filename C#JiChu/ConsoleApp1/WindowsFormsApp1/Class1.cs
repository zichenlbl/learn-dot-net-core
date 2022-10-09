using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// 静态类最大的特点就是共享
    /// </summary>
    public static class Class1
    {
        public static Form1 _form1 { get; set; }
    }
}
