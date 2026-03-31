using System;
using System.Collections.Generic;
using System.Text;

namespace C__Inheritance_Assignment
{
    class Furniture
    {
        public int OrderId;
        public string OrderDate;
        public string FurnitureType;
        public int Qty;
        public double TotalAmt;
        public string PaymentMode;

        public virtual void GetData()
        {
            Console.Write("Enter Order Id: ");
            OrderId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Order Date: ");
            OrderDate = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            Qty = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Payment Mode (Credit Card / Debit Card): ");
            PaymentMode = Console.ReadLine();
        }

        public virtual void ShowData()
        {
            Console.WriteLine("Order Id      : " + OrderId);
            Console.WriteLine("Order Date    : " + OrderDate);
            Console.WriteLine("Furniture Type: " + FurnitureType);
            Console.WriteLine("Quantity      : " + Qty);
            Console.WriteLine("Payment Mode  : " + PaymentMode);
            Console.WriteLine("Total Amount  : " + TotalAmt);
        }
    }

    class Chair : Furniture
    {
        public string ChairType;
        public string Purpose;
        public string MaterialDetail;
        public double Rate;

        public override void GetData()
        {
            FurnitureType = "Chair";
            base.GetData();

            Console.Write("Enter Chair Type (Wood / Steel / Plastic): ");
            ChairType = Console.ReadLine();

            Console.Write("Enter Purpose (Home / Office): ");
            Purpose = Console.ReadLine();

            if (ChairType.ToLower() == "wood")
            {
                Console.Write("Enter Wood Type (Teak Wood / Rose Wood): ");
                MaterialDetail = Console.ReadLine();
            }
            else if (ChairType.ToLower() == "steel")
            {
                Console.Write("Enter Steel Type (Gray Steel / Green Steel / Brown Steel): ");
                MaterialDetail = Console.ReadLine();
            }
            else if (ChairType.ToLower() == "plastic")
            {
                Console.Write("Enter Plastic Color (Green / Red / Blue / White): ");
                MaterialDetail = Console.ReadLine();
            }

            Console.Write("Enter Rate: ");
            Rate = Convert.ToDouble(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            Console.WriteLine("\n----- Chair Details -----");
            base.ShowData();
            Console.WriteLine("Chair Type    : " + ChairType);
            Console.WriteLine("Purpose       : " + Purpose);
            Console.WriteLine("Material Info : " + MaterialDetail);
            Console.WriteLine("Rate          : " + Rate);
        }
    }

    class Cot : Furniture
    {
        public string CotType;
        public string MaterialDetail;
        public string Capacity;
        public double Rate;

        public override void GetData()
        {
            FurnitureType = "Cot";
            base.GetData();

            Console.Write("Enter Cot Type (Wood / Steel): ");
            CotType = Console.ReadLine();

            if (CotType.ToLower() == "wood")
            {
                Console.Write("Enter Wood Type (Teak Wood / Rose Wood): ");
                MaterialDetail = Console.ReadLine();
            }
            else if (CotType.ToLower() == "steel")
            {
                Console.Write("Enter Steel Type (Gray Steel / Green Steel / Brown Steel): ");
                MaterialDetail = Console.ReadLine();
            }

            Console.Write("Enter Capacity (Single / Double): ");
            Capacity = Console.ReadLine();

            Console.Write("Enter Rate: ");
            Rate = Convert.ToDouble(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            Console.WriteLine("\n----- Cot Details -----");
            base.ShowData();
            Console.WriteLine("Cot Type      : " + CotType);
            Console.WriteLine("Material Info : " + MaterialDetail);
            Console.WriteLine("Capacity      : " + Capacity);
            Console.WriteLine("Rate          : " + Rate);
        }
    }
    internal class Assignment_6
    {
        static void Main()
        {
            Furniture f;

            Console.WriteLine("Select Furniture Type");
            Console.WriteLine("1. Chair");
            Console.WriteLine("2. Cot");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                f = new Chair();
            }
            else if (choice == 2)
            {
                f = new Cot();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return;
            }

            f.GetData();
            f.ShowData();
        }
    }
}
