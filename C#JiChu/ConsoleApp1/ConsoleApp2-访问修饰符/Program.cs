using System;

namespace ConsoleApp2_访问修饰符
{
    //默认修饰符 只能在当前项目中访问该类
    internal class Person
    {
        public string _age;
        private char _gender;
        protected string _name;
        internal int _chinese;
        protected internal int _math;
    }

    public class Student
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
