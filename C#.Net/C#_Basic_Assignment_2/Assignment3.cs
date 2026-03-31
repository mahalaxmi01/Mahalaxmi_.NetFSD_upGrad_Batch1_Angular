using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment3
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the Secound number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            for(int i=num1+1;i<num2;i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
