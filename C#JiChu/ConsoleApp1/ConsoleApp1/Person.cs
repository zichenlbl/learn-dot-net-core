using System;

namespace ConsoleApp1
{
    public class Person
    {
        private string _name; //字段
        private int _age;
        private char _gender;

        public string Name //属性
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int Age { get => _age; set => _age = value; }

        public char Gender
        {
            get { return this._gender; }
            set
            {
                if (_gender != '男' && _gender != '女')
                {
                    _gender = '男';
                }
            }
        }

        public void Eat()
        {
            Console.WriteLine("{0}Eat,年龄{1},性别{2}.", this.Name, this.Age, this.Gender);
        }

        public static void Eat2()
        {
            Console.WriteLine("类的静态方法");
        }
    }
}
