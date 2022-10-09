using System;

namespace ConsoleApp2_简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你想要的笔记本型号(Lenovo/IBM/Acer/Dell):");
            string brand = Console.ReadLine();
            NoteBook noteBook = GetNoteBook(brand);
            if (noteBook != null)
            {
                noteBook.SayHello();
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        /// <summary>
        /// 工厂 根据用户的输入返回不同的对象
        /// </summary>
        /// <returns></returns>
        public static NoteBook GetNoteBook(string brand)
        {
            //方法返回父类对象，实际返回为子类
            NoteBook noteBook = null;
            switch (brand)
            {
                case "Lenovo":
                    noteBook = new Lenovo();
                    break;
                case "IBM":
                    noteBook = new IBM();
                    break;
                case "Acer":
                    noteBook = new Acer();
                    break;
                case "Dell":
                    noteBook = new Dell();
                    break;
                default:
                    break;
            }
            return noteBook;
        }
    }

    /// <summary>
    /// 抽象类 笔记本
    /// </summary>
    public abstract class NoteBook
    {
        public abstract void SayHello();
    }

    public class Lenovo : NoteBook
    {
        public override void SayHello()
        {
            Console.WriteLine("你好,我是联想笔记本!");
        }
    }

    public class Acer : NoteBook
    {
        public override void SayHello()
        {
            Console.WriteLine("你好,我是宏基笔记本!");
        }
    }

    public class IBM : NoteBook
    {
        public override void SayHello()
        {
            Console.WriteLine("你好,我是IBM笔记本!");
        }
    }

    public class Dell : NoteBook
    {
        public override void SayHello()
        {
            Console.WriteLine("你好,我是戴尔笔记本!");
        }
    }
}
