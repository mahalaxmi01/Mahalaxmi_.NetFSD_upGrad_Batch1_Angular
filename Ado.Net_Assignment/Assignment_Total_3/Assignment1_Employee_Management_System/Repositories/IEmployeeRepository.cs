using Assignment1_Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Employee_Management_System.Repositories
{
    internal interface IEmployeeRepository
    {
        
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(int employeeId, string dept, int salary);
       
    }
}
