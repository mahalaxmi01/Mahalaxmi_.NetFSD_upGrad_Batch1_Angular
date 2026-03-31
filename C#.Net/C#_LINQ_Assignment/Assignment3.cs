using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C__LINQ_Assignment
{
    internal class Assignment3
    {
        static void Main()
        {
            List<string> names = new List<string> { "Ravi", "Kiran", "Amit", "Raj", "Anil" };

            // 1. Names starting with 'A'
            Console.WriteLine("Names starting with 'A':");
            foreach (var name in names.Where(n => n.StartsWith("A")))
            {
                Console.WriteLine(name);
            }

            // 2. Sort names alphabetically
            Console.WriteLine("\nNames sorted alphabetically:");
            foreach (var name in names.OrderBy(n => n))
            {
                Console.WriteLine(name);
            }

            // 3. Convert all names to uppercase
            Console.WriteLine("\nNames in uppercase:");
            foreach (var name in names.Select(n => n.ToUpper()))
            {
                Console.WriteLine(name);
            }

            // 4. Names with length > 4
            Console.WriteLine("\nNames with length > 4:");
            foreach (var name in names.Where(n => n.Length > 4))
            {
                Console.WriteLine(name);
            }
        }
    }
}
