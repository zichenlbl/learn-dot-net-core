using System;

namespace ConsoleApp2_接口
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1.Test();

            //接口就是一个规范、能力 
            IKouLanble kouLanble = new Student();
            kouLanble.KouLan(); //扣篮
            kouLanble.Fly(); //接口的飞

            Student student = new Student();
            student.Fly(); //飞

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Person
    {

    }

    public class Student : Person, IKouLanble
    {
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void KouLan()
        {
            Console.WriteLine("扣篮");
        }

        public void Fly()
        {
            Console.WriteLine("飞");
        }

        /// <summary>
        /// 显示实现接口 类里的方法默认private
        /// </summary>
        void IKouLanble.Fly()
        {
            Console.WriteLine("接口的飞");
        }
    }

    public interface IKouLanble
    {
        void KouLan();

        //接口中的成员不允许添加访问修饰符, 默认就是public
        public void Fly();
        //protected void Fly();

        //不允许写普通属性
        //private string _name;

        //自动属性
        public int MyProperty { get; set; }
    }

    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class Bird
    {
        /// <summary>
        /// 抽象方法
        /// </summary>
        public abstract void Fly();
    }
    
}
