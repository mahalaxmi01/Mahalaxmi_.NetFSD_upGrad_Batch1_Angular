using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_1
{
    internal class Assignment7
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the  distance of the jounery");
            int distance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the speed of the jounery");
            int speed = Convert.ToInt32(Console.ReadLine());
            int time = distance / speed;
            Console.WriteLine("the time taken for the journey is " + time+"s");

        }
    }
}
