using System;
using System.IO;
using System.Xml;

namespace ConsoleApp2_追加XML文档
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"H:\A\newXML.xml";
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement books = null;
            //如果文件存在
            if (File.Exists(path))
            {
                xmlDocument.Load(path); //加载XML
                //获得根节点
                books = xmlDocument.DocumentElement;
            }
            else
            {
                //如果不存在则创建
                XmlDeclaration xmlDeclaration =
                    xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDocument.AppendChild(xmlDeclaration); //添加第一行
                //创建根节点
                books = xmlDocument.CreateElement("Books");
                xmlDocument.AppendChild(books);
            }

            // 写子节点
            XmlElement book = xmlDocument.CreateElement("Book");
            books.AppendChild(book);

            //写值
            XmlElement name = xmlDocument.CreateElement("Name");
            name.InnerText = "计算机";
            book.AppendChild(name);

            XmlElement price = xmlDocument.CreateElement("Price");
            price.InnerText = "15.5";
            book.AppendChild(price);

            XmlElement des = xmlDocument.CreateElement("Des");
            des.InnerText = "好看啊";
            book.AppendChild(des);

            xmlDocument.Save(path);
            Console.WriteLine("追加成功");

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
