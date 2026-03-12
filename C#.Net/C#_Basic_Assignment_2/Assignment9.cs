using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment9
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the number that u want to find the factorial");
            int num = Convert.ToInt32(Console.ReadLine());
            int product = 1;
            for(int i = num; i >= 1; i--)
            {
                product = product * i;

            }
            Console.WriteLine("factorial of "+num+"is "+product);

        }
    }
}
