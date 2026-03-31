using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C__LINQ_Assignment
{
    
    internal class Assignment8
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Ravi", Class = "10A", Subject = "Math", Marks = 80 },
            new Student { Id = 2, Name = "Anita", Class = "10A", Subject = "Science", Marks = 70 },
            new Student { Id = 3, Name = "Karan", Class = "10A", Subject = "Math", Marks = 90 },
            new Student { Id = 4, Name = "Meena", Class = "10B", Subject = "Math", Marks = 85 },
            new Student { Id = 5, Name = "Arjun", Class = "10B", Subject = "Science", Marks = 75 },
            new Student { Id = 6, Name = "Riya", Class = "10B", Subject = "Math", Marks = 95 }
        };

            // 1 & 2 & 3 Combined: Group by Class -> then Subject -> Average Marks
            var result = students
                .GroupBy(s => s.Class)
                .Select(classGroup => new
                {
                    Class = classGroup.Key,
                    Subjects = classGroup
                        .GroupBy(s => s.Subject)
                        .Select(subjectGroup => new
                        {
                            Subject = subjectGroup.Key,
                            AverageMarks = subjectGroup.Average(s => s.Marks)
                        })
                });

            // Display result
            foreach (var cls in result)
            {
                Console.WriteLine("\nClass: " + cls.Class);

                foreach (var sub in cls.Subjects)
                {
                    Console.WriteLine("Subject: " + sub.Subject +
                                      " | Average Marks: " + sub.AverageMarks);
                }
            }
        }
    }
}
