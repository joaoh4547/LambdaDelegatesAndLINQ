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
            V3();
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
                new Product {Id = 10, Name = "Sound Bar", Price = 700, Category = c3},
                new Product {Id = 7, Name = "Camera", Price = 700, Category = c3},
                new Product {Id = 8, Name = "Printer", Price = 350, Category = c3},
                new Product {Id = 9, Name = "MacBook", Price = 1800, Category = c2},

                new Product {Id = 11, Name = "Level", Price = 70.0, Category = c1}
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900).ToList();
            Print("Tier 1 and price < 900", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name).ToList();
            Print("Name of Products From Tools", r2);

            var r3 = products.Where(p => p.Name.StartsWith("C")).Select(p =>
                new {p.Name, p.Price, CategoryName = p.Category.Name});

            Print("products starting with the letter c", r3);

            var r4 = products.Where(p => p.Category.Tier == 1)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ToList();
            Print("Tier 1 order by price then by name", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("Tier 1 order by price then by name skip 2 take 4", r5);

            var r6 = products.First();
            Console.WriteLine($"First -> {r6}");

            var r7 = products.Where(p => p.Price > 3000).FirstOrDefault();


            var r8 = products.Where(p => p.Id == 3).Single();
            Console.WriteLine($"Single -> {r8}");
            var r9 = products.Where(p => p.Id == 32).SingleOrDefault();
            Console.WriteLine($"Single Or Default -> {r9}");
            Console.WriteLine();


            var r10 = products.Max(p => p.Price);
            Console.WriteLine($"Max Price : {r10}");
            var r11 = products.Min(p => p.Price);
            Console.WriteLine($"Min Price : {r11}");

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine($"Category 1 Sum Prices : {r12}");

            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine($"Category 1 Average prices : {r13}");

            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine(r14);

            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine($"Category 1 aggregate sum {r15}");
            Console.WriteLine();
            var r16 = products.GroupBy(p => p.Category);

            foreach (var group in r16)
            {
                Console.WriteLine($"Category -> {group.Key.Name}:");
                foreach (var product in group)
                {
                    Console.WriteLine(product);
                }

                Console.WriteLine("------------------");
            }
        }

        private static void V3()
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
                new Product {Id = 10, Name = "Sound Bar", Price = 700, Category = c3},
                new Product {Id = 7, Name = "Camera", Price = 700, Category = c3},
                new Product {Id = 8, Name = "Printer", Price = 350, Category = c3},
                new Product {Id = 9, Name = "MacBook", Price = 1800, Category = c2},

                new Product {Id = 11, Name = "Level", Price = 70.0, Category = c1}
            };

            var r1 = from p in products where p.Category.Tier == 1 & p.Price < 900 select p;
            Print("Tier 1 and price < 900", r1);

            var r2 = from p in products where p.Category.Name == "Tools" select p.Name;
            Print("Name Of Products", r2);

            var r3 = from p in products
                where p.Name.StartsWith("C")
                select new {p.Name, p.Price, CategoryName = p.Category.Name};

            Print("Names Starts With 'C'", r3);

            var r4 = from p in products where p.Category.Tier == 1 orderby p.Name orderby p.Price select p;
            Print("Tier 1 Order by Price then by name ", r4);

            var r5 = (from p in r4 select p).Skip(2).Take(4);
                Print("Tier 1 Order by Price then by name SKIP 2 Take 4",r5);
        }
    
        private static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (var i in collection)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
        }
    }
}