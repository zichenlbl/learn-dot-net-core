using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 满减 满M元减N元
    /// </summary>
    class MNDiscount : Discount
    {
        public double M { get; set; }
        public double N { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">满</param>
        /// <param name="n">减</param>
        public MNDiscount(double m, double n)
        {
            this.M = m;
            this.N = n;
        }

        public override double GetTotalMoney(double realMoney)
        {
            //每满500减100元 
            return realMoney >= this.M 
                ? realMoney - (int)(realMoney / this.M) * this.N 
                : realMoney;
        }
    }
}
