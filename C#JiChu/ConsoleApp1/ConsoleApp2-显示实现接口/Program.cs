using System;

namespace ConsoleApp2_显示实现接口
{
    class Program
    {
        static void Main(string[] args)
        {
            //显示实现接口就是为了解决方法的重名问题
            IFlyable flyable = new Bird();
            flyable.Fly(); //接口中鸟会飞

            Bird bird = new Bird();
            bird.Fly(); //鸟会飞

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Bird : IFlyable
    {
        /// <summary>
        /// Bird自己的Fly方法
        /// </summary>
        public void Fly()
        {
            Console.WriteLine("鸟会飞");
        }

        /// <summary>
        /// 显示实现接口 类里面的方法默认是private修饰
        /// </summary>
        void IFlyable.Fly()
        {
            Console.WriteLine("接口中鸟会飞");
        }
    }

    public interface IFlyable
    {
        void Fly();
    }
}
