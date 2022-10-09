using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2_反射
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();

            var c = class1.GetType(); //当前实例的准确运行时类型。

            object o = Activator.CreateInstance(c); //创建指定类型的实例
            MethodInfo methodInfo = c.GetMethod("Test"); //搜索具有指定名称的公共方法。

            methodInfo.Invoke(o, null); //我是Test方法

            /////////////////使用NuGet包///////////////////
            //安装Microsoft.Extensions.Dependency
            //注册
            var sc = new ServiceCollection(); //容器
            //依赖注入
            sc.AddScoped(typeof(IClass1), typeof(Class1));
            
            var sp = sc.BuildServiceProvider();

            //调用
            IClass1 class2 = sp.GetService<IClass1>();
            class2.Test(); //我是Test方法

            ////////////////////////////////////////
            Console.WriteLine(Environment.CurrentDirectory); //项目运行的文件路径
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes = new List<Type>();
            foreach (var item in files)
            {
                //加载指定路径上的程序集
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(item);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetMethod("Voice") != null)
                    {
                        animalTypes.Add(type);
                    }
                }
            }

            if (animalTypes.Count > 0)
            {
                int i = 0;
                var t = animalTypes[0];
                var m = t.GetMethod("Voice");
                var o1 = Activator.CreateInstance(t);
                m.Invoke(o1, new object[] { i });
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
