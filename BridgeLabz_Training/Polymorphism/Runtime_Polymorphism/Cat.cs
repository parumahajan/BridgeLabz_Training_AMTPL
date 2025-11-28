using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Polymorphism.Runtime_Polymorphism
{
    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Cat meows: Meow Meow");
        }
    }
}
