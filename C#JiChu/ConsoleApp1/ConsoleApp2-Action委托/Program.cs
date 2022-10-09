using System;

namespace ConsoleApp2_Action委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = Test;
            action(); //Test方法

            Action<string> action1 = Test;
            action1("Mike"); //Hello Mike

            Action<string, int> action2 = Test;
            action2("张三", 22); //Hello 张三:22

            //返回值类型指定为 string
            Func<string> func = Test1;
            Console.WriteLine(func()); //Hi

            //参数类型 string int 返回值类型指定为string
            Func<string, int, string> func1 = Test1;
            Console.WriteLine(func1("李四", 23));

            Console.WriteLine("Hello World!");
            Console.WriteLine();
        }

        private static void Test()
        {
            Console.WriteLine("Test方法");
        }

        private static void Test(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        private static void Test(string name, int age)
        {
            Console.WriteLine("Hello " + name + ":" + age);
        }

        private static string Test1()
        {
            return "Hi";
        }

        private static string Test1(string name, int age)
        {
            return "Hi " + name + ":" + age;
        }
    }
}
