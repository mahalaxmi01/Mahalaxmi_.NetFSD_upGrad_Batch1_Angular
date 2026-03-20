using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collection_Assignment
{
    using System;
    using System.Collections.Generic;

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    internal class Assignment_1
    {
        static void Main()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product { Id = 1, Name = "Laptop", Price = 50000, Category = "Electronics" });
            products.Add(new Product { Id = 2, Name = "Mobile", Price = 15000, Category = "Electronics" });
            products.Add(new Product { Id = 3, Name = "Headphones", Price = 1200, Category = "Accessories" });
            products.Add(new Product { Id = 4, Name = "Keyboard", Price = 800, Category = "Accessories" });
            products.Add(new Product { Id = 5, Name = "Mouse", Price = 500, Category = "Accessories" });
            products.Add(new Product { Id = 6, Name = "Chair", Price = 3000, Category = "Furniture" });
            products.Add(new Product { Id = 7, Name = "Table", Price = 7000, Category = "Furniture" });
            products.Add(new Product { Id = 8, Name = "Watch", Price = 2000, Category = "Fashion" });
            products.Add(new Product { Id = 9, Name = "Shoes", Price = 2500, Category = "Fashion" });
            products.Add(new Product { Id = 10, Name = "Bag", Price = 900, Category = "Fashion" });

            Console.WriteLine("All Products:");
            DisplayProducts(products);

            Console.WriteLine("\nProducts with Price > 1000:");
            var filteredProducts = products.Where(p => p.Price > 1000).ToList();
            DisplayProducts(filteredProducts);

            Console.WriteLine("\nProducts Sorted by Price (Ascending):");
            var ascProducts = products.OrderBy(p => p.Price).ToList();
            DisplayProducts(ascProducts);

            Console.WriteLine("\nProducts Sorted by Price (Descending):");
            var descProducts = products.OrderByDescending(p => p.Price).ToList();
            DisplayProducts(descProducts);

            Console.WriteLine("\nEnter Product Id to Remove:");
            int id = Convert.ToInt32(Console.ReadLine());

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.WriteLine("\nUpdated Product List:");
            DisplayProducts(products);
        }

        static void DisplayProducts(List<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}, Category: {p.Category}");
            }
        }
    }
}
