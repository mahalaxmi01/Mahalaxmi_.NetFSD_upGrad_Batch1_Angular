using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment6
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the temperature in fahrenheit");
            int temp = Convert.ToInt32(Console.ReadLine());
            int celcius = (temp - 32) * 5 / 9;
            Console.WriteLine("temperature in celcius is " + celcius);


        }
    }
}
