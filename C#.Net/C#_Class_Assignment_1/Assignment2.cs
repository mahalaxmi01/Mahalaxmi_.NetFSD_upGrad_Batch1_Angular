using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    internal class Doctor
    {
        int doctorid;
        String doctorname;
        String specialization;
        int consultationfee;

        static void Main(String[] args)
        {
            Doctor doc1 = new Doctor();
            Doctor doc2 = new Doctor();

            doc1.doctorid = 101;
            doc1.doctorname = "swapna";
            doc1.specialization = "ayurvedic";
            doc1.consultationfee = 2500;

            doc2.doctorid = 102;
            doc2.doctorname = "swarup";
            doc2.specialization = "medic";
            doc2.consultationfee = 1000;

            Console.WriteLine(doc1.doctorid);
            Console.WriteLine(doc1.doctorname);
            Console.WriteLine(doc1.specialization);
            Console.WriteLine(doc1.consultationfee);

            Console.WriteLine(doc2.doctorid);
            Console.WriteLine(doc2.doctorname);
            Console.WriteLine(doc2.specialization);
            Console.WriteLine(doc2.consultationfee);

        }
    }
}
