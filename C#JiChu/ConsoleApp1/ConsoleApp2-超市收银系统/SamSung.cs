using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 商品: 三星
    /// </summary>
    class SamSung : ProductFather
    {
        public SamSung(string id, double price, string name)
            : base(id, price, name)
        {

        }
    }
}
