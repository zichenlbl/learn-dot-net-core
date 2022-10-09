using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp2_MD5加密
{
    class Program
    {
        static void Main(string[] args)
        {
            //MD5加密
            string str = "zhangsan123456";
            str = GetMD5(str);
            Console.WriteLine(str);
            Console.WriteLine(20.ToString("x")); //10进制转16进制 14 

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5.Create(); //创建MD5对象
            //将字符串转为字节数组
            byte[] buffer = Encoding.Default.GetBytes(str);
            //返回加密好的字节数组
            buffer = md5.ComputeHash(buffer);
            //将字节数组转为字符串并返回
            //return Encoding.Default.GetString(buffer);  //??Aq$?e??*RAh?
            string str1 = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                str1 += buffer[i].ToString("x2"); //将10进制转为16进制 每个数字补齐2位
            }
            //9bad4171724cf6511abde2a52416881   x
            //9bad41710724cf6511abde2a52416881  x2
            return str1; //9bad41710724cf6511abde2a52416881
        }
    }
}
