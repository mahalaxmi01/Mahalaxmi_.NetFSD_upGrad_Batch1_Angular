using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    internal class Hospital
    {
        static String hospital_name="maha_multi specilality";
        static String hospital_add = "hyd";
        String patientName;

        static void Main()
        {
            Hospital H1 = new Hospital();
            H1.patientName = "JANNU";
            Hospital H2 = new Hospital();
            H2.patientName = "MONNU";
            Hospital H3 = new Hospital();
            H3.patientName = "LITIEKESH";

            Console.WriteLine(hospital_name + "," + hospital_add + "," + H1.patientName);
            Console.WriteLine(hospital_name + "," + hospital_add + "," + H2.patientName);
            Console.WriteLine(hospital_name + "," + hospital_add + "," + H3.patientName);


        }

    }
}
