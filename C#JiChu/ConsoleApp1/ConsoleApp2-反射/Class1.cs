using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_反射
{
    class Class1 : IClass1
    {
        public void Test()
        {
            Console.WriteLine("我是Test方法");
        }
    }

    interface IClass1
    {
        void Test();
    }
}
