using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_1
{
    internal class Assignment6
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter the length of the square");
            int length = Convert.ToInt32(Console.ReadLine());
            int square_area = length * length;
            Console.WriteLine("Area of the square is "+ square_area);

            Console.WriteLine("enter the breath of the rectangle");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the height number");
            int h = Convert.ToInt32(Console.ReadLine());
            int rectangle_heigth = b * h;
            Console.WriteLine("the Area of the rectangle is "+ rectangle_heigth);
        }
    }
}
