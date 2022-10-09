using System;

namespace ConsoleApp2_Lambda表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomeCalc((a, b) => a * b, 100, 200); //20000

            Func<int, int, int> func = new Func<int, int, int>(
                (int x, int y) => { return x + y; }
            );
            Console.WriteLine(func(4, 8)); //12

            Func<int, int, int> func1 = (x, y) => { return x * y; };
            Console.WriteLine(func1(4, 8)); //32

            func = (x, y) => x - y;
            Console.WriteLine(func(6, 3)); //3

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public static void DoSomeCalc<T>(Func<T, T, T> func, T x, T y)
        {
            T result = func(x, y);
            Console.WriteLine(result);
        }

    }
}
