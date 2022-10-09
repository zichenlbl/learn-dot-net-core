using System;

namespace ConsoleApp1
{

    public enum Gender
    {
        男,
        女
    }

    /// <summary>
    /// 结构可以帮助我们一次性声明多个不同类型的变量
    /// </summary>
    public struct PersonStruct
    {
        public string _name; //字段
        public int _age;
        public char _gender;
    }

    
    class Program
    {

        public static void Test(out int num)
        {
            num = 0;
            num++;
        }

        public static void Test2(ref int num)
        {
            num++;
        }

        public static void Test3(params int[] num)
        {
            Console.WriteLine("{0},{1}", num[0], num[1]);
        }

        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "张三";
            person1.Age = 22;
            person1.Gender = '未';
            person1.Eat(); //张三Eat,年龄22,性别男.
            Person.Eat2(); //类的静态方法

            //打印字体为蓝色
            Console.ForegroundColor = ConsoleColor.Blue;

            Test3(7, 9); //7,9

            int myNum2 = -1;
            Test2(ref myNum2);
            Console.WriteLine(myNum2); //0

            int myNum;
            Test(out myNum);
            Console.WriteLine(myNum); //1

            PersonStruct person = new PersonStruct();
            person._name = "张三";
            person._age = 22;
            person._gender = '男';
            Console.WriteLine(person._name); //张三

            Gender gender = Gender.女;
            Gender gender1 = (Gender)Enum.Parse(typeof(Gender), "0");
            Console.WriteLine(gender1); //男
            //
            int a = 1 + 1;
            switch (a)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
            try
            {
                int num = 1;
                int b = num / 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常:{0}", ex.Message);
                //throw ex;
            }
            finally
            {
                Console.WriteLine("不管是否发生异常都会执行");
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
