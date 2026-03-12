using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment14
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter a number");
            int n1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter a number");
            int n2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter a number");
            int n3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter a number");
            int n4 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter a number");
            int n5 = Convert.ToInt32(Console.ReadLine());

            int smallest = n1;

            if (n2 < smallest)
                smallest = n2;

            if (n3 < smallest)
                smallest = n3;

            if (n4 < smallest)
                smallest = n4;

            if (n5 < smallest)
                smallest = n5;

            Console.WriteLine("Smallest number is: " + smallest);

        }
    }
}
