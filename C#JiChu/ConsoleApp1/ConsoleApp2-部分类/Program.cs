using System;

namespace ConsoleApp2_部分类
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Test();
            Console.WriteLine(person._name); //张三

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        /// <summary>
        /// 部分类
        /// </summary>
        public partial class Person
        {
            public string _name;
        }

        /// <summary>
        /// 部分类
        /// </summary>
        public partial class Person
        {
            //public string _name; 已定义过
            public void Test()
            {
                _name = "张三"; //可以访问
            }
        }

        //public class Person
        //{

        //}

        //public class Person
        //{
        //}
    }
}
