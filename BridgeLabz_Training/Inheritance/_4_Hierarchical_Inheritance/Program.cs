using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Inheritance._4_Hierarchical_Inheritance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();
            Cow cow = new Cow();

            // Parent class method accessed by all child classes
            dog.Eat();
            dog.Bark();

            Console.WriteLine();

            cat.Eat();
            cat.Meow();

            Console.WriteLine();

            cow.Eat();
            cow.Moo();

            Console.ReadLine();
        }
    }
}