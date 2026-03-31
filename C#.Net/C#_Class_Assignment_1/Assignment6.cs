using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    internal class Billing
    {
        string patientname;
        int ConsultationFee;
        int TestCharges;

        public Billing(String patientname,int ConsultationFee,int TestCharges)
        {
            this.patientname = patientname;
            this.ConsultationFee = ConsultationFee;
            this.TestCharges = TestCharges;
        }

        public  int CalculateTotalBill()
        {
            int totalbill = ConsultationFee + TestCharges;
            return totalbill;
        }

        static void Main(String[] args)
        {
            Billing b1 = new Billing("junnu", 2500, 2500);
            Console.WriteLine(b1.patientname);
            Console.WriteLine(b1.CalculateTotalBill());

            Billing b2 = new Billing("jattu", 1000, 2500);
            Console.WriteLine(b2.patientname);
            Console.WriteLine(b2.CalculateTotalBill());
        }
    }
}
