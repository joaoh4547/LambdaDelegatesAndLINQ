using System;
using System.Collections.Generic;
using Project01.Entities;

namespace Project01
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product {Id = 7, Name = "Hd Case", Price = 85.50},
                new Product {Id = 1, Name = "Notebook", Price = 2580.97},
                new Product {Id = 4, Name = "Tv", Price = 970.67},
                new Product {Id = 2, Name = "Tablet", Price = 800.00}
            };

            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        
    }
}