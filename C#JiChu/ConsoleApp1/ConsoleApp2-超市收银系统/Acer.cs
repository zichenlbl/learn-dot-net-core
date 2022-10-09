using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 商品: 宏基
    /// </summary>
    class Acer : ProductFather
    {
        public Acer(string id, double price, string name)
            : base(id, price, name)
        {

        }
    }
}
