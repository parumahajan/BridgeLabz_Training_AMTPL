using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Imp_Regex
{
    internal class Phone_No
    {
        public static void Main(String[] args)
        {
            string input = "My number is 8219744409";
            string pattern = @"\d{10}";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);

            // or Instead of these 2 steps, just write this one single step:

            // Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                Console.WriteLine("Found: " + match.Value);
            }
            else
            {
                Console.WriteLine("No Match Found");
            }
        }
    }
}