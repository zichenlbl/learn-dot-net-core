using System;
using System.IO;
using System.Text;

namespace ConsoleApp2_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            //读取文件
            byte[] buffer = File.ReadAllBytes(@"H:\A\WenBen.txt");
            //将字节数组中的每一个元素按照指定的编码格式解码成字符串
            string str = Encoding.Default.GetString(buffer);
            Console.WriteLine(str); //Hello,你好!

            //写入字符到文件
            string str2 = "Hello World!";
            //没有文件的话 会创建，有文件则覆盖
            byte[] buffer2 = Encoding.Default.GetBytes(str2);
            File.WriteAllBytes(@"H:\A\newWenBen.txt", buffer2);
            Console.WriteLine("写入成功");

            //按行读取字符文本
            string[] contents = File.ReadAllLines(@"H:\A\WenBen2.txt", Encoding.Default);
            foreach (string item in contents)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------分隔符----------");

            // 读取所有的字符文本
            string str3 = File.ReadAllText(@"H:\A\WenBen2.txt", Encoding.Default);
            Console.WriteLine(str3);

            // 读取所有的字符文本 使用相对路径
            string str4 = File.ReadAllText(@"WenBen2.txt", Encoding.Default);
            Console.WriteLine(str4);

            //按行写入字符到文件
            string[] str5 = new string[] { "静夜思", "床前明月光" };
            //没有文件的话 会创建，有文件则覆盖
            File.WriteAllLines(@"H:\A\newWenBen2.txt", str5);
            Console.WriteLine("写入成功");

            //写入所有字符到文件
            //没有文件的话 会创建，有文件则覆盖
            File.WriteAllText(@"H:\A\newWenBen3.txt", "静夜思\n床前明月光，\n疑是地上霜。");
            Console.WriteLine("写入成功");

            //追加写入
            File.AppendAllText(@"H:\A\newWenBen4.txt", DateTime.Now.ToString() + '\n');
            Console.WriteLine("写入成功");

            //File类只能读小文件,一次性把文件读到内存

            //创建一个文件
            //File.Create(@"H:\A\newFile.txt");
            //Console.WriteLine("创建成功");

            //删除一个文件
            //File.Delete(@"H:\A\newFile.txt");
            //Console.WriteLine("删除成功");

            //复制一个文件
            //File.Copy(@"H:\A\20191005_IMG_0172.JPG", @"H:\A\newImg.JPG");
            //Console.WriteLine("复制成功");

            //移动一个文件 目录要存在
            //File.Move(@"H:\A\newImg.JPG", @"H:\A\new\newImg2.JPG");
            //Console.WriteLine("移动成功");

            str = @"F:\A\20191005_IMG_0172.JPG";
            //获取文件名
            Console.WriteLine(Path.GetFileName(str)); //20191005_IMG_0172.JPG
            //获取文件名不包括扩展名
            Console.WriteLine(Path.GetFileNameWithoutExtension(str)); //20191005_IMG_0172
            //获取扩展名
            Console.WriteLine(Path.GetExtension(str)); //.JPG
            //获取文件所在的文件夹
            Console.WriteLine(Path.GetDirectoryName(str)); //F:\A
            //获取文件所在的全路径
            Console.WriteLine(Path.GetFullPath(str)); //F:\A\20191005_IMG_0172.JPG
            //连接两个字符串作为路径
            Console.WriteLine(Path.Combine(@"F:\B", "a.exe")); //F:\B\a.exe

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
