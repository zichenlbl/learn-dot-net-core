using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2_进程类
{
    class Program
    {
        static void Main(string[] args)
        {
            //通过进程打开指定文件
            ProcessStartInfo startInfo = new ProcessStartInfo(@"H:\A\WenBen2.txt");

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            //通过进程打开应用程序
            Process.Start("calc");
            Process.Start("mspaint");
            Process.Start("notepad");
            Process.Start("iexplore", "https://www.hujinya.com");

            //查看当前程序中正在运行的所有进程
            Process[] processes = Process.GetProcesses();
            foreach (var item in processes)
            {
                Console.WriteLine(item);
            }
            //processes[0].Kill(); //停止进程

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
