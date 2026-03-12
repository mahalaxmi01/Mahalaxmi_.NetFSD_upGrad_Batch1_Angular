using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_1
{
    internal class Assignment8
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter a string");
            string  str = Console.ReadLine();
            char ch = str[2];
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' || ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
            {
                Console.WriteLine("3rd letter of the string i.e;" + ch + " is a vowel");
            }
            else
            {
                Console.WriteLine("3rd letter of the string i.e;" + ch + " is not a vowel");
            }

        }
    }
}
