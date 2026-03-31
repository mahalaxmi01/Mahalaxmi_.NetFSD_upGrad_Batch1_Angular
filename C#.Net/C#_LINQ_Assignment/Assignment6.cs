using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C__LINQ_Assignment
{
    internal class Assignment6
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6 };

            // 1. Remove duplicates
            Console.WriteLine("Unique Numbers:");
            var unique = numbers.Distinct();
            foreach (var n in unique)
            {
                Console.WriteLine(n);
            }

            // 2. Find duplicate values
            Console.WriteLine("\nDuplicate Numbers:");
            var duplicates = numbers.GroupBy(n => n)
                                    .Where(g => g.Count() > 1)
                                    .Select(g => g.Key);

            foreach (var n in duplicates)
            {
                Console.WriteLine(n);
            }

            // 3. Count occurrence of each number
            Console.WriteLine("\nCount of each number:");
            var counts = numbers.GroupBy(n => n)
                                .Select(g => new { Number = g.Key, Count = g.Count() });

            foreach (var item in counts)
            {
                Console.WriteLine(item.Number + " - " + item.Count);
            }
        }
    }
}
