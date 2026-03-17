using System;
using System.Collections.Generic;
using System.Text;

namespace C__Inheritance_Assignment
{
    class Staff
    {
        // Properties
        public int StaffId { get; set; }
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        // Virtual Method
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    // Doctor Class
    class Doctor : Staff
    {
        public double ConsultationFee { get; set; }

        public override double CalculateSalary()
        {
            return BaseSalary + ConsultationFee;
        }
    }

    // Nurse Class
    class Nurse : Staff
    {
        public double NightShiftAllowance { get; set; }

        public override double CalculateSalary()
        {
            return BaseSalary + NightShiftAllowance;
        }
    }

    // Lab Technician Class
    class LabTechnician : Staff
    {
        public double EquipmentAllowance { get; set; }

        public override double CalculateSalary()
        {
            return BaseSalary + EquipmentAllowance;
        }
    }
    internal class Assignment_1
    {
        static void Main()
        {
            // Runtime Polymorphism
            Staff s1 = new Doctor
            {
                StaffId = 1,
                Name = "Dr. Ravi",
                BaseSalary = 50000,
                ConsultationFee = 20000
            };

            Staff s2 = new Nurse
            {
                StaffId = 2,
                Name = "Anita",
                BaseSalary = 30000,
                NightShiftAllowance = 8000
            };

            Staff s3 = new LabTechnician
            {
                StaffId = 3,
                Name = "Kiran",
                BaseSalary = 25000,
                EquipmentAllowance = 5000
            };

            // Display Salaries
            Console.WriteLine($"{s1.Name} Salary: {s1.CalculateSalary()}");
            Console.WriteLine($"{s2.Name} Salary: {s2.CalculateSalary()}");
            Console.WriteLine($"{s3.Name} Salary: {s3.CalculateSalary()}");
        }
    }
}
