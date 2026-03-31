using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_Assingment
{
    // Abstract Class
    abstract class Sales
    {
        protected int dailySales = 400;

        // Non-abstract method
        public int GetDailySales()
        {
            return dailySales;
        }

        // Abstract method
        public abstract int GetMonthlySales(int dailySales);
    }

    // Interface
    interface ISales
    {
        int GetYearlySales(int monthlySales);
    }

    // Main Class
    class SalesCalculator : Sales, ISales
    {
        // Implement abstract method
        public override int GetMonthlySales(int dailySales)
        {
            return dailySales * 30;
        }

        // Implement interface method
        public int GetYearlySales(int monthlySales)
        {
            return monthlySales * 12;
        }
    }
    internal class Assignment_2
    {
        static void Main(string[] args)
        {
            SalesCalculator obj = new SalesCalculator();

            int daily = obj.GetDailySales();
            int monthly = obj.GetMonthlySales(daily);
            int yearly = obj.GetYearlySales(monthly);

            Console.WriteLine("Daily sales: Rs." + daily);
            Console.WriteLine("Monthly sales: Rs." + monthly);
            Console.WriteLine("Annual sales: Rs." + yearly);

            Console.ReadLine();
        }

    }
}
