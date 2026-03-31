using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C__LINQ_Assignment
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
    }

    internal class Assignment5
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>()
        {
            new Customer { Id = 1, Name = "Ravi" },
            new Customer { Id = 2, Name = "Anita" },
            new Customer { Id = 3, Name = "Karan" },
            new Customer { Id = 4, Name = "Meena" }
        };

            List<Order> orders = new List<Order>()
        {
            new Order { Id = 1, CustomerId = 1, Amount = 2000 },
            new Order { Id = 2, CustomerId = 1, Amount = 4000 },
            new Order { Id = 3, CustomerId = 2, Amount = 3000 },
            new Order { Id = 4, CustomerId = 3, Amount = 1000 }
        };

            // 1. Join Customers and Orders
            Console.WriteLine("Customer Orders (Join):");
            var joinData = customers.Join(
                orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new { c.Name, o.Amount }
            );

            foreach (var item in joinData)
            {
                Console.WriteLine(item.Name + " - " + item.Amount);
            }

            // 2. Total order amount per customer
            Console.WriteLine("\nTotal Order Amount per Customer:");
            var totalAmount = orders.GroupBy(o => o.CustomerId)
                                    .Select(g => new
                                    {
                                        CustomerId = g.Key,
                                        Total = g.Sum(o => o.Amount)
                                    });

            foreach (var item in totalAmount)
            {
                var name = customers.First(c => c.Id == item.CustomerId).Name;
                Console.WriteLine(name + " - " + item.Total);
            }

            // 3. Customers with total orders > 5000
            Console.WriteLine("\nCustomers with Total Orders > 5000:");
            var highValueCustomers = totalAmount.Where(t => t.Total > 5000);

            foreach (var item in highValueCustomers)
            {
                var name = customers.First(c => c.Id == item.CustomerId).Name;
                Console.WriteLine(name + " - " + item.Total);
            }

            // 4. Customers who have no orders
            Console.WriteLine("\nCustomers with No Orders:");
            var noOrders = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id));

            foreach (var customer in noOrders)
            {
                Console.WriteLine(customer.Name);
            }
        }
    }
}
