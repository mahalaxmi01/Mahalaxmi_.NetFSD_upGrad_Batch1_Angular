using System;
using System.Collections.Generic;
using System.Text;

namespace C__Basic_Assignment_2
{
    internal class Assignment7
    {
        static void Main(String[] args)
        {
            Console.WriteLine("enter no of products that are sold in product1");
            int product_1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter no of products that are sold in product2");
            int product_2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter no of products that are sold in product3");
            int product_3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("productnumber            QuantitySold");
            Console.WriteLine("product_1               " + product_1);
            Console.WriteLine("product_2               " + product_2);
            Console.WriteLine("product_3               " + product_3);
            double total = product_1 * 22.5 + product_2 * 44.50 + product_3 * 9.98;
            Console.WriteLine("total price is " + total);





        }
    }
}
