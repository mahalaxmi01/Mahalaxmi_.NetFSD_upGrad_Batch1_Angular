using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_Assingment
{
    // Interface
    public interface GovtRules
    {
        double EmployeePF(double basicSalary);
        string LeaveDetails();
        double GratuityAmount(float serviceCompleted, double basicSalary);
    }

    // TCS Class
    public class TCS : GovtRules
    {
        private int empId;
        private string name;
        private string dept;
        private string desg;
        private double basicSalary;

        // Parameterized Constructor
        public TCS(int empId, string name, string dept, string desg, double basicSalary)
        {
            this.empId = empId;
            this.name = name;
            this.dept = dept;
            this.desg = desg;
            this.basicSalary = basicSalary;
        }

        // Properties
        public int EmpId
        {
            get { return empId; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Dept
        {
            get { return dept; }
        }

        public string Desg
        {
            get { return desg; }
        }

        public double BasicSalary
        {
            get { return basicSalary; }
        }

        // Interface Methods
        public double EmployeePF(double basicSalary)
        {
            double employeePF = basicSalary * 0.12;
            double employerPF = basicSalary * 0.0833;
            double pensionFund = basicSalary * 0.0367;

            Console.WriteLine("TCS PF Details");
            Console.WriteLine("Employee Contribution (12%)      : " + employeePF);
            Console.WriteLine("Employer Contribution (8.33%)    : " + employerPF);
            Console.WriteLine("Pension Fund Contribution (3.67%): " + pensionFund);

            return employeePF + employerPF + pensionFund;
        }

        public string LeaveDetails()
        {
            return "TCS Leave Details:\n" +
                   "1 day of Casual Leave per month\n" +
                   "12 days of Sick Leave per year\n" +
                   "10 days of Privilege Leave per year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
                return 3 * basicSalary;
            else if (serviceCompleted > 10)
                return 2 * basicSalary;
            else if (serviceCompleted > 5)
                return 1 * basicSalary;
            else
                return 0;
        }

        // Display Method
        public void DisplayDetails(float serviceCompleted)
        {
            Console.WriteLine("\n===== TCS Employee Details =====");
            Console.WriteLine("Employee ID   : " + EmpId);
            Console.WriteLine("Name          : " + Name);
            Console.WriteLine("Department    : " + Dept);
            Console.WriteLine("Designation   : " + Desg);
            Console.WriteLine("Basic Salary  : " + BasicSalary);

            Console.WriteLine();
            double totalPF = EmployeePF(BasicSalary);
            Console.WriteLine("Total PF Contribution : " + totalPF);

            Console.WriteLine();
            Console.WriteLine(LeaveDetails());

            Console.WriteLine();
            Console.WriteLine("Gratuity Amount : " + GratuityAmount(serviceCompleted, BasicSalary));
        }
    }

    // Accenture Class
    public class Accenture : GovtRules
    {
        private int empId;
        private string name;
        private string dept;
        private string desg;
        private double basicSalary;

        // Parameterized Constructor
        public Accenture(int empId, string name, string dept, string desg, double basicSalary)
        {
            this.empId = empId;
            this.name = name;
            this.dept = dept;
            this.desg = desg;
            this.basicSalary = basicSalary;
        }

        // Properties
        public int EmpId
        {
            get { return empId; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Dept
        {
            get { return dept; }
        }

        public string Desg
        {
            get { return desg; }
        }

        public double BasicSalary
        {
            get { return basicSalary; }
        }

        // Interface Methods
        public double EmployeePF(double basicSalary)
        {
            double employeePF = basicSalary * 0.12;
            double employerPF = basicSalary * 0.12;

            Console.WriteLine("Accenture PF Details");
            Console.WriteLine("Employee Contribution (12%)   : " + employeePF);
            Console.WriteLine("Employer Contribution (12%)   : " + employerPF);

            return employeePF + employerPF;
        }

        public string LeaveDetails()
        {
            return "Accenture Leave Details:\n" +
                   "2 days of Casual Leave per month\n" +
                   "5 days of Sick Leave per year\n" +
                   "5 days of Privilege Leave per year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        // Display Method
        public void DisplayDetails(float serviceCompleted)
        {
            Console.WriteLine("\n===== Accenture Employee Details =====");
            Console.WriteLine("Employee ID   : " + EmpId);
            Console.WriteLine("Name          : " + Name);
            Console.WriteLine("Department    : " + Dept);
            Console.WriteLine("Designation   : " + Desg);
            Console.WriteLine("Basic Salary  : " + BasicSalary);

            Console.WriteLine();
            double totalPF = EmployeePF(BasicSalary);
            Console.WriteLine("Total PF Contribution : " + totalPF);

            Console.WriteLine();
            Console.WriteLine(LeaveDetails());

            Console.WriteLine();
            Console.WriteLine("Gratuity Amount : Not Applicable");
        }
    }
    internal class Assignment_1
    {
        static void Main(string[] args)
        {
            TCS tcsEmp = new TCS(101, "Sai", "IT", "Developer", 50000);
            Accenture accEmp = new Accenture(201, "Laxmi", "HR", "Analyst", 60000);

            tcsEmp.DisplayDetails(12);
            accEmp.DisplayDetails(7);

            Console.ReadLine();
        }
    }
}
