using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_1
{
    internal class Assignment2
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter distence in KM");
            int distance = Convert.ToInt32(Console.ReadLine());
            int IN_M = distance * 1000;
            Console.WriteLine("the distance in meters is " + IN_M + "M");
        }
        
    }
}
