using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    class Patient
    {
        int PatientId;
        String PatientName;
        int Age;
        String Disease;

        static void Main(String[] args)
        {
            Patient p = new Patient();
            p.PatientId = 101;
            p.PatientName = "maha";
            p.Age = 22;
            p.Disease = "unempolyment";
            Console.WriteLine(p.PatientId+","+p.PatientName+","+p.Age+","+p.Disease);
        }
    }
}
