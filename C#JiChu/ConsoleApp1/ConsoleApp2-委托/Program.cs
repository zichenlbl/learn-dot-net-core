using System;

namespace ConsoleApp2_委托
{
    //泛型委托
    public delegate T MyDelegate2<T>(T a, T b);

    class Program
    {
        /// <summary>
        /// 声明一个委托
        /// </summary>
        /// <param name="name"></param>
        public delegate void MyDelegate(string name);

        static void Main(string[] args)
        {
            //委托
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Func<Product> func = new Func<Product>(productFactory.MakePizza);
            Func<Product> func1 = new Func<Product>(productFactory.MakeToyCar);
            Logger logger = new Logger();
            Action<Product> action = new Action<Product>(logger.Log);
            Box box = wrapFactory.WrapProduct(func, action);
            //满足条件Price >= 50 执行回调action委托
            //Product'Toy Car' created at 2022/10/9 2:41:04. Price is 100.
            Box box1 = wrapFactory.WrapProduct(func1, action);
            Console.WriteLine(box.Product.Name); //Pizza
            Console.WriteLine(box1.Product.Name); //Toy Car


            //使用泛型委托
            MyDelegate2<int> myDelegate21 = new MyDelegate2<int>(Add);
            Console.WriteLine(myDelegate21(4, 8)); //12

            MyDelegate2<double> myDelegate22 = new MyDelegate2<double>(Mul);
            Console.WriteLine(myDelegate22(3.0, 4.5)); //13.5

            MyDelegate myDelegate = new MyDelegate(SayHiChinese);
            myDelegate("张三"); //吃了么？张三

            MyDelegate myDelegate1 = SayHiChinese;
            myDelegate1.Invoke("李四"); //吃了吗？李四
            myDelegate1("李四"); //吃了么？李四

            Test("王五", SayHiEnglish); //Nice to meet you 王五

            //匿名函数
            Test("赵六", delegate (string name)
                {
                    Console.WriteLine("Hello " + name);
                }
            );

            Test("孙七", (string name) =>
                {
                    Console.WriteLine("Hello " + name);
                }
            );

            //委托数组
            MyDelegate[] myDelegates = { SayHiChinese, SayHiEnglish };
            foreach (MyDelegate item in myDelegates)
            {
                //吃了么？孙悟空
                //Nice to meet you 孙悟空
                item("孙悟空");
            }

            //委托参数
            MyDelegate myDelegate2 = SayHiEnglish;
            Say(myDelegate2); //Nice to meet you Mike

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public static void Test(string name, MyDelegate myDelegate)
        {
            myDelegate(name);
        }

        public static void SayHiChinese(string name)
        {
            Console.WriteLine("吃了么？" + name);
        }

        public static void SayHiEnglish(string name)
        {
            Console.WriteLine("Nice to meet you " + name);
        }

        public static void Say(MyDelegate myDelegate)
        {
            myDelegate("Mike");
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static double Mul(double x, double y)
        {
            return x * y;
        }
    }

    class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine("Product'{0}' created at {1}. Price is {2}.",
                product.Name, DateTime.UtcNow, product.Price);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }

    }

    class WrapFactory
    {
        public Box WrapProduct(Func<Product> getProduct,
            Action<Product> logCallBack)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
            if (product.Price >= 50)
            {
                logCallBack(product);
            }
            box.Product = product;
            return box;
        }
    }

    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 12;
            return product;
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }
}
