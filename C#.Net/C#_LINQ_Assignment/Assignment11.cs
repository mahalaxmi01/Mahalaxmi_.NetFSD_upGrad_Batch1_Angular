using System;
using System.Collections.Generic;
using System.Linq;

namespace C__LINQ_Assignment
{

    internal class Assignment11
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Ravi", Department = "IT", Salary = 60000, JoiningDate = DateTime.Today.AddMonths(-2) },
            new Employee { Id = 2, Name = "Anita", Department = "HR", Salary = 50000, JoiningDate = DateTime.Today.AddMonths(-8) },
            new Employee { Id = 3, Name = "Karan", Department = "IT", Salary = 80000, JoiningDate = DateTime.Today.AddMonths(-4) },
            new Employee { Id = 4, Name = "Meena", Department = "Finance", Salary = 75000, JoiningDate = DateTime.Today.AddMonths(-10) },
            new Employee { Id = 5, Name = "Arjun", Department = "HR", Salary = 65000, JoiningDate = DateTime.Today.AddMonths(-1) },
            new Employee { Id = 6, Name = "Riya", Department = "Finance", Salary = 70000, JoiningDate = DateTime.Today.AddMonths(-5) }
        };

            // 1. Total employees
            Console.WriteLine("1. Total Employees:");
            Console.WriteLine(employees.Count());

            // 2. Department-wise average salary
            Console.WriteLine("\n2. Department-wise Average Salary:");
            var deptAvgSalary = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(e => e.Salary)
                });

            foreach (var item in deptAvgSalary)
            {
                Console.WriteLine(item.Department + " - " + item.AverageSalary);
            }

            // 3. Recently joined employees (last 6 months)
            Console.WriteLine("\n3. Recently Joined Employees (Last 6 Months):");
            var recentEmployees = employees
                .Where(e => e.JoiningDate >= DateTime.Today.AddMonths(-6));

            foreach (var emp in recentEmployees)
            {
                Console.WriteLine(emp.Name + " - " + emp.Department + " - " + emp.JoiningDate.ToShortDateString());
            }

            // 4. Highest paid employee per department
            Console.WriteLine("\n4. Highest Paid Employee Per Department:");
            var highestPaid = employees
                .GroupBy(e => e.Department)
                .Select(g => g.OrderByDescending(e => e.Salary).First());

            foreach (var emp in highestPaid)
            {
                Console.WriteLine(emp.Department + " - " + emp.Name + " - " + emp.Salary);
            }

            // 5. Salary distribution (min, max, avg)
            Console.WriteLine("\n5. Salary Distribution:");
            Console.WriteLine("Minimum Salary: " + employees.Min(e => e.Salary));
            Console.WriteLine("Maximum Salary: " + employees.Max(e => e.Salary));
            Console.WriteLine("Average Salary: " + employees.Average(e => e.Salary));
        }

    }
}
