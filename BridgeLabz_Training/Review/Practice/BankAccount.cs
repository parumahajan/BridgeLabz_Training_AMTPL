using BridgeLabz_Training.Review.BankingApplication;
using System;

namespace BridgeLabz_Training.Review.Practice
{
    public class BankAccount
    {
        // encap 
        private decimal balance;

        // read-only
        public decimal Balance
        {
            get { return balance; }

        }

        // constructor
        public BankAccount(decimal initBalance)
        {
            if(initBalance < 0)
            {
                throw new ArgumentException("Initial Balance cannot be negative");
            }
            balance = initBalance;
        }

        // Deposit
        public void Deposit(decimal amt)
        {
            if(amt <= 0)
            {
                throw new ArgumentException("Deposit Amount should be greater than zero");
            }

            balance += amt;
        }

        // Withdraw
        public void Withdraw(decimal amt)
        {
            if(amt <= 0)
            {
                throw new ArgumentException("Withdraw Amount should be greater than zero");
            }

            if(amt > balance)
            {
                throw new InsuffientBalanceException("Insuffient balance for withdrawal");
            }

            balance -= amt;
        
 















    }
}