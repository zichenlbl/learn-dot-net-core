using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_接口
{
    class Class1
    {
        public static void Test()
        {
            WarmKiller wk = new WarmKiller();
            wk.Love(); //只能调用Love方法

            IKiller killer = wk;
            killer.Kill(); //IKiller类型才能调用Kill方法
        }
    }

    interface IGentleman
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }

    class WarmKiller : IGentleman, IKiller
    {
        //显示实现接口
        void IKiller.Kill()
        {
            Console.WriteLine("Let me kill the enemy...");
        }

        public void Love()
        {
            Console.WriteLine("I will love you for ever...");
        }
    }

}
