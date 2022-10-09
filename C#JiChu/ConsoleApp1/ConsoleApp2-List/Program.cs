using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp2_List
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "张三");
            //dic.Add(1, "张三"); //不能添加相同的键
            dic.Add(2, "李四");
            dic[1] = "王五";
            foreach (int item in dic.Keys)
            {
                Console.WriteLine("{0}:{1}", item, dic[item]); //1:王五 2:李四
            }
            foreach (KeyValuePair<int, string> keyValue in dic)
            {
                Console.WriteLine("{0}:{1}", keyValue.Key, keyValue.Value); //1:王五 2:李四
            }

            int n = 10;
            object o = n; //装箱
            int n2 = (int)o;

            ////ArrayList装箱拆箱时间
            ArrayList list2 = new ArrayList();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int k = 0; k < 9999999; k++)
            {
                list2.Add(k);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed); //00:00:00.8945075

            //List<T> 泛型集合不需要装箱拆箱
            List<int> list3 = new List<int>();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            for (int j = 0; j < 9999999; j++)
            {
                list3.Add(j);
            }
            stopwatch2.Stop();
            Console.WriteLine(stopwatch2.Elapsed); //00:00:00.0918368

            //继承关系才可能有装箱和拆箱
            int n3 = 10;
            IComparable i2 = n3; //装箱

            int n4 = 11;
            string str = Convert.ToString(n4); //没有装箱

            //创建泛型集合对象
            List<int> list = new List<int>();
            list.Add(7);
            list.Add(9);
            list.AddRange(new int[] {  1, 2, 3 });
            list.AddRange(list);
            list.Remove(7);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            //list.Clear(); //清空
            //list.Reverse(); //反转
            //list.Sort(); //排序
            //list.Insert(0, 9); //插入
            //list.InsertRange(0, list); //插入集合
            //List泛型集合可以转换为数组
            int[] nums = list.ToArray();
            //数组可以转换为泛型集合
            List<int> newList = nums.ToList();


            Console.WriteLine();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
