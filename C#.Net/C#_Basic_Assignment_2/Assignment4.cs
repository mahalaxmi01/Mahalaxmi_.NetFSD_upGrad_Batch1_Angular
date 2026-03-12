using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment4
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine(num + " is a even number");
            }
            else
            {
                Console.WriteLine(num + " is a odd number");
            }
        }
    }
}
