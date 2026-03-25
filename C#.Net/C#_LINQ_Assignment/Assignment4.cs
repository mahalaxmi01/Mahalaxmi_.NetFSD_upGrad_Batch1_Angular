using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
    public DateTime JoiningDate { get; set; }
}

namespace C__LINQ_Assignment
{
    internal class Assignment4
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Ravi", Department = "IT", Salary = 60000 },
            new Employee { Id = 2, Name = "Anita", Department = "HR", Salary = 50000 },
            new Employee { Id = 3, Name = "Karan", Department = "IT", Salary = 80000 },
            new Employee { Id = 4, Name = "Meena", Department = "Finance", Salary = 75000 },
            new Employee { Id = 5, Name = "Arjun", Department = "HR", Salary = 55000 }
        };

            // 1. Get employees from IT department
            Console.WriteLine("Employees in IT Department:");
            foreach (var emp in employees.Where(e => e.Department == "IT"))
            {
                Console.WriteLine(emp.Name + " - " + emp.Salary);
            }

            // 2. Get highest salary employee
            var highest = employees.OrderByDescending(e => e.Salary).First();
            Console.WriteLine("\nHighest Salary Employee:");
            Console.WriteLine(highest.Name + " - " + highest.Salary);

            // 3. Get average salary
            double avgSalary = employees.Average(e => e.Salary);
            Console.WriteLine("\nAverage Salary: " + avgSalary);

            // 4. Group employees by Department
            Console.WriteLine("\nEmployees grouped by Department:");
            var grouped = employees.GroupBy(e => e.Department);
            foreach (var group in grouped)
            {
                Console.WriteLine("\nDepartment: " + group.Key);
                foreach (var emp in group)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Salary);
                }
            }

            // 5. Count employees in each department
            Console.WriteLine("\nEmployee count in each Department:");
            var countDept = employees.GroupBy(e => e.Department)
                                     .Select(g => new { Department = g.Key, Count = g.Count() });

            foreach (var item in countDept)
            {
                Console.WriteLine(item.Department + " - " + item.Count);
            }
        }
    }
}
