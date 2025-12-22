// "System Under Test (SUT)"

using System;

namespace BridgeLabz_Training.NUnit
{
    public class Calculator // CLASS

    // It contains the Production / Business Logic.
    {
        public string Owner { get; } // READ-ONLY PROPERTY TO STORE THE DETAIL FOR THE OWNER OF THE CALCULATOR.

        public Calculator(string owner)
        // PARAMETERIZED CONST (to initialize objects)
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("Owner name cannot be empty", nameof(owner));
            }

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
            // We can't let the DivideByZero Error occur here, so we will do defensive programming, and create an exception to catch it.

            if (b == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero");
            }
            return a / b;
        }
    }
}