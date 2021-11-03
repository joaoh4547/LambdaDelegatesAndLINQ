using System;
using Delegates.Services;

namespace Delegates
{
     delegate double BinaryNumericOperation(double n1, double n2);
    class Program
    {
        public static void Main(string[] args)
        {
            double a = 18, b = 92;
            BinaryNumericOperation operation = CalculationService.Sum;
            var result = operation(a, b);
            Console.WriteLine(result);
        }
    }
}