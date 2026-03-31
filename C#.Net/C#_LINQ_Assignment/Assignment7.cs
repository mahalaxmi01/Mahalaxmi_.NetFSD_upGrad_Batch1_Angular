using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C__LINQ_Assignment
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
    internal class Assignment7
    {
        static void Main()
        {
            List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 55000, Stock = 5 },
            new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "Keyboard", Category = "Electronics", Price = 1500, Stock = 8 },
            new Product { Id = 4, Name = "Chair", Category = "Furniture", Price = 3000, Stock = 12 },
            new Product { Id = 5, Name = "Table", Category = "Furniture", Price = 7000, Stock = 0 },
            new Product { Id = 6, Name = "Pen", Category = "Stationery", Price = 20, Stock = 50 },
            new Product { Id = 7, Name = "Notebook", Category = "Stationery", Price = 60, Stock = 7 }
        };

            // 1. Get products with stock < 10
            Console.WriteLine("Products with Stock < 10:");
            foreach (var p in products.Where(p => p.Stock < 10))
            {
                Console.WriteLine(p.Name + " - " + p.Stock);
            }

            // 2. Get top 3 expensive products
            Console.WriteLine("\nTop 3 Expensive Products:");
            foreach (var p in products.OrderByDescending(p => p.Price).Take(3))
            {
                Console.WriteLine(p.Name + " - " + p.Price);
            }

            // 3. Group products by Category
            Console.WriteLine("\nProducts Grouped by Category:");
            var groupedProducts = products.GroupBy(p => p.Category);
            foreach (var group in groupedProducts)
            {
                Console.WriteLine("\nCategory: " + group.Key);
                foreach (var p in group)
                {
                    Console.WriteLine(p.Name + " - " + p.Price + " - Stock: " + p.Stock);
                }
            }

            // 4. Get total stock per category
            Console.WriteLine("\nTotal Stock per Category:");
            var totalStock = products.GroupBy(p => p.Category)
                                     .Select(g => new
                                     {
                                         Category = g.Key,
                                         TotalStock = g.Sum(p => p.Stock)
                                     });

            foreach (var item in totalStock)
            {
                Console.WriteLine(item.Category + " - " + item.TotalStock);
            }

            // 5. Check if any product is out of stock
            bool outOfStock = products.Any(p => p.Stock == 0);
            Console.WriteLine("\nIs any product out of stock? " + outOfStock);
        }
    }
}
