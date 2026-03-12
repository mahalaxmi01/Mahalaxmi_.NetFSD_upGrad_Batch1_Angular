using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment10
    {
        static void Main(String[] args)
        {
            int a = 0, b = 1, next;

            Console.Write(a + " " + b + " ");

            next = a + b;

            while (next <= 40)
            {
                Console.Write(next + " ");
                a = b;
                b = next;
                next = a + b;
            }

        }
    }
}
