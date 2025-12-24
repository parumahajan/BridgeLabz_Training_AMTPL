using System;

namespace BridgeLabz_Training.Review.BankingApplication
{
    public class BankAccount
    {
        // Encapsulated balance
        private decimal balance;

        // Read-only access to balance
        public decimal Balance
        {
            get { return balance; }
        }

        // Constructor
        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative");
            }

            balance = initialBalance;
        }

        // Deposit method
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            balance += amount;
        }

        // Withdraw method
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > balance)
            {
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.");
            }

            balance -= amount;
        }
    }
}
