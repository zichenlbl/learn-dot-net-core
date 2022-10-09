using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2_正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "www.hujinya.com";
            str1 = Regex.Replace(str1, @"[a-z]", "*"); //把符合的替换为*
            Console.WriteLine(str1); //***.*******.***

            //题目: 判断5-12位的数字   {}:重复描述字符
            //{m,n} 表示数量为m-n个
            //{m} 表示数量为m个
            //{m,} 表示数量为m-正无穷
            //? 表示数量为0次或1次
            //+ 表示数量为1次或多次
            //* 表示数量为0次或多次
            Console.WriteLine(Regex.IsMatch("12345", @"^\d{5,12}$")); //True

            /*
             * \w 字母数字下划线汉字
             * \s 空白符 /n换行 /r回车 /t制表 /v垂直制表 /f换页
             * \d 0-9数字
             * . 除换行符以外的任意字符
             * ^ 开始
             * $ 结束
             */

            // | 匹配左边或右边
            Console.WriteLine(Regex.IsMatch("12y3", @"\d|x")); //True

            //() 分组
            Console.WriteLine(Regex.IsMatch("abab", @"(ab){2}")); //True

            Console.WriteLine(Regex.IsMatch("abb", @"ab{2}")); //True

            Console.WriteLine(Regex.IsMatch("(", @"\(")); //True

            //题目: 校验ip4地址 每段最大数字为255, 并且第1位不能为0
            Console.WriteLine(Regex.IsMatch("192.168.10.1", @"^((2[0-4]\d|25[0-5]|1\d\d|[1-9]\d?)\.){3}(2[0-4]\d|25[0-5]|1\d\d|[1-9]\d?)$")); //True

            string str = "123456n";
            bool flag = Regex.IsMatch(str, @"\d"); //任意一个是数字
            Console.WriteLine(flag); //True

            str = "12234n";
            flag = Regex.IsMatch(str, @"\d*"); //0个或多个数字
            Console.WriteLine(flag); //True

            str = "n1323n";
            flag = Regex.IsMatch(str, @"\d\d\d\d"); //4个数字
            Console.WriteLine(flag); //True

            flag = Regex.IsMatch(str, @"\d\d\d"); //3个数字
            Console.WriteLine(flag); //True

            str = "2221";
            //任意位置匹配就为True
            flag = Regex.IsMatch(str, @"11*"); //第一个字符是1, 第二个是0个或多个字符1
            Console.WriteLine(flag); //True

            flag = Regex.IsMatch(str, @"^2"); //以2开头
            Console.WriteLine(flag); //True

            flag = Regex.IsMatch(str, @"1$"); //以1结尾
            Console.WriteLine(flag); //True

            str = "2";
            flag = Regex.IsMatch(str, @"^\d$"); //以数字开头, 以数字结尾, 一个数字
            Console.WriteLine(flag); //True

            str = "12345";
            flag = Regex.IsMatch(str, @"^\d*$");  //以数字开头, 以数字结尾, 0个或多个数字
            Console.WriteLine(flag); //True

            str = "azAZ09_你";
            // \W 大写的表示\w的补集, 除了\w的都符合  
            flag = Regex.IsMatch(str, @"\w"); //字母数字下划线汉字
            Console.WriteLine(flag); //True

            //[] 表示定义要符合的一堆集合
            flag = Regex.IsMatch("x", @"[xyz]"); //任意一个xyz中的字符
            Console.WriteLine(flag); //True

            flag = Regex.IsMatch("X", @"[A-Z]"); //任意一个A-Z中的字符
            Console.WriteLine(flag); //True

            //^ 在[]表示补集, 除了A-Z的都符合
            flag = Regex.IsMatch("x", @"[^A-Z]"); //任意一个除了A-Z中的字符
            Console.WriteLine(flag); //True

            //题目: 以数字、字母、下划线组成, 不能以数字开头 -1a_B
            flag = Regex.IsMatch("xyz_123", @"^[A-Za-z_]\w*$");
            Console.WriteLine(flag); //True

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
