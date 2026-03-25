using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Student_Management_System.models
{
    internal class StudentDataModel
    {
        public int StudentID { get; set; }
        public string? FirstName { get; set; }
        public char Gender { get; set; }

        public string? DateOfBirth { get; set; }
    }
}
