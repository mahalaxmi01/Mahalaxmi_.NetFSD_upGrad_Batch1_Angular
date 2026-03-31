using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_ExceptionHandling
{
    // BankAccount Class
    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public static double balance = 1000; // Initial balance

        public char transactionType;
        public double transactionAmount;

        // Constructor
        public BankAccount(int accNo, string name, char type, double amount)
        {
            AccountNumber = accNo;
            Name = name;
            transactionType = type;
            transactionAmount = amount;
        }

        // Method to perform transaction
        public void ProcessTransaction()
        {
            if (transactionType == 'd' || transactionType == 'D')
            {
                // Deposit
                balance += transactionAmount;
                Console.WriteLine("Amount Deposited: " + transactionAmount);
            }
            else if (transactionType == 'c' || transactionType == 'C')
            {
                // Withdrawal
                if (balance - transactionAmount < 500)
                {
                    throw new CheckBalanceException("Minimum balance of 500 must be maintained!");
                }
                else
                {
                    balance -= transactionAmount;
                    Console.WriteLine("Amount Withdrawn: " + transactionAmount);
                }
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type!");
            }
        }

        public void Display()
        {
            Console.WriteLine("\nAccount Number: " + AccountNumber);
            Console.WriteLine("Name          : " + Name);
            Console.WriteLine("Balance       : " + balance);
        }
    }
    // User-defined Exception
    public class CheckBalanceException : Exception
    {
        public CheckBalanceException(string message) : base(message)
        {
        }
    }
    internal class Assignment_1
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount acc = new BankAccount(101, "Sai", 'c', 600);
                acc.ProcessTransaction();
                acc.Display();
            }
            catch (CheckBalanceException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
