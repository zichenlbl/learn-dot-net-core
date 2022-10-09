using System;

namespace ConsoleApp2_超市收银系统
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建超市
            SupperMarket supperMarket = new SupperMarket();
            supperMarket.ShowPros(); //展示货物
            //与用户交流
            supperMarket.Welcome();


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

}
