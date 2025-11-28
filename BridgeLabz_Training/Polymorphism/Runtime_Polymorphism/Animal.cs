using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Polymorphism.Runtime_Polymorphism
{
    public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal speaks in general sound.");
        }
    }
}

