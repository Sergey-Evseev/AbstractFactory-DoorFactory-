/*Паттерн "Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс для создания семейств взаимосвязанных объектов 
 * с определенными интерфейсами без указания конкретных типов данных объектов.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_DoorFactory_
{
    interface Door
    {        
        string getDescription();
    }

    //класс деревенные двери
    class WoodenDoor : Door
    {
        //private Door door;
        public string getDescription()
        {
            return "Я деревянная дверь";
        }
    }
    //класс железные двери
    class IronDoor : Door
    {
        public string getDescription()
        {
            return "Я железная дверь";
        }
    }
    //интерфейс установщика дверей
    interface DoorFittingExpert
    {
        string getDescription();
    }
    //класс сварщика
    class Welder : DoorFittingExpert
    {
        public string getDescription()
        {
            return "Я могу устанавливать металлические двери";
        }
    }
    //класс плотника
    class Carpenter : DoorFittingExpert
    {
        public string getDescription()
        {
            return "Я могу устанавливать деревянные двери";
        }
    }
    //абстрактная фабрика
    abstract class DoorFactory 
    {
        public abstract Door makeDoor();
        public abstract DoorFittingExpert makeFittingExpert();
    }
    //класс деревянных дверей
    class WoodenDoorDactory : DoorFactory
    {
        public override Door makeDoor()
        {
           return new WoodenDoor();
        }

        public override DoorFittingExpert makeFittingExpert()
        {
           return new Carpenter();
        }
    }
    //класс железныйх дверей
    class IronDoorFactory : DoorFactory
    {
        public override Door makeDoor()
        {
           return new IronDoor();
        }

        public override DoorFittingExpert makeFittingExpert()
        {
           return new Welder();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            DoorFactory factory = new WoodenDoorDactory();
            Door door = factory.makeDoor();
            door.getDescription();

            DoorFittingExpert expert = factory.makeFittingExpert();
            expert.getDescription();

            Console.ReadKey();
        }
    }
}
