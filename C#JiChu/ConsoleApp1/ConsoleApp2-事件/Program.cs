using System;
using System.Timers;

namespace ConsoleApp2_事件
{

    class Program
    {
        static void Main(string[] args)
        {
            //Timer timer = new Timer();
            //timer.Interval = 1000; //引发Timer事件的间隔
            //Boy boy = new Boy();
            //Girl girl = new Girl();
            ////达到间隔时发生
            //timer.Elapsed += boy.Action; //Jump!
            //timer.Elapsed += girl.Action; //Sing!
            //timer.Start();

            Test test = new Test();
            Test1 test1 = new Test1();
            test.Handler += new Test.EventHandler(test1.MethodA); //订阅事件
            test.Handler += n => 
            { 
                throw new ApplicationException("Here are an error!");
            };//Here are an error!
            //触发事件
            //test.Handler("hello"); //不能在外部类直接调用 报错
            //使用Start方法调用
            test.Start("Hello"); //Hello

            Test2 test2 = new Test2();
            Test3 test3 = new Test3();
            test2.action += test3.MethodA;
            test2.Start("World"); //World Test2

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    class Test2 // : System.EventArgs
    {
        public event Action<object, string> action = null;
        //EventHandler是一个委托,第一个参数为object
        //public event EventHandler<string> eventhandler = null;
        public Test2()
        {

        }
        public void Start(string str)
        {
            if (action != null)
            {
                //获取调用列表 异常处理
                foreach (Action<object, string> handle in action.GetInvocationList())
                {
                    try
                    {
                        //把当前类传出去
                        handle(this, str);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }

    class Test3
    {
        public void MethodA(object sender, string str)
        {
            if (sender is Test2)
            {
                str += " Test2";
            }
            Console.WriteLine(str);
        }
    }

    class Test
    {
        public delegate void EventHandler(string str); //声明委托
        public event EventHandler Handler; //定义事件
        public event Action<string> action; //Action委托
        public void Start(string str)
        {
            if (Handler != null)
            {
                //获取调用列表 异常处理
                foreach (EventHandler handle in Handler.GetInvocationList())
                {
                    try
                    {
                        handle(str);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //Handler(str);
            }
        }

        private void handle(string str)
        {
            throw new NotImplementedException();
        }
    }

    class Test1
    {
        public void MethodA(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Boy
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Jump!");
        }
    }

    class Girl
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sing!");
        }
    }

}
