using System;

namespace ConsoleApp2_抽象类
{
    class Program
    {
        static void Main(string[] args)
        {
            //动物叫的方法
            Animal animal = new Dog();
            animal.Bark();

            Animal animal2 = new Cat();
            animal2.Bark();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// 抽象方法
        /// </summary>
        public abstract void Bark();
    }

    public class Dog : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("狗狗旺旺");
        }
    }

    public class Cat : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("猫猫喵喵");
        }
    }

}
