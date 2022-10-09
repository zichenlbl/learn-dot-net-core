using System;
using ConsoleApp2_访问修饰符;

namespace ConsoleApp2_访问修饰符2
{
    class Program
    {
        static void Main(string[] args)
        {
            //访问public修饰的Student类
            Student student = new Student();

            //不能访问internal修饰的Person类
            //Person person = new Person(); 

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
