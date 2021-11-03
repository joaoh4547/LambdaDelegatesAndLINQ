using System;
using System.Collections.Generic;
using Project01.Entities;

namespace Project01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var products = new List<Product>();
            products.Add(new Product(4, "Tv", 900));
            products.Add(new Product(1, "Notebook", 2500));
            products.Add(new Product(2, "Tablet", 800));

            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        private static int CompareProducts(Product p1, Product p2)
        {
            return p1.Price.CompareTo(p2.Price);
        }
    }
}