﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Investment Account has interest rates that vary, no overdraft and fee for failed transactions
    /// </summary>

    class InvestmentAccount : Account
    {
        // Apply Interest Rates
        private const double IR1 = 1.25;
        private const double IR2 = 2.25;
        // Add the Transaction fee on Withdrawal 
        private const double FEE = 1.75; 

        /// <summary>
        /// Constructor with account number
        /// </summary>
        /// <param name="accountNumber"></param>
        public InvestmentAccount(int accountNumber) 
            : base(accountNumber)
        {
        }

        /// <summary>
        /// Constructor with account number and initial balance
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="initBalance"></param>
        public InvestmentAccount(int accountNumber, double initBalance)
            : base(accountNumber, initBalance)
        {
        }


        /// <summary>
        /// Method to deposit an amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override bool Deposit(double amount)
        {
            // check positive
            if(amount < 0)
            {
                return false; 
            }
            else
            {
                balance += amount; 
            }

            return true; 
        }

        /// <summary>
        /// Method to withdraw funds
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override bool Withdraw(double amount)
        {
            if(amount > 0)
            {
                // sufficient balance
                if( (amount+FEE) <= balance)
                {
                    Console.WriteLine("Balance: {0}", balance);
                    balance -= (amount + FEE);
                    Console.WriteLine("{0}", (amount + FEE));
                    Console.WriteLine("Balance: {0}", balance);
                    return true;
                }
            }

            return false; 
        }

        /// <summary>
        /// Function to transfer funds. 
        /// </summary>
        /// <param name="toAccount"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override bool Transfer(Account toAccount, double amount)
        {
            // first check amount +ve
            // Balance is sufficient
            if(Withdraw(amount))
            {
                toAccount.Deposit(amount);
                return true; 
            }

            return false; 
        }

        /// <summary>
        /// Apply Interest to the Balance
        /// if balance is grater than 0, apply interest rate 1 
        /// if balance is greater than 1000 apply interest rate 2
        /// Interest rates that vary on all funds
        /// </summary>
        /// <returns></returns>
        public double ApplyInterest()
        {
            if (balance > 0)
            {
                double interest = balance * IR1;
                Deposit(interest);
                return interest;
            }
            else if (balance > 1000)
            {
                double interest = balance * IR2;
                Deposit(interest);
                return interest;
            }
            return -1;
            
        }

    }
}
