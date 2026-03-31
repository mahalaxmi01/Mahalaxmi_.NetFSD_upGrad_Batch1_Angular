using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment13
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter a number");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter a number");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter a number");
            int num3 = Convert.ToInt32(Console.ReadLine());
            int temp = 0;

            if (num1 > num2)
            {
                temp = num1;
                if (temp > num3)
                {
                    Console.WriteLine("largest number amoung the 3 numbers is "+ temp);
                }
                else
                {
                    Console.WriteLine("largest number amoung the 3 numbers is " + num3);
                }
            }
            else
            {
                temp = num2;
                if (temp > num3)
                {
                    Console.WriteLine("largest number amoung the 3 numbers is " + temp);
                }
                else
                {
                    Console.WriteLine("largest number amoung the 3 numbers is " + num3);
                }
            }




        }
    }
}
