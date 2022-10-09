using System;
using System.Xml;

namespace ConsoleApp2_读取XML文档
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDocument = new XmlDocument();
            string path = @"H:\A\newXML.xml";

            //加载XML
            xmlDocument.Load(path);

            //获取根节点
            XmlElement books = xmlDocument.DocumentElement;

            //获取子节点集合
            XmlNodeList xmlNodeList = books.ChildNodes;

            foreach (XmlNode item in xmlNodeList)
            {
                Console.WriteLine(item.InnerText);
            }

            //读取节点的属性值
            XmlNodeList xmlNodeList1 =
                xmlDocument.SelectNodes("/Books/Book/Item");
            foreach (XmlNode item in xmlNodeList1)
            {
                Console.WriteLine(item.Attributes["Name"].Value); //张三
                Console.WriteLine(item.Attributes["Age"].Value); //22
            }

            XmlNode xmlNode = xmlDocument.SelectSingleNode("/Books/Book/Des");
            xmlNode.RemoveAll(); //删除Des节点的值
            xmlDocument.Save(path);
            Console.WriteLine("删除成功");

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
