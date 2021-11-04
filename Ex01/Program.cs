using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Ex01.Entities;
using System.Linq;

namespace Ex01
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var products = new List<Product>();
            Console.Write("Enter full file path: ");
            var path = Console.ReadLine();

            if (File.Exists(path) && path != null)
            {
                using (var reader = File.OpenText(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Split(',');
                        products.Add(new Product(line[0], double.Parse(line[1], CultureInfo.InvariantCulture)));
                    }
                }

                var avg = products.Average(p => p.Price);
                Console.WriteLine($"Average Price {avg.ToString("C", CultureInfo.GetCultureInfo("pt-br"))}");
                var names = products.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
                foreach (var productName in names)
                {
                    Console.WriteLine(productName);
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}