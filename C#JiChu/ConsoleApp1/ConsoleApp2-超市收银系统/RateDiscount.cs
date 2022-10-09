using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 按折扣率打折
    /// </summary>
    class RateDiscount : Discount
    {
        /// <summary>
        /// 折扣率 .05
        /// </summary>
        public double Rate { get; set; }

        public RateDiscount(double rate)
        {
            this.Rate = rate;
        }

        public override double GetTotalMoney(double realMoney)
        {
            return realMoney * this.Rate; 
        }
    }
}
