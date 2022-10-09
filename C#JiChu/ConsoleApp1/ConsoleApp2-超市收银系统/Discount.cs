using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 打折 抽象类
    /// </summary>
    abstract class Discount
    {
        /// <summary>
        /// 打折后的价钱
        /// </summary>
        /// <param name="realMoney">原价</param>
        /// <returns></returns>
        public abstract double GetTotalMoney(double realMoney);
    }
}
