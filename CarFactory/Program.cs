/*Паттерн "Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс для создания семейств взаимосвязанных объектов 
 с определенными интерфейсами без указания конкретных типов данных объектов.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory
{
    //интерфейс двигателя
    interface IEngine
    {
        void ReleaseEngine();
    }
    //конкретный класс двигателя
    class JapaneseEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("Японский двигатель");
    }
    //конкретный класс двигателя
    class RussianEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("Российский двигатель");
    }
    //интерфейс автомобиля
    interface ICar
    {
        void ReleaseCar(IEngine engine); //принимает ссылку на интерфейс двигатеоля
    }
    //класс конкретного автомобиля
    class JapaneseCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Собрали японский автомобиль: ");
            engine.ReleaseEngine();
        }
    }
    //класс конкретного автомобиля
    class RussianCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Собрали российский автомобиль: ");
            engine.ReleaseEngine();
        }
    }
    //интерфейс фабрики
    interface IFactory
    {
        IEngine createEngine(); //метод создающий двигатель
        ICar createCar(); //метод создающий автомобиль
    }
    //класс конкретной японской фабрики
    class JapaneseFactory : IFactory
    {
        public ICar createCar() => new JapaneseCar();
        public IEngine createEngine() => new JapaneseEngine();
    }
    //класс конкретной российской фабрики
    class RussianFactory : IFactory
    {
        public ICar createCar() => new RussianCar(); //создает и возвращает экземпляр автомобиля
        public IEngine createEngine() => new RussianEngine();
    }


    class Program
    {
        static void Main(string[] args)
        {
            //построение японской фабрики
            JapaneseFactory jFactory = new JapaneseFactory();
            //создание японского двигателя
            IEngine jEngine = jFactory.createEngine();
            //создание японского автомобилля
            ICar jCar = jFactory.createCar();
            jCar.ReleaseCar(jEngine);


            //построение российской фабрики 
            RussianFactory rFactory = new RussianFactory();
            //создание российкого двигателя
            IEngine rEngine = rFactory.createEngine();
            //создание росс. автомобиля
            ICar rCar = rFactory.createCar();
            //выпуск россиского автомобиля
            rCar.ReleaseCar(rEngine);
        }
    }
}
