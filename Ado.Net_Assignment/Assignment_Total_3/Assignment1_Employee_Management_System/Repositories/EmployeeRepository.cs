using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment1_Employee_Management_System.Repositories
{
    internal class EmployeeRepository:IEmployeeRepository
    {
        private SqlConnection? connection = null;
        string connectionString = "Data Source=CHINNI\\SqlExpress;Initial Catalog=NewPracticeDb;Integrated Security=True;Trust Server Certificate=True";
        public EmployeeRepository()
        {
            connection = new SqlConnection(connectionString);
        }
        private SqlCommand? command = null;
        private string? qry = null;
        public static void AddEmployee(string name, string dept, int salary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                    "Data Source=DESKTOP-4O1D65I\\SQLEXPRESS;Initial Catalog=NewPracticeDb;Integrated Security=True;Trust Server Certificate=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Department", dept);
                    command.Parameters.AddWithValue("@Salary", salary);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                    "Data Source=DESKTOP-4O1D65I\\SQLEXPRESS;Initial Catalog=NewPracticeDb;Integrated Security=True;Trust Server Certificate=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DeleteEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Employee deleted successfully");
                    else
                        Console.WriteLine("Employee not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetEmployeesByDept(string dept)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4O1D65I\\SQLEXPRESS;Initial Catalog=NewPracticeDb;Integrated Security=True;Trust Server Certificate=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetEmployeeByDept", connection);
                    //set Procedur
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //pass parameter values to store procedure
                    command.Parameters.AddWithValue("@deptname", dept);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id:{reader["EmployeeId"]} Name:{reader["Name"]} " +
                            $"Dept:{reader["Department"]} Salary:{reader["Salary"]}");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void GetAllEmployees()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                    "Data Source=DESKTOP-4O1D65I\\SQLEXPRESS;Initial Catalog=NewPracticeDb;Integrated Security=True;Trust Server Certificate=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("GetAllEmployees", connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id:{reader["EmployeeId"]} Name:{reader["Name"]} " +
                            $"Dept:{reader["Department"]} Salary:{reader["Salary"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateEmployee(int employeeId, string dept, int salary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                    "Data Source=DESKTOP-4O1D65I\\SQLEXPRESS;Initial Catalog=NewPracticeDb;Integrated Security=True;Trust Server Certificate=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@Department", dept);
                    command.Parameters.AddWithValue("@Salary", salary);

                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Employee updated successfully");
                    else
                        Console.WriteLine("Employee not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            EmployeeRepository repo = new EmployeeRepository();

            do
            {
                Console.WriteLine("\n===== Employee Management System =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Get Employees By Department");
                Console.WriteLine("5. Get All Employees");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Department: ");
                        string dept = Console.ReadLine();

                        Console.Write("Enter Salary: ");
                        int salary = Convert.ToInt32(Console.ReadLine());

                        EmployeeRepository.AddEmployee(name, dept, salary);
                        break;

                    case 2:
                        Console.Write("Enter Employee ID to delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        repo.DeleteEmployee(deleteId);
                        break;

                    case 3:
                        Console.Write("Enter Employee ID to update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Department: ");
                        string newDept = Console.ReadLine();

                        Console.Write("Enter New Salary: ");
                        int newSalary = Convert.ToInt32(Console.ReadLine());

                        repo.UpdateEmployee(updateId, newDept, newSalary);
                        break;

                    case 4:
                        Console.Write("Enter Department: ");
                        string searchDept = Console.ReadLine();

                        EmployeeRepository.GetEmployeesByDept(searchDept);
                        break;

                    case 5:
                        EmployeeRepository.GetAllEmployees();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 6);
        }


    }

}

