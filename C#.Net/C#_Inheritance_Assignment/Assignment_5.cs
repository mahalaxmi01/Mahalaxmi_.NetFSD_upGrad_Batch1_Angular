using System;
using System.Collections.Generic;
using System.Text;

namespace C__Inheritance_Assignment
{
    // Base Class
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; }

        // Virtual Method
        public virtual string CalculateGrade()
        {
            return Marks > 50 ? "Pass" : "Fail";
        }
    }

    // School Student
    class SchoolStudent : Student
    {
        public override string CalculateGrade()
        {
            return Marks > 40 ? "Pass" : "Fail";
        }
    }

    // College Student
    class CollegeStudent : Student
    {
        public override string CalculateGrade()
        {
            return Marks > 50 ? "Pass" : "Fail";
        }
    }

    // Online Student
    class OnlineStudent : Student
    {
        public override string CalculateGrade()
        {
            return Marks > 60 ? "Pass" : "Fail";
        }
    }

    internal class Assignment_5
    {
        public static void Main(String[ ] args)
        {
            // Polymorphism using array
            Student[] students = new Student[3];

            students[0] = new SchoolStudent { StudentId = 1, Name = "Ravi", Marks = 45 };
            students[1] = new CollegeStudent { StudentId = 2, Name = "Anita", Marks = 55 };
            students[2] = new OnlineStudent { StudentId = 3, Name = "Kiran", Marks = 58 };

            foreach (Student student in students)
            {
                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Result: {student.CalculateGrade()}");
                Console.WriteLine("------------------------");
            }
        }
    }
}
