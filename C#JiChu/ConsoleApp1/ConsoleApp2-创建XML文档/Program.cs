using System;
using System.Xml;

namespace ConsoleApp2_创建XML文档
{
    class Program
    {
        static void Main(string[] args)
        {
            //xml文档
            XmlDocument xmlDocument = new XmlDocument();

            //创建描述信息
            XmlDeclaration xmlDeclaration =
                xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            //写入第一行
            xmlDocument.AppendChild(xmlDeclaration);

            //写根节点
            XmlElement books = xmlDocument.CreateElement("Books");
            xmlDocument.AppendChild(books);

            //写子节点
            XmlElement book = xmlDocument.CreateElement("Book");
            books.AppendChild(book);

            //写值
            XmlElement name = xmlDocument.CreateElement("Name");
            name.InnerText = "金瓶梅";
            book.AppendChild(name);

            XmlElement price = xmlDocument.CreateElement("Price");
            price.InnerText = "10.5";
            book.AppendChild(price);

            XmlElement des = xmlDocument.CreateElement("Des");
            des.InnerText = "好看";
            book.AppendChild(des);

            XmlElement item = xmlDocument.CreateElement("Item");
            //给节点添加属性
            item.SetAttribute("Name", "张三");
            item.SetAttribute("Age", "22");
            book.AppendChild(item);

            //保存文件
            xmlDocument.Save(@"H:\A\newXML.xml");
            Console.WriteLine("创建成功");

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
