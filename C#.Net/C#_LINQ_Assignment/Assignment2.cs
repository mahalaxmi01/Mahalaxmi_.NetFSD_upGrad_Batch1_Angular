using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C__LINQ_Assignment
{
    internal class Assignment2
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

            // 1. Get even numbers
            Console.WriteLine("Even Numbers:");
            foreach (var n in numbers.Where(n => n % 2 == 0))
            {
                Console.WriteLine(n);
            }

            // 2. Get numbers greater than 15
            Console.WriteLine("\nNumbers greater than 15:");
            foreach (var n in numbers.Where(n => n > 15))
            {
                Console.WriteLine(n);
            }

            // 3. Find square of each number
            Console.WriteLine("\nSquares of numbers:");
            foreach (var n in numbers.Select(n => n * n))
            {
                Console.WriteLine(n);
            }

            // 4. Count numbers divisible by 5
            int count = numbers.Count(n => n % 5 == 0);
            Console.WriteLine("\nCount of numbers divisible by 5: " + count);
        }
    }
}
