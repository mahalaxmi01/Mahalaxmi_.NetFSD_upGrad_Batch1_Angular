using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment11
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the number that u want to get the multiplication table");
            int num = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i <= 20; i++)
            {
                Console.WriteLine(num + " * " + i + " = " + num * i);
            }

        }
    }
}
