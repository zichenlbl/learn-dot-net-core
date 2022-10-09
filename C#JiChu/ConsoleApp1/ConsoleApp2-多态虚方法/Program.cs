using System;

namespace ConsoleApp2_多态虚方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //多态: 让一个对象能够表现出多种的状态(类型)
            //实现多态的三种方法: 虚方法、抽象类、接口
            Chinese chinese = new Chinese("张三");
            Chinese chinese2 = new Chinese("李四");

            Japanese japanese = new Japanese("树下君");
            Japanese japanese2 = new Japanese("井边子");

            Korea korea = new Korea("金秀贤");
            Korea korea2 = new Korea("金贤秀");

            American american = new American("科比布莱恩特");
            American american2 = new American("奥尼尔");

            Person[] people = { chinese, chinese2, japanese, 
                japanese2, korea, korea2, american, american2 };

            for (int i = 0; i < people.Length; i++)
            {
                people[i].SayHello();
                //if (people[i] is Chinese)
                //{
                //    ((Chinese)people[i]).SayHello();
                //}
                //else if (people[i] is Japanese)
                //{
                //    ((Japanese)people[i]).SayHello();
                //}
                //else if (people[i] is Korea)
                //{
                //    ((Korea)people[i]).SayHello();
                //}
                //else if (people[i] is American)
                //{
                //    ((American)people[i]).SayHello();
                //}
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Person
    {
        public Person(string name) //构造方法
        {
            this.Name = name;
        }

        private string _name; //字段

        public string Name //属性
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// virtual 标记为虚方法
        /// </summary>
        public virtual void SayHello() //方法
        {
            Console.WriteLine("我是人");
        }
    }

    public class Chinese : Person
    {
        public Chinese(string name) 
            : base (name)
        {

        }

        /// <summary>
        /// new 隐藏父类中的相同方法
        /// override 重写父类的方法
        /// </summary>
        public override void SayHello()
        {
            Console.WriteLine("我是中国人,我叫{0}.", this.Name);
        }
    }

    public class Japanese : Person
    {
        public Japanese(string name)
            : base(name)
        {

        }

        public override void SayHello()
        {
            Console.WriteLine("我是日本人,我叫{0}.", this.Name);
        }
    }

    public class Korea : Person
    {
        public Korea(string name)
            : base(name)
        {

        }

        public override void SayHello()
        {
            Console.WriteLine("我是韩国人,我叫{0}.", this.Name);
        }
    }

    public class American : Person
    {
        public American(string name)
            : base(name)
        {

        }

        public override void SayHello()
        {
            Console.WriteLine("我是美国人,我叫{0}.", this.Name);
        }
    }
}
