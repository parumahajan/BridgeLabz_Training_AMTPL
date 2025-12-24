using System;

namespace BridgeLabz_Training.Review.BankingApplication
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
}