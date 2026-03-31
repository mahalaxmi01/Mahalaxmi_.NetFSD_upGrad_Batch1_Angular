using Assignment1_Student_Management_System.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Assignment1_Student_Management_System.Repositories
{
    internal class StudentRepository:IStudentRepository
    {
        private SqlConnection? connection = null;
        string connectionString = "Data Source=CHINNI\\SqlExpress;Initial Catalog=SchoolDB;Integrated Security=True;Trust Server Certificate=True";
        public StudentRepository()
        {
            connection = new SqlConnection(connectionString);
        }
        private SqlCommand? command = null;
        private string? qry = null;
        public void  AddStudent(StudentDataModel studentDataModel)
        {
            try
            {
                qry = $"Insert into Students (FirstName, Gender, DateOfBirth) values " +
                      $"('{studentDataModel.FirstName}', '{studentDataModel.Gender}', '{studentDataModel.DateOfBirth}')";
                command = new SqlCommand(qry, connection);
                connection?.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("data added");
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                qry = $"Delete from Students where StudentID={studentId}";
                command = new SqlCommand(qry, connection);
                connection?.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw;
            }
           
            finally
            {
                connection.Close();
            }
        }

        public StudentDataModel? GetStudent(int studentId)
        {
            try
            {
                qry = $"select * from students where StudentID=" + studentId;
                command = new SqlCommand(qry, connection);
                connection?.Open();
                SqlDataReader reader = command.ExecuteReader();
                StudentDataModel? studentDataModel = null;
                if(reader.HasRows)
                {
                    reader.Read();
                    //convert reader data to studentdatamodel
                    studentDataModel = new StudentDataModel()
                    {
                        StudentID = Convert.ToInt32(reader["StudentID"]),
                        FirstName = reader["FirstName"].ToString(),
                        Gender = Convert.ToChar(reader["Gender"]),
                        DateOfBirth = reader["DateOfBirth"].ToString()
                    };
                }
                return studentDataModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
            
        }

        public List<StudentDataModel> GetStudents()
        {
            try
            {
                qry = "select * from Students";
                command = new SqlCommand(qry, connection);
                connection?.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<StudentDataModel> students = new List<StudentDataModel>();
                while (reader.Read())
                {
                    //Adding student to list
                    students.Add(
                        new StudentDataModel()
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            FirstName = reader["FirstName"].ToString(),
                            Gender = Convert.ToChar(reader["Gender"]),
                            DateOfBirth = reader["DateOfBirth"].ToString()
                        }
                        );
                    
                }
                return students;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
        }
        public void UpdateStudent(int studentId, String DateOfBirth,Char gender)
        {
            try
            {
                qry = $"Update Students set Gender='{gender}',DateOfBirth='{DateOfBirth}' where StudentID={studentId}";
                command = new SqlCommand(qry, connection);
                connection?.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
        }

    }
    class Test_Student
    {
        static void Main(String[] args)
        {
            try
            {
                Console.WriteLine("Student Managment App!!!!!!");
                StudentRepository studentRepository = new StudentRepository();
                do
                {
                    Console.WriteLine("1.AddStudent");
                    Console.WriteLine("2.DeleteStudent");
                    Console.WriteLine("3.UpdateStudent");
                    Console.WriteLine("4.GetStudent");
                    Console.WriteLine("5.GetAllStudent");
                    Console.WriteLine("6.Exit App");
                    Console.WriteLine("Enter Choice");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {
                                StudentDataModel model = new StudentDataModel();
                                Console.WriteLine("enter your name");
                                model.FirstName = Console.ReadLine();
                                Console.WriteLine("enter your gender");
                                model.Gender = char.Parse(Console.ReadLine());
                                Console.WriteLine("enter your DateOfBirth");
                                model.DateOfBirth = Console.ReadLine();
                                studentRepository.AddStudent(model);   
                                Console.WriteLine("Student added successfully");

                            }
                            break;
                        case 2:
                            {
                                //Delete student
                                Console.WriteLine("enter the studentid");
                                int studentId = int.Parse(Console.ReadLine());
                                studentRepository.DeleteStudent(studentId);
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine("enter the studentid");
                                int studentId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the gender");
                                char gender = char.Parse(Console.ReadLine());
                                Console.WriteLine("enter the DateOfBirth");
                                string DOB = Console.ReadLine();
                                studentRepository.UpdateStudent(studentId, DOB,gender);
                            }
                            break;
                        case 4:
                            {
                                //Get Student
                                Console.WriteLine("enter the studentid");
                                int studentId = int.Parse(Console.ReadLine());
                                StudentDataModel? model = studentRepository.GetStudent(studentId);
                                if (model != null)
                                {
                                    Console.WriteLine($"Id:{model.StudentID} Name:{model.FirstName} Gender:{model.Gender} DateOfBirth:{model.DateOfBirth}");
                                }
                                else
                                {
                                    Console.WriteLine("EmployeeId Invalid");
                                }
                            }
                            break;
                        case 5:
                            {
                                List<StudentDataModel> students = studentRepository.GetStudents();
                                foreach (var model in students)
                                {
                                    Console.WriteLine($"Id:{model.StudentID} Name:{model.FirstName} Gender:{model.Gender} DateOfBirth:{model.DateOfBirth}");

                                }
                            }
                            break;
                        case 6:
                            {
                                //closing app
                                Environment.Exit(0);
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid Choice");
                            }
                            break;
                    }
                } while (true);
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
