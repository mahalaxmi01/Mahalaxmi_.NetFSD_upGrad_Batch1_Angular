using System;
using System.Collections.Generic;
using System.Text;

namespace C__Class_Assignment_1
{
    internal class MedicalTest
    {
        int testId;
        String testName;
        int cost;

        public MedicalTest(int testId, String testName, int cost)
        {
            this.testId = testId;
            this.testName = testName;
            this.cost = cost;
        }
         static void Main(String[] args)
        {
            MedicalTest mt1 = new MedicalTest(1,"bloodtest",2500);
            //mt1.testId = 1;
            //mt1.testName = "blood test";
            //mt1.cost = 2500;

            MedicalTest mt2 = new MedicalTest(2,"x-ray",10000);
            

            Console.WriteLine(mt1.testId + "," + mt1.testName + "," + mt1.cost);
            Console.WriteLine(mt2.testId + "," + mt2.testName + "," + mt2.cost);



        }

    }
}
