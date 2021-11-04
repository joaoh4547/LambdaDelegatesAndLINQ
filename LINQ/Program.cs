using System;
using System.Collections.Generic;
using System.Linq;
using LINQ.Entities;

namespace LINQ
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            V2();
        }

        private static void V1()
        {
            // Fonte de Dados
            var numbers = new int[] {2, 3, 4, 5, 6};


            // expressão 
            var result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10)
                .ToList();

            // Executar a consulta 

            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
        }

        private static void V2()
        {
            var c1 = new Category {Id = 1, Name = "Tools", Tier = 2};
            var c2 = new Category {Id = 2, Name = "Computers", Tier = 1};
            var c3 = new Category {Id = 3, Name = "Electronics", Tier = 1};

            var products = new List<Product>()
            {
                new Product {Id = 1, Name = "Computer", Price = 1100.58, Category = c2},
                new Product {Id = 2, Name = "Hammer", Price = 90.00, Category = c1},
                new Product {Id = 3, Name = "Tv", Price = 1700, Category = c3},
                new Product {Id = 4, Name = "Notebook", Price = 1300, Category = c2},
                new Product {Id = 5, Name = "Saw", Price = 80, Category = c1},
                new Product {Id = 6, Name = "Tablet", Price = 700, Category = c2},
                new Product {Id = 7, Name = "Camera", Price = 700, Category = c3},
                new Product {Id = 8, Name = "Printer", Price = 350, Category = c3},
                new Product {Id = 9, Name = "MacBook", Price = 1800, Category = c2},
                new Product {Id = 10, Name = "Sound Bar", Price = 700, Category = c3},
                new Product {Id = 11, Name = "Level", Price = 70.0, Category = c1}
            };

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}