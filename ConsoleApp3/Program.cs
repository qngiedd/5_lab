using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Транспортное средство, Управление авто, Машина, Двигатель, Разумное существо, Человек, Трансформер;
namespace Lab5
{
    abstract class ThinkingCreature 
    {
        public abstract void Think();
    }
    interface CarControl
    {
        bool CheckStatus();
        void MoveForward();
        void MoveBack();
        void TurnLeft();
        void TurnRight();
        void Stop();
    }
    abstract class Vehicle 
    {
        public int WheelsNumber { get; set; }
        public abstract bool CheckStatus();
    }
    
    class Car : Vehicle
    {
        public bool IsActive { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public string ManufacturerCountry { get; set; }
        public int Cost { get; set; }
        public Car()
        {
            Model = "Toyota Camry";
            Speed = 100;
            ManufacturerCountry = "Japan";
            Cost = 10000;
            IsActive = false;
        }
        public Car(string model, int speed, string manufacturerCountry, int cost, bool isActive)
        {
            Model = model;
            Speed = speed;
            ManufacturerCountry = manufacturerCountry;
            Cost = cost;
            IsActive = isActive;
        }
        override public bool CheckStatus()
        {
            return IsActive;
        }
        public override string ToString()
        {
            return
                $"This is an object of {this.GetType()} " +
                $"type, with {this.GetHashCode()} hashcode.\n" +
                $"Model: {Model}\n" +
                $"Speed: {Speed}\n" +
                $"Cost: {Cost}\n" +
                $"TurnedOn:({IsActive})\n";
             
        }
    }
    class CarWithControl : Car, CarControl
    {
        
        public void MoveForward()
        {
            Console.WriteLine("The car is moving forward");
        }
        public void MoveBack()
        {
            Console.WriteLine("The car is moving back");
        }
        public void TurnLeft()
        {
            Console.WriteLine("The car is turning left");
        }
        public void TurnRight()
        {
            Console.WriteLine("The car is turning right");
        }
        public void Stop()
        {
            Console.WriteLine("The car has stopped!");
        }
    }
    sealed class Engine
    {
        public int Capacity { get; set; }
    }
    class Human : ThinkingCreature
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public override void Think()
        {
            
            Console.WriteLine("I can think");
        }
        public Human()
        { 
            Name = "undefined Name";
            SecondName = "undefined SecondName";
            Age = 0;
        }
        public Human(string name, string secondName, int age)
        {
            Name = name;
            SecondName = secondName;
            Age = age;
        }
        public override string ToString()
        {
            return 
                $"This is an object of {this.GetType()} type, " +
                $"with {this.GetHashCode()} hashcode.\n" +
                $"Name of the human is {Name}\n" +
                $"Surname: {SecondName}";
        }
    }
    class Transformer : Car
    {
        public bool IsPreparedForBattle { get; set; }
        public int NumberOfGuns { get; set; }
        public void Shoot()
        {
            Console.WriteLine("Poof!");
        }
        override public bool CheckStatus()
        {
            return IsPreparedForBattle;
        }
        public Transformer()
        {
            IsPreparedForBattle = false;
            NumberOfGuns = 0;
        }
        public Transformer(bool isPreparedForBattle, int numberOfGuns)
        {
            IsPreparedForBattle = isPreparedForBattle;
            NumberOfGuns = numberOfGuns;
        }
        public override string ToString()
        {
            return 
                $"This is an object of {this.GetType()} " +
                $"type, with {this.GetHashCode()} hashcode.\n" +
                $"Transformer prepared for battle ({IsPreparedForBattle})\n" +
                $"Number of guns: {NumberOfGuns}\n" +
                $"Model: {Model}\n" +
                $"Speed: {Speed}\n" +
                $"Cost: {Cost}\n" +
                $"TurnedOn:({IsActive})\n";
        }
    }
    class Printer
    {
        public virtual string IAmPrinting(Object obj)
        {
            if (obj != null)
            {
                return obj.ToString();
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human oHuman1 = new Human();
            Human oHuman2 = new Human("Angelina", "Draguts", 21);
            Human refHuman2 = oHuman2 as Human;

            Car oCar1 = new Car();
            Car oCar2 = new Car("Volvo XC90", 220, "Germany", 80000, true);
            Car refCar2 = oCar2 as Car;


            Transformer oTransfromer1 = new Transformer();
            Transformer oTransfromer2 = new Transformer(true,4);
            Transformer refTransfromer2 = oTransfromer2 as Transformer;

            Printer oPrinter = new Printer();
            Object[] arr = { refHuman2, refCar2, refTransfromer2 };
            
            foreach (object element in arr)
                Console.WriteLine(oPrinter.IAmPrinting(element)+ "\n_____________________________\n");

            Console.ReadKey();
        }
    }
}
