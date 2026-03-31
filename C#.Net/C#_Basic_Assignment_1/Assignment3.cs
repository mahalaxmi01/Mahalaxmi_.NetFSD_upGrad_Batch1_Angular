using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_1
{
    internal class Assignment3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the secound number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the third number");
            int num3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the fourth number");
            int num4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the fifth number");
            int num5 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2 + num3 + num4 + num5;
            int average = sum / 5;
            Console.WriteLine("sum of 5 numbers is " + sum);
            Console.WriteLine("average of 5 numbers is " + average);
        }
    }
}
