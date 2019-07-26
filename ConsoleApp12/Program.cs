using System;

namespace ConsoleApp12
{
    abstract class Car
    {
        public Car(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetPrice();
    }

    class BasicEquipment : Car
    {
        public BasicEquipment() : base("базовая комплектация машины")
        { }
        public override int GetPrice()
        {
            return 40000;
        }
    }
    class LuxuryEquipment : Car
    {
        public LuxuryEquipment()
            : base("люксовая комплектация машины")
        { }
        public override int GetPrice()
        {
            return 60000;
        }
    }

    abstract class CarDecorator : Car
    {
        protected Car car;
        public CarDecorator(string n, Car car) : base(n)
        {
            this.car = car;
        }
    }

    class SportSet : CarDecorator
    {
        public SportSet(Car p)
            : base(p.Name + ", тюнинговый декор, спортивный обвес, нитро впрыск", p)
        { }

        public override int GetPrice()
        {
            return car.GetPrice() + 30000;
        }
    }

    class BuisnesSet : CarDecorator
    {
        public BuisnesSet(Car p)
            : base(p.Name + ", бронированный корпус, бронированный стекла, автоподкачка шин, система активной защиты", p)
        { }

        public override int GetPrice()
        {
            return car.GetPrice() + 500000;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new BasicEquipment();
            car1 = new SportSet(car1); // базовая комплектация машины + SportSet
            Console.WriteLine("Название: {0}", car1.Name);
            Console.WriteLine("Цена: {0}", car1.GetPrice());

            Car car2 = new LuxuryEquipment();
            // люксовая комплектация машины
            Console.WriteLine("Название: {0}", car2.Name);
            Console.WriteLine("Цена: {0}", car2.GetPrice());

            Car pizza3 = new LuxuryEquipment();            
            pizza3 = new BuisnesSet(pizza3);// люксовая комплектация машины + BuisnesSet
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetPrice());

            Console.ReadLine();
        }
    }
}
