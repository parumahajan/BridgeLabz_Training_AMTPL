using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BridgeLabz_Training.Inheritance._5_Hybrid_Inheritance
{
    public class Manager : Employee   // Multilevel continuation
    {
        public string Department;

        public void ManageTeam()
        {
            Console.WriteLine($"{Name} manages the {Department} department.");
        }
    }
}
