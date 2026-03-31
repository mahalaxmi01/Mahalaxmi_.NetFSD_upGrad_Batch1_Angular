using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    internal class Nurse
    {
        int nurseid { get; set; }
        string nursename { get; set; }
        string department { get; set; }

        static void Main(String[] args)
        {
            Nurse n1 = new Nurse();
            n1.nurseid = 1;
            n1.nursename = "maha";
            n1.department = "ayurvedham";
            Console.WriteLine(n1.nurseid);
            Console.WriteLine(n1.nursename);
            Console.WriteLine(n1.department);


            Nurse n2 = new Nurse();
            n2.nurseid = 2;
            n2.nursename = "nani";
            n2.department = "medic";
            Console.WriteLine(n2.nurseid);
            Console.WriteLine(n2.nursename);
            Console.WriteLine(n2.department);



        }
    }
}
