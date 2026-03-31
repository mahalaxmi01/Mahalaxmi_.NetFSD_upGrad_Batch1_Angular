using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collection_Assignment
{
    using System;
    using System.Collections.Generic;

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; }
    }

    internal class Assignment_2
    {
        static void Main()
        {
           
            Dictionary<int, Student> students = new Dictionary<int, Student>();

            
            students.Add(1, new Student { Id = 1, Name = "Ravi", Marks = 85 });
            students.Add(2, new Student { Id = 2, Name = "Anita", Marks = 72 });
            students.Add(3, new Student { Id = 3, Name = "Karan", Marks = 90 });
            students.Add(4, new Student { Id = 4, Name = "Meena", Marks = 65 });
            students.Add(5, new Student { Id = 5, Name = "Sita", Marks = 78 });

            Console.WriteLine("All Students:");
            DisplayStudents(students);

            Console.WriteLine("\nEnter Student Id to Retrieve:");
            int searchId = Convert.ToInt32(Console.ReadLine());

            if (students.ContainsKey(searchId))
            {
                var s = students[searchId];
                Console.WriteLine($"Found: Id={s.Id}, Name={s.Name}, Marks={s.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            Console.WriteLine("\nEnter Student Id to Check:");
            int checkId = Convert.ToInt32(Console.ReadLine());

            if (students.ContainsKey(checkId))
                Console.WriteLine("Student exists.");
            else
                Console.WriteLine("Student does not exist.");

            Console.WriteLine("\nEnter Student Id to Update Marks:");
            int updateId = Convert.ToInt32(Console.ReadLine());

            if (students.ContainsKey(updateId))
            {
                Console.WriteLine("Enter new marks:");
                double newMarks = Convert.ToDouble(Console.ReadLine());

                students[updateId].Marks = newMarks;
                Console.WriteLine("Marks updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            Console.WriteLine("\nEnter Student Id to Remove:");
            int removeId = Convert.ToInt32(Console.ReadLine());

            if (students.ContainsKey(removeId))
            {
                students.Remove(removeId);
                Console.WriteLine("Student removed successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            Console.WriteLine("\nStudents with Marks > 75:");
            foreach (var s in students.Values)
            {
                if (s.Marks > 75)
                {
                    Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Marks: {s.Marks}");
                }
            }

            Console.WriteLine("\nUpdated Student List:");
            DisplayStudents(students);
        }

        static void DisplayStudents(Dictionary<int, Student> students)
        {
            foreach (var s in students.Values)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Marks: {s.Marks}");
            }
        }
    }
    
}
