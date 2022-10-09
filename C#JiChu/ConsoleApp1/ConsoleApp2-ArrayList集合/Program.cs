using System;
using System.Collections;

namespace ConsoleApp2_ArrayList集合
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建了一个集合对象
            ArrayList list = new ArrayList();
            //很多数据的一个集合 长度任意改变, 数据类型任意
            list.Add("张三");
            list.Add(22);
            list.Add(233m); //233
            list.Add(new int[] { 1, 2, 3 });
            Person person = new Person();
            list.Add(person);
            //添加集合 打印时打印集合的元素
            //list.AddRange(new string[] { "李四", "王五" });
            //list.Clear(); //清空元素
            //list.Remove(22); //删除22
            //list.RemoveAt(0); //删除下标0的元素
            //list.RemoveRange(3, 2); //根据下标去移除一定范围的元素
            //list.Sort(); //升序排列
            //list.Reverse(); //反转
            //list.Insert(2, "Hello"); //插入元素
            //list.InsertRange(3, new string[] { "赵六", "孙七" }); //插入集合
            //bool flag = list.Contains(22); //判断是否包含22
            //1 4; 5 8; 9 16 集合大小和对应可包含的大小
            int count = list.Count; //集合的大小
            int capacity = list.Capacity; //可包含的大小
            Console.WriteLine("{0}/{1}", count, capacity);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Person)
                {
                    ((Person)list[i]).SayHello();
                } 
                else if (list[i] is int[])
                {
                    for (int j = 0; j < ((int[])list[i]).Length; j++)
                    {
                        Console.WriteLine(((int[])list[i])[j]);
                    }
                }
                else
                {
                    Console.WriteLine(list[i]);
                }
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Person
    {
        public void SayHello()
        {
            Console.WriteLine("你好");
        }
    }
}
