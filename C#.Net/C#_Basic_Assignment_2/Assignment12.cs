using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment12
    {
        static void Main(String[] args)
        {
            for(int i = 200; i <= 300; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine(i + " is divisble by 7");
                }
            }
        }
    }
}
