using System;

namespace ConsoleApp2_密封类
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    //密封类 不能被继承,自身可以继承其他类
    public sealed class Person : Test
    {

    }

    public class Test
    {

    }

    //无法从密封类型Person派生
    //public class Test : Person
    //{

    //}
}
