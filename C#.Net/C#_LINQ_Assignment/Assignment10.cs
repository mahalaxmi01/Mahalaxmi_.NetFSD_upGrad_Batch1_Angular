using System;
using System.Collections.Generic;
using System.Text;

namespace C__LINQ_Assignment
{
    internal class Assignment10
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Ravi", Department = "IT", Salary = 60000 },
            new Employee { Id = 2, Name = "Anita", Department = "HR", Salary = 50000 },
            new Employee { Id = 3, Name = "Karan", Department = "IT", Salary = 80000 },
            new Employee { Id = 4, Name = "Meena", Department = "Finance", Salary = 75000 },
            new Employee { Id = 5, Name = "Arjun", Department = "HR", Salary = 65000 }
        };

            // Custom Sorting
            var sortedEmployees = employees
                .OrderBy(e => e.Department)              // Department ascending
                .ThenByDescending(e => e.Salary);       // Salary descending

            Console.WriteLine("Employees Sorted by Department (ASC) and Salary (DESC):");

            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine(emp.Department + " - " + emp.Name + " - " + emp.Salary);
            }
        }
    }
}
