using System;
using System.Collections;

namespace ConsoleApp2_Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个键值对集合
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "张三");
            hashtable.Add(2, "李四");
            hashtable.Add(3, 22);
            hashtable.Add(true, "正确");
            //hashtable.Add(1, "赵六"); //不能添加两个相同的键
            hashtable["e"] = "添加的"; //添加的另一种方式
            hashtable[1] = "赵六"; //如果有键为1 则替换键为1的值
            if (!hashtable.ContainsKey("键")) //判断是否已存在键
            {
                hashtable.Add("键", "值");
            }
            //hashtable.Clear(); //清空
            hashtable.Remove("键"); //移除指定的键

            foreach (var item in hashtable.Keys) //hashtable键
            {
                Console.WriteLine("{0}:{1}", item , hashtable[item]);
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
