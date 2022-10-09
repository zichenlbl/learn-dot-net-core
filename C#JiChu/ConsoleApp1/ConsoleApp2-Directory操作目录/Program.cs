using System;
using System.IO;

namespace ConsoleApp2_Directory操作目录
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建文件夹
            //Directory.CreateDirectory(@"H:\A\newFolder");
            //Console.WriteLine("创建成功");

            //删除空文件夹
            //Directory.Delete(@"H:\A\newFolder");
            //Console.WriteLine("删除成功");

            //强制删除非空文件夹
            //Directory.Delete(@"H:\A\newFolder", true);
            //Console.WriteLine("删除成功");

            //剪切文件夹
            //Directory.Move(@"H:\A\picture", @"H:\A\picture2");
            //Console.WriteLine("剪切成功");

            //获取目录下所有文件路径 指定txt格式
            string[] paths = Directory.GetFiles(@"H:\A", "*.txt");
            foreach (var item in paths)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
