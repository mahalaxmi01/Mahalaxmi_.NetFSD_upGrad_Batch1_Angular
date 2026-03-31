using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_1
{
    internal class Assignment1
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the secound number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int quotient = num1 / num2;
            Console.WriteLine("the quotient of the 2 numbers is " + quotient);

        }
    }
}
