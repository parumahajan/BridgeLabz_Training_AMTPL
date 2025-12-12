using System;

namespace BridgeLabz_Training.NUnit
{
    public class Calculator
    {
        public string Owner { get; }

        public Calculator(string owner)
        {
            if (string.IsNullOrWhiteSpace(owner))
                throw new ArgumentException("Owner name cannot be empty.", nameof(owner));

            Owner = owner;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            return a / b;
        }
    }
}
