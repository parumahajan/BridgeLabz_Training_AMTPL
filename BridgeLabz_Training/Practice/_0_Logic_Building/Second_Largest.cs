using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Practice._0_Logic_Building
{
    internal class Second_Largest
    {
        static void Main()
        {
            int[] arr = { 10, 20, 5, 8, 30 };

            Array.Sort(arr);
            Console.WriteLine(arr[arr.Length - 2]);
        }
    }
}