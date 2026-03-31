using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C__LINQ_Assignment
{
    internal class Assignment9
    {
        static void Main()
        {
            List<Order> orders = new List<Order>()
        {
            new Order { Id = 1, CustomerName = "Ravi",  OrderDate = DateTime.Today.AddDays(-10),  TotalAmount = 2500 },
            new Order { Id = 2, CustomerName = "Anita", OrderDate = DateTime.Today.AddDays(-20),  TotalAmount = 4000 },
            new Order { Id = 3, CustomerName = "Kiran", OrderDate = DateTime.Today.AddDays(-35),  TotalAmount = 1500 },
            new Order { Id = 4, CustomerName = "Ravi",  OrderDate = DateTime.Today.AddDays(-50),  TotalAmount = 5000 },
            new Order { Id = 5, CustomerName = "Meena", OrderDate = DateTime.Today.AddDays(-65),  TotalAmount = 3500 },
            new Order { Id = 6, CustomerName = "Anita", OrderDate = DateTime.Today.AddDays(-75),  TotalAmount = 6000 },
            new Order { Id = 7, CustomerName = "Arjun", OrderDate = DateTime.Today.AddDays(-15),  TotalAmount = 2000 },
            new Order { Id = 8, CustomerName = "Ravi",  OrderDate = DateTime.Today.AddDays(-95),  TotalAmount = 7000 },
            new Order { Id = 9, CustomerName = "Meena", OrderDate = DateTime.Today.AddDays(-5),   TotalAmount = 4500 },
            new Order { Id = 10, CustomerName = "Kiran", OrderDate = DateTime.Today.AddDays(-25), TotalAmount = 3000 }
        };

            // 1. Get orders placed in last 30 days
            Console.WriteLine("Orders placed in last 30 days:");
            var last30DaysOrders = orders.Where(o => o.OrderDate >= DateTime.Today.AddDays(-30));

            foreach (var order in last30DaysOrders)
            {
                Console.WriteLine(order.Id + " - " + order.CustomerName + " - " +
                                  order.OrderDate.ToShortDateString() + " - " + order.TotalAmount);
            }

            // 2. Get monthly sales report
            Console.WriteLine("\nMonthly Sales Report:");
            var monthlySales = orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalSales = g.Sum(x => x.TotalAmount)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month);

            foreach (var item in monthlySales)
            {
                Console.WriteLine(item.Year + " - " + item.Month + " : " + item.TotalSales);
            }

            // 3. Get top 5 customers by spending
            Console.WriteLine("\nTop 5 Customers by Spending:");
            var topCustomers = orders
                .GroupBy(o => o.CustomerName)
                .Select(g => new
                {
                    CustomerName = g.Key,
                    TotalSpent = g.Sum(x => x.TotalAmount)
                })
                .OrderByDescending(x => x.TotalSpent)
                .Take(5);

            foreach (var customer in topCustomers)
            {
                Console.WriteLine(customer.CustomerName + " - " + customer.TotalSpent);
            }

            // 4. Get highest order per month
            Console.WriteLine("\nHighest Order Per Month:");
            var highestOrderPerMonth = orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => g.OrderByDescending(x => x.TotalAmount).First())
                .OrderBy(x => x.OrderDate.Year)
                .ThenBy(x => x.OrderDate.Month);

            foreach (var order in highestOrderPerMonth)
            {
                Console.WriteLine(order.OrderDate.Year + " - " + order.OrderDate.Month +
                                  " : " + order.CustomerName + " - " + order.TotalAmount);
            }
        }
    }
}
