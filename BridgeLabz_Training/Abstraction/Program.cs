using System;

namespace BridgeLabz_Training.Abstraction
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Vehicle v;

            v = new Car();
            v.DisplayInfo();
            v.Start();
            v.Stop();
            Console.WriteLine();

            v = new Bike();
            v.DisplayInfo();
            v.Start();
            v.Stop();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}