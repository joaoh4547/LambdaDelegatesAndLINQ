using System;
using System.Collections.Generic;
using Delegates.Services;
using Project01.Entities;

namespace Delegates
{
    internal delegate double BinaryNumericOperation(double n1, double n2);

    internal delegate void MultCastBinaryNumericOperation(double n1, double n2);

    internal static class Program
    {
        public static void Main(string[] args)
        {
            ActionDelegate();
        }

        
        private static void ActionDelegate()
        {
            var products = new List<Product>
            {
                new Product {Id = 7, Name = "Hd Case", Price = 85.50},
                new Product {Id = 1, Name = "Notebook", Price = 2580.97},
                new Product {Id = 4, Name = "Tv", Price = 970.67},
                new Product {Id = 2, Name = "Tablet", Price = 800.00}
            };

            products.ForEach(product => { product.Price += product.Price * 0.1; });
            foreach (var product   in products) 
            {
                Console.WriteLine(product);
            }
        }

        private static void MulticastDelegate()
        {
            //  Multicast Delegate
            double a = 1, b = 92;
            MultCastBinaryNumericOperation operation = CalculationService.ShowSum;
            operation += CalculationService.ShowMax;
            operation(a, b);
        }

        private static void SumWithDelegates()
        {
            // Sum With Delegate
            double a = 18, b = 92;
            BinaryNumericOperation operation = CalculationService.Sum;
            var result = operation(a, b);
            Console.WriteLine(result);
        }
    }
}