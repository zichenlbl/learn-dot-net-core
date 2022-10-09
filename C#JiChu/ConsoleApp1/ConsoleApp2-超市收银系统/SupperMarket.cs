using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 超市
    /// </summary>
    class SupperMarket
    {
        //Acre SamSung Banana
        Warehouse warehouse = new Warehouse(); //仓库

        /// <summary>
        /// 创建超市
        /// </summary>
        public SupperMarket()
        {
            warehouse.Purchase("Acre", 200);
            warehouse.Purchase("SamSung", 300);
            warehouse.Purchase("Banana", 100);
        }

        /// <summary>
        /// 用户交互 欢迎光临
        /// </summary>
        public void Welcome()
        {
            Console.WriteLine("欢迎光临,请问您需要什么?");
            Console.WriteLine("我们有 Acer、SamSung、Banner 商品");
            string strType = Console.ReadLine();
            Console.WriteLine("您需要多少?");
            int count = Convert.ToInt32(Console.ReadLine());

            //取货
            ProductFather[] productFathers 
                = warehouse.Shipment(strType, count);
            //计算价格
            double realMoney = GetMoney(productFathers);
            Console.WriteLine("您总共应支付{0}元!", realMoney);
            Console.WriteLine("选择您的打折方式:1-不打折,2-打九折,3-满5000减1000");
            string input = Console.ReadLine();
            Discount discount = GetDiscount(input);
            realMoney = discount.GetTotalMoney(realMoney);
            Console.WriteLine("打完折后您应付{0}元", realMoney);
            Console.WriteLine("以下是您的购物信息");
            foreach (var item in productFathers)
            {
                Console.WriteLine("商品名称:{0},价格:{1},商品编号:{2}",
                    item.Name, item.Price, item.ID);
            }
        }

        /// <summary>
        /// 计算货物价钱
        /// </summary>
        /// <param name="productFathers"></param>
        /// <returns></returns>
        public double GetMoney(ProductFather[] productFathers)
        {
            double realMoney = 0;
            for (int i = 0; i < productFathers.Length; i++)
            {
                realMoney += productFathers[i].Price;
            }
            return realMoney;
        }

        /// <summary>
        /// 根据用户的选择返回对应的打折对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Discount GetDiscount(string input)
        {
            Discount discount = null;
            switch (input)
            {
                case "1":
                    discount = new NoDiscount();
                    break;
                case "2":
                    discount = new RateDiscount(.9);
                    break;
                case "3":
                    discount = new MNDiscount(5000, 1000);
                    break;
                default:
                    break;
            }
            return discount;
        }

        /// <summary>
        /// 超市展示货物
        /// </summary>
        public void ShowPros()
        {
            warehouse.ShowPros();
        }

    }
}
