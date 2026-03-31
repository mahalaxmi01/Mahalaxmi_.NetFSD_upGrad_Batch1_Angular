
using System;
using System.Collections.Generic;
using System.Text;

namespace C__Inheritance_Assignment
{
    class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        // Base Method
        public void CalculateInterest()
        {
            Console.WriteLine("Base account interest calculation");
        }
    }

    // Savings Account
    class SavingsAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Savings Account interest: 5%");
        }
    }

    // Current Account
    class CurrentAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Current Account interest: 2%");
        }
    }

    internal class Assignment_2
    {
        static void Main()
        {
            // Method Hiding Example
            Account acc = new SavingsAccount();
            acc.CalculateInterest();   // Calls Base Method

            // Accessing Derived Method
            SavingsAccount sa = new SavingsAccount();
            sa.CalculateInterest();    // Calls Savings Method

            CurrentAccount ca = new CurrentAccount();
            ca.CalculateInterest();    // Calls Current Method
        }
    }
}
