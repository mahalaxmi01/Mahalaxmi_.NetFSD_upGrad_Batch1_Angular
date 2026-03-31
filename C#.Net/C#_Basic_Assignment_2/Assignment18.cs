using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment18
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Enter first word:");
            string word1 = Console.ReadLine();

            Console.WriteLine("Enter second word:");
            string word2 = Console.ReadLine();

            if (word1 == word2)
            {
                Console.WriteLine("Both words are the same.");
            }
            else
            {
                Console.WriteLine("Both words are different.");
            }

        }
    }
}
