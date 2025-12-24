using System;

namespace BridgeLabz_Training.Review.Practice
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
}