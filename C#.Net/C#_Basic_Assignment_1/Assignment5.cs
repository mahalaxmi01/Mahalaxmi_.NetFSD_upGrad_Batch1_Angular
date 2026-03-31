using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_1
{
    internal class Assignment5
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the secound number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 > num2)
            {
                Console.WriteLine(num1 + " is the highest number then " + num2);
            }
            else
            {
                Console.WriteLine(num2 + " is the highest number then " + num1);
            }
        }
    }
}
