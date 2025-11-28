using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BridgeLabz_Training.Inheritance._5_Hybrid_Inheritance
{
    public class Employee : Person, IWork   // Hybrid: Inheriting class + interface
    {
        public double Salary;

        public void Work()
        {
            Console.WriteLine($"{Name} is working on company tasks.");
        }

        public void ShowEmployee()
        {
            Console.WriteLine($"Salary: {Salary}");
        }
    }
}