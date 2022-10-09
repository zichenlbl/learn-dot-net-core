using System;

namespace ConsoleApp2_关键字new
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            driver.SayHello(); //我是司机

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 父类
    /// </summary>
    public class Person
    {
        public Person()
        {
            Console.WriteLine("Person的无参构造函数");
        }

        public Person(string name, int age, char gender)
        {
            Console.WriteLine("Person的有参构造函数");
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string _name;
        private int _age;
        private char _gender;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public char Gender { get => _gender; set => _gender = value; }

        public void SayHello()
        {
            Console.WriteLine("我是人类");
        }
    }

    /// <summary>
    /// 子类
    /// </summary>
    public class Driver : Person
    {
        public Driver() : base()
        {
            Console.WriteLine("Driver的无参构造函数");
        }

        private int _driveTime; //驾龄

        public Driver(string name, int age, char gender) : base(name, age, gender)
        {
            Console.WriteLine("Driver的有参构造函数");
        }

        public int DriveTime { get => _driveTime; set => _driveTime = value; }

        public new void SayHello()
        {
            Console.WriteLine("我是司机");
        }

    }
}
