using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment19
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Enter a word:");
            string word = Console.ReadLine();

            string reverse = "";

            for (int i = word.Length - 1; i >= 0; i--)
            {
                reverse += word[i];
            }

            if (word == reverse)
            {
                Console.WriteLine("The word is a Palindrome.");
            }
            else
            {
                Console.WriteLine("The word is not a Palindrome.");
            }

        }
    }
}
