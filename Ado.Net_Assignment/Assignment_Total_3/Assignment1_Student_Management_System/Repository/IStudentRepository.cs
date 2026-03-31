using Assignment1_Student_Management_System.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Student_Management_System.Repositories
{
    internal interface IStudentRepository
    {
        void AddStudent(StudentDataModel studentDataMobel);
        void DeleteStudent(int studentId);
        void UpdateStudent(int studentId, string dateOfBirth, char gender);

        StudentDataModel? GetStudent(int studentId);
        List<StudentDataModel> GetStudents();
    }
}
