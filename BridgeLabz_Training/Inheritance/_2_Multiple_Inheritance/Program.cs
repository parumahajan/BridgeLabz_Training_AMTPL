using System;

namespace BridgeLabz_Training.Inheritance._2_Multiple_Inheritance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Intern intern = new Intern();
            intern.Name = "Pranav";

            intern.Work();    // From IWorker interface
            intern.Study();   // From IStudent interface

            Console.ReadLine();
        }
    }
}