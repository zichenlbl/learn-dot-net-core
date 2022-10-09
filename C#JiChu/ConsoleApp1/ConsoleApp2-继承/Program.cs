using System;

namespace ConsoleApp2_继承
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            driver.Age = 30;
            driver.Name = "张三";
            driver.Gender = '男';
            driver.DriveTime = 5;
            //张三:30:男:5
            Console.WriteLine("{0}:{1}:{2}:{3}", driver.Name,
                driver.Age, driver.Gender, driver.DriveTime);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 没有使用继承 重复字段
    /// </summary>
    public class Studnet
    {
        private string _name;
        private char _gender;
        private int _age;
        private int _id;

        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }
        
        public char Gender
        {
            get { return _gender; }
            set { this._gender = value; }
        }

        public int Age
        {
            get { return this._age; }
            set { this._age = value; }
        }

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public void Run()
        {
            Console.WriteLine("学生跑");
        }
    }

    /// <summary>
    /// 没有使用继承 重复字段
    /// </summary>
    public class Teacher
    {
        private string _name;
        private int _age;
        private char _gender;
        private double _salary;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public char Gender { get => _gender; set => _gender = value; }
        public double Salary { get => _salary; set => _salary = value; }

        public void Run()
        {
            Console.WriteLine("老师跑");
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

    }
}
