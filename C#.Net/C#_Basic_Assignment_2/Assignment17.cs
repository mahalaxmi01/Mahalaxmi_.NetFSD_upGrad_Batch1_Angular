using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment17
    {
        static void Main(String[] args)
        {

            Console.WriteLine("enter a string");
            String n1 = Console.ReadLine();
            String rev=null;
            for(int i = n1.Length -1; i >= 0; i--)
            {
                char ch = n1[i];
                rev = rev + ch;
            }
            Console.WriteLine(rev);

        }
    }
}
