using System;

namespace ConsoleApp2_构造函数
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("张三", 22, '男', 99, 98, 97);
            student.SayHello(); //张三: 22:男: 99:98:97

            Student student1 = new Student("李四", 30);
            student1.SayHello(); //李四: 30:男: 0:0:0

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Student
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Student()
        {

        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        public Student(string name, int age, char gender, int chinese,
            int math, int english)
        {
            
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.Chinese = chinese;
            this.Math = math;
            this.English = english;
        }

        /// <summary>
        /// this关键字调用当前类的构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Student(string name, int age) 
            : this(name, age, '男', 0, 0, 0)
        {
        }

        /// <summary>
        /// 程序结束的时候执行析构函数
        /// </summary>
        ~Student()
        {
            Console.WriteLine("析构函数");
        }

        private string _name;
        private int _age;
        private char _gender;
        private int _chinese;
        private int _math;
        private int _english;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public char Gender { get => _gender; set => _gender = value; }
        public int Chinese { get => _chinese; set => _chinese = value; }
        public int Math { get => _math; set => _math = value; }
        public int English { get => _english; set => _english = value; }

        public void SayHello()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}", 
                this.Name, this.Age, this.Gender, this.Chinese, this.Math, this.English);
        }
    }

}
