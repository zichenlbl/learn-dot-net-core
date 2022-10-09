using System;
using System.IO;
using System.Text;

namespace ConsoleApp2_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用StreamReader读取字符文件
            using (StreamReader streamReader = new StreamReader(@"H:\A\WenBen2.txt",
                Encoding.Default))
            {
                while (!streamReader.EndOfStream) //是否读到结尾
                {
                    string str = streamReader.ReadLine();
                    Console.WriteLine(str);
                }
                Console.WriteLine("读取成功");
            }

            //使用StreamWriter写入字符文件 参数:路径,是否追加写入,编码
            using (StreamWriter streamWriter = new StreamWriter(@"H:\A\newWenBen6.txt", true ,Encoding.Default))
            {
                streamWriter.Write(DateTime.Now.ToString() + '\n');
                Console.WriteLine("写入成功");
            }
            

            //使用FileStream复制二进制文件
            string soucre = @"H:\A\20191005_IMG_0172.JPG";
            string target = @"H:\A\new\newImg3.JPG";
            //1.创建负责读取文件的流
            using (FileStream fileStream2 = new FileStream(soucre,
                FileMode.Open, FileAccess.Read))
            {
                //2.创建负责写入文件的流
                using (FileStream fileStream3 = new FileStream(target,
                FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer2 = new byte[1024 * 1024 * 1]; //1MB
                    //循环读取
                    while (true)
                    {
                        //返回本次实际读取到的字节数
                        int r2 = fileStream2.Read(buffer2, 0, buffer2.Length);
                        if (r2 == 0)
                        {
                            break;
                        }
                        //写入新文件
                        fileStream3.Write(buffer2, 0, r2);
                    }
                }
            }
            Console.WriteLine("复制成功");

            //使用FileStream写入数据
            using (FileStream fileStream1 = new FileStream(@"H:\A\newWenBen5.txt",
                FileMode.OpenOrCreate, FileAccess.Write))
            {
                string str = "静夜思\n床前明月光，";
                byte[] buffer2 = Encoding.UTF8.GetBytes(str);
                fileStream1.Write(buffer2, 0, buffer2.Length); //头部覆盖写入
                Console.WriteLine("写入成功");
            }

            //读取数据 FileStream 操作字节
            //1.创建 参数:路径、对文件做的操作、对文件数据做的操作
            FileStream fileStream = new FileStream(@"H:\A\WenBen2.txt",
                FileMode.OpenOrCreate, FileAccess.Read);
            byte[] buffer = new byte[1024 * 1024 * 5]; //一次读5MB大小到缓冲区
            int r = fileStream.Read(buffer, 0, buffer.Length); //从0开始放,放5MB内容
            //将字节数组中每一个元素按照指定的编码格式解码成字符串
            string s = Encoding.Default.GetString(buffer, 0, r); //从0开始解码,解码读到的大小

            //关闭流
            fileStream.Close();
            //释放流占用的资源
            fileStream.Dispose();

            Console.WriteLine(s);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
