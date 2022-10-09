using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_超市收银系统
{
    /// <summary>
    /// 仓库
    /// </summary>
    class Warehouse
    {
        /// <summary>
        /// 商品集合 list[0]:宏基 1:三星 2:香蕉
        /// List<ProductFather>: 每种商品的货架
        /// </summary>
        List<List<ProductFather>> productFatherslist
            = new List<List<ProductFather>>();

        /// <summary>
        /// 初始化货架
        /// </summary>
        public Warehouse()
        {
            productFatherslist.Add(new List<ProductFather>()); //宏基
            productFatherslist.Add(new List<ProductFather>()); //三星
            productFatherslist.Add(new List<ProductFather>()); //香蕉
        }

        /// <summary>
        /// 进货 往仓库中进货
        /// </summary>
        /// <param name="strType">商品的类型</param>
        /// <param name="count">数量</param>
        public void Purchase(string strType, int count)
        {
            object p = Guid.NewGuid().ToString();
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Acre":
                        productFatherslist[0].Add(
                            new Acer(
                                Guid.NewGuid().ToString(),
                                1000,
                                "宏基笔记本"
                            )
                        );
                        break;
                    case "SamSung":
                        productFatherslist[1].Add(
                            new SamSung(
                                Guid.NewGuid().ToString(),
                                2000,
                                "三星笔记本"
                            )
                        );
                        break;
                    case "Banana":
                        productFatherslist[2].Add(
                            new Banner(
                                Guid.NewGuid().ToString(),
                                2,
                                "香蕉"
                            )
                        );
                        break;
                }
            }
        }

        /// <summary>
        /// 出货 从仓库中取货
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="count"></param>
        public ProductFather[] Shipment(string strType, int count)
        {
            ProductFather[] productFathers = new ProductFather[count];
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Acer":
                        if (productFatherslist[0].Count > 0)
                        {
                            productFathers[i] = productFatherslist[0][0];
                            productFatherslist[0].RemoveAt(0); //移除0下标的元素
                        }
                        break;
                    case "SamSung":
                        if (productFatherslist[1].Count > 0)
                        {
                            productFathers[i] = productFatherslist[1][0];
                            productFatherslist[1].RemoveAt(0);
                        }
                        break;
                    case "Banner":
                        if (productFatherslist[2].Count > 0)
                        {
                            productFathers[i] = productFatherslist[2][0];
                            productFatherslist[2].RemoveAt(0);
                        }
                        break;
                    default:
                        break;
                }
            }
            return productFathers;
        }

        /// <summary>
        /// 查询所有的货物
        /// </summary>
        /// <returns></returns>
        public void ShowPros()
        {
            foreach (var item in productFatherslist)
            {
                if (item.Count > 0)
                {
                    Console.WriteLine("仓库有:{0}:{1}个,单价{2}元\r",
                        item[0].Name, item.Count, item[0].Price);
                }
            }
        }













        public void Add(ProductFather productFather)
        {
            if (productFather is Acer)
            {
                productFatherslist[0].Add(productFather);
            }
            if (productFather is SamSung)
            {
                productFatherslist[1].Add(productFather);
            }
            if (productFather is Banner)
            {
                productFatherslist[2].Add(productFather);
            }
        }

    }
}
