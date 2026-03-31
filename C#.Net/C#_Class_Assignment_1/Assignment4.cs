using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    internal class Appointment
    {
        int AppointmentId;
        String PatientName;
        String DoctorName;
        String AppointmentDate;

        public Appointment()
        {
            DoctorName = "General Physician";
            AppointmentDate = "12-03-2026";
        }

        static void Main()
        {
            Appointment app = new Appointment();
            Console.WriteLine(app.DoctorName);
            Console.WriteLine(app.AppointmentDate);
        }
    }
}
