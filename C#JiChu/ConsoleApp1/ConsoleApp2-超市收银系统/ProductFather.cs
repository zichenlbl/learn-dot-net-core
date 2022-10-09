using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 商品父类
    /// </summary>
    class ProductFather
    {
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        public ProductFather(string id, double price, string name)
        {
            this.Price = price;
            this.Name = name;
            this.ID = id;
        }
    }
}
