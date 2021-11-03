using System;
using Delegates.Services;

namespace Delegates
{
     delegate double BinaryNumericOperation(double n1, double n2);
     delegate void MultCastBinaryNumericOperation(double n1, double n2);
    class Program
    {
        public static void Main(string[] args)
        {
            MulticastDelegate();

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