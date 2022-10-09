using System;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp2_字符串的方法
{
    class Program
    {
        static void Main(string[] args)
        {


            //把|放在每个字符数组的中间
            string[] names = { "张三", "李四", "王五", "赵六" };
            string str12 = string.Join("|", names);
            Console.WriteLine(str12); //张三|李四|王五|赵六
            Console.WriteLine(string.Join("-", "2022", "09", "27")); //2022-09-27

            //判断字符串是否为null或空
            string str11 = null;
            Console.WriteLine(string.IsNullOrEmpty(str11)); //True
            str11 = "";
            Console.WriteLine(string.IsNullOrEmpty(str11)); //True
            str11 = "张三";
            Console.WriteLine(string.IsNullOrEmpty(str11)); //False

            string str10 = "  abc def ";
            //str10 = str10.Trim(); //abc def
            //str10 = str10.TrimEnd(); //  abc def
            //str10 = str10.TrimStart(); //abc def
            str10 = str10.TrimEnd('f', ' '); //  abc de
            Console.WriteLine(str10);

            //取文件名
            string path = @"c:\a\b\c\test.mp3";
            int index2 = path.LastIndexOf("\\"); //最后一次出现的位置
            path = path.Substring(index2 + 1);
            Console.WriteLine(path); //test.mp3


            //判断字符串以子串开头或结尾
            string str9 = "Hello World!";
            bool flag2 = str9.StartsWith("He");
            Console.WriteLine(flag2); //True
            flag2 = str9.EndsWith("!");
            Console.WriteLine(flag2); //True
            flag2 = str9.EndsWith("Hello World!");
            Console.WriteLine(flag2); //True
            int index = str9.IndexOf('o');
            Console.WriteLine(index); //4
            index = str9.IndexOf('o', 4); //包括4索引位置
            Console.WriteLine(index); //4
            index = str9.IndexOf('o', 5); //从索引5开始找
            Console.WriteLine(index); //7
            index = str9.IndexOf('x');
            Console.WriteLine(index); //-1 找不到

            //截取字符串
            string str8 = "今天天气怎么样?";
            str8 = str8.Substring(2);
            Console.WriteLine(str8); //天气怎么样?
            str8 = str8.Substring(2, 3);
            Console.WriteLine(str8); //怎么样

            //判断字符串中是否包含一些关键字
            string str7 = "机密任务: 张三";
            if (str7.Contains("张三"))
            {
                str7 = str7.Replace("张三", "**");
            }
            Console.WriteLine(str7); //机密任务: **

            string str5 = "1234567890qwertyuiop";
            Console.WriteLine(str5.Length); //20
            Console.WriteLine(str5.ToUpper()); //转大写
            Console.WriteLine(str5.ToLower()); //转小写
            //比较的时候忽略两个字符串的大小写
            bool flag = str5.Equals("1234567890QWERTYUIOP",
                StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(flag); //True
            char[] chars2 = { '6', 'q', 'i' };
            //以6 q i 分隔, 去除空的数组元素
            string[] str6 = str5.Split(chars2, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(str6[0]); //12345
            Console.WriteLine(str6[1]); //7890

            StringBuilder stringBuilder = new StringBuilder();
            string str4 = null;
            //创建一个计时器,记录程序运行的时间
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //开始计时
            for (int i = 0; i < 90000; i++)
            {
                //str4 += i;             //00:00:10.0793807
                stringBuilder.Append(i); //00:00:00.0077419
            }
            stopwatch.Stop(); //计时结束
            Console.WriteLine(stopwatch.Elapsed); //时间 
            //Console.WriteLine(str4);
            //Console.WriteLine(stringBuilder.ToString());


            string str3 = "abcdef";
            Console.WriteLine(str3[0]); //a
            char[] chars = str3.ToCharArray();
            chars[0] = 'z';
            str3 = new string(chars);
            Console.WriteLine(str3); //zbcdef

            string str = "张三";
            string str2 = "张三"; //即时窗口 输入 &str 回车 和 &str2 查看堆中地址一样

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
