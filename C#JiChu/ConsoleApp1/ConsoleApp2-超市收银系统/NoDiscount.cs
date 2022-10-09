using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 不打折的方式
    /// </summary>
    class NoDiscount : Discount
    {
        public override double GetTotalMoney(double realMoney)
        {
            return realMoney;
        }
    }
}
