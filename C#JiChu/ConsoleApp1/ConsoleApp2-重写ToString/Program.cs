using System;

namespace ConsoleApp2_重写ToString
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Console.WriteLine(person.ToString()); //Hello World!

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Person
    {
        public override string ToString()
        {
            return "Hello World!";
        }
    }
}
