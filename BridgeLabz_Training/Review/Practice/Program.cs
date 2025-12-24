using System;

namespace BridgeLabz_Training.Review.Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Banking Application\n");

            decimal initBalance;

            while (true)
            {
                CW("Enter the initial balance");
                string? input = Console.ReadLine();

                if(decimal.TryParse(input, out initBalance) && initialBalance >= 0)
                {

                }
            }


        }
    }
}
