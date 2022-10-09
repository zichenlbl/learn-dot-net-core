using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 商品: 香蕉
    /// </summary>
    class Banner : ProductFather
    {
        public Banner(string id, double price, string name)
            : base(id, price, name)
        {

        }
    }
}
