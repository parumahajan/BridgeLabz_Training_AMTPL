using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Regex
{
    internal class Email
    {
        public static void Main(String[] args)
        {
            string input = "pranavmahajan619@gmail.com";

            string pattern = @"\w+@\w+\.\w+";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(input);

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