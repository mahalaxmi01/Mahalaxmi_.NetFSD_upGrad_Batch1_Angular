using System;
using System.Collections.Generic;
using System.Linq;

namespace C__LINQ_Assignment
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public int Marks { get; set; }
    }

    internal class Assignment1
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Ravi", Age = 20, Marks = 80 },
            new Student { Id = 2, Name = "Anita", Age = 22, Marks = 70 },
            new Student { Id = 3, Name = "Karan", Age = 19, Marks = 90 },
            new Student { Id = 4, Name = "Meena", Age = 26, Marks = 85 },
            new Student { Id = 5, Name = "Arjun", Age = 18, Marks = 60 }
        };

            // 1. Students with marks > 75
            Console.WriteLine("Students with Marks > 75:");
            foreach (var s in students.Where(s => s.Marks > 75))
            {
                Console.WriteLine(s.Name + " - " + s.Marks);
            }

            // 2. Students age between 18 and 25
            Console.WriteLine("\nStudents Age between 18 and 25:");
            foreach (var s in students.Where(s => s.Age >= 18 && s.Age <= 25))
            {
                Console.WriteLine(s.Name + " - " + s.Age);
            }

            // 3. Sort students by Marks (descending)
            Console.WriteLine("\nStudents sorted by Marks (Descending):");
            foreach (var s in students.OrderByDescending(s => s.Marks))
            {
                Console.WriteLine(s.Name + " - " + s.Marks);
            }

            // 4. Select only Name and Marks
            Console.WriteLine("\nName and Marks:");
            foreach (var s in students.Select(s => new { s.Name, s.Marks }))
            {
                Console.WriteLine(s.Name + " - " + s.Marks);
            }
        }
    }
            
}
