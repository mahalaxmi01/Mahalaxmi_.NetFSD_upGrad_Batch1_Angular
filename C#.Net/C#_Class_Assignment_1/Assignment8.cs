using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    internal class PatientRecord
    {
        int PatientId;
        string PatientName;
        int Age;
        String Disease;
        static String HospitalName = "Apollo Hospital";

        public PatientRecord(int PatientId,string PatientName,int Age,String Disease)
        {
            this.PatientId = PatientId;
            this.PatientName = PatientName;
            this.Age = Age;
            this.Disease = Disease;
        }

        public void DisplayPatientRecord()
        {
            Console.WriteLine("HospitalName: "+HospitalName);
            Console.WriteLine("PatientId: "+PatientId);
            Console.WriteLine("PatientName: "+PatientName);
            Console.WriteLine("Age: "+Age);
            Console.WriteLine("Disease: "+Disease);
        }

        static void Main(String[] args)
        {
            PatientRecord pr1 = new PatientRecord(101, "maha", 23, "unemployment");
            pr1.DisplayPatientRecord();

            PatientRecord pr2 = new PatientRecord(102, "chinni", 22, "mental");
            pr2.DisplayPatientRecord();

            PatientRecord pr3 = new PatientRecord(103, "sita", 21, "stress");
            pr3.DisplayPatientRecord();
        }
    }
}
