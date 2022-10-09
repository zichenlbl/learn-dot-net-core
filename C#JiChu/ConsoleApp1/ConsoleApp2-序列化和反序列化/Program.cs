using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp2_序列化和反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            ////要将person对象 传输给对方电脑
            //Person person = new Person();
            //person.Name = "张三";
            //person.Age = 22;
            //person.Gender = '男';

            //using (FileStream fileStream = new FileStream(@"H:\A\Person.txt",
            //    FileMode.OpenOrCreate ,FileAccess.Write))
            //{
            //    //序列化对象
            //    BinaryFormatter binaryFormatter = new BinaryFormatter();
            //    binaryFormatter.Serialize(fileStream, person);
            //    Console.WriteLine("序列化成功");
            //}

            //接收二进制文件 反序列化
            using (FileStream fileStream = new FileStream(@"H:\A\Person.txt",
                FileMode.OpenOrCreate, FileAccess.Read))
            {
                //反序列化对象
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Person person = (Person)binaryFormatter.Deserialize(fileStream);
                Console.WriteLine("{0}:{1}:{2}", person.Name, person.Age, person.Gender);
                Console.WriteLine("反序列化成功");
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    [Serializable]
    public class Person
    {
        private string _name;
        private char _gender;
        private int _age;

        public string Name { get => _name; set => _name = value; }
        public char Gender { get => _gender; set => _gender = value; }
        public int Age { get => _age; set => _age = value; }
    }
}
