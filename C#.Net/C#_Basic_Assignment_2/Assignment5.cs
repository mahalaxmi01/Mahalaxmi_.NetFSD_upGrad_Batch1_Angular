using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment5
    {
        static void Main(String[] args)
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
            int even_count=0;
            int odd_count=0;
            if (num1 % 2 == 0)
            {
                even_count++;
            }
            else
            {
                odd_count++;
            }
            if (num2 % 2 == 0)
            {
                even_count++;
            }
            else
            {
                odd_count++;
            }
            if (num3 % 2 == 0)
            {
                even_count++;
            }
            else
            {
                odd_count++;
            }
            if (num4 % 2 == 0)
            {
                even_count++;
            }
            else
            {
                odd_count++;
            }
            if (num5 % 2 == 0)
            {
                even_count++;
            }
            else
            {
                odd_count++;
            }
            Console.WriteLine("the no.of even numbers count is " + even_count);
            Console.WriteLine("the no.of odd numbers count is " + odd_count);
        }
    }
}
