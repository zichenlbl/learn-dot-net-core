using System;

namespace ConsoleApp2_依赖反转
{
    class Program
    {
        static void Main(string[] args)
        {
            //当NokiaPhone出错时可以用EricssonPhone 低耦合 
            //var user = new PhoneUser(new NokiaPhone());
            var user = new PhoneUser(new EricssonPhone());
            user.UsePhone();

            var engine = new Engine();
            var car = new Car(engine);
            car.Run(3);
            Console.WriteLine(car.Speed); //30

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    class Engine
    {
        public int RPM { get; private set; }
        public void Work(int gas)
        {
            this.RPM = 1000 * gas;
        }
    }

    class Car
    {
        private Engine _engine;
        /// <summary>
        /// 解耦合 Car类依赖Engine类
        /// </summary>
        /// <param name="engine"></param>
        public Car(Engine engine)
        {
            _engine = engine;
        }

        public int Speed { get; private set; }
        public void Run(int gas)
        {
            _engine.Work(gas);
            this.Speed = _engine.RPM / 100;
        }
    }

    class PhoneUser
    {
        private IPhone _phone;
        public PhoneUser(IPhone phone)
        {
            _phone = phone;
        }

        public void UsePhone()
        {
            _phone.Dail();
            _phone.PickUp();
            _phone.Send();
            _phone.Receive();
        }
    }

    interface IPhone
    {
        void Dail();
        void PickUp();
        void Send();
        void Receive();
    }

    class NokiaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Nokia calling...");
        }

        public void PickUp()
        {
            Console.WriteLine("Hello! This is Tim!");
        }

        public void Receive()
        {
            Console.WriteLine("Nokia message ring...");
        }

        public void Send()
        {
            Console.WriteLine("Hello!");
        }
    }

    class EricssonPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Ericsson calling...");
        }

        public void PickUp()
        {
            Console.WriteLine("Hi! This is Tim!");
        }

        public void Receive()
        {
            Console.WriteLine("Ericsson message ring...");
        }

        public void Send()
        {
            Console.WriteLine("Hi!");
        }
    }
}
